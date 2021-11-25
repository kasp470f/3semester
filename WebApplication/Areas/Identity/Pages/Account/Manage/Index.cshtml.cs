using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication.Areas.Identity.Data;

namespace WebApplication.Areas.Identity.Pages.Account.Manage
{
    /// <summary>
    /// A model for the Index of Account 
    /// <para>Created by Kasper</para>
    /// </summary>
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<AccountIdentity> _userManager;
        private readonly SignInManager<AccountIdentity> _signInManager;

        // Created by Kasper
        public IndexModel(
            UserManager<AccountIdentity> userManager,
            SignInManager<AccountIdentity> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        /// The Input Model for the IndexModel
        /// <para>Created by Kasper</para>
        /// </summary>
        public class InputModel
        {
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Full name")]
            public string Name { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Address")]
            public string Address { get; set; }

            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
        }

        /// <summary>
        /// Load the user async
        /// <para>Created by Kasper</para>
        /// </summary>
        /// <param name="user">The account identity</param>
        private async Task LoadAsync(AccountIdentity user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                Name = user.FullName,
                Address = user.Address,
                PhoneNumber = phoneNumber
            };
        }

        /// <summary>
        /// <para>Created by Kasper</para>
        /// </summary>
        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        /// <summary>
        /// <para>Created by Kasper</para>
        /// </summary>
        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            if (Input.Name != user.FullName)
            {
                user.FullName = Input.Name;
            }

            if (Input.Address != user.Address)
            {
                user.Address = Input.Address;
            }

            await _userManager.UpdateAsync(user);

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}

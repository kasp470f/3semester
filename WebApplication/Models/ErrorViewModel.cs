using System;

namespace WebApplication.Models
{
    /// <summary>
    /// <para>Created by Kasper</para>
    /// </summary>
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}

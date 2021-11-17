using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFApplication.Model;
using WPFApplication.ViewModel;

namespace WPFApplication.Views
{
    /// <summary>
    /// Interaction logic for ViewUserControl.xaml
    /// </summary>
    public partial class ViewUserControl : UserControl
    {
        ParticipatesViewModel participates = new ParticipatesViewModel();

        public ViewUserControl()
        {
            InitializeComponent();
            this.DataContext = participates;
            GetAll();
            foreach (var item in Pp)
            {
                cmbParticipantList.Items.Add(item.Id+ "- " +item.Name);
            }
        }
        private List<Participate> participateList;

        public List<Participate> Pp
        {
            get { return participateList; }
            set { participateList = value; }
        }

        public void GetAll()
        {
            Pp = participates.GetAll();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
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
        string filePath = @"C:\Temp\data.csv";
        public ViewUserControl()
        {
            InitializeComponent();
            this.DataContext = participates;
            GetAll();
            foreach (var item in ParticipateList)
            {
                cmbParticipantList.Items.Add(item.Id+ "- " +item.Name);
            }
        }
        private List<Participate> participateList;

        public List<Participate> ParticipateList
        {
            get { return participateList; }
            set { participateList = value; }
        }

        public void GetAll()
        {
            ParticipateList = participates.GetAll();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

            if (!File.Exists(filePath))
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    string strData = cmbParticipantList.SelectedItem.ToString();
                    sw.WriteLine("{0}", strData);
                    sw.Close();
                }
            }
            else
            {
                StreamWriter sw = File.AppendText(filePath);
                string strData = cmbParticipantList.SelectedItem.ToString();
                string floatData = DateTime.Now.ToString("HH:mm");
                sw.WriteLine("{0},{1}", strData, floatData);
                MessageBox.Show("File exported to you Desktop!");

                

            }
            
            cmbParticipantList.Items.Remove(cmbParticipantList.SelectedItem);
        }

    }
}

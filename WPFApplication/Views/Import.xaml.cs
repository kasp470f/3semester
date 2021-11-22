using Microsoft.Win32;
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
using WPFApplication.ViewModel;

namespace WPFApplication.Views
{
    /// <summary>
    /// Interaction logic for Import.xaml
    /// </summary>
    public partial class Import : UserControl
    {
        ParticipatesViewModel participates = new ParticipatesViewModel();

        public Import()
        {
            InitializeComponent();
        }
        private List<string> participateList;

        public List<string> ParticipateList
        {
            get { return participateList; }
            set { participateList = value; }
        }

        public void GetAll()
        {
            ParticipateList = participates.GetAll();
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            string filePath = @"C:\Temp";

            //Browse File function
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //Filter files that will  be shown in files windows
            openFileDialog.Filter = "CSV  FILES|*.csv;*.xlsx;";
            // Show open file dialog box
            Nullable<bool> FileOk = openFileDialog.ShowDialog();
            // Process open file dialog box results
            if (FileOk == true)
            {
                //Save full file  path  inside a string
                string CSVFilePath = System.IO.Path.GetFullPath(openFileDialog.FileName);
                if (Directory.Exists(filePath) == false)
                {
                    Directory.CreateDirectory(filePath);
                }
                else
                {
                    if (File.Exists(@"C:\Temp\data.csv"))
                    {
                        File.Delete(@"C:\Temp\data.csv");
                    }

                }

                File.Copy(CSVFilePath, System.IO.Path.Combine(filePath, "data.csv"));
                GetAll();
                foreach (var item in ParticipateList)
                {
                    cmbParticipantList.Items.Add(item[0]);
                }
            }

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string fileSavePath = @"C:\Temp\savedData.csv";
            StreamWriter sw;
            if (!File.Exists(fileSavePath))
            {
                using (sw = File.CreateText(fileSavePath))
                {
                    if (cmbParticipantList.Items.Count > 0)
                    {
                        string strData = cmbParticipantList.SelectedItem.ToString();
                        string Time = DateTime.Now.ToString("HH:mm");
                        sw.WriteLine($"{strData},{Time}");
                        sw.Close();
                        MessageBox.Show("File Saved!");

                    }
                    else
                    {
                        MessageBox.Show("Du har ikke valgt et løbernummer fra list");
                    }

                }
            }
            else
            {
                using (FileStream fs = new FileStream(fileSavePath, FileMode.Append, FileAccess.Write))
                using (sw = new StreamWriter(fs))
                {
                    if (cmbParticipantList.Items.Count > 0)
                    {
                        string strData = cmbParticipantList.SelectedItem.ToString();
                        string Time = DateTime.Now.ToString("HH:mm");
                        sw.WriteLine($"{strData},{Time}");
                        sw.Close();
                        MessageBox.Show("File Saved!");

                    }
                    else
                    {
                        MessageBox.Show("Du har ikke valgt et løbernummer fra list");
                    }
                }

            }
            cmbParticipantList.Items.Remove(cmbParticipantList.SelectedItem);
        }

    }
}

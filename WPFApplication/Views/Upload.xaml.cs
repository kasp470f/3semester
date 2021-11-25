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
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

namespace WPFApplication.Views
{
    /// <summary>
    /// Interaction logic for Upload.xaml
    /// <para>Created by Rezan</para>
    /// </summary>
    public partial class Upload : UserControl
    {
        // Created by Rezan
        public Upload()
        {
            InitializeComponent();
        }

        // Created by Rezan
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string strPath = @"C:\Temp\savedData.csv";

            try
            {
                SqlConnection connString = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                connString.Open();
                string line;
                // Read the file and display it line by line.  
                StreamReader file = new StreamReader(strPath);
                while ((line = file.ReadLine()) != null)
                {
                    //Console.WriteLine(line);
                    var values = line.Split(';');
                    var Id = values[0];

                    DateTime date = DateTime.Parse(values[1]);
                    string format = "yyyy/MM/dd";
                    string Dato = date.ToString(format);

                    // Create SQL command here !
                    var query = $"INSERT";
                        SqlCommand command = new SqlCommand(query, connString);
                        command.ExecuteNonQuery();
                    
                }
                file.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("There were some errors when importing the file, the data in the file is not compatible with the database.");

            }
        }

        // Created by Rezan
        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            string strPath = @"C:\Temp\savedData.csv";
            string filename = null;
            // using the method
            if (strPath != "")
            {
                filename = Path.GetFileName(strPath);
                fileName.Text = "Filename = " + filename;
            }
            else
            {
                MessageBox.Show("File not exist!");
            }
           


        }
    }
}


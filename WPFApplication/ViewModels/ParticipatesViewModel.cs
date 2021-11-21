using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows;
using WPFApplication.Model;
using WPFApplication.Views;

namespace WPFApplication.ViewModel
{
    class ParticipatesViewModel
    {
       
       
        public List<string> GetAll()
        {
            var ParticipateList = new List<string>();

            string file = FilePath();
            try
            {
                var sw = new StreamReader(file);
                while (!sw.EndOfStream)
                {
                    var splits = sw.ReadLine().Split(";");
                    ParticipateList.Add(splits[0]);
                }
            }
            catch (Exception ex)
            {
                    MessageBox.Show(ex.Message);
            }
            return ParticipateList;
        }

        public string FilePath()
        {
            string filePath = @"C:\Temp\data.csv";
            return filePath;
        }

    }
}

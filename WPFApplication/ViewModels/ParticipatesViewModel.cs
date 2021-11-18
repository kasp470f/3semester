using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using WPFApplication.Model;
using WPFApplication.Views;

namespace WPFApplication.ViewModel
{
    class ParticipatesViewModel
    {
        ViewUserControl viewUser;
        public ParticipatesViewModel()
        {
            GetAll();
            
        }
       
        public List<Participate> GetAll()
        {
            SqlConnection connString = new SqlConnection(ConfigurationManager.ConnectionStrings["path"].ConnectionString);
            var  ParticipateList = new List<Participate>();
            try
            {
                if (connString.State == ConnectionState.Closed)
                {
                    connString.Open();
                    var query = "SELECT  * FROM  participants";
                    SqlCommand command = new SqlCommand(query, connString);
                    command.CommandType = CommandType.Text;
                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            ParticipateList.Add(new Participate
                            {
                                Id = (int)reader["Id"],
                        });

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                connString.Close();
            }
            return ParticipateList;
        }

        

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CustomerModule
{
    static class Utility
    {       
        static string[] querryParameters = new string[] { "@name", "@surname", "@telephone", "@address","@id" };
        static int indexParameter = 0;
        public static void ExecuteQuerry(List<TextBox> tbList,string connection,string query,int querryType)
        {           
            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    switch (querryType)
                    {
                        case 1:
                            foreach (TextBox tb in tbList)
                            {
                                command.Parameters.AddWithValue(querryParameters[indexParameter], tb.Text);
                                indexParameter++;
                            }
                            break;
                        case 2:
                            try
                            {
                                command.Parameters.AddWithValue(querryParameters[querryParameters.Length - 1], Int32.Parse(tbList[tbList.Count - 1].Text));
                            }
                            catch(Exception ex)
                            {
                                return; // When you don't select a row to delete.
                            }
                            break;
                        default:
                            break;
                    }
                    indexParameter = 0;
                    conn.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("There was an error: \n" /*+ ex.ToString()*/); //Sometimes database is set on Readonly and no update/delete/insert functionalities are possible --- Furture investigation
                System.Windows.Application.Current.Shutdown();                 // ---- Depends on user settings data can be on Readonly
            }
        }
        public static void FillDataGrid(string connection,string query,DataGrid dgCustomer)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                using (SqlDataAdapter daAdapter = new SqlDataAdapter(query, con))
                {
                    DataTable dtRecord = new DataTable();
                    daAdapter.Fill(dtRecord);
                    dgCustomer.ItemsSource = dtRecord.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error: \n" /*+ ex.ToString()*/);
                System.Windows.Application.Current.Shutdown();
            }
        }
        public static bool CheckEmptyInsert(List<TextBox> tbList)
        {
            bool noElement = true;
            foreach (TextBox tbc in tbList)
            {
                if (tbc.Text != "" && tbc.Name != "tbID")
                {
                    noElement = false;
                    break;
                }
            }
            if (noElement == true)
            {
                MessageBoxResult result = MessageBox.Show("All the entries are empty.Are you sure do you want to continue ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.No)
                {
                    return false;
                }
            }
            return true;
        }
    }
}

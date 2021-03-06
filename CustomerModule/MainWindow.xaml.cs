﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows;
using System.Windows.Controls;


namespace CustomerModule
{
    public partial class MainWindow : Window
    {

        List<TextBox> tbList = new List<TextBox>();
        public readonly String  connectionString = string.Empty;
        int RowId;
        string[] query = new string[] 
        {
            "Exec sp_Customer_Details",
            @"Exec sp_Insert_Customer @name,@surname,@telephone,@address",      // Querry type 1
            @"Exec sp_Delete_Customer @id",                                     // Querry type 2
            @"Exec sp_Update_Customer @id,@name,@surname,@telephone,@address",  // Querry type 1
        };
        DataRowView dataRow;
        int ColumnRowIndex = 0;

        public MainWindow()
        {
            InitializeComponent();
            tbList.AddMany<TextBox>(tbName, tbSurname, tbTelephone, tbAddress,tbID);
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(AppDomain.CurrentDomain.BaseDirectory)); 
            connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            Utility.FillDataGrid(connectionString,query[0],dgCustomer);
        }       

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            foreach (TextBox tb in tbList)
                tb.Text = string.Empty;
        }

        private void dgCustomer_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

            dataRow = (DataRowView)dgCustomer.SelectedItem;
            if(dataRow!=null)
                foreach (TextBox tb in tbList)
                {
                    tb.Text = dataRow.Row.ItemArray[ColumnRowIndex].ToString();
                    ColumnRowIndex++;
                }
            ColumnRowIndex = 0;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            RowId = dgCustomer.SelectedIndex;
            if (dgCustomer.SelectedIndex != -1)
            {
                Utility.ExecuteQuerry(tbList, connectionString, query[2], 2);
                Utility.FillDataGrid(connectionString, query[0], dgCustomer);
            }
            else MessageBox.Show("Please select a column to remove");
            if (RowId - 1 >= 0)
            {
                dgCustomer.SelectedIndex = RowId-1;
                dgCustomer.Focus();
            }
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            if (Utility.CheckEmptyInsert(tbList) == true)
            {
                Utility.ExecuteQuerry(tbList, connectionString, query[1], 1);
                Utility.FillDataGrid(connectionString, query[0], dgCustomer);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {   RowId = dgCustomer.SelectedIndex;
            if (dgCustomer.SelectedIndex != -1)
            {
                if (Utility.CheckEmptyInsert(tbList) == true)
                {
                    Utility.ExecuteQuerry(tbList, connectionString, query[3], 1);
                    Utility.FillDataGrid(connectionString, query[0], dgCustomer);
                }
            }
            else MessageBox.Show("Please select a column to modify");
            dgCustomer.SelectedIndex = RowId;
            dgCustomer.Focus();
        }

        private void dgCustomer_AutoGeneratedColumns(object sender, EventArgs e)
        {
            foreach (DataGridColumn col in dgCustomer.Columns) // Hide ID column 
            {
                if (col.Header.ToString() == "Id")
                {
                    col.Visibility = Visibility.Collapsed;
                    break;
                }
            }
        }

        private void tbTelephone_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1) ) // Check if input is Digit for Telephone
                e.Handled = true;
        }
    }
    
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace SchoolDataBase
{
    public partial class Form1 : Form
    {

        List<string> Errors = new List<string>();

        OleDbConnection con = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = School.mdb");
        DataTable DTable = new DataTable();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /**
             * con.Open();
             * DataTable schemaTable = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
             * con.Close();
             **/

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {

                string Table = comboBox1.SelectedItem.ToString();

                OleDbCommand com = new OleDbCommand("SELECT * FROM " + Table + ";", con);

                con.Open();
                com.ExecuteNonQuery();
                OleDbDataAdapter DAdapter = new OleDbDataAdapter(com);
                DAdapter.Fill(DTable);

                /**
                 * 
                 * Научить заполнять DataTable 
                 * 
                 **/
/*
                if (Table == "Pupils")
                {
                    DTable.Columns["id_pupil"].ColumnName = "ID";
                    DTable.Columns["Surname"].ColumnName = "Фамилия";
                    DTable.Columns["Name"].ColumnName = "Имя";
                    DTable.Columns["Patronymic"].ColumnName = "Отчество";
                    DTable.Columns["id_class"].ColumnName = "ID класса";
                    DTable.Columns["id_parents"].ColumnName = "ID родителей";

                    
                }
                if (Table == "Teachers")
                {

                }*/
                
                dataGridView1.DataSource = DTable;
                con.Close();

            }
            catch (Exception ex)
            {
                Errors.Add(ex.ToString());
            }
        
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            if(comboBox1.SelectedItem.ToString() == "") { button1.Enabled = false; }
        }
    }
}

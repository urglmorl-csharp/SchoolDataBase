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
    public partial class DBEditor : Form
    {

        string Table = "";

        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=School.mdb");
        DataTable DTable = new DataTable();

        public DBEditor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            m.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Ученики") { Table = "Pupils"; }
            if (comboBox1.SelectedItem.ToString() == "Учителя") { Table = "Teachers"; }
            if (comboBox1.SelectedItem.ToString() == "Классы") { Table = "Class"; }
            if (comboBox1.SelectedItem.ToString() == "Родители") { Table = "Parents"; }
            if (comboBox1.SelectedItem.ToString() == "Предметы") { Table = "Subjects"; }
            if (comboBox1.SelectedItem.ToString() == "Классный руководитель") { Table = "ClassroomTeacher"; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbCommand com = new OleDbCommand("SELECT * FROM " + Table + ";", conn);
            OleDbDataAdapter DAdapter = new OleDbDataAdapter(com);

            conn.Open();

            com.ExecuteNonQuery();
            DAdapter.Fill(DTable);
            //dataGridView1.Columns[0].Visible = false;

            conn.Close();
        }
    }
}

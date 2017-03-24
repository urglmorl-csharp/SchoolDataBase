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

        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=School.mdb");
        DataTable DTable = new DataTable();

        string Table = "";

        public DBEditor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main M = new Main();
            M.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
            if(comboBox1.SelectedItem.ToString() == "Ученики") { Table = "Pupils"; }
            if (comboBox1.SelectedItem.ToString() == "Учителя") { Table = "Teachers"; }
            if (comboBox1.SelectedItem.ToString() == "Классы") { Table = "Class"; }
            if (comboBox1.SelectedItem.ToString() == "Родители") { Table = "Parents"; }
            if (comboBox1.SelectedItem.ToString() == "Предметы") { Table = "Subjects"; }
            if (comboBox1.SelectedItem.ToString() == "Классные руководители") { Table = "ClassroomTeacher"; }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            DTable.Clear();
            DTable.Columns.Clear();

            OleDbCommand com = new OleDbCommand("SELECT * FROM " + Table + ";", conn);
            OleDbDataAdapter DAdapter = new OleDbDataAdapter(com);

            conn.Open();

            com.ExecuteNonQuery();
            DAdapter.Fill(DTable);
            dataGridView1.DataSource = DTable;

            conn.Close();

            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {

            string ID = dataGridView1.SelectedCells[0].Value.ToString();

        }
    }
}

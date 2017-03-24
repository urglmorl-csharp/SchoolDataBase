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
            //button2.Enabled = true;
            if(comboBox1.SelectedItem.ToString() == "Ученики") { Table = "Pupils"; }
            if (comboBox1.SelectedItem.ToString() == "Учителя") { Table = "Teachers"; }
            if (comboBox1.SelectedItem.ToString() == "Классы") { Table = "Class"; }
            if (comboBox1.SelectedItem.ToString() == "Родители") { Table = "Parents"; }
            if (comboBox1.SelectedItem.ToString() == "Предметы") { Table = "Subjects"; }
            if (comboBox1.SelectedItem.ToString() == "Классные руководители") { Table = "ClassroomTeacher"; }

            DTable.Clear();
            DTable.Columns.Clear();

            OleDbCommand com = new OleDbCommand("SELECT * FROM " + Table + ";", conn);
            OleDbDataAdapter DAdapter = new OleDbDataAdapter(com);

            conn.Open();

            com.ExecuteNonQuery();
            DAdapter.Fill(DTable);
            dataGridView1.DataSource = DTable;
            if (Table != "ClassroomTeacher") { dataGridView1.Columns[0].Visible = false; }

            conn.Close();

            if (Table == "Pupils")
            {
                dataGridView1.Columns[1].Name = "Имя";
                dataGridView1.Columns[2].Name = "Фамилия";
                dataGridView1.Columns[3].Name = "Отчество";
                dataGridView1.Columns[4].Name = "id_Класс";
                dataGridView1.Columns[5].Name = "id_Родители";
            }
            if (Table == "Teachers")
            {
                dataGridView1.Columns[1].Name = "Имя";
                dataGridView1.Columns[2].Name = "Фамилия";
                dataGridView1.Columns[3].Name = "Отчество";
                dataGridView1.Columns[4].Name = "Телефон";
            }
            if (Table == "Class")
            {
                dataGridView1.Columns[1].Name = "Класс";
                dataGridView1.Columns[2].Name = "id_Классный руководитель";
                dataGridView1.Columns[3].Name = "Номер кабинета";
            }
            if (Table == "Parents")
            {
                dataGridView1.Columns[1].Name = "Имя";
                dataGridView1.Columns[2].Name = "Фамилия";
                dataGridView1.Columns[3].Name = "Отчество";
                dataGridView1.Columns[4].Name = "Место работы";
                dataGridView1.Columns[5].Name = "Телефон";
            }
            if (Table == "Subjects")
            {
                dataGridView1.Columns[1].Name = "Предмет";
                dataGridView1.Columns[2].Name = "id_Учитель";
            }
            if (Table == "ClassroomTeacher")
            {
                dataGridView1.Columns[0].Name = "id_Классный руководитель";
                dataGridView1.Columns[1].Name = "id_Учитель";
            }

            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {

            //DTable.Columns.Clear();

            //OleDbCommand com = new OleDbCommand("SELECT * FROM " + Table + ";", conn);
            //OleDbDataAdapter DAdapter = new OleDbDataAdapter(com);

            //conn.Open();

            //com.ExecuteNonQuery();
            //DAdapter.Fill(DTable);
            //dataGridView1.DataSource = DTable;
            //if(Table != "ClassroomTeacher") { dataGridView1.Columns[0].Visible = false; }

            //conn.Close();

            //if(Table == "Pupils" )
            //{
            //    dataGridView1.Columns[1].Name = "Имя";
            //    dataGridView1.Columns[2].Name = "Фамилия";
            //    dataGridView1.Columns[3].Name = "Отчество";
            //    dataGridView1.Columns[4].Name = "id_Класс";
            //    dataGridView1.Columns[5].Name = "id_Родители";
            //}
            //if (Table == "Teachers" )
            //{
            //    dataGridView1.Columns[1].Name = "Имя";
            //    dataGridView1.Columns[2].Name = "Фамилия";
            //    dataGridView1.Columns[3].Name = "Отчество";
            //    dataGridView1.Columns[4].Name = "Телефон";
            //}
            //if (Table == "Class" )
            //{
            //    dataGridView1.Columns[1].Name = "Класс";
            //    dataGridView1.Columns[2].Name = "id_Классный руководитель";
            //    dataGridView1.Columns[3].Name = "Номер кабинета";
            //}
            //if (Table == "Parents" )
            //{
            //    dataGridView1.Columns[1].Name = "Имя";
            //    dataGridView1.Columns[2].Name = "Фамилия";
            //    dataGridView1.Columns[3].Name = "Отчество";
            //    dataGridView1.Columns[4].Name = "Место работы";
            //    dataGridView1.Columns[5].Name = "Телефон";
            //}
            //if (Table == "Subjects")
            //{
            //    dataGridView1.Columns[1].Name = "Предмет";
            //    dataGridView1.Columns[2].Name = "id_Учитель";
            //}
            //if (Table == "ClassroomTeacher")
            //{
            //    dataGridView1.Columns[0].Name = "id_Классный руководитель";
            //    dataGridView1.Columns[1].Name = "id_Учитель";
            //}

            //button3.Enabled = true;
            //button4.Enabled = true;
            //button5.Enabled = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {

            string ID = dataGridView1.SelectedCells[0].Value.ToString();


        }
    }
}

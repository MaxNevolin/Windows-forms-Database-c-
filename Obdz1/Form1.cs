using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Obdz1
{
    public partial class Form1 : Form
    {
        public DB DataBase1;
        public Form1()
        {
            InitializeComponent();
            DataBase1 = new DB();
            ShowTable();
        }
        public void ShowTable()
        {

            dataGridView1.DataSource = DataBase1.ConnectData("select * from electro order by date_elect", "table1");
            //DataTableReader dtr1=DataBase1.ConnectData("select * from electro order by date_elect", "table1").CreateDataReader();
            //string s = dtr1.Read();
            dataGridView1.Columns[0].HeaderText = "Дата замірювання";
            dataGridView1.Columns[1].HeaderText = "Показання лічильника";
            dataGridView1.Columns[2].HeaderText = "Додаткова ціна";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addform form_add = new addform("electro", "date_elect");
            form_add.Show();
            form_add.ValuesAdded += new ValuesAddedHandler(ShowTable);
            //if (form_add.ValuesAdded) ;
            /*DB DataBase1 = new DB();
            string datetmp = " '" + form_add.datestr + "' ";
            string valuetmp = " '" + form_add.valuecount.ToString() + "' ";
            dataGridView1.DataSource = DataBase1.getConnect("INSERT INTO electro(date_elect,curr_value ,price) VALUES(to_date(" + datetmp + ",'DD.MM.YYYY')," + valuetmp + ",0);", "table1");
            dataGridView1.DataSource = DataBase1.getConnect("select * from electro", "table1");*/

        }

        private void button2_Click(object sender, EventArgs e)
        {
            deleteform form_del = new deleteform("electro","date_elect");
            form_del.Show();
            form_del.ValuesDeleted += new ValuesDeletedHandler(ShowTable);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            updateform form_upd = new updateform("electro", "date_elect");
            form_upd.Show();
            form_upd.ValuesUpdated += new ValuesUpdatedHandler(ShowTable);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dateform form_d = new dateform("electro", "date_elect");
            form_d.ShowDialog();
           // if (form_d.sql != null)
            // {select avgprice('10.10.2011','27.10.2011') from dual
            if (form_d.sql != null)
            {
                dataGridView1.DataSource = DataBase1.ConnectData(form_d.sql, "table4");
                dataGridView1.Columns[0].HeaderText = "Сума за період";
            }
           // }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            monthform form_d = new monthform();
            form_d.table = "electro";
            form_d.ShowDialog();
            if (form_d.sql != null)
            {
                dataGridView1.DataSource = DataBase1.ConnectData(form_d.sql, "table4");
                dataGridView1.Columns[0].HeaderText = "Сума за місяць";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ShowTable();
        }
    }
}

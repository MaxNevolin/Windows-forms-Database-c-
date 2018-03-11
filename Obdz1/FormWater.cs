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
    public partial class FormWater : Form
    {
        public string table;
        public string date;
        public DB DataBase1;
        public FormWater()
        {
            InitializeComponent();
            DataBase1 = new DB();
            ShowFullTable();
        }
        public void ShowFullTable()
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            dataGridView1.DataSource = DataBase1.ConnectData("select * from coldwater full outer join hotwater on date_cwater=date_hwater", "table3");
            dataGridView1.Columns[0].HeaderText = "Дата замірювання (холодна вода)";
            dataGridView1.Columns[1].HeaderText = "Показання лічильника";
            dataGridView1.Columns[2].HeaderText = "Додаткова ціна";
            dataGridView1.Columns[3].HeaderText = "Дата замірювання (гаряча вода)";
            dataGridView1.Columns[4].HeaderText = "Показання лічильника";
            dataGridView1.Columns[5].HeaderText = "Додаткова ціна";

        }
        public FormWater(string s1,string s2)
        {
            table = s1;
            date = s2;
            InitializeComponent();
            if (s1 == "coldwater")
                label1.Text = "Холодна вода";
            else
                label1.Text = "Гаряча вода";
            DataBase1 = new DB();
            ShowTable();
        }

        public void ShowTable()
        {

            dataGridView1.DataSource = DataBase1.ConnectData("select "+date+",curr_value,price,sum(price)"
            +" over (order by "+ date+")as sum_price "
            + "from " + table + " order by "+ date, "table3");
            //DataTableReader dtr1=DataBase1.ConnectData("select * from electro", "table3").CreateDataReader();
            //string s = dtr1.Read();
            dataGridView1.Columns[0].HeaderText = "Дата замірювання";
            dataGridView1.Columns[1].HeaderText = "Показання лічильника";
            dataGridView1.Columns[2].HeaderText = "Додаткова ціна";
            dataGridView1.Columns[3].HeaderText = "Сумарна ціна";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            deleteform form_del = new deleteform(table, date);
            form_del.Show();
            form_del.ValuesDeleted += new ValuesDeletedHandler(ShowTable);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            updateform form_upd = new updateform(table, date);
            form_upd.Show();
            form_upd.ValuesUpdated += new ValuesUpdatedHandler(ShowTable);
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            addform form_add = new addform(table, date);
            form_add.Show();
            form_add.ValuesAdded += new ValuesAddedHandler(ShowTable);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            dateform form_d = new dateform(table, date);
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
            form_d.table = table;
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

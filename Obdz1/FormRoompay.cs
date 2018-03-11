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
    public partial class FormRoompay : Form
    {
        public DB DataBase1;

        public FormRoompay()
        {
            InitializeComponent();
            DataBase1 = new DB();
            ShowTable();
        }
        public void ShowTable()
        {

            dataGridView1.DataSource = DataBase1.ConnectData("select date_roompay,payhold ,paywarm,paygas,sum(payhold+paywarm+paygas) over (order by date_roompay) as sum from roompay", "table2");
            DataTableReader dtr1=DataBase1.ConnectData("select * from roompay", "table2").CreateDataReader();
            //string s = dtr1.Read();
            dataGridView1.Columns[0].HeaderText = "Дата";
            dataGridView1.Columns[1].HeaderText = "Ціна за утримання території";
            dataGridView1.Columns[2].HeaderText = "Ціна за опалення";
            dataGridView1.Columns[3].HeaderText = "Ціна за газ";
            dataGridView1.Columns[4].HeaderText = "Кумулятивна сума";
        }

             private void button2_Click_1(object sender, EventArgs e)
        {
            deleteform form_del = new deleteform("roompay", "date_roompay");
            form_del.Show();
            form_del.ValuesDeleted += new ValuesDeletedHandler(ShowTable);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            addroompay form_del = new addroompay();
            form_del.Show();
            form_del.Addroom += new AddroomHandler(ShowTable);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dateform form_d = new dateform("roompay", "date_roompay");
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
            form_d.table = "roompay";
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

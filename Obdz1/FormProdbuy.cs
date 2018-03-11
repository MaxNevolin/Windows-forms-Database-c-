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
    public partial class FormProdbuy : Form
    {
         public DB DataBase1;
        public FormProdbuy()
        {
            InitializeComponent();
                DataBase1 = new DB();
            ShowTable();
        }
        public void ShowTable()
        {

            dataGridView1.DataSource = DataBase1.ConnectData("select date_buy ,num_items ,products.name_prod,products.price,sumprice from prod_buy inner join products on prod_id=products.id","table6");

            //DataTableReader dtr1=DataBase1.ConnectData("select * from electro", "table3").CreateDataReader();
            //string s = dtr1.Read();
            dataGridView1.Columns[0].HeaderText = "Дата покупки";
            dataGridView1.Columns[1].HeaderText = "Кількість продуктів";
            dataGridView1.Columns[2].HeaderText = "Назва продукту";
            dataGridView1.Columns[3].HeaderText = "Ціна";
            dataGridView1.Columns[4].HeaderText = "Сумарна ціна";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addbuy form_add = new addbuy();
            form_add.Show();
            form_add.Addbuy += new AddbuyHandler(ShowTable);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            deleteform form_del = new deleteform("prod_buy","date_buy");
            form_del.Show();
            form_del.ValuesDeleted += new ValuesDeletedHandler(ShowTable);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dateform form_d = new dateform("prod_buy", "date_buy");
            form_d.ShowDialog();
            if (form_d.sql != null)
            {
                dataGridView1.DataSource = DataBase1.ConnectData(form_d.sql, "table4");
                dataGridView1.Columns[0].HeaderText = "Сума за період";
            }
            //form_del.ValuesDeleted += new ValuesDeletedHandler(ShowTable);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            monthform form_d = new monthform();
            form_d.table = "prod_buy";
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

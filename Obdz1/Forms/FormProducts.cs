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
    public partial class FormProducts : Form
    {
        public DB DataBase1;
        public FormProducts()
        {
            InitializeComponent();
            DataBase1 = new DB();
            ShowTable();
        }
        public void ShowTable()
        {

            dataGridView1.DataSource = DataBase1.ConnectData("SELECT id,id_parent,lpad(' ',10*level)||name_prod,price "
+ "FROM products START WITH id_parent IS NULL "
+ "CONNECT BY PRIOR id = id_parent "
+ "ORDER SIBLINGS BY name_prod", "table3");

            //DataTableReader dtr1=DataBase1.ConnectData("select * from electro", "table3").CreateDataReader();
            //string s = dtr1.Read();
            dataGridView1.Columns[0].HeaderText = "Код";
            dataGridView1.Columns[1].HeaderText = "Код категорії";
            dataGridView1.Columns[2].HeaderText = "Назва продукту";
            dataGridView1.Columns[3].HeaderText = "Ціна";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addproduct form_add = new addproduct();
            form_add.Show();
            form_add.ValuesChange += new ValuesChangeHandler(ShowTable);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kategform form_add = new kategform();
            form_add.Show();
            form_add.KatChange += new KatChangeHandler(ShowTable);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            delprod form_add = new delprod();
            form_add.Show();
            form_add.ValueDel += new ValueDelHandler(ShowTable);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ShowTable();
        }
    }
}

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
    public delegate void AddbuyHandler();
    public partial class addbuy : Form
    {
        public DB DataBase1;
        public event AddbuyHandler Addbuy;
        public addbuy()
        {
            InitializeComponent();
            DataBase1 = new DB();           
           
            addComboBox1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBase1.SqlExecute("insert into prod_buy(date_buy ,prod_id ,num_items ,sumprice) values('"+textBox2.Text+"',(select id from products where name_prod='"+comboBox1.Text+"'),"+textBox1.Text+",null)", false);
            if (Addbuy != null)
                Addbuy();
        }
        private void addComboBox1()
        {
            DataTableReader dr = DataBase1.ConnectData("select  name_prod from products where id_parent is not null", "table5").CreateDataReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}

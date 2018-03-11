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
    public delegate void ValuesChangeHandler();
    public partial class addproduct : Form
    {
        public DB DataBase1;
        public event ValuesChangeHandler ValuesChange;
        public addproduct()
        {
            DataBase1=new DB();
            InitializeComponent();
            addComboBox1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBase1.SqlExecute("insert into products(id ,id_parent ,name_prod ,price) values((select max(id)+1 from products),(select id from products where name_prod='"+comboBox1.Text+"'),'"+textBox1.Text+"',"+textBox2.Text+")", false);
            if (ValuesChange != null)
                ValuesChange();
        }
        private void addComboBox1()
        {
            DataTableReader dr = DataBase1.ConnectData("select distinct name_prod from products where id_parent is null","table5").CreateDataReader();
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

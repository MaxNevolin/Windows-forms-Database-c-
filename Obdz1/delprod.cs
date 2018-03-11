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
    public delegate void ValueDelHandler();
    public partial class delprod : Form
    {
        public DB DataBase1;
        public event ValueDelHandler ValueDel;
        public delprod()
        {
            InitializeComponent();
            DataBase1 = new DB();
            addComboBox1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBase1.SqlExecute("delete from products where name_prod='" + comboBox1.Text + "'", false);
            if (ValueDel != null)
                ValueDel();
        }
        private void addComboBox1()
        {
            DataTableReader dr = DataBase1.ConnectData("select distinct name_prod from products", "table5").CreateDataReader();
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

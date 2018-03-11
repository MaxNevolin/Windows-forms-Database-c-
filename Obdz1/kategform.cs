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
    public delegate void KatChangeHandler();
    public partial class kategform : Form
    {
        public DB DataBase1;
        public event KatChangeHandler KatChange;
        public kategform()
        {
            DataBase1 = new DB();
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DataBase1.SqlExecute("insert into products(id ,id_parent ,name_prod ,price) values((select max(id)+1 from products),null,'" + textBox1.Text + "',null)", false);
            if (KatChange != null)
                KatChange();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

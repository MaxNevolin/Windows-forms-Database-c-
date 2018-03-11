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
    public delegate void AddroomHandler();
    public partial class addroompay : Form
    {
        public DB DataBase1;
        public event AddroomHandler Addroom;
        public addroompay()
        {
            InitializeComponent();
            DataBase1 = new DB();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBase1.SqlExecute("insert into roompay(date_roompay,payhold ,paywarm,paygas,numpeople) values('" + textBox1.Text + "',null,null,null,3)", false);
            if (Addroom != null)
                Addroom();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

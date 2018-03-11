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
    public delegate void ValuesDeletedHandler();
    public partial class deleteform : Form
    {
        public DB DataBase1;
        public event ValuesDeletedHandler ValuesDeleted;
        public string datestr;
        public string table;
        public string date;
        public deleteform()
        {
            DataBase1 = new DB();
            InitializeComponent();
            addComboBox1();
        }
        public deleteform(string s1,string s2)
        {
            DataBase1 = new DB();
            InitializeComponent();
            table = s1;
            date = s2;
            addComboBox1();

        }
        private void addComboBox1()
        {
            if(table!="prod_buy")
            {
                comboBox4.Visible=false;
                label5.Visible=false;
            }
            DataTableReader dr = DataBase1.ConnectData("select distinct to_char(" + date + ",'yyyy') from " + table, "table4").CreateDataReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());
            }
            if (table == "prod_buy")
            {
                 dr = DataBase1.ConnectData("select distinct name_prod from products,prod_buy where id=prod_buy.prod_id","table5").CreateDataReader();
                     while (dr.Read())
                     {
                         comboBox4.Items.Add(dr[0].ToString());
                     }
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            datestr = "'" + comboBox3.Text;
            datestr += "." + comboBox2.Text;
            datestr += "." + comboBox1.Text + "'";
             if (table == "prod_buy")
            {
                datestr += " and prod_id=(select id from products where name_prod='" + comboBox4.Text + "')";
                 }
            //valuecount = float.Parse(textBox4.Text);       
            DataBase1.SqlExecute("DELETE FROM " +table+ " WHERE "+date+"=" + datestr,false);
            if (table == "electro")
                DataBase1.SqlExecute("CalcPriceElec", true);
            else if (table == "coldwater")
                DataBase1.SqlExecute("PriceWater", true);
            else if (table == "hotwater")
                DataBase1.SqlExecute("PriceHwater", true);
            if (ValuesDeleted != null)
                ValuesDeleted();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTableReader dr = DataBase1.ConnectData("select distinct to_char(" + date + ",'mm') from " + table+" where to_char("+date+",'yyyy')='"+comboBox1.Text+"'", "table4").CreateDataReader();
            comboBox2.Items.Clear();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr[0].ToString());
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            string tmp=comboBox2.Text;
            if(tmp.Length<2)
                tmp='0'+tmp;
            DataTableReader dr = DataBase1.ConnectData("select distinct to_char(" + date + ",'dd') from " + table + " where to_char(" + date + ",'yyyy')='" + comboBox1.Text + "' and to_char("+date+",'mm')='"+tmp+"'", "table4").CreateDataReader();
            comboBox3.Items.Clear();
            while (dr.Read())
            {
                comboBox3.Items.Add(dr[0].ToString());
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

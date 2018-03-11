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
    public delegate void ValuesUpdatedHandler();
    public partial class updateform : Form
    {
        public DB DataBase1;
        public event ValuesUpdatedHandler ValuesUpdated;
        public string datestr;
        public string table;
        public string date;
        public updateform()
        {
            DataBase1 = new DB();
            InitializeComponent();
        }
        public updateform(string s1, string s2)
        {
            DataBase1 = new DB();
            InitializeComponent();
            table = s1;
            date = s2;
            addComboBox1();

        }
        private void addComboBox1()
        {
            DataTableReader dr = DataBase1.ConnectData("select distinct to_char(" + date + ",'yyyy') from " + table, "table4").CreateDataReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());
            }

        }


        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            DataTableReader dr = DataBase1.ConnectData("select distinct to_char(" + date + ",'mm') from " + table + " where to_char(" + date + ",'yyyy')='" + comboBox1.Text + "'", "table4").CreateDataReader();
            comboBox2.Items.Clear();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr[0].ToString());
            }
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string tmp = comboBox2.Text;
            if (tmp.Length < 2)
                tmp = '0' + tmp;
            DataTableReader dr = DataBase1.ConnectData("select distinct to_char(" + date + ",'dd') from " + table + " where to_char(" + date + ",'yyyy')='" + comboBox1.Text + "' and to_char(" + date + ",'mm')='" + tmp + "'", "table4").CreateDataReader();
            comboBox3.Items.Clear();
            while (dr.Read())
            {
                comboBox3.Items.Add(dr[0].ToString());
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            datestr = "'" + comboBox3.Text;
            datestr += "." + comboBox2.Text;
            datestr += "." + comboBox1.Text + "'";
            //valuecount = float.Parse(textBox4.Text); 
            DataBase1.SqlExecute("Update " + table + " set curr_value=" + textBox4.Text + " WHERE "+date+" =" + datestr, false);
            if (table == "electro")
                DataBase1.SqlExecute("CalcPriceElec", true);
            else if (table == "coldwater")
                DataBase1.SqlExecute("PriceWater", true);
            else if (table == "hotwater")
                DataBase1.SqlExecute("PriceHwater", true);
            if (ValuesUpdated != null)
                ValuesUpdated();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

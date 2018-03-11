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
    public partial class dateform : Form
    {
        public DB DataBase1;
        public string datestr;
        public string datestr2;
        public string table;
        public string date;
        public string sql;
        public dateform()
        {
            InitializeComponent();
            DataBase1 = new DB();
            addComboBox();
        }
        public dateform(string t, string d)
        {
            table = t;
            date = d;
            InitializeComponent();
            DataBase1 = new DB();
            addComboBox();
        }
        private void addComboBox()
        {
            for (int i = 0; i < 15; i++)
            {
                comboBox1.Items.Add((i + 2000).ToString());
                comboBox6.Items.Add((i + 2000).ToString());
            }
            for (int i = 1; i < 13; i++)
            {
                comboBox2.Items.Add(i.ToString());
                comboBox5.Items.Add(i.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            DataTableReader dr = DataBase1.ConnectData("select trunc(last_day(to_date('" + comboBox5.Text + "','MM')))-trunc(to_date('" + comboBox5.Text + "','mm'),'mm')+1 from dual", "table4").CreateDataReader();
            int i = 0;
            while (dr.Read())
            {
                i = int.Parse((dr[0].ToString()));
            }
            while (i != 0)
            {
                comboBox4.Items.Add(i.ToString());
                i--;
            }
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            DataTableReader dr = DataBase1.ConnectData("select trunc(last_day(to_date('" + comboBox2.Text + "','MM')))-trunc(to_date('" + comboBox2.Text + "','mm'),'mm')+1 from dual", "table4").CreateDataReader();
            int i = 0;
            while (dr.Read())
            {
                i = int.Parse((dr[0].ToString()));
            }
            while (i != 0)
            {
                comboBox3.Items.Add(i.ToString());
                i--;
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            datestr = "'" + comboBox3.Text;
            datestr += "." + comboBox2.Text;
            datestr += "." + comboBox1.Text + "'";
            datestr2 = "'" + comboBox4.Text;
            datestr2 += "." + comboBox5.Text;
            datestr2 += "." + comboBox6.Text + "'";
            DataTableReader dr;
            //valuecount = float.Parse(textBox4.Text);select avgprice('10.10.2011','27.10.2011') from dual
            //DataBase1.SqlExecute("Alter trigger PriceElecTrig disable",false);
            if (table == "electro")
                sql = "select to_char(AvgPrice(to_date(" + datestr + ",'DD.MM.YYYY'),to_date(" + datestr2 + ",'DD.MM.YYYY')),'9999.99')as lol from dual";//dr = DataBase1.ConnectData("select AvgPrice(to_date(" + datestr + ",'DD.MM.YYYY'),to_date(" + datestr2 + ",'DD.MM.YYYY')) from dual", "table1").CreateDataReader();
            else if (table == "coldwater")
                sql = "select to_char(AvgPriceCW(to_date(" + datestr + ",'DD.MM.YYYY'),to_date(" + datestr2 + ",'DD.MM.YYYY')),'9999.99')as lol from dual";
            else if (table == "hotwater")
                sql = "select to_char(AvgPriceHW(to_date(" + datestr + ",'DD.MM.YYYY'),to_date(" + datestr2 + ",'DD.MM.YYYY')),'9999.99')as lol from dual";
            else if (table == "prod_buy")
                sql = "select to_char(AvgPricebuy(to_date(" + datestr + ",'DD.MM.YYYY'),to_date(" + datestr2 + ",'DD.MM.YYYY')),'9999.99')as lol from dual";
            else if (table == "roompay")
                sql = "select to_char(AvgPriceRP(to_date(" + datestr + ",'DD.MM.YYYY'),to_date(" + datestr2 + ",'DD.MM.YYYY')),'9999.99')as lol from dual";
            this.Close();
        }

    }
}

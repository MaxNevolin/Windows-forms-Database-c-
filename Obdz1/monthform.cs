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
    public partial class monthform : Form
    {
        public string datestr;
        public string datestr2;
        public string table;
        public string date;
        public string sql;
        public monthform()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            datestr = "'01";
            datestr += "." + textBox2.Text;
            datestr += "." + textBox1.Text + "'";
            datestr2 = "'01";
            if (textBox2.Text == "12")
            {
                datestr2 += ".01";
                datestr2 += "." + (int.Parse(textBox1.Text) + 1).ToString()+"'";
            }
            else
            {
                datestr2 += "." + (int.Parse(textBox2.Text) + 1).ToString();
                datestr2 += "." + textBox1.Text + "'";
            }
            DataTableReader dr;
            //valuecount = float.Parse(textBox4.Text);select avgprice('10.10.2011','27.10.2011') from dual
            //DataBase1.SqlExecute("Alter trigger PriceElecTrig disable",false);
            if (table == "electro")
                sql = "select to_char(AvgPrice(to_date(" + datestr + ",'DD.MM.YYYY'),to_date(" + datestr2 + ",'DD.MM.YYYY')),'9999.99')as lol from dual";//dr = DataBase1.ConnectData("select AvgPrice(to_date(" + datestr + ",'DD.MM.YYYY'),to_date(" + datestr2 + ",'DD.MM.YYYY')) from dual", "table1").CreateDataReader();
            else if (table == "coldwater")
                sql = "select to_char(AvgPriceCW(to_date(" + datestr + ",'DD.MM.YYYY'),to_date(" + datestr2 + ",'DD.MM.YYYY')),'9999.99')as lol from dual";
            //DataBase1.SqlExecute("PriceWater", true);
            else if (table == "hotwater")
                sql = "select to_char(AvgPriceHW(to_date(" + datestr + ",'DD.MM.YYYY'),to_date(" + datestr2 + ",'DD.MM.YYYY')),'9999.99')as lol from dual";
            else if (table == "prod_buy")
                sql = "select to_char(AvgPricebuy(to_date(" + datestr + ",'DD.MM.YYYY'),to_date(" + datestr2 + ",'DD.MM.YYYY')),'9999.99')as lol from dual";
            else if (table == "roompay")
                sql = "select to_char(AvgPriceRP(to_date(" + datestr + ",'DD.MM.YYYY'),to_date(" + datestr2 + ",'DD.MM.YYYY')),'9999.99')as lol from dual";   //DataBase1.SqlExecute("PriceHwater", true);
           this.Close();
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
    public delegate void ValuesAddedHandler();
    public partial class addform : Form
    {
        public DB DataBase1;
        public event ValuesAddedHandler ValuesAdded;
        public string datestr;
        public float valuecount;
        public string table;
        public string date;
        public addform()
        {
            InitializeComponent();
            DataBase1 = new DB();
            addComboBox();
        }
        public addform(string t,string d)
        {
            table = t;
            date = d;
            InitializeComponent();
            DataBase1 = new DB();
            addComboBox();
        }
        private void addComboBox()
        {
            for (int i=0;i<15;i++)
                comboBox1.Items.Add((i+2000).ToString());
            for (int i = 1; i < 13; i++)
                comboBox2.Items.Add(i.ToString());          

        }
        private void button1_Click(object sender, EventArgs e)
        {
            datestr = "'" + comboBox3.Text;
            datestr += "." + comboBox2.Text;
            datestr += "." + comboBox1.Text + "'";
            //valuecount = float.Parse(textBox4.Text);
            //DataBase1.SqlExecute("Alter trigger PriceElecTrig disable",false);
            DataBase1.SqlExecute("INSERT INTO " + table + "(" + date + ",curr_value ,price) VALUES(" + datestr + "," + textBox4.Text + ",null)", false);
            if(table=="electro")
                DataBase1.SqlExecute("CalcPriceElec",true);
            else if (table == "coldwater")
                DataBase1.SqlExecute("PriceWater", true);
            else if (table == "hotwater")
                DataBase1.SqlExecute("PriceHwater", true);
            if (ValuesAdded != null)
                ValuesAdded();
           
            /*datestr = textBox1.Text;
            datestr +="."+ textBox2.Text;
            datestr +="."+ textBox3.Text;
            
            if (ValuesAdded != null)
                ValuesAdded(this,EventArgs.Empty);*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            DataTableReader dr = DataBase1.ConnectData("select trunc(last_day(to_date('" + comboBox2.Text + "','MM')))-trunc(to_date('" + comboBox2.Text + "','mm'),'mm')+1 from dual", "table4").CreateDataReader();
            int i=0;
            while (dr.Read())
            {
                i=int.Parse((dr[0].ToString()));
            }
            while(i!=0)
            {
                comboBox3.Items.Add(i.ToString());
                i--;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

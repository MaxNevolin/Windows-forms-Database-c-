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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            IsMdiContainer = true;
            this.LayoutMdi(MdiLayout.TileHorizontal);
            InitializeComponent();
        }

        private void ElectroToolStrip_Click(object sender, EventArgs e)
        {
            //foreach (Form aForm in this.OwnedForms)
            //{
           //     aForm.Close();
            //}
           // if(this.ActiveMdiChild!=null)
           //     this.ActiveMdiChild.Close();
            this.panel1.Controls.Clear();
           //     this.ActiveMdiChild.Close();
            Form1 Form = new Form1();
            Form.MdiParent = this;
            this.Width = Form.Width+100;
            this.Height = Form.Height+100;
            panel1.Controls.Add(Form);
            Form.Show();
            Form.Size = this.Size;
           // Form.Top = this.Top + 20;
           // Form.Left = this.Left + 20;
            //form_add.ValuesAdded += new ValuesAddedHandler(ShowTable);
        }

        private void GasToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // foreach (Form aForm in this.OwnedForms)
           // {
            //    aForm.Close();
           // }
            this.panel1.Controls.Clear();
            FormRoompay Form2 = new FormRoompay();
            Form2.MdiParent = this;
            this.Width = Form2.Width + 100;
            this.Height = Form2.Height + 100;
            panel1.Controls.Add(Form2);
            Form2.Show();
            Form2.Size = this.Size;
           // Form2.Top = this.Top + 20;
            //Form2.Left = this.Left + 20;
        }

        private void WaterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            FormWater Form3 = new FormWater();
            Form3.MdiParent = this;
            this.Width = Form3.Width + 100;
            this.Height = Form3.Height + 100;
           // Form3.Top = this.Top;
            panel1.Controls.Add(Form3);
            Form3.Show();
            Form3.Size = this.Size;
            //Form3.Top = this.Top+20;
          // Form3.Left = this.Left+20;
        }

        private void HotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            FormWater Form3 = new FormWater("hotwater","date_hwater");
            Form3.MdiParent = this;
            this.Width = Form3.Width + 100;
            this.Height = Form3.Height + 100;
            // Form3.Top = this.Top;
            panel1.Controls.Add(Form3);
            Form3.Show();
            Form3.Size = this.Size;
        }

        private void ColdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            FormWater Form3 = new FormWater("coldwater", "date_cwater");
            Form3.MdiParent = this;
            this.Width = Form3.Width + 100;
            this.Height = Form3.Height + 100;
            // Form3.Top = this.Top;
            panel1.Controls.Add(Form3);
            Form3.Show();
            Form3.Size = this.Size;
        }

        private void ProdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            FormProducts Form3 = new FormProducts();
            Form3.MdiParent = this;
            this.Width = Form3.Width + 100;
            this.Height = Form3.Height + 100;
            // Form3.Top = this.Top;
            panel1.Controls.Add(Form3);
            Form3.Show();
            Form3.Size = this.Size;
        }

        private void покупкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            FormProdbuy Form3 = new FormProdbuy();
            Form3.MdiParent = this;
            this.Width = Form3.Width + 100;
            this.Height = Form3.Height + 100;
            // Form3.Top = this.Top;
            panel1.Controls.Add(Form3);
            Form3.Show();
            Form3.Size = this.Size;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

    }
}

namespace Obdz1
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.таблиціToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ElectroToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.GasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WaterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ColdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.додВитратиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.покупкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.таблиціToolStripMenuItem,
            this.додВитратиToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(699, 24);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // таблиціToolStripMenuItem
            // 
            this.таблиціToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ElectroToolStrip,
            this.GasToolStripMenuItem,
            this.WaterToolStripMenuItem});
            this.таблиціToolStripMenuItem.Name = "таблиціToolStripMenuItem";
            this.таблиціToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.таблиціToolStripMenuItem.Text = "Кварт.плата";
            // 
            // ElectroToolStrip
            // 
            this.ElectroToolStrip.Name = "ElectroToolStrip";
            this.ElectroToolStrip.Size = new System.Drawing.Size(168, 22);
            this.ElectroToolStrip.Text = "Електроенергія";
            this.ElectroToolStrip.Click += new System.EventHandler(this.ElectroToolStrip_Click);
            // 
            // GasToolStripMenuItem
            // 
            this.GasToolStripMenuItem.Name = "GasToolStripMenuItem";
            this.GasToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.GasToolStripMenuItem.Text = "Газ та утримання";
            this.GasToolStripMenuItem.Click += new System.EventHandler(this.GasToolStripMenuItem_Click);
            // 
            // WaterToolStripMenuItem
            // 
            this.WaterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HotToolStripMenuItem,
            this.ColdToolStripMenuItem});
            this.WaterToolStripMenuItem.Name = "WaterToolStripMenuItem";
            this.WaterToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.WaterToolStripMenuItem.Text = "Вода";
            this.WaterToolStripMenuItem.Click += new System.EventHandler(this.WaterToolStripMenuItem_Click);
            // 
            // HotToolStripMenuItem
            // 
            this.HotToolStripMenuItem.Name = "HotToolStripMenuItem";
            this.HotToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.HotToolStripMenuItem.Text = "Гаряча";
            this.HotToolStripMenuItem.Click += new System.EventHandler(this.HotToolStripMenuItem_Click);
            // 
            // ColdToolStripMenuItem
            // 
            this.ColdToolStripMenuItem.Name = "ColdToolStripMenuItem";
            this.ColdToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.ColdToolStripMenuItem.Text = "Холодна";
            this.ColdToolStripMenuItem.Click += new System.EventHandler(this.ColdToolStripMenuItem_Click);
            // 
            // додВитратиToolStripMenuItem
            // 
            this.додВитратиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProdToolStripMenuItem,
            this.покупкиToolStripMenuItem});
            this.додВитратиToolStripMenuItem.Name = "додВитратиToolStripMenuItem";
            this.додВитратиToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.додВитратиToolStripMenuItem.Text = "Дод. витрати";
            // 
            // ProdToolStripMenuItem
            // 
            this.ProdToolStripMenuItem.Name = "ProdToolStripMenuItem";
            this.ProdToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.ProdToolStripMenuItem.Text = "Продукти";
            this.ProdToolStripMenuItem.Click += new System.EventHandler(this.ProdToolStripMenuItem_Click);
            // 
            // покупкиToolStripMenuItem
            // 
            this.покупкиToolStripMenuItem.Name = "покупкиToolStripMenuItem";
            this.покупкиToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.покупкиToolStripMenuItem.Text = "Покупки";
            this.покупкиToolStripMenuItem.Click += new System.EventHandler(this.покупкиToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(675, 444);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label1.Location = new System.Drawing.Point(234, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Курсовий проект";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label2.Location = new System.Drawing.Point(294, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "на тему";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label3.Location = new System.Drawing.Point(97, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(448, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Автоматизована система домашньої бухгалтерії";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 483);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip2);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem таблиціToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ElectroToolStrip;
        private System.Windows.Forms.ToolStripMenuItem GasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WaterToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem HotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ColdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem додВитратиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ProdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem покупкиToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
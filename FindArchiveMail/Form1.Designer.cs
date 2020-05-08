namespace FindArchiveMail
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TsBtnCloseAll = new System.Windows.Forms.ToolStripButton();
            this.TsBtnClose = new System.Windows.Forms.ToolStripButton();
            this.TsBtnAbout = new System.Windows.Forms.ToolStripButton();
            this.TsBtnShowFindPanel = new System.Windows.Forms.ToolStripButton();
            this.TsIndex = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabFind = new FindArchiveMail.TabFind();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsBtnCloseAll,
            this.TsBtnClose,
            this.TsBtnAbout,
            this.TsBtnShowFindPanel,
            this.TsIndex});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(830, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // TsBtnCloseAll
            // 
            this.TsBtnCloseAll.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TsBtnCloseAll.Image = ((System.Drawing.Image)(resources.GetObject("TsBtnCloseAll.Image")));
            this.TsBtnCloseAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsBtnCloseAll.Name = "TsBtnCloseAll";
            this.TsBtnCloseAll.Size = new System.Drawing.Size(73, 22);
            this.TsBtnCloseAll.Text = "Close All";
            this.TsBtnCloseAll.Click += new System.EventHandler(this.TsBtnCloseAll_Click);
            // 
            // TsBtnClose
            // 
            this.TsBtnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TsBtnClose.Image = ((System.Drawing.Image)(resources.GetObject("TsBtnClose.Image")));
            this.TsBtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsBtnClose.Name = "TsBtnClose";
            this.TsBtnClose.Size = new System.Drawing.Size(56, 22);
            this.TsBtnClose.Text = "Close";
            this.TsBtnClose.Click += new System.EventHandler(this.TsBtnClose_Click);
            // 
            // TsBtnAbout
            // 
            this.TsBtnAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TsBtnAbout.Image = ((System.Drawing.Image)(resources.GetObject("TsBtnAbout.Image")));
            this.TsBtnAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsBtnAbout.Name = "TsBtnAbout";
            this.TsBtnAbout.Size = new System.Drawing.Size(60, 22);
            this.TsBtnAbout.Text = "About";
            this.TsBtnAbout.Click += new System.EventHandler(this.TsBtnAbout_Click);
            // 
            // TsBtnShowFindPanel
            // 
            this.TsBtnShowFindPanel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TsBtnShowFindPanel.Image = ((System.Drawing.Image)(resources.GetObject("TsBtnShowFindPanel.Image")));
            this.TsBtnShowFindPanel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsBtnShowFindPanel.Name = "TsBtnShowFindPanel";
            this.TsBtnShowFindPanel.Size = new System.Drawing.Size(52, 22);
            this.TsBtnShowFindPanel.Text = "Hide";
            this.TsBtnShowFindPanel.Click += new System.EventHandler(this.TsBtnShowFindPanel_Click);
            // 
            // TsIndex
            // 
            this.TsIndex.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TsIndex.Image = ((System.Drawing.Image)(resources.GetObject("TsIndex.Image")));
            this.TsIndex.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsIndex.Name = "TsIndex";
            this.TsIndex.Size = new System.Drawing.Size(56, 22);
            this.TsIndex.Text = "Index";
            this.TsIndex.Click += new System.EventHandler(this.TsIndex_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabFind);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(830, 490);
            this.tabControl1.TabIndex = 1;
            // 
            // tabFind
            // 
            this.tabFind.Location = new System.Drawing.Point(4, 22);
            this.tabFind.Name = "tabFind";
            this.tabFind.Padding = new System.Windows.Forms.Padding(3);
            this.tabFind.Size = new System.Drawing.Size(822, 464);
            this.tabFind.TabIndex = 1;
            this.tabFind.Text = "Find";
            this.tabFind.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 515);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "FindArchiveMail";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton TsBtnCloseAll;
        private System.Windows.Forms.ToolStripButton TsBtnClose;
        private System.Windows.Forms.ToolStripButton TsBtnShowFindPanel;
        private System.Windows.Forms.ToolStripButton TsIndex;
        private System.Windows.Forms.TabControl tabControl1;
        //private System.Windows.Forms.TabPage tabPage2;
        private TabFind tabFind;
        private System.Windows.Forms.ToolStripButton TsBtnAbout;
    }
}


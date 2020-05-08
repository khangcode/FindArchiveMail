namespace FindArchiveMail
{
    partial class TabFind
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.BtnFind = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtReceiver = new System.Windows.Forms.TextBox();
            this.TxtSender = new System.Windows.Forms.TextBox();
            this.ChkSubject = new System.Windows.Forms.CheckBox();
            this.TxtBody = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RdBtnReceivedOn = new System.Windows.Forms.RadioButton();
            this.RdBtnSentOn = new System.Windows.Forms.RadioButton();
            this.DPickerTo = new System.Windows.Forms.DateTimePicker();
            this.DPickerFrom = new System.Windows.Forms.DateTimePicker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.TsLabelTotalRow = new System.Windows.Forms.ToolStripStatusLabel();
            this.AvDataGridView1 = new ADGV.AdvancedDataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SentOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SenderEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceivedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.TxtMaxResult = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AvDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.TxtMaxResult);
            this.splitContainer1.Panel1.Controls.Add(this.BtnFind);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.TxtReceiver);
            this.splitContainer1.Panel1.Controls.Add(this.TxtSender);
            this.splitContainer1.Panel1.Controls.Add(this.ChkSubject);
            this.splitContainer1.Panel1.Controls.Add(this.TxtBody);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Panel2.Controls.Add(this.AvDataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(814, 451);
            this.splitContainer1.SplitterDistance = 356;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.Resize += new System.EventHandler(this.splitContainer1_Resize);
            // 
            // BtnFind
            // 
            this.BtnFind.Location = new System.Drawing.Point(268, 289);
            this.BtnFind.Name = "BtnFind";
            this.BtnFind.Size = new System.Drawing.Size(75, 23);
            this.BtnFind.TabIndex = 10;
            this.BtnFind.Text = "Find";
            this.BtnFind.UseVisualStyleBackColor = true;
            this.BtnFind.Click += new System.EventHandler(this.BtnFind_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 255);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Receiver";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Sender";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Contain";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "From";
            // 
            // TxtReceiver
            // 
            this.TxtReceiver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtReceiver.Location = new System.Drawing.Point(115, 252);
            this.TxtReceiver.Name = "TxtReceiver";
            this.TxtReceiver.Size = new System.Drawing.Size(228, 20);
            this.TxtReceiver.TabIndex = 4;
            // 
            // TxtSender
            // 
            this.TxtSender.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtSender.Location = new System.Drawing.Point(115, 214);
            this.TxtSender.Name = "TxtSender";
            this.TxtSender.Size = new System.Drawing.Size(228, 20);
            this.TxtSender.TabIndex = 3;
            // 
            // ChkSubject
            // 
            this.ChkSubject.AutoSize = true;
            this.ChkSubject.Location = new System.Drawing.Point(115, 190);
            this.ChkSubject.Name = "ChkSubject";
            this.ChkSubject.Size = new System.Drawing.Size(84, 17);
            this.ChkSubject.TabIndex = 2;
            this.ChkSubject.Text = "Subject only";
            this.ChkSubject.UseVisualStyleBackColor = true;
            // 
            // TxtBody
            // 
            this.TxtBody.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtBody.Location = new System.Drawing.Point(115, 163);
            this.TxtBody.Name = "TxtBody";
            this.TxtBody.Size = new System.Drawing.Size(228, 20);
            this.TxtBody.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RdBtnReceivedOn);
            this.groupBox1.Controls.Add(this.RdBtnSentOn);
            this.groupBox1.Controls.Add(this.DPickerTo);
            this.groupBox1.Controls.Add(this.DPickerFrom);
            this.groupBox1.Location = new System.Drawing.Point(115, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 144);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // RdBtnReceivedOn
            // 
            this.RdBtnReceivedOn.AutoSize = true;
            this.RdBtnReceivedOn.Location = new System.Drawing.Point(132, 111);
            this.RdBtnReceivedOn.Name = "RdBtnReceivedOn";
            this.RdBtnReceivedOn.Size = new System.Drawing.Size(88, 17);
            this.RdBtnReceivedOn.TabIndex = 3;
            this.RdBtnReceivedOn.TabStop = true;
            this.RdBtnReceivedOn.Text = "Received On";
            this.RdBtnReceivedOn.UseVisualStyleBackColor = true;
            // 
            // RdBtnSentOn
            // 
            this.RdBtnSentOn.AutoSize = true;
            this.RdBtnSentOn.Location = new System.Drawing.Point(17, 111);
            this.RdBtnSentOn.Name = "RdBtnSentOn";
            this.RdBtnSentOn.Size = new System.Drawing.Size(64, 17);
            this.RdBtnSentOn.TabIndex = 2;
            this.RdBtnSentOn.TabStop = true;
            this.RdBtnSentOn.Text = "Sent On";
            this.RdBtnSentOn.UseVisualStyleBackColor = true;
            // 
            // DPickerTo
            // 
            this.DPickerTo.Location = new System.Drawing.Point(17, 72);
            this.DPickerTo.Name = "DPickerTo";
            this.DPickerTo.ShowCheckBox = true;
            this.DPickerTo.Size = new System.Drawing.Size(200, 20);
            this.DPickerTo.TabIndex = 1;
            // 
            // DPickerFrom
            // 
            this.DPickerFrom.Location = new System.Drawing.Point(17, 28);
            this.DPickerFrom.Name = "DPickerFrom";
            this.DPickerFrom.ShowCheckBox = true;
            this.DPickerFrom.Size = new System.Drawing.Size(200, 20);
            this.DPickerFrom.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsLabelTotalRow});
            this.statusStrip1.Location = new System.Drawing.Point(0, 429);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(454, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // TsLabelTotalRow
            // 
            this.TsLabelTotalRow.Name = "TsLabelTotalRow";
            this.TsLabelTotalRow.Size = new System.Drawing.Size(93, 17);
            this.TsLabelTotalRow.Text = "TsLabelTotalRow";
            // 
            // AvDataGridView1
            // 
            this.AvDataGridView1.AllowUserToAddRows = false;
            this.AvDataGridView1.AllowUserToDeleteRows = false;
            this.AvDataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AvDataGridView1.AutoGenerateContextFilters = true;
            this.AvDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AvDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.SentOn,
            this.SenderEmail,
            this.Subject,
            this.ReceivedOn});
            this.AvDataGridView1.DateWithTime = false;
            this.AvDataGridView1.Location = new System.Drawing.Point(3, 12);
            this.AvDataGridView1.Name = "AvDataGridView1";
            this.AvDataGridView1.ReadOnly = true;
            this.AvDataGridView1.Size = new System.Drawing.Size(426, 414);
            this.AvDataGridView1.TabIndex = 0;
            this.AvDataGridView1.TimeFilter = false;
            this.AvDataGridView1.SortStringChanged += new System.EventHandler(this.AvDataGridView1_SortStringChanged);
            this.AvDataGridView1.FilterStringChanged += new System.EventHandler(this.AvDataGridView1_FilterStringChanged);
            this.AvDataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AvDataGridView1_CellDoubleClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 22;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Id.Width = 80;
            // 
            // SentOn
            // 
            this.SentOn.DataPropertyName = "SentOn";
            this.SentOn.HeaderText = "SentOn";
            this.SentOn.MinimumWidth = 22;
            this.SentOn.Name = "SentOn";
            this.SentOn.ReadOnly = true;
            this.SentOn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.SentOn.Width = 150;
            // 
            // SenderEmail
            // 
            this.SenderEmail.DataPropertyName = "SenderEmailAddress";
            this.SenderEmail.HeaderText = "Sender Mail";
            this.SenderEmail.MinimumWidth = 22;
            this.SenderEmail.Name = "SenderEmail";
            this.SenderEmail.ReadOnly = true;
            this.SenderEmail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.SenderEmail.Width = 150;
            // 
            // Subject
            // 
            this.Subject.DataPropertyName = "Subject";
            this.Subject.HeaderText = "Subject";
            this.Subject.MinimumWidth = 22;
            this.Subject.Name = "Subject";
            this.Subject.ReadOnly = true;
            this.Subject.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Subject.Width = 400;
            // 
            // ReceivedOn
            // 
            this.ReceivedOn.DataPropertyName = "ReceivedOn";
            this.ReceivedOn.HeaderText = "Receive On";
            this.ReceivedOn.MinimumWidth = 22;
            this.ReceivedOn.Name = "ReceivedOn";
            this.ReceivedOn.ReadOnly = true;
            this.ReceivedOn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ReceivedOn.Width = 150;
            // 
            // bindingSource1
            // 
            this.bindingSource1.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bindingSource1_ListChanged);
            // 
            // TxtMaxResult
            // 
            this.TxtMaxResult.Location = new System.Drawing.Point(115, 291);
            this.TxtMaxResult.Name = "TxtMaxResult";
            this.TxtMaxResult.Size = new System.Drawing.Size(135, 20);
            this.TxtMaxResult.Text = "1000";
            this.TxtMaxResult.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 294);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Max Result";
            // 
            // FrmFind
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 451);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmFind";
            this.Text = "FrmFind";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AvDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RdBtnReceivedOn;
        private System.Windows.Forms.RadioButton RdBtnSentOn;
        private System.Windows.Forms.DateTimePicker DPickerTo;
        private System.Windows.Forms.DateTimePicker DPickerFrom;
        private System.Windows.Forms.CheckBox ChkSubject;
        private System.Windows.Forms.TextBox TxtBody;
        private System.Windows.Forms.TextBox TxtReceiver;
        private System.Windows.Forms.TextBox TxtSender;
        private System.Windows.Forms.Button BtnFind;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ADGV.AdvancedDataGridView AvDataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn SentOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SenderEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subject;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceivedOn;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel TsLabelTotalRow;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtMaxResult;
    }
}
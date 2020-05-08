namespace FindArchiveMail
{
    partial class TabIndex
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DPickerFrom = new System.Windows.Forms.DateTimePicker();
            this.DPickerTo = new System.Windows.Forms.DateTimePicker();
            this.BtnFromTo = new System.Windows.Forms.Button();
            this.BtnMonthIndex = new System.Windows.Forms.Button();
            this.BtnReIndexAll = new System.Windows.Forms.Button();
            this.TxtStatus = new System.Windows.Forms.TextBox();
            this.TxtPath = new System.Windows.Forms.TextBox();
            this.BtnPath = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(307, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "to";
            // 
            // DPickerFrom
            // 
            this.DPickerFrom.Location = new System.Drawing.Point(74, 19);
            this.DPickerFrom.Name = "DPickerFrom";
            this.DPickerFrom.ShowCheckBox = true;
            this.DPickerFrom.Size = new System.Drawing.Size(200, 20);
            this.DPickerFrom.TabIndex = 2;
            // 
            // DPickerTo
            // 
            this.DPickerTo.Location = new System.Drawing.Point(329, 19);
            this.DPickerTo.Name = "DPickerTo";
            this.DPickerTo.ShowCheckBox = true;
            this.DPickerTo.Size = new System.Drawing.Size(200, 20);
            this.DPickerTo.TabIndex = 3;
            // 
            // BtnFromTo
            // 
            this.BtnFromTo.Location = new System.Drawing.Point(548, 20);
            this.BtnFromTo.Name = "BtnFromTo";
            this.BtnFromTo.Size = new System.Drawing.Size(75, 23);
            this.BtnFromTo.TabIndex = 4;
            this.BtnFromTo.Text = "Index";
            this.BtnFromTo.UseVisualStyleBackColor = true;
            this.BtnFromTo.Click += new System.EventHandler(this.BtnFromTo_Click);
            // 
            // BtnMonthIndex
            // 
            this.BtnMonthIndex.Location = new System.Drawing.Point(629, 20);
            this.BtnMonthIndex.Name = "BtnMonthIndex";
            this.BtnMonthIndex.Size = new System.Drawing.Size(75, 23);
            this.BtnMonthIndex.TabIndex = 5;
            this.BtnMonthIndex.Text = "Month Index";
            this.BtnMonthIndex.UseVisualStyleBackColor = true;
            this.BtnMonthIndex.Click += new System.EventHandler(this.BtnMonthIndex_Click);
            // 
            // BtnReIndexAll
            // 
            this.BtnReIndexAll.Location = new System.Drawing.Point(710, 20);
            this.BtnReIndexAll.Name = "BtnReIndexAll";
            this.BtnReIndexAll.Size = new System.Drawing.Size(75, 23);
            this.BtnReIndexAll.TabIndex = 6;
            this.BtnReIndexAll.Text = "ReIndex All";
            this.BtnReIndexAll.UseVisualStyleBackColor = true;
            this.BtnReIndexAll.Click += new System.EventHandler(this.BtnReIndexAll_Click);
            // 
            // TxtStatus
            // 
            this.TxtStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtStatus.Location = new System.Drawing.Point(36, 60);
            this.TxtStatus.Multiline = true;
            this.TxtStatus.Name = "TxtStatus";
            this.TxtStatus.ReadOnly = true;
            this.TxtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TxtStatus.Size = new System.Drawing.Size(750, 337);
            this.TxtStatus.TabIndex = 7;
            // 
            // TxtPath
            // 
            this.TxtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtPath.Location = new System.Drawing.Point(36, 409);
            this.TxtPath.Name = "TxtPath";
            this.TxtPath.ReadOnly = true;
            this.TxtPath.Size = new System.Drawing.Size(669, 20);
            this.TxtPath.TabIndex = 8;
            // 
            // BtnPath
            // 
            this.BtnPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnPath.Location = new System.Drawing.Point(711, 407);
            this.BtnPath.Name = "BtnPath";
            this.BtnPath.Size = new System.Drawing.Size(75, 23);
            this.BtnPath.TabIndex = 9;
            this.BtnPath.Text = "Select";
            this.BtnPath.UseVisualStyleBackColor = true;
            this.BtnPath.Click += new System.EventHandler(this.BtnPath_Click);
            // 
            // FrmIndex
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 451);
            this.Controls.Add(this.BtnPath);
            this.Controls.Add(this.TxtPath);
            this.Controls.Add(this.TxtStatus);
            this.Controls.Add(this.BtnReIndexAll);
            this.Controls.Add(this.BtnMonthIndex);
            this.Controls.Add(this.BtnFromTo);
            this.Controls.Add(this.DPickerTo);
            this.Controls.Add(this.DPickerFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmIndex";
            this.Text = "Index";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DPickerFrom;
        private System.Windows.Forms.DateTimePicker DPickerTo;
        private System.Windows.Forms.Button BtnFromTo;
        private System.Windows.Forms.Button BtnMonthIndex;
        private System.Windows.Forms.Button BtnReIndexAll;
        private System.Windows.Forms.TextBox TxtStatus;
        private System.Windows.Forms.TextBox TxtPath;
        private System.Windows.Forms.Button BtnPath;
    }
}
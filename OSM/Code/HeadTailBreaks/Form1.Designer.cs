namespace HeadTailBreaks
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.InputFileAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.HeadPercentage = new System.Windows.Forms.TextBox();
            this.TailPercentage = new System.Windows.Forms.Label();
            this.BreakResult = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.htIndex = new System.Windows.Forms.Label();
            this.data = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.clearText = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(318, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Go";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // InputFileAddress
            // 
            this.InputFileAddress.AllowDrop = true;
            this.InputFileAddress.Location = new System.Drawing.Point(191, 8);
            this.InputFileAddress.Name = "InputFileAddress";
            this.InputFileAddress.Size = new System.Drawing.Size(714, 21);
            this.InputFileAddress.TabIndex = 2;
            this.InputFileAddress.TextChanged += new System.EventHandler(this.InputFileAddress_TextChanged);
            this.InputFileAddress.DragDrop += new System.Windows.Forms.DragEventHandler(this.txt_ObjDragDrop);
            this.InputFileAddress.DragEnter += new System.Windows.Forms.DragEventHandler(this.txt_ObjDragEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(263, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Division Rule:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(358, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Head:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(449, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tail:";
            // 
            // HeadPercentage
            // 
            this.HeadPercentage.Location = new System.Drawing.Point(399, 46);
            this.HeadPercentage.Name = "HeadPercentage";
            this.HeadPercentage.Size = new System.Drawing.Size(29, 21);
            this.HeadPercentage.TabIndex = 6;
            this.HeadPercentage.Text = "40";
            this.HeadPercentage.TextChanged += new System.EventHandler(this.HeadPercentage_TextChanged);
            this.HeadPercentage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HeadPercentage_KeyPress);
            this.HeadPercentage.MouseLeave += new System.EventHandler(this.HeadPercentage_MouseLeave);
            // 
            // TailPercentage
            // 
            this.TailPercentage.AutoSize = true;
            this.TailPercentage.Location = new System.Drawing.Point(491, 49);
            this.TailPercentage.Name = "TailPercentage";
            this.TailPercentage.Size = new System.Drawing.Size(0, 12);
            this.TailPercentage.TabIndex = 7;
            // 
            // BreakResult
            // 
            this.BreakResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BreakResult.Location = new System.Drawing.Point(191, 107);
            this.BreakResult.Multiline = true;
            this.BreakResult.Name = "BreakResult";
            this.BreakResult.ReadOnly = true;
            this.BreakResult.Size = new System.Drawing.Size(714, 169);
            this.BreakResult.TabIndex = 8;
            this.BreakResult.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.BreakResult_MouseDoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(434, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "Ht_index:";
            // 
            // htIndex
            // 
            this.htIndex.AutoSize = true;
            this.htIndex.Location = new System.Drawing.Point(493, 83);
            this.htIndex.Name = "htIndex";
            this.htIndex.Size = new System.Drawing.Size(0, 12);
            this.htIndex.TabIndex = 10;
            // 
            // data
            // 
            this.data.Location = new System.Drawing.Point(20, 67);
            this.data.MaxLength = 0;
            this.data.Multiline = true;
            this.data.Name = "data";
            this.data.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.data.Size = new System.Drawing.Size(141, 220);
            this.data.TabIndex = 11;
            this.data.MouseClick += new System.Windows.Forms.MouseEventHandler(this.data_MouseClick);
            this.data.TextChanged += new System.EventHandler(this.data_TextChanged);
            this.data.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.data_KeyPress);
            this.data.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.data_MouseDoubleClick);
            this.data.MouseEnter += new System.EventHandler(this.data_MouseEnter);
            this.data.MouseLeave += new System.EventHandler(this.data_MouseLeave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "Drag&&drop data file here:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "Or Paste data here...";
            // 
            // clearText
            // 
            this.clearText.Location = new System.Drawing.Point(42, 291);
            this.clearText.Name = "clearText";
            this.clearText.Size = new System.Drawing.Size(75, 23);
            this.clearText.TabIndex = 14;
            this.clearText.Text = "clear";
            this.clearText.UseVisualStyleBackColor = true;
            this.clearText.Click += new System.EventHandler(this.clearText_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 317);
            this.Controls.Add(this.clearText);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.data);
            this.Controls.Add(this.htIndex);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BreakResult);
            this.Controls.Add(this.TailPercentage);
            this.Controls.Add(this.HeadPercentage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.InputFileAddress);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "HeadTailBreaks";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox InputFileAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox HeadPercentage;
        private System.Windows.Forms.Label TailPercentage;
        private System.Windows.Forms.TextBox BreakResult;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label htIndex;
        private System.Windows.Forms.TextBox data;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button clearText;
    }
}


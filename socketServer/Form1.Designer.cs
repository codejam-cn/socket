namespace socketServer
{
    partial class FrmServer
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ServerIpLabel = new System.Windows.Forms.Label();
            this.Port = new System.Windows.Forms.Label();
            this.ServerPortText = new System.Windows.Forms.TextBox();
            this.StartBtn = new System.Windows.Forms.Button();
            this.ServerPortLabel = new System.Windows.Forms.Label();
            this.StopBtn = new System.Windows.Forms.Button();
            this.cmbIp = new System.Windows.Forms.ComboBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // ServerIpLabel
            // 
            this.ServerIpLabel.Location = new System.Drawing.Point(13, 27);
            this.ServerIpLabel.Name = "ServerIpLabel";
            this.ServerIpLabel.Size = new System.Drawing.Size(56, 23);
            this.ServerIpLabel.TabIndex = 0;
            this.ServerIpLabel.Text = "ServerIP";
            // 
            // Port
            // 
            this.Port.AutoSize = true;
            this.Port.Location = new System.Drawing.Point(192, 30);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(0, 12);
            this.Port.TabIndex = 1;
            // 
            // ServerPortText
            // 
            this.ServerPortText.Location = new System.Drawing.Point(239, 24);
            this.ServerPortText.Name = "ServerPortText";
            this.ServerPortText.Size = new System.Drawing.Size(100, 21);
            this.ServerPortText.TabIndex = 3;
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(359, 22);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(102, 23);
            this.StartBtn.TabIndex = 4;
            this.StartBtn.Text = "Start Server";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // ServerPortLabel
            // 
            this.ServerPortLabel.AutoSize = true;
            this.ServerPortLabel.Location = new System.Drawing.Point(199, 30);
            this.ServerPortLabel.Name = "ServerPortLabel";
            this.ServerPortLabel.Size = new System.Drawing.Size(29, 12);
            this.ServerPortLabel.TabIndex = 5;
            this.ServerPortLabel.Text = "Port";
            // 
            // StopBtn
            // 
            this.StopBtn.Location = new System.Drawing.Point(359, 52);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(102, 23);
            this.StopBtn.TabIndex = 6;
            this.StopBtn.Text = "Stop Server";
            this.StopBtn.UseVisualStyleBackColor = true;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // cmbIp
            // 
            this.cmbIp.FormattingEnabled = true;
            this.cmbIp.Location = new System.Drawing.Point(71, 24);
            this.cmbIp.Name = "cmbIp";
            this.cmbIp.Size = new System.Drawing.Size(121, 20);
            this.cmbIp.TabIndex = 7;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(71, 106);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(305, 139);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = "";
            // 
            // FrmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 265);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.cmbIp);
            this.Controls.Add(this.StopBtn);
            this.Controls.Add(this.ServerPortLabel);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.ServerPortText);
            this.Controls.Add(this.Port);
            this.Controls.Add(this.ServerIpLabel);
            this.Name = "FrmServer";
            this.Text = "frmServer";
            this.Load += new System.EventHandler(this.frmServer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ServerIpLabel;
        private System.Windows.Forms.Label Port;
        private System.Windows.Forms.TextBox ServerPortText;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Label ServerPortLabel;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.ComboBox cmbIp;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}


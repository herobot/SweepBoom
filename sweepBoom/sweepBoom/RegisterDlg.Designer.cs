namespace sweepBoom
{
    partial class RegisterDlg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterDlg));
            this.regisUserLabel = new System.Windows.Forms.Label();
            this.regisPassWordLabel1 = new System.Windows.Forms.Label();
            this.regisPassWordLabel2 = new System.Windows.Forms.Label();
            this.regisUserNameText = new System.Windows.Forms.TextBox();
            this.regisPassWordText1 = new System.Windows.Forms.TextBox();
            this.regisPassWordText2 = new System.Windows.Forms.TextBox();
            this.regisSureButton = new System.Windows.Forms.Button();
            this.regisCancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // regisUserLabel
            // 
            this.regisUserLabel.AutoSize = true;
            this.regisUserLabel.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.regisUserLabel.Location = new System.Drawing.Point(57, 40);
            this.regisUserLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.regisUserLabel.Name = "regisUserLabel";
            this.regisUserLabel.Size = new System.Drawing.Size(112, 14);
            this.regisUserLabel.TabIndex = 0;
            this.regisUserLabel.Text = "请输入用户名：";
            // 
            // regisPassWordLabel1
            // 
            this.regisPassWordLabel1.AutoSize = true;
            this.regisPassWordLabel1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.regisPassWordLabel1.Location = new System.Drawing.Point(57, 79);
            this.regisPassWordLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.regisPassWordLabel1.Name = "regisPassWordLabel1";
            this.regisPassWordLabel1.Size = new System.Drawing.Size(97, 14);
            this.regisPassWordLabel1.TabIndex = 1;
            this.regisPassWordLabel1.Text = "请输入密码：";
            // 
            // regisPassWordLabel2
            // 
            this.regisPassWordLabel2.AutoSize = true;
            this.regisPassWordLabel2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.regisPassWordLabel2.Location = new System.Drawing.Point(57, 117);
            this.regisPassWordLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.regisPassWordLabel2.Name = "regisPassWordLabel2";
            this.regisPassWordLabel2.Size = new System.Drawing.Size(112, 14);
            this.regisPassWordLabel2.TabIndex = 2;
            this.regisPassWordLabel2.Text = "请再输入密码：";
            // 
            // regisUserNameText
            // 
            this.regisUserNameText.Location = new System.Drawing.Point(161, 35);
            this.regisUserNameText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.regisUserNameText.Name = "regisUserNameText";
            this.regisUserNameText.Size = new System.Drawing.Size(139, 21);
            this.regisUserNameText.TabIndex = 3;
            // 
            // regisPassWordText1
            // 
            this.regisPassWordText1.Location = new System.Drawing.Point(161, 73);
            this.regisPassWordText1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.regisPassWordText1.Name = "regisPassWordText1";
            this.regisPassWordText1.PasswordChar = '*';
            this.regisPassWordText1.Size = new System.Drawing.Size(139, 21);
            this.regisPassWordText1.TabIndex = 4;
            // 
            // regisPassWordText2
            // 
            this.regisPassWordText2.Location = new System.Drawing.Point(161, 112);
            this.regisPassWordText2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.regisPassWordText2.Name = "regisPassWordText2";
            this.regisPassWordText2.PasswordChar = '*';
            this.regisPassWordText2.Size = new System.Drawing.Size(139, 21);
            this.regisPassWordText2.TabIndex = 5;
            // 
            // regisSureButton
            // 
            this.regisSureButton.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.regisSureButton.Location = new System.Drawing.Point(60, 153);
            this.regisSureButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.regisSureButton.Name = "regisSureButton";
            this.regisSureButton.Size = new System.Drawing.Size(100, 27);
            this.regisSureButton.TabIndex = 6;
            this.regisSureButton.Text = "确认注册";
            this.regisSureButton.UseVisualStyleBackColor = true;
            this.regisSureButton.Click += new System.EventHandler(this.regisSureButton_Click);
            // 
            // regisCancelButton
            // 
            this.regisCancelButton.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.regisCancelButton.Location = new System.Drawing.Point(199, 153);
            this.regisCancelButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.regisCancelButton.MaximumSize = new System.Drawing.Size(100, 27);
            this.regisCancelButton.MinimumSize = new System.Drawing.Size(100, 27);
            this.regisCancelButton.Name = "regisCancelButton";
            this.regisCancelButton.Size = new System.Drawing.Size(100, 27);
            this.regisCancelButton.TabIndex = 7;
            this.regisCancelButton.Text = "取消注册";
            this.regisCancelButton.UseVisualStyleBackColor = true;
            this.regisCancelButton.Click += new System.EventHandler(this.regisCancelButton_Click);
            // 
            // RegisterDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 216);
            this.Controls.Add(this.regisCancelButton);
            this.Controls.Add(this.regisSureButton);
            this.Controls.Add(this.regisPassWordText2);
            this.Controls.Add(this.regisPassWordText1);
            this.Controls.Add(this.regisUserNameText);
            this.Controls.Add(this.regisPassWordLabel2);
            this.Controls.Add(this.regisPassWordLabel1);
            this.Controls.Add(this.regisUserLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegisterDlg";
            this.Text = "注册用户";
            this.Load += new System.EventHandler(this.RegisterDlg_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label regisUserLabel;
        private System.Windows.Forms.Label regisPassWordLabel1;
        private System.Windows.Forms.Label regisPassWordLabel2;
        private System.Windows.Forms.TextBox regisUserNameText;
        private System.Windows.Forms.TextBox regisPassWordText1;
        private System.Windows.Forms.TextBox regisPassWordText2;
        private System.Windows.Forms.Button regisSureButton;
        private System.Windows.Forms.Button regisCancelButton;
    }
}
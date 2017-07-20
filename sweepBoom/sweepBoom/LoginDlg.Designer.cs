namespace sweepBoom
{
    partial class LoginDlg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginDlg));
            this.userNameLabel = new System.Windows.Forms.Label();
            this.passWordLabel = new System.Windows.Forms.Label();
            this.userNameText = new System.Windows.Forms.TextBox();
            this.passWordText = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.loginSureButton = new System.Windows.Forms.Button();
            this.loginCancelButton = new System.Windows.Forms.Button();
            this.nonRegister = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userNameLabel.Location = new System.Drawing.Point(39, 76);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(72, 20);
            this.userNameLabel.TabIndex = 0;
            this.userNameLabel.Text = "用户：";
            // 
            // passWordLabel
            // 
            this.passWordLabel.AutoSize = true;
            this.passWordLabel.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.passWordLabel.Location = new System.Drawing.Point(39, 140);
            this.passWordLabel.Name = "passWordLabel";
            this.passWordLabel.Size = new System.Drawing.Size(72, 20);
            this.passWordLabel.TabIndex = 1;
            this.passWordLabel.Text = "密码：";
            // 
            // userNameText
            // 
            this.userNameText.Location = new System.Drawing.Point(127, 68);
            this.userNameText.Name = "userNameText";
            this.userNameText.Size = new System.Drawing.Size(167, 28);
            this.userNameText.TabIndex = 2;
            // 
            // passWordText
            // 
            this.passWordText.Location = new System.Drawing.Point(127, 132);
            this.passWordText.Name = "passWordText";
            this.passWordText.PasswordChar = '*';
            this.passWordText.Size = new System.Drawing.Size(167, 28);
            this.passWordText.TabIndex = 3;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel1.Location = new System.Drawing.Point(316, 77);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(89, 20);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "注册用户";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel2.Location = new System.Drawing.Point(316, 140);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(89, 20);
            this.linkLabel2.TabIndex = 5;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "忘记密码";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // loginSureButton
            // 
            this.loginSureButton.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.loginSureButton.Location = new System.Drawing.Point(43, 189);
            this.loginSureButton.Name = "loginSureButton";
            this.loginSureButton.Size = new System.Drawing.Size(150, 40);
            this.loginSureButton.TabIndex = 6;
            this.loginSureButton.Text = "确认";
            this.loginSureButton.UseVisualStyleBackColor = true;
            this.loginSureButton.Click += new System.EventHandler(this.loginSureButton_Click);
            // 
            // loginCancelButton
            // 
            this.loginCancelButton.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.loginCancelButton.Location = new System.Drawing.Point(255, 189);
            this.loginCancelButton.Name = "loginCancelButton";
            this.loginCancelButton.Size = new System.Drawing.Size(150, 40);
            this.loginCancelButton.TabIndex = 7;
            this.loginCancelButton.Text = "取消";
            this.loginCancelButton.UseVisualStyleBackColor = true;
            this.loginCancelButton.Click += new System.EventHandler(this.loginCancelButton_Click);
            // 
            // nonRegister
            // 
            this.nonRegister.Location = new System.Drawing.Point(43, 258);
            this.nonRegister.Name = "nonRegister";
            this.nonRegister.Size = new System.Drawing.Size(362, 40);
            this.nonRegister.TabIndex = 9;
            this.nonRegister.Text = "点击此处免注册玩游戏";
            this.nonRegister.UseVisualStyleBackColor = true;
            this.nonRegister.Click += new System.EventHandler(this.nonRegister_Click);
            // 
            // LoginDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(448, 324);
            this.Controls.Add(this.nonRegister);
            this.Controls.Add(this.loginCancelButton);
            this.Controls.Add(this.loginSureButton);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.passWordText);
            this.Controls.Add(this.userNameText);
            this.Controls.Add(this.passWordLabel);
            this.Controls.Add(this.userNameLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(470, 380);
            this.MinimumSize = new System.Drawing.Size(470, 380);
            this.Name = "LoginDlg";
            this.Text = "登录扫雷";
            this.Load += new System.EventHandler(this.LoginDlg_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.Label passWordLabel;
        private System.Windows.Forms.TextBox userNameText;
        private System.Windows.Forms.TextBox passWordText;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Button loginSureButton;
        private System.Windows.Forms.Button loginCancelButton;
        private System.Windows.Forms.Button nonRegister;
    }
}
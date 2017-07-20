namespace sweepBoom
{
    partial class modelChooseDlg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(modelChooseDlg));
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.boomSize = new System.Windows.Forms.TextBox();
            this.boomCount = new System.Windows.Forms.TextBox();
            this.modelChooseSureButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(29, 36);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(213, 22);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "简单（12X12,15个雷）";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(29, 89);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(213, 22);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "中等（16X16,30个雷）";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(29, 142);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(213, 22);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "困难（20X20,50个雷）";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(29, 196);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(213, 22);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "自定义（大小和雷数）";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "雷区大小（12——20）";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 298);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(188, 18);
            this.label6.TabIndex = 9;
            this.label6.Text = "雷的数目（15——50）";
            // 
            // boomSize
            // 
            this.boomSize.Location = new System.Drawing.Point(221, 242);
            this.boomSize.Name = "boomSize";
            this.boomSize.Size = new System.Drawing.Size(100, 28);
            this.boomSize.TabIndex = 10;
            // 
            // boomCount
            // 
            this.boomCount.Location = new System.Drawing.Point(221, 292);
            this.boomCount.Name = "boomCount";
            this.boomCount.Size = new System.Drawing.Size(100, 28);
            this.boomCount.TabIndex = 11;
            // 
            // modelChooseSureButton
            // 
            this.modelChooseSureButton.Location = new System.Drawing.Point(221, 342);
            this.modelChooseSureButton.Name = "modelChooseSureButton";
            this.modelChooseSureButton.Size = new System.Drawing.Size(100, 28);
            this.modelChooseSureButton.TabIndex = 12;
            this.modelChooseSureButton.Text = "确认";
            this.modelChooseSureButton.UseVisualStyleBackColor = true;
            this.modelChooseSureButton.Click += new System.EventHandler(this.modelChooseSureButton_Click);
            // 
            // modelChooseDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 400);
            this.Controls.Add(this.modelChooseSureButton);
            this.Controls.Add(this.boomCount);
            this.Controls.Add(this.boomSize);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "modelChooseDlg";
            this.Text = "难度选择";
            this.Load += new System.EventHandler(this.modelChooseDlg_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox boomSize;
        private System.Windows.Forms.TextBox boomCount;
        private System.Windows.Forms.Button modelChooseSureButton;
    }
}
namespace sweepBoom
{
    partial class ScoreShowDlg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScoreShowDlg));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.simpleGridView = new System.Windows.Forms.DataGridView();
            this.middleGridView = new System.Windows.Forms.DataGridView();
            this.hardGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.simpleGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.middleGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hardGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.simpleGridView, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.hardGridView, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.middleGridView, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 40);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(813, 466);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // simpleGridView
            // 
            this.simpleGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.simpleGridView.Enabled = false;
            this.simpleGridView.Location = new System.Drawing.Point(4, 4);
            this.simpleGridView.Margin = new System.Windows.Forms.Padding(4);
            this.simpleGridView.Name = "simpleGridView";
            this.simpleGridView.ReadOnly = true;
            this.simpleGridView.RowHeadersVisible = false;
            this.simpleGridView.RowTemplate.Height = 23;
            this.simpleGridView.Size = new System.Drawing.Size(261, 450);
            this.simpleGridView.TabIndex = 0;
            // 
            // middleGridView
            // 
            this.middleGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.middleGridView.Enabled = false;
            this.middleGridView.Location = new System.Drawing.Point(275, 4);
            this.middleGridView.Margin = new System.Windows.Forms.Padding(4);
            this.middleGridView.Name = "middleGridView";
            this.middleGridView.ReadOnly = true;
            this.middleGridView.RowHeadersVisible = false;
            this.middleGridView.RowTemplate.Height = 23;
            this.middleGridView.Size = new System.Drawing.Size(261, 450);
            this.middleGridView.TabIndex = 1;
            // 
            // hardGridView
            // 
            this.hardGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.hardGridView.Enabled = false;
            this.hardGridView.Location = new System.Drawing.Point(546, 4);
            this.hardGridView.Margin = new System.Windows.Forms.Padding(4);
            this.hardGridView.Name = "hardGridView";
            this.hardGridView.ReadOnly = true;
            this.hardGridView.RowHeadersVisible = false;
            this.hardGridView.RowTemplate.Height = 23;
            this.hardGridView.Size = new System.Drawing.Size(263, 450);
            this.hardGridView.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "简单模式英雄排行榜";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(284, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "中等模式英雄排行榜";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(555, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "困难模式英雄排行榜";
            // 
            // ScoreShowDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 506);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(853, 562);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(853, 562);
            this.Name = "ScoreShowDlg";
            this.Text = "扫雷英雄榜";
            this.Load += new System.EventHandler(this.ScoreShowDlg_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.simpleGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.middleGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hardGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView simpleGridView;
        private System.Windows.Forms.DataGridView middleGridView;
        private System.Windows.Forms.DataGridView hardGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
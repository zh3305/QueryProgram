namespace QueryProgram
{
    partial class MainForm
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
            this.tb_Search = new MetroFramework.Controls.MetroTextBox();
            this.bt_Search = new MetroFramework.Controls.MetroButton();
            this.tb_MainData = new MetroFramework.Controls.MetroTabControl();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // tb_Search
            // 
            // 
            // 
            // 
            this.tb_Search.CustomButton.Image = null;
            this.tb_Search.CustomButton.Location = new System.Drawing.Point(194, 1);
            this.tb_Search.CustomButton.Name = "";
            this.tb_Search.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tb_Search.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tb_Search.CustomButton.TabIndex = 1;
            this.tb_Search.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tb_Search.CustomButton.UseSelectable = true;
            this.tb_Search.CustomButton.Visible = false;
            this.tb_Search.Lines = new string[0];
            this.tb_Search.Location = new System.Drawing.Point(83, 60);
            this.tb_Search.MaxLength = 32767;
            this.tb_Search.Name = "tb_Search";
            this.tb_Search.PasswordChar = '\0';
            this.tb_Search.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_Search.SelectedText = "";
            this.tb_Search.SelectionLength = 0;
            this.tb_Search.SelectionStart = 0;
            this.tb_Search.ShortcutsEnabled = true;
            this.tb_Search.Size = new System.Drawing.Size(216, 23);
            this.tb_Search.TabIndex = 1;
            this.tb_Search.UseCustomBackColor = true;
            this.tb_Search.UseSelectable = true;
            this.tb_Search.UseStyleColors = true;
            this.tb_Search.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tb_Search.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // bt_Search
            // 
            this.bt_Search.Location = new System.Drawing.Point(305, 60);
            this.bt_Search.Name = "bt_Search";
            this.bt_Search.Size = new System.Drawing.Size(75, 23);
            this.bt_Search.TabIndex = 2;
            this.bt_Search.Text = "搜索";
            this.bt_Search.UseCustomBackColor = true;
            this.bt_Search.UseSelectable = true;
            this.bt_Search.UseStyleColors = true;
            this.bt_Search.Click += new System.EventHandler(this.bt_Search_Click);
            // 
            // tb_MainData
            // 
            this.tb_MainData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_MainData.Location = new System.Drawing.Point(13, 92);
            this.tb_MainData.Margin = new System.Windows.Forms.Padding(0);
            this.tb_MainData.Name = "tb_MainData";
            this.tb_MainData.Size = new System.Drawing.Size(1072, 396);
            this.tb_MainData.TabIndex = 3;
            this.tb_MainData.UseSelectable = true;
            this.tb_MainData.UseStyleColors = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 60);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(54, 19);
            this.metroLabel1.TabIndex = 4;
            this.metroLabel1.Text = "关键字:";
            this.metroLabel1.UseCustomBackColor = true;
            this.metroLabel1.UseStyleColors = true;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1097, 508);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.tb_MainData);
            this.Controls.Add(this.bt_Search);
            this.Controls.Add(this.tb_Search);
            this.Name = "MainForm";
            this.Text = "关联查询程序";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroTextBox tb_Search;
        private MetroFramework.Controls.MetroButton bt_Search;
        private MetroFramework.Controls.MetroTabControl tb_MainData;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}


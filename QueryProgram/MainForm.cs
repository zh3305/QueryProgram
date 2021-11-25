using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using NPOI.XSSF.UserModel;
using Sync_Tools.GUI;

namespace QueryProgram
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        private FrmSplash frmSplash;

        public MainForm()
        {
            Thread thread = new Thread(new ThreadStart(RunLoding));
            thread.Start();
            // Task.Run(RunLoding).Start();
            InitializeComponent();
        }

        public void RunLoding()
        {

            frmSplash = new FrmSplash();
            Application.Run(frmSplash);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            async Task LoadAsync()
            {
                int pageindex = 0;
                // Parallel.ForEach(Directory.GetFileSystemEntries(
                //     Directory.GetCurrentDirectory() + "/明细",
                //     "*.xlsx"), sourcefile =>
                // {
                //  
                //
                //
                // });
                foreach (var sourcefile in Directory.GetFileSystemEntries(
                    Directory.GetCurrentDirectory() + "/明细",
                    "*.xlsx"))
                
                {
                    // string filename = System.IO.Path.GetFileName(sourcefile); //文件名  “Default.aspx”
                    // string extension = System.IO.Path.GetExtension(sourcefile); //扩展名 “.aspx”
                    string fileNameWithoutExtension =
                        System.IO.Path.GetFileNameWithoutExtension(sourcefile); // 没有扩展名的文件名 “Default”

                    var DataPage = new MetroTabPage()
                    {
                        HorizontalScrollbarBarColor = true,
                        HorizontalScrollbarHighlightOnWheel = false,
                        HorizontalScrollbarSize = 10,
                        Name = $"DataPage{pageindex}",
                        TabIndex = 0,
                        Text = fileNameWithoutExtension,
                        VerticalScrollbarBarColor = true,
                        VerticalScrollbarHighlightOnWheel = false,
                        VerticalScrollbarSize = 10,
                        Location = new System.Drawing.Point(4, 23),
                        Padding = new System.Windows.Forms.Padding(1),
                    };

                    var userControl1 = new UserControl1(sourcefile)
                    {
                        Dock = System.Windows.Forms.DockStyle.Fill,
                        Location = new Point(5, 5),
                        Margin = new Padding(5)
                    };
                    // await userControl1.LoadAsync();
                    DataPage.Controls.Add(userControl1);
                    this.tb_MainData.Controls.Add(DataPage);
                }

                // Task.WaitAll(Directory.GetFileSystemEntries(
                //     Directory.GetCurrentDirectory() + "/明细",
                //     "*.xlsx").Select(async sourcefile =>
                // {
                //
                // }).ToArray());

                frmSplash.stop();
            }

            LoadAsync().Wait();
        }

        private void bt_Search_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.tb_MainData.Controls)
            {
                if (control is MetroTabPage page)
                {
                    foreach (Control pageControl in page.Controls)
                    {
                        if (pageControl is UserControl1 Uci)
                        {
                            Uci.search(tb_Search.Text);
                        }
                    }
                }

                // 加载加载脚本

            }

        }
    }
}



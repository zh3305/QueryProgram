//using ScriptNET.Runtime;
//using Scripting.SSharp.Runtime;

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
// using Castle.Facilities.Logging;
using Microsoft.Win32;
// using Oauth2Login.HongHu;
// using Sync_Tools.IModule;
// using Sync_Tools.IoC;
// using Sync_Tools.Toos;
// using Sync_Tools.Toos.Quartz;

namespace Sync_Tools.GUI
{
    //using Microsoft.ClearScript;

    public partial class FrmSplash : Form
    {
        private readonly int _centerX;
        private int _centerY;
        private bool _lastOrientation = true;
        private int _lastX = -1;
        private int _timer;

        public FrmSplash()
        {
            InitializeComponent();

            _centerX = Size.Width / 2;
            _centerY = Size.Height / 2;

            _centerX -= pictureBox1.Size.Width / 2;
            _centerY -= pictureBox1.Size.Height / 2;
            DialogResult = DialogResult.Cancel;
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            initialisator.RunWorkerAsync();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _timer += 25;
            var pic = pictureBox1;
            var time = _timer++;

            var tmp = time / 360.0f;
            var x = Math.Sin(tmp) * 90;
            x += _centerX;

            var y = pic.Location.Y;

            pic.Location = new Point((int)x, y);

            var goLeft = _lastX > (int)x;

            if (goLeft != _lastOrientation)
            {
                var img = pic.Image.Clone() as Image;
                Debug.Assert(img != null, "img != null");
                img.RotateFlip(RotateFlipType.RotateNoneFlipX);
                pic.Image = img;
                _lastOrientation = goLeft;
            }

            _lastX = (int)x;
        }

        private void initialisator_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // DialogResult = DialogResult.OK;
            // timer1.Stop();
            // Close();
            //this.Dispose();
        }

        public void stop()
        {
            timer1.Stop();
            Close();
        }

        private void initialisator_DoWork(object sender, DoWorkEventArgs e)
        {
            // try
            // {
                //var filepath = Assembly.GetExecutingAssembly().Location;
                //Environment.CurrentDirectory = filepath.Remove(filepath.LastIndexOf(System.IO.Path.DirectorySeparatorChar));

                //检查更新
                //initialisator.ReportProgress(0, "Checking for updates");
                //CraftNetTools.AppUpdates.Check();



                //读取配置
//                 initialisator.ReportProgress(0, "Initializing 加载配置文件 " + Config.Config.Instance.LoadedFromFile);
//                 //                Console.WriteLine(Config.Config.Instance.LoadedFromFile);
//
//
//                 var ModS = IocManager.Instance.ResolveAll<IModuleInterface>();
//                 foreach (var moduleInterface in ModS)
//                 {
//                     initialisator.ReportProgress(0, "初始化模块 ["+ moduleInterface.Name+"]");
//                     moduleInterface.Initialize();
//                 }
// #if SapB1
// //TODO 启用 Sbo DI  接口
// //初始化 Sbo DI  接口
//
// #else
//                 //初始化 链接字符串 接口
// //                initialisator.ReportProgress(0, "Initializing SQL interface");
// //                SetConnString.Initialize();
// //                SysDataLog.GetLog("TLog").Info("----------------");
// #endif
//
//
//                 //初始化脚本引擎
//                 initialisator.ReportProgress(0, "Initializing Script Engine");
//                 RScriptEngine.Initialize(ModS);
//
//
//                 //初始同步任务
//                 initialisator.ReportProgress(0, "Initializing Automated job scheduler");
//                 //  JobHost.RefJob();
//                 QuartzManager<RunJob>.Initialize().Wait();
//                 //SysDataLog.Shell.WriteLine("警告：2秒后关闭启动页...");
//                 //Thread.Sleep(1000);
//                 //SysDataLog.Shell.WriteLine("错误：1秒后关闭启动页...");
//                 //Thread.Sleep(1000);
//                 //SysDataLog.Shell.WriteLine("注意：正在关闭启动页...加载主窗口");
//                 //Thread.Sleep(100);
//                 Config.Config.Instance.Save();
//             }
//             catch (Exception exception)
//             {
//                 SysDataLog.HandleException(exception);
//                 Console.WriteLine(exception);
//                 throw;
//             }

            ////initialisator.ReportProgress(0, "Loading Script.NET context");
            ////ScriptNET.Runtime.RuntimeHost.Initialize();
        }

        /// <summary>
        ///   注册文件打开方式
        /// </summary>
        /// <param name="pExtension"></param>
        /// <param name="pProgramId"></param>
        /// <param name="pDescription"></param>
        /// <param name="pEXE"></param>
        /// <param name="pIconPath"></param>
        /// <param name="pIconIndex"></param>
        private static void RegisterFileAssociation(string pExtension, string pProgramId, string pDescription,
            string pEXE, string pIconPath, int pIconIndex)
        {
            try
            {
                if (pExtension.Length != 0)
                {
                    if (pExtension[0] != '.') pExtension = "." + pExtension;

                    using (var key = Registry.ClassesRoot.OpenSubKey(pExtension))
                    {
                        if (key == null)
                            using (var extKey = Registry.ClassesRoot.CreateSubKey(pExtension))
                            {
                                Debug.Assert(extKey != null, "extKey != null");
                                extKey.SetValue(string.Empty, pProgramId);
                            }
                    }

                    using (var extKey = Registry.ClassesRoot.OpenSubKey(pExtension))
                    {
                        Debug.Assert(extKey != null, "extKey != null");
                        using (var key = extKey.OpenSubKey(pProgramId))
                        {
                            if (key == null)
                                using (var progIdKey = Registry.ClassesRoot.CreateSubKey(pProgramId))
                                {
                                    Debug.Assert(progIdKey != null, "progIdKey != null");
                                    progIdKey.SetValue(string.Empty, pDescription);
                                    using (var defaultIcon = progIdKey.CreateSubKey("DefaultIcon"))
                                    {
                                        Debug.Assert(defaultIcon != null, "defaultIcon != null");
                                        defaultIcon.SetValue(string.Empty, $"\"{pIconPath}\",{pIconIndex}");
                                    }

                                    using (var command = progIdKey.CreateSubKey("shell\\open\\command"))
                                    {
                                        Debug.Assert(command != null, "command != null");
                                        command.SetValue(string.Empty, $"\"{pEXE}\" \"%1\"");
                                    }
                                }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error registering file association: {0}", ex);
            }
        }

        private void initialisator_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            label2.Text = (string)e.UserState;
        }
    }
}
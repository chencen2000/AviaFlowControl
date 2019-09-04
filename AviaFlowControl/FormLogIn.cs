using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace AviaFlowControl
{
    public partial class FormLogIn : Form
    {
        public FormLogIn()
        {
            InitializeComponent();
        }

        private void FormLogIn_Load(object sender, EventArgs e)
        {
            textBoxUsername.Focus();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // login
            labelLoginStatus.Visible = false;
            this.Enabled = false;
            Task.Run(() => 
            {
                //System.Threading.Thread.Sleep(3000);
                if (login_task())
                {
                    login_completed();
                }
            });
        }

        void login_completed()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    login_completed();
                }));
            }
            else
            {
                this.Close();
                Form3 f = new Form3();
                f.Show();
            }
        }

        bool login_task()
        {
            bool ret = false;
            try
            {
                string dir = System.IO.Path.Combine(System.Environment.GetEnvironmentVariable("FDHOME"), "AVIA", "hydra");
                System.IO.File.Delete(System.IO.Path.Combine(dir, "HydraLogin.xml"));
                string exe = System.IO.Path.Combine(dir, "HydraLogin.exe");
                string param = $"-u={textBoxUsername.Text} -p={textBoxPassword.Text}";
                if (System.IO.File.Exists(exe))
                {
                    System.Collections.Specialized.StringDictionary envs = new System.Collections.Specialized.StringDictionary();
                    envs.Add("APSTHOME", System.IO.Path.Combine(System.Environment.GetEnvironmentVariable("FDHOME"), "AVIA"));
                    //Tuple<int, string[]> res = Program.run_exe(@"c:\windows\system32\notepad.exe", param, envs);
                    Tuple<int, string[]> res = Program.run_exe(exe, param, envs);
                    if (res.Item1 == 0)
                    {
                        if (System.IO.File.Exists(System.IO.Path.Combine(dir, "HydraLogin.xml")))
                        {
                            utility.IniFile config = new utility.IniFile(System.IO.Path.Combine(System.Environment.GetEnvironmentVariable("FDHOME"), "AVIA", "config.ini"));
                            // load xml
                            try
                            {
                                XmlDocument doc = new XmlDocument();
                                doc.Load(System.IO.Path.Combine(dir, "HydraLogin.xml"));
                                string uid = doc.DocumentElement?["id"]?.InnerText;
                                config.WriteValue("config", "uid", uid);
                                // clear ini device section
                                utility.IniFile ini = new utility.IniFile(System.IO.Path.Combine(System.Environment.GetEnvironmentVariable("FDHOME"), "AVIA", "aviaDevice.ini"));
                                ini.DeleteSection("device");
                                // OE Control start
                                //OEControl.start();
                                ret = true;
                            }
                            catch (Exception) { }
                        }
                    }
                    else
                    {
                        this.Invoke(new Action(() =>
                        {
                            labelLoginStatus.Text = $"Fail to login, error code: {res.Item1}";
                            labelLoginStatus.Visible = true;
                        }));
                    }
                }
            }
            catch (Exception)
            { }
            finally
            {
                this.Invoke(new Action(() =>
                {
                    this.Enabled = true;
                }));
            }
            return ret;
        }
    }
}

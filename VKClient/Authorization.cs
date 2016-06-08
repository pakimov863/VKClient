using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using VKLib;
using VKLib.Enums.Filters;

namespace VKClient
{
    public partial class Authorization : Form
    {
        private VKapi _Api;
        private ulong _Appid;
        private string _Login = "";
        private string _Password = "";
        private string _Image = "";

        public Authorization(ref VKapi api, ulong appid)
        {
            InitializeComponent();
            _Api = api;
            _Appid = appid;
        }

        public void button_Login_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(_Login) || String.IsNullOrWhiteSpace(_Password))
            {
                if (textbox_Login.Text.Trim() == "" || textbox_Password.Text.Trim() == "")
                    MessageBox.Show("Неверный логин или пароль");
                else
                { _Login = textbox_Login.Text.Trim(); _Password = textbox_Password.Text.Trim(); }
            }

            try
            {
                _Api.Authorize(new ApiAuthParams
                {
                    ApplicationId = _Appid,
                    Login = _Login,
                    Password = _Password,
                    Settings = Settings.All
                });

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message); return;
            }

            if (_Api.IsAuthorized)
            {
                if (!Directory.Exists("users/" + Convert.ToString(_Api.UserId) + "/")) Directory.CreateDirectory("users/" + Convert.ToString(_Api.UserId) + "/");
                    using (StreamWriter SW = new StreamWriter("users/" + Convert.ToString(_Api.UserId) + "/userinfo.info", false))
                    {
                        SW.WriteLine(_Login);
                        SW.WriteLine(_Password);
                        SW.Close();
                    }
                using (StreamWriter SW = new StreamWriter("lastusers.info",false ))
                {
                    SW.WriteLine(Convert.ToString(_Api.UserId));
                    SW.Close();
                }
                this.Close();
            }
        }

        private void checkbox_PassVisible_CheckedChanged(object sender, EventArgs e)
        {
            textbox_Password.UseSystemPasswordChar = !checkbox_PassVisible.Checked;
        }

        private void Authorization_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists("users")) Directory.CreateDirectory("users");

            string username = "";
            if (File.Exists("lastusers.info"))
                using(StreamReader SR = new StreamReader("lastusers.info"))
                {
                    while(!SR.EndOfStream )
                    {
                        username = SR.ReadLine();
                    }
                    SR.Close();
                }
            if (username.Trim() == "") username = "";

            listBox1.Items.Add("Новый пользователь");
            listBox1.SelectedIndex = 0;
            foreach (string item in Directory.GetDirectories("users"))
            {
                if (File.Exists(item + "/userinfo.info"))
                {
                    string addusername = item.Substring(item.LastIndexOf("\\")+1);
                    listBox1.Items.Add(addusername);
                    if (addusername == username) listBox1.SelectedIndex = listBox1.Items.Count - 1;
                }
            }

            if (!String.IsNullOrWhiteSpace(username) && Directory.Exists("users/" + username + "/"))
            {
                if (File.Exists("users/" + username + "/userinfo.info"))
                {
                    using (StreamReader SR = new StreamReader("users/" + username + "/userinfo.info"))
                    {
                        _Login = SR.ReadLine();
                        _Password = SR.ReadLine();
                        _Image = SR.ReadLine();
                        SR.Close();
                    }
                    if (!String.IsNullOrWhiteSpace(_Image)) pictureBox1.Image = new Bitmap(_Image);
                    if (!String.IsNullOrWhiteSpace(_Login) && !String.IsNullOrWhiteSpace(_Password)) button_Login_Click(sender, e);
                    else if (!String.IsNullOrWhiteSpace(_Login))
                    {
                        textbox_Login.Text = _Login;
                        textbox_Password.Focus();
                    }
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex == 0)
            {
                textbox_Login.Clear(); textbox_Login.ClearUndo();
                textbox_Password.Clear(); textbox_Password.ClearUndo();
            }
            else
            {
                if (!String.IsNullOrWhiteSpace(listBox1.Items[listBox1.SelectedIndex].ToString()) && Directory.Exists("users/" + listBox1.Items[listBox1.SelectedIndex].ToString() + "/"))
                {
                    if (File.Exists("users/" + listBox1.Items[listBox1.SelectedIndex].ToString() + "/userinfo.info"))
                    {
                        using (StreamReader SR = new StreamReader("users/" + listBox1.Items[listBox1.SelectedIndex].ToString() + "/userinfo.info"))
                        {
                            _Login = SR.ReadLine();
                            _Password = SR.ReadLine();
                            _Image = SR.ReadLine();
                            SR.Close();
                        }
                        if (!String.IsNullOrWhiteSpace(_Image)) pictureBox1.Image = new Bitmap(_Image);
                        if (!String.IsNullOrWhiteSpace(_Login) && !String.IsNullOrWhiteSpace(_Password))
                        {
                            textbox_Login.Text = _Login;
                            textbox_Password.Text = _Password;
                            button_Login.Focus();
                        }
                        else if (!String.IsNullOrWhiteSpace(_Login))
                        {
                            textbox_Login.Text = _Login;
                            textbox_Password.Focus();
                        }
                        else
                        {
                            textbox_Login.Clear(); textbox_Login.ClearUndo();
                            textbox_Password.Clear(); textbox_Password.ClearUndo();
                            textbox_Login.Focus();
                        }
                    }
                }
            }
        }
    }
}

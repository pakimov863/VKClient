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
        private string _Login;
        private string _Password;
        private string _Image;

        public Authorization(ref VKapi api, ulong appid)
        {
            InitializeComponent();
            _Api = api;
            _Appid = appid;
        }

        public void button_Login_Click(object sender, EventArgs e)
        {
            if (_Login.Trim() == "" || _Password.Trim() == "")
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
            catch(VKLib.Exception.AccessDeniedException ex)
            {
                MessageBox.Show("Неверный логин или пароль: " + ex.Message); return;
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

        private void button1_Click(object sender, EventArgs e)
        {
            //var api = new VKapi();
            //api.Authorize(appId, email, password, settings); // авторизуемся

            //api.Messages.Send(12504716, false, "привет, друг!");
            //var myuser = api.Users.Get(143525490,ProfileFields.All );
            //int i = 0;
            //var myuser = api.Messages.GetHistory(143525490, false, out i);
            //var myuser = api.Messages.GetDialogs();
            //MessageBox.Show(Convert.ToString(myuser));
            //var audio = api.Audio.Get(143525490);
            //MessageBox.Show(Convert.ToString(audio));

            /*var group = api.Utils.ResolveScreenName("habr"); // получаем id сущности с коротким именем habr

            // получаем id пользователей из группы, макс. кол-во записей = 1000
            int totalCount; // общее кол-во участников
            var userIds = api.Groups.GetMembers(group.Id.Value, out totalCount);
            foreach (long id in userIds)
            {
                api.Messages.Send(id, false, "привет, друг!"); // посылаем сообщение пользователю
            }*/
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
            if (username.Trim() == "") username = null;
            if (username != null && Directory.Exists("users/" + username + "/"))
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
                    if (_Image != null) if (_Image.Trim() != "") pictureBox1.Image = new Bitmap(_Image);
                    if (_Login != null && _Password != null) if (_Login.Trim() != "" && _Password.Trim() != "") button_Login_Click(sender, e);
                    else if (_Login.Trim() != "") textbox_Login.Text = _Login;
                }
            }
        }
    }
}

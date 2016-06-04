using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using VKLib;
using VKLib.Enums.Filters;

namespace VKClient
{
    public partial class Authorization : Form
    {
        private auth_login loginBox; 
        public Authorization()
        {
            InitializeComponent();
            loginBox = new auth_login();
            loginBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            loginBox.Location = new System.Drawing.Point(this.Width - loginBox.Width-28, 12);
            loginBox.Name = "loginBox";
            loginBox.button_Login.Click += new System.EventHandler(this.button_Login_Click);
            this.Controls.Add(loginBox);
        }

        public void button_Login_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("L:" + loginBox.textbox_Login.Text + " P:" + loginBox.textbox_Password.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region private
            int appId = 0; // указываем id приложения
            string email = "0"; // email для авторизации
            string password = "0"; // пароль
            #endregion

            Settings settings = Settings.All; // уровень доступа к данным

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
    }
}

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
using System.Collections.ObjectModel;

namespace VKClient
{
    public partial class Messenger : Form
    {
        public Messenger()
        {
            InitializeComponent();
        }
        public ReadOnlyCollection<VKLib.Model.Message> dialog;
        public VKapi qu = new VKapi();

        private void Messenger_Load(object sender, EventArgs e)
        {
            int x = 0;
            while (x < 20)
            {
                messageControl1.Add("Testing\r\nasdasdasdasd", MessageControl.BubblePositionEnum.Right);
                messageControl1.Add("Testing\r\nasdasdasdasd\r\nasdasdasdasd", MessageControl.BubblePositionEnum.Right);
                messageControl1.Add("Testing", MessageControl.BubblePositionEnum.Left);
                x++;
            }
            int id = 0;
            string log = "", pass = "";
            SettingLoader.logpass(ref id, ref log, ref pass);
            Settings lvl = Settings.All;
            qu.Authorize(id, log, pass, lvl);

            int totalcount = 5; int unreadcount = 5;

            dialog = qu.Messages.GetDialogs(out totalcount, out unreadcount, 5, 0, false);

            //System.Collections.ObjectModel.ReadOnlyCollection<VKLib.Model.Message>
            for (int i = 0; i < 5; i++)
            {

                if (dialog[i].UsersCount > 2) listBox2.Items.Add(dialog[i].Title);
                else
                {
                    VKLib.Model.User obj = qu.Users.Get(Convert.ToInt64(dialog[i].UserId));
                    listBox2.Items.Add(obj.FirstName + " " + obj.LastName);
                }
            }

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.chat_MainWindow1.messages.Clear();

            listBox1.Items.Clear();
            int messegcount = 10;
            int a = listBox2.SelectedIndex;
            ReadOnlyCollection<VKLib.Model.Message> history;
            if (dialog[a].UsersCount > 2)
                history = qu.Messages.GetHistory(out messegcount, true, 2000000000 + Convert.ToInt64(dialog[a].ChatId));
            else
            {
                history = qu.Messages.GetHistory(out messegcount, false, Convert.ToInt64(dialog[a].UserId));
            }
            for (int i = history.Count - 1; i >= 0; i--)
            {
                listBox1.Items.Add(history[i].FromId + " " + history[i].Body);
                //if (history[i].FromId != qu.UserId) this.chat_MainWindow1.addTextYou(history[i].Body, Convert.ToDateTime(history[i].Date));
                //else this.chat_MainWindow1.addTextMe(history[i].Body, Convert.ToDateTime(history[i].Date));
            }
            listBox1.TopIndex = listBox1.Items.Count - 1;

            //this.chat_MainWindow1.ScrollConversationToEnd();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.chat_MainWindow1.messages.Clear();
            //this.chat_MainWindow1.addTextMe("asdasdasd");

            string t = textBox1.Text;
            int a = listBox2.SelectedIndex;
            if (t != "")
            {
                listBox1.Items.Add(Convert.ToString(qu.UserId) + " " + t);
                if (dialog[a].UsersCount > 2)
                    qu.Messages.Send(2000000000 + Convert.ToInt64(dialog[a].ChatId), true, t);
                else
                {
                    qu.Messages.Send(Convert.ToInt64(dialog[a].UserId), false, t);
                }
                textBox1.Clear();
            }
        }
    }
}
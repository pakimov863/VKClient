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

        private void Messenger_Load(object sender, EventArgs e)
        {
            int id=0;
            string log="", pass="";
            SettingLoader.logpass(ref id, ref log, ref pass);
            VKapi qu = new VKapi();
            Settings lvl = Settings.All;
            qu.Authorize(id, log, pass, lvl);

            int totalcount = 5; int unreadcount = 5;

            ReadOnlyCollection<VKLib.Model.Message> dialog = qu.Messages.GetDialogs(out totalcount, out unreadcount, 20, 0, false);
            
            //System.Collections.ObjectModel.ReadOnlyCollection<VKLib.Model.Message>
            for (int i=0; i<20; i++)
            {
                if (dialog[i].Title != " ... ") listBox2.Items.Add(dialog[i].Title);
                else
                {
                    VKLib.Model.User obj = qu.Users.Get(Convert.ToInt64(dialog[i].UserId));
                    listBox2.Items.Add(obj.FirstName+" "+obj.LastName);
                }
            }

        }
    }
}
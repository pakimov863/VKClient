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
namespace VKClient
{
    public partial class Form1 : Form
    {
        public VKapi _API;
        public ulong  _APPID;

        public Form1()
        {
            InitializeComponent();
            _API = new VKapi();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string l = "", p = "";
            SettingLoader.logpass(ref _APPID, ref l, ref p);

            Authorization au = new Authorization(ref _API, _APPID);
            if (au.ShowDialog() == DialogResult.No) Application.Exit();
            this.Size = new Size(200, 100);
        }
    }
}

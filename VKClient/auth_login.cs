using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VKClient
{
    public partial class auth_login : UserControl
    {
        public auth_login()
        {
            InitializeComponent();
        }

        private void checkbox_PassVisible_CheckedChanged(object sender, EventArgs e)
        {
            textbox_Password.UseSystemPasswordChar = !checkbox_PassVisible.Checked;
        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;

namespace VKClient
{
    public partial class load_anim : UserControl
    {
        public load_anim()
        {
            InitializeComponent();
        }

        private byte animType = 1;
        private int animIterator = 0;

        public void StartAnimation(byte type = 1)
        {
            animType = type;
            if (animType != 1 && animType != 2) animType = 1;
            timer_anim.Start();
        }

        public void PauseAnimation()
        {
            if (timer_anim.Enabled) timer_anim.Stop();
            else timer_anim.Start();
        }

        private void timer_anim_Tick(object sender, EventArgs e)
        {
            animIterator++;
            if ((animType == 1 && animIterator > Convert.ToInt32(Properties.Resources.AL1Length)) ||
                    (animType == 2 && animIterator > Convert.ToInt32(Properties.Resources.AL2Length)))
                animIterator = 0;

            pictureBox_anim.Image = Properties.Resources.ResourceManager.GetObject("AL" + animType.ToString() + "_" + animIterator.ToString("000")) as Image;
        }
    }
}

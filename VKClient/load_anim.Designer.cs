namespace VKClient
{
    partial class load_anim
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox_anim = new System.Windows.Forms.PictureBox();
            this.timer_anim = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_anim)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_anim
            // 
            this.pictureBox_anim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_anim.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_anim.Name = "pictureBox_anim";
            this.pictureBox_anim.Size = new System.Drawing.Size(100, 100);
            this.pictureBox_anim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_anim.TabIndex = 0;
            this.pictureBox_anim.TabStop = false;
            // 
            // timer_anim
            // 
            this.timer_anim.Interval = 30;
            this.timer_anim.Tick += new System.EventHandler(this.timer_anim_Tick);
            // 
            // load_anim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pictureBox_anim);
            this.Name = "load_anim";
            this.Size = new System.Drawing.Size(100, 100);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_anim)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_anim;
        private System.Windows.Forms.Timer timer_anim;
    }
}

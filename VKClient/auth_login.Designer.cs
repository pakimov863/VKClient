namespace VKClient
{
    partial class auth_login
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textbox_Password = new System.Windows.Forms.TextBox();
            this.textbox_Login = new System.Windows.Forms.TextBox();
            this.label_ = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkbox_PassVisible = new System.Windows.Forms.CheckBox();
            this.button_Login = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Silver;
            this.pictureBox1.Location = new System.Drawing.Point(131, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // textbox_Password
            // 
            this.textbox_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textbox_Password.Location = new System.Drawing.Point(131, 294);
            this.textbox_Password.Name = "textbox_Password";
            this.textbox_Password.Size = new System.Drawing.Size(179, 24);
            this.textbox_Password.TabIndex = 1;
            this.textbox_Password.UseSystemPasswordChar = true;
            // 
            // textbox_Login
            // 
            this.textbox_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textbox_Login.Location = new System.Drawing.Point(131, 264);
            this.textbox_Login.Name = "textbox_Login";
            this.textbox_Login.Size = new System.Drawing.Size(200, 24);
            this.textbox_Login.TabIndex = 2;
            // 
            // label_
            // 
            this.label_.AutoSize = true;
            this.label_.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_.Location = new System.Drawing.Point(71, 206);
            this.label_.Name = "label_";
            this.label_.Size = new System.Drawing.Size(328, 37);
            this.label_.TabIndex = 3;
            this.label_.Text = "Новый пользователь";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(75, 267);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Логин";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(64, 297);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Пароль";
            // 
            // checkbox_PassVisible
            // 
            this.checkbox_PassVisible.AutoSize = true;
            this.checkbox_PassVisible.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkbox_PassVisible.Location = new System.Drawing.Point(316, 300);
            this.checkbox_PassVisible.Name = "checkbox_PassVisible";
            this.checkbox_PassVisible.Size = new System.Drawing.Size(15, 14);
            this.checkbox_PassVisible.TabIndex = 6;
            this.checkbox_PassVisible.UseVisualStyleBackColor = true;
            this.checkbox_PassVisible.CheckedChanged += new System.EventHandler(this.checkbox_PassVisible_CheckedChanged);
            // 
            // button_Login
            // 
            this.button_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Login.Location = new System.Drawing.Point(337, 294);
            this.button_Login.Name = "button_Login";
            this.button_Login.Size = new System.Drawing.Size(65, 24);
            this.button_Login.TabIndex = 7;
            this.button_Login.Text = "Вход";
            this.button_Login.UseVisualStyleBackColor = true;
            // 
            // auth_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.button_Login);
            this.Controls.Add(this.checkbox_PassVisible);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_);
            this.Controls.Add(this.textbox_Login);
            this.Controls.Add(this.textbox_Password);
            this.Controls.Add(this.pictureBox1);
            this.Name = "auth_login";
            this.Size = new System.Drawing.Size(462, 333);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkbox_PassVisible;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.TextBox textbox_Password;
        public System.Windows.Forms.TextBox textbox_Login;
        public System.Windows.Forms.Label label_;
        public System.Windows.Forms.Button button_Login;
    }
}

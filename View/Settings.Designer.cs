namespace MTSRecorder.View
{
    partial class SettingsFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.settingsCancelBtn = new System.Windows.Forms.Button();
            this.settingsSaveBtn = new System.Windows.Forms.Button();
            this.settingsPasswordTB = new System.Windows.Forms.TextBox();
            this.settingsLoginTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.settingsCancelBtn);
            this.groupBox1.Controls.Add(this.settingsSaveBtn);
            this.groupBox1.Controls.Add(this.settingsPasswordTB);
            this.groupBox1.Controls.Add(this.settingsLoginTB);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 123);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Логин и проль";
            // 
            // settingsCancelBtn
            // 
            this.settingsCancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.settingsCancelBtn.Location = new System.Drawing.Point(194, 94);
            this.settingsCancelBtn.Name = "settingsCancelBtn";
            this.settingsCancelBtn.Size = new System.Drawing.Size(75, 23);
            this.settingsCancelBtn.TabIndex = 5;
            this.settingsCancelBtn.Text = "Отмена";
            this.settingsCancelBtn.UseVisualStyleBackColor = true;
            this.settingsCancelBtn.Click += new System.EventHandler(this.settingsCancelBtn_Click);
            // 
            // settingsSaveBtn
            // 
            this.settingsSaveBtn.Location = new System.Drawing.Point(6, 94);
            this.settingsSaveBtn.Name = "settingsSaveBtn";
            this.settingsSaveBtn.Size = new System.Drawing.Size(75, 23);
            this.settingsSaveBtn.TabIndex = 4;
            this.settingsSaveBtn.Text = "Сохранить";
            this.settingsSaveBtn.UseVisualStyleBackColor = true;
            this.settingsSaveBtn.Click += new System.EventHandler(this.settingsSaveBtn_Click);
            // 
            // settingsPasswordTB
            // 
            this.settingsPasswordTB.Location = new System.Drawing.Point(66, 55);
            this.settingsPasswordTB.Name = "settingsPasswordTB";
            this.settingsPasswordTB.Size = new System.Drawing.Size(203, 21);
            this.settingsPasswordTB.TabIndex = 3;
            // 
            // settingsLoginTB
            // 
            this.settingsLoginTB.Location = new System.Drawing.Point(66, 28);
            this.settingsLoginTB.Name = "settingsLoginTB";
            this.settingsLoginTB.Size = new System.Drawing.Size(203, 21);
            this.settingsLoginTB.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Пароль";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Логин";
            // 
            // SettingsFrm
            // 
            this.AcceptButton = this.settingsSaveBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.settingsCancelBtn;
            this.ClientSize = new System.Drawing.Size(299, 147);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsFrm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.SettingsFrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button settingsCancelBtn;
        private System.Windows.Forms.Button settingsSaveBtn;
        private System.Windows.Forms.TextBox settingsPasswordTB;
        private System.Windows.Forms.TextBox settingsLoginTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
using System;
using System.Windows.Forms;

namespace MTSRecorder.View
{
    public partial class SettingsFrm : Form
    {
        public SettingsFrm()
        {
            InitializeComponent();
        }

//Сохранить настройки
        private void settingsSaveBtn_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.User = settingsLoginTB.Text;
            Properties.Settings.Default.Password = settingsPasswordTB.Text;
            Properties.Settings.Default.Save();
            Close();
        }

//Отмена
        private void settingsCancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SettingsFrm_Load(object sender, EventArgs e)
        {
            settingsLoginTB.Text = Properties.Settings.Default.User;
            settingsPasswordTB.Text = Properties.Settings.Default.Password;
        }
    }
}
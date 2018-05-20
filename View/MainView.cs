using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
//using AutoUpdaterEasy;
using MTSRecorder.Presenter;
using MTSRecorder.Properties;

namespace MTSRecorder.View
{
    public partial class MainWindow : Form

    {
        private string _fPath;
        

        public MainWindow()
        {
            InitializeComponent();
           
            Application.EnableVisualStyles();
           
            
            

        }

 //Кнопка настроек
        private void settingsBtn_Click(object sender, EventArgs e)
        {

            SettingsFrm sf = new SettingsFrm();
            sf.ShowDialog();
        }

//Получить список номеров и заполнить таблицу
        private void connectBtn_Click(object sender, EventArgs e)
        {
            var w = new Worker().GetNumbers();
            if (w != null)
            {
                numbersGV.DataSource = w;
                numbersGV.Columns[0].Visible = false;
                numbersGV.Columns[1].HeaderText = Resources.NumDGV_Header1;
            }

        }
//Получить все записи номера
        private void numbersGV_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var num = numbersGV.CurrentCell.Value.ToString();
            var r = Worker.GetRecs(num);
            recGv.DataSource = r;
            recGv.Columns[0].Visible = false;
            recGv.Columns[1].HeaderText = Resources.MainWindow_numbersGV_Number;
            recGv.Columns[2].HeaderText = Resources.MainWindow_numbersGV_CellContentDoubleClick_Type;
            recGv.Columns[3].HeaderText = Resources.MainWindow_numbersGV_CellContentDoubleClick_DateTime;
            recGv.Columns[4].HeaderText = Resources.MainWindow_numbersGV_CellContentDoubleClick_Duration;
            recGv.Columns[5].HeaderText = Resources.MainWindow_numbersGV_CellContentDoubleClick_File;
        }
//Скачать все записи номера
        private void downloadAllBtn_Click(object sender, EventArgs e)
        {
            if (numbersGV.CurrentCell != null)
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.ShowDialog();
                _fPath = fbd.SelectedPath;
                string num = numbersGV.CurrentCell.Value.ToString();
                Worker.DownloadAllRcs(_fPath, num);               
            }
            else
            {
                MessageBox.Show(Resources.MainWindow_downloadAllBtn_Click_SelectNumberFromList);
            }
        }

    }
    }

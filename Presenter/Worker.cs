using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using MTSRecorder.Properties;
using MTSRecorder.View;


namespace MTSRecorder.Presenter
{
    
    public class Worker
    {
        private const string UrlBase = "https://mrecord.mts.ru/api/v2";
        private static readonly string Login = Settings.Default.User;
        private static readonly string Password = Settings.Default.Password;
        public static int Fcount { get; set; }
        public static int FAll { get; set; }

        public static  MainWindow Mf = ((MainWindow) Application.OpenForms["MainWindow"]);
        //private  MTSData.NumbersDataTable _dtn;


        //Получаем список номеров
        public MTSData.NumbersDataTable GetNumbers()
        {
            var dtn=new MTSData.NumbersDataTable();

            var client = new RestClient(UrlBase)
            {
                Authenticator = new HttpBasicAuthenticator(Login, Password)
            };
            var request = new RestRequest("/numbers", Method.GET);
            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                MessageBox.Show(Resources.Worker_GetNumbers_ErrorMessageBox, Resources.Worker_GetNumbers_ErrorCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dtn;
            }
            else
            {
                var content = response.Content;
                    dynamic jsonObj = JsonConvert.DeserializeObject(content);
                    dynamic value = jsonObj["Value"];
                    foreach (var val in value)
                    {
                        var nr = dtn.NewNumbersRow();
                        nr["Number"] = val.Name;
                        dtn.Rows.Add(nr);
                    }
                }
            return dtn;
        }

//Отображает все записи
        public static MTSData.RecordsDataTable GetRecs(string number)
        {
            
            var dt1 = DateTime.Now;
            var dt2 = dt1.AddMonths(-1);
            var sdt1 = dt1.ToString("yyyy-MM-ddTHH:mm:ss");
            var sdt2 = dt2.ToString("yyyy-MM-ddTHH:mm:ss");
            var client = new RestClient(UrlBase)
            {
                Authenticator = new HttpBasicAuthenticator(Login, Password)
            };
            var request = new RestRequest("/recs/" + number + "/" + sdt2 + "/" + sdt1, Method.GET);
            var response = client.Execute(request);
            var content = response.Content;
            dynamic jsonObj = JsonConvert.DeserializeObject(content);
            dynamic value = jsonObj["Value"];
            var rdt = new MTSData.RecordsDataTable();
            if (value != null)
            {
                foreach (var val in value)
                {
                    var rr = rdt.NewRecordsRow();
                    rr["Number"] = val.Number;
                    rr["CallType"] = val.CallType;
                    rr["CallTime"] = val.CallTime;
                    rr["Duration"] = val.Duration;
                    rr["FileName"] = val.FileName;
                    rdt.Rows.Add(rr);
                }
            }
            else
            {
                MessageBox.Show(Resources.Worker_GetRecs_NullRecords);
            }
            return rdt;
        }

//Скачивание всех записей
        internal static async void DownloadAllRcs(string fPath, string num)
        {
            var rdt = GetRecs(num);
            var fNameArray = rdt.Rows.Cast<DataRow>().Select(x => x.ItemArray[5]).ToList();
            var dict = new Dictionary<Uri, string>();
            foreach (var t in fNameArray)
            {
                var s = t.ToString();
                var fUrl = "https://mrecord.mts.ru/api/v2/file/" + num + "/" + s;
                dict.Add(new Uri(fUrl), fPath+"\\"+s + ".mp3");
            }
            FAll = dict.Count;
            Mf.label6.Text = FAll.ToString();
            await DownloadManyFiles(dict);
        }
//Загружатель
        public static async Task DownloadManyFiles(Dictionary<Uri, string> files)
        {
            var wc = new WebClient {Credentials = GetCredential()};
            Fcount = 0;
            wc.DownloadProgressChanged += (s, e) => Mf.progressBar1.Value = e.ProgressPercentage;
            Mf.progressBar2.Maximum = FAll;
            foreach (var pair in files)
            {
                await wc.DownloadFileTaskAsync(pair.Key, pair.Value);
                Fcount++;
                Mf.label1.Text = Fcount.ToString();
                Mf.progressBar2.Value = Fcount;
            }
            wc.Dispose();
        }
//Базовая аутентификация для webClient
        private static CredentialCache GetCredential()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            var credentialCache = new CredentialCache
            {
                {new Uri(UrlBase), "Basic", new NetworkCredential(Login, Password)}
            };
            return credentialCache;
        }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OKCount
{
    public partial class Form1 : Form
    {
        private const string _BASE_URL = "http://10.15.8.85/OK/api/ok/";
        private const string _RESULTS = "HighScores";
        private const string _SAVE_RESULT = "SaveScore";

        int ok = 0;

        private List<DailyScore> _dailyScores = new List<DailyScore>();
        public List<DailyScore> DailyScores { get => _dailyScores; set => _dailyScores = value; }


        public Form1()
        {
            InitializeComponent();
            textBox1.Text = ok.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ok++;
            textBox1.Text = ok.ToString();
        }

        private async void saveScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DailyScore newScore = new DailyScore()
            {
                Time = DateTime.Now,
                Score = ok
            };
            DailyScores.Add(newScore);

            using (HttpClient client = new HttpClient())
            {
                var httpContent = new StringContent(JsonConvert.SerializeObject(newScore), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(_BASE_URL + _SAVE_RESULT, httpContent);
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show(response.StatusCode.ToString() + " : " + response.ReasonPhrase);
                }
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(_BASE_URL + _RESULTS);
                if (response.IsSuccessStatusCode)
                {
                    string responseJson = await response.Content.ReadAsStringAsync();
                    this.DailyScores = JsonConvert.DeserializeObject<List<DailyScore>>(responseJson);
                }
            }
        }

        private void highScoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HighScores hs = new HighScores(this.DailyScores);
            hs.ShowDialog();
        }
    }
}

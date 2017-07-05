using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OKCount
{
    public partial class HighScores : Form
    {
        private List<DailyScore> Scores
        {
            get;set;
        }

        public HighScores(List<DailyScore> scores)
        {
            InitializeComponent();
            this.Scores = scores;
        }

        private void HighScores_Load(object sender, EventArgs e)
        {
            this.bsScores.DataSource = this.Scores.OrderByDescending(a => a.Score);
        }
    }
}

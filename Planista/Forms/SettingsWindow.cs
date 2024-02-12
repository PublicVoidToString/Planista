using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planista.Forms
{
    public partial class SettingsWindow : Form
    {
        #region Initialization
        public SettingsWindow()
        {
            InitializeComponent();
            SetText();
        }
        private void SetText()
        {
            for (int i = 0; i < 11; ++i)
            {
                Controls[$"TPrBreak{i}"].Text = $"{ConditionsData.NoBreaksProfessorPoints[i]}";
                Controls[$"TStBreak{i}"].Text = $"{ConditionsData.NoBreaksStudentPoints[i]}";
                if (i < 6)
                {
                    Controls[$"TCon{i}"].Text = $"{ConditionsData.subjectContinuityPoints[i]}";
                    Controls[$"THourLimit{i}"].Text = $"{ConditionsData.hourLimitPoints[i]}";
                    Controls[$"TBestStartStudent{i}"].Text = $"{ConditionsData.bestFirstHourPoints[0, i]}";
                    Controls[$"TBestStartProfessor{i}"].Text = $"{ConditionsData.bestFirstHourPoints[1, i]}";
                }
            }
            TFirstHour.Text = $"{ConditionsData.firstHour}";
            TLastHour.Text = $"{ConditionsData.lastHour}";
            THourLimit.Text = $"{ConditionsData.hourLimit}";
            TBestStart.Text = "";
            TBestStart.Text = $"{ConditionsData.bestFirstHour}";
            TMutation.Text = $"{Data.mutationChance}";
            TCrossover.Text = $"{Data.crossoverChance}";
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
        #endregion
        //------------------------------END OF REGION------------------------------//
        #region Scorers criteria settings    NOT DONE YET
        private void TFirstHour_TextChanged(object sender, EventArgs e)
        {
            (sender as TextBox).Text=Engine.insertedTextToInt((sender as TextBox).Text, ref ConditionsData.firstHour,23);
        }
        private void TLastHour_TextChanged(object sender, EventArgs e)
        {
            (sender as TextBox).Text = Engine.insertedTextToInt((sender as TextBox).Text, ref ConditionsData.lastHour, 24);
        }
        private void THourLimit_TextChanged(object sender, EventArgs e)
        {
            (sender as TextBox).Text = Engine.insertedTextToInt((sender as TextBox).Text, ref ConditionsData.hourLimit, 24);
        }
        private void TBestStart_TextChanged(object sender, EventArgs e)
        {
            (sender as TextBox).BackColor = Color.Red;
            (sender as TextBox).Text = Engine.insertedTextToInt((sender as TextBox).Text, ref ConditionsData.bestFirstHour);
            if (ConditionsData.bestFirstHour < ConditionsData.firstHour) ConditionsData.bestFirstHour = ConditionsData.firstHour;
            else if (ConditionsData.bestFirstHour > ConditionsData.lastHour) ConditionsData.bestFirstHour = ConditionsData.lastHour;
            else if((sender as TextBox).Text!="")(sender as TextBox).BackColor = Color.White;
        }
        #endregion
        //------------------------------END OF REGION------------------------------//
        #region Scorers points settings
        private void TStBreakPoint_TextChanged(object sender, EventArgs e)
        {
            int id = int.Parse(Regex.Match((sender as TextBox).Name, @"\d+").Value);
            (sender as TextBox).Text = Engine.insertedTextToInt((sender as TextBox).Text, ref ConditionsData.NoBreaksStudentPoints[id]);

        }
        private void TPrBreakPoint_TextChanged(object sender, EventArgs e)
        {
            int id = int.Parse(Regex.Match((sender as TextBox).Name, @"\d+").Value);
            (sender as TextBox).Text = Engine.insertedTextToInt((sender as TextBox).Text, ref ConditionsData.NoBreaksProfessorPoints[id]);
        }
        private void TConPoint_TextChanged(object sender, EventArgs e)
        {
            int id = int.Parse(Regex.Match((sender as TextBox).Name, @"\d+").Value);
            (sender as TextBox).Text = Engine.insertedTextToInt((sender as TextBox).Text, ref ConditionsData.subjectContinuityPoints[id]);
        }
        private void THourLimitPoint_TextChanged(object sender, EventArgs e)
        {
            int id = int.Parse(Regex.Match((sender as TextBox).Name, @"\d+").Value);
            (sender as TextBox).Text = Engine.insertedTextToInt((sender as TextBox).Text, ref ConditionsData.hourLimitPoints[id]);
        }
        private void TBestStartStudentPoints_TextChanged(object sender, EventArgs e)
        {
            int id = int.Parse(Regex.Match((sender as TextBox).Name, @"\d+").Value);
            (sender as TextBox).Text = Engine.insertedTextToInt((sender as TextBox).Text, ref ConditionsData.bestFirstHourPoints[0,id]);
        }
        private void TBestStartProfessorPoints_TextChanged(object sender, EventArgs e)
        {
            int id = int.Parse(Regex.Match((sender as TextBox).Name, @"\d+").Value);
            (sender as TextBox).Text = Engine.insertedTextToInt((sender as TextBox).Text, ref ConditionsData.bestFirstHourPoints[1, id]);
        }
        #endregion
        //------------------------------END OF REGION------------------------------//
        #region Algorithm setting
        private void TMutation_TextChanged(object sender, EventArgs e)
        {
            (sender as TextBox).Text = Engine.insertedTextToInt((sender as TextBox).Text, ref Data.mutationChance, 0, 100);
        }

        private void TCrossover_TextChanged(object sender, EventArgs e)
        {
            (sender as TextBox).Text = Engine.insertedTextToInt((sender as TextBox).Text, ref Data.crossoverChance, 0, 100);
        }

        #endregion
        //------------------------------END OF REGION------------------------------//
        #region ON/OFF scorers buttons
        private void BStuBreak_Click(object sender, EventArgs e)
        {
            ConditionsData.noBreakStudentB = !ConditionsData.noBreakStudentB;
            if (ConditionsData.noBreakStudentB) (sender as Button).BackColor = Color.Green;
            else (sender as Button).BackColor = Color.Red;
        }

        private void BProfBreak_Click(object sender, EventArgs e)
        {
            ConditionsData.noBreakProfessorB = !ConditionsData.noBreakProfessorB;
            if (ConditionsData.noBreakProfessorB) (sender as Button).BackColor = Color.Green;
            else (sender as Button).BackColor = Color.Red;

        }

        private void BCon_Click(object sender, EventArgs e)
        {
            ConditionsData.continuityB = !ConditionsData.continuityB;
            if (ConditionsData.continuityB) (sender as Button).BackColor = Color.Green;
            else (sender as Button).BackColor = Color.Red;

        }

        private void BLimit_Click(object sender, EventArgs e)
        {
            ConditionsData.hourLimitB = !ConditionsData.hourLimitB;
            if (ConditionsData.hourLimitB) (sender as Button).BackColor = Color.Green;
            else (sender as Button).BackColor = Color.Red;

        }

        private void BStartHourStu_Click(object sender, EventArgs e)
        {
            ConditionsData.bestFirstHourStudentB = !ConditionsData.bestFirstHourStudentB;
            if (ConditionsData.bestFirstHourStudentB) (sender as Button).BackColor = Color.Green;
            else (sender as Button).BackColor = Color.Red;

        }

        private void BStartHourProf_Click(object sender, EventArgs e)
        {
            ConditionsData.bestFirstHourProfessorB = !ConditionsData.bestFirstHourProfessorB;
            if (ConditionsData.bestFirstHourProfessorB) (sender as Button).BackColor = Color.Green;
            else (sender as Button).BackColor = Color.Red;

        }
        #endregion
        //------------------------------END OF REGION------------------------------//
        #region Function Buttons
        private void Breturn_Click(object sender, EventArgs e)
        {
            SetText();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        #endregion
        //------------------------------END OF REGION------------------------------//
    }//END OF SETTINGSWINDOW
}

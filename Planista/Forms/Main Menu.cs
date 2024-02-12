using Planista.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace Planista
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            tTime.Text = "01:00:00";
            SetDataListText();
        }

        private List<string> filePathList = new List<string>(); //List of paths to selected data
        private List<string> fileNameList = new List<string>(); //List of paths to selected data
        private short selectedView=1; //1-FileName List, 2-PathList, 3-GroupList, 4-ProfessorList

        #region Resize (Currently empty)
        private void MainMenu_Load(object sender, EventArgs e)
        {
        }
        private void MainMenu_Resize(object sender, EventArgs e)
        {
        }
        #endregion
        //------------------------------END OF REGION------------------------------//
        #region Button functions
        private void bClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        } //Close button click
        private void bStart_Click(object sender, EventArgs e)
        {
            progressBar.Step = 1;
            progressBar.Value = 0;
            ProgressVisible(true);
            ScheduleWindow better = new ScheduleWindow(Data.mixer.Scheduler());
            better.Show();
        } //Start Algorithm
        private void bChooseData_Click(object sender, EventArgs e)
        {
            string path = Engine.SelectFile();
            if (path != "") {
                Engine.ReadTextFile(path); //Reads data from file and inserts it into reference variables (Data->Variables storing schedule reference data)
                bStart.Enabled = true;
                filePathList.Add(path);
                fileNameList.Add(Path.GetFileName(path));
                filePathList.Sort();
                fileNameList.Sort();
                SetDataListText();
            }
        } //Button for choosing file to get data from 
        private void bSettings_Click(object sender, EventArgs e)
        {
            Data.settings.Show();
        } //Button starting setting window
        private void bResetData_Click(object sender, EventArgs e)
        {
            Data.groupList = null;
            Data.subjectList = null;
            Data.professorList = null;
            Data.referenceSchedule = new Schedule();
            bStart.Enabled = false;
            filePathList.Clear();
            fileNameList.Clear();
            SetDataListText();
        } //Button reseting reference data
        private void bChangeView_Click(object sender, EventArgs e)
        {
            selectedView += 1;
            if (selectedView > 4) selectedView = 1;
            SetDataListText();
        }
        private void tObject_TextChanged(object sender, EventArgs e)
        {
            tObject.BackColor = Color.White;
            if (int.TryParse(tObject.Text, out int n))
            {
                if (n >= 50) Data.schedulesCount = n;
                else tObject.BackColor = Color.Red;
            }
            else
            {
                if (tObject.Text != "") tObject.Text = $"{Data.schedulesCount}";
                else tObject.BackColor = Color.Red;
            }
        } //text changing amount of object per generation window (Data.schedulesCount)
        private void tGeneration_TextChanged(object sender, EventArgs e)
        {
            tGeneration.BackColor = Color.White;
            if (int.TryParse(tGeneration.Text, out int n))
            {
                if (n >= 50) Data.generationsCount = n;
                else tGeneration.BackColor = Color.Red;
            }
            else
            {
                if (tGeneration.Text != "") tGeneration.Text = $"{Data.generationsCount}";
                else tGeneration.BackColor = Color.Red;
            }

        }
        private void tTime_TextChanged(object sender, EventArgs e)
        {
            string[] lineSplit = tTime.Text.Split(':');
            short hours = (short)(Data.safetyTimerInSec / 3600);
            short minutes = (short)((Data.safetyTimerInSec % 3600) / 60);
            short seconds = (short)(Data.safetyTimerInSec % 60);
            string fillHour = "";
            string fillMinute = "";
            string fillSecond = "";
            if (lineSplit.Length == 3 && short.TryParse(lineSplit[0], out short n) && short.TryParse(lineSplit[1], out n) && short.TryParse(lineSplit[2], out n)) 
            {
                Engine.insertedTextToInt(lineSplit[0], ref hours);
                Engine.insertedTextToInt(lineSplit[1], ref minutes, 0, 59);
                Engine.insertedTextToInt(lineSplit[2], ref seconds, 0, 59);
                Data.safetyTimerInSec = hours * 3600 + minutes * 60 + seconds;
            }
            else
            {
                if (hours < 10) fillHour = "0";
                if (minutes < 10) fillMinute = "0";
                if (seconds < 10) fillSecond = "0";
                tTime.Text = $"{fillHour}{hours}:{fillMinute}{minutes}:{fillSecond}{seconds}";
            }
        } //text changing safety timer value (Data.safetyTimerInSec)

        #endregion
        //------------------------------END OF REGION------------------------------//
        #region Other functions
        private void SetDataListText()
        {
            switch (selectedView)
            {
                case 1: // FileName List
                    tDataList.Text = "Lista wczytanych plików:\n";
                    foreach(string str in fileNameList)
                        tDataList.Text += $"{str}\n";
                    break;
                case 2: // Path List
                    tDataList.Text = "Lista wczytanych ścieżek:\n";
                    foreach (string str in filePathList)
                        tDataList.Text += $"{str}\n";
                    break;
                case 3: // Group List
                    tDataList.Text = "Lista wczytanych Grup:\n";
                    Group[] groups = Data.referenceSchedule.GetGroups();
                    Array.Sort(groups, (a1, a2) => a1.name.CompareTo(a2.name));
                    foreach (Group group in groups)
                    {
                        tDataList.Text += group.name + "\n";
                    }
                    break;
                case 4: // Professor List
                    tDataList.Text = "Lista wczytanych Profesorów:\n";
                    Professor[] professors = Data.referenceSchedule.GetProfessors();
                    Array.Sort(professors, (a1, a2) => a1.name.CompareTo(a2.name));
                    foreach (Professor professor in professors)
                    {
                        tDataList.Text += professor.name + "\n";
                    }
                    break;
            }
        } //Sets displayed textList to correct List

        public void Step()
        {
            progressBar.PerformStep();
        }

        public void ProgressVisible(bool set)
        {
            progressBar.Visible = set;
        }

        public void ProgressSetText(string text)
        {
            progressBar.CustomText = text;
        }

        public void ProgressMax(int max)
        {
            progressBar.Maximum = max;
            progressBar.Value = 0;
        }
        #endregion
        //------------------------------END OF REGION------------------------------//
    }//END OF MAIN MENU
}

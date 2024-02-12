using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planista
{
    public partial class ScheduleWindow : Form
    {
        #region Variables
        private List<Button> buttons;
        private Schedule loadedSchedule;
        private Group[] groups;
        private Professor[] professors;
        private int selectedGroup = 0; // -1 means that Professor schedule is showing, other numbers define shown groups schedule
        private int selectedProfessor = -1; //-1 means that Group Schedule is showing, other numbers define shown professors schedule
        #endregion
        //------------------------------END OF REGION------------------------------//
        #region On start
        public ScheduleWindow(Schedule schedule)
        {
            loadedSchedule = schedule;
            groups = loadedSchedule.GetGroups();
            professors = loadedSchedule.GetProfessors();
            Array.Sort(professors,(a1,a2) => a1.name.CompareTo(a2.name));
            Array.Sort(groups, (a1, a2) => a1.name.CompareTo(a2.name));
            buttons = new List<Button>();
            InitializeComponent(); 
            this.Location = new Point((Screen.GetBounds(this).Width-1018)/2, 0);
            this.Width = 1218;
            this.Height = 50 * (ConditionsData.lastHour + 3 - ConditionsData.firstHour)+8;
        } //Filling all variables (loaded Schedule, groups, proffesors) on load
        private void ScheduleWindow_Load(object sender, EventArgs e)
        {
            for (int d = 0; d < 6; ++d) for (int h = 0; h < ConditionsData.lastHour + 2 - ConditionsData.firstHour; ++h)
                {
                    AddButton(d, h);
                }
            AddFunctionButtons();
            LoadSchedule();
        } //Adding all buttons from next functions on load
        private void AddButton(int d, int h)
        {
            Button button = new Button();
            this.Controls.Add(button);
            button.Height = 50;
            button.Width = 200;
            button.Left = d*200+1;
            button.Top = (h+1)*48+1;
            button.Name = $"{d},{ConditionsData.firstHour+h-1}";
            buttons.Add(button);
            button.Click += new System.EventHandler(Button_click);
        } //Adding Schedule elements buttons
        private void AddFunctionButtons()
        {
            Button button = new Button();
            this.Controls.Add(button);
            buttons.Add(button);
            button.Height = 50;
            button.Width = 300;
            button.Left = 0;
            button.Top = 0;
            button.Name = "BPrev";
            button.Font = new Font(button.Font.FontFamily, 20);
            button.Click += new System.EventHandler(Previous_Click);

            button = new Button();
            this.Controls.Add(button);
            buttons.Add(button);
            button.Height = 50;
            button.Width = 300;
            button.Left = 901;
            button.Name = "BNext";
            button.Font = new Font(button.Font.FontFamily, 20);
            button.Click += new System.EventHandler(Next_Click);

            button = new Button();
            buttons.Add(button);
            this.Controls.Add(button);
            button.Height = 50;
            button.Width = 400;
            button.Left = 401;
            button.Top = 0;
            button.Name = "BChange";
            button.Font = new Font(button.Font.FontFamily, 20);
            button.Click += new System.EventHandler(Change_Click);

            button = new Button();
            buttons.Add(button);
            this.Controls.Add(button);
            button.Font = new Font(button.Font.FontFamily, 20);
            button.Height = 50;
            button.Width = 100;
            button.Left = 301;
            button.Top = 0;
            button.Name = "BScore";


            button = new Button();
            buttons.Add(button);
            this.Controls.Add(button);
            button.Font = new Font(button.Font.FontFamily, 20);
            button.Height = 50;
            button.Width = 100;
            button.Left = 801;
            button.Top = 0;
            button.Name = "BValid";
        } //Adding function buttons (Prev, Next, Change, Score)
        #endregion
        //------------------------------END OF REGION------------------------------//
        #region Button Events
        private void Previous_Click(object sender, EventArgs e)
        {
            if (selectedGroup == -1)
            {
                selectedProfessor -= 1;
                if (selectedProfessor < 0) selectedProfessor = professors.Length-1;
            }
            else
            {
                selectedGroup -= 1;
                if (selectedGroup < 0) selectedGroup = groups.Length-1;
            }
            LoadSchedule();
        } //Button changing current schedule to the previous group/professor
        private void Next_Click(object sender, EventArgs e)
        {
            if (selectedGroup == -1)
            {
                selectedProfessor += 1;
                if (selectedProfessor >= professors.Length) selectedProfessor = 0;
            }
            else
            {
                selectedGroup += 1;
                if (selectedGroup >= groups.Length) selectedGroup = 0;
            }
            LoadSchedule();
        } //Button changing current schedule to the next group/professor
        private void Change_Click(object sender, EventArgs e)
        {
            if (selectedGroup == -1)
            {
                selectedGroup = 0;
                selectedProfessor = -1;
            }
            else
            {
                selectedGroup = -1;
                selectedProfessor = 0;
            }
            LoadSchedule();
        } //Button changing between groups and professors schedule
        private void Button_click(object sender, EventArgs e)
        {

        } //Clicking button with Schedule element
        #endregion
        //------------------------------END OF REGION------------------------------//
        #region Button text functions
        private void LoadSchedule()
        {
            ResetButtons();
            foreach (SchElement element in loadedSchedule.GetAll())
            {
                if(selectedGroup!=-1 && element.group == groups[selectedGroup])
                {
                    Controls[$"{element.day},{element.hour}"].Text = $"{element.subject}\nsala: \nprow: {element.professor}";
                }
                else if(selectedProfessor!=-1 && element.professor == professors[selectedProfessor]){
                    Controls[$"{element.day},{element.hour}"].Text = $"{element.subject}\ngrupa: {element.group}\nsala: ";
                }
            }
        } //Function calling ResetButtons and setting correct text to schedule element buttons
        private void ResetButtons()
        {
            foreach(Button button in buttons)
            {
                button.Text = "";
                if (button.Name[0] =='0')
                {
                    button.Font = new System.Drawing.Font("Verdana", 20f, FontStyle.Bold);
                    button.BackColor = Color.Gray;
                    if (button.Name.Length > 3) button.Text = $"{button.Name[2]}{button.Name[3]}:{Data.hourStartsAt}";
                    else
                    {
                        if (int.Parse($"{button.Name[2]}") != ConditionsData.firstHour - 1)
                            button.Text = $"{button.Name[2]}:{Data.hourStartsAt}";
                    }
                } else if (button.Name[2] == $"{ConditionsData.firstHour - 1}"[0])
                {
                    button.Font = new System.Drawing.Font("Verdana", 16f, FontStyle.Bold);
                    button.BackColor = Color.Gray;
                    switch (button.Name[0])
                    {
                        case '1':
                            button.Text = "Poniedziałek";
                            break;
                        case '2':
                            button.Text = "Wtorek";
                            break;
                        case '3':
                            button.Text = "Środa";
                            break;
                        case '4':
                            button.Text = "Czwartek";
                            break;
                        case '5':
                            button.Text = "Piątek";
                            break;
                    }
                }
            }
            Controls["BScore"].Text = $"{Data.scorer.GetScore(loadedSchedule).Item1}";
            Controls["BValid"].Text = $"{Data.scorer.GetScore(loadedSchedule).Item2}";
            Controls["BNext"].Text = "Następny";
            Controls["BPrev"].Text = "Poprzedni";
            if(selectedProfessor==-1)Controls["BChange"].Text = $"Grupa: {groups[selectedGroup]}";
            else Controls["BChange"].Text = $"Prowadzący: {professors[selectedProfessor]}";
        } //Function reseting button texts to correct ones (Schedule element buttons are set to empty)
        #endregion
        //------------------------------END OF REGION------------------------------//
    }//END OF SCHEDULE WINDOW
}

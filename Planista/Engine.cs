using Planista.Forms;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Planista
{
    public static class Engine
    {
        public static void LoadClasses()
        {
            Data.scorer = new ScheduleScorer(); //Class allowing to count score of each schedule
            Data.mixer = new ScheduleMixer(); //Class that purpose is to mix and generate new schedules
            Data.settings = new SettingsWindow();
        } //Loads classes.Necessery function must always be between SetCompatibleTextRendereing and Run in main function. 

        #region Scheduler functions
        public static Schedule GenerateNewSchedule(short variant)
        {
            if(variant==0 || variant ==1)
                return AssignHours();
            if (variant == 2)
                return  AssignHoursTwo();
            if (variant == 3)
                return AssignHoursThree();
            return null;
        }
        private static Schedule AssignHours()
        {
            List<SchElement> array = new List<SchElement>();
            foreach (SchElement e in Data.referenceSchedule.GetAll())
            {
                array.Add(new SchElement(e.day, e.hour, e.group, e.subject, e.professor, e.ID));
            }
            array = MixArray(array); //Adding randomness
            bool isScheduleRandom = Data.r.Next(0, 6) == 1;
            foreach(SchElement element in array)
            {
                short startHour = ConditionsData.firstHour;
                if (ConditionsData.bestFirstHourStudentB && Data.r.Next(0, 5) != 0) startHour = ConditionsData.bestFirstHour;
                //// ASSIGN FUNCTION 
                if (element.day == -1)
                {
                    if (isScheduleRandom && Data.r.Next(0, 11) == 0)//Generating schedule randomly
                    {
                        while (true) {
                            short d = (short)Data.r.Next(1, 6);
                            short h = (short)Data.r.Next(ConditionsData.firstHour, ConditionsData.lastHour + 1);
                            if (!Array.Exists(array.ToArray(), ele => ele.day == d && ele.hour == h && ele.group == element.group) && !Array.Exists(array.ToArray(), ele => ele.day == d && ele.hour == h && ele.professor == element.professor))
                            {
                                element.day = d;
                                element.hour = h;
                                h = (short)(ConditionsData.lastHour + 1); ;
                                break;
                            }
                        }
                    }
                    else //Generating Schedule based on hours
                        for (short h = startHour; h <= ConditionsData.lastHour; ++h)
                        {
                            for (short d = 1; d <= 5; ++d)
                            {
                                if (!Array.Exists(array.ToArray(), ele => ele.day == d && ele.hour == h && ele.group == element.group) && !Array.Exists(array.ToArray(), ele => ele.day == d && ele.hour == h && ele.professor == element.professor))
                                {
                                    element.day = d;
                                    element.hour = h;
                                    h = (short)(ConditionsData.lastHour + 1); ;
                                    break;
                                }
                            }
                        }
                    if(element.day ==-1)
                    {
                        element.day = 1;
                        element.hour = (short)(ConditionsData.firstHour + 1);
                        MessageBox.Show("Występuje błędnie wstawiony SchElement");
                    }
                }
                //// ASSIGN FUNCTION
            }
            Schedule newSchedule = new Schedule();
            foreach (SchElement element in array) newSchedule.AddNew(element);
            return newSchedule;
        }//Generates schedule from reference Schedule

        private static Schedule AssignHoursTwo()
        {
            Schedule newSchedule = new Schedule();
            foreach (SchElement e in Data.referenceSchedule.GetAll())
            {
                newSchedule.AddNew(e);
            }
            foreach (SchElement e in newSchedule.GetAll())
            {
                while (true) {
                    short d = (short)Data.r.Next(1, 6);
                    short h = (short)Data.r.Next(ConditionsData.firstHour, ConditionsData.lastHour + 1);
                    e.day = d;
                    e.hour = h;
                    if (newSchedule.IsPossible(e)) break;
                }
            }
            foreach (SchElement element in Data.referenceSchedule.GetAll())
            {
                Console.WriteLine(newSchedule.GetAll().Where(ele => ele.group == element.group && ele.professor == element.professor).ToArray()[0]);
            }
            return newSchedule;
        }


        private static Schedule AssignHoursThree()
        {
            Schedule newSchedule = new Schedule();
            foreach (SchElement e in Data.referenceSchedule.GetAll())
            {
                newSchedule.AddNew(e);
            }
            foreach (SchElement e in newSchedule.GetAll())
            {
                while (true)
                {
                    short d = (short)Data.r.Next(1, 6);
                    short h = (short)Data.r.Next(ConditionsData.firstHour, (ConditionsData.lastHour-ConditionsData.firstHour) / 3 + ConditionsData.firstHour);
                    e.day = d;
                    e.hour = h;
                    if (newSchedule.IsPossible(e)) break;
                    d = (short)Data.r.Next(1, 6);
                    h = (short)Data.r.Next(ConditionsData.firstHour, (ConditionsData.lastHour - ConditionsData.firstHour) / 2 + ConditionsData.firstHour);
                    e.day = d;
                    e.hour = h;
                    if (newSchedule.IsPossible(e)) break;
                    d = (short)Data.r.Next(1, 6);
                    h = (short)Data.r.Next(ConditionsData.firstHour, ConditionsData.lastHour + 1);
                    e.day = d;
                    e.hour = h;
                    if (newSchedule.IsPossible(e)) break;
                }
            }
            foreach (SchElement element in Data.referenceSchedule.GetAll())
            {
                Console.WriteLine(newSchedule.GetAll().Where(ele => ele.group == element.group && ele.professor == element.professor).ToArray()[0]);
            }
            return newSchedule;
        }



        public static List<SchElement> MixArray(List<SchElement> array)
        {
            for(int i = 0; i < array.Count*100; ++i)
            {
                int temp = Data.r.Next();
                SchElement help = array[i%array.Count];
                array[i % array.Count] = array[temp % array.Count];
                array[temp % array.Count] = help;
            }
            return array;
        }//Mixes array to generate schedules randomly 
        #endregion
        //------------------------------END OF REGION------------------------------//
        #region  Auxiliary functions
        public static string insertedTextToInt(string text, ref short previous)
        {
            if (short.TryParse(text, out short n)) previous = n;
            else
            {
                if (text != "") text = $"{previous}";
            }
            return text;
        } //Changes insterted string to Int, always keeps the "previous" tekst as int or ""
        public static string insertedTextToInt(string text, ref short previous, short upperLimit)
        {
            if (short.TryParse(text, out short n) && n <= upperLimit) previous = n;
            else
            {
                if (text != "") text = $"{previous}";
            }
            return text;
        } //Same as insertedTextToInt but output cannot be higher thean upper limit
        public static string insertedTextToInt(string text, ref short previous, short lowerLimit, short upperLimit)
        {
            if (short.TryParse(text, out short n) && n <= upperLimit && n >= lowerLimit) previous = n;
            else
            {
                if (text != "") text = $"{previous}";
            }
            return text;
        } //Same as insertedTextToInt but output must be between lowerlimit and upperlimit 
        #endregion
        //------------------------------END OF REGION------------------------------//
        #region Operating on files
        public static void ReadTextFile(string fileName)
        {
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        InsertData(line);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Error reading the file: " + e.Message);
            }
        } //Reads data from file and inserts it into reference variables (Data->Variables storing schedule reference data)
        private static void InsertData(String line)
        {
            string groupName;
            string subjectName;
            string professorName;
            int howManyHours = 0;
            string[] lineSplit = line.Split(' ');
            if (lineSplit.Length > 2)
            {
                //Split line into required data
                groupName = lineSplit[0];
                subjectName = lineSplit[1];
                professorName = lineSplit[2];
                if (lineSplit.Length == 4) howManyHours = int.Parse(lineSplit[3]);
                else howManyHours = 1;
                //Insert data into reference storing variables
                if (Group.Get(groupName) == null) Group.Add(groupName);
                if (Subject.Get(subjectName) == null) Subject.Add(subjectName);
                if (Professor.Get(professorName) == null) Professor.Add(professorName);
                for (int i = 0; i < howManyHours; i++)
                    Data.referenceSchedule.AddNew(Group.Get(groupName), Subject.Get(subjectName), Professor.Get(professorName));

            }

        } //inserts data into reference variables (Data->Variables storing schedule reference data)
        public static string SelectFile()
        {
            string filePath="";
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (Data.lastPath == "") openFileDialog.InitialDirectory = Data.desktopPath;
                else openFileDialog.InitialDirectory = Data.lastPath;
                openFileDialog.Filter = "txt files (*.txt)|*.txt";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    Data.lastPath = Path.GetDirectoryName(filePath);
                }
                else
                {
                    if (filePath != "") MessageBox.Show($"Error accessing the file at path:\n\"{filePath}\"");
                }
            }
            return filePath;
        } //Opens windows and allows user to select correct file
        #endregion
        //------------------------------END OF REGION------------------------------//



    } //END OF ENGINE
}
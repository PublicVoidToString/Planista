using Planista.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planista
{
    public class Data
    {
        #region Nonchangeable by user variables
        public static short firstGeneraionVersion = 3; //Algorithm used for generating first generation (0,1 - First possible hour, 1 - Random, 2 - Random but trying to fit in 1/2 -> 1/3 -> 1/1 of the day)
        public static short version = 2; //Version of the algorithm (1 - Basic, 2 - Upgraded)
        public static string lastPath = ""; //Stores the last path selected by user
        public static string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); //Stores the path to desktop
        public static bool saveIter = true; //Should the results of each iteration be saved in a file
        // Basic classes allowing to use their functions, in future instead of static function it might be added to each schedule for added functionality
        //Each class is defined at beginning of the program by Engine.AddClasses();
        public static ScheduleScorer scorer; //Class allowing to count score of each schedule
        public static ScheduleMixer mixer; //Class that purpose is to mix and generate new schedules
        public static SettingsWindow settings;
        public static MainMenu menu;
        // ScheduleMixer geneticScheduleMaker = new ScheduleMixer(); //Propably not used
        // End of Basic classes

        public static Random r = new Random(); //Random variable for whole program to use only one seed
        #endregion
        //------------------------------END OF REGION------------------------------//
        #region Changeable by user variables
        public static int schedulesCount = 100; //Variable that defines amount of objects per generation
        public static int generationsCount = 100; //Variable that defines amount of objects per generation
        public static int safetyTimerInSec = 3600; //if loading time exceed this value best schedule will be chosen
        public static string hourStartsAt = "00";
        public static short mutationChance = 20; //chance of mutation
        public static short crossoverChance = 90; //chance of crossover
        public static short minBestSchedules = 10; //minimum required amount of schedules taken into next generation
        public static short maxBestSchedules = 30; //maximum possible amount of schedules taken into next generation
        #endregion
        //------------------------------END OF REGION------------------------------//
        #region Variables storing schedule reference data
        public static Group groupList; //list of all existing groups
        public static Subject subjectList; //List of all existing subjects
        public static Professor professorList; //List of all existing professors
        public static Schedule referenceSchedule = new Schedule(); //Reference schedule used for making new schedules (data nad hour are set to -1)
        #endregion
        //------------------------------END OF REGION------------------------------//

    }//END OF DATA
}

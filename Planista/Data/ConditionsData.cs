using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planista
{
    public static class ConditionsData
    {
        #region ON/OFF booleans
        public static bool noBreakProfessorB=true;
        public static bool noBreakStudentB = true;
        public static bool continuityB = true;
        public static bool hourLimitB = true;
        public static bool bestFirstHourStudentB = true;
        public static bool bestFirstHourProfessorB = true;
        #endregion
        //------------------------------END OF REGION------------------------------//
        #region Points
        public static short[] NoBreaksProfessorPoints = { 1000, 1000, 1000, 950, 800, 650, 400, 250, 100, 50, 0 };//Points depending on amount of professor breaks starting from 0, last if more than 10
        public static short[] NoBreaksStudentPoints = { 600, 550, 500, 400, 300, 200, 150, 100, 50, 0, 0 }; //Points depending on amount of student breaks starting from 0, last if more than ten
        public static short[] subjectContinuityPoints = { 100, 200, 0, -50, -100, -30 }; //Points for how many times each subject occurs continuously for one group, last if more than five and then returns (number)*(last) points
        public static short[] hourLimitPoints = { 0, 100, 200, 300, 400, 500 }; //Points for how many times hour limit per day is not surpassed
        public static short[,] bestFirstHourPoints = { { 0, 25, 50, 70, 90, 105 }, { 0, 30, 60, 90, 110, 125 } }; //[0,x] - student, [1,x] - professor
        #endregion
        //------------------------------END OF REGION------------------------------//
        #region Changeable by user variables
        public static short firstHour = 7;//Firsy possible hour to set;
        public static short lastHour = 20;//Last possible hour to set
        public static short bestFirstHour = 8; //If first Lesson starts in this hour extra points will be added
        public static short hourLimit = 8; //Daily hour limit for professor, extra points if not surpassed
        #endregion
        //------------------------------END OF REGION------------------------------//
    }//END OF CONDITIONSDATA
}

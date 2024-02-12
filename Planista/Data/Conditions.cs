using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Planista
{
    #region Scorers
    public class NoBreaksStudent : IScheduleScorer
    {
        public int score(Schedule schedule)
        {
            if (!ConditionsData.noBreakStudentB) return 0;
            int points = 0;
            foreach (Group group in schedule.GetGroups())
            {
                short emptyHours = 0;
                (short day, short hour)[] Time = schedule.GetGroupDaysHours(group);
                short[] start = { 25, 25, 25, 25, 25 };
                short[] end = { 0, 0, 0, 0, 0 };
                short hours = 0;
                foreach ((short d, short h) T in Time)
                {
                    if (T.h > end[T.d - 1]) end[T.d - 1] = T.h;
                    if (T.h < start[T.d - 1]) start[T.d - 1] = T.h;
                    hours += 1;
                }
                for (short i = 0; i < 5; ++i) if (start[i] != 25)
                    {
                        hours -= (short)(end[i] + 1 - start[i]);
                    }
                emptyHours -= hours;
                if (emptyHours > 10) points += ConditionsData.NoBreaksStudentPoints[10];
                else points += ConditionsData.NoBreaksStudentPoints[emptyHours];
            }
            return points;
        }

        public bool allowed(Schedule schedule) { return true; }
    }
    public class NoBreaksProfessor : IScheduleScorer
    {
        public int score(Schedule schedule)
        {
            if (!ConditionsData.noBreakProfessorB) return 0;
            int points = 0;
            foreach (Professor prof in schedule.GetProfessors())
            {
                short emptyHours = 0;
                (short day, short hour)[] Time = schedule.GetProfessorDaysHours(prof);
                short[] start = { 25, 25, 25, 25, 25 };
                short[] end = { 0, 0, 0, 0, 0 };
                short hours = 0;
                foreach ((short d, short h) T in Time)
                {
                    //PROBLEM MOŻE NIE PRZYPISAĆ WARTOŚCI JAK NIE MA MIEJSCA, WSTAWIĆ WTEDY LOSOWO :D
                    if (T.h > end[T.d - 1]) end[T.d - 1] = T.h;
                    if (T.h < start[T.d - 1]) start[T.d - 1] = T.h;
                    hours += 1;
                }
                for (short i = 0; i < 5; ++i) if (start[i] != 25)
                    {
                        hours -= (short)(end[i] + 1 - start[i]);
                    }
                emptyHours -= hours;
                if (emptyHours > 10) points+= ConditionsData.NoBreaksProfessorPoints[10];
                else points+=ConditionsData.NoBreaksProfessorPoints[emptyHours];
            }
            return points;
        }

        public bool allowed(Schedule schedule) { return true; }

    }
    public class OptimalStartStudent : IScheduleScorer
    { 
        public int score(Schedule schedule)
        {
            if (!ConditionsData.bestFirstHourStudentB) return 0;
            int points=0;
            foreach(Group group in schedule.GetGroups())
            {
                (short day, short hour)[] Time = schedule.GetGroupDaysHours(group);
                short[] start = { 25, 25, 25, 25, 25 };
                foreach ((short d, short h) T in Time)
                {
                    if (T.h < start[T.d - 1]) start[T.d - 1] = T.h;
                }
                int count = 0;
                for(int i = 0; i < 5; ++i)
                {
                    if (ConditionsData.bestFirstHour == start[i]) count += 1;
                }
                points += ConditionsData.bestFirstHourPoints[0,count];
            }
            return points;
        }

        public bool allowed(Schedule schedule) { return true; }
    }
    public class OptimalStartProfessor : IScheduleScorer
    {
        public int score(Schedule schedule)
        {
            if (!ConditionsData.bestFirstHourProfessorB) return 0;
            int points = 0;
            foreach (Professor prof in schedule.GetProfessors())
            {
                (short day, short hour)[] Time = schedule.GetProfessorDaysHours(prof);
                short[] start = { 25, 25, 25, 25, 25 };
                foreach ((short d, short h) T in Time)
                {
                    if (T.h < start[T.d - 1]) start[T.d - 1] = T.h;
                }
                int count = 0;
                for (int i = 0; i < 5; ++i)
                {
                    if (ConditionsData.bestFirstHour == start[i]) count += 1;
                }
                points += ConditionsData.bestFirstHourPoints[1, count];
            }
            return points;
        }

        public bool allowed(Schedule schedule) { return true; }
    }
    public class DailyHourLimitProfessor : IScheduleScorer
    {
        public int score(Schedule schedule)
        {
            if (!ConditionsData.hourLimitB) return 0;
            int points = 0;
            foreach (Professor prof in schedule.GetProfessors())
            {
                short hours = 0;
                (short day, short hour)[] Time = schedule.GetProfessorDaysHours(prof);
                short[] start = { 25, 25, 25, 25, 25 };
                short[] end = { 0, 0, 0, 0, 0 };
                foreach ((short d, short h) T in Time)
                {
                    if (T.h > end[T.d - 1]) end[T.d - 1] = T.h;
                    if (T.h < start[T.d - 1]) start[T.d - 1] = T.h;
                }
                for(int i = 0; i < 5; ++i)
                {
                    if (end[i] + 1 - start[i] <= ConditionsData.hourLimit) hours += 1;
                }
                points += ConditionsData.hourLimitPoints[hours];
            }
            return points;
        }

        public bool allowed(Schedule schedule) { return true;  }
    }
    public class ContinuousSubject : IScheduleScorer
    {
        public int score(Schedule schedule)
        {
            if (!ConditionsData.continuityB) return 0;
            //wziąć każdą grupę 
            // Wziąc każde zajęcia dla niej (nazwę)
            // Dla każdych zajęć wziąść każdą godzinę
            //Sprawdzić czy godziny występują pod rząd
            return 0;
        }
        public bool allowed(Schedule schedule){ return true; }

    }
    #endregion
    //------------------------------END OF REGION------------------------------//
    #region Requirements
    public class OneAtTimeStudent : IScheduleScorer
    {
        public int score(Schedule schedule) { return 0; }
        public bool allowed(Schedule schedule)
        {

            foreach (Group group in schedule.GetGroups())
            {
                foreach ((short d, short h) T in schedule.GetGroupDaysHours(group))
                {
                    if (schedule.GetGroupSchedule(group, T.d, T.h).Length > 1) return false;
                }
            }
            return true;
        }
    }
    public class OneAtTimeProfessor : IScheduleScorer
    {
        public int score(Schedule schedule) { return 0; }

        public bool allowed(Schedule schedule)
        {
            foreach(Professor prof in schedule.GetProfessors())
            {
                foreach((short d, short h)T in schedule.GetProfessorDaysHours(prof))
                {
                    if (schedule.GetProfessorSchedule(prof, T.d, T.h).Length > 1) return false;
                }
            }
            return true;
        }
    }
    public class CorrectHours : IScheduleScorer
    {
        public int score(Schedule schedule) { return 0; }

        public bool allowed(Schedule schedule)
        {

            foreach (Group grp in schedule.GetGroups())
            {
                foreach ((short d, short h) T in schedule.GetGroupDaysHours(grp))
                {
                    if (!(T.h >= ConditionsData.firstHour && T.h <= ConditionsData.lastHour)) { return false; }
                }
            }

            return true;
        }
    }
    #endregion
    //------------------------------END OF REGION------------------------------//

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Planista.Generator
{
    public static class Mutation
    {

        //DODAĆ ŻE OKIENKO NIE PIERWSZE JEST WYBIERANE ALE LOSOWO
        public static Schedule Basic(Schedule schedule) //Mutates schedule at random
        {
            if (Data.version == 1) return TotallyRandom(schedule);
            switch (Data.r.Next(0, 2))
            {
                case 0:
                    return TotallyRandom(schedule);
                case 1:
                    return FixLast(schedule);
                case 2:
                    return FillWindow(schedule);

            }
            return schedule;
        }

        private static Schedule TotallyRandom(Schedule schedule) //Mutates schedule at random
        {
            foreach (SchElement element in schedule.GetAll())
            {
                if (Data.r.Next(0, 101) < Data.mutationChance)
                {
                    short day = (short)Data.r.Next(1, 6);
                    short hour = (short)Data.r.Next(ConditionsData.firstHour, ConditionsData.lastHour + 1);
                    if (schedule.GetProfessorSchedule(element.professor, day, hour).ToArray().Length == 0)
                        if (schedule.GetGroupSchedule(element.group, day, hour).ToArray().Length == 0)
                        {
                            element.day = day;
                            element.hour = hour;
                        }
                }
            }
            return schedule;
        }

        private static Schedule FixLast(Schedule schedule)
        {

            SchElement[] worst = schedule.GetWorstHour();
            foreach (SchElement ele in worst)
            {
                short d = ele.day;
                short h = ele.hour;
                for (int i = 0; i < 5; ++i)
                {
                    ele.day = (short)Data.r.Next(1, 6);
                    if(ele.hour!=ConditionsData.firstHour)ele.hour = (short)Data.r.Next(ConditionsData.firstHour, ele.hour);
                    if (!schedule.IsPossible(ele))
                    {
                        ele.day = d;
                        ele.hour = h;
                        break;
                    }
                }
            }
            return schedule;
        }

        private static Schedule FillWindow(Schedule schedule)
        {
            Professor selProf = schedule.GetProfessors()[Data.r.Next(0,schedule.GetProfessors().Length)];
            (short d, short h) window= (0,0);
            SchElement[] first = new SchElement[6];
            SchElement[] last = new SchElement[6];
            foreach (SchElement ele in schedule.GetAll().Where(ele=>ele.professor == selProf))
            {
                if (first[ele.day] == null || ele.hour < first[ele.day].hour) first[ele.day] = ele;
                if (last[ele.day] == null || ele.hour > last[ele.day].hour) last[ele.day] = ele;
            }
            foreach (SchElement ele in schedule.GetAll())
            {
                if (first[ele.day] == ele || last[ele.day] == ele) continue;
                if (schedule.GetAll().Where(searched => searched.hour == ele.hour - 1 && ele.day == searched.day && searched.professor == selProf) == null)
                {
                    if (Data.r.Next(0, 3) == 0)
                    {
                        window = (ele.day, (short)(ele.hour - 1));
                        break;
                    }
                }
                if (schedule.GetAll().Where(searched => searched.hour == ele.hour + 1 && ele.day == searched.day && searched.professor == selProf) == null)
                {
                    if (Data.r.Next(0, 2) == 0)
                    {
                        window = (ele.day, (short)(ele.hour - 1));
                        break;
                    }
                }
            }
            if (window.d == 0) return schedule;

            for(int i = 1; i < 6; ++i)
            {
                short d = first[i].day;
                short h = first[i].hour;
                first[i].day = window.d;
                first[i].hour = window.h;
                if (schedule.IsPossible(first[i])) return schedule;
                first[i].day = d;
                first[i].hour = h;
                d = last[i].day;
                h = last[i].hour;
                last[i].day = window.d;
                last[i].hour = window.h;
                if (schedule.IsPossible(first[i])) return schedule;
                last[i].day = d;
                last[i].hour = h;

            }


            return schedule;
        }


    }
}

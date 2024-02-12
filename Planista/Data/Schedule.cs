using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization.Configuration;

namespace Planista
{
    public class Schedule
    {
        private List<SchElement> elements;
        public int score;
        public Schedule()
        {
            elements = new List<SchElement>();
        }
        public Schedule(Schedule previous)
        {
            elements = new List<SchElement>();
            foreach(SchElement ele in previous.GetAll())
            {
                AddNew(ele);
            }
        }

        #region Schedule functions 
        public void AddNew(SchElement e)
        {
            SchElement element= new SchElement(e.day,e.hour,e.group,e.subject,e.professor,e.ID);
            elements.Add(element);
        } //Makes new SchElement and adds it to the list (saver version)
        public void AddNew(Group gro, Subject subj, Professor prof)
        {
            SchElement elem = new SchElement(-1, -1, gro, subj, prof);
            elements.Add(elem);
        } //Adds new SchElements with Day and Hours set to -1 to list

        public bool CorrectHours()
        {
            if (elements.Where(ele => ele.day == -1 || ele.hour == -1).ToArray().Length > 0) return false;
            return true;
        }

        #endregion
        //------------------------------END OF REGION------------------------------//
        #region SchElement focused functions
        public SchElement[] GetAll()
        {
            return elements.ToArray();
        } //Return all SchElements

        public SchElement GetByID(int ID)
        {
            return elements.Where(element => element.ID == ID).ToArray()[0];
        }
        public (short, short)[] GetDaysHours()
        {
            return elements.Select(element => (element.day, element.hour)).Distinct().ToArray();
        } //Return on (day,hour) combinations

        public bool IsPossible(SchElement e)
        {
            if (elements.Where(element => (element.professor == e.professor || element.group == e.group) && element.hour == e.hour && element.day == e.day).Count() > 1)
            {
                Console.WriteLine(elements.Where(element => (element.professor == e.professor || element.group == e.group) && element.hour == e.hour && element.day == e.day).Count());
                return false;
            }
            return true;
        }

        public void Print()
        {
            foreach(SchElement e in elements)
            {
                Console.WriteLine($"{e.professor} {e.group} {e.hour} {e.day}");
            }
        }

        #endregion
        //------------------------------END OF REGION------------------------------//
        #region Group focused functions
        public Group[] GetGroups()
        {
            return elements.Select(element => element.group).Distinct().ToArray();
        }
        public Group[] GetGroupByDayHour((short d, short h) date)
        {
            return elements.Where(element => element.day == date.d && element.hour == date.h).Select(element => element.group).ToArray();
        } //Return list of Groups based on Day and Hour (REDUNDANT)
        public SchElement[] GetGroupSchedule(Group searched)
        {
            return elements.Where(element => element.group == searched).ToArray();
        } //Return list of SchElements connected to searched Group
        public SchElement[] GetGroupSchedule(Group searched, short d, short h)
        {
            return elements.Where(element => element.group == searched && element.day ==d && element.hour==h).ToArray();
        } //Return list of SchElements connected to searched Group
        public (short, short)[] GetGroupDaysHours(Group searched)
        {
            return elements.Where(element => element.group == searched).Select(element => (element.day, element.hour)).Distinct().ToArray();
        }

        #endregion
        //------------------------------END OF REGION------------------------------//
        #region Professor focused functions
        public Professor[] GetProfessors()
        {
            return elements.Select(element => element.professor).Distinct().ToArray();
        }
        public Professor[] GetProfessorByDayHour((short d, short h) date)
        {
            return elements.Where(element => element.day == date.d && element.hour == date.h).Select(element => element.professor).ToArray();
            //return elements.Where(element => element.day == date.d && element.hour == date.h).ToArray();
        } //Return list of professors based on Day and Hour (REDUNDANT)
        public SchElement[] GetProfessorSchedule(Professor searched)
        {
            return elements.Where(element => element.professor == searched).ToArray();
        } //Return list of SchElements connected to searched Professor
        public SchElement[] GetProfessorSchedule(Professor searched, short d, short h)
        {
            return elements.Where(element => element.professor == searched && element.day==d && element.hour==h).ToArray();
        } //Return list of SchElements connected to searched Professor, method overload, return schedule based on day and hour
        public (short, short)[] GetProfessorDaysHours(Professor searched)
        {
            return elements.Where(element => element.professor == searched).Select(element => (element.day, element.hour)).Distinct().ToArray();
        }

        #endregion
        //------------------------------END OF REGION------------------------------//

        public SchElement[] GetWorstHour()
        {
            SchElement[] element = elements.Where(ele => ele.hour == elements.Max(elem => elem.hour)).ToArray();
            return element;
        }


    }//END OF SCHEDULE
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planista
{
    public class Subject
    {
        public string name;
        public Subject next;
        public Subject(String newName)
        {
            name = newName;
        }
        public override String ToString()
        {
            return name;
        }
        public static void Add(string n)
        {
            if (Data.subjectList == null) Data.subjectList = new Subject(n);
            else
            {
                Subject newSubject = Data.subjectList;
                while (newSubject.next != null)
                {
                    if (newSubject.name.ToLower() == n.ToLower()) return;
                    newSubject = newSubject.next;
                }
                newSubject.next = new Subject(n);
            }
            Console.WriteLine($"Added subject {n}");
        }//Adding new subject to Data.subjectList
        public static Subject Get(string who)
        {
            if (Data.subjectList == null)
            {
                Console.WriteLine("Subject not found");
                return null;
            }
            Subject result = Data.subjectList;
            while (!result.name.ToLower().Equals(who.ToLower()))
            {
                if (result.next == null)
                {
                    Console.WriteLine("Subject not found");
                    return null;
                }
                result = result.next;
            }
            return result;
        }//Getting subject by string from Data.subjectList (searched by name)
    }//END OF SUBJECT
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planista
{
    public class Professor
    {
        public string name;
        public Professor next;
        public Professor(String newName)
        {
            name = newName;
        }
        public override String ToString()
        {
            return name;
        }
        public static void Add(string n)
        {
            if (Data.professorList == null) Data.professorList = new Professor(n);
            else
            {
                Professor newProfessor = Data.professorList;
                while (newProfessor.next != null) newProfessor = newProfessor.next;
                newProfessor.next = new Professor(n);
            }
            Console.WriteLine($"Added professor {n}");
        }//Adding new professor to Data.professorList
        public static Professor Get(string who)
        {
            if (Data.professorList == null)
            {
                Console.WriteLine("Professor not found");
                return null;
            }
            Professor result = Data.professorList;
            while (!result.name.ToLower().Equals(who.ToLower()))
            {
                if (result.next == null)
                {
                    Console.WriteLine("Professor not found");
                    return null;
                }
                result = result.next;
            }
            return result;
        }//Getting proffesor by string from Data.professorList (searched by name)
    }//END OF PROFESSOR
}

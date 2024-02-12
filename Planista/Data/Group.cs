using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Planista
{
    public class Group
    {
        public string name;
        public Group next;
        public Group(String newName)
        {
            name = newName;
        }
        public override String ToString()
        {
            return name;
        }
        public static void Add(string n)
        {
            if (Data.groupList == null) Data.groupList = new Group(n);
            else
            {
                Group newGroup = Data.groupList;
                while (newGroup.next != null)
                {
                    if (newGroup.name.ToLower() == n.ToLower()) return;
                    newGroup = newGroup.next;
                }
                newGroup.next = new Group(n);
            }
            Console.WriteLine($"Added group {n}");
        } //Adding  new group to Data.GroupList
        public static Group Get(string who)
        {
            if (Data.groupList == null)
            {
                Console.WriteLine("Group not found");
                return null;
            }
            Group result = Data.groupList;
            while (!result.name.ToLower().Equals(who.ToLower()))
            {
                if (result.next == null)
                {
                    Console.WriteLine("Group not found");
                    return null;
                }
                result = result.next;
            }
            return result;
        } //Getting group by string from Data.GroupList (searched by name)

    } //END OF GROUP
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Planista
{
    public class SchElement
    {
        public short day;
        public short hour;
        public Group group;
        public Subject subject;
        public Professor professor;
        public int ID;
        
        public SchElement(short d, short h, Group g, Subject s, Professor p)
       {
            day = d;
            hour = h;
            group = g;
            subject = s;
            professor = p;
        } //Add new Schedule element
        public SchElement(short d, short h, Group g, Subject s, Professor p, int ID)
        {
            day = d;
            hour = h;
            group = g;
            subject = s;
            professor = p;
        } //Add new Schedule element
        public SchElement(Group g, Subject s, Professor p)
        {
            group = g;
            subject = s;
            professor = p;
        } //Add new Schedule element, hour and day are set to -1(not assigned)
        public override String ToString()
        {
            if (hour == -1) return $"group: {group}, subject: {subject}, professor: {professor}";
            else return $"d: {day}, h: {hour}, group: {group}, subject: {subject}, professor: {professor}";
        } //In current format this function exists only for debug purposes 

        public void ChangeTime(SchElement ele)
        {
            day = ele.day;
            hour = ele.hour;
        }

    }//END OF SCHELEMENT
}

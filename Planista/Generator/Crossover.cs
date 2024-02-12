using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planista.Generator
{
    public static class Crossover
    {

        public static void ChooseAlgorithm(Schedule main, List<Schedule> pool)
        {
            if (Data.version == 1) Random(main, pool);
            else
            {
                switch (Data.r.Next(0, 3))
                {
                    case 0:
                        Random(main, pool);
                        break;
                    case 1:
                    case 2:
                        Worst(main, pool);
                        break;
                }
            }
        }


        private static void Random(Schedule main, List<Schedule> pool)
        {
            int index = Data.r.Next(0, pool.Count());
            Schedule[] chosen = { main, pool[index] };
            foreach (SchElement element in Data.referenceSchedule.GetAll())
            {
                if (Data.r.Next(0, 2) == 2) main.GetByID(element.ID).ChangeTime(chosen[1].GetByID(element.ID));
            }
        } //Total randomness

        private static void Worst(Schedule main, List<Schedule> pool)
        {
            int index = Data.r.Next(0, pool.Count());
            Schedule chosen = pool[index];
            SchElement[] worst = main.GetWorstHour();
            foreach (SchElement ele in worst)
            {
                short d = ele.day;
                short h = ele.hour;
                ele.ChangeTime(chosen.GetByID(ele.ID));
                if (!main.IsPossible(ele))
                {
                    ele.day = d;
                    ele.hour = h;
                }
            }
            //    if (Data.r.Next(0, 3) == 2) main.GetByID(element.ID).ChangeTime(chosen[2].GetByID(element.ID));
        } //Worst SchElements
    }
}

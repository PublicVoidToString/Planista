using Planista.Forms;
using Planista.Generator;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Planista
{
    public class ScheduleMixer
    {
        private List<Schedule> schedules;
        private ScheduleScorer scorer;
        private List<Schedule> pool = new List<Schedule>();
        private Schedule bestFromPrevious;

        public ScheduleMixer()
        {
            schedules = new List<Schedule>();
            scorer = new ScheduleScorer();
        }
        public Schedule Scheduler()
        {
            bestFromPrevious = null;
            schedules.Clear();// So program can be run more than once
            pool.Clear();
            GenerateFirstGeneration(Data.firstGeneraionVersion);//Making the First Generation of Schedules, number defines used algorithm, options below:
                                       //0,1 Insert each SchElement to first possible Hour,Day (Hour more important then day)
                                       //2 Insert each SchElement randomly (Requirements must be met)
                                       //3 Insert each SchElement randomly, but first try in 1/3 of all timetables, then 1/2 and then all of them

            Data.menu.ProgressMax(Data.generationsCount);
            Stopwatch sw = Stopwatch.StartNew();
            AlgoChart form = new AlgoChart();
            File output = new File();
            for (int temp = 0; temp < Data.generationsCount; temp++)//Iterations
            {
                form.AddMax(temp, GetBestSchedule().score);
                form.AddAvg(temp, GetAverage());
                if (Data.saveIter) output.Insert(GetAverage(),GetBestSchedule().score);
                pool.Clear();// So program can be run more than once
                FitnessFunction();
                schedules.Clear();
                GenerateNewSchedules(Data.schedulesCount-1);
                foreach (Schedule sch in schedules)
                {
                    if (Data.r.Next(0, 101) < Data.crossoverChance) Crossover.ChooseAlgorithm(sch, pool);
                    if (Data.r.Next(0, 101) < Data.mutationChance) Mutation.Basic(sch);
                }
                if(bestFromPrevious!=null)schedules.Add(bestFromPrevious); //So the best one is always saved
                if (sw.ElapsedMilliseconds / 1000 > Data.safetyTimerInSec)
                {
                    sw.Stop();
                    Console.WriteLine("Finished after: " + sw.ElapsedMilliseconds / 1000 + "s");//info about safety timer
                    Data.menu.ProgressVisible(false);
                    form.SetMax(GetBestSchedule().score);
                    form.Show();
                    return GetBestSchedule();
                }
                bestFromPrevious = GetBestSchedule();
                Data.menu.ProgressSetText($"Pkt najlepszego: {bestFromPrevious.score} | Średnia: {GetAverage()} | Czas: {sw.ElapsedMilliseconds/1000}s/{Data.safetyTimerInSec} | Progres");
                Data.menu.Step();

            } //End Of Iterations
             
            Console.WriteLine("Finished after: " + sw.ElapsedMilliseconds / 1000 + "s");
            if(Data.saveIter)output.PrintToFile();
            sw.Stop(); ;
            Data.menu.ProgressVisible(false);
            form.SetMax(GetBestSchedule().score);
            form.Show();
            return GetBestSchedule();
        } //Main function, Makes first generation and evolves it, at the end returns the best one

        private void FitnessFunction()
        {
            int worstScore = GetWorstSchedule().score;
            int totalScore = schedules.Sum(schedule => schedule.score-worstScore);
            foreach (Schedule sch in schedules)
            {
                pool.Add(sch);
                int chance = (int)(Math.Ceiling(Math.Pow(((double)(sch.score - worstScore) / totalScore) * 100, 3)));
                for(int i = 0; i < chance; ++i)
                {
                    pool.Add(sch);
                }
            }
        }
        private void GenerateNewSchedules(int count)
        {
            while (schedules.Count() < count)
            {
                int index = Data.r.Next(0, pool.Count());
                schedules.Add(new Schedule(pool[index]));
            }
        } //Generates new schedules in schedulslist based on existing top schedules;

        private void GenerateFirstGeneration(short algorithmID)
        {
            Data.menu.ProgressMax(Data.schedulesCount);
            Data.menu.ProgressVisible(true);
            for (short i = 0; i < Data.schedulesCount; ++i)
            {
                schedules.Add(Engine.GenerateNewSchedule(algorithmID));
                Data.menu.ProgressSetText($"Tworzenie pierwszej generacji | Progres");
                Data.menu.Step();
            }
        }
        public Schedule GetBestSchedule()
        {
            int max = -1;
            Schedule Best=null;
            foreach (Schedule schedule in schedules)
            {
                if (schedule.CorrectHours())
                {
                    (int currentscore, bool possible) = scorer.GetScore(schedule);
                    if (possible && currentscore > max)
                    {
                        Best = schedule;
                        max = currentscore;
                    }
                }
            }
            return Best;
        }  //returns only one best schedule //Move to engine
        public Schedule GetWorstSchedule()
        {
            int min = 99999;
            Schedule Worst = null;
            foreach (Schedule schedule in schedules)
            {
                (int currentscore, bool possible) = scorer.GetScore(schedule);
                if (/*possible &&*/ currentscore < min)
                {
                    Worst = schedule;
                    min = currentscore;
                }
            }
            return Worst;
        }  //returns only one best schedule //Move to engine
        public int GetAverage()
        {
            long score=0;
            int nbr = 0;
            foreach (Schedule schedule in schedules)
            {
                score += schedule.score;
                nbr++;
            }
            return (int)(score / nbr) ;
        }  //returns only one best schedule //Move to engine
    }//END OF SCHEDULEMIXER
}

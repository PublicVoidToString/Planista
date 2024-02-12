using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Planista
{
    public interface IScheduleScorer
    {
        int score(Schedule schedule);
        bool allowed(Schedule schedule);
    }//END OF ISCHEDULESCORER

    public class ScheduleScorer
    {
        private List<IScheduleScorer> scorers;
        public ScheduleScorer()
        {
            scorers = new List<IScheduleScorer>();
            AddScorer(new OneAtTimeProfessor());
            AddScorer(new OneAtTimeStudent());
            AddScorer(new NoBreaksProfessor());
            AddScorer(new NoBreaksStudent());
            AddScorer(new OptimalStartStudent());
            AddScorer(new OptimalStartProfessor());
            AddScorer(new DailyHourLimitProfessor());
            AddScorer(new ContinuousSubject());
            AddScorer(new CorrectHours());
        } //Constructor adds all Conditions
        private void AddScorer(IScheduleScorer scorer)
        {
            scorers.Add(scorer);
        } //Adds given Condition
        public (int, bool) GetScore(Schedule s)
        {
            int score = 0;
            bool valid = true;
            foreach (IScheduleScorer scorer in scorers)
            {
                score += scorer.score(s);
                valid &= scorer.allowed(s);
            }
            s.score = score;
            return (score, valid);
        } //Gets score andif valid of selected Schedule
    }//END OF SCHELESCORER


}

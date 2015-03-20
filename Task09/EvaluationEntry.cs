using System;

namespace Task09
{
    internal class EvaluationEntry
    {
        public EvaluationEntry(string line)
        {
            var values = line.Split(new[] {' '},
                StringSplitOptions.RemoveEmptyEntries);
            Judge = values[2];
            if (Convert.ToInt32(values[0]) < 0)
            {
                Penalty = Convert.ToInt32(values[0]);
                Score = Convert.ToInt32(values[1]);
                MessyEntry = false;
            }
            else
            {
                Penalty = Convert.ToInt32(values[1]);
                Score = Convert.ToInt32(values[0]);
                MessyEntry = true;
            }
        }

        public int Penalty { get; private set; }
        public int Score { get; private set; }
        public string Judge { get; private set; }
        public bool MessyEntry { get; private set; }
    }
}
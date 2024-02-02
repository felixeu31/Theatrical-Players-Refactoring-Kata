using System;

namespace TheatricalPlayersRefactoringKata
{
    public class Play
    {
        private string _name;
        private string _type;

        public string Name { get => _name; set => _name = value; }
        public string Type { get => _type; set => _type = value; }

        public Play(string name, string type) {
            this._name = name;
            this._type = type;
        }

        public decimal CalculatePerformanceAmount(int performanceAudience)
        {
            var performanceAmount = 0;
            switch (Type)
            {
                case "tragedy":
                    performanceAmount = 40000;
                    if (performanceAudience > 30)
                    {
                        performanceAmount += 1000 * (performanceAudience - 30);
                    }

                    break;
                case "comedy":
                    performanceAmount = 30000;
                    if (performanceAudience > 20)
                    {
                        performanceAmount += 10000 + 500 * (performanceAudience - 20);
                    }

                    performanceAmount += 300 * performanceAudience;
                    break;
                default:
                    throw new Exception("unknown type: " + Type);
            }
            
            return Convert.ToDecimal(performanceAmount / 100);
        }

        public int CalculateVolumeCredits(int performanceAudience)
        {
            var volumeCredits = Math.Max(performanceAudience - 30, 0);
            // add extra credit for every ten comedy attendees
            if ("comedy" == Type) volumeCredits += (int)Math.Floor((decimal)performanceAudience / 5);
            return volumeCredits;
        }
    }
}

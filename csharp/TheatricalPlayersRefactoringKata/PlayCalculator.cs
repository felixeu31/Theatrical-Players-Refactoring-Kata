using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatricalPlayersRefactoringKata
{
    public class PlayCalculator : IPerformanceCalculator
    {
        private readonly Performance _performance;
        private readonly int _volumeThreshold;
        private readonly decimal _baseAmount;
        private readonly int _extraAmountPerExceedAssistant;

        public PlayCalculator(Performance performance, int volumeThreshold, decimal baseAmount, int extraAmountPerExceedAssistant)
        {
            _performance = performance;
            _volumeThreshold = volumeThreshold;
            _baseAmount = baseAmount;
            _extraAmountPerExceedAssistant = extraAmountPerExceedAssistant;
        }

        protected int ExceededAudience()
        {
            return _performance.Audience - _volumeThreshold;
        }

        protected bool AudienceExceedVolumeThreshold()
        {
            return _performance.Audience > _volumeThreshold;
        }

        public virtual int CalculateVolumeCredits()
        {
            var volumeCredits = Math.Max(_performance.Audience - 30, 0);
            return volumeCredits;
        }

        public virtual decimal CalculateAmount()
        {
            if (!AudienceExceedVolumeThreshold())
            {
                return _baseAmount;
            }
            return _baseAmount + _extraAmountPerExceedAssistant * ExceededAudience();
        }
    }
}

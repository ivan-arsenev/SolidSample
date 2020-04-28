using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class AutoPolicyRater
    {
        private readonly RatingEngine _ratingEngine;
        private ConsoleLogger _loger;

        public AutoPolicyRater(RatingEngine engine, ConsoleLogger loger)
        {
            _ratingEngine = engine;
            _loger = loger;
        }
        
        public void Rate(Policy policy)
        {
            
            _loger.Log("Rating AUTO policy...");
            _loger.Log("Validating policy.");
            if (String.IsNullOrEmpty(policy.Make))
            {
                _loger.Log("Auto policy must specify Make");
                return;
            }
            if (policy.Make == "BMW")
            {
                if (policy.Deductible < 500)
                {
                    _ratingEngine.Rating = 1000m;
                }
                _ratingEngine.Rating = 900m;
            }
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class LandPolicyRater
    {
        private readonly RatingEngine _ratingEngine;
        private ConsoleLogger _loger;

        public LandPolicyRater(RatingEngine engine, ConsoleLogger loger)
        {
            _ratingEngine = engine;
            _loger = loger;
        }

        public void Rate(Policy policy)
        {

            _loger.Log("Rating LAND policy...");
            _loger.Log("Validating policy.");
            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                _loger.Log("Land policy must specify Bond Amount and Valuation.");
                return;
            }
            if (policy.BondAmount < 0.8m * policy.Valuation)
            {
                _loger.Log("Insufficient bond amount.");
                return;
            }
            _ratingEngine.Rating = policy.BondAmount * 0.05m;
            

        }
    }
}

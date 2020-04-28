using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class LifePolicyRater
    {
        private readonly RatingEngine _ratingEngine;
        private ConsoleLogger _loger;

        public LifePolicyRater(RatingEngine engine, ConsoleLogger loger)
        {
            _ratingEngine = engine;
            _loger = loger;
        }

        public void Rate(Policy policy)
        {

            _loger.Log("Rating LIFE policy...");
            _loger.Log("Validating policy.");
            if (policy.DateOfBirth == DateTime.MinValue)
            {
                _loger.Log("Life policy must include Date of Birth.");
                return;
            }
            if (policy.DateOfBirth < DateTime.Today.AddYears(-100))
            {
                _loger.Log("Centenarians are not eligible for coverage.");
                return;
            }
            if (policy.Amount == 0)
            {
                _loger.Log("Life policy must include an Amount.");
                return;
            }
            int age = DateTime.Today.Year - policy.DateOfBirth.Year;
            if (policy.DateOfBirth.Month == DateTime.Today.Month &&
                DateTime.Today.Day < policy.DateOfBirth.Day ||
                DateTime.Today.Month < policy.DateOfBirth.Month)
            {
                age--;
            }
            decimal baseRate = policy.Amount * age / 200;
            if (policy.IsSmoker)
            {
                _ratingEngine.Rating = baseRate * 2;
            }
            _ratingEngine.Rating = baseRate;

        }
    }
}

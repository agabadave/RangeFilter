using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation.TestHelper;
using RangeFilter.Validators;
using Xunit;

namespace RangeFilter.Tests.Validators
{
    public class RangeFilterValidatorTests
    {
        [Fact]
        public void Validator_ShouldHaveErrorForDateTimes_WhenFromIsGreaterThanTo()
        {
            var validator = new RangeFilterValidator<DateTime>();

            var model = new RangeFilter<DateTime>
            {
                From = DateTime.Now,
                To = DateTime.Now.AddDays(-2)
            };

            validator.ShouldHaveValidationErrorFor(x => x.To, model);
        }

        [Fact]
        public void Validator_ShouldHaveErrorForInt_WhenFromIsGreaterThanTo()
        {
            var validator = new RangeFilterValidator<int>();

            var model = new RangeFilter<int>
            {
                From = 10,
                To = 5
            };

            validator.ShouldHaveValidationErrorFor(x => x.To, model);
        }

        [Fact]
        public void Validator_ShouldHaveErrorForDouble_WhenFromIsGreaterThanTo()
        {
            var validator = new RangeFilterValidator<double>();

            var model = new RangeFilter<double>
            {
                From = 59.293840,
                To = 23.445
            };

            validator.ShouldHaveValidationErrorFor(x => x.To, model);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace RangeFilter.Validators
{
    public class RangeFilterValidator<T> : AbstractValidator<RangeFilter<T>> where T : struct
    {
        public RangeFilterValidator()
        {
            RuleFor(x => x.To).Must(ToMustBeGreaterThanFrom)
                .When(x => x.To.HasValue && x.From.HasValue)
                .WithMessage(x => "The To value must be greater than From value")
                .WithErrorCode("RangeFilter_ToMustBeGreaterThanFrom");
        }

        private bool ToMustBeGreaterThanFrom(RangeFilter<T> model, T? element)
        {
            var compare = Nullable.Compare(model.To, model.From);
            return compare > 0;
        }
    }
}

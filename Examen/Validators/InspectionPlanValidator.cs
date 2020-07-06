using Examen.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Validators
{
    public class InspectionPlanValidator : AbstractValidator<InspectionPlan>
    {
        public InspectionPlanValidator()
        {
            RuleFor(x => x.Temperature).GreaterThanOrEqualTo(18).LessThanOrEqualTo(28);
            RuleFor(x => x.Humidity).GreaterThanOrEqualTo(25).LessThanOrEqualTo(75);
            RuleFor(x => x.Pressure).GreaterThanOrEqualTo(936).LessThanOrEqualTo(1144);
        }
    }
}

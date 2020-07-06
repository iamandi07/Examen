using Examen.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Validators
{
    public class EquipmentValidator: AbstractValidator<Equipment>
    {
        public EquipmentValidator()
        {
            RuleFor(x => x.CalibrationDate).LessThan(DateTime.UtcNow);
        }
    }
}

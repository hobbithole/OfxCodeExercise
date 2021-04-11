using FluentValidation;
using OfxCodeExercise.Battleship.Lib;

namespace OfxCodeExercise.Battleship.Api.StateTracker.Validators
{
    public class PositionValidator: AbstractValidator<Position>
    {
        public PositionValidator()
        {
            RuleFor(x => x.X)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Position X must not be less than zero.");

            RuleFor(x => x.Y)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Position Y must not be less than zero.");
        }
    }
}

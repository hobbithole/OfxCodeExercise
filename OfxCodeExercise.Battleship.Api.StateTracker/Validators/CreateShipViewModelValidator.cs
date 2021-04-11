using FluentValidation;
using OfxCodeExercise.Battleship.Api.StateTracker.ViewModel;

namespace OfxCodeExercise.Battleship.Api.StateTracker.Validators
{
    public class CreateShipViewModelValidator: AbstractValidator<CreateShipRequest>
    {
        public CreateShipViewModelValidator()
        {
            RuleFor(x => x.BoardId)
                .GreaterThan(0)
                .WithMessage("Board Id must be greater than zero");

            RuleFor(x => x.Length)
                .GreaterThan(0)
                .WithMessage("Ship length must be greater than zero.");

            RuleFor(x => x.StartAt)
                .NotNull()
                .WithMessage("Ship must have a starting position")
                .SetValidator(new PositionValidator());
                
        }
    }
}

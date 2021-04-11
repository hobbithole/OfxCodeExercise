using FluentValidation;
using OfxCodeExercise.Battleship.Api.StateTracker.ViewModel;

namespace OfxCodeExercise.Battleship.Api.StateTracker.Validators
{
    public class BoardViewModelValidator: AbstractValidator<BoardViewModel>
    {
        public BoardViewModelValidator()
        {
            RuleFor(x => x.Width)
                .GreaterThanOrEqualTo(10)
                .WithMessage("Minimum board size is 10 x 10.")
                .LessThanOrEqualTo(100)
                .WithMessage("Maximum board size is 100 x 100.");

            RuleFor(x => x.Height)
                .GreaterThanOrEqualTo(10)
                .WithMessage("Minimum board size is 10 x 10.")
                .LessThanOrEqualTo(100)
                .WithMessage("Maximum board size is 100 x 100.");
        }
    }
}

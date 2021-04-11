using System;

namespace OfxCodeExercise.Battleship.Lib.Exceptions
{
    public class InvalidRequestException : ApplicationException
    {
        public InvalidRequestException(string errorMessgae) : base(errorMessgae)
        {
        }
    }
}

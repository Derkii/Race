using System;

namespace Cars
{
    internal class PossibleUnexpectedBehaviour : Exception
    {
        public PossibleUnexpectedBehaviour(string message = "") : base(message)
        {
        }
    }
}
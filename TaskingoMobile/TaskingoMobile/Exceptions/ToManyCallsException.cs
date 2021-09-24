using System;

namespace TaskingoMobile.Exceptions
{
    public class ToManyCallsException : Exception
    {
        public ToManyCallsException(string message) : base(message)
        {

        }
    }
}

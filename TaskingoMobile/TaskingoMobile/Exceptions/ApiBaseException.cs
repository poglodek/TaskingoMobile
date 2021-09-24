using System;

namespace TaskingoMobile.Exceptions
{
    public class ApiBaseException : Exception
    {
        public ApiBaseException(string message) : base(message)
        {

        }
    }
}

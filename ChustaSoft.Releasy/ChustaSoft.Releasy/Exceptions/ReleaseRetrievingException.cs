using System;

namespace ChustaSoft.Releasy.Exceptions
{
    public class ReleaseRetrievingException : Exception
    {

        private const string ERROR_MESSAGE = "An error occurred while getting the project release notes";

        public ReleaseRetrievingException(Exception innerException) 
            : base(ERROR_MESSAGE, innerException)
        { }
    }
}

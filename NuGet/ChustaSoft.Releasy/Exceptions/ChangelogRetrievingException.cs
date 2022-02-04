using System;

namespace ChustaSoft.Releasy
{
    /// <summary>
    /// Exception thrown by any internal error inside Releasy
    /// </summary>
    public class ChangelogRetrievingException : Exception
    {

        private const string ERROR_MESSAGE = "An error occurred while getting the project release notes";

        public ChangelogRetrievingException(Exception innerException) 
            : base(ERROR_MESSAGE, innerException)
        { }

    }
}

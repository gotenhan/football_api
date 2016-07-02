using System;

namespace FootballApi.CrossCuting
{
    public class FootballApiException:Exception
    {
        public FootballApiException(string message, Exception innerException = null) : base(message, innerException)
        {
        }
    }
}
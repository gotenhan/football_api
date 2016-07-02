using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballApi.Domain
{
    public class FootballApiException:Exception
    {
        public FootballApiException(string message, Exception innerException = null) : base(message, innerException)
        {
        }
    }
}
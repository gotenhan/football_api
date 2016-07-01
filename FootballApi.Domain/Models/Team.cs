using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FootballApi.Domain.Models
{
    public class Team
    {
        [Key, StringLength(200)]
        public string Name { get; set; }
    }
}
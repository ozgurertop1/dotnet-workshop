using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetWorkshop.Core.DTOs
{
    public class UserProfileDto:BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

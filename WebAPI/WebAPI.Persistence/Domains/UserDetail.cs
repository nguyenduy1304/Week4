using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Persistence.Domains
{
    public class UserDetail
    {
        public int Id { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String PhoneNumber { get; set; }

        public String Address { get; set; }

        public String IdUser { get; set; }

        public User User { get; set; }

    }
}

using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Contact:IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string District { get; set; }
        public string City { get; set; }

        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}

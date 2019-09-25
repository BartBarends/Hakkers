using System;
using System.Collections.Generic;

namespace Hakkers.Models
{
    public partial class Clients
    {
        public Clients()
        {
            Assignments = new HashSet<Assignments>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TelephoneNumber { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Location { get; set; }
        public string PostalCode { get; set; }

        public virtual ICollection<Assignments> Assignments { get; set; }
    }
}

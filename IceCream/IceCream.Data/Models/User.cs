using System;
using System.Collections.Generic;

namespace IceCream.Data.Models
{
    public partial class User
    {
        public User()
        {
            UserDebtor = new HashSet<UserDebtor>();
        }

        public int IdUser { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime AdmissionDate { get; set; }
        public string Contact { get; set; }
        public string Password { get; set; }
        public DateTime? AcceptedTemsDate { get; set; }
        public DateTime Created { get; set; }
        public bool IsAdmin { get; set; }
        public string ImageURL { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<UserDebtor> UserDebtor { get; set; }

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Entities
{
    public class User
    {
        public virtual string Account { get; set; }
        public virtual string Firstname { get; set; }
        public virtual string Lastname { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual string Avatar { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace EFCORE.Models
{
    public partial class Blog
    {
        public Blog()
        {
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public decimal IdDecimal { get; set; }
        public Guid IdGuid { get; set; }
        public string BlogName { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}

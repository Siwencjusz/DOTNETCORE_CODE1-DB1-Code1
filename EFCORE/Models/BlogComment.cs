using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCORE.Models
{
    public class BlogComment
    {
        public int BlogId { get; private set; }
        public decimal IdDecimal { get; private set; }
        public Guid IdGuid { get; private set; }
        public string BlogName { get; private set; }
        public int CommentId { get; private set; }
        public string Comment { get; private set; }
    }
}

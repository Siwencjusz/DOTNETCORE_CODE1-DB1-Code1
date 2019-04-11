using System;
using System.Collections.Generic;

namespace EFCORE.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public int? BlogId { get; set; }
        public string Comment1 { get; set; }

        public Blog Blog { get; set; }
    }
}

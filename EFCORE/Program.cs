using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EFCORE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var _context = new DbFactory().CreateDbContext(new string[] { }))
            {
                var blog = _context.Blogs.FirstOrDefault();
                var comment = _context.Comments.FirstOrDefault();
                var blogComment = _context.BlogCommentsView.FirstOrDefault();

            }
            CreateWebHostBuilder(args).Build().Run();

        
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}

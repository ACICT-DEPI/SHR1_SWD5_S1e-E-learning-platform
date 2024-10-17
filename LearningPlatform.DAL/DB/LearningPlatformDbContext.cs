using LearningPlatform.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlatform.DAL.DB
{
    public class LearningPlatformDbContext:DbContext
    {
        public LearningPlatformDbContext(DbContextOptions<LearningPlatformDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
		public DbSet<Course> Courses{ get; set; }
	}
}

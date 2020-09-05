using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using Fitness.BL.Model;

namespace Fitness.BL.Controller
{
    class FitnessContext : DbContext
    {
        public FitnessContext() : base("DBconnection") { }

        public DbSet<Activity> Activities { get; set; }
    }
}

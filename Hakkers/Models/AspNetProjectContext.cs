using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Hakkers.Models
{
    public partial class AspNetProjectContext : IdentityDbContext
    {
        public AspNetProjectContext(DbContextOptions<AspNetProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AssignmentCategories> AssignmentCategories { get; set; }
        public virtual DbSet<AssignmentPriorities> AssignmentPriorities { get; set; }
        public virtual DbSet<AssignmentStatuses> AssignmentStatuses { get; set; }
        public virtual DbSet<Assignments> Assignments { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
    }
}

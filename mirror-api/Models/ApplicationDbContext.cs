using Microsoft.EntityFrameworkCore;

namespace mirror_api.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<Level> Levels { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<LevelGroup> LevelGroups { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        
        
        /*
        ** OnModelCreating => override helps adding additional configuration of models
        ** @param ModelBuilder => Helps maintaining the shape, relations and DB maps between entities 
        */

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            // Defining the foreign keys in associative @LevelGroup model
            builder.Entity<LevelGroup>().HasKey(lg => new
            {
                lg.GroupId,
                lg.LevelId
            });
            
            // Many-to-one relationship between @LevelGroup and @Level
            builder.Entity<LevelGroup>()
                .HasOne(levelGroup => levelGroup.Level)
                .WithMany(level => level.LevelGroups)
                .HasForeignKey(levelGroup => levelGroup.LevelId);
            
            // Many-to-one relationship between @LevelGroup and @Group
            builder.Entity<LevelGroup>()
                .HasOne(levelGroup => levelGroup.Group)
                .WithMany(level => level.LevelGroups)
                .HasForeignKey(levelGroup => levelGroup.GroupId);
        }
    }
}
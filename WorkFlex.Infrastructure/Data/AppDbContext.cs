using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WorkFlex.Domain.Entities;

namespace WorkFlex.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<Conversation> Conversations { get; set; }
        public virtual DbSet<ConversationReply> ConversationReplies { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<JobPost> JobPosts { get; set; }
        public virtual DbSet<JobType> JobTypes { get; set; }
        public virtual DbSet<JobApplication> JobApplications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", true, true);
                IConfigurationRoot configuration = builder.Build();
                string connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidDataException("Connection string is not found");
                optionsBuilder.UseSqlite(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Profile)
                .WithOne(p => p.User)
                .HasForeignKey<Profile>(p => p.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.JobPosts)
                .WithOne(jp => jp.User)
                .HasForeignKey(jp => jp.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.ConversationReplies)
                .WithOne(cr => cr.User)
                .HasForeignKey(cr => cr.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.ConversationsAsUserOne)
                .WithOne(c => c.UserOneNavigation)
                .HasForeignKey(c => c.UserOne);

            modelBuilder.Entity<User>()
                .HasMany(u => u.ConversationsAsUserTwo)
                .WithOne(c => c.UserTwoNavigation)
                .HasForeignKey(c => c.UserTwo);

            modelBuilder.Entity<Role>()
                .HasMany(r => r.Users)
                .WithOne(u => u.Role)
                .HasForeignKey(u => u.RoleId);

            modelBuilder.Entity<JobType>()
                .HasMany(jt => jt.JobPosts)
                .WithOne(jp => jp.JobType)
                .HasForeignKey(jp => jp.JobTypeId);

            modelBuilder.Entity<Industry>()
                .HasMany(jt => jt.JobPosts)
                .WithOne(jp => jp.Industry)
                .HasForeignKey(jp => jp.IndustryId);

            modelBuilder.Entity<JobPost>()
                .HasMany(jp => jp.JobApplications)
                .WithOne(a => a.JobPost)
                .HasForeignKey(a => a.JobPostId);

            // Seed Data
            modelBuilder.Seed();
        }
    }
}

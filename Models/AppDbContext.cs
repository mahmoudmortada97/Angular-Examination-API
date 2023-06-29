using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ExaminationAuthentication.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Student_Exam> Students_Exams { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student_Exam>().HasKey(m => new { m.StudentId, m.ExamId });
            modelBuilder.Entity<Student_Exam>().HasOne(ep => ep.Student).WithMany(e => e.student_Exams).HasForeignKey(ep => ep.StudentId);
            modelBuilder.Entity<Student_Exam>().HasOne(ep => ep.Exam).WithMany(e => e.student_Exams).HasForeignKey(ep => ep.ExamId);

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "student" },
                new IdentityRole { Name = "instructor" }
                );

            modelBuilder.Entity<Student>()
            .Property(u => u.Id)
           .ValueGeneratedNever();

            modelBuilder.Entity<Instructor>()
            .Property(u => u.Id)
        .ValueGeneratedNever();



            modelBuilder.Entity<Exam>()
       .HasMany(e => e.questions)
       .WithOne(q => q.Exam)
       .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Ignore<IdentityUserLogin<string>>();
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(ur => new { ur.UserId, ur.RoleId });
            modelBuilder.Ignore<IdentityUserToken<string>>();



        }
    }
}

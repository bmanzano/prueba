namespace LTraker.Data
{
    using Entities;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public class LearningContext : DbContext
    {
        public LearningContext()
            : base("name=LearningContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Individual
            var individual = modelBuilder.Entity<Individual>();
            individual.ToTable("Individual");
            individual.HasKey(x => x.Id);
            individual.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            individual.Property(x => x.Email).HasMaxLength(500).IsRequired();
            individual.Property(x => x.Name).HasMaxLength(500).IsRequired();
            #endregion

            #region Course
            var course = modelBuilder.Entity<Course>();
            course.ToTable("Courses");
            course.HasKey(x => x.Id);
            course.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            course.Property(x => x.Name).HasMaxLength(500).IsRequired();
            course.Property(x => x.Description).HasMaxLength(500).IsOptional();
            course.Property(x => x.DurationAVG).IsRequired();
            course.HasMany(x => x.Topics);
            #endregion

            #region Topic
            var topic = modelBuilder.Entity<Topic>();
            topic.ToTable("Topics");
            topic.HasKey(x => x.Id);
            topic.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            topic.Property(x => x.Name).HasMaxLength(500).IsRequired();
            topic.Property(x => x.Descripcion).HasMaxLength(500).IsOptional();
            topic.HasMany(x => x.Courses);
            #endregion

            #region Planeacion
            var planeacion = modelBuilder.Entity<Planeacion>();
            planeacion.ToTable("Planeacion");
            planeacion.HasKey(x => x.Id);
            planeacion.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            planeacion.Property(x => x.DateEstimatedInicio).IsOptional();
            planeacion.Property(x => x.DateEstimatedFin).IsOptional();
            planeacion.Property(x => x.DurationEstimated).IsOptional();
            planeacion.HasRequired(x => x.AssignedCourse).WithMany().HasForeignKey(x => x.AssignedCourseId);
            #endregion

            #region AssignedCourse
            var assignedcourse = modelBuilder.Entity<AssignedCourse>();
            assignedcourse.ToTable("AssignedCourses");
            assignedcourse.HasKey(x => x.Id);
            assignedcourse.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            assignedcourse.Property(x => x.AssignmentDate).IsRequired();
            assignedcourse.Property(x => x.StartDate).IsOptional();
            assignedcourse.Property(x => x.FinishDate).IsOptional();
            assignedcourse.Property(x => x.IsCompleted).IsOptional();
            assignedcourse.Property(x => x.TotalHours).IsOptional();
            assignedcourse.HasRequired(x => x.Individual).WithMany().HasForeignKey(x => x.IndividualId);
            assignedcourse.HasRequired(x => x.Course).WithMany().HasForeignKey(x => x.CourseId);
            #endregion

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<Individual> Individuals { get; set; }
        public virtual DbSet<AssignedCourse> AssignedCourses { get; set; }
        public virtual DbSet<Planeacion> Planeacion { get; set; }
    }
}
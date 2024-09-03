using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FinalProj.Models;

public partial class FprojectContext : DbContext
{
    public FprojectContext()
    {
    }

    public FprojectContext(DbContextOptions<FprojectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CalendarEvent> CalendarEvents { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<File> Files { get; set; }

    public virtual DbSet<ProjectGroup> ProjectGroups { get; set; }

    public virtual DbSet<SubmissionDate> SubmissionDates { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(" Server= DESKTOP-UTNTEEU\\SQLEXPRESS;Database= FProject;Trusted_Connection=True;Encrypt=false ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CalendarEvent>(entity =>
        {
            entity.HasKey(e => e.EventNum).HasName("PK__Calendar__14AB80BBFADCEB02");

            entity.ToTable("CalendarEvent");

            entity.Property(e => e.EventNum).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.EndDate)
                .HasColumnType("date")
                .HasColumnName("end_date");
            entity.Property(e => e.EndHour).HasColumnName("end_hour");
            entity.Property(e => e.EventType)
                .HasMaxLength(255)
                .HasColumnName("eventType");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.StartDate)
                .HasColumnType("date")
                .HasColumnName("start_date");
            entity.Property(e => e.StartHour).HasColumnName("start_hour");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.CalendarEvents)
                .HasForeignKey(d => d.Id)
                .HasConstraintName("FK__CalendarEven__ID__398D8EEE");

            entity.HasOne(d => d.ProjNumNavigation).WithMany(p => p.CalendarEvents)
                .HasForeignKey(d => d.ProjNum)
                .HasConstraintName("FK__CalendarE__ProjN__38996AB5");

            entity.HasMany(d => d.Ids).WithMany(p => p.EventNums)
                .UsingEntity<Dictionary<string, object>>(
                    "AddedBy",
                    r => r.HasOne<User>().WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__AddedBy__ID__3D5E1FD2"),
                    l => l.HasOne<CalendarEvent>().WithMany()
                        .HasForeignKey("EventNum")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__AddedBy__EventNu__3C69FB99"),
                    j =>
                    {
                        j.HasKey("EventNum", "Id").HasName("PK__AddedBy__778ACE793F1F329F");
                        j.ToTable("AddedBy");
                        j.IndexerProperty<int>("Id").HasColumnName("ID");
                    });
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepNum).HasName("PK__Departme__4D3E6BA54B4C37F6");

            entity.ToTable("Department");

            entity.Property(e => e.DepNum).ValueGeneratedNever();
            entity.Property(e => e.NameDepartment)
                .HasMaxLength(255)
                .HasColumnName("Name_department");
        });

        modelBuilder.Entity<File>(entity =>
        {
            entity.HasKey(e => e.FileNum).HasName("PK__Files__0BBA21386B80A48A");

            entity.Property(e => e.FileNum).ValueGeneratedNever();
            entity.Property(e => e.FileName)
                .HasMaxLength(255)
                .HasColumnName("file_name");
            entity.Property(e => e.FilePath)
                .HasMaxLength(255)
                .HasColumnName("file_path");
            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.Files)
                .HasForeignKey(d => d.Id)
                .HasConstraintName("FK__Files__ID__35BCFE0A");

            entity.HasOne(d => d.ProjNumNavigation).WithMany(p => p.Files)
                .HasForeignKey(d => d.ProjNum)
                .HasConstraintName("FK__Files__ProjNum__34C8D9D1");
        });

        modelBuilder.Entity<ProjectGroup>(entity =>
        {
            entity.HasKey(e => e.ProjNum).HasName("PK__ProjectG__C5FDFDDC8BBCEF85");

            entity.ToTable("ProjectGroup");

            entity.Property(e => e.ProjNum).ValueGeneratedNever();
            entity.Property(e => e.NameProject)
                .HasMaxLength(255)
                .HasColumnName("Name_project");

            entity.HasOne(d => d.DepNumNavigation).WithMany(p => p.ProjectGroups)
                .HasForeignKey(d => d.DepNum)
                .HasConstraintName("FK__ProjectGr__DepNu__267ABA7A");
        });

        modelBuilder.Entity<SubmissionDate>(entity =>
        {
            entity.HasKey(e => e.SubNum).HasName("PK__Submissi__EBF25663E9A97DDA");

            entity.ToTable("SubmissionDate");

            entity.Property(e => e.SubNum).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.DueDate)
                .HasColumnType("date")
                .HasColumnName("due_date");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.SubmissionName)
                .HasMaxLength(255)
                .HasColumnName("Submission_name");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.SubmissionDates)
                .HasForeignKey(d => d.Id)
                .HasConstraintName("FK__SubmissionDa__ID__31EC6D26");

            entity.HasOne(d => d.ProjNumNavigation).WithMany(p => p.SubmissionDates)
                .HasForeignKey(d => d.ProjNum)
                .HasConstraintName("FK__Submissio__ProjN__30F848ED");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.TaskNum).HasName("PK__Task__64996029CACF7EB6");

            entity.ToTable("Task");

            entity.Property(e => e.TaskNum).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.DueDate)
                .HasColumnType("date")
                .HasColumnName("due_date");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IsCompleted).HasColumnName("is_completed");
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.Id)
                .HasConstraintName("FK__Task__ID__2E1BDC42");

            entity.HasOne(d => d.ProjNumNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.ProjNum)
                .HasConstraintName("FK__Task__ProjNum__2D27B809");

            entity.HasMany(d => d.EventNums).WithMany(p => p.TaskNums)
                .UsingEntity<Dictionary<string, object>>(
                    "AddTo",
                    r => r.HasOne<CalendarEvent>().WithMany()
                        .HasForeignKey("EventNum")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__AddTo__EventNum__48CFD27E"),
                    l => l.HasOne<Task>().WithMany()
                        .HasForeignKey("TaskNum")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__AddTo__TaskNum__47DBAE45"),
                    j =>
                    {
                        j.HasKey("TaskNum", "EventNum").HasName("PK__AddTo__C5D3D822D198D9F7");
                        j.ToTable("AddTo");
                    });

            entity.HasMany(d => d.Ids).WithMany(p => p.TaskNums)
                .UsingEntity<Dictionary<string, object>>(
                    "WrittenBy",
                    r => r.HasOne<User>().WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__WrittenBy__ID__44FF419A"),
                    l => l.HasOne<Task>().WithMany()
                        .HasForeignKey("TaskNum")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__WrittenBy__TaskN__440B1D61"),
                    j =>
                    {
                        j.HasKey("TaskNum", "Id").HasName("PK__WrittenB__07B82EEB5195BAEA");
                        j.ToTable("WrittenBy");
                        j.IndexerProperty<int>("Id").HasColumnName("ID");
                    });
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC2715FE8987");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ConfirmPassword)
                .HasMaxLength(255)
                .HasColumnName("confirm_password");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("First_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("Last_name");
            entity.Property(e => e.Passworde)
                .HasMaxLength(255)
                .HasColumnName("passworde");

            entity.HasOne(d => d.DepNumNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.DepNum)
                .HasConstraintName("FK__Users__DepNum__29572725");

            entity.HasOne(d => d.ProjNumNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.ProjNum)
                .HasConstraintName("FK__Users__ProjNum__2A4B4B5E");

            entity.HasMany(d => d.FileNums).WithMany(p => p.Ids)
                .UsingEntity<Dictionary<string, object>>(
                    "UploadedBy",
                    r => r.HasOne<File>().WithMany()
                        .HasForeignKey("FileNum")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__UploadedB__FileN__412EB0B6"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__UploadedBy__ID__403A8C7D"),
                    j =>
                    {
                        j.HasKey("Id", "FileNum").HasName("PK__Uploaded__A2AF4E3411E3F2B0");
                        j.ToTable("UploadedBy");
                        j.IndexerProperty<int>("Id").HasColumnName("ID");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

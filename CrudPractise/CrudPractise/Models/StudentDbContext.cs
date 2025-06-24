using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CrudPractise.Models;

public partial class StudentDbContext : DbContext
{
    public StudentDbContext()
    {
    }

    public StudentDbContext(DbContextOptions<StudentDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=connstring");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__course__8F1FF3864C384D5B");

            entity.ToTable("course");

            entity.HasIndex(e => e.CourseName, "UQ__course__363C7AEC38ECC573").IsUnique();

            entity.Property(e => e.CourseId)
                .ValueGeneratedNever()
                .HasColumnName("course_Id");
            entity.Property(e => e.CourseName)
                .HasMaxLength(50)
                .HasColumnName("course_Name");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__A2F4E9ACD5E9D1C3");

            entity.ToTable("Student");

            entity.Property(e => e.StudentId)
                .ValueGeneratedNever()
                .HasColumnName("Student_ID");
            entity.Property(e => e.CourseId).HasColumnName("course_Id");
            entity.Property(e => e.StdAddress)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("std_address");
            entity.Property(e => e.StudentName)
                .HasMaxLength(50)
                .HasColumnName("Student_Name");

            entity.HasOne(d => d.Course).WithMany(p => p.Students)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Student__course___3B75D760");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

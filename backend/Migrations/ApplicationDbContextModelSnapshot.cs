﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend.Data.Contexts;

namespace backend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("backend.Data.Models.Administrator", b =>
                {
                    b.Property<int>("AdministratorId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.HasKey("AdministratorId");

                    b.ToTable("Administrators");
                });

            modelBuilder.Entity("backend.Data.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CourseName");

                    b.Property<int>("CreditHours");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Level")
                        .IsRequired();

                    b.Property<string>("Section");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("backend.Data.Models.Instructor", b =>
                {
                    b.Property<int>("InstructorId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("InstructorId");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("backend.Data.Models.Prerequisite", b =>
                {
                    b.Property<int>("PrerequisiteId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CourseId");

                    b.Property<bool>("IsMandatory");

                    b.HasKey("PrerequisiteId");

                    b.HasIndex("CourseId");

                    b.ToTable("Prerequisite");
                });

            modelBuilder.Entity("backend.Data.Models.Registration", b =>
                {
                    b.Property<int>("RegistrationId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CourseId");

                    b.Property<int>("EnrollmentLimit");

                    b.Property<int?>("InstructorId");

                    b.HasKey("RegistrationId");

                    b.HasIndex("CourseId");

                    b.HasIndex("InstructorId");

                    b.ToTable("Registration");
                });

            modelBuilder.Entity("backend.Data.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("BirthDate")
                        .IsRequired()
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("backend.Data.Models.StudentEnrollment", b =>
                {
                    b.Property<int>("StudentEnrollmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("RegistrationId");

                    b.Property<int>("StudentId");

                    b.HasKey("StudentEnrollmentId");

                    b.HasIndex("RegistrationId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentEnrollment");
                });

            modelBuilder.Entity("backend.Data.Models.Prerequisite", b =>
                {
                    b.HasOne("backend.Data.Models.Course", "Course")
                        .WithMany("Prerequisites")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("backend.Data.Models.Registration", b =>
                {
                    b.HasOne("backend.Data.Models.Course", "Course")
                        .WithMany("Registrations")
                        .HasForeignKey("CourseId");

                    b.HasOne("backend.Data.Models.Instructor", "Instructor")
                        .WithMany("Registrations")
                        .HasForeignKey("InstructorId");
                });

            modelBuilder.Entity("backend.Data.Models.StudentEnrollment", b =>
                {
                    b.HasOne("backend.Data.Models.Registration", "Registration")
                        .WithMany("StudentEnrollments")
                        .HasForeignKey("RegistrationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("backend.Data.Models.Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

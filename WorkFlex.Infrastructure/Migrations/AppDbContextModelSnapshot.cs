﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkFlex.Infrastructure.Data;

#nullable disable

namespace WorkFlex.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WorkFlex.Domain.Entities.Conversation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserOne")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserTwo")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserOne");

                    b.HasIndex("UserTwo");

                    b.ToTable("Conversations");
                });

            modelBuilder.Entity("WorkFlex.Domain.Entities.ConversationReply", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ConversationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Reply")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ConversationId");

                    b.HasIndex("UserId");

                    b.ToTable("ConversationReplies");
                });

            modelBuilder.Entity("WorkFlex.Domain.Entities.Industry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("IndustryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Industry");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 10, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(1038),
                            IndustryName = "Software Development",
                            ModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 10, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(1042),
                            IndustryName = "Artificial Intelligence",
                            ModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 10, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(1042),
                            IndustryName = "Healthcare",
                            ModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2024, 10, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(1043),
                            IndustryName = "Finance",
                            ModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2024, 10, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(1044),
                            IndustryName = "Transportation",
                            ModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2024, 10, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(1044),
                            IndustryName = "Agriculture",
                            ModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("WorkFlex.Domain.Entities.JobApplication", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ApplicationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CvFile")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("JobPostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("JobPostId");

                    b.HasIndex("UserId");

                    b.ToTable("JobApplications");

                    b.HasData(
                        new
                        {
                            Id = new Guid("dc15e04c-f427-46dd-89d3-d7c9f2be3d14"),
                            ApplicationDate = new DateTime(2024, 10, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(1180),
                            CvFile = "path/to/cv.pdf",
                            Description = "",
                            JobPostId = new Guid("517306b6-9100-4b6a-8d14-989929f2d3b7"),
                            Status = 2,
                            UserId = new Guid("b9901f8d-a093-4668-9425-e678450ab197")
                        });
                });

            modelBuilder.Entity("WorkFlex.Domain.Entities.JobPost", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpiredAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("IndustryId")
                        .HasColumnType("int");

                    b.Property<string>("JobDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobLocation")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("JobTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("SalaryRange")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IndustryId");

                    b.HasIndex("JobTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("JobPosts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("517306b6-9100-4b6a-8d14-989929f2d3b7"),
                            CreatedAt = new DateTime(2024, 10, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(1141),
                            ExpiredAt = new DateTime(2024, 11, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(1142),
                            IndustryId = 1,
                            JobDescription = "Looking for a skilled software engineer. Must have experience with C# and .NET Core. Angular experience is a plus.",
                            JobLocation = "Số 13, Tân Thuận Đông, Quận 7, Hồ Chí Minh",
                            JobTypeId = 1,
                            ModifiedAt = new DateTime(2024, 10, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(1142),
                            SalaryRange = "",
                            Status = 0,
                            Title = "Software Engineer",
                            UserId = new Guid("5e00316f-34b1-422d-aced-7df47cd486c4")
                        },
                        new
                        {
                            Id = new Guid("ada5f8c2-65c2-4c18-b1c8-d3f3a0238607"),
                            CreatedAt = new DateTime(2024, 10, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(1157),
                            ExpiredAt = new DateTime(2024, 11, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(1158),
                            IndustryId = 2,
                            JobDescription = "Looking for a data scientist to join our AI team. Must have experience with Python, TensorFlow, and Keras.",
                            JobLocation = " 239 Đ. Xuân Thủy, Dịch Vọng Hậu, Cầu Giấy, Hà Nội",
                            JobTypeId = 1,
                            ModifiedAt = new DateTime(2024, 10, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(1158),
                            SalaryRange = "",
                            Status = 0,
                            Title = "AI Engineer",
                            UserId = new Guid("5e00316f-34b1-422d-aced-7df47cd486c4")
                        },
                        new
                        {
                            Id = new Guid("90ab47e4-e674-4d75-8e09-dd668234ceb3"),
                            CreatedAt = new DateTime(2024, 10, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(1161),
                            ExpiredAt = new DateTime(2024, 11, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(1161),
                            IndustryId = 3,
                            JobDescription = "We are looking for a nurse to join our team. Must have a nursing degree and at least 2 years of experience.",
                            JobLocation = "Số 1, Đại Cồ Việt, Hai Bà Trưng, Hà Nội",
                            JobTypeId = 1,
                            ModifiedAt = new DateTime(2024, 10, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(1161),
                            SalaryRange = "",
                            Status = 0,
                            Title = "Nurse",
                            UserId = new Guid("5e00316f-34b1-422d-aced-7df47cd486c4")
                        });
                });

            modelBuilder.Entity("WorkFlex.Domain.Entities.JobType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("JobTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 10, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(1017),
                            ModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TypeName = "Full Time"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 10, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(1021),
                            ModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TypeName = "Part Time"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 10, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(1021),
                            ModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TypeName = "Internship"
                        });
                });

            modelBuilder.Entity("WorkFlex.Domain.Entities.Profile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Headline")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Profiles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e62ef57d-51c2-45a2-a166-3e311f10f4dc"),
                            CreatedAt = new DateTime(2024, 10, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(992),
                            Headline = "Admin Profile",
                            ModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Summary = "",
                            UserId = new Guid("5b86f1ab-349a-4f85-9ca0-6e4a0d0a5321")
                        },
                        new
                        {
                            Id = new Guid("c0bcc639-ff4d-4e1b-8f30-0a7c026e0247"),
                            CreatedAt = new DateTime(2024, 10, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(995),
                            Headline = "Recruiter Profile",
                            ModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Summary = "",
                            UserId = new Guid("5e00316f-34b1-422d-aced-7df47cd486c4")
                        },
                        new
                        {
                            Id = new Guid("bc12cdfb-a888-49e4-9771-c6cb934b4668"),
                            CreatedAt = new DateTime(2024, 10, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(997),
                            Headline = "Job Seeker Profile",
                            ModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Summary = "",
                            UserId = new Guid("b9901f8d-a093-4668-9425-e678450ab197")
                        });
                });

            modelBuilder.Entity("WorkFlex.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleName = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            RoleName = "Recruiter"
                        },
                        new
                        {
                            Id = 3,
                            RoleName = "JobSeeker"
                        });
                });

            modelBuilder.Entity("WorkFlex.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Avatar")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsLock")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Location")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Phone")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5b86f1ab-349a-4f85-9ca0-6e4a0d0a5321"),
                            Avatar = "",
                            CreatedAt = new DateTime(2024, 10, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(902),
                            DateOfBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "admin@example.com",
                            FirstName = "Admin",
                            IsActive = true,
                            IsLock = false,
                            LastName = "User",
                            Location = "",
                            ModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Password = "$2a$12$Qj8ov7RydnsbdkZfYAToaumQQIYDCeWcPyUTMeIW4sdhBoFujJHfm",
                            Phone = "",
                            RoleId = 1,
                            Username = "admin"
                        },
                        new
                        {
                            Id = new Guid("5e00316f-34b1-422d-aced-7df47cd486c4"),
                            Avatar = "",
                            CreatedAt = new DateTime(2024, 10, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(905),
                            DateOfBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "recruiter@example.com",
                            FirstName = "Recruiter",
                            IsActive = true,
                            IsLock = false,
                            LastName = "User",
                            Location = "",
                            ModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Password = "$2a$12$RbvswLANBzRWrHEvwHJajem0x0uEv10NHZ7rFfdRG1Dn4oSulmavm",
                            Phone = "",
                            RoleId = 2,
                            Username = "recruiter"
                        },
                        new
                        {
                            Id = new Guid("b9901f8d-a093-4668-9425-e678450ab197"),
                            Avatar = "",
                            CreatedAt = new DateTime(2024, 10, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(908),
                            DateOfBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "jobseeker@example.com",
                            FirstName = "Job",
                            IsActive = true,
                            IsLock = false,
                            LastName = "Seeker",
                            Location = "",
                            ModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Password = "$2a$12$L90P0yqjOYUyP8iuS5YkCe669W9DQnIRqqkzGVw24cJwVTVBhmc3i",
                            Phone = "",
                            RoleId = 3,
                            Username = "jobseeker"
                        });
                });

            modelBuilder.Entity("WorkFlex.Domain.Entities.Conversation", b =>
                {
                    b.HasOne("WorkFlex.Domain.Entities.User", "UserOneNavigation")
                        .WithMany("ConversationsAsUserOne")
                        .HasForeignKey("UserOne")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WorkFlex.Domain.Entities.User", "UserTwoNavigation")
                        .WithMany("ConversationsAsUserTwo")
                        .HasForeignKey("UserTwo")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("UserOneNavigation");

                    b.Navigation("UserTwoNavigation");
                });

            modelBuilder.Entity("WorkFlex.Domain.Entities.ConversationReply", b =>
                {
                    b.HasOne("WorkFlex.Domain.Entities.Conversation", "Conversation")
                        .WithMany("ConversationReplies")
                        .HasForeignKey("ConversationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorkFlex.Domain.Entities.User", "User")
                        .WithMany("ConversationReplies")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Conversation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WorkFlex.Domain.Entities.JobApplication", b =>
                {
                    b.HasOne("WorkFlex.Domain.Entities.JobPost", "JobPost")
                        .WithMany("JobApplications")
                        .HasForeignKey("JobPostId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WorkFlex.Domain.Entities.User", "User")
                        .WithMany("JobApplications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobPost");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WorkFlex.Domain.Entities.JobPost", b =>
                {
                    b.HasOne("WorkFlex.Domain.Entities.Industry", "Industry")
                        .WithMany("JobPosts")
                        .HasForeignKey("IndustryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorkFlex.Domain.Entities.JobType", "JobType")
                        .WithMany("JobPosts")
                        .HasForeignKey("JobTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorkFlex.Domain.Entities.User", "User")
                        .WithMany("JobPosts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Industry");

                    b.Navigation("JobType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WorkFlex.Domain.Entities.Profile", b =>
                {
                    b.HasOne("WorkFlex.Domain.Entities.User", "User")
                        .WithOne("Profile")
                        .HasForeignKey("WorkFlex.Domain.Entities.Profile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WorkFlex.Domain.Entities.User", b =>
                {
                    b.HasOne("WorkFlex.Domain.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("WorkFlex.Domain.Entities.Conversation", b =>
                {
                    b.Navigation("ConversationReplies");
                });

            modelBuilder.Entity("WorkFlex.Domain.Entities.Industry", b =>
                {
                    b.Navigation("JobPosts");
                });

            modelBuilder.Entity("WorkFlex.Domain.Entities.JobPost", b =>
                {
                    b.Navigation("JobApplications");
                });

            modelBuilder.Entity("WorkFlex.Domain.Entities.JobType", b =>
                {
                    b.Navigation("JobPosts");
                });

            modelBuilder.Entity("WorkFlex.Domain.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("WorkFlex.Domain.Entities.User", b =>
                {
                    b.Navigation("ConversationReplies");

                    b.Navigation("ConversationsAsUserOne");

                    b.Navigation("ConversationsAsUserTwo");

                    b.Navigation("JobApplications");

                    b.Navigation("JobPosts");

                    b.Navigation("Profile")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

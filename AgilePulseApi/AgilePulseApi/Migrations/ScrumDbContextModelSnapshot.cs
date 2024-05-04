﻿// <auto-generated />
using System;
using AgilePulseApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AgilePulseApi.Migrations
{
    [DbContext(typeof(ScrumDbContext))]
    partial class ScrumDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AgilePulseApi.Models.Domain.Cycle", b =>
                {
                    b.Property<Guid>("CycleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CycleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("CycleId");

                    b.ToTable("Cycle");
                });

            modelBuilder.Entity("AgilePulseApi.Models.Domain.Issue", b =>
                {
                    b.Property<Guid>("IssueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IssueDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IssueTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Priority")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("cycleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("projectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("scrumUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IssueId");

                    b.HasIndex("cycleId");

                    b.HasIndex("projectId");

                    b.HasIndex("scrumUserId");

                    b.ToTable("Issue");
                });

            modelBuilder.Entity("AgilePulseApi.Models.Domain.Project", b =>
                {
                    b.Property<Guid>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("LeadId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProjectId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectId");

                    b.HasIndex("LeadId");

                    b.HasIndex("ProjectId1");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("AgilePulseApi.Models.Domain.ScrumUser", b =>
                {
                    b.Property<Guid>("ScrumUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ScrumUsername")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ScrumUserId");

                    b.ToTable("ScumUser");
                });

            modelBuilder.Entity("AgilePulseApi.Models.Domain.ScrumUserProject", b =>
                {
                    b.Property<Guid>("ScrumUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ScrumUserId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ScrumUserProject");
                });

            modelBuilder.Entity("AgilePulseApi.Models.Domain.Issue", b =>
                {
                    b.HasOne("AgilePulseApi.Models.Domain.Cycle", "cycle")
                        .WithMany("issues")
                        .HasForeignKey("cycleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgilePulseApi.Models.Domain.Project", "project")
                        .WithMany("issues")
                        .HasForeignKey("projectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgilePulseApi.Models.Domain.ScrumUser", "scrumUser")
                        .WithMany("issues")
                        .HasForeignKey("scrumUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cycle");

                    b.Navigation("project");

                    b.Navigation("scrumUser");
                });

            modelBuilder.Entity("AgilePulseApi.Models.Domain.Project", b =>
                {
                    b.HasOne("AgilePulseApi.Models.Domain.ScrumUser", "scrumUser")
                        .WithMany("projects")
                        .HasForeignKey("LeadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgilePulseApi.Models.Domain.Project", null)
                        .WithMany("projects")
                        .HasForeignKey("ProjectId1");

                    b.Navigation("scrumUser");
                });

            modelBuilder.Entity("AgilePulseApi.Models.Domain.ScrumUserProject", b =>
                {
                    b.HasOne("AgilePulseApi.Models.Domain.Project", "Project")
                        .WithMany("ScrumUserProjects")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgilePulseApi.Models.Domain.ScrumUser", "ScrumUser")
                        .WithMany("ScrumUserProjects")
                        .HasForeignKey("ScrumUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("ScrumUser");
                });

            modelBuilder.Entity("AgilePulseApi.Models.Domain.Cycle", b =>
                {
                    b.Navigation("issues");
                });

            modelBuilder.Entity("AgilePulseApi.Models.Domain.Project", b =>
                {
                    b.Navigation("ScrumUserProjects");

                    b.Navigation("issues");

                    b.Navigation("projects");
                });

            modelBuilder.Entity("AgilePulseApi.Models.Domain.ScrumUser", b =>
                {
                    b.Navigation("ScrumUserProjects");

                    b.Navigation("issues");

                    b.Navigation("projects");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TimeTracker.Data.Database;

#nullable disable

namespace TimeTracker.Data.Migrations
{
    [DbContext(typeof(TimeTrackerContext))]
    partial class TimeTrackerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.8");

            modelBuilder.Entity("TimeTracker.Data.Models.Organisation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("CreatorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Organisations");
                });

            modelBuilder.Entity("TimeTracker.Data.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("CreatorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("OrganisationId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("OrganisationId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("TimeTracker.Data.Models.Record", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("CreatorId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("End")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProjectId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Start")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("WorkItemId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("WorkItemId");

                    b.ToTable("Records");
                });

            modelBuilder.Entity("TimeTracker.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TimeTracker.Data.Models.WorkItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("CreatorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProjectId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("WorkItemId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("WorkItemId");

                    b.ToTable("WorkItems");
                });

            modelBuilder.Entity("TimeTracker.Data.Models.Organisation", b =>
                {
                    b.HasOne("TimeTracker.Data.Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("TimeTracker.Data.Models.Project", b =>
                {
                    b.HasOne("TimeTracker.Data.Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TimeTracker.Data.Models.Organisation", "Organisation")
                        .WithMany("Projects")
                        .HasForeignKey("OrganisationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Organisation");
                });

            modelBuilder.Entity("TimeTracker.Data.Models.Record", b =>
                {
                    b.HasOne("TimeTracker.Data.Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TimeTracker.Data.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TimeTracker.Data.Models.WorkItem", "WorkItem")
                        .WithMany("Records")
                        .HasForeignKey("WorkItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Project");

                    b.Navigation("WorkItem");
                });

            modelBuilder.Entity("TimeTracker.Data.Models.WorkItem", b =>
                {
                    b.HasOne("TimeTracker.Data.Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TimeTracker.Data.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TimeTracker.Data.Models.WorkItem", null)
                        .WithMany("Subtasks")
                        .HasForeignKey("WorkItemId");

                    b.Navigation("Creator");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("TimeTracker.Data.Models.Organisation", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("TimeTracker.Data.Models.WorkItem", b =>
                {
                    b.Navigation("Records");

                    b.Navigation("Subtasks");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using ArzTalep.BL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ArzTalep.BusinessLayer.Migrations
{
    [DbContext(typeof(ArzTalepDbContext))]
    [Migration("20210530110611_baseentitty_upgrade")]
    partial class baseentitty_upgrade
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ArzTalep.BL.Model.Campaign", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("ProductID");

                    b.Property<int>("Status");

                    b.Property<int>("UserCreated");

                    b.Property<int>("UserModified");

                    b.HasKey("ID");

                    b.HasIndex("ProductID");

                    b.ToTable("Campaigns");
                });

            modelBuilder.Entity("ArzTalep.BL.Model.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("Status");

                    b.Property<int>("UserCreated");

                    b.Property<int>("UserModified");

                    b.HasKey("ID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Aware.File.Model.FileRelation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("FileName");

                    b.Property<string>("Path");

                    b.Property<int>("RelationId");

                    b.Property<int>("RelationType");

                    b.Property<string>("SortOrder");

                    b.Property<int>("Status");

                    b.Property<int>("Type");

                    b.Property<int>("UserCreated");

                    b.Property<int>("UserModified");

                    b.HasKey("ID");

                    b.ToTable("FileRelations");
                });

            modelBuilder.Entity("Aware.Mail.MailTemplate", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("ParentID");

                    b.Property<int>("Status");

                    b.Property<string>("Subject");

                    b.Property<int>("UserCreated");

                    b.Property<int>("UserModified");

                    b.HasKey("ID");

                    b.ToTable("MailTemplates");
                });

            modelBuilder.Entity("Aware.Model.ApplicationModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AllowedIps");

                    b.Property<string>("ClientID");

                    b.Property<string>("ClientSecret");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<short>("IsPublic");

                    b.Property<string>("Name");

                    b.Property<string>("SmtpPassword");

                    b.Property<int>("SmtpPort");

                    b.Property<string>("SmtpServer");

                    b.Property<string>("SmtpUsername");

                    b.Property<int>("Status");

                    b.Property<int>("UserCreated");

                    b.Property<int>("UserModified");

                    b.HasKey("ID");

                    b.ToTable("Applicatin");
                });

            modelBuilder.Entity("Aware.Model.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyID");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Email");

                    b.Property<int>("Gender");

                    b.Property<DateTime>("LastVisit");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("PhoneNumber");

                    b.Property<int>("Role");

                    b.Property<int>("Status");

                    b.Property<int>("UserCreated");

                    b.Property<int>("UserModified");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Aware.Util.Lookup.Lookup", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("ExtraData");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<int>("Status");

                    b.Property<int>("Type");

                    b.Property<int>("UserCreated");

                    b.Property<int>("UserModified");

                    b.Property<string>("Value");

                    b.HasKey("ID");

                    b.ToTable("Lookup");
                });

            modelBuilder.Entity("ArzTalep.BL.Model.Campaign", b =>
                {
                    b.HasOne("ArzTalep.BL.Model.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
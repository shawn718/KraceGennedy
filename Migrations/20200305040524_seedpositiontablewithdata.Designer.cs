﻿// <auto-generated />
using System;
using KraceGennedy.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KraceGennedy.Migrations
{
    [DbContext(typeof(KraceGennedyContext))]
    [Migration("20200305040524_seedpositiontablewithdata")]
    partial class seedpositiontablewithdata
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KraceGennedy.Models.Employee", b =>
                {
                    b.Property<string>("EmployeeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Branch")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("DOB")
                        .IsRequired()
                        .HasColumnType("varchar(35)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<int>("PositionID")
                        .HasColumnType("int");

                    b.Property<string>("Telephone")
                        .HasColumnType("varchar(100)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("CityID");

                    b.HasIndex("PositionID");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("KraceGennedy.Models.EmployeeCity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CityName = "Parish of Saint Andrew"
                        },
                        new
                        {
                            ID = 2,
                            CityName = "Kingston"
                        },
                        new
                        {
                            ID = 3,
                            CityName = "Parish of Saint James"
                        },
                        new
                        {
                            ID = 4,
                            CityName = "Montego Bay"
                        },
                        new
                        {
                            ID = 5,
                            CityName = "Parish of Westmoreland"
                        },
                        new
                        {
                            ID = 6,
                            CityName = "Whitehall"
                        },
                        new
                        {
                            ID = 7,
                            CityName = "Parish of Saint Catherine"
                        },
                        new
                        {
                            ID = 8,
                            CityName = "Rest Pen"
                        },
                        new
                        {
                            ID = 9,
                            CityName = "Portmore"
                        },
                        new
                        {
                            ID = 10,
                            CityName = "Beacon Hill"
                        },
                        new
                        {
                            ID = 11,
                            CityName = "Parish of Trelawny"
                        },
                        new
                        {
                            ID = 12,
                            CityName = "Albert Town"
                        },
                        new
                        {
                            ID = 13,
                            CityName = "Parish of Saint Ann"
                        },
                        new
                        {
                            ID = 14,
                            CityName = "Bamboo"
                        },
                        new
                        {
                            ID = 15,
                            CityName = "Parish of Clarendon"
                        },
                        new
                        {
                            ID = 16,
                            CityName = "Bryans Pen"
                        },
                        new
                        {
                            ID = 17,
                            CityName = "Parish of Hanover"
                        },
                        new
                        {
                            ID = 18,
                            CityName = "Lucea"
                        },
                        new
                        {
                            ID = 19,
                            CityName = "Phoenix Park"
                        },
                        new
                        {
                            ID = 20,
                            CityName = "Parish of Portland"
                        },
                        new
                        {
                            ID = 21,
                            CityName = "Port Antonio"
                        },
                        new
                        {
                            ID = 22,
                            CityName = "Parish of Saint Mary"
                        },
                        new
                        {
                            ID = 23,
                            CityName = "Mannings Town"
                        },
                        new
                        {
                            ID = 24,
                            CityName = "Bull Bay"
                        },
                        new
                        {
                            ID = 25,
                            CityName = "Sandy Bay"
                        },
                        new
                        {
                            ID = 26,
                            CityName = "August Town"
                        },
                        new
                        {
                            ID = 27,
                            CityName = "Gregory Park"
                        },
                        new
                        {
                            ID = 28,
                            CityName = "Parish of Saint Elizabeth"
                        },
                        new
                        {
                            ID = 29,
                            CityName = "Hopewell"
                        },
                        new
                        {
                            ID = 30,
                            CityName = "Bethlehem"
                        },
                        new
                        {
                            ID = 31,
                            CityName = "Little London"
                        },
                        new
                        {
                            ID = 32,
                            CityName = "Albert Arms"
                        },
                        new
                        {
                            ID = 33,
                            CityName = "Lionel Town"
                        },
                        new
                        {
                            ID = 34,
                            CityName = "Harbour View"
                        },
                        new
                        {
                            ID = 35,
                            CityName = "Clarks Town"
                        },
                        new
                        {
                            ID = 36,
                            CityName = "Bog Walk"
                        },
                        new
                        {
                            ID = 37,
                            CityName = "Passage Fort"
                        },
                        new
                        {
                            ID = 38,
                            CityName = "Minho"
                        },
                        new
                        {
                            ID = 39,
                            CityName = "Plum Corner"
                        },
                        new
                        {
                            ID = 40,
                            CityName = "Liberty Valley"
                        },
                        new
                        {
                            ID = 41,
                            CityName = "Stony Hill"
                        },
                        new
                        {
                            ID = 42,
                            CityName = "Up Park Camp"
                        },
                        new
                        {
                            ID = 43,
                            CityName = "Santa Maria"
                        },
                        new
                        {
                            ID = 44,
                            CityName = "Parish of Saint Thomas"
                        },
                        new
                        {
                            ID = 45,
                            CityName = "Old Lee Gate"
                        },
                        new
                        {
                            ID = 46,
                            CityName = "Mount Nebo"
                        },
                        new
                        {
                            ID = 47,
                            CityName = "Central Village"
                        },
                        new
                        {
                            ID = 48,
                            CityName = "Clarendon Park"
                        },
                        new
                        {
                            ID = 49,
                            CityName = "Matildas Corner"
                        },
                        new
                        {
                            ID = 50,
                            CityName = "Liguanea"
                        },
                        new
                        {
                            ID = 51,
                            CityName = "Papine"
                        },
                        new
                        {
                            ID = 52,
                            CityName = "Mona Heights"
                        },
                        new
                        {
                            ID = 53,
                            CityName = "Glengoffe"
                        },
                        new
                        {
                            ID = 54,
                            CityName = "Dumblane"
                        },
                        new
                        {
                            ID = 55,
                            CityName = "Comfort Village"
                        },
                        new
                        {
                            ID = 56,
                            CityName = "Rectory"
                        },
                        new
                        {
                            ID = 57,
                            CityName = "Thatch Pen"
                        });
                });

            modelBuilder.Entity("KraceGennedy.Models.Position", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PositionDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PositionName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Positions");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            PositionName = "ITManager"
                        },
                        new
                        {
                            ID = 2,
                            PositionName = "HRManager"
                        },
                        new
                        {
                            ID = 3,
                            PositionName = "SecurityManager"
                        },
                        new
                        {
                            ID = 4,
                            PositionName = "GeneralManager"
                        },
                        new
                        {
                            ID = 5,
                            PositionName = "ITSoftwareDeveloper"
                        },
                        new
                        {
                            ID = 6,
                            PositionName = "HREmployee"
                        },
                        new
                        {
                            ID = 7,
                            PositionName = "CheifFinancialOfficer"
                        },
                        new
                        {
                            ID = 8,
                            PositionName = "CheifExecutiveOfficer"
                        },
                        new
                        {
                            ID = 9,
                            PositionName = "CheifOpperationsOfficer"
                        },
                        new
                        {
                            ID = 10,
                            PositionName = "RegularEmployee"
                        },
                        new
                        {
                            ID = 11,
                            PositionName = "ITSystemAdministrator"
                        });
                });

            modelBuilder.Entity("KraceGennedy.Models.Schedule", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Day")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Hours")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("KraceGennedy.Models.WeatherInfo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Day")
                        .HasColumnType("datetime2");

                    b.Property<string>("WeatherDesc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CityID");

                    b.ToTable("WeatherInfos");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("KraceGennedy.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("KraceGennedy.Models.Employee", b =>
                {
                    b.HasOne("KraceGennedy.Models.EmployeeCity", "City")
                        .WithMany()
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KraceGennedy.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KraceGennedy.Models.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KraceGennedy.Models.Schedule", b =>
                {
                    b.HasOne("KraceGennedy.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID");
                });

            modelBuilder.Entity("KraceGennedy.Models.WeatherInfo", b =>
                {
                    b.HasOne("KraceGennedy.Models.EmployeeCity", "City")
                        .WithMany()
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

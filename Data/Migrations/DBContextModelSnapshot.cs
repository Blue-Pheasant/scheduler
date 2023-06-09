﻿// <auto-generated />
using System;
using Application.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace scheduler.Data.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Application.Data.Entities.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CalendarId")
                        .HasColumnType("int")
                        .HasColumnName("id_calendar");

                    b.Property<DateTime?>("CanceledAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("canceled_at");

                    b.Property<bool>("Editable")
                        .HasColumnType("bit")
                        .HasColumnName("edit_able");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2")
                        .HasColumnName("end");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("location");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2")
                        .HasColumnName("start");

                    b.Property<bool>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("status");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id_user");

                    b.Property<Guid?>("UserId1")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CalendarId");

                    b.HasIndex("UserId");

                    b.HasIndex("UserId1");

                    b.ToTable("appointments");
                });

            modelBuilder.Entity("Application.Data.Entities.AuthToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Blacklisted")
                        .HasColumnType("bit")
                        .HasColumnName("black_listed");

                    b.Property<DateTime>("ExpiresAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("expires_at");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("token");

                    b.Property<int>("Type")
                        .HasColumnType("int")
                        .HasColumnName("type");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("tokens");
                });

            modelBuilder.Entity("Application.Data.Entities.Calendar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BackgroundColor")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("background_color");

                    b.Property<string>("BorderColor")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("border_color");

                    b.Property<string>("DragBackgroundColor")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("drag_background_color");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("calendars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BackgroundColor = "#ffffff",
                            BorderColor = "#000000",
                            DragBackgroundColor = "#cccccc",
                            Name = "Default",
                            UserId = new Guid("39f84ed2-41d7-4f50-c84a-08db59c30ba6")
                        },
                        new
                        {
                            Id = 2,
                            BackgroundColor = "#9e5fff",
                            BorderColor = "#65a94c",
                            DragBackgroundColor = "#839334",
                            Name = "Private",
                            UserId = new Guid("39f84ed2-41d7-4f50-c84a-08db59c30ba6")
                        },
                        new
                        {
                            Id = 3,
                            BackgroundColor = "#00a9ff",
                            BorderColor = "#00a9ff",
                            DragBackgroundColor = "#00a9ff",
                            Name = "Company",
                            UserId = new Guid("39f84ed2-41d7-4f50-c84a-08db59c30ba6")
                        },
                        new
                        {
                            Id = 4,
                            BackgroundColor = "#66cc66",
                            BorderColor = "#66cc66",
                            DragBackgroundColor = "#66cc66",
                            Name = "Vacation",
                            UserId = new Guid("39f84ed2-41d7-4f50-c84a-08db59c30ba6")
                        },
                        new
                        {
                            Id = 5,
                            BackgroundColor = "#ffa500",
                            BorderColor = "#ffa500",
                            DragBackgroundColor = "#ffa500",
                            Name = "Meetings",
                            UserId = new Guid("39f84ed2-41d7-4f50-c84a-08db59c30ba6")
                        },
                        new
                        {
                            Id = 6,
                            BackgroundColor = "#f5f5dc",
                            BorderColor = "#f5f5dc",
                            DragBackgroundColor = "#f5f5dc",
                            Name = "Holidays",
                            UserId = new Guid("39f84ed2-41d7-4f50-c84a-08db59c30ba6")
                        },
                        new
                        {
                            Id = 7,
                            BackgroundColor = "#ff69b4",
                            BorderColor = "#ff69b4",
                            DragBackgroundColor = "#ff69b4",
                            Name = "Birthdays",
                            UserId = new Guid("39f84ed2-41d7-4f50-c84a-08db59c30ba6")
                        },
                        new
                        {
                            Id = 8,
                            BackgroundColor = "#8b0000",
                            BorderColor = "#8b0000",
                            DragBackgroundColor = "#8b0000",
                            Name = "Deadlines",
                            UserId = new Guid("39f84ed2-41d7-4f50-c84a-08db59c30ba6")
                        },
                        new
                        {
                            Id = 9,
                            BackgroundColor = "#00ced1",
                            BorderColor = "#00ced1",
                            DragBackgroundColor = "#00ced1",
                            Name = "Appointments",
                            UserId = new Guid("39f84ed2-41d7-4f50-c84a-08db59c30ba6")
                        },
                        new
                        {
                            Id = 10,
                            BackgroundColor = "#ffd700",
                            BorderColor = "#ffd700",
                            DragBackgroundColor = "#ffd700",
                            Name = "Tasks",
                            UserId = new Guid("39f84ed2-41d7-4f50-c84a-08db59c30ba6")
                        },
                        new
                        {
                            Id = 11,
                            BackgroundColor = "#c05d5d",
                            BorderColor = "#ed0c0c",
                            DragBackgroundColor = "#2c1111",
                            Name = "Van Lang",
                            UserId = new Guid("edb42291-18b6-4713-c84b-08db59c30ba6")
                        });
                });

            modelBuilder.Entity("Application.Data.Entities.Invitation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<int>("AppointmentId")
                        .HasColumnType("int")
                        .HasColumnName("appointment_id");

                    b.Property<DateTime>("ExpiresAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("expires_at");

                    b.Property<Guid>("PartnerId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("partner_id");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.HasIndex("PartnerId");

                    b.ToTable("invitations");
                });

            modelBuilder.Entity("Application.Data.Entities.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit")
                        .HasColumnName("is_read");

                    b.Property<string>("Message")
                        .HasColumnType("text")
                        .HasColumnName("message");

                    b.Property<string>("Title")
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("url");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id_user");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("notifications");
                });

            modelBuilder.Entity("Application.Data.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("39f84ed2-41d7-4f50-c84a-08db59c30ba6"),
                            AccessFailedCount = 0,
                            Address = "Ho Chi Minh",
                            ConcurrencyStamp = "bdb211de-f18a-45e2-a4b0-7635cc97366a",
                            DateOfBirth = new DateTime(2001, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "hoc@scheduler.com",
                            EmailConfirmed = false,
                            FirstName = "Hoc",
                            IsActive = false,
                            LastName = "Tran Van",
                            LockoutEnabled = false,
                            PasswordHash = "$2a$10$SFj9fotNhmDP48wztIk8DOnzCUxDFKDvG7XCqKNXLpfu22JG1Op6y",
                            PhoneNumber = "01269454343",
                            PhoneNumberConfirmed = false,
                            Role = "Admin",
                            TwoFactorEnabled = false
                        },
                        new
                        {
                            Id = new Guid("edb42291-18b6-4713-c84b-08db59c30ba6"),
                            AccessFailedCount = 0,
                            Address = "123 Main St, Anytown, USA",
                            ConcurrencyStamp = "a1a73651-898f-4227-9ec7-509bb1e136da",
                            DateOfBirth = new DateTime(1996, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "cuong@scheduler.com",
                            EmailConfirmed = false,
                            FirstName = "Cuong",
                            IsActive = false,
                            LastName = "Luu",
                            LockoutEnabled = false,
                            PasswordHash = "$2a$10$8AdOnBG5wGiCdyQbzRnQ5e3ULlillR2i6Z1bq.fuF8adASx9da.5S",
                            PhoneNumber = "0979182391",
                            PhoneNumberConfirmed = false,
                            Role = "Client",
                            TwoFactorEnabled = false
                        },
                        new
                        {
                            Id = new Guid("318c212e-c1cf-444a-7ca3-08db602a105a"),
                            AccessFailedCount = 0,
                            Address = "257 Fireweed Ln",
                            ConcurrencyStamp = "4993d8f0-d015-45da-b263-663a9f0fe5f5",
                            DateOfBirth = new DateTime(1954, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "admin@scheduler.com",
                            EmailConfirmed = false,
                            FirstName = "Admin",
                            IsActive = false,
                            LastName = "Demo",
                            LockoutEnabled = false,
                            PasswordHash = "$2a$10$JEcaPhrFMbvgFgeWCppT1.x3eF72wAmg8VPIqH3w28m9pjKY1aFOm",
                            PhoneNumber = "01269454344",
                            PhoneNumberConfirmed = false,
                            Role = "Admin",
                            TwoFactorEnabled = false
                        });
                });

            modelBuilder.Entity("Application.Data.Entities.WorkProvider", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AppointmentId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "AppointmentId");

                    b.HasIndex("AppointmentId");

                    b.ToTable("works_providers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Application.Data.Entities.Appointment", b =>
                {
                    b.HasOne("Application.Data.Entities.Calendar", "Calendar")
                        .WithMany()
                        .HasForeignKey("CalendarId")
                        .HasConstraintName("appointments_calendar_topic")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Application.Data.Entities.User", "Initiator")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("appointments_users_owner")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Application.Data.Entities.User", null)
                        .WithMany("Appointments")
                        .HasForeignKey("UserId1");

                    b.Navigation("Calendar");

                    b.Navigation("Initiator");
                });

            modelBuilder.Entity("Application.Data.Entities.AuthToken", b =>
                {
                    b.HasOne("Application.Data.Entities.User", "User")
                        .WithMany("Tokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Application.Data.Entities.Calendar", b =>
                {
                    b.HasOne("Application.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_calendar_user")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Application.Data.Entities.Invitation", b =>
                {
                    b.HasOne("Application.Data.Entities.Appointment", "Appointment")
                        .WithMany()
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Application.Data.Entities.User", "Partner")
                        .WithMany()
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Appointment");

                    b.Navigation("Partner");
                });

            modelBuilder.Entity("Application.Data.Entities.Notification", b =>
                {
                    b.HasOne("Application.Data.Entities.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Application.Data.Entities.WorkProvider", b =>
                {
                    b.HasOne("Application.Data.Entities.Appointment", "Appointment")
                        .WithMany("Providers")
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Application.Data.Entities.User", "User")
                        .WithMany("WorkProviders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Appointment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Application.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Application.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Application.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Application.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Application.Data.Entities.Appointment", b =>
                {
                    b.Navigation("Providers");
                });

            modelBuilder.Entity("Application.Data.Entities.User", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Notifications");

                    b.Navigation("Tokens");

                    b.Navigation("WorkProviders");
                });
#pragma warning restore 612, 618
        }
    }
}

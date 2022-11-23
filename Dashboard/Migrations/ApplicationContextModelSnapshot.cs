﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Dashboard.Migrations
{
	[DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Dashboard.Entities.CssColor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Value")
                        .HasColumnType("text")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.ToTable("csscolors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Value = "primary"
                        },
                        new
                        {
                            Id = 2,
                            Value = "secondary"
                        },
                        new
                        {
                            Id = 3,
                            Value = "success"
                        },
                        new
                        {
                            Id = 4,
                            Value = "danger"
                        },
                        new
                        {
                            Id = 5,
                            Value = "warning"
                        },
                        new
                        {
                            Id = 6,
                            Value = "light"
                        },
                        new
                        {
                            Id = 7,
                            Value = "dark"
                        });
                });

            modelBuilder.Entity("Dashboard.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "user"
                        });
                });

            modelBuilder.Entity("Dashboard.Entities.Tile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("BorderColorId")
                        .HasColumnType("integer")
                        .HasColumnName("border_color_id");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Link")
                        .HasColumnType("text")
                        .HasColumnName("link");

                    b.Property<string>("LinkName")
                        .HasColumnType("text")
                        .HasColumnName("link_name");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("Number")
                        .HasColumnType("integer")
                        .HasColumnName("number");

                    b.Property<int>("TextColorId")
                        .HasColumnType("integer")
                        .HasColumnName("text_color_id");

                    b.Property<bool>("TurnOn")
                        .HasColumnType("boolean")
                        .HasColumnName("turn_on");

                    b.HasKey("Id");

                    b.HasIndex("BorderColorId");

                    b.HasIndex("TextColorId");

                    b.ToTable("tiles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BorderColorId = 2,
                            Description = "описание плитки",
                            Link = "http://localhost",
                            LinkName = "Перейти",
                            Name = "Плитка 1",
                            Number = 1,
                            TextColorId = 1,
                            TurnOn = true
                        },
                        new
                        {
                            Id = 2,
                            BorderColorId = 2,
                            Description = "описание плитки",
                            Link = "http://localhost",
                            LinkName = "Перейти",
                            Name = "Плитка 2",
                            Number = 2,
                            TextColorId = 1,
                            TurnOn = true
                        },
                        new
                        {
                            Id = 3,
                            BorderColorId = 2,
                            Description = "описание плитки",
                            Link = "http://localhost",
                            LinkName = "Перейти",
                            Name = "Плитка 3",
                            Number = 3,
                            TextColorId = 1,
                            TurnOn = true
                        },
                        new
                        {
                            Id = 4,
                            BorderColorId = 2,
                            Description = "описание плитки",
                            Link = "http://localhost",
                            LinkName = "Перейти",
                            Name = "Плитка 4",
                            Number = 4,
                            TextColorId = 1,
                            TurnOn = true
                        },
                        new
                        {
                            Id = 5,
                            BorderColorId = 2,
                            Description = "описание плитки",
                            Link = "http://localhost",
                            LinkName = "Перейти",
                            Name = "Плитка 5",
                            Number = 5,
                            TextColorId = 1,
                            TurnOn = true
                        });
                });

            modelBuilder.Entity("Dashboard.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<int?>("RoleId")
                        .HasColumnType("integer")
                        .HasColumnName("role_id");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@dashboard.com",
                            IsActive = true,
                            Name = "Администратор",
                            Password = "92AB2C1C8F150F5EDFBA5DB5F640FB47",
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("Dashboard.Entities.Tile", b =>
                {
                    b.HasOne("Dashboard.Entities.CssColor", "BorderColor")
                        .WithMany()
                        .HasForeignKey("BorderColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dashboard.Entities.CssColor", "TextColor")
                        .WithMany()
                        .HasForeignKey("TextColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BorderColor");

                    b.Navigation("TextColor");
                });

            modelBuilder.Entity("Dashboard.Entities.User", b =>
                {
                    b.HasOne("Dashboard.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Dashboard.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DAL.Migrations
{
    [DbContext(typeof(PostgreSqlContext))]
    [Migration("20220817135900_UpdatingEGITModels")]
    partial class UpdatingEGITModels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("DAL.Models.Client", b =>
                {
                    b.Property<int>("ClientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Bandwidth")
                        .HasColumnType("integer");

                    b.Property<string>("ClientName")
                        .HasColumnType("text");

                    b.Property<string>("ClientSector")
                        .HasColumnType("text");

                    b.Property<int>("CurrentVMs")
                        .HasColumnType("integer");

                    b.Property<int>("ISPID")
                        .HasColumnType("integer");

                    b.Property<int>("PublicIps")
                        .HasColumnType("integer");

                    b.Property<int>("TotalVMs")
                        .HasColumnType("integer");

                    b.Property<int>("VPNClients")
                        .HasColumnType("integer");

                    b.HasKey("ClientID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("DAL.Models.Cluster", b =>
                {
                    b.Property<int>("ClusterID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClusterName")
                        .HasColumnType("text");

                    b.Property<string>("ClusterType")
                        .HasColumnType("text");

                    b.HasKey("ClusterID");

                    b.ToTable("Clusters");
                });

            modelBuilder.Entity("DAL.Models.Lun", b =>
                {
                    b.Property<int>("LunID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("LunName")
                        .HasColumnType("text");

                    b.Property<int>("LunStorage")
                        .HasColumnType("integer");

                    b.Property<int>("StorageID")
                        .HasColumnType("integer");

                    b.HasKey("LunID");

                    b.HasIndex("StorageID");

                    b.ToTable("Luns");
                });

            modelBuilder.Entity("DAL.Models.Node", b =>
                {
                    b.Property<int>("NodeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ClusterID")
                        .HasColumnType("integer");

                    b.Property<string>("NodeName")
                        .HasColumnType("text");

                    b.Property<string>("NodeType")
                        .HasColumnType("text");

                    b.Property<int>("RemainingCPUCores")
                        .HasColumnType("integer");

                    b.Property<int>("RemainingRAM")
                        .HasColumnType("integer");

                    b.Property<int>("TotalCPUCores")
                        .HasColumnType("integer");

                    b.Property<int>("TotalRAM")
                        .HasColumnType("integer");

                    b.HasKey("NodeID");

                    b.HasIndex("ClusterID");

                    b.ToTable("Nodes");
                });

            modelBuilder.Entity("DAL.Models.Storage", b =>
                {
                    b.Property<int>("StorageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("StorageName")
                        .HasColumnType("text");

                    b.Property<int>("StorageRSpace")
                        .HasColumnType("integer");

                    b.Property<int>("StorageTSpace")
                        .HasColumnType("integer");

                    b.Property<string>("StorageType")
                        .HasColumnType("text");

                    b.HasKey("StorageID");

                    b.ToTable("Storages");
                });

            modelBuilder.Entity("DAL.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("HomeAddress")
                        .HasColumnType("text");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsPowerUser")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("PassportNumber")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DAL.Models.Lun", b =>
                {
                    b.HasOne("DAL.Models.Storage", "Storage")
                        .WithMany()
                        .HasForeignKey("StorageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Storage");
                });

            modelBuilder.Entity("DAL.Models.Node", b =>
                {
                    b.HasOne("DAL.Models.Cluster", "Cluster")
                        .WithMany()
                        .HasForeignKey("ClusterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cluster");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Saleforce.Permissions.Api.Persistence.EntityFramework;

namespace Saleforce.Permissions.Api.Migrations
{
    [DbContext(typeof(PermissionsDbContext))]
    partial class PermissionsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Saleforce.Permissions.Api.Entities.Delivery", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Data");

                    b.Property<string>("DeliveryApprovalId");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryApprovalId")
                        .IsUnique();

                    b.ToTable("Deliveries");
                });

            modelBuilder.Entity("Saleforce.Permissions.Api.Entities.DeliveryApproval", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Status");

                    b.Property<string>("UserInfoId");

                    b.HasKey("Id");

                    b.HasIndex("UserInfoId");

                    b.ToTable("DeliveryApprovals");
                });

            modelBuilder.Entity("Saleforce.Permissions.Api.Entities.Permission", b =>
                {
                    b.Property<string>("PermissionType")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("PermissionType");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("Saleforce.Permissions.Api.Entities.Role", b =>
                {
                    b.Property<string>("RoleType")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("RoleType");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Saleforce.Permissions.Api.Entities.RolePermissions", b =>
                {
                    b.Property<string>("RoleType");

                    b.Property<string>("PermissionType");

                    b.HasKey("RoleType", "PermissionType");

                    b.HasIndex("PermissionType");

                    b.ToTable("RolePermissions");
                });

            modelBuilder.Entity("Saleforce.Permissions.Api.Entities.UserInfo", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.HasKey("Id");

                    b.ToTable("UserInfos");
                });

            modelBuilder.Entity("Saleforce.Permissions.Api.Entities.UserPermissions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Connector")
                        .IsRequired();

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("DataScope")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<DateTimeOffset?>("ExpireDate");

                    b.Property<string>("PermissionType")
                        .IsRequired();

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.Property<int>("UserRolesId");

                    b.HasKey("Id");

                    b.HasIndex("PermissionType");

                    b.HasIndex("UserRolesId");

                    b.ToTable("UserPermissions");
                });

            modelBuilder.Entity("Saleforce.Permissions.Api.Entities.UserRoles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Connector");

                    b.Property<string>("DataScope")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<DateTimeOffset?>("ExpireDate");

                    b.Property<string>("RoleType")
                        .IsRequired();

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleType");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Saleforce.Permissions.Api.Entities.Delivery", b =>
                {
                    b.HasOne("Saleforce.Permissions.Api.Entities.DeliveryApproval", "DeliveryApproval")
                        .WithOne("Delivery")
                        .HasForeignKey("Saleforce.Permissions.Api.Entities.Delivery", "DeliveryApprovalId");
                });

            modelBuilder.Entity("Saleforce.Permissions.Api.Entities.DeliveryApproval", b =>
                {
                    b.HasOne("Saleforce.Permissions.Api.Entities.UserInfo", "UserInfo")
                        .WithMany("DeliveryApprovals")
                        .HasForeignKey("UserInfoId");
                });

            modelBuilder.Entity("Saleforce.Permissions.Api.Entities.RolePermissions", b =>
                {
                    b.HasOne("Saleforce.Permissions.Api.Entities.Permission", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermissionType")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Saleforce.Permissions.Api.Entities.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleType")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Saleforce.Permissions.Api.Entities.UserPermissions", b =>
                {
                    b.HasOne("Saleforce.Permissions.Api.Entities.Permission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionType")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Saleforce.Permissions.Api.Entities.UserRoles", "UserRoles")
                        .WithMany()
                        .HasForeignKey("UserRolesId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Saleforce.Permissions.Api.Entities.UserRoles", b =>
                {
                    b.HasOne("Saleforce.Permissions.Api.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleType")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

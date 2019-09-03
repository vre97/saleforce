﻿using Microsoft.EntityFrameworkCore;
using Saleforce.Permissions.Api.Entities;

namespace Saleforce.Permissions.Api.Persistence.EntityFramework
{
    public class PermissionsDbContext : DbContext
    {
        public PermissionsDbContext(DbContextOptions<PermissionsDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<UserPermissions> UserPermissions { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<RolePermissions> RolePermissions { get; set; }

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<UserRoles> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureRoleTypePrimaryKey();
            modelBuilder.ConfigurePermissionPrimaryKey();
            modelBuilder.ConfigureRolePermissionsPrimaryKey();
            modelBuilder.ConfigureUserPermissions();
            modelBuilder.ConfigureUserRoles();
        }
    }
}
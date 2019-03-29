using System;
using Microsoft.EntityFrameworkCore;

namespace Custom_identity_Schema.DataModel
{
    public class CustomDataContext : DbContext
    {
        public CustomDataContext(DbContextOptions<CustomDataContext> options) : base(options)
        {
        }

        public DbSet<CusUser> Users {  get;set; }
        public DbSet<CusRole> Roles {  get;set; }
        public DbSet<CusUserRole> UserRoles { get;set; }
    }
}

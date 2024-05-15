﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace THWEB.Data
{
    public class BookAuthConnection : IdentityDbContext<IdentityUser>
    {
        public BookAuthConnection(DbContextOptions<BookAuthConnection> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var readerRoleId = "004c7e807dfc44be89522c7130898655";
            var writeRoleId = "71e282d376ca485eb094eff019287fa5";

            base.OnModelCreating(builder);

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerRoleId,
                    ConcurrencyStamp = readerRoleId,
                    Name = "Read",
                    NormalizedName = "Read".ToUpper()
                },
                new IdentityRole
                {
                    Id = writeRoleId,
                    ConcurrencyStamp = writeRoleId,
                    Name = "Write",
                    NormalizedName = "Write".ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}

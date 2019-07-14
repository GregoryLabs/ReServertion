﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ServerReservation.Areas.Identity.Models;
using ServerReservation.Models;

namespace ServerReservation.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        #region Models
        public DbSet<Request> Requests { get; set; }
        public DbSet<Server> Servers { get; set; }
        #endregion
    }
}

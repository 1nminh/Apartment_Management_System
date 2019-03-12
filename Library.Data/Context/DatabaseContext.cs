using Library.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Account> PersonInformation { get; set; }
        public DbSet<FeedBack> FeedBack { get; set; }
        public DbSet<Apartment> Apartment { get; set; }
        public DbSet<RoomType> RoomType { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<PendingRequest> PendingRequest { get; set; }
        public DbSet<Period> Period { get; set; }
        public DbSet<RoomPayLog> RoomPayLog { get; set; }
        public DbSet<ServicePaycheck> ServicePayCheck { get; set; }
        public DbSet<Service> Service { get; set; }
        public DatabaseContext() : base("AMS") { }
    }
}

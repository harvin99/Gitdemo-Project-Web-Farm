﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLTro
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RoomManagerEntities2 : DbContext
    {
        public RoomManagerEntities2()
            : base("name=RoomManagerEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ImagesRoomCategory> ImagesRoomCategories { get; set; }
        public virtual DbSet<RoomCategory> RoomCategories { get; set; }
        public virtual DbSet<RentRoom> RentRooms { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<UsedService> UsedServices { get; set; }
        public virtual DbSet<USDDetail> USDDetails { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
    }
}

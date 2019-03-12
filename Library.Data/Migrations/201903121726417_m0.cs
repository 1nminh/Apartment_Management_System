namespace Library.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m0 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Apartments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        TotalLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ApartmentID = c.Int(nullable: false),
                        RoomTypeID = c.Int(nullable: false),
                        RoomName = c.String(),
                        Capacity = c.Int(nullable: false),
                        Floor = c.Int(nullable: false),
                        Available = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Apartments", t => t.ApartmentID, cascadeDelete: true)
                .ForeignKey("dbo.RoomTypes", t => t.RoomTypeID, cascadeDelete: true)
                .Index(t => t.ApartmentID)
                .Index(t => t.RoomTypeID);
            
            CreateTable(
                "dbo.PendingRequests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 128),
                        ChoosenRoomID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false, storeType: "date"),
                        Pending = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Accounts", t => t.Username)
                .ForeignKey("dbo.Rooms", t => t.ChoosenRoomID, cascadeDelete: true)
                .Index(t => t.Username)
                .Index(t => t.ChoosenRoomID);
            
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Sex = c.String(),
                        IdCardNumber = c.String(),
                        Nationality = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        DateOfBirth = c.DateTime(nullable: false, storeType: "date"),
                        Balance = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Username);
            
            CreateTable(
                "dbo.FeedBacks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 128),
                        Content = c.String(),
                        Date = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Accounts", t => t.Username)
                .Index(t => t.Username);
            
            CreateTable(
                "dbo.Periods",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 128),
                        RoomID = c.Int(nullable: false),
                        JoinedDate = c.DateTime(nullable: false, storeType: "date"),
                        ExpiryDate = c.DateTime(nullable: false, storeType: "date"),
                        isActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Accounts", t => t.Username)
                .ForeignKey("dbo.Rooms", t => t.RoomID, cascadeDelete: true)
                .Index(t => t.Username)
                .Index(t => t.RoomID);
            
            CreateTable(
                "dbo.RoomPayLogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PeriodID = c.Int(nullable: false),
                        Username = c.String(maxLength: 128),
                        Amount = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false, storeType: "date"),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Accounts", t => t.Username)
                .ForeignKey("dbo.Periods", t => t.PeriodID, cascadeDelete: true)
                .Index(t => t.PeriodID)
                .Index(t => t.Username);
            
            CreateTable(
                "dbo.ServicePaychecks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 128),
                        DateCreated = c.DateTime(nullable: false, storeType: "date"),
                        DateOfPayment = c.DateTime(nullable: false, storeType: "date"),
                        ServiceID = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        Money = c.Int(nullable: false),
                        Paid = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Accounts", t => t.Username)
                .ForeignKey("dbo.Services", t => t.ServiceID, cascadeDelete: true)
                .Index(t => t.Username)
                .Index(t => t.ServiceID);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                        Unit = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RoomTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "RoomTypeID", "dbo.RoomTypes");
            DropForeignKey("dbo.PendingRequests", "ChoosenRoomID", "dbo.Rooms");
            DropForeignKey("dbo.ServicePaychecks", "ServiceID", "dbo.Services");
            DropForeignKey("dbo.ServicePaychecks", "Username", "dbo.Accounts");
            DropForeignKey("dbo.RoomPayLogs", "PeriodID", "dbo.Periods");
            DropForeignKey("dbo.RoomPayLogs", "Username", "dbo.Accounts");
            DropForeignKey("dbo.Periods", "RoomID", "dbo.Rooms");
            DropForeignKey("dbo.Periods", "Username", "dbo.Accounts");
            DropForeignKey("dbo.PendingRequests", "Username", "dbo.Accounts");
            DropForeignKey("dbo.FeedBacks", "Username", "dbo.Accounts");
            DropForeignKey("dbo.Rooms", "ApartmentID", "dbo.Apartments");
            DropIndex("dbo.ServicePaychecks", new[] { "ServiceID" });
            DropIndex("dbo.ServicePaychecks", new[] { "Username" });
            DropIndex("dbo.RoomPayLogs", new[] { "Username" });
            DropIndex("dbo.RoomPayLogs", new[] { "PeriodID" });
            DropIndex("dbo.Periods", new[] { "RoomID" });
            DropIndex("dbo.Periods", new[] { "Username" });
            DropIndex("dbo.FeedBacks", new[] { "Username" });
            DropIndex("dbo.PendingRequests", new[] { "ChoosenRoomID" });
            DropIndex("dbo.PendingRequests", new[] { "Username" });
            DropIndex("dbo.Rooms", new[] { "RoomTypeID" });
            DropIndex("dbo.Rooms", new[] { "ApartmentID" });
            DropTable("dbo.RoomTypes");
            DropTable("dbo.Services");
            DropTable("dbo.ServicePaychecks");
            DropTable("dbo.RoomPayLogs");
            DropTable("dbo.Periods");
            DropTable("dbo.FeedBacks");
            DropTable("dbo.Accounts");
            DropTable("dbo.PendingRequests");
            DropTable("dbo.Rooms");
            DropTable("dbo.Apartments");
        }
    }
}

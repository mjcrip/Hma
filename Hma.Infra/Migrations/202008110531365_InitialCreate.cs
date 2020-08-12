namespace Hma.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Blogging.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorId = c.Int(nullable: false),
                        Title = c.String(),
                        Content = c.String(),
                        SectionName = c.String(),
                        MainImage = c.String(),
                        ParagraphContent1 = c.String(),
                        BlockQuote = c.String(),
                        ListItemsCsv = c.String(),
                        ParagraphContent2 = c.String(),
                        ParagraphContent3 = c.String(),
                        ParagraphContent4 = c.String(),
                        ParagraphContent5 = c.String(),
                        Description = c.String(),
                        StorePath = c.String(),
                        IsCreated = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Blogging.Authors", t => t.AuthorId, cascadeDelete: true)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "Blogging.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Blogging.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
            CreateTable(
                "Blogging.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Organization = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Blogging.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        Email = c.String(),
                        Phone = c.String(),
                        City = c.String(),
                        Zip = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Blogging.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Blogging.Articles", "AuthorId", "Blogging.Authors");
            DropForeignKey("Blogging.Authors", "PersonId", "Blogging.People");
            DropForeignKey("Blogging.Contacts", "PersonId", "Blogging.People");
            DropIndex("Blogging.Articles", new[] { "AuthorId" });
            DropIndex("Blogging.Authors", new[] { "PersonId" });
            DropIndex("Blogging.Contacts", new[] { "PersonId" });
            DropTable("Blogging.Contacts");
            DropTable("Blogging.People");
            DropTable("Blogging.Authors");
            DropTable("Blogging.Articles");
        }
    }
}

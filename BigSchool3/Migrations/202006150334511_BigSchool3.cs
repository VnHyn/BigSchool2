namespace BigSchool3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BigSchool3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Name");
        }

        internal class Models
        {
            internal class ApplicationDbContext
            {
                public object Attendances { get; internal set; }

                internal void SaveChanges()
                {
                    throw new NotImplementedException();
                }
            }
        }
    }
}

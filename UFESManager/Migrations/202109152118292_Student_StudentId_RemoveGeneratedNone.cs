namespace UFESManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Student_StudentId_RemoveGeneratedNone : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubjectStudents", "Student_StudentId", "dbo.Students");
            DropPrimaryKey("dbo.Students");
            AlterColumn("dbo.Students", "StudentId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Students", "StudentId");
            AddForeignKey("dbo.SubjectStudents", "Student_StudentId", "dbo.Students", "StudentId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubjectStudents", "Student_StudentId", "dbo.Students");
            DropPrimaryKey("dbo.Students");
            AlterColumn("dbo.Students", "StudentId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Students", "StudentId");
            AddForeignKey("dbo.SubjectStudents", "Student_StudentId", "dbo.Students", "StudentId", cascadeDelete: true);
        }
    }
}

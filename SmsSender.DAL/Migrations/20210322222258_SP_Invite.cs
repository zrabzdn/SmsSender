using Microsoft.EntityFrameworkCore.Migrations;

namespace SmsSender.DAL.Migrations
{
    public partial class SP_Invite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            const string sql = @"
                IF OBJECT_ID('sp_invite', 'P') IS NOT NULL
                DROP PROC sp_invite
                GO
 
                DROP TYPE IF EXISTS [NumberList];
				GO

                CREATE TYPE [dbo].[NumberList] AS TABLE
                (
                    String nvarchar(11)
                )
                GO

                CREATE PROCEDURE [dbo].[sp_invite]
                    @user_id int,
                    @phones [dbo].[NumberList] ReadOnly
                AS
                BEGIN
                    SET NOCOUNT ON;
                    INSERT INTO [dbo].[Invitations] (Id, Phone, Author, Createdon)
                    SELECT NEWID(), p.String, @user_id, GETDATE() FROM @phones AS p
                END";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            const string sql = @"DROP PROCEDURE [dbo].[sp_invite]
                                    GO
                                    DROP TYPE [dbo].[List]";

            migrationBuilder.Sql(sql);
        }
    }
}

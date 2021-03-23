using Microsoft.EntityFrameworkCore.Migrations;

namespace SmsSender.DAL.Migrations
{
    public partial class SP_GetCountInvitations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            const string sql = @"
                IF OBJECT_ID('sp_getcountinvitations', 'P') IS NOT NULL
                DROP PROC sp_getcountinvitations
                GO
 
                CREATE PROCEDURE [dbo].[sp_getcountinvitations]
                    @appid int,
                    @countInvitations int output
                AS
                BEGIN
                    SET NOCOUNT ON;
                    SELECT @countInvitations=COUNT(Id) from [dbo].[Invitations] WHERE CONVERT(DATE, Createdon) = CONVERT(DATE, GETDATE())
                END";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            const string sql = @"DROP PROCEDURE [dbo].[sp_getcountinvitations]";

            migrationBuilder.Sql(sql);
        }
    }
}

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SmsSender.DAL.Core;
using SmsSender.Shared.Interfaces;
using System.Collections.Generic;
using System.Data;

namespace SmsSender.DAL.Repositories
{
    public class InvitationRepository : IInvitationRepository
    {
        private readonly AppDbContext _context;

        public InvitationRepository(AppDbContext context)
        {
            _context = context;
        }

        public void SetInvitations(int userId, IEnumerable<string> phones)
        {
            var user_id = new SqlParameter("@user_id", userId);

            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("String", typeof(string)));
            foreach (var phone in phones)
                table.Rows.Add(phone);

            var phoneNumbers = new SqlParameter("@phones", table) { TypeName = "dbo.NumberList", SqlDbType = SqlDbType.Structured };
     
            _context.Database.ExecuteSqlRaw("sp_invite @user_id, @phones", user_id, phoneNumbers);
        }

        public int GetCountInvitations(int apiId)
        {
            var apiid = new SqlParameter("@apiid", apiId);
            var countInvitations = new SqlParameter
            {
                ParameterName = "@countInvitations",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            _context.Database.ExecuteSqlRaw("sp_getcountinvitations @apiid, @countInvitations OUT", apiid,
                countInvitations);

            return (int)countInvitations.Value;
        }
    }
}

using System;

namespace SmsSender.DAL.Entities
{
    public class Invitation
    {
        public Guid Id { get; set; }

        public string PhoneNumber { get; set; }

        public int AuthorId { get; set; }

        public DateTime CreationDate { get; set; }
    }
}

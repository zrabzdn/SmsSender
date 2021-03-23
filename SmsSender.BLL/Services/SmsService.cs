using SmsSender.BLL.Interfaces;

namespace SmsSender.BLL.Services
{
    public class SmsService : ISmsService
    {
        public void Send(string phoneNumber, string message)
        {
            // TODO: Mock SMS provider service
        }
    }
}

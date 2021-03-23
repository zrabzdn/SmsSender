
namespace SmsSender.BLL.Interfaces
{
    public interface ISmsService
    {
        void Send(string phoneNumber, string message);
    }
}

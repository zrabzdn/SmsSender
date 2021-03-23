
namespace SmsSender.BLL.Interfaces
{
    public interface IRequestValidationService<in T>
    {
        void ValidateRequest(T request);
    }
}

using SmsSender.BLL.Exceptions;
using SmsSender.BLL.Interfaces;
using SmsSender.BLL.Services;
using SmsSender.Shared.Contracts.DTOs;
using Xunit;

namespace SmsSender.BLL.Test
{
    public class SendInvitesRequestValidationServiceTest
    {
        private ISendInvitesRequestValidationService<SendInvitesDto> srv = new SendInvitesRequestValidationService();

        [Fact]
        public void Test_ValidateRequest_Empty_PhoneNumber()
        {
            // Arrange
            var dto = new SendInvitesDto { Message = "some messsage", PhoneNumbers = new[] { string.Empty } };

            // Act & Assert
            Assert.Throws<ValidationException>(() => srv.ValidateRequest(dto));
        }

        [Fact]
        public void Test_ValidateRequest_PHONE_NUMBERS_INVALID()
        {
            // Arrange
            var dto = new SendInvitesDto { Message = "some messsage", PhoneNumbers = new[] { "89968885569" } };

            // Act & Assert
            Assert.Throws<ValidationException>(() => srv.ValidateRequest(dto));
        }

        [Fact]
        public void Test_ValidateRequest_PHONE_NUMBERS_VALID()
        {
            // Arrange
            var dto = new SendInvitesDto { Message = "some messsage", PhoneNumbers = new[] { "79968885569" } };

            // Act
            var exception = Record.Exception(() => srv.ValidateRequest(dto));

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public void Test_ValidateRequest_PHONE_NUMBERS_DUPLICATE()
        {
            // Arrange
            var dto = new SendInvitesDto { Message = "some messsage", PhoneNumbers = new[] { "79067891234", "79067891234" } };

            // Act & Assert
            Assert.Throws<ValidationException>(() => srv.ValidateRequest(dto));
        }
    }
}

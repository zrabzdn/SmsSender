using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmsSender.BLL.Exceptions;
using System;

namespace SmsSender.WebApi.Controllers
{
    public class DefaultController : ControllerBase
    {
        protected IActionResult CallBLAction<T>(Func<T> action)
        {
            try
            {
                var result = action.Invoke();
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{AppDomain.CurrentDomain.FriendlyName} : {ex.Message}");
            }
        }
    }
}

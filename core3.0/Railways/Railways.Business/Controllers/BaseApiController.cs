using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Railways.Business.Business;

namespace Railways.Business.Controllers
{
    [Route("railways")]
    public abstract class BaseApiController : ControllerBase
    {
        /// <summary>
        /// Creates response from result
        /// </summary>
        protected IActionResult FromResult<T>(Result<T> result)
        {
            return StatusCode((int)result.ErrorCode, new
            {
                Error = new
                {
                    Code = result.ErrorCode,
                    Message = result.Message
                }
            });
        }

        /// <summary>
        /// Creates error response from result
        /// </summary>
        protected IActionResult ErrorResult(HttpStatusCode code, string message)
        {
            return StatusCode((int)code, new
            {
                Error = new
                {
                    Code = code,
                    Message = message
                }
            });
        }
    }
}
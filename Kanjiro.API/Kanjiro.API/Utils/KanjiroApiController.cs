using Kanjiro.API.Models.Model;
using Kanjiro.API.Utils.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Kanjiro.API.Utils
{
    public static class KanjiroApiController
    {
        static string mensagemErroInesperadoApi = "Ocorreu um erro inesperado na API. Verifique os logs para mais informações.";

        public static async Task<ActionResult<ServiceResponse<T>>> HandleRequest<T>(Func<Task<T>> action)
        {
            try
            {
                return new OkObjectResult(ServiceResponse<T>.SuccessResponse(await action()));
            }
            catch (KanjiroCustomException ex)
            {
                return new BadRequestObjectResult(ServiceResponse<T>.FailResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return new ObjectResult(mensagemErroInesperadoApi) { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }
    }
}

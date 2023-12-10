using System.Net;
using System.Text.Json;
using VEZEETA.API.Models;

namespace APILayer.Middlrewares
{
    public class MiddlewareException
    {
        private readonly RequestDelegate _next;

        public MiddlewareException(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                HandleException(context, ex);
            }
        }

        private async void HandleException(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            var Response = new CustomResponse();

            switch (context.Response.StatusCode)
            {
                case 204:
                    Response.StatusCode = (int)HttpStatusCode.NoContent;
                    Response.Message = ex.Message;
                    Response.Details = "No Content";
                    break;
                case 400:
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    Response.Message = ex.Message;
                    Response.Details = "Bad request";
                    break;
                case 401:
                    Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    Response.Message = ex.Message;
                    Response.Details = "UnAuthorized";
                    break;
                case 404:
                    Response.StatusCode = (int)HttpStatusCode.NotFound; 
                    Response.Message = ex.Message;
                    Response.Details = "Not Found";
                    break;
                default:
                    Response.StatusCode = (int)HttpStatusCode.InternalServerError; 
                    Response.Message = ex.Message;
                    Response.Details = "Internal Server Error";
                    break;
            }

            var json = JsonSerializer.Serialize(Response);

            await context.Response.WriteAsync(json);
        }
    }
}

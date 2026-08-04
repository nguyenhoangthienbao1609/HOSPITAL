using System.Net;
using System.Text.Json;

namespace THUCTAP.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Cho phép Request đi tiếp vào các Middleware khác và lọt vào Controller
                await _next(context);
            }
            catch (Exception ex)
            {
                // Nếu Controller (hoặc Repository) ném ra bất kỳ lỗi gì, nó sẽ bị tóm tại đây
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Thiết lập kiểu trả về là JSON
            context.Response.ContentType = "application/json";

            // Thiết lập HTTP Status Code là 400 (BadRequest) giống hệt như cách bạn làm cũ
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            // Đóng gói thông báo lỗi
            var response = new
            {
                Message = exception.Message
            };

            // Chuyển đối tượng thành chuỗi JSON và trả về cho Frontend
            var jsonResponse = JsonSerializer.Serialize(response);
            return context.Response.WriteAsync(jsonResponse);
        }
    }
}
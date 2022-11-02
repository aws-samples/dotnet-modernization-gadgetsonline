using GadgetsOnline.Models;
using Microsoft.AspNetCore.Http;

namespace GadgetsOnline.Services
{
    public interface IOrderProcessing
    {
        bool ProcessOrder(Order order, HttpContext httpContext);
    }
}
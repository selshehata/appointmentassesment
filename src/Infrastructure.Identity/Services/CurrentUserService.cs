using Core.Application.Interfaces.Application;
using System.Security.Claims;

namespace Web.Razor.Services
{
    public class CurrentUserService : ICurrentUserService
    {
       

        public string? UserId => "TestUser";
    }
}

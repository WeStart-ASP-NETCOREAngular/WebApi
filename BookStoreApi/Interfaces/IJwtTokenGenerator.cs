using BookStoreApi.Data;
using Microsoft.AspNetCore.Identity;

namespace BookStoreApi.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string Generate(ApplicationUser user);
    }
}

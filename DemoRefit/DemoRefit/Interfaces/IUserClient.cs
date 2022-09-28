using DemoRefit.Models;
using Refit;

namespace DemoRefit.Interfaces
{
    [Headers("Content-Type: application/json")]
    public interface IUserClient
    {
        [Get("/api/home/{id}")]
        Task<UserClient> GetUser(String id);

        [Post("/api/home")]
        Task CreateUser(CreateUserRequest createUserRequest);

        [Post("/api/home/{id}")]
        Task UpdateUser(EditUserRequest editUserRequest, String id);

        [Get("/api/home")]
        Task<PaginatedList<UserClient>> GetAllUser(int? pageNumber);

        [Delete("/api/home/{id}")]
        Task DeleteUser(String id);
    }
}

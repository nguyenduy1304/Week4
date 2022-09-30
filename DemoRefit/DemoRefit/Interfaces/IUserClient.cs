using DemoRefit.Models;
using Refit;

namespace DemoRefit.Interfaces
{
    [Headers("Content-Type: application/json")]
    public interface IUserClient
    {
        [Get("/api/v1/users/{id}")]
        Task<UserClient> GetUser(String id);

        [Post("/api/v1/users")]
        Task CreateUser(CreateUserRequest createUserRequest);

        [Post("/api/v1/users/{id}")]
        Task UpdateUser(EditUserRequest editUserRequest, String id);

        [Get("/api/v1/users")]
        Task<PaginatedList<UserClient>> GetAllUser(int? pageNumber);

        [Delete("/api/v1/users/{id}")]
        Task DeleteUser(String id);
    }
}

using WebAPI.Contract.Requests;
using WebAPI.Contract.Response;
using WebAPI.Persistence.Domains;

namespace WebAPI.Application.Interfaces
{
    public interface IUserSevice
    {
        List<GetUserResponse> GetUsers();
        GetUserResponse GetUserByID(String id);
        String CreateUser(CreateUserRequest createUserRequest);
        void UpdateUser(EditUserRequest editUserRequest, String id);

        EditUserRequest GetEditUserRequest(String id);
        void DeleteUser(String userid);
    }
}

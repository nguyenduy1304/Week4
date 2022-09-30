using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.Interfaces;
using WebAPI.Contract.Requests;

namespace WebAPI.Controllers.V1
{
    
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [EnableCors("Policy")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserSevice _userSevice;

        public readonly IMapper _mapper;
        private IValidator<CreateUserRequest> _validator;
        public UsersController(IUserSevice userSevice,
                              ILogger<UsersController> logger,
                              IMapper mapper,
                              IValidator<CreateUserRequest> validator)
        {
            _userSevice = userSevice;
            _mapper = mapper;
            _logger = logger;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult Index(int? pageNumber)
        {
            var user = _userSevice.GetUsers(pageNumber ?? 1);
            return Ok(user);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetUserById(String id)
        {
            var user = _userSevice.GetUserByID(id);
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser(CreateUserRequest createUserRequest)
        {
            ValidationResult result = _validator.Validate(createUserRequest);
            if (!result.IsValid)
            {
                _logger.LogError("YOU HAVE NOT ENTERED ENOUGH INFORMATION");
                return BadRequest();
            }
            else
            {
                var user = _userSevice.CreateUser(createUserRequest);
                return Ok(user);
            }
        }

        [HttpPost("{id}")]
        public IActionResult EditUser(EditUserRequest editUserRequest, String id)
        {
            _userSevice.UpdateUser(editUserRequest, id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(String id)
        {
            _userSevice.DeleteUser(id);
            return Ok();
        }

    }
}

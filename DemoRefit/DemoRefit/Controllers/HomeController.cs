using DemoRefit.Interfaces;
using DemoRefit.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Data;
using System.Diagnostics;

namespace DemoRefit.Controllers
{
    public class HomeController : Controller
    {
        private IValidator<CreateUserRequest> _validator;
        private readonly ILogger<HomeController> _logger;
        private readonly IUserClient userClient;

        public HomeController(ILogger<HomeController> logger,
                                IValidator<CreateUserRequest> validator)
        {
            _logger = logger;
            _validator = validator;
            userClient = RestService.For<IUserClient>("https://localhost:7088");
        }

        public IActionResult Index()
        {
            var user = userClient.GetAllUser().GetAwaiter().GetResult();
            return View(user);
        }

        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(CreateUserRequest createUserRequest)
        {
            ValidationResult result = _validator.Validate(createUserRequest);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return View("CreateUser", createUserRequest);

            }
            else
            {
                userClient.CreateUser(createUserRequest);
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public async Task<IActionResult> EditUser(String id)
        {
            var userid =await userClient.GetUser(id);
            ViewBag.UserId = id;

            return View(userid);
        }
        [HttpPost]
        public async Task<IActionResult> EditUsers(EditUserRequest editUserRequest, String id)
        {
            ViewBag.UserId = id;
            await userClient.UpdateUser(editUserRequest, id);
            return RedirectToAction("Index");

        }



        public IActionResult DeleteUser(String id)
        {
            try
            {
                userClient.DeleteUser(id);
                _logger.LogInformation("Delete user successfully");
                return RedirectToAction("Index");
            }
            catch (DataException)
            {
                ViewBag.Error = "Delete user Failed";
                return View();
            }
        }







        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
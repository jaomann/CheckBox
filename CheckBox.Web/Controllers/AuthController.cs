using AutoMapper;
using CheckBox.Core.Contracts.entities;
using CheckBox.Core.Entities;
using CheckBox.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CheckBox.Web.Controllers
{
    public class AuthController : Controller
    {
        public IUserService _userService { get; set; }
        public IMapper _mapper { get; set; }
        public AuthController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Login()
        {
            return RedirectToAction("Index", "Note"/*, userlogado*/);
        }
        [HttpPost]
        public IActionResult Register(UserViewModel entity)
        {
            var entityUser = _mapper.Map<User>(entity);
            _userService.Create(entityUser);

            return RedirectToAction("Index", "Home");
        }
    }
}

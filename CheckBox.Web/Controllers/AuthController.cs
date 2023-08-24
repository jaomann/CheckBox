using AutoMapper;
using CheckBox.Core.Contracts.entities;
using CheckBox.Core.Entities;
using CheckBox.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Security.Cryptography;
namespace CheckBox.Web.Controllers
{
    public class AuthController : Controller
    {
        private IUserService _userService { get; set; }
        private INoteService _noteService { get; set; }
        private IMapper _mapper { get; set; }
        public AuthController(IUserService userService, IMapper mapper, INoteService noteService)
        {
            _userService = userService;
            _mapper = mapper;
            _noteService = noteService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserViewModel entity)
        {
            var current_user = _userService.ValidateUser(_mapper.Map<User>(entity));
            if (current_user != null)
            {
                TempData["user_id"] = current_user.Id;
                return RedirectToAction("Index", "Note");
            }
            else
            {
                ViewData["Error"] = "Usuário ou senha incorretos";
                return View();
            }
        }

        [HttpPost]
        public IActionResult Register(UserViewModel entity)
        {
            var entityUser = _mapper.Map<User>(entity);
            entityUser.Password = _userService.GenerateHashCode(entity.Password);
            _userService.Create(entityUser);
            return RedirectToAction("Index", "Auth");
        }
    }
}

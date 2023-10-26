using AutoMapper;
using CheckBox.Core.Contracts.entities;
using CheckBox.Core.Entities;
using CheckBox.Web.Helper;
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
        private ISession _session { get; set; }
        public AuthController(ISession session,IUserService userService, IMapper mapper, INoteService noteService)
        {
            _userService = userService;
            _mapper = mapper;
            _noteService = noteService;
            _session = session;
        }
        public IActionResult Index()
        {
            if(_session.FindUserSession() != null){
                return RedirectToAction("Index","Note"); 
            }
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserViewModel entity)
        {
            var current_user = _mapper.Map<UserViewModel>(_userService.ValidateUser(_mapper.Map<User>(entity)));
            if (current_user != null)
            {
                _session.MakeSession(current_user);
                return RedirectToAction("Index", "Note");
            }
            ViewData["Error"] = "Usuário ou senha incorretos";
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserViewModel entity)
        {
            var entityUser = _mapper.Map<User>(entity);
            entityUser.Password = _userService.GenerateHashCode(entity.Password);
            _userService.Create(entityUser);
            return RedirectToAction("Index", "Auth");
        }
        public IActionResult Logout()
        {
            _session.RemoveSession();
            return RedirectToAction("Index");
        }
    }
}

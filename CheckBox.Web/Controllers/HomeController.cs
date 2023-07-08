using CheckBox.Core.Contracts.entities;
using CheckBox.Core.Entities;
using CheckBox.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CheckBox.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly INoteService _noteService;
        public HomeController(IUserService userService, INoteService noteService)
        {
            _noteService = noteService;
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Guid id)
        {
            var loggedUser = _userService.GetbyID(id);
            return View(loggedUser);
        }
    }
}

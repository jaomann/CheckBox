using AutoMapper;
using CheckBox.Services;
using CheckBox.Web.Helper;
using CheckBox.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CheckBox.Web.Controllers
{
    public class UserController : Controller
    {
        private ISession _session { get; set; }

        public UserController(ISession session)
        {
            _session = session;
        }
        public IActionResult Profile()
        {
            return View(_session.FindUserSession());
        }
    }
}

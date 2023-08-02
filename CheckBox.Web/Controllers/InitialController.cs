using AutoMapper;
using CheckBox.Core.Contracts.entities;
using CheckBox.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckBox.Web.Controllers
{
    public class InitialController : Controller
    {
        private readonly IUserService _userServices;
        private readonly IMapper _mapper;
        private readonly INoteService _noteService;
        public InitialController(IUserService userService, IMapper mapper, INoteService noteService)
        {
            _mapper = mapper;
            _userServices = userService;
            _noteService = noteService;
        }
        public IActionResult Index()
        {
            if (TempData["user_id"] == null)
            {
                ViewData["Error"] = "Você precisa estar logado";
                return RedirectToAction("Index", "Auth");
            }
            else
            {
                Guid id = (Guid)TempData["user_id"];
                var notes = _mapper.Map<IEnumerable<NoteViewModel>>(_noteService.GetAll().Where(x => x.User_Id.Equals(id)));
                var user = _mapper.Map<UserViewModel>(_userServices.GetbyID(id));
                ViewBag.Notes = notes;
                ViewData["user_name"] = user.Name;
            }
            return View();
        }

    }
}

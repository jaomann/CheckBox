using AutoMapper;
using CheckBox.Core.Contracts.entities;
using CheckBox.Core.Entities;
using CheckBox.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckBox.Web.Controllers
{
    public class NoteController : Controller
    {
        private readonly IUserService _userServices;
        private readonly IMapper _mapper;
        private readonly INoteService _noteService;
        public NoteController(IUserService userService, IMapper mapper, INoteService noteService)
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
                var user = _mapper.Map<UserViewModel>(_userServices.GetbyID(id));
                ViewData["user"] = user;
                var notes = _mapper.Map<IEnumerable<NoteViewModel>>(_noteService.GetAll().Where(x => x.UserId.Equals(user.Id)));
                ViewBag.Notes = notes;
                return View();
            }
        }
        public IActionResult Create(Guid id)
        {
            var user = _mapper.Map<UserViewModel>(_userServices.GetbyID(id));
            TempData["user_id"] = id;
            return View(new NoteViewModel() { UserId = id, Born = DateTime.Now});
        }
        [HttpPost]
        public IActionResult Create(NoteViewModel entity)
        {
            TempData["user_id"] = entity.UserId;
            var note = _mapper.Map<Note>(entity);
            note.Id = new Guid();
            _noteService.Create(note);
            return RedirectToAction(nameof(Index));
        }

    }
}

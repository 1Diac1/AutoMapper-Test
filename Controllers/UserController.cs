using AutoMapper;
using AutoMapperTest.Infrastractures;
using AutoMapperTest.Models;
using AutoMapperTest.Repositories;
using AutoMapperTest.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperTest.Controllers
{
    public class UserController : Controller
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserController(IRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var mappedUsers = _mapper.Map<List<IndexUserViewModel>>(_userRepository.GetAll());

            if (mappedUsers == null)
                NotFound();

            return View(mappedUsers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var mappedUser = _mapper.Map<User, EditUserViewModel>(_userRepository.Get(id.Value));

            return View(mappedUser);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var mappedUser = _mapper.Map<DeleteUserViewModel>(_userRepository.Get(id));

            return View(mappedUser);
        }

        [HttpPost]
        public IActionResult Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var mappedUser = _mapper.Map<CreateUserViewModel, User>(model);
                _userRepository.Create(mappedUser);
                _userRepository.Save();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var mappedUser = _mapper.Map<User>(model);

                _userRepository.Update(mappedUser);
                _userRepository.Save();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(DeleteUserViewModel model)
        {
            var mappedUser = _mapper.Map<User>(model);

            _userRepository.Delete(mappedUser);
            _userRepository.Save();

            return RedirectToAction("Index");
        }
    }
}

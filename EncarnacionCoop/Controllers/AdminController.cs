using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EncarnacionCoop.Entities;
using EncarnacionCoop.Models;

namespace EncarnacionCoop.Controllers
{

    public class AdminController : Controller
    {
        private readonly EncarnacioncoopContext _context;

        public AdminController(EncarnacioncoopContext user)
        {
            _context = user;
        }

        public IActionResult Index()
        {
            var user = _context.ClientInfos.ToList();
            return View(user);
        }


        [HttpGet]
        public IActionResult Create()
        {
             var UserType = _context.UserTypes.ToList();
            ViewData["UserType"] = UserType;
            return View();
        }

        [HttpPost]
        public ActionResult Create(ClientInfoViewModel clientinfo)
        {

            if (!ModelState.IsValid)
                return View(clientinfo);
            ClientInfo c = new ClientInfo
            {
                Id = clientinfo.Id,
                UserType = clientinfo.UserType,
                FirstName = clientinfo.FirstName,
                MiddleName = clientinfo.MiddleName,
                LastName = clientinfo.LastName,
                Address = clientinfo.Address,
                ZipCode = clientinfo.ZipCode,
                Birthday = clientinfo.Birthday,
                Age = clientinfo.Age,
                NameOfFather = clientinfo.NameOfFather,
                NameOfMother = clientinfo.NameOfMother,
                CivilStatus = clientinfo.CivilStatus,
                Religion = clientinfo.Religion,
                Occupation = clientinfo.Occupation
            };
            _context.ClientInfos.Add(c);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

         [HttpGet]
        public ActionResult View(int id)
        {
            var clientViewModel = _context.ClientInfos
                .Where(q => q.Id == id)
                .Select(clientupdate => new ClientInfoViewModel
                {
                    Id = clientupdate.Id,
                    UserType = clientupdate.UserType,
                    FirstName = clientupdate.FirstName,
                    MiddleName = clientupdate.MiddleName,
                    LastName = clientupdate.LastName,
                    Address = clientupdate.Address,
                    ZipCode = clientupdate.ZipCode,
                    Birthday = clientupdate.Birthday,
                    Age = clientupdate.Age,
                    NameOfFather = clientupdate.NameOfFather,
                    NameOfMother = clientupdate.NameOfMother,
                    CivilStatus = clientupdate.CivilStatus,
                    Religion = clientupdate.Religion,
                    Occupation = clientupdate.Occupation
                })
                .FirstOrDefault();

            if (clientViewModel == null)
            {
                return NotFound();
            }

            var clientEntity = new EncarnacionCoop.Entities.ClientInfo
            {
                Id = clientViewModel.Id,
                UserType = clientViewModel.UserType,
                FirstName = clientViewModel.FirstName,
                MiddleName = clientViewModel.MiddleName,
                LastName = clientViewModel.LastName,
                Address = clientViewModel.Address,
                ZipCode = clientViewModel.ZipCode,
                Birthday = clientViewModel.Birthday,
                Age = clientViewModel.Age,
                NameOfFather = clientViewModel.NameOfFather,
                NameOfMother = clientViewModel.NameOfMother,
                CivilStatus = clientViewModel.CivilStatus,
                Religion = clientViewModel.Religion,
                Occupation = clientViewModel.Occupation
            };

            return View(clientEntity); // Pass the converted entity to the view
        }


        [HttpGet]
        public ActionResult Update(int id)
        {

            var UserType = _context.UserTypes.ToList();
            ViewData["UserType"] = UserType;
            var clientViewModel = _context.ClientInfos
                .Where(q => q.Id == id)
                .Select(clientupdate => new ClientInfoViewModel
                {
                    Id = clientupdate.Id,
                    UserType = clientupdate.UserType,
                    FirstName = clientupdate.FirstName,
                    MiddleName = clientupdate.MiddleName,
                    LastName = clientupdate.LastName,
                    Address = clientupdate.Address,
                    ZipCode = clientupdate.ZipCode,
                    Birthday = clientupdate.Birthday,
                    Age = clientupdate.Age,
                    NameOfFather = clientupdate.NameOfFather,
                    NameOfMother = clientupdate.NameOfMother,
                    CivilStatus = clientupdate.CivilStatus,
                    Religion = clientupdate.Religion,
                    Occupation = clientupdate.Occupation
                })
                .FirstOrDefault();

            if (clientViewModel == null)
            {
                return NotFound();
            }

            var clientEntity = new EncarnacionCoop.Entities.ClientInfo
            {
                Id = clientViewModel.Id,
                UserType = clientViewModel.UserType,
                FirstName = clientViewModel.FirstName,
                MiddleName = clientViewModel.MiddleName,
                LastName = clientViewModel.LastName,
                Address = clientViewModel.Address,
                ZipCode = clientViewModel.ZipCode,
                Birthday = clientViewModel.Birthday,
                Age = clientViewModel.Age,
                NameOfFather = clientViewModel.NameOfFather,
                NameOfMother = clientViewModel.NameOfMother,
                CivilStatus = clientViewModel.CivilStatus,
                Religion = clientViewModel.Religion,
                Occupation = clientViewModel.Occupation
            };

            return View(clientEntity); // Pass the converted entity to the view
        }

        [HttpPost]
        public ActionResult Update(ClientInfoViewModel clientupdate)
        {
            if (!ModelState.IsValid)
            {
                return View(clientupdate);
            }

            var existingClient = _context.ClientInfos.Find(clientupdate.Id);

            if (existingClient == null)
            {
                return NotFound();
            }

            existingClient.UserType = clientupdate.UserType;
            existingClient.FirstName = clientupdate.FirstName;
            existingClient.MiddleName = clientupdate.MiddleName;
            existingClient.LastName = clientupdate.LastName;
            existingClient.Address = clientupdate.Address;
            existingClient.ZipCode = clientupdate.ZipCode;
            existingClient.Birthday = clientupdate.Birthday;
            existingClient.Age = clientupdate.Age;
            existingClient.NameOfFather = clientupdate.NameOfFather;
            existingClient.NameOfMother = clientupdate.NameOfMother;
            existingClient.CivilStatus = clientupdate.CivilStatus;
            existingClient.Religion = clientupdate.Religion;
            existingClient.Occupation = clientupdate.Occupation;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

         [HttpGet]
        public IActionResult Delete(int id)
        {
            var clientInfo = _context.ClientInfos.Where(q => q.Id == id).FirstOrDefault();
            _context.ClientInfos.Remove(clientInfo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
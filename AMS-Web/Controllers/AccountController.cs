using Library.BLL;
using Library.IBLL;
using Library.Model.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AMS_Web.Controllers
{
    public class AccountController : Controller
    {
        private IRepository<Account> accountRepository;
        
        private readonly string HOMEPAGE = "home";

        public AccountController()
        {
            this.accountRepository = new Repository<Account>();
        }

        public ActionResult Login()
        {
            return View();
        }

        // Post: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            var result = accountRepository.Get(x => x.Username.Equals(username) == true && x.Password.Equals(password) == true);
            if (result != null)
            {
                Session["Username"] = username.ToString();
                if (Session["Username"] != null)
                {
                    return RedirectToAction("Index", "Apartment");
                }
            }
            return RedirectToAction("Login");
        }

        public ActionResult Index(int? pageIndex)
        {
            if (pageIndex == null) pageIndex = 1;
            var result = accountRepository.GetAll().OrderBy(x => x.Username);
            return View(result.ToPagedList((int)pageIndex, 5));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Account account)
        {
            if (string.IsNullOrEmpty(account.Username)) return View();
            if (string.IsNullOrEmpty(account.Password)) return View();
            if (string.IsNullOrEmpty(account.FirstName)) return View();
            if (string.IsNullOrEmpty(account.LastName)) return View();
            if (string.IsNullOrEmpty(account.Sex)) return View();
            if (string.IsNullOrEmpty(account.IdCardNumber)) return View();
            if (string.IsNullOrEmpty(account.Nationality)) return View();

            accountRepository.Create(account);
            return RedirectToAction("Index", "Account");
        }

        public ActionResult Edit(string username)
        {
            var result = accountRepository.Get(x => x.Username.Equals(username));
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(Account account)
        {
            accountRepository.Update(account);
            return RedirectToAction("Index", "Account");
        }

        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(string username)
        {
            accountRepository.Delete(username);
            return RedirectToAction("Index", "Account");
        }

    }
}
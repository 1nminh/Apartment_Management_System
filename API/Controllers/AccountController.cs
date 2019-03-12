using Library.BLL;
using Library.IBLL;
using Library.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IRepository<Account> accountRepository;

        public AccountController()
        {
            this.accountRepository = new Repository<Account>();
        }

        // POST: Login 
        [HttpPost]
        public IHttpActionResult Login(string username, string password)
        {
            var result = accountRepository.Get(x => x.Username.Equals(username) &&  x.Password.Equals(password));
            if(result != null)
            {
                return Ok(result);
            }
            return BadRequest("Invalid Username Password");
        }

        // POST: Create Account 
        [HttpPost]
        public IHttpActionResult CreateAccount(Account account)
        {
            if (string.IsNullOrEmpty(account.Username))
            {
                return BadRequest("Username cannot be null");
            }
            if (string.IsNullOrEmpty(account.Password))
            {
                return BadRequest("Password cannot be null");
            }
            accountRepository.Create(account);
            return Ok();
        }

        // GET: All account
        [HttpGet]
        public IHttpActionResult GetAllAccount()
        {
            var result = accountRepository.GetAll();
            return Ok(result);
        }

        // Get: Account detail
        [HttpGet]
        public IHttpActionResult GetAccountDetail(string username)
        {
            var result = accountRepository.Get(x=> x.Username.Equals(username));
            return Ok(result);
        }

        [HttpPost]
        public IHttpActionResult EditAccount(Account account)
        {
            accountRepository.Update(account);
            return Ok();
        }
    }
}

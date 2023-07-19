using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.Protocol.Plugins;
using ShoppingCart.DbFiles;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers
{
    public class UserController : Controller
    {
        MyDbContextFile contextFile;

        public UserController(MyDbContextFile contextFile)
        {
            this.contextFile = contextFile;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Users users)
        {
            if (ModelState.IsValid)
            {
				contextFile.Add(users);
				contextFile.SaveChanges();
				ViewBag.success = "Successfully";
				return RedirectToAction("Login", "User");
			}
			return View();
		}
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}
			[HttpPost]
			public IActionResult Login(Users login)
			{

					var l = from a in contextFile.users
					where a.U_Email == login.U_Email && a.U_Password == login.U_Password
							select a;

					if (l.Any())
					{
			//		ViewBag.Name = l.;	
						return RedirectToAction("Index","Home");
					}
					else
					{
						ViewBag.msg = "Invalid login";
					}
					return View();
		}
    }
}

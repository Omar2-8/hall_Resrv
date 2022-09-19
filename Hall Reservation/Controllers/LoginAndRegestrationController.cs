using Hall_Reservation.Models;

using Microsoft.AspNetCore.Mvc;

namespace Hall_Reservation.Controllers
{
    public class LoginAndRegestrationController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;

        public LoginAndRegestrationController(ModelContext context, IWebHostEnvironment webHostEnviroment)
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("UserId,Fname,Lname,Password,UserName,UserImage,Email,Phonenumber")] User user, string username, string password)
        {
            if (ModelState.IsValid)
            {
                string wwwrootPath = _webHostEnviroment.WebRootPath;
                // string fileName = Guid.NewGuid().ToString() + "_" + user.ImageFile.FileName;
                //string extension = Path.GetExtension(user.ImageFile.FileName);
                //user.UserImage = fileName;
                //string path = Path.Combine(wwwrootPath + "/Images/" + fileName);
                //using (var filestream = new FileStream(path, FileMode.Create))
                //{
                //    await user.ImageFile.CopyToAsync(filestream);
                //}

                _context.Add(user);
                await _context.SaveChangesAsync();
                var ListId = _context.Users.OrderByDescending(p => p.UserId).FirstOrDefault().UserId;
                Login login1 = new Login();
                login1.RolesId = 2;
                login1.UserName = username;
                login1.Password = password;
                login1.UserId = ListId;
                _context.Add(login1);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login", "LoginAndRegestration");
            }
            return View(user);
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login([Bind("UserName,Password")] Login login)
        {
            var auth = _context.Logins.Where(x => x.UserName == login.UserName && x.Password == login.Password).SingleOrDefault();
            if (auth != null)
            {
                
                switch (auth.RolesId)
                {
                    case 1:
                        HttpContext.Session.SetInt32("UserId", (int)auth.UserId);
                        HttpContext.Session.SetString("AdminName", auth.UserName);
                        var username = User.Identity.Name;
                        return RedirectToAction("Admin", "DashBoard");
                    case 2:
                        HttpContext.Session.SetInt32("UserId", (int)auth.UserId);
                        HttpContext.Session.SetString("AdminName", auth.UserName);
                        var urname = User.Identity.Name;
                        return RedirectToAction("Index", "Home");

                }
            }
            return View();
        }
    }
}

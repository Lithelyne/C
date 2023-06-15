using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Login.Models;
using Microsoft.AspNetCore.Identity;

namespace Login.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext db;


    public HomeController(ILogger<HomeController> logger, MyContext _mycontext )
    {
        _logger = logger;
        db = _mycontext;
    }

    public IActionResult Index()
    {
        return View("Index");
    }

    [HttpPost("register")]
    public IActionResult Register(User newUser)
    {
        if(!ModelState.IsValid)
        {
            return Index();
        }
        Console.WriteLine(db.Users);
        PasswordHasher<User> passwordHash = new PasswordHasher<User>();
        newUser.Password = passwordHash.HashPassword(newUser, newUser.Password);

        db.Users.Add(newUser);
        db.SaveChanges();

        HttpContext.Session.SetInt32("UUID", newUser.UserId);
        return RedirectToAction("success");
        }

    [HttpPost("login")]
    public IActionResult Login(LoginUser loginUser)
    {
        if(!ModelState.IsValid)
        {
            return Index();
        }

        User? dbUser = db.Users.FirstOrDefault(user => user.Email == user.Email);

        if (dbUser == null)
        {
            ModelState.AddModelError("Email", "not found");
            return Index();
        }
        PasswordHasher<LoginUser> passwordHash = new PasswordHasher<LoginUser>();
        PasswordVerificationResult pwCompareResult = passwordHash.VerifyHashedPassword(loginUser, dbUser.Password, loginUser.LoginPassword);

        if(pwCompareResult == 0)
        {
            ModelState.AddModelError("LoginPassword", "invalid password");
            return Index();
        }
        HttpContext.Session.SetInt32("UUID", dbUser.UserId);
        return RedirectToAction("success"); 
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }


public IActionResult Success()
{
    return View("success");
}


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


    public class SessionCheckAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            int? userId = context.HttpContext.Session.GetInt32("UUID");
            if(userId == null)
            {
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
        }
    }
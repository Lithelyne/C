using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using BeltExam.Models;
using Microsoft.AspNetCore.Identity;

namespace BeltExam.Controllers;
[SessionCheck]


public class CouponController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext db;


    public CouponController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        db = context;
    }

    [HttpGet("coupon")]
    public IActionResult AllCoupon()
    {
        List<Coupon> allCoupons = db.Coupons
        .Include(coupon => coupon.Creator)
        .Include(coupon => coupon.UserCoupons)
        .ToList();
        return View("AllCoupon", allCoupons);
    }

    [HttpGet("coupon/new")]
    public IActionResult NewCoupon()
    {
        return View("New");
    }

    [HttpPost("coupon/create")]
    public IActionResult CreateCoupon(Coupon newCoupon)
    {
        if (!ModelState.IsValid)
        {
            return View("New");
        }

        newCoupon.UserId = (int)HttpContext.Session.GetInt32("UUID");

        db.Coupons.Add(newCoupon);
        db.SaveChanges();
        return RedirectToAction("AllCoupon");
    }


    [HttpGet("user/{userId}")]
    public IActionResult ViewOne(int userId)
    {
        User? oneUser = db.Users
            .Include(user => user.UserCoupons)
            .ThenInclude(userCoupon => userCoupon.Coupon)
            .FirstOrDefault(user => user.UserId == userId);

        List<Coupon> coupons = db.Coupons.Where(coupon => coupon.UserId == userId).ToList();
        ViewBag.Coupons = coupons.Count;

        if (oneUser == null)
        {
            return RedirectToAction("Index");
        }

        return View("Details", oneUser);
    }




    [HttpPost("coupon/{couponId}/usercoupon")]
    public IActionResult UserCoupon(int couponId)
    {

        UserCoupon? existingUserCoupon = db.UserCoupons.FirstOrDefault(usercoupon => usercoupon.UserId ==
        HttpContext.Session.GetInt32("UUID") && usercoupon.CouponId == couponId);

        if (existingUserCoupon == null)
        {
            UserCoupon newUserCoupon = new UserCoupon()
            {
                CouponId = couponId,
                UserId = (int)HttpContext.Session.GetInt32("UUID")
            };

            db.UserCoupons.Add(newUserCoupon);
        }
        

        db.SaveChanges();
        return RedirectToAction("AllCoupon");


    }







}

public class SessionCheckAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        int? userId = context.HttpContext.Session.GetInt32("UUID");
        if (userId == null)
        {
            context.Result = new RedirectToActionResult("Index", "Home", null);
        }
    }
}
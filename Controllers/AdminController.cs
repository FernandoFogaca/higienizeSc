using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using HigienizeMVC.Data;

namespace HigienizeMVC.Controllers;

public class AdminController : Controller
{
    private readonly AppDbContext _context;

    public AdminController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string email, string password)
    {
        if (email == "higienizesc@gmail.com" &&
            password == "h991101206@")
        {
            HttpContext.Session.SetString("Admin", email);

            return RedirectToAction("Index");
        }

        ViewBag.Error = "Email ou senha inválidos.";

        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();

        return RedirectToAction("Login");
    }

    private bool IsLoggedIn()
    {
        return HttpContext.Session.GetString("Admin") != null;
    }

    public IActionResult Index()
    {
        if (!IsLoggedIn())
        {
            return RedirectToAction("Login");
        }

        var comments = _context.Comments
            .Where(c => !c.IsApprove)
            .ToList();

        ViewBag.PendingCount = comments.Count;

        return View(comments);
    }

    public IActionResult ApproveComment(int id)
    {
        if (!IsLoggedIn())
        {
            return RedirectToAction("Login");
        }

        var comment = _context.Comments.FirstOrDefault(c => c.Id == id);

        if (comment != null)
        {
            comment.IsApprove = true;

            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }

    public IActionResult DeleteComment(int id)
    {
        if (!IsLoggedIn())
        {
            return RedirectToAction("Login");
        }

        var comment = _context.Comments.FirstOrDefault(c => c.Id == id);

        if (comment != null)
        {
            _context.Comments.Remove(comment);

            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }
}
using Microsoft.AspNetCore.Mvc;
using HigienizeMVC.Data;

namespace HigienizeMVC.Controllers;

public class AdminController : Controller
{
    private readonly AppDbContext _context;

    public AdminController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var comments = _context.Comments
        .Where(c => !c.IsApprove)
        .ToList();
        ViewBag.PendingCount = comments.Count;
        return View(comments);
    }
public IActionResult ApproveComment(int id)
{
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
    var comment = _context.Comments.FirstOrDefault(c => c.Id == id);

    if (comment != null)
    {
        _context.Comments.Remove(comment);

        _context.SaveChanges();
    }

    return RedirectToAction("Index");
}




}
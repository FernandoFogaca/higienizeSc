using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HigienizeMVC.Models;
using HigienizeMVC.Data;

namespace HigienizeMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly AppDbContext _context;

    public HomeController(
        ILogger<HomeController> logger,
        AppDbContext context)
    {
        _logger = logger;

        _context = context;
    }

    public IActionResult Index()
    {
        var testimonials = new List<Testimonial>
        {
            new Testimonial
            {
                Id = 1,
                Name = "Ana Paula",
                City = "São José",
                Message = "Meu sofá ficou com outra aparência. Atendimento pontual, cuidadoso e o resultado superou o que eu esperava.",
                Rating = 5,
                IsApproved = true,
            },

            new Testimonial
            {
                Id = 2,
                Name = "Mariana Souza",
                City = "Florianópolis",
                Message = "Atendimento excelente e muito capricho.",
                Rating = 5,
                IsApproved = true
            },

            new Testimonial
            {
                Id = 3,
                Name = "Carla Mendes",
                City = "Palhoça",
                Message = "Resultado visível no mesmo dia.",
                Rating = 5,
                IsApproved = true
            }
        };

        ViewBag.Comments =
    _context.Comments
    .Where(c => c.IsApprove)
    .ToList();
        return View(testimonials);
    }

    [HttpPost]
    public IActionResult AddComment(Comment comment)
    {
         comment.IsApprove = false;
         comment.CreatedAt = DateTime.Now;
        _context.Comments.Add(comment);

        _context.SaveChanges();

        TempData["Success"] = "Comentário enviado com sucesso!";

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

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        });
    }
}
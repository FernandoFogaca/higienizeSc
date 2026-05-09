using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HigienizeMVC.Models;


namespace HigienizeMVC.Controllers;

public class HomeController : Controller

{private static List<Comment> comments = new();
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
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
                Message = "Meu sofá ficou com outra aparência. Atendimento pontual, cuidadoso e o resultado superou o que eu esperava. ",
                 Rating = 5,
                 IsApproved = true,

            },new Testimonial
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

       ViewBag.Comments = comments;
       return View(testimonials);
    }

   [ HttpPost]
public IActionResult AddComment(Comment comment)

{comment.Id = comments.Count + 1;
comments.Add(comment);
return RedirectToAction("Index");
}

public IActionResult DeleteComment(int id)
{
    var comment = comments.FirstOrDefault(c => c.Id == id);

    if (comment != null)
    {
        comments.Remove(comment);
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
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

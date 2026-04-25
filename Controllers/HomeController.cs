using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HigienizeMVC.Models;

namespace HigienizeMVC.Controllers;

public class HomeController : Controller
{
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

        return View(testimonials);
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

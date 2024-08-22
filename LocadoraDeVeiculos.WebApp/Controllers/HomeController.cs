using LocadoraDeVeiculos.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LocadoraDeVeiculos.WebApp.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}

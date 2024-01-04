using ArtisanTech.DataAccess.Repository.IRepository;
using ArtisanTech.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArtisanTech.Areas.Customer.Controllers
{
	[Area("Customer")]
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IUnitOfWork _unitOfWork;

		public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
		{
			_logger = logger;
			_unitOfWork = unitOfWork;
		}

		public IActionResult Index()
		{
			IEnumerable<Product> products = _unitOfWork.Product.GetAll(includeProperties: "Category");
			return View(products);
		}

		public IActionResult Details(int id)
		{
			Product product = _unitOfWork.Product.Get(x => x.Id == id, includeProperties: "Category");
			return View(product);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View();
		}
	}
}
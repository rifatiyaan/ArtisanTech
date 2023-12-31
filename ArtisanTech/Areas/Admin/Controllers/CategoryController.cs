using ArtisanTech.DataAccess.Repository.IRepository;
using ArtisanTech.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArtisanTech.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CategoryController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		public CategoryController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public IActionResult Index()
		{
			List<Category> categories = _unitOfWork.Category.GetAll().ToList();
			return View(categories);
		}

		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(Category obj)
		{
			if (obj.Name == obj.DisplayOrder.ToString())
			{
				ModelState.AddModelError("name", "Name and Display Order can't match");
			}


			if (ModelState.IsValid)
			{
				_unitOfWork.Category.Add(obj);
				_unitOfWork.Save();
				TempData["success"] = "Category is successfully created";
				return RedirectToAction("Index");
			}
			return View();
		}

		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Category categoryFromDb = _unitOfWork.Category.Get(u => u.CategoryId == id);

			if (categoryFromDb == null)
			{
				return NotFound();
			}

			return View(categoryFromDb);
		}
		[HttpPost]
		public IActionResult Edit(Category obj)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.Category.Update(obj);
				_unitOfWork.Save();
				TempData["success"] = "Category is successfully updated";
				return RedirectToAction("Index");
			}
			return View();
		}

		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Category deletedCategoryFromDb = _unitOfWork.Category.Get(u => u.CategoryId == id);

			if (deletedCategoryFromDb == null)
			{
				return NotFound();
			}

			return View(deletedCategoryFromDb);
		}
		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePOST(int? id)
		{
			Category deletedCategoryFromDb = _unitOfWork.Category.Get(u => u.CategoryId == id);

			if (deletedCategoryFromDb == null)
			{
				return NotFound();
			}
			_unitOfWork.Category.Remove(deletedCategoryFromDb);
			_unitOfWork.Save();
			TempData["success"] = "Category is successfully deleted";
			return RedirectToAction("Index");
		}

	}
}

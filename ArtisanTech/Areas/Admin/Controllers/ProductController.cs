﻿using ArtisanTech.DataAccess.Repository.IRepository;
using ArtisanTech.Models;
using ArtisanTech.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ArtisanTech.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IWebHostEnvironment _webHostEnvironment;
		public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
		{
			_unitOfWork = unitOfWork;
			_webHostEnvironment = webHostEnvironment;
		}
		public IActionResult Index()
		{
			List<Product> products = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();

			return View(products);

		}

		public IActionResult Upsert(int? id)
		{
			ProductVM productVM = new() //using ViewModels to generate dropdown
			{
				CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
				{
					Text = u.Name,
					Value = u.CategoryId.ToString()
				}),
				Product = new Product()
			};
			//create
			if (id == null || id == 0)
			{
				return View(productVM);
			}
			//update
			else
			{
				productVM.Product = _unitOfWork.Product.Get(u => u.Id == id);
				return View(productVM);
			}


		}

		[HttpPost]
		public IActionResult Upsert(ProductVM productvm, IFormFile? file)
		{


			if (ModelState.IsValid)
			{
				string wwwRootPath = _webHostEnvironment.WebRootPath;
				if (file != null)
				{
					string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
					string productPath = Path.Combine(wwwRootPath, @"images\product");
					if (!string.IsNullOrEmpty(productvm.Product.ImageUrl))
					{
						var oldImagePath = Path.Combine(wwwRootPath, productvm.Product.ImageUrl.TrimStart('\\'));

						if (System.IO.File.Exists(oldImagePath))
						{
							System.IO.File.Delete(oldImagePath);
						}
					}



					using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
					{
						file.CopyTo(fileStream);
					}
					productvm.Product.ImageUrl = @"\images\product\" + fileName;
				}


				if (productvm.Product.Id == 0)
				{
					_unitOfWork.Product.Add(productvm.Product);
				}
				else
				{
					_unitOfWork.Product.Update(productvm.Product);
				}



				_unitOfWork.Save();
				TempData["success"] = "Product is successfully created";
				return RedirectToAction("Index");
			}
			//if ModelState is not valid
			else
			{
				productvm.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
				{
					Text = u.Name,
					Value = u.CategoryId.ToString()
				});

				return View(productvm);
			}

		}



		#region
		[HttpGet]
		public IActionResult GetAll()
		{
			List<Product> products = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();
			return Json(new { data = products });
		}

		public IActionResult Delete(int? id)
		{
			var itemToDelete = _unitOfWork.Product.Get(u => u.Id == id);
			if (itemToDelete == null)
			{
				return Json(new { success = false, message = "Error while deleting" });
			}

			var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, itemToDelete.ImageUrl.TrimStart('\\'));

			if (System.IO.File.Exists(oldImagePath))
			{
				System.IO.File.Delete(oldImagePath);
			}
			_unitOfWork.Product.Remove(itemToDelete);
			_unitOfWork.Save();
			return Json(new { success = false, message = "Product Successfully deleted" });
		}
		#endregion
	}
}

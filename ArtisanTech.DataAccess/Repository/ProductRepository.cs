﻿using ArtisanTech.Data;
using ArtisanTech.DataAccess.Repository.IRepository;
using ArtisanTech.Models;

namespace ArtisanTech.DataAccess.Repository
{
	public class ProductRepository : Repository<Product>, IProductRepository
	{
		private readonly ApplicationDbContext _db;
		public ProductRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}


		public void Update(Product obj)
		{
			_db.Products.Update(obj);
		}


	}
}

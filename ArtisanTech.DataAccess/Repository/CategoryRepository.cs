using ArtisanTech.Data;
using ArtisanTech.DataAccess.Repository.IRepository;
using ArtisanTech.Models;

namespace ArtisanTech.DataAccess.Repository
{
	public class CategoryRepository : Repository<Category>, ICategoryRepository
	{
		public readonly ApplicationDbContext _db;
		public CategoryRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}



		public void Update(Category obj)
		{
			_db.Categories.Update(obj);
		}
	}
}

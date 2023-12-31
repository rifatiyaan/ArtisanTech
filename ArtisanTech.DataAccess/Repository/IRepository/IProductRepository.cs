using ArtisanTech.Models;

namespace ArtisanTech.DataAccess.Repository.IRepository
{
	public interface IProductRepository : IRepository<Product>
	{
		void Update(Product obj);

	}
}

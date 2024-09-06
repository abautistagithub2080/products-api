using PRODUCTS_API.Models;

namespace PRODUCTS_API.Repository
{
    public interface IRepository
    {
        IEnumerable<Products> GetById(int id);
        bool Insert(int id, string Name, string StatusName, string Stock, string Description, string Price, string Discount, string FinalPrice);
        bool Update(int id, string Name, string StatusName, string Stock, string Description, string Price, string Discount, string FinalPrice);
    }
}

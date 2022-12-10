using MyWebShop.Library.Models;

namespace MyWebShop.Library.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAll();
        
        //in the interface we do not implement 'async' , we do only in the child
        Task Add(ProductDto productDto);
    }
}

using MyWebShop.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.Collections;

namespace MyWebShop.Library.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAll(global::Google.Protobuf.WellKnownTypes.Empty request);
        Task<object> GetAll();
        //in the interface we do not implement 'async' , we do only in the child
        Task Add(ProductDto productDto);
    }
}

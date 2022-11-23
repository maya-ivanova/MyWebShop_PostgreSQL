using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MyWebShop.Library.Contracts;
using MyWebShop.Library.Services;
using Google.Protobuf.Collections;
using System;


namespace MyWebShop.Grpc.Services
{
    public class ProductGrpcService : Product.ProductBase
    {
        private readonly IProductService _productService;
        public ProductGrpcService(IProductService productService)
        {
            _productService = productService;
        }

        public override async Task<ProductList> GetAll(Empty request, ServerCallContext context) 
        {
            ProductList result = new();
            //var products = await ProductService.GetAll(request, context);
            // return result.Add(products.select(products => new productitem()
            //{
            //    Id = products.Id,
            //    Title = products.Title,

            //}));

            return null;
            
        }
    }
}

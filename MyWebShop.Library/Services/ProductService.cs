using Microsoft.Extensions.Configuration;
using MyWebShop.Library.Contracts;
using MyWebShop.Library.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MyWebShop.Library.Common;
using MyWebShop.Library.Data.Models;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace MyWebShop.Library.Services
{
    public class ProductService : IProductService
    {
        private readonly IConfiguration configuration;
        private readonly IRepository repo;

        public ProductService(IConfiguration _configuration, IRepository _repo)
        {
            configuration = _configuration;
            repo = _repo;
        }


        //private static async Task<string> ReadAllTextAsync(string filePath)
        //{
        //    using (FileStream sourceStream = new FileStream(filePath,
        //        FileMode.Open, FileAccess.Read, FileShare.Read,
        //        bufferSize: 4096, useAsync: true))
        //    {
        //        StringBuilder sb = new StringBuilder();

        //        byte[] buffer = new byte[1024];
        //        int numRead;
        //        while ((numRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
        //        {
        //            string text = Encoding.UTF8.GetString(buffer, 0, numRead);
        //            sb.Append(text);
        //        }

        //        return sb.ToString();
        //    }
        //}

       public async Task<IEnumerable<ProductDto>> GetAll()
        {
            var dataPath = configuration.GetSection("DataFiles:Products").Value;

            var data = await File.ReadAllTextAsync(dataPath);
            //var data = await File.ReadAllTextAsync(dataPath);
            //string data = await File.("Data/products.json");

            return JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(data);
        }

        public async Task Add(ProductDto productDto)
        {
            var product = new ProductDto()
            {
                Id = productDto.Id,
                Title = productDto.Title,
                Type = productDto.Type,
                Description = productDto.Description,
                Filename = productDto.Filename,
                Height = productDto.Height,
                Width = productDto.Width,
                Price = productDto.Price,
                Rating = productDto.Rating

            };

            await repo.AddAsync(product);
            await repo.SaveChangesAsync();
        }
    }
}


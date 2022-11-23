using Microsoft.Extensions.Configuration;
using MyWebShop.Library.Contracts;
using MyWebShop.Library.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf.Collections;

namespace MyWebShop.Library.Services
{
    public class ProductService : IProductService
    {
        private readonly IConfiguration configuration;

        public ProductService(IConfiguration _configuration)
        {
            configuration = _configuration;

        }


        public async Task<IEnumerable<ProductDto>> GetAll(global::Google.Protobuf.WellKnownTypes.Empty request)
        {

            var dataPath = configuration.GetSection("DataFiles:Products").Value;
            
            //var data = ReadAllTextAsync("bin/Debug/net6.0/Data/products.json");
            var data = ReadAllTextAsync(dataPath);
            //string data = await File.("Data/products.json");

            return JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(await data);
        }

        private static async Task<string> ReadAllTextAsync(string filePath)
        {
            using (FileStream sourceStream = new FileStream(filePath,
                FileMode.Open, FileAccess.Read, FileShare.Read,
                bufferSize: 4096, useAsync: true))
            {
                StringBuilder sb = new StringBuilder();

                byte[] buffer = new byte[1024];
                int numRead;
                while ((numRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                {
                    string text = Encoding.UTF8.GetString(buffer, 0, numRead);
                    sb.Append(text);
                }

                return sb.ToString();
            }
        }

        async Task<object> IProductService.GetAll()
        {
            var dataPath = configuration.GetSection("DataFiles:Products").Value;

            //var data = ReadAllTextAsync("bin/Debug/net6.0/Data/products.json");
            var data = ReadAllTextAsync(dataPath);
            //string data = await File.("Data/products.json");

            return JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(await data);
        }
    }
}


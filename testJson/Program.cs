using Newtonsoft.Json;
using System;
using System.Text;
using System.Collections.Generic;
using testJson;


public class Program
{
    public static void Main()
    {
        var json = ReadAllText("products.json");
        Console.WriteLine(json);

    }

 

//public List<string> GetAll()
//{
//    var data = File.ReadAllText("bin/Debug/net7.0/Data/products.json");


//        return JsonConvert.PopulateObject(data, new ProductTest { });
//}

public static string ReadAllText(string filePath)
    {
        using (FileStream sourceStream = new FileStream(filePath,
            FileMode.Open, FileAccess.Read, FileShare.Read,
            bufferSize: 4096, useAsync: true))
        {
            StringBuilder sb = new StringBuilder();

            byte[] buffer = new byte[1024];
            int numRead;
            while ((numRead = sourceStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                string text = Encoding.UTF8.GetString(buffer, 0, numRead);
                sb.Append(text);
            }

            return sb.ToString();
        }
    }

   
    }


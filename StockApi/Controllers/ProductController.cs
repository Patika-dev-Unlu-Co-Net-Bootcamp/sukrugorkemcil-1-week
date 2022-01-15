using Microsoft.AspNetCore.Mvc;

using StockApi.Model;
using StockApi.Request;
using System.Net;

namespace StockApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {

        public List<ProductModel> ProductList = new List<ProductModel> {
          new ProductModel{Id=1,Name="Pantolon",Color="Mavi",Size=1},
          new ProductModel{Id=2,Name="Kazak",Color="Kırmızı",Size=2},
          new ProductModel{Id=3,Name="Mont",Color="Siyah",Size=2},
          new ProductModel{Id=4,Name="Bere",Color="Beyaz",Size=3}
        };


        [HttpGet]
        public List<ProductModel> Get()
        {
            return ProductList;
        }

        [HttpPut]
        public List<ProductModel> Update(UpdateProductRequest updateProductRequest)
        {
            var product = productUpdate(updateProductRequest);
            return product.OrderBy(k => k.Id).ToList();
        }

        [HttpPost]
        public List<ProductModel> Add(ProductRequest ProductRequest)
        {
            var product = productAdd(ProductRequest);
            return product.OrderBy(k => k.Id).ToList();

        }

        [HttpDelete]
        public List<ProductModel> Delete(DeleteProductRequest deleteProductRequest)
        {
            var product = productDelete(deleteProductRequest);
            return product.OrderBy(k => k.Id).ToList();

        }
        private List<ProductModel> productAdd(ProductRequest request)
        {
            int lastIndex = ProductList.OrderByDescending(k => k.Id).FirstOrDefault().Id;

            ProductList.Add(new ProductModel
            {
                Id = lastIndex + 1,
                Name = request.Name,
                Color = request.Color,
                Size = request.Size,
            });
            return ProductList;
        }

        private List<ProductModel> productUpdate(UpdateProductRequest request)
        {
            var result = ProductList.Where(k => k.Id == request.Id).FirstOrDefault();

            ProductList.Remove(result);
            ProductList.Add(new ProductModel
            {
                Id = request.Id,
                Name = request.Name,
                Color = request.Color,
                Size = request.Size,
            });
            return ProductList;
        }

        private List<ProductModel> productDelete(DeleteProductRequest request)
        {
            var result = ProductList.Where(k => k.Id == request.Id).FirstOrDefault();

            ProductList.Remove(result);

            return ProductList;
        }
    

    }

}




using System.Reflection;
using System.Text.Json;
using API.Core;

namespace Infrastructure.Data
{
    public class DataSeeder
    { 
        private readonly StoreContext dbContext;

        public DataSeeder(StoreContext dbContext )
        {
            this.dbContext = dbContext;
        }

        public void Seed()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if(!this.dbContext.ProductBrands.Any())
            {
                // var brands = new List<ProductBrand>()
                // {
                //     new ProductBrand()
                //     {
                //         Name = "Test001"
                //     }
                // };
                // this.dbContext.ProductBrands.AddRange(brands);
                // this.dbContext.SaveChanges();
                var brandsData = File.ReadAllText("C:/Shared/DEAN/Tut/skinet/Infrastructure/Data/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                foreach(var item in brands)
                {
                    this.dbContext.ProductBrands.Add(item);
                }
                this.dbContext.SaveChanges();
            }
            if(!this.dbContext.ProductTypes.Any())
            {
                var brandTypesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(brandTypesData);
                foreach(var item in types)
                {
                    this.dbContext.ProductTypes.Add(item);
                }
                this.dbContext.SaveChanges();
            }
            if(!this.dbContext.Products.Any())
            {
                var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                foreach(var item in products)
                {
                    this.dbContext.Products.Add(item);
                }
                this.dbContext.SaveChanges();
            }
        }
    }
}
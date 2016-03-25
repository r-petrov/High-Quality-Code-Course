
namespace Orders
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Models;

    public class DataMapper
    {
        private readonly string categoriesFileName;
        private readonly string productsFileName;
        private readonly string ordersFileName;

        public DataMapper(string categoriesFileName, string productsFileName, string ordersFileName)
        {
            this.categoriesFileName = categoriesFileName;
            this.productsFileName = productsFileName;
            this.ordersFileName = ordersFileName;
        }

        public DataMapper()
            : this("../../Data/categories.txt", "../../Data/products.txt", "../../Data/orders.txt")
        {
        }

        public IEnumerable<Category> GetAllCategories()
        {
            var categoriesFromFile = ReadFileLines(this.categoriesFileName, true);
            var categories = categoriesFromFile
                .Select(c => c.Split(','))
                .Select(c => new Category
                {
                    Id = int.Parse(c[0]),
                    Name = c[1],
                    Description = c[2]
                });

            return categories;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var productsFromFile = ReadFileLines(this.productsFileName, true);
            var products = productsFromFile
                .Select(p => p.Split(','))
                .Select(p => new Product
                {
                    Id = int.Parse(p[0]),
                    Name = p[1],
                    CategoryId = int.Parse(p[2]),
                    Price = decimal.Parse(p[3]),
                    Quantity = int.Parse(p[4]),
                });

            return products;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            var ordersFromFile = ReadFileLines(this.ordersFileName, true);
            var orders = ordersFromFile
                .Select(p => p.Split(','))
                .Select(p => new Order
                {
                    ID = int.Parse(p[0]),
                    ProductId = int.Parse(p[1]),
                    Quantity = int.Parse(p[2]),
                    Discount = decimal.Parse(p[3]),
                });

            return orders;
        }

        private List<string> ReadFileLines(string filename, bool hasHeader)
        {
            var allLines = new List<string>();
            using (var reader = new StreamReader(filename))
            {
                string currentLine;
                if (hasHeader)
                {
                    reader.ReadLine();
                }

                while ((currentLine = reader.ReadLine()) != null)
                {
                    allLines.Add(currentLine);
                }
            }

            return allLines;
        }
    }
}

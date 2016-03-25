namespace Orders
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    public class Queries
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var dataMapper = new DataMapper();
            var categories = dataMapper.GetAllCategories();
            var products = dataMapper.GetAllProducts();
            var orders = dataMapper.GetAllOrders();

            // Names of the 5 most expensive products
            var fiveMostExpensiveProducts = products
                .OrderByDescending(p => p.Price)
                .Take(5)
                .Select(p => p.Name);

            Console.WriteLine(string.Join(Environment.NewLine, fiveMostExpensiveProducts));

            Console.WriteLine(new string('-', 10));

            // Quantity of products in each category
            var quantityOfProductsInEachCategory = products
                .GroupBy(p => p.CategoryId)
                .Select(grp => new { Category = categories.First(c => c.Id == grp.Key).Name, Count = grp.Count() })
                .ToList();

            foreach (var category in quantityOfProductsInEachCategory)
            {
                Console.WriteLine("{0}: {1}", category.Category, category.Count);
            }

            Console.WriteLine(new string('-', 10));

            // The 5 top products (by order quantity)
            var fiveMostOrderedProducts = orders
                .GroupBy(o => o.ProductId)
                .Select(grp => new { Product = products.First(p => p.Id == grp.Key).Name, Quantities = grp.Sum(grpgrp => grpgrp.Quantity) })
                .OrderByDescending(q => q.Quantities)
                .Take(5);

            foreach (var product in fiveMostOrderedProducts)
            {
                Console.WriteLine("{0}: {1}", product.Product, product.Quantities);
            }

            Console.WriteLine(new string('-', 10));

            // The most profitable category
            var mostProfitableCategory = orders
                .GroupBy(o => o.ProductId)
                .Select(g => new { categoryId = products.First(p => p.Id == g.Key).CategoryId, price = products.First(p => p.Id == g.Key).Price, quantity = g.Sum(p => p.Quantity) })
                .GroupBy(p => p.categoryId)
                .Select(grp => new { categoryName = categories.First(c => c.Id == grp.Key).Name, totalQuantity = grp.Sum(g => g.quantity * g.price) })
                .OrderByDescending(g => g.totalQuantity)
                .First();
            Console.WriteLine("{0}: {1}", mostProfitableCategory.categoryName, mostProfitableCategory.totalQuantity);
        }
    }
}

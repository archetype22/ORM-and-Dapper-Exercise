using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);
            #region Department
            //var departmentRepo = new DapperDepartmentRepository(conn);

            //departmentRepo.InsertDepartment("Levity");
            //var allDepartments = departmentRepo.GetAllDepartments();
            //foreach (Department item in allDepartments) 
            //{
            //    Console.WriteLine($"Department ID: {item.DepartmentID}");
            //    Console.WriteLine($"Department Name: {item.Name}");
            //}
            #endregion

            #region Product
            var productRepo = new DapperProductRepository(conn);
                        
            productRepo.CreateProduct("Lightsaber", 999.99, 10);

            //var productToUpdate = productRepo.GetProduct(940);

            //productToUpdate.Name = "Nathans Modified Lightsaber";
            //productToUpdate.Price = 10000;
            //productToUpdate.CategoryID = 1;
            //productToUpdate.OnSale = true;
            //productToUpdate.StockLevel = 2;

            //productRepo.UpdateProduct(productToUpdate);

            //productRepo.DeleteProduct(940);

            var allProducts = productRepo.GetAllProducts();
            foreach (Product item in allProducts) 
            {
                Console.WriteLine($"Product ID: {item.ProductID}");
                Console.WriteLine($"Product Name: {item.Name}");
                Console.WriteLine($"Product Price: {item.Price}");
                Console.WriteLine($"Product Category ID: {item.CategoryID}");
                Console.WriteLine($"Product On Sale: {item.OnSale}");
                Console.WriteLine($"Product Stock Level: {item.StockLevel}");
                Console.WriteLine();
                Console.WriteLine();
            }
            
            #endregion
        }
    }
}

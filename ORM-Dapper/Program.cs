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
            #region Department Area
            //var departmentRepo = new DapperDepartmentRepository(conn);
            // departmentRepo.InsertDepartment("Ben's New Department");
            //var departments = departmentRepo.GetAllDepartments();
            //foreach(var department in departments)
            // {
            // Console.WriteLine(department.DepartmentID);
            // Console.WriteLine(department.Name);
            // Console.WriteLine();
            // Console.WriteLine();

            // }
            #endregion

            var productRepository = new DapperProductRepository(conn);

            //var productToUpdate = productRepository.GetProduct(941);
            //productToUpdate.OnSale = 0;
            //productToUpdate.Name = "Seeing if this worked!";
            //productToUpdate.Price = 300;
            //productToUpdate.CategoryID = 1;
            //productToUpdate.StockLevel = 1;


            //productRepository.UpdateProduct(productToUpdate);

            productRepository.DeleteProduct(940);
            productRepository.DeleteProduct(941);
            productRepository.DeleteProduct(942);

            var products = productRepository.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine(product.Name);
                Console.WriteLine(product.ProductID);
                Console.WriteLine(product.StockLevel);
                Console.WriteLine(product.Price);
                Console.WriteLine(product.OnSale);
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}

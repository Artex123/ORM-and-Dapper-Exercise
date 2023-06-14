using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _conn;
        public DapperProductRepository(IDbConnection conn) 
        {
            _conn = conn;
        }
        public void CreateProduct(string name, double price, int categoryID)
        {
            _conn.Execute("INSERT INTO products (Name, Price, CategoryID) VALUES (@name, @price, @categoryid);",
                new {name = name, price = price, categoryid = categoryID});
        }


        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM products;");
        }

        public Product GetProduct(int ID)
        {
            return _conn.QuerySingle<Product>("SELECT * FROM products WHERE ProductID = @ID;",
                new {ID});
        }
        public void DeleteProduct(int ID)
        {
            _conn.Execute("DELETE FROM sales WHERE ProductID = @id;", new {ID = ID});
            _conn.Execute("DELETE FROM reviews WHERE ProductID = @id;", new { ID = ID });
            _conn.Execute("DELETE FROM products WHERE ProductID = @id;", new { ID = ID });
        }

        public void UpdateProduct(Product product)
        {
            _conn.Execute("UPDATE products SET Name = @name, price = @price, " +
                "CategoryID = @categoryID, OnSale = @onsale, " +
                "StockLevel = @stocklevel WHERE ProductID = @id",
                new {name = product.Name, price = product.Price, 
                    categoryID = product.CategoryID, onsale = product.OnSale, 
                    stocklevel = product.StockLevel, id = product.ProductID});
            
        }
    }
}

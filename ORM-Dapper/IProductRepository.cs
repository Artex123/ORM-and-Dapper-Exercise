﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();

        public void CreateProduct(string name, double price, int categoryID);
        public Product GetProduct(int ID);
        public void UpdateProduct(Product product);
        public void DeleteProduct(int ID);
    }
}

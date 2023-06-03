using DataService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface ILogic
    {
        public IEnumerable<Category> getCategories();

        public Category? AddCategory(Category category);

        public Category UpdateCategory(Category category);

        public Category DeleteCategory(Category category);

        public IEnumerable<Product> GetCategoryProducts(string categoryId);

        public Product AddProduct(Product product);

        public Product UpdateProduct(Product product);

        public Product DeleteProduct(Product product);

        public IEnumerable<ProductAttribute> GetProductAttributes(string productId);

        public ProductAttribute AddAttribute(ProductAttribute productAttribute);

        public ProductAttribute UpdateAttribute(ProductAttribute productAttribute);

        public ProductAttribute DeleteAttribute(ProductAttribute productAttribute);
    }
}


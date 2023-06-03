using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity = DataService.Entities;

namespace BusinessLogic
{
    public class Mapper
    {
        public static entity.Category ModelToEntityCategory(Category category)
        {
            return new entity.Category()
            {
                CategoryId = category.CategoryId,
                Name= category.Name,
                Description= category.Description,
            };
        }

        public static Category EntityToModelCategory(entity.Category category)
        {
            return new Category()
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Description = category.Description,
            };
        }

        public static IEnumerable<Category> MapAllCategories(IEnumerable<entity.Category> categories)
        {
            return categories.Select(EntityToModelCategory);
        }


        // -------------------- product mappers 

        public static entity.Product ModelToEntityProduct(Product product)
        {
            return new entity.Product()
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Brand= product.Brand,
                Price= product.Price,
                Quantity= product.Quantity,
                CategoryId= product.CategoryId
            };
        }

        public static Product EntityToModelProduct(entity.Product product)
        {
            return new Product()
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Brand = product.Brand,
                Price = product.Price,
                Quantity = product.Quantity,
                CategoryId = product.CategoryId
            };
        }

        public static IEnumerable<Product> MapAllProducts(IEnumerable<entity.Product> products)
        {
            return products.Select(EntityToModelProduct);
        }

        // ---------------------- Attribute mappers


        public static entity.ProductAttribute ModelToEntityAttribute(ProductAttribute productAttribute)
        {
            return new entity.ProductAttribute()
            {
                AttributeId= productAttribute.AttributeId,
                Name= productAttribute.Name,
                Value= productAttribute.Value,
                ProductId= productAttribute.ProductId
            };
        }

        public static ProductAttribute EntityToModelAttribute(entity.ProductAttribute productAttribute)
        {
            return new ProductAttribute()
            {
                AttributeId = productAttribute.AttributeId,
                Name = productAttribute.Name,
                Value = productAttribute.Value,
                ProductId = productAttribute.ProductId
            };
        }

        public static IEnumerable<ProductAttribute> MapAllAttributes(IEnumerable<entity.ProductAttribute> productAttributes)
        {
            return productAttributes.Select(EntityToModelAttribute);
        }
    }
}

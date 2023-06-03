using DataService;
using DataService.Entities;
using Microsoft.Identity.Client;

namespace BusinessLogic
{
    public class Logic : ILogic
    {

        private IRepo repo;
        public Logic(IRepo _repo)
        {
            repo = _repo;
        }

        public IEnumerable<Category> getCategories()
        {
            return Mapper.MapAllCategories(repo.getAllCategories());
        }

        public Category? AddCategory(Category category)
        {
            try
            {
                return Mapper.EntityToModelCategory(repo.AddCategory(Mapper.ModelToEntityCategory(category)));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Category UpdateCategory(Category category)
        {
            try
            {
                return Mapper.EntityToModelCategory(repo.UpdateCategory(Mapper.ModelToEntityCategory(category)));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Category DeleteCategory(Category category)
        {
            try 
            {
                return Mapper.EntityToModelCategory(repo.DeleteCategory(Mapper.ModelToEntityCategory(category)));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // --------------------------------- Product Logic

        public IEnumerable<Product> GetCategoryProducts(string categoryId)
        {
            return Mapper.MapAllProducts(repo.GetCategoryProducts(categoryId));
        }

        public Product AddProduct(Product product)
        {
            try
            {
                return Mapper.EntityToModelProduct(repo.AddProduct(Mapper.ModelToEntityProduct(product)));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Product UpdateProduct(Product product)
        {
            try
            {
                return Mapper.EntityToModelProduct(repo.UpdateProduct(Mapper.ModelToEntityProduct(product)));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Product DeleteProduct(Product product)
        {
            try
            {
                return Mapper.EntityToModelProduct(repo.DeleteProduct(Mapper.ModelToEntityProduct(product)));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // -------------------------------------- Product Attribute logic

        public IEnumerable<ProductAttribute> GetProductAttributes(string productId)
        {
            return Mapper.MapAllAttributes(repo.getAttributes(productId));
        } 

        public ProductAttribute AddAttribute(ProductAttribute productAttribute)
        {
            try
            {
                return Mapper.EntityToModelAttribute(repo.AddAttribute(Mapper.ModelToEntityAttribute(productAttribute)));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public ProductAttribute UpdateAttribute(ProductAttribute productAttribute)
        {
            try
            {
                return Mapper.EntityToModelAttribute(repo.UpdateAttribute(Mapper.ModelToEntityAttribute(productAttribute)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProductAttribute DeleteAttribute(ProductAttribute productAttribute)
        {
            try
            {
                return Mapper.EntityToModelAttribute(repo.DeleteAttribute(Mapper.ModelToEntityAttribute(productAttribute)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
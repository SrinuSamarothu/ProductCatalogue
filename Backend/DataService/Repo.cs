using DataService.Entities;

namespace DataService
{
    public class Repo : IRepo
    {
        private readonly ProductCatalogueContext context;

        public Repo(ProductCatalogueContext _context)
        {
            this.context = _context;
        }

        // --------------------------- Categories

        public IEnumerable<Category> getAllCategories()
        {
            return context.Categories.ToList();
        }

        public Category? AddCategory(Category category)
        {
            try
            {
                context.Add(category);
                if (context.SaveChanges() > 0)
                {
                    return category;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Category? UpdateCategory(Category category)
        {
            context.Update(category);
            if(context.SaveChanges() > 0)
            {
                return category;
            }
            else
            {
                return null;
            }
        }

        public Category? DeleteCategory(Category category)
        {
            context.Remove(category);
            if(context.SaveChanges() > 0)
            {
                return category;
            }
            else
            {
                return null;
            }
        }

        // ---------------------------- Products 

        public IEnumerable<Product> GetCategoryProducts(string categoryId)
        {
            return context.Products.Where(product => product.CategoryId == categoryId).ToList();
        }

        public IEnumerable<Product> GetProducts()
        {
            return context.Products.ToList();
        }

        public Product? AddProduct(Product product)
        {
            context.Add(product);
            if(context.SaveChanges() > 0)
            {
                return product;
            }
            else
            {
                return null;
            }
        }

        public Product? UpdateProduct(Product product)
        {
            context.Update(product);
            if(context.SaveChanges() > 0)
            {
                return product;
            }
            else
            {
                return null;
            }
        }

        public Product DeleteProduct(Product product)
        {
            context.Remove(product);
            if (context.SaveChanges() > 0)
            {
                return product;
            }
            else
            {
                return null;
            }
        }

        // --------------------------- Product attributes

        public IEnumerable<ProductAttribute> getAttributes(string productId)
        {
            return context.ProductAttributes.Where(attribute => attribute.ProductId == productId).ToList();
        }

        public ProductAttribute? AddAttribute(ProductAttribute productAttribute)
        {
            context.Add(productAttribute);
            if(context.SaveChanges() > 0)
            {
                return productAttribute;
            }
            else
            {
                return null;
            }
        }

        public ProductAttribute? UpdateAttribute(ProductAttribute productAttribute)
        {
            context.Update(productAttribute);
            if(context.SaveChanges() > 0)
            {
                return productAttribute;
            }
            else
            {
                return null;
            }
        }

        public ProductAttribute DeleteAttribute(ProductAttribute productAttribute)
        {
            context.Remove(productAttribute);
            if (context.SaveChanges() > 0)
            {
                return productAttribute;
            }
            else
            {
                return null;
            }
        }
    }
}
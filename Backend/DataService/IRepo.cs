using DataService.Entities;

namespace DataService
{
    public interface IRepo
    {
        public IEnumerable<Category> getAllCategories();

        public Category? AddCategory(Category category);

        public Category? UpdateCategory(Category category);

        public Category? DeleteCategory(Category category);

        public IEnumerable<Product> GetCategoryProducts(string categoryId);

        public IEnumerable<Product> GetProducts();

        public Product? AddProduct(Product product);

        public Product? UpdateProduct(Product product);

        public Product DeleteProduct(Product product);

        public IEnumerable<ProductAttribute> getAttributes(string productId);

        public ProductAttribute? AddAttribute(ProductAttribute productAttribute);

        public ProductAttribute? UpdateAttribute(ProductAttribute productAttribute);

        public ProductAttribute DeleteAttribute(ProductAttribute productAttribute);
    }
}

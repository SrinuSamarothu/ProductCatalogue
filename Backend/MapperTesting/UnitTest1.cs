using model = BusinessLogic;
using entity = DataService.Entities;

namespace MapperTesting
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CategoryModelToEntityMapperTest()
        {
            // arrange
            model.Category category = new model.Category();
            // act
            object resultCategory = model.Mapper.ModelToEntityCategory(category);
            // assert
            Assert.That(typeof(entity.Category), Is.EqualTo(resultCategory.GetType()));
        }

        [Test]
        public void CategoryEntityToModelMapperTest()
        {
            // arrange
            entity.Category category = new entity.Category();
            // act
            object resultCategory = model.Mapper.EntityToModelCategory(category);
            // assert
            Assert.That(typeof(model.Category), Is.EqualTo(resultCategory.GetType()));
        }

        [Test]
        public void ProductModelToEntityMapperTest()
        {
            // arrange
            model.Product product = new model.Product();
            // act
            object resultProduct = model.Mapper.ModelToEntityProduct(product);
            // assert
            Assert.That(typeof(entity.Product), Is.EqualTo(resultProduct.GetType()));
        }

        [Test]
        public void ProductEntityToModelMapperTest()
        {
            // arrange
            entity.Product product = new entity.Product();
            // act
            object resultProduct = model.Mapper.EntityToModelProduct(product);
            // assert
            Assert.That(typeof(model.Product), Is.EqualTo(resultProduct.GetType()));
        }

        [Test]
        public void AttributeModelToEntityMapperTest()
        {
            // arrange
            model.ProductAttribute productAttribute = new model.ProductAttribute();
            // act
            object resultProductAttribute = model.Mapper.ModelToEntityAttribute(productAttribute);
            // assert
            Assert.That(typeof(entity.ProductAttribute), Is.EqualTo(resultProductAttribute.GetType()));
        }

        [Test]
        public void AttributeEntityToModelMapperTest()
        {
            // arrange
            entity.ProductAttribute productAttribute = new entity.ProductAttribute();
            // act
            object resultProductAttribute = model.Mapper.EntityToModelAttribute(productAttribute);
            // assert
            Assert.That(typeof(model.ProductAttribute), Is.EqualTo(resultProductAttribute.GetType()));
        }
    }
}
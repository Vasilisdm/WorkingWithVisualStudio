﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WorkingWithVisualStudio.Controllers;
using WorkingWithVisualStudio.Models;
using Xunit;
using Moq;

namespace WorkingWithVisualStudio.Tests
{
    public class HomeControllerTests
    {

        [Theory]
        [ClassData(typeof(ProductTestData))]
        public void IndexActionModelIsComplete(Product[] products)
        {
            // Arrange
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products).Returns(products);
            var controller = new HomeController { Repository = mock.Object };

            // Act
            var model = (controller.Index() as ViewResult)?.ViewData.Model
                as IEnumerable<Product>;

            // Assert
            Assert.Equal(controller.Repository.Products, model,
                Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name
                && p1.Price == p2.Price));
        }


        class PropertyOnceFakeRepository : IRepository
        {
            public int PropertyCounter { get; set; } = 0;

            public IEnumerable<Product> Products
            {
                get 
                {
                    PropertyCounter++;
                    return new[] { new Product { Name = "MackBook Pro Mid 2017", Price = 1438 } };
                }
            }

            public void AddProduct(Product p)
            {
                // no need for the current test
            }
        }


        [Fact]
        public void RepositoryPropertyCalledOnce()
        {
            // Arrange 
            var repo = new PropertyOnceFakeRepository();
            var controller = new HomeController { Repository = repo };

            // Act 
            var result = controller.Index();

            // Assert
            Assert.Equal(1, repo.PropertyCounter);
        }
    }
}
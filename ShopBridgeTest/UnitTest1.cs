using NUnit.Framework;
using ShopBridge.Controllers;
using ShopBridge.Models;
using Microsoft.AspNetCore.Mvc;

namespace ShopBridgeTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        IItemRepository itemRepository;
        [Test]
        public async System.Threading.Tasks.Task Test_NullValue_CreateItem()
        {
            // Arrange
            var controller = new ItemController(itemRepository);

            // Act
            var response = await controller.CreateItemAsync(null);

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(response);
        }

        [Test]
        public async System.Threading.Tasks.Task Test_InvalidModel_CreateItem()
        {
            // Arrange
            var controller = new ItemController(itemRepository);

            CreateItem item = new CreateItem
            {
                Name = "abc",
            };
            // Act
            var response = await controller.CreateItemAsync(item);

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(response);
        }

        [Test]
        public async System.Threading.Tasks.Task Test_InvalidModel_UpdateItem()
        {
            // Arrange
            var controller = new ItemController(itemRepository);

            CreateItem item = new CreateItem
            {
                Name = "xyz"
            };
            // Act
            var response = await controller.UpdateIteamAsync(1,item);

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(response);
        }
    }
}
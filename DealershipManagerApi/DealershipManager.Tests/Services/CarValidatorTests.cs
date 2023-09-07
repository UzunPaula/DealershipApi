using DealershipManagerApi.DTOs;
using DealershipManagerApi.Models;
using DealershipManagerApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealershipManager.Tests.Services
{
    public class CarValidatorTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void IsValidAddCarDto_NullOrEmptryCarBrand_ShouldReturnFalse(string brand)
        {
            //Arrange
            var dto = new AddCarDto
            {
                Brand = brand,
                Category = Category.Crossover,
                Model = "Model",
                Price = 10000,
                ProductionYear = 2010
            };
            var sut = new CarValidator();

            //Act
            var result = sut.IsValidAddCarDto(dto);

            //Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void IsValidAddCarDto_NullOrEmptryCarModel_ShouldReturnFalse(string model)
        {
            //Arrange
            var dto = new AddCarDto
            {
                Brand = "Brand",
                Category = Category.Crossover,
                Model = model,
                Price = 10000,
                ProductionYear = 2010
            };
            var sut = new CarValidator();

            //Act
            var result = sut.IsValidAddCarDto(dto);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void IsValidAddCarDto_FutureProductionYear_ShouldReturnFalse()
        {
            //Arrange
            var dto = new AddCarDto
            {
                Brand = "Brand",
                Category = Category.Crossover,
                Model = "Model",
                Price = 10000,
                ProductionYear = DateTime.UtcNow.Year + 1
            };
            var sut = new CarValidator();

            //Act
            var result = sut.IsValidAddCarDto(dto);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void IsValidAddCarDto_NegativePrice_ShouldReturnFalse()
        {
            //Arrange
            var dto = new AddCarDto
            {
                Brand = "Brand",
                Category = Category.Crossover,
                Model = "Model",
                Price = -10000,
                ProductionYear = DateTime.UtcNow.Year
            };
            var sut = new CarValidator();

            //Act
            var result = sut.IsValidAddCarDto(dto);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void IsValidAddCarDto_ValidData_ShouldReturnTrue()
        {
            //Arrange
            var dto = new AddCarDto
            {
                Brand = "Brand",
                Category = Category.Crossover,
                Model = "Model",
                Price = 10000,
                ProductionYear = DateTime.UtcNow.Year
            };
            var sut = new CarValidator();

            //Act
            var result = sut.IsValidAddCarDto(dto);

            //Assert
            Assert.True(result);
        }
    }
}


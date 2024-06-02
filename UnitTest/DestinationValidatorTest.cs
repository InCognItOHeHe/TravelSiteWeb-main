using FluentValidation.TestHelper;
using TravelSiteWeb.Models;
using TravelSiteWeb.Services;
using Xunit;

namespace TravelSiteWeb.Tests
{
    public class TravelDestinationValidatorTests
    {
        private readonly TravelDestinationValidator _validator;

        public TravelDestinationValidatorTests()
        {
            _validator = new TravelDestinationValidator();
        }

        [Fact]
        public void Should_Have_Error_When_Country_Is_Null()
        {
            // Arrange
            var model = new Destinations { Country = null };

            // Act
            var result = _validator.TestValidate(model);

            // Assert
            result.ShouldHaveValidationErrorFor(dest => dest.Country);
        }

        [Fact]
        public void Should_Have_Error_When_City_Is_Null()
        {
            // Arrange
            var model = new Destinations { City = null };

            // Act
            var result = _validator.TestValidate(model);

            // Assert
            result.ShouldHaveValidationErrorFor(dest => dest.City);
        }

        [Fact]
        public void Should_Have_Error_When_TripType_Is_Empty()
        {
            // Arrange
            var model = new Destinations { TripType = string.Empty };

            // Act
            var result = _validator.TestValidate(model);

            // Assert
            result.ShouldHaveValidationErrorFor(dest => dest.TripType);
        }

        [Fact]
        public void Should_Have_Error_When_TripType_Is_Too_Short()
        {
            // Arrange
            var model = new Destinations { TripType = "Short" }; // Less than 20 characters

            // Act
            var result = _validator.TestValidate(model);

            // Assert
            result.ShouldHaveValidationErrorFor(dest => dest.TripType);
        }

        [Fact]
        public void Should_Have_Error_When_TripType_Is_Too_Long()
        {
            // Arrange
            var model = new Destinations { TripType = new string('A', 256) }; // More than 255 characters

            // Act
            var result = _validator.TestValidate(model);

            // Assert
            result.ShouldHaveValidationErrorFor(dest => dest.TripType);
        }

        [Fact]
        public void Should_Not_Have_Error_When_TripType_Is_Valid_Length()
        {
            // Arrange
            var model = new Destinations { TripType = new string('A', 50) }; // Between 20 and 255 characters

            // Act
            var result = _validator.TestValidate(model);

            // Assert
            result.ShouldNotHaveValidationErrorFor(dest => dest.TripType);
        }
    }
}

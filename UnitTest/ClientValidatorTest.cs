using FluentValidation.TestHelper;
using TravelSiteWeb.Models;
using TravelSiteWeb.Services;
using Xunit;

namespace TravelSiteWeb.Tests
{
    public class ClientValidatorTests
    {
        private readonly ClientValidator _validator;

        public ClientValidatorTests()
        {
            _validator = new ClientValidator();
        }

        [Fact]
        public void Should_Have_Error_When_FirstName_Is_Empty()
        {
            // Arrange
            var client = new Clients { FirstName = "" };

            // Act
            var result = _validator.TestValidate(client);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.FirstName).WithErrorMessage("Field cannot be empty");
        }

        [Fact]
        public void Should_Not_Have_Error_When_FirstName_Is_Not_Empty()
        {
            // Arrange
            var client = new Clients { FirstName = "John" };

            // Act
            var result = _validator.TestValidate(client);

            // Assert
            result.ShouldNotHaveValidationErrorFor(c => c.FirstName);
        }

        [Fact]
        public void Should_Have_Error_When_LastName_Is_Empty()
        {
            // Arrange
            var client = new Clients { LastName = "" };

            // Act
            var result = _validator.TestValidate(client);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.LastName).WithErrorMessage("Field cannot be empty");
        }

        [Fact]
        public void Should_Not_Have_Error_When_LastName_Is_Not_Empty()
        {
            // Arrange
            var client = new Clients { LastName = "Doe" };

            // Act
            var result = _validator.TestValidate(client);

            // Assert
            result.ShouldNotHaveValidationErrorFor(c => c.LastName);
        }

        [Fact]
        public void Should_Have_Error_When_FirstTrip_Is_Empty()
        {
            // Arrange
            var client = new Clients { FirstTrip = "" };

            // Act
            var result = _validator.TestValidate(client);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.FirstTrip).WithErrorMessage("Field cannot be empty");
        }

        [Fact]
        public void Should_Have_Error_When_FirstTrip_Exceeds_Length()
        {
            // Arrange
            var client = new Clients { FirstTrip = new string('a', 51) };

            // Act
            var result = _validator.TestValidate(client);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.FirstTrip);
        }

        [Fact]
        public void Should_Not_Have_Error_When_FirstTrip_Is_Within_Length()
        {
            // Arrange
            var client = new Clients { FirstTrip = new string('a', 50) };

            // Act
            var result = _validator.TestValidate(client);

            // Assert
            result.ShouldNotHaveValidationErrorFor(c => c.FirstTrip);
        }
    }
}

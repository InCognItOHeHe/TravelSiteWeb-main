using System.Collections.Generic;
using Moq;
using Xunit;
using RepositoryUsingEFinMVC.Repository;
using TravelSiteWeb.Models;
using TravelSiteWeb.Services;

namespace TravelSiteWeb.Tests
{
    public class ReservationValidatorTests
    {
        [Fact]
        public void BeExistingClientID_Should_Return_True_For_Existing_ClientID()
        {
            // Arrange
            var existingClient = new Clients { ClientsID = 1 };
            var clientsRepositoryMock = new Mock<IClientsRepository>();
            clientsRepositoryMock.Setup(x => x.GetById(1)).Returns(existingClient);
            var validator = new ReservationValidator(clientsRepositoryMock.Object, null);

            // Act
            var result = validator.BeExistingClientID(1);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void BeExistingClientID_Should_Return_False_For_NonExisting_ClientID()
        {
            // Arrange
            var clientsRepositoryMock = new Mock<IClientsRepository>();
            clientsRepositoryMock.Setup(x => x.GetById(2)).Returns((Clients)null);
            var validator = new ReservationValidator(clientsRepositoryMock.Object, null);

            // Act
            var result = validator.BeExistingClientID(2);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void BeExistingTravelDestinationID_Should_Return_True_For_Existing_DestinationID()
        {
            // Arrange
            var existingDestination = new Destinations { DestinationsID = 1 };
            var destinationsRepositoryMock = new Mock<IDestinationsRepository>();
            destinationsRepositoryMock.Setup(x => x.GetById(1)).Returns(existingDestination);
            var validator = new ReservationValidator(null, destinationsRepositoryMock.Object);

            // Act
            var result = validator.BeExistingTravelDestinationID(1);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void BeExistingTravelDestinationID_Should_Return_False_For_NonExisting_DestinationID()
        {
            // Arrange
            var destinationsRepositoryMock = new Mock<IDestinationsRepository>();
            destinationsRepositoryMock.Setup(x => x.GetById(2)).Returns((Destinations)null);
            var validator = new ReservationValidator(null, destinationsRepositoryMock.Object);

            // Act
            var result = validator.BeExistingTravelDestinationID(2);

            // Assert
            Assert.False(result);
        }
    }
}


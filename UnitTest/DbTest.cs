using System;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Moq;
using TravelSiteWeb.Models;
using TravelSiteWeb.Data;

namespace TravelSiteWeb.Tests
{
    public class TripContextTests
    {
        [Fact]
        public void TripContext_Constructor_With_DbContextOptions_Creates_Instance()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<TripContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            // Act
            var context = new TripContext(options);

            // Assert
            Assert.NotNull(context);
        }

        [Fact]
        public void TripContext_Constructor_Without_DbContextOptions_Throws_Exception()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new TripContext(null));
        }

        [Fact]
        public void TripContext_Sets_DbSets()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<TripContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            // Act
            using (var context = new TripContext(options))
            {
                // Assert
                Assert.NotNull(context.Clients);
                Assert.NotNull(context.Destinations);
                Assert.NotNull(context.Reservations);
            }
        }

    }
}

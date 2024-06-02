using System.Collections.Generic;
using System.Linq;
using Xunit;
using TravelSiteWeb.Models;
using TravelSiteWeb.Services;
using TravelSiteWeb.Data;
using TravelSiteWeb.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace TravelSiteWeb.Tests
{
    public class MappingServiceTests
    {
        private readonly MappingService _mappingService;
        private readonly TripContext _context;

        public MappingServiceTests()
        {
            _mappingService = new MappingService();
            _context = GetInMemoryTripContext();

            _mappingService.ConfigureMapping();
        }

        private TripContext GetInMemoryTripContext()
        {
            var options = new DbContextOptionsBuilder<TripContext>()
                .UseInMemoryDatabase(databaseName: "TripDatabase")
                .Options;

            var context = new TripContext(options);
            SeedDatabase(context);
            return context;
        }

        private void SeedDatabase(TripContext context)
        {
            var clients = new List<Clients>
            {
                new Clients { ClientsID = 1, FirstName = "John", LastName = "Doe", FirstTrip = "Trip1" },
                new Clients { ClientsID = 2, FirstName = "Jane", LastName = "Smith", FirstTrip = "Trip2" }
            };

            var reservations = new List<Reservations>
            {
                new Reservations { ReservationsID = 1, ClientsID = 1, Contact = "Contact1", Cost = "100", Adress = "Address1", ReservationDate = "10.10.2023" },
                new Reservations { ReservationsID = 2, ClientsID = 2, Contact = "Contact2", Cost = "200", Adress = "Address2", ReservationDate = "10.10.2023" }
            };

            context.Clients.AddRange(clients);
            context.Reservations.AddRange(reservations);
            context.SaveChanges();
        }

        [Fact]
        public void GetClientView_Should_Return_Correct_ViewModels()
        {
            // Act
            var result = _mappingService.GetClientView(_context);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("John Doe", result[0].FullName);
            Assert.Equal("Jane Smith", result[1].FullName);
        }


        [Fact]
        public void GetClientOrderViewModels_Should_Return_Correct_ViewModels()
        {
            // Act
            var result = _mappingService.GetClientOrderViewModels(_context);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("John Doe", result[0].FullName);
            Assert.Single(result[0].Reservations);
            Assert.Equal("Contact1", result[0].Reservations[0].Contact);

            Assert.Equal("Jane Smith", result[1].FullName);
            Assert.Single(result[1].Reservations);
            Assert.Equal("Contact2", result[1].Reservations[0].Contact);
        }
    }
}

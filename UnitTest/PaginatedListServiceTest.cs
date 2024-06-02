using Xunit;
using System.Collections.Generic;
using System.Linq;
using TravelSiteWeb.Services;
using TravelSiteWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace TravelSiteWeb.Tests
{
    public class PaginatedListServiceTests
    {
        [Fact]
        public async Task CreateAsync_Returns_Correct_PaginatedList()
        {
            // Arrange
            var items = new List<string> { "Item1", "Item2", "Item3", "Item4", "Item5" };
            var source = items.AsQueryable();
            var pageIndex = 2;
            var pageSize = 2;

            // Act
            var paginatedListService = new PaginatedListService();
            var result = await paginatedListService.CreateAsync(source, pageIndex, pageSize) as PaginatedList<string>;

            // Assert
            Assert.Equal(pageIndex, result.PageIndex);
            Assert.Equal(3, result.TotalPages);
            Assert.Equal(2, result.Count);
            Assert.Equal("Item3", result[0]);
            Assert.Equal("Item4", result[1]);
        }
    }
}

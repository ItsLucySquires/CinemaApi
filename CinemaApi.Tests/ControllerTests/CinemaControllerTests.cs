using CinemaApi.Models;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;

namespace CinemaApi.Tests.ControllerTests
{
    public class CinemaControllerTests
    {
        private CinemasController _controller;
        private CinemaApiContext _context;

        [SetUp]
        public void Setup()
        {
            _context = A.Fake<CinemaApiContext>();
            _controller = new CinemasController(_context);
        }

        [Test]
        public async Task Get_ReturnsAllCinemas()
        {
            var cinemas = new List<Cinema>
            {
                new Cinema { Id = Guid.NewGuid(), Name = "Cinema 1" },
                new Cinema { Id = Guid.NewGuid(), Name = "Cinema 2" }
            };
            A.CallTo(() => _context.Cinema.ToListAsync())
                .Returns(cinemas);
            var result = await _controller.GetCinemas();
            Assert.That(result, Is.Not.Null);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
            _context = null;
            _controller = null;
        }
    }
}

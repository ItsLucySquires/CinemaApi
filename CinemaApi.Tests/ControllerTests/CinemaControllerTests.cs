using FakeItEasy;

namespace CinemaApi.Tests.ControllerTests
{
    public class CinemaControllerTests
    {
        private CinemasController _controller;

        [SetUp]
        public void Setup()
        {
            var _context = A.Fake<CinemaApiContext>();
            _controller = new CinemasController(_context);
        }

        [Test]
        public void Get_ReturnsAllCinemas()
        {
            Assert.Pass();
        }
    }
}

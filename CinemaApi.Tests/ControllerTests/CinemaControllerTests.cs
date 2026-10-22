using CinemaApi.Data.Handlers.Cinema;
using CinemaApi.Data.Models;
using FakeItEasy;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApi.Tests.ControllerTests
{
    public class CinemaControllerTests
    {
        private CinemasController _controller;
        private IMediator _mediator;

        [SetUp]
        public void Setup()
        {
            _mediator = A.Fake<IMediator>();
            _controller = new CinemasController(_mediator);
        }

        [Test]
        public async Task Get_ReturnsAllCinemas()
        {
            var cinemas = new List<Cinema>
            {
                new Cinema { Id = Guid.NewGuid(), Name = "Cinema 1" },
                new Cinema { Id = Guid.NewGuid(), Name = "Cinema 2" }
            };
            A.CallTo(() => _mediator.Send(A<CinemaQuery>.Ignored))
                .Returns(cinemas);

            var actionResult = await _controller.GetCinemas();
            var okResult = actionResult.Result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);

            var resultCinemas = okResult.Value as IEnumerable<Cinema>;
            Assert.That(resultCinemas, Is.Not.Null);
            Assert.That(resultCinemas.Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task GetCinemas_WhenNoCinemasExist_ReturnsEmptyList()
        {
            var cinemas = new List<Cinema>();
            A.CallTo(() => _mediator.Send(A<CinemaQuery>.Ignored))
                .Returns(cinemas);

            var actionResult = await _controller.GetCinemas();
            var okResult = actionResult.Result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);

            var resultCinemas = okResult.Value as IEnumerable<Cinema>;
            Assert.That(resultCinemas, Is.Not.Null);
            Assert.That(resultCinemas.Count(), Is.EqualTo(0));
        }

        [TearDown]
        public void TearDown()
        {
            _controller = null;
        }
    }
}

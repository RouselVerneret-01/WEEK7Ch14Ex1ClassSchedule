using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using ClassSchedule.Controllers;
using ClassSchedule.Models;

namespace ClassScheduleTests
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexActionMethod_ReturnsAViewResult()
        {
            var classMock = new Mock<IRepository<Class>>();
            var dayMock = new Mock<IRepository<Day>>();

            classMock.Setup(m => m.List(It.IsAny<QueryOptions<Class>>()))
                .Returns(new List<Class>());

            dayMock.Setup(m => m.List(It.IsAny<QueryOptions<Day>>()))
                .Returns(new List<Day>());

            var controller = new HomeController(classMock.Object, dayMock.Object);

            var result = controller.Index();

            Assert.IsType<ViewResult>(result);
        }
    }
}
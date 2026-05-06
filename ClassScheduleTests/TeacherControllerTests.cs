using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using ClassSchedule.Controllers;
using ClassSchedule.Models;

namespace ClassScheduleTests
{
    public class TeacherControllerTests
    {
        [Fact]
        public void IndexActionMethod_ReturnsAViewResult()
        {
            var mock = new Mock<IRepository<Teacher>>();

            mock.Setup(m => m.List(It.IsAny<QueryOptions<Teacher>>()))
                .Returns(new List<Teacher>());

            var controller = new TeacherController(mock.Object);

            var result = controller.Index();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void IndexActionMethod_ModelIsAListOfTeacherObjects()
        {
            var mock = new Mock<IRepository<Teacher>>();

            mock.Setup(m => m.List(It.IsAny<QueryOptions<Teacher>>()))
                .Returns(new List<Teacher>());

            var controller = new TeacherController(mock.Object);

            var result = controller.Index() as ViewResult;

            Assert.IsType<List<Teacher>>(result.Model);
        }
    }
}
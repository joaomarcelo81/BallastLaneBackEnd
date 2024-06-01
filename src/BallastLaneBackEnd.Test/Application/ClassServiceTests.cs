using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using AutoMapper;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using BallastLaneBackEnd.Domain.Interfaces.Repositories;
using BallastLaneBackEnd.Domain.Util;
using BallastLaneBackEnd.Domain.Entities;

using BallastLaneBackEnd.Domain.DTO.Class;
using BallastLaneBackEnd.Domain.Interfaces.Services;
using System.Security.Claims;
using BallastLaneBackEnd.Application;
using BallastLaneBackEnd.Domain.DTO.Student;

namespace BallastLaneBackEnd.Test.Application
{
    public class ClassServiceTests
    {
        private readonly Mock<IRepository<Class>> _classRepositoryMock;
        private readonly Mock<IRepository<Student>> _studentRepositoryMock;
        private readonly Mock<ILogger<ClassService>> _loggerMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Settings _settings;
        private readonly ClassService _classService;

        public ClassServiceTests()
        {
            _classRepositoryMock = new Mock<IRepository<Class>>();
            _studentRepositoryMock = new Mock<IRepository<Student>>();
            _loggerMock = new Mock<ILogger<ClassService>>();
            _mapperMock = new Mock<IMapper>();
            _settings = new Settings(); // Configure as needed

            _classService = new ClassService(
                _mapperMock.Object,
                _loggerMock.Object,
                _settings,
                _classRepositoryMock.Object,
                _studentRepositoryMock.Object);
        }

        [Fact]
        public async Task Add_ShouldReturnClassId()
        {
            // Arrange
            var createClassRequest = new CreateClassRequest();
            var classEntity = new Class { Id = 1 };

            _mapperMock.Setup(m => m.Map<Class>(createClassRequest)).Returns(classEntity);
            _classRepositoryMock.Setup(r => r.Add(It.IsAny<Class>())).ReturnsAsync(classEntity);

            // Act
            var result = await _classService.Add(createClassRequest);

            // Assert
            Assert.Equal(1, result);
            // _loggerMock.Verify(l => l.LogInformation(It.IsAny<string>(), It.IsAny<object[]>()), Times.Once);
            _classRepositoryMock.Verify(r => r.Add(It.IsAny<Class>()), Times.Once);
        }

        [Fact]
        public async Task Update_ShouldReturnUpdatedClassId()
        {
            // Arrange
            var updateClassRequest = new UpdateClassRequest { TeacherId = 2, SubjectId = 3, Students = new List<StudentRequest> { new StudentRequest { Id = 1 } } };
            var classEntity = new Class { Id = 1, Students = new List<Student> { new Student { Id = 1 } } };


            _mapperMock.Setup(m => m.Map<Class>(It.IsAny<UpdateClassRequest>())).Returns(classEntity);
            _classRepositoryMock.Setup(r => r.Get(It.IsAny<int>())).ReturnsAsync(classEntity);
            _studentRepositoryMock.Setup(r => r.Get(It.IsAny<int>())).ReturnsAsync(new Student { Id = 1 });
            _classRepositoryMock.Setup(r => r.Update(It.IsAny<Class>())).ReturnsAsync(classEntity);

            // Act
            var result = await _classService.Update(1, updateClassRequest);

            // Assert
            Assert.Equal(1, result);
            //   _loggerMock.Verify(l => l.LogInformation(It.IsAny<string>(), It.IsAny<object[]>()), Times.Once);
            _classRepositoryMock.Verify(r => r.Get(It.IsAny<int>()), Times.Once);
            _classRepositoryMock.Verify(r => r.Update(It.IsAny<Class>()), Times.Exactly(2));
        }

        [Fact]
        public async Task Get_ShouldReturnClassResponse()
        {
            // Arrange
            var classEntity = new Class { Id = 1 };
            var classResponse = new ClassResponse { Id = 1 };

            _classRepositoryMock.Setup(r => r.Get(1)).ReturnsAsync(classEntity);
            _mapperMock.Setup(m => m.Map<ClassResponse>(classEntity)).Returns(classResponse);

            // Act
            var result = await _classService.Get(1);

            // Assert
            Assert.Equal(classResponse, result);
            //  _loggerMock.Verify(l => l.LogInformation(It.IsAny<string>()), Times.Once);
            _classRepositoryMock.Verify(r => r.Get(1), Times.Once);
        }

        [Fact]
        public async Task Delete_ShouldReturnDeletedClassId()
        {
            // Arrange
            var classEntity = new Class { Id = 1 };
            var classResponse = new ClassResponse { Id = 1 };

            _classRepositoryMock.Setup(r => r.Delete(1)).ReturnsAsync(classEntity);
            _mapperMock.Setup(m => m.Map<ClassResponse>(classEntity)).Returns(classResponse);

            // Act
            var result = await _classService.Delete(1);

            // Assert
            Assert.Equal(1, result);
            //  _loggerMock.Verify(l => l.LogInformation(It.IsAny<string>()), Times.Once);
            _classRepositoryMock.Verify(r => r.Delete(1), Times.Once);
        }

        [Fact]
        public async Task List_ShouldReturnAllClasses()
        {
            // Arrange
            var classEntities = new List<Class> { new Class { Id = 1 }, new Class { Id = 2 } };
            var classResponses = new List<ClassResponse> { new ClassResponse { Id = 1 }, new ClassResponse { Id = 2 } };

            _classRepositoryMock.Setup(r => r.GetAll()).ReturnsAsync(classEntities);
            _mapperMock.Setup(m => m.Map<ClassResponse>(It.IsAny<Class>())).Returns<Class>(c => classResponses.First(cr => cr.Id == c.Id));

            // Act
            var result = await _classService.List();

            // Assert
            Assert.Equal(2, result.Count);
            //  _loggerMock.Verify(l => l.LogInformation(It.IsAny<string>()), Times.Once);
            _classRepositoryMock.Verify(r => r.GetAll(), Times.Once);
        }
    }
}

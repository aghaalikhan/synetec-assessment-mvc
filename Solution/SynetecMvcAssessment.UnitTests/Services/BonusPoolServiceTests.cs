using FluentAssertions;
using InterviewTestTemplatev2.Data;
using InterviewTestTemplatev2.Models;
using InterviewTestTemplatev2.Repositories;
using InterviewTestTemplatev2.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SynetecMvcAssessment.UnitTests.Services
{
    [TestFixture]
    public class BonusPoolServiceTests
    {
        private BonusPoolService _bonusPoolService;
        private Mock<IEmployeeRepository> _employeeRepositoryMock;

        [SetUp]
        public void TestSetup()
        {
            _employeeRepositoryMock = new Mock<IEmployeeRepository>();
            _bonusPoolService = new BonusPoolService(_employeeRepositoryMock.Object);
        }

        [Test]
        public async Task GetBonusPool_ReturnsBonusPoolWithAllEmployees()
        {
            //Arrange
            var employeeOne = new HrEmployee
            {
                ID = 1,
                Full_Name = "Employee One"
            };

            var employeeTwo = new HrEmployee
            {
                ID = 1,
                Full_Name = "Employee Two"
            };

            _employeeRepositoryMock.Setup(er => er.GetEmployeesAsync()).ReturnsAsync(new List<HrEmployee>() { employeeOne, employeeTwo });

            //Act
            var result = await _bonusPoolService.GetBonusPoolAsync();

            //Assert
            result.Employees[0].FullName.Should().Be(employeeOne.Full_Name);
            result.Employees[0].ID.Should().Be(employeeOne.ID);

            result.Employees[1].FullName.Should().Be(employeeTwo.Full_Name);
            result.Employees[1].ID.Should().Be(employeeTwo.ID);
        }


        [Test]
        public async Task GetBonusPoolCalculationResultAsync_ReturnsBonusPoolCalcualteResultForEmployee()
        {
            //Arrange
            var employeeOne = new HrEmployee
            {
                ID = 1,
                Full_Name = "Employee One",
                Salary = 7000

            };

            var employeeTwo = new HrEmployee
            {
                ID = 1,
                Full_Name = "Employee Two",
                Salary = 3000
            };

            _employeeRepositoryMock.Setup(er => er.GetEmployeesAsync()).ReturnsAsync(new List<HrEmployee>() { employeeOne, employeeTwo });

            //Act
            var result = await _bonusPoolService.GetBonusPoolCalculationResultAsync(employeeOne.ID, 3000);

            //Assert
            result.Employee.ID.Should().Be(employeeOne.ID);
            result.Employee.FullName.Should().Be(employeeOne.Full_Name);
            result.bonusPoolAllocation.Should().Be(2100);
        }

        [Test]
        public async Task GetBonusPoolCalculationResultAsync_ZeroEmployeeId_ThrowsArgumentException()
        {
            //Arrange           
            //Act
            Func<Task<BonusPoolCalculatorResultModel>> getBonusCalculationResultFunc = async () => await _bonusPoolService.GetBonusPoolCalculationResultAsync(0, 3000);

            //Assert
            await getBonusCalculationResultFunc.Should().ThrowAsync<ArgumentException>();
        }

        [Test]
        public async Task GetBonusPoolCalculationResultAsync_EmployeeIdNotInRepository_ThrowsException()
        {
            //Arrange
            var employeeOne = new HrEmployee
            {
                ID = 1,
                Full_Name = "Employee One",
                Salary = 7000

            };

            var employeeTwo = new HrEmployee
            {
                ID = 1,
                Full_Name = "Employee Two",
                Salary = 3000
            };

            _employeeRepositoryMock.Setup(er => er.GetEmployeesAsync()).ReturnsAsync(new List<HrEmployee>() { employeeOne, employeeTwo });

            //Act
            Func<Task<BonusPoolCalculatorResultModel>> getBonusCalculationResultFunc = async () => await _bonusPoolService.GetBonusPoolCalculationResultAsync(3, 3000);

            //Assert
            await getBonusCalculationResultFunc.Should().ThrowAsync<Exception>();
        }
    }
}

using challenge.Controllers;
using challenge.Data;
using challenge.Models;
using challenge.Repositories;
using challenge.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace code_challenge.Tests
{
    [TestClass]
    public class EmployeeControllerTests
    {
        private static EmployeeContext _context;
        private static Fakes.Logging.FakeLoggerFactory _logFactory = new Fakes.Logging.FakeLoggerFactory();
        private static EmployeeController _employeeController;

        [ClassInitialize]
        public static void InitializeClass(TestContext context)
        {
            _context = new EmployeeContext(
                          new DbContextOptionsBuilder<EmployeeContext>()
                              .UseInMemoryDatabase("EmployeeDB").Options);

            new EmployeeDataSeeder(_context).Seed().Wait();

            _employeeController = new EmployeeController(
                _logFactory.CreateLogger<EmployeeController>(),
                new EmployeeService(
                    _logFactory.CreateLogger<EmployeeService>(),
                        new EmployeeRespository(
                            _logFactory.CreateLogger<EmployeeRespository>(), _context)));

        }

        [TestMethod]
        public void CreateEmployee_Pass()
        {
            var employee = new Employee()
            {
                Department = "Complaints",
                FirstName = "Debbie",
                LastName = "Downer",
                Position = "Receiver",
            };

            var actionResult = _employeeController.CreateEmployee(employee);
            Assert.IsInstanceOfType(actionResult, typeof(CreatedAtRouteResult));

            var createdAtRoute = (CreatedAtRouteResult)actionResult;
            var employeeRec = (Employee)createdAtRoute.Value;
            Assert.IsFalse(String.IsNullOrWhiteSpace(employeeRec.EmployeeId));
        }

        [TestMethod]
        public void GetEmployeeById_Pass()
        {

        }

        [TestMethod]
        public void GetEmployeeId_Fail()
        {

        }

        [TestMethod]
        public void UpdateEmployee_Pass()
        {

        }

        [TestMethod]
        public void UpdateEmployee_Fail()
        {

        }
    }
}

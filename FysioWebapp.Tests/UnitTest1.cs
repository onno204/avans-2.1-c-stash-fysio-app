using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Domain;
using Core.DomainServices;
using FysioWebapp.Controllers.Manage;
using FysioWebapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace FysioWebapp.Tests
{
    public class UnitTest1
    {

        List<User> mockedUserList = new List<User>
        {
        new User()
        {
                    AdditionalIdentifier = 2167989,
                    Appointments = new List<Appointment>(),
                    BirthDate = new DateTime(2002, 02, 05),
                    Comments = new List<Comment>(),
                    DcsphCode = 999,
                    DcsphDescription = "unknown",
                    Email = "o.thrapist@student.avans.nl",
                    EndDateTreatment = new DateTime(2021, 10, 30),
                    FullName = "Onno thrapist",
                    Gender = Gender.Male,
                    GlobalDescriptionComplaints = "Heel veel klachten",
                    IntakeSuperVisionUser = null,
                    IntakeUser = null,
                    MainTherapist = null,
                    Password = null,
                    Picture = null,
                    SignUpDate = DateTime.Now,
                    TreatmentHistory = new List<Treatment>(),
                    TreatmentPlan = "Geen",
                    Id = 1,
                    UserType = UserType.Therapist
                },
        new User()
        {
                    AdditionalIdentifier = 2167989,
                    Appointments = new List<Appointment>(),
                    BirthDate = new DateTime(2002, 02, 05),
                    Comments = new List<Comment>(),
                    DcsphCode = 999,
                    DcsphDescription = "unknown",
                    Email = "o.thrapist@student.avans.nl",
                    EndDateTreatment = new DateTime(2021, 10, 30),
                    FullName = "Onno thrapist",
                    Gender = Gender.Male,
                    GlobalDescriptionComplaints = "Heel veel klachten",
                    IntakeSuperVisionUser = null,
                    IntakeUser = null,
                    MainTherapist = null,
                    Password = null,
                    Picture = null,
                    SignUpDate = DateTime.Now,
                    TreatmentHistory = new List<Treatment>(),
                    TreatmentPlan = "Geen",
                    Id = 2,
                    UserType = UserType.StudentTherapist
                },
        new User()
        {
                    AdditionalIdentifier = 2167989,
                    Appointments = new List<Appointment>(),
                    BirthDate = new DateTime(2002, 02, 05),
                    Comments = new List<Comment>(),
                    DcsphCode = 999,
                    DcsphDescription = "unknown",
                    Email = "o.thrapist@student.avans.nl",
                    EndDateTreatment = new DateTime(2021, 10, 30),
                    FullName = "Onno thrapist",
                    Gender = Gender.Male,
                    GlobalDescriptionComplaints = "Heel veel klachten",
                    IntakeSuperVisionUser = null,
                    IntakeUser = null,
                    MainTherapist = null,
                    Password = null,
                    Picture = null,
                    SignUpDate = DateTime.Now,
                    SessionDuration = 2.0f,
                    SessionsPerWeek = 3,
                    TreatmentHistory = new List<Treatment>(),
                    TreatmentPlan = "Geen",
                    Id = 3,
                    UserType = UserType.Employee
                },
        };

        public IQueryable<User> mockedUser()
        {

            return this.mockedUserList.AsQueryable();

        }

        [Fact]
        public async Task Should_Register_A_New_Patient()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<PatientController>>();
            var userRepoMock = new Mock<IUserRepository>();

            PatientController patientController = new PatientController(loggerMock.Object, userRepoMock.Object);
            userRepoMock.Setup(userRepo => userRepo.GetAll()).Returns(this.mockedUser());

            // Act
            NewPatientModel newPatient = new NewPatientModel()
            {
                AdditionalIdentifier = 2167989,
                BirthDate = new DateTime(2002, 02, 05),
                DcsphCode = 999,
                DcsphDescription = "unknown",
                Email = "o.testTherapist@student.avans.nl",
                EndDateTreatment = new DateTime(2021, 10, 30),
                FullName = "Onno thrapist",
                Gender = Gender.Male,
                GlobalDescriptionComplaints = "Heel veel klachten",
                Picture = null,
                SignUpDate = DateTime.Now,
                TreatmentPlan = "Behandelplan",
                CommentsInput = "",
                SessionDuration = 1.5f,
                SessionsPerWeek = 3,
                MainTherapistId = 1,
                IntakeSuperVisionUserId = 1,
                IntakeUserId = 1,
                UserType = UserType.Employee
            };

            // Assert
            var result = await patientController.Add(newPatient);

            var viewResult = result as ViewResult;
            Assert.Null(viewResult);
        }

        [Fact]
        public async Task Should_Show_The_New_Patient()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<AgendaController>>();
            var userRepoMock = new Mock<IUserRepository>();

            AgendaController controller = new AgendaController(loggerMock.Object, userRepoMock.Object)
            {
                GetLoggedinUserEmail = () => "o.thrapist@student.avans.nl"
            };
            userRepoMock.Setup(userRepo => userRepo.GetAll()).Returns(this.mockedUser());

            // Act
            AddAppointmentViewModel model = new AddAppointmentViewModel()
            {
                UserEmail = "o.thrapist@student.avans.nl",
                EndDate = DateTime.Now,
                StartDate = DateTime.Now.AddHours(-2)
            };

            // Assert
            var result = await controller.Add(3, model);
            result = await controller.Add(3, model);
            result = await controller.Add(3, model);
            result = await controller.Add(3, model);

            var viewResult = result as ViewResult;
            Assert.Null(viewResult);
        }
    }
}

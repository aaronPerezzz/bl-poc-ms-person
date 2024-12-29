using bl_poc_ms_person.Controllers;

namespace bl_poc_ms_person.Tests.Pruebas
{
    [TestClass]
    public sealed class PersonsControllerTests: BaseTests
    {
        [TestMethod]
        public async Task GetPersons()
        {
            var nameDB = Guid.NewGuid().ToString();
            var context = BuildContext(nameDB);

            context.Persons.Add(new Models.Persons { Name = "Aaron", LastName = "Pérez", Email = "aaron@gmail.com", MaritalStatus = "Soltero" });
            await context.SaveChangesAsync();

            var context2 = BuildContext(nameDB);

            var controller = new PersonController(IP);
        }
    }
}

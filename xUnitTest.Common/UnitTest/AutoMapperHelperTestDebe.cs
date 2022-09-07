
using Core.Common.Util.Helper.API;

namespace xUnitTest.Common.UnitTest
{
    public class AutoMapperHelperTestDebe
    {
        [Theory]
        [InlineData("Carlos", 24400, "Mariano Egas N37-50", "IT", true)] 
        [InlineData("Diego", 45678, "Canal 4", "IT", true)]
        [InlineData("Paulina", 1200.45, "Egas N37-50", "IT", true)] 
        [InlineData("Monica", 22145, "Otra direccion N37-50", "IT", false)] 

        public void ValidarProcesoSimpleDeMapeo(string nombre, double salario, string direccion, string departamento, bool resultadoEsperadoTest)
        {
            EmployeeDTO emp = new EmployeeDTO
            {
                Name = nombre,
                Salary = salario,
                Address = direccion,
                Department = departamento
            };

            var resultadoMapeo = AutoMapperHelper.MapeoDinamicoSimpleAutoMapper<Employee, EmployeeDTO>(emp);

            bool resultadoObtenidoTest = resultadoMapeo == null ? false : true;

            Console.WriteLine(emp.ToString());

            Assert.Equal(resultadoObtenidoTest, resultadoEsperadoTest);
        }

        [Fact]
        public void ValidarProcesoSimpleDeMapeo_Fact()
        {
            EmployeeDTO emp = new EmployeeDTO
            {
                Name = "James",
                Salary = 20000,
                Address = "London",
                Department = "IT"
            };

            AutoMapperHelper.MapeoDinamicoSimpleAutoMapper<Employee, EmployeeDTO>(emp);

            Console.WriteLine(emp.ToString());
            Assert.True(true);

        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
    }
    public class EmployeeDTO
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
    }


}

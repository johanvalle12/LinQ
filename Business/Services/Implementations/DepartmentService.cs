using Business.Services.Abstractions;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private List<Department> DepartmentList = TestData.DepartmentList;
        public List<Department> GetDepartments()
        {
            return DepartmentList;
        }
        public Department GetDepartment(int id)
        {
            var department = DepartmentList.FirstOrDefault(department => department.Id == id);
            if (department == null)
                throw new InvalidOperationException($"No se ha encontrado el departamento con ID {id}");

            return department;
        }

        public Subdepartment GetSubdepartment(Department department, int id)
        {
            var subdepartment = department.Subdepartments.FirstOrDefault(subdepartment => subdepartment.Id == id);
            if (subdepartment == null)
                throw new InvalidOperationException($"No se ha encontrado el subdepartamento con ID {id}");

            return subdepartment;
        }
    }
}

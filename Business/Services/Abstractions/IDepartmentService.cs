using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstractions
{
    public interface IDepartmentService
    {
        public Department GetDepartment(int id);
        public Subdepartment GetSubdepartment(Department department, int id);
        public List<Department> GetDepartments();
    }
}

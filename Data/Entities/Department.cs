using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; private set; }

        public List<Subdepartment> Subdepartments { get; private set; }
        public Department(int id, string name, List<Subdepartment> subdepartments)
        {
            if(id == 0)
                throw new ArgumentNullException("El id no puede ser vacio o 0");
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("El nombre no puede ser vacio");

            if (subdepartments == null || !subdepartments.Any())
                throw new InvalidOperationException("El departamento necesita subdepartamentos");

            Id = id;
            Name = name;
            Subdepartments = subdepartments;
        }
    }
}

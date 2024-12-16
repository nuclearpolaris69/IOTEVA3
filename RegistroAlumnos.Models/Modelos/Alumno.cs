using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAlumnos.Models.Modelos
{
    public class Alumno
    {
        public string? Nombre { get; set; }
        public string? Email { get; set; }
        public int? Edad { get; set; }

        public Boolean Activo { get; set; }
        public Curso? Curso { get; set; }
    }
}

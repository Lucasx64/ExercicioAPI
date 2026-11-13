using System;
using System.Collections.Generic;

namespace PizzariaAPI.Models;

public partial class EspecialidadeProfessor
{
    public int RegistroProfessor { get; set; }

    public string Especialidade { get; set; } = null!;

    public virtual Professor RegistroProfessorNavigation { get; set; } = null!;
}

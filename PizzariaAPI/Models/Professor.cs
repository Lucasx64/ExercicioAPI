using System;
using System.Collections.Generic;

namespace PizzariaAPI.Models;

public partial class Professor
{
    public int RegistroProfessor { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Curso> Curso { get; set; } = new List<Curso>();

    public virtual ICollection<EspecialidadeProfessor> EspecialidadeProfessor { get; set; } = new List<EspecialidadeProfessor>();
}

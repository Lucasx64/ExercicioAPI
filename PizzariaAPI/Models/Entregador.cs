using System;
using System.Collections.Generic;

namespace PizzariaAPI.Models;

public partial class Entregador
{
    public int Matricula { get; set; }

    public string Nome { get; set; } = null!;

    public string PlacaMoto { get; set; } = null!;

    public virtual ICollection<Pedido> Pedido { get; set; } = new List<Pedido>();
}

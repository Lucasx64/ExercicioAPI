using System;
using System.Collections.Generic;

namespace PizzariaAPI.Models;

public partial class Pedido
{
    public int Numero { get; set; }

    public DateOnly DataPedido { get; set; }

    public TimeOnly Hora { get; set; }

    public string CpfCliente { get; set; } = null!;

    public int MatriculaEntregador { get; set; }

    public virtual Cliente CpfClienteNavigation { get; set; } = null!;

    public virtual ICollection<ItemPedido> ItemPedido { get; set; } = new List<ItemPedido>();

    public virtual Entregador MatriculaEntregadorNavigation { get; set; } = null!;
}

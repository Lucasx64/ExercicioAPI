using System;
using System.Collections.Generic;

namespace PizzariaAPI.Models;

public partial class ItemPedido
{
    public string? CodigoCrip { get; set; }

    public int CodigoPedido { get; set; }

    public int NumeroPedido { get; set; }

    public int CodigoPizza { get; set; }

    public byte Quantidade { get; set; }

    public virtual Pizza CodigoPizzaNavigation { get; set; } = null!;

    public virtual Pedido NumeroPedidoNavigation { get; set; } = null!;
}

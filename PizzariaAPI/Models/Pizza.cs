using System;
using System.Collections.Generic;

namespace PizzariaAPI.Models;

public partial class Pizza
{
    public int Codigo { get; set; }

    public string Sabor { get; set; } = null!;

    public decimal Preco { get; set; }

    public virtual ICollection<ItemPedido> ItemPedido { get; set; } = new List<ItemPedido>();
}

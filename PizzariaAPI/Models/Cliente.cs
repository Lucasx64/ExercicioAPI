using System;
using System.Collections.Generic;

namespace PizzariaAPI.Models;

public partial class Cliente
{
    public string CpfCliente { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string Rua { get; set; } = null!;

    public string Numero { get; set; } = null!;

    public string Bairro { get; set; } = null!;

    public virtual ICollection<Pedido> Pedido { get; set; } = new List<Pedido>();

    public virtual ICollection<TelefoneCliente> TelefoneCliente { get; set; } = new List<TelefoneCliente>();
}

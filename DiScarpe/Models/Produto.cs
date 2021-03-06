//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DiScarpe.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Produto
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public int IdCategoria { get; set; }
        public int IdCor { get; set; }
        public int IdMarca { get; set; }
        public int IdEstilo { get; set; }
        public int IdTamanho { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int IdUsuario { get; set; }
    
        public virtual Categoria Categoria { get; set; }
        public virtual Cor Cor { get; set; }
        public virtual Estilo Estilo { get; set; }
        public virtual Marca Marca { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Tamanho Tamanho { get; set; }
    }
}

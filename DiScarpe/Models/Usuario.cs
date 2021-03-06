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
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            this.Produto = new HashSet<Produto>();
        }

        public int IdUsuario { get; set; }
        [DisplayName("Nome")]
        [Required(ErrorMessage = "Este campo dever ser preenchido.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Este campo dever ser preenchido.")]
        public string Email { get; set; }
        [DisplayName("Senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Este campo dever ser preenchido.")]
        public string Senha { get; set; }
        public string LoginErrorMessage { get; internal set; }
        public bool Administrador { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Produto> Produto { get; set; }
    }
}

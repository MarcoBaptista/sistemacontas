using SistemaContas.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaContas.Data.Entities
{
    public class Categoria
    {
        #region Atributos
        private Guid? _idCategoria;
        private string? _nome;
        private TipoCategoria? _tipo;
        private Guid? _idUsuario;
        
        private Usuario? _usuario; //associação entre classes
        private List<Conta> _contas; //associação entre classes

        #endregion

        #region Encapsulamento
        public Guid? IdCategoria { get => _idCategoria; set => _idCategoria = value; }
        public string? Nome { get => _nome; set => _nome = value; }
        public TipoCategoria? Tipo { get => _tipo; set => _tipo = value; }
        public Guid? IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public Usuario? Usuario { get => _usuario; set => _usuario = value; }
        public List<Conta> Contas { get => _contas; set => _contas = value; }
        #endregion


    }
}

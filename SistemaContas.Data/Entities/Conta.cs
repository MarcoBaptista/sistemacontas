using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaContas.Data.Entities
{
    public class Conta
    {
        #region Atributos

        private Guid? _idConta;
        private string? _nome;
        private string? _descricao;
        private DateTime? _data;
        private decimal? _valor;
        private Guid? _idUsuario;
        private Guid? _idCategoria;

        private Usuario? _usuario; //associacao entre classes
        private Categoria? _categoria; //associacao entre classes


        #endregion

        #region Encapsulamentos

        public Guid? IdConta { get => _idConta; set => _idConta = value; }
        public string? Nome { get => _nome; set => _nome = value; }
        public string? Descricao { get => _descricao; set => _descricao = value; }
        public DateTime? Data { get => _data; set => _data = value; }
        public decimal? Valor { get => _valor; set => _valor = value; }
        public Guid? IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public Guid? IdCategoria { get => _idCategoria; set => _idCategoria = value; }
        public Usuario? Usuario { get => _usuario; set => _usuario = value; }
        public Categoria? Categoria { get => _categoria; set => _categoria = value; }

        #endregion


    }
}

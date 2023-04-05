using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaContas.Data.Entities
{
    /// <summary>
    /// Modelo de entidade
    /// </summary>
    public class Usuario
    {
        #region Atributos

        private Guid? _idUsuario;
        private string? _nome;
        private string? _email;
        private string? _senha;
        private DateTime? _dataCriacao;
        private int? _ativo;

        private List<Categoria> _categorias; //associacao entre classes
        private List<Conta> _contas;

        #endregion

        #region Encapsulamentos
        public Guid? IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public string? Nome { get => _nome; set => _nome = value; }
        public string? Email { get => _email; set => _email = value; }
        public string? Senha { get => _senha; set => _senha = value; }
        public DateTime? DataCriacao { get => _dataCriacao; set => _dataCriacao = value; }
        public int? Ativo { get => _ativo; set => _ativo = value; }
        public List<Categoria> Categorias { get => _categorias; set => _categorias = value; }
        public List<Conta> Contas { get => _contas; set => _contas = value; }
        #endregion




    }
}

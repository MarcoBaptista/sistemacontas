using Microsoft.EntityFrameworkCore;
using SistemaContas.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaContas.Data.Repositories
{
    /// <summary>
    /// Classe abstrata para definição dos métodos base dos repositórios
    /// </summary>
    public abstract class BaseRepository <TEntity, TKey>
        where TEntity : class //obrigatorio que é do tipo especifico que está chegando
    {
        //Tentity é geneérico para qq entidade instanciada
        //Tkey para passar o tipo da chave da entidade 
        public virtual void Adicionar( TEntity entity)
        {
            using (var dataContext = new DataContext()) {
                dataContext.Add(entity);
                dataContext.SaveChanges();
            }
        }

        public virtual void Atualizar(TEntity entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Entry(entity).State = EntityState.Modified;
                dataContext.SaveChanges();
            }
        }

        public virtual void Excluir(TEntity entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Remove(entity);
                dataContext.SaveChanges();
            }
        }
        /// <summary>
        /// Declarada para reeber uma expressão LAMBDA
        /// </summary>
        /// <returns></returns>
        public virtual List<TEntity> Obtertodos(Func<TEntity, bool> where )
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<TEntity>()
                    .Where( where )
                    .ToList();
            }
        }

        /// <summary>
        /// Consulta generica q retorne um registro
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual TEntity? Obter(Func<TEntity, bool> where)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<TEntity>()
                    .FirstOrDefault(where);
            }
        }

        public virtual TEntity? ObterPorId( TKey id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<TEntity>()
                    .Find( id );
            }

        }
    }
}

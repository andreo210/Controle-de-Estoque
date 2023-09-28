using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.Domain
{
    public interface IGlobalRepository<TEntity>//implementa uma interface bem generica
    {//interface com os metodos de CRUD
        // contem todos os métodos que deverão ser implementados pela classe que usar essa interface como referência. Logo de cara, não se assuste com a assinatura da classe

        public IEnumerable<TEntity> Get(
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           string includeProperties = "");
        public Task<IEnumerable<TEntity>> ObterTodosAsNoTracking(Expression<Func<TEntity, bool>> predicate);

        public TEntity GetByID(object id);

        public TEntity Insert(TEntity entity);

        public void Delete(object id);

        public void Delete(TEntity entityToDelete);

        public void Update(TEntity entityToUpdate);

        public void Save();
        public IEnumerable<TEntity> GetAll();
    }
}

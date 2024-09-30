using Store.Data.Context;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _context;
        private  Hashtable _repositories;
        //key value pair to store instaces of  repositories
        //so key can not repeated
        //value is opject or instace of what we need 
        // when i ask for new opject ,insure that is on opject only 
        //it will make caching and reusabilty
        public UnitOfWork(StoreDbContext context)
        {
            _context = context;
        }
        public async Task<int> CompeleteAsync()
        =>await _context.SaveChangesAsync();

        public IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
           if (_repositories is null )
                _repositories = new Hashtable();
           var entityKey = typeof(TEntity).Name;//Product // make key is the name of enity
            if (!_repositories.ContainsKey(entityKey)) 
            {
                var repositoryType= typeof(GenericRepository<,>);//make generic repository <Product , int> 
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity) , typeof(TKey)), _context);
                // find constractor match the list of paramter
                _repositories.Add(entityKey, repositoryInstance);
            
            }
            return (IGenericRepository<TEntity, TKey>) _repositories[entityKey];


        }
    }
}

using Microsoft.EntityFrameworkCore;
using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Specification
{
    public class SpecificationEvaluator<TEntity, TKey> where TEntity:BaseEntity<TKey>
    {
        //IEnumerable vs IQuerable 
        ///collection of data both of them
        ///the way of excution 
        /// differed excution => retrive in memory"locally" (array , list , dictionary) for small data 
        /// making prosses in your memory 
        /// 
        ///large data => IQuerable 
        ///differd excution =>proccess in database ,filtration ,sorting, pagination 
        ///server excution => remote data source 
        ///

        public static IQueryable <TEntity> GetQuery(IQueryable<TEntity> inputQuery , ISpecification<TEntity> specs)
        {
            var query = inputQuery; 
            if(specs.Criteria is not null )
                query = query.Where(specs.Criteria);//x=>x.typeId ==3 
            if(specs.OrderBy is not null )
                query = query.OrderBy(specs.OrderBy);

            if (specs.OrderByDescending is not null)
                query = query.OrderBy(specs.OrderByDescending);
            if (specs.IsPaginated)
                query = query.Skip(specs.Skip).Take(specs.Take);
            query = specs.Includes.Aggregate(query , (current , includeExpression)
                => current.Include(includeExpression));
            return query;
        }


    }
}

using DataGridWithComputedCells.Data;
using DataGridWithComputedCells.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridWithComputedCells.Factories
{
    public class RepositoryFactory
    {
        private static readonly Dictionary<Type, IAdoRepository> _repositories = new Dictionary<Type, IAdoRepository>();
        private static readonly DbContext _dbContext = new DbContext("Data Source=db.sqlite");

        public static IAdoRepository GetRepository<T>() where T: IAdoRepository
        {
            if (typeof(T) == typeof(PersonRepository))
            {
                if (!_repositories.ContainsKey(typeof(PersonRepository)))
                {
                    _repositories.Add(typeof(PersonRepository), new PersonRepository(_dbContext));
                }
                return _repositories[typeof(PersonRepository)];
            }
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace Autofac.Integration.WebApi.Owin.SelfHost.Console.Infrastructure
{
    public class RepositoryBase<TItem> : IRepository<TItem> where TItem : class, IEntity
    {
        private LiteDatabase _database;

        //private readonly ILiteCollection<TItem> _collection;

        public RepositoryBase(LiteDatabase database)
        {
            _database = database;
            //_collection = database.GetCollection<TItem>();
        }

        public void Create(TItem item)
        {
            _database.GetCollection<TItem>().Insert(item);
            //_database.GetCollection<TItem>().EnsureIndex(item.Id);
        }

        public ICollection<TItem> All()
        {
            return _database.GetCollection<TItem>().FindAll().ToList();
        }

        public TItem Fetch(string id)
        {
            return _database.GetCollection<TItem>().FindById(id);
        }

        public bool Update(TItem item)
        {
            return _database.GetCollection<TItem>().Update(item);
        }

        public bool Delete(string id)
        {
            return _database.GetCollection<TItem>().Delete(id);
        }
    }
}

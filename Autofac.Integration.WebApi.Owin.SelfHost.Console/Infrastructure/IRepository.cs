using System.Collections.Generic;

namespace Autofac.Integration.WebApi.Owin.SelfHost.Console.Infrastructure
{
    public interface IRepository<TItem> where TItem : class, IEntity
    {
        void Create(TItem item);

        ICollection<TItem> All();

        TItem Fetch(string id);

        bool Update(TItem item);

        bool Delete(string id);
    }
}

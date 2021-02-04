using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using tmherronProfessionalSite.Contracts;
using tmherronProfessionalSite.Contracts.HeyCurator;
using tmherronProfessionalSite.Data.HeyCurator;

namespace tmherronProfessionalSite
{
    public abstract class RepositoryBaseHC<T> : IRepositoryBaseHC<T> where T : IDocument
    {
        protected IMongoCollection<T> _collectionDbContext { get; set; }

        public RepositoryBaseHC(IHCDbSettings settings, string collectionName)
        {
            var client = new MongoClient(settings.ConnectionString);

            var database = client.GetDatabase(settings.HeyCuratorDatabaseName);

            _collectionDbContext = database.GetCollection<T>(collectionName);
        }

        public void Create(T entity) =>
            _collectionDbContext.InsertOne(entity);

        public void Update(T entity) =>
            _collectionDbContext.ReplaceOne(e => e.Id == entity.Id, entity);

        public void Delete(T entity) =>
            _collectionDbContext.DeleteOne(e => e.Id == entity.Id);

        public IQueryable<T> FindAll() =>
            _collectionDbContext.AsQueryable<T>().Where(item => true).Select(item => item); // Select optional

        public IQueryable<T> FindAllByCondition(Expression<Func<T, bool>> expression) =>
            _collectionDbContext.AsQueryable<T>().Where(expression);

        public T FindById(string id) =>
            _collectionDbContext.Find<T>(e => e.Id == id).FirstOrDefault();
    }
}

using POC_Mongo.Src.Domain.Entities;

namespace POCMONGO.Domain.Entities
{
    public interface IEntity
    {
        public abstract Task<List<IEntity>> getAll();

        public abstract Task<IEntity> getOne(string id);

        public abstract Task<Boolean> save();

        public abstract Task<Boolean> update();

        public abstract Task<Boolean> delete();
    }
}

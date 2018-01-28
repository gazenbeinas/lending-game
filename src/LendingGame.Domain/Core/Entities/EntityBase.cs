namespace LendingGame.Domain.Core.Entities
{
    public abstract class EntityBase
    {
        protected EntityBase(string id)
        {
            Id = id;
        }

        protected EntityBase()
        {
        }

        public abstract string GenerateId();

        public string Id { get; set; }

        public abstract bool IsValid();
    }
}
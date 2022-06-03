namespace Contracts
{
    public class Entity<T>
    {
        public T Id { get; set; }
    }
    public class Entity : Entity<int> { }
}

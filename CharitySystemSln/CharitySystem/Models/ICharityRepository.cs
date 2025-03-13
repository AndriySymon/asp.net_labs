namespace CharitySystem.Models
{
    public interface ICharityRepository
    {
        IQueryable<Event> Events { get; }
    }
}

using System.Collections.Generic;

namespace CharitySystem.Models.ViewModels
{
    public class EventListViewModel
    {
        public IEnumerable<Event> Events { get; set; } = new List<Event>();
        public PagingInfo PagingInfo { get; set; } = new PagingInfo();
        public string? CurrentCategory { get; set; }
    }
}
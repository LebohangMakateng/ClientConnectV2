using System;
using API.Entities;

namespace API.DTOs
{
    public class GigDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Decimal TaskRate { get; set; }
        public RateType RateType { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Expertise { get; set; }
        public TaskProgress Progress { get; set; }
        
    }
}
using System;
using API.Entities;

namespace API.DTOs
{
    public class GigUpdateDto
    {
        public string Description { get; set; }
        public Decimal TaskRate { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
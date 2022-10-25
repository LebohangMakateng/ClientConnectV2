using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Entities;

namespace API.Entities
{
    public class Gig
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Decimal TaskRate { get; set; }
        [Required]
        public RateType RateType { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Expertise { get; set; }
        public string Username { get; set; }
        public TaskProgress Progress { get; set; }
        public string Hidden { get; set; }
    }

    public enum RateType
    {
        Hourly, ProjectCompleted
    }
}
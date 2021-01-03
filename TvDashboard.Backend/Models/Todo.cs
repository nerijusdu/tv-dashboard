using System;
using SQLite;
using TvDashboard.Backend.Services;

namespace TvDashboard.Backend.Models
{
    public class Todo : ICrudItem
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
﻿using System;

namespace TvDashboard.Dtos
{
    public class TodoDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
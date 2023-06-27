﻿using System.ComponentModel.DataAnnotations;

namespace KPcinema.Models
{
    public class Movie
    {
        public int id { get; set; }
        public string? title { get; set; }
        public string? url { get; set; }
        public string? description { get; set; }
        public string? video { get; set; }

    }
}

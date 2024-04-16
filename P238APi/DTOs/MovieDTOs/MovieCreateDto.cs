﻿using P238MovieAPi.Entities;

namespace P238MovieAPi.DTOs.MovieDTOs
{
    public class MovieCreateDto
    {
        public bool IsDeleted { get; set; }
        public int GenreId { get; set; }
        public string Name { get; set; }
            
        public string Description { get; set; }
        public double Price { get; set; }
        public double CostPrice { get; set; }
        
    }
}

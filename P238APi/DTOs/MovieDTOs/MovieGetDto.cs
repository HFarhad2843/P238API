using P238MovieAPi.Entities;

namespace P238MovieAPi.DTOs.MovieDTOs
{
    public class MovieGetDto
    {
        public int Id { get; set; }
        public int GenreId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
       


    }
}

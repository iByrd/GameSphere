using System.ComponentModel.DataAnnotations;

namespace GameSphere.Models
{
    public class VideoGame
    {
        public int VideoGameId { get; set; }
        public string Title { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public int GenreId { get; set; }  // foreign key property
        public Genre Genre { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int ConsoleId { get; set; }  // foreign key property
        public Console Console { get; set; }
    }
}

namespace GameSphere.Models
{
    public class VideoGameListViewModel
    {
        public List<Genre> Genres { get; set; }
        public List<Console> Consoles { get; set; }
        public List<VideoGame> VideoGames { get; set; }
        public string SelectedGenre { get; set; }
        public string SelectedConsole { get; set; }
        public string CheckActiveGenre(string genre) =>
            genre == SelectedGenre ? "active" : "";
        public string CheckActiveConsole(string console) =>
            console == SelectedConsole ? "active" : "";
    }
}

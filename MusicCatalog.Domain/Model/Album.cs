
namespace MusicCatalog.Domain.Model
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public int PublicationYear { get; set; }
        public string Version { get; set; }
        public string OwnerId { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }
    }
}

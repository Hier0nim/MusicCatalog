
namespace MusicCatalog.Domain.Model
{
    public class Track
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Length { get; set; }
        public int AlbumId { get; set; }
        public virtual Album Album { get; set; }
    }
}
 
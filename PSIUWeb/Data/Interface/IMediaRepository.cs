using PSIUWeb.Models;

namespace PSIUWeb.Data.Interface
{
    public interface IMediaRepository
    {
        
        public Media? GetMediaById(int id);

        public IQueryable<Media>? GetMedias();

        public Media? Update(Media c);

        public Media? Delete(int id);

        public Media? Create(Media c);
    }

}

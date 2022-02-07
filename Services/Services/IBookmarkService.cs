using Entity;
using System.Collections.Generic;

namespace Services
{
    public interface IBookmarkService
    {
        Bookmark CreateBookmark(Bookmark Bookmark);
        List<Bookmark> GetBookmarks();
        Bookmark GetBookmark(int Id);
        Bookmark GetBookmark(string Name);
        void UpdateBookmark(Bookmark Bookmark);
        void DeleteBookmark(Bookmark Bookmark);
    }
}

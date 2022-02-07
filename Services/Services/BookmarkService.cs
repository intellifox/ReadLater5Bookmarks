using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class BookmarkService : IBookmarkService
    {
        private ReadLaterDataContext _ReadLaterDataContext;
        public BookmarkService(ReadLaterDataContext readLaterDataContext)
        {
            _ReadLaterDataContext = readLaterDataContext;
        }

        public Bookmark CreateBookmark(Bookmark bookmark)
        {
            _ReadLaterDataContext.Add(bookmark);
            _ReadLaterDataContext.SaveChanges();
            return bookmark;
        }

        public void DeleteBookmark(Bookmark bookmark)
        {
            _ReadLaterDataContext.Bookmark.Remove(bookmark);
            _ReadLaterDataContext.SaveChanges();
        }

        public Bookmark GetBookmark(int id)
        {

            Bookmark bookmark = _ReadLaterDataContext.Bookmark.Where(b => b.ID == id).Include(c => c.Category).FirstOrDefault();
            bookmark.Counter++;
            _ReadLaterDataContext.SaveChanges();
            return bookmark;
        }

        public Bookmark GetBookmark(string URL)
        {
            return _ReadLaterDataContext.Bookmark.Where(b => b.URL == URL).FirstOrDefault();
        }

        public List<Bookmark> GetBookmarks()
        {
            return _ReadLaterDataContext.Bookmark.ToList();
        }

        public void UpdateBookmark(Bookmark bookmark)
        {
            _ReadLaterDataContext.Update(bookmark);
            _ReadLaterDataContext.SaveChanges();
        }

        public void UpdateCountBookmark(Bookmark bookmark)
        {
            bookmark.Counter++;

            _ReadLaterDataContext.Bookmark.Update(bookmark);
            _ReadLaterDataContext.SaveChanges();
        }
    }
}

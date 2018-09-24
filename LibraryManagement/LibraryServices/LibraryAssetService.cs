using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryServices
{
    public class LibraryAssetService : ILibraryAsset
    {
        private readonly ApplicationDbContext _context;

        public LibraryAssetService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(LibraryAsset asset)
        {
            _context.Add(asset);
            _context.SaveChanges();
        }

        public IEnumerable<LibraryAsset> GetAll()
        {
            return _context.LibraryAssets
                .Include(a => a.Status)
                .Include(a => a.Location);
        }

        public string GetAuthorOrDirector(int id)
        {
            var isBook = _context.LibraryAssets.OfType<Book>()
                .Where(a => a.Id == id).Any();

            var isVideo = _context.LibraryAssets.OfType<Video>()
                .Where(a => a.Id == id).Any();

            return isBook ?
                _context.Books.FirstOrDefault(b => b.Id == id).Author :
                _context.Videos.FirstOrDefault(v => v.Id == id).Director
                ?? "Unknown";
        }

        public LibraryAsset GetById(int id)
        {
            return _context.LibraryAssets
                .Include(a => a.Status)
                .Include(a => a.Location)
                .FirstOrDefault(a => a.Id == id);
        }

        public LibraryBranch GetCurrentLocation(int id)
        {
            return _context.LibraryAssets
                .FirstOrDefault(a => a.Id == id)
                .Location;
        }

        public string GetDeweyIndex(int id)
        {
            if(_context.Books.Any(b => b.Id == id))
            {
                return _context.Books
                    .FirstOrDefault(b => b.Id == id)
                    .DeweyIndex;
            }

            return "";
        }

        public string GetIsbn(int id)
        {
            if(_context.Books.Any(b => b.Id == id))
            {
                return _context.Books
                    .FirstOrDefault(b => b.Id == id)
                    .ISBN;
            }

            return "";
        }

        public string GetTitle(int id)
        {
            return _context.LibraryAssets
                .FirstOrDefault(a => a.Id == id)
                .Title;
        }

        public string GetType(int id)
        {
            var book = _context.LibraryAssets.OfType<Book>()
                .Where(b => b.Id == id);

            return book.Any() ? "Book" : "Video";
        }
    }
}

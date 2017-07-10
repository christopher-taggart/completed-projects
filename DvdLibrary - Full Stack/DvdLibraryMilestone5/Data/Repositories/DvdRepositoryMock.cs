using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DvdLibraryMilestone5.Models;

namespace DvdLibraryMilestone5.Data.Repositories
{
    public class DvdRepositoryMock : IDvdRepository
    {
        private static List<Dvd> _dvds;

        static DvdRepositoryMock()
        {
            _dvds = new List<Dvd>()
            {
                new Dvd { DvdId= 1, RatingId= "PG-13", Title= "Star Wars", Director= "George Lucas", ReleaseYear = "1977"},
                new Dvd { DvdId = 2, RatingId = "PG-13", Title="Terminator", Director = "James Cameron", ReleaseYear = "1984"}
            };
        }

        public void CreateDvd(Dvd dvd)
        {
            if (_dvds.Any())
            {
                dvd.DvdId = _dvds.Max(d => d.DvdId) + 1;
            }
            else
            {
                dvd.DvdId = 0;
            }

            _dvds.Add(dvd);
        }

        public IEnumerable<Dvd> GetAll()
        {
            
            return _dvds;
        }

        public Dvd GetById(int id)
        {
            return _dvds.FirstOrDefault(d => d.DvdId == id);
        }

        public IEnumerable<Dvd> GetbyRating(string rating)
        {
            return _dvds.Where(d=>d.RatingId == rating);
        }

        public IEnumerable<Dvd> GetByTitle(string title)
        {
            return _dvds.Where(d => d.Title.Contains(title));
        }

        public IEnumerable<Dvd> GetByDirector(string director)
        {
            return _dvds.Where(d => d.Director.Contains(director));
        }

        public IEnumerable<Dvd> GetByReleaseYear(string year)
        {
            return _dvds.Where(d => d.ReleaseYear == year);
        }

        public void Update(Dvd dvd)
        {
            _dvds.RemoveAll(d => d.DvdId == dvd.DvdId);
            _dvds.Add(dvd);
        }

        public void Delete(int id)
        {
            _dvds.RemoveAll(d => d.DvdId == id);
        }
    }
}
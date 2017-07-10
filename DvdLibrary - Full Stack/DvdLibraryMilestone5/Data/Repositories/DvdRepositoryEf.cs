using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using DvdLibraryMilestone5.Models;

namespace DvdLibraryMilestone5.Data.Repositories
{
    public class DvdRepositoryEF : IDvdRepository
    {
        private DvdEntities _ctx;

        public DvdRepositoryEF()
        {
            this._ctx = new DvdEntities();
        }
        public void CreateDvd(Dvd dvd)
        {
            _ctx.Dvds.Add(dvd);
            _ctx.SaveChanges();
        }

        public IEnumerable<Dvd> GetAll()
        {
            return _ctx.Dvds;
        }

        public Dvd GetById(int id)
        {
            return _ctx.Dvds.Find(id);
        }

        public IEnumerable<Dvd> GetbyRating(string rating)
        {
            return _ctx.Dvds.Where(d => d.RatingId == rating);
        }

        public IEnumerable<Dvd> GetByTitle(string title)
        {
            var query = _ctx.Dvds.Where(d => d.Title.Contains(title));
            return query;
        }

        public IEnumerable<Dvd> GetByDirector(string director)
        {
            var query = _ctx.Dvds.Where(d => d.Director.Contains(director));
            return query;
        }

        public IEnumerable<Dvd> GetByReleaseYear(string releaseYear)
        {
            return _ctx.Dvds.Where(d => d.ReleaseYear == releaseYear);
        }

        public void Update(Dvd dvd)
        {
            _ctx.Entry(dvd).State = EntityState.Modified;
            _ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            _ctx.Dvds.Remove(GetById(id));
            _ctx.SaveChanges();
        }
    }
}
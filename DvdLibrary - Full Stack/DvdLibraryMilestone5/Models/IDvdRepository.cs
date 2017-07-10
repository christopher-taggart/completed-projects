using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DvdLibraryMilestone5.Models
{
    public interface IDvdRepository
    {
        void CreateDvd(Dvd dvd);
        IEnumerable<Dvd> GetAll();
        Dvd GetById(int id);
        IEnumerable<Dvd> GetbyRating(string rating);
        IEnumerable<Dvd> GetByTitle(string title);
        IEnumerable<Dvd> GetByDirector(string director);
        IEnumerable<Dvd> GetByReleaseYear(string releaseYear);
        void Update(Dvd dvd);
        void Delete(int id);
    }
}
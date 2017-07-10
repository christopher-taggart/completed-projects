using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using DvdLibraryMilestone5.Data;
using DvdLibraryMilestone5.Models;

namespace DvdLibraryMilestone5.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DvdsController : ApiController
    {
        IDvdRepository _repo;
        public DvdsController(IDvdRepository repo)
        {
            _repo = repo;
        }
        public DvdsController() : this(RepositoryFactory.GetRepository())
        {

        }
        [Route("dvds/")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAll()
        {

            IEnumerable<Dvd> dvds = _repo.GetAll();
            
                /*var query = from q in _repo.GetAll()
                select new
                {
                    q.DvdId,
                    q.Title,
                    q.Director,
                    q.ReleaseYear,
                    q.Rating.RatingName
                    
                };*/
            return Ok(dvds);
            //return Ok(_repo.GetAll());
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Get(int id)
        {
            Dvd found = _repo.GetById(id);


            if (found == null)
            {
                return NotFound();
            }
           
            return Ok(found);
        }

        [Route("dvds/rating/{rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByRating(string rating)
        {
            IEnumerable<Dvd> dvds = _repo.GetbyRating(rating);

            if (dvds == null)
            {
                return NotFound();
            }

            
            return Ok(dvds);
        }

        [Route("dvds/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByTitle(string title)
        {
            IEnumerable<Dvd> dvds = _repo.GetByTitle(title);

            if (dvds == null)
            {
                return NotFound();
            }

            return Ok(dvds);
        }

        [Route("dvds/director/{director}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByDirector(string director)
        {
            IEnumerable<Dvd> dvds = _repo.GetByDirector(director);

            if (dvds == null)
            {
                return NotFound();
            }

            
            return Ok(dvds);
        }

        [Route("dvds/year/{releaseYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByReleaseYear(string releaseYear)
        {
            IEnumerable<Dvd> dvds = _repo.GetByReleaseYear(releaseYear);

            if (dvds == null)
            {
                return NotFound();
            }

           
            
            return Ok(dvds);
        }

        [Route("dvd/")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Add(Dvd dvd)
        {
            _repo.CreateDvd(dvd);

            return Created($"dvd/{dvd.DvdId}", dvd);

        }

        [Route("dvd/{id}")]
        [AcceptVerbs("PUT")]
        public void Update(int id, Dvd dvd)
        {
            dvd.DvdId = id;
            _repo.Update(dvd);
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("DELETE")]
        public void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}

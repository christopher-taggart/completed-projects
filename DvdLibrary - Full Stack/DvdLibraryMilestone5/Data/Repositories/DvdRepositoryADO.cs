using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DvdLibraryMilestone5.Models;

namespace DvdLibraryMilestone5.Data.Repositories
{
    public class DVDRepositoryADO : IDvdRepository
    {
        public void CreateDvd(Dvd dvd)
        {
            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {

                SqlCommand cmd = new SqlCommand("DvdsInsert", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                cmd.Parameters.AddWithValue("@RatingId", dvd.RatingId);
                cmd.Parameters.AddWithValue("@Director", dvd.Director);
                cmd.Parameters.AddWithValue("@ReleaseYear", dvd.ReleaseYear);
                cmd.Parameters.AddWithValue("@Notes", dvd.Notes);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                }

            }
        }

        public IEnumerable<Dvd> GetAll()
        {
            List<Dvd> results = new List<Dvd>();
            
            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdsSelectAll", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Dvd d = new Dvd();

                        d.DvdId = int.Parse(dr["DvdId"].ToString());
                        d.Title = dr["Title"].ToString();
                        d.RatingId = dr["RatingId"].ToString();
                        d.Director = dr["Director"].ToString();
                        d.ReleaseYear = dr["ReleaseYear"].ToString();
                        d.Notes = dr["Notes"].ToString();

                        results.Add(d);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                }
            }

            return results;
        }

        public Dvd GetById(int id)
        {
            Dvd dvd = null;
            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {

                SqlCommand cmd = new SqlCommand("DvdsSelectById", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DvdId", id);

                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    // if instead of while?
                    while (dr.Read())
                    {
                        Dvd d = new Dvd();

                        d.DvdId = int.Parse(dr["DvdId"].ToString());
                        d.Title = dr["Title"].ToString();
                        d.RatingId = dr["RatingId"].ToString();
                        d.Director = dr["Director"].ToString();
                        d.ReleaseYear = dr["ReleaseYear"].ToString();
                        d.Notes = dr["Notes"].ToString();
                        dvd = d;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                }
            }
            return dvd;
        }

        public IEnumerable<Dvd> GetbyRating(string rating)
        {
            List<Dvd> results = new List<Dvd>();

            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdsSelectByRatingId", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RatingId", rating);
                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Dvd d = new Dvd();

                        d.DvdId = int.Parse(dr["DvdId"].ToString());
                        d.Title = dr["Title"].ToString();
                        d.RatingId = dr["RatingId"].ToString();
                        d.Director = dr["Director"].ToString();
                        d.ReleaseYear = dr["ReleaseYear"].ToString();
                        d.Notes = dr["Notes"].ToString();

                        results.Add(d);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                }
            }

            return results;
        }

        public IEnumerable<Dvd> GetByTitle(string title)
        {
            List<Dvd> results = new List<Dvd>();

            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdsSelectByTitle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Title", title);
                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Dvd d = new Dvd();

                        d.DvdId = int.Parse(dr["DvdId"].ToString());
                        d.Title = dr["Title"].ToString();
                        d.RatingId = dr["RatingId"].ToString();
                        d.Director = dr["Director"].ToString();
                        d.ReleaseYear = dr["ReleaseYear"].ToString();
                        d.Notes = dr["Notes"].ToString();

                        results.Add(d);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                }
            }

            return results;
        }

        public IEnumerable<Dvd> GetByDirector(string director)
        {
            List<Dvd> results = new List<Dvd>();

            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdsSelectByDirector", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Director", director);
                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Dvd d = new Dvd();

                        d.DvdId = int.Parse(dr["DvdId"].ToString());
                        d.Title = dr["Title"].ToString();
                        d.RatingId = dr["RatingId"].ToString();
                        d.Director = dr["Director"].ToString();
                        d.ReleaseYear = dr["ReleaseYear"].ToString();
                        d.Notes = dr["Notes"].ToString();

                        results.Add(d);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                }
            }

            return results;
        }

        public IEnumerable<Dvd> GetByReleaseYear(string releaseYear)
        {   
            List<Dvd> results = new List<Dvd>();

            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdsSelectByReleaseYear", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ReleaseYear", releaseYear);
                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Dvd d = new Dvd();

                        d.DvdId = int.Parse(dr["DvdId"].ToString());
                        d.Title = dr["Title"].ToString();
                        d.RatingId = dr["RatingId"].ToString();
                        d.Director = dr["Director"].ToString();
                        d.ReleaseYear = dr["ReleaseYear"].ToString();
                        d.Notes = dr["Notes"].ToString();

                        results.Add(d);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                }
            }

            return results;
        }

        public void Update(Dvd dvd)
        {
            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdsUpdate", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DvdId", dvd.DvdId);
                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                cmd.Parameters.AddWithValue("@RatingId", dvd.RatingId);
                cmd.Parameters.AddWithValue("@Director", dvd.Director);
                cmd.Parameters.AddWithValue("@ReleaseYear", dvd.ReleaseYear);
                cmd.Parameters.AddWithValue("@Notes", dvd.Notes);
                

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                }
            }

        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {


                SqlCommand cmd = new SqlCommand("DvdsDelete", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DvdId", id);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
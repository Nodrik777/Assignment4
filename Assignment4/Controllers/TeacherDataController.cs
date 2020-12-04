using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Assignment4.Models;
using MySql.Data.MySqlClient;

namespace Assignment4.Controllers
{
    public class TeacherDataController : ApiController
    {
        // GET: api/TeacherData
        private TeacherDBContext Blog = new TeacherDBContext();

        // This controller will access 'Teacher table' for our assignment database.
        /// <summary>
        /// Return list of teachers 
        /// </summary>
        /// <example> GET api/TeacherData/ListTeachers</example>
        /// <returns>
        /// A list of Teachers
        /// </returns>
        [HttpGet]

        public IEnumerable<Teacher> ListTeachers(string SearchKey=null)
        {
            //Creating a connection
            MySqlConnection Conn = Blog.AccessDatabase();

            //Open the connection between web server and database
            Conn.Open();

            //Setting a new command for a database
            MySqlCommand cmd = Conn.CreateCommand();

            // Sql Query
            cmd.CommandText = "Select * from Teachers where teachername like '%"+SearchKey+"%' or teacherlname " +
                "like '%"+SearchKey+"%' ";

            //Getting result Set of query into variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Creating an empty list of Teacher names
            List<Teacher> Teachers = new List<Teacher> { };

            while (ResultSet.Read())
            {
                int TeacherId = (int)ResultSet["teacherid"];
                string TeacherFname = (string)ResultSet["teacherfname"];
                string TeacherLname = (string)ResultSet["teacherlname"];
                string Employeenumber = (string)ResultSet["employeenumber"];


                Teacher NewTeacher = new Teacher();
                NewTeacher.Teacherid = TeacherId;
                NewTeacher.TeacherFname = TeacherFname;
                NewTeacher.TeacherLname = TeacherLname;
                NewTeacher.Employeenumber = Employeenumber;


                Teachers.Add(NewTeacher);
            }

            //Closing connection
            Conn.Close();

            //Returning final list of Teachers
            return Teachers;

        
        [HttpGet]

            public Teacher FindTeacher(int id)
        {
                Teacher NewTeacher = new Teacher();


             MySqlConnection Conn = Blog.AccessDatabase();

            //Open the connection between web server and database
            Conn.Open();

            //Setting a new command for a database
            MySqlCommand cmd = Conn.CreateCommand();

            // Sql Query
            cmd.CommandText = "Select * from Teachers where teacherid = "+id;

            //Getting result Set of query into variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                int TeacherId = (int)ResultSet["teacherid"];
                string TeacherFname = (string)ResultSet["teacherfname"];
                string TeacherLname = (string)ResultSet["teacherlname"];
                string Employeenumber = (string)ResultSet["employeenumber"];


                
                NewTeacher.Teacherid = TeacherId;
                NewTeacher.TeacherFname = TeacherFname;
                NewTeacher.TeacherLname = TeacherLname;
                NewTeacher.Employeenumber = Employeenumber;
            }

                return NewTeacher;          
         }
            [HttpPost]

            public void DeleteTeacher(int id)
            {

                MySqlConnection cmd = Blog.AccessDatabase();

                Conn.Open();

                cmd.CommandText = "Delete from teachers where=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Prepare();

                cmd.ExecuteNonQuery();
                Conn.Close();

            }
        
            [HttpPost]

            public void AddTeacher(int id)
            {

                MySqlConnection cmd = Blog.AccessDatabase();

                Conn.Open();

                // I could not find correct query to insert into teachers table
                // 'Insert into teacher (columns) values ();
                cmd.CommandText = "Insert into teachers (teacherid, teacherfname, teacherlname, employeenumber) " +
                        "values (@id)"; 


                cmd.Parameters.AddWithValue("@id", id);
                cmd.Prepare();

                cmd.ExecuteNonQuery();
                Conn.Close();

        }
      }
    }

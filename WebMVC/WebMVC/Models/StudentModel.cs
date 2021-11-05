using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class StudentModel
    {

        public int mssv { get; set; }

        public string fullname { get; set; }

        public string classname { get; set; }

        public string sex { get; set; }

        public double gpa { get; set; }

        public StudentModel ()
        {

        }
    }
}
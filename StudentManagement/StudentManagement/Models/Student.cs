using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class Student
    {
        public int id { get; set; }

        public string fullname { get; set; }

        public string classname { get; set; }

        public string sex { get; set; }

        public double gpa { get; set; }

        public DateTime birth { get; set; }

        public Student()
        { }

    }
}

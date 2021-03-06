﻿using System;
using System.Collections.Generic;

namespace EF6.Integration.Console.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string StudentName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public decimal Height { get; set; }

        public float Weight { get; set; }

        public byte[] RowVersion { get; set; }

        public int? GradeId { get; set; }

        public virtual Grade Grade { get; set; }

        public int Age { get; set; }

        public virtual StudentAddress Address { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

    }
}

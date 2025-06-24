using System;
using System.Collections.Generic;

namespace CrudPractise.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string StudentName { get; set; } = null!;

    public string? StdAddress { get; set; }

    public int? CourseId { get; set; }

    public virtual Course? Course { get; set; }
}

using System;
using System.ComponentModel.DataAnnotations;

public class Course
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public int Credits { get; set; }

    // Propriété de navigation
    public virtual List<Enrollment> Enrollments { get; set; }
}

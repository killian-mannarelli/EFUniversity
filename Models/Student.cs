using System;
using System.ComponentModel.DataAnnotations;

public class Student
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public DateTime EnrollmentDate { get; set; }

    // Navigation property
    public virtual List<Enrollment> Enrollments { get; set; }
}

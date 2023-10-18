using System;
using System.ComponentModel.DataAnnotations;

public class Enrollment
{
    [Required]
    public int Id { get; set; }

    public Grade? Grade { get; set; }

    [Required]
    public int StudentId { get; set; }

    [Required]
    public int CourseId { get; set; }

    // Propriétés de navigation
    public virtual Student Student { get; set; }
    public virtual Course Course { get; set; }
}

public enum Grade
{
    A,
    B,
    C,
    D,
    F
}

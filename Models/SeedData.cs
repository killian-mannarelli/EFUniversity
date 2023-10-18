using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

public static class SeedData
{
    public static void Initialize(UniversityContext context)
    {
        context.Database.EnsureCreated();

        // Check if any students exist
        if (context.Student.Any())
        {
            return; // DB has been seeded
        }

        var students = new Student[]
        {
            new Student
            {
                FirstName = "Alexander",
                LastName = "Carson",
                EnrollmentDate = DateTime.Parse("2016-09-01")
            },
            new Student
            {
                FirstName = "Meredith",
                LastName = "Alonso",
                EnrollmentDate = DateTime.Parse("2018-09-01")
            },
            new Student
            {
                FirstName = "Arturo",
                LastName = "Anand",
                EnrollmentDate = DateTime.Parse("2019-09-01")
            },
            new Student
            {
                FirstName = "Gytis",
                LastName = "Barzdukas",
                EnrollmentDate = DateTime.Parse("2018-09-01")
            }
        };
        context.Student.AddRange(students);
        context.SaveChanges();

        var courses = new Course[]
        {
            new Course
            {
                Id = 1050,
                Title = "Chemistry",
                Credits = 3
            },
            new Course
            {
                Id = 4022,
                Title = "Microeconomics",
                Credits = 3
            },
            new Course
            {
                Id = 4041,
                Title = "Macroeconomics",
                Credits = 3
            },
            new Course
            {
                Id = 1045,
                Title = "Calculus",
                Credits = 4
            }
        };
        context.Course.AddRange(courses);
        context.SaveChanges();

        var enrollments = new Enrollment[]
        {
            new Enrollment
            {
                StudentId = students[0].Id,
                CourseId = courses[0].Id,
                Grade = Grade.A
            },
            new Enrollment
            {
                StudentId = students[0].Id,
                CourseId = courses[1].Id,
                Grade = Grade.C
            },
            new Enrollment
            {
                StudentId = students[1].Id,
                CourseId = courses[3].Id,
                Grade = Grade.B
            },
            new Enrollment { StudentId = students[2].Id, CourseId = courses[0].Id },
            new Enrollment
            {
                StudentId = students[2].Id,
                CourseId = courses[1].Id,
                Grade = Grade.B
            },
            new Enrollment
            {
                StudentId = students[3].Id,
                CourseId = courses[0].Id,
                Grade = Grade.C
            }
        };
        context.Enrollment.AddRange(enrollments);
        context.SaveChanges();
    }
}

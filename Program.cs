using Microsoft.EntityFrameworkCore;

using (var db = new UniversityContext())
{
    var courses = db.Course.OrderBy(c => c.Title).ToList();

    var students = db.Student.OrderByDescending(s => s.Id).ToList();

    var studentCarsonDetails = db.Student
        .Where(s => s.FirstName == "Alexander" && s.LastName == "Carson")
        .Include(s => s.Enrollments)
        .Select(
            s =>
                new
                {
                    s.Id,
                    s.FirstName,
                    s.LastName,
                    Enrollments = s.Enrollments.Select(e => new { e.CourseId, e.Grade }).ToList()
                }
        )
        .FirstOrDefault();

    var studentsEnrolledInChemistry = db.Course
        .Where(c => c.Title == "Chemistry")
        .Include(c => c.Enrollments)
        .ThenInclude(e => e.Student)
        .SelectMany(c => c.Enrollments)
        .Select(
            e =>
                new
                {
                    e.Student.Id,
                    e.Student.FirstName,
                    e.Student.LastName
                }
        )
        .ToList();

    var alonso = db.Student.SingleOrDefault(
        s => s.FirstName == "Meredith" && s.LastName == "Alonso"
    );
    var chemistry = db.Course.SingleOrDefault(c => c.Title == "Chemistry");

    if (alonso != null && chemistry != null)
    {
        var newEnrollment = new Enrollment { StudentId = alonso.Id, CourseId = chemistry.Id, };
        db.Enrollment.Add(newEnrollment);
    }

    var anand = db.Student.SingleOrDefault(s => s.FirstName == "Arturo" && s.LastName == "Anand");
    if (anand != null && chemistry != null)
    {
        var anandEnrollment = db.Enrollment.SingleOrDefault(
            e => e.StudentId == anand.Id && e.CourseId == chemistry.Id
        );
        if (anandEnrollment != null)
        {
            anandEnrollment.Grade = Grade.D;
        }
    }

    db.SaveChanges();

    var Barzdukas = db.Student.SingleOrDefault(s => s.LastName == "Barzdukas");

    if (Barzdukas != null)
    {
        db.Student.Remove(Barzdukas);
    }

    var carson = db.Student.SingleOrDefault(
        s => s.FirstName == "Alexander" && s.LastName == "Carson"
    );

    if (carson != null && chemistry != null)
    {
        var carsonChemistryEnrollment = db.Enrollment.SingleOrDefault(
            e => e.StudentId == carson.Id && e.CourseId == chemistry.Id
        );
        if (carsonChemistryEnrollment != null)
        {
            db.Enrollment.Remove(carsonChemistryEnrollment);
        }
    }

    db.SaveChanges();
}

/*Proiect
• Student este caracterizat de 
urmatoarele
• Nume
• Prenume
• Varsta
• Adresa
• Adresa este caracterizata de
• Oras:string
• Strada
• Numar
• Creeati modelul, populati DB
• Adaugati PK, FK precum si relatiile
necesare
• Scrieti functii pentru
• Obtinerea tuturor studentilor
• Obtinerea unui student dupa ID
• Creeare student
• Stergere student
• Modificare date student
• Obtinerea adresei unui student
• Modificare adresa student
• In cazul in care studentul nu are adresa, 
aceasta va fi creeata
• Stergerea unui student
• Cu un parametru care va specifica daca
adresa este la randul ei stearsa
*/
using Microsoft.EntityFrameworkCore;
using ProiectWON7.Data;
using ProiectWON7.Data.Models;

//using var dbCtx = new StudentsDbContext();
//dbCtx.SaveChanges();
//Seed();
//GetAllStudents();
//GetStudentById(1);
var student = new Student { Name = "dent8", Surname = "Stu", Age = 28 };
var address = new Address { City = "City", Street = "Street", Number = 8 ,Student=student};
//var address2 = new Address { City = "City", Street = "Street", Number = 8, Student = student };

CreateStudent(student, address);
//RemoveStudent(student);
//UpdateStudent(student, "dent10", "Stu", 30);
ObtainAddress(student);
//UpdateAddress(student, address2);
//Console.WriteLine(DeleteStudent(student));

bool DeleteStudent(Student student)
{
    using var dbCtx = new StudentsDbContext();
    var studentId=student.Id;
    dbCtx.Students.Remove(student);
    dbCtx.SaveChanges();
    return dbCtx.Addresses.FirstOrDefault(a => a.StudentId==studentId) == null;
}

void UpdateAddress(Student student, Address address2)
{
    using var dbCtx = new StudentsDbContext();
    var studentToUpdate=dbCtx.Students.Include(s=>s.Address).FirstOrDefault(s=>s.Id == student.Id);
    studentToUpdate.Address = address2;
    dbCtx.SaveChanges();
}

Address ObtainAddress(Student student)
{
    using var dbCtx = new StudentsDbContext();
    return dbCtx.Addresses.FirstOrDefault(s => s.StudentId == student.Id);
}

void UpdateStudent(Student studentToUpdate, string Name, string Surname, int age)
{
    using var dbCtx = new StudentsDbContext();
    var student = dbCtx.Students.FirstOrDefault(s=>s.Id==studentToUpdate.Id);
    student.Name = Name;
    student.Surname = Surname;
    student.Age = age;
    dbCtx.SaveChanges();
}

void RemoveStudent(Student student)
{
    using var dbCtx = new StudentsDbContext();
    dbCtx.Students.Remove(student);
    dbCtx.SaveChanges();
}

void CreateStudent(Student student, Address address)
{
    using var dbCtx = new StudentsDbContext();
    dbCtx.Students.Add(student);
    dbCtx.Addresses.Add(address);
    dbCtx.SaveChanges();
}

Student GetStudentById(int id)
{
    using var dbCtx = new StudentsDbContext();
    return dbCtx.Students.Include(s=>s.Address).FirstOrDefault(s=>s.Id==id);
}

List<Student> GetAllStudents()
{
    using var dbCtx = new StudentsDbContext();
    return dbCtx.Students.Include(s => s.Address).ToList();
}

void Seed()
{
    using var dbContext = new StudentsDbContext();
    var student1 = new Student
    {
        Name = "dent1",
        Surname = "Stu",
        Age = 21
    };
    var student2 = new Student
    {
        Name = "dent2",
        Surname = "Stu",
        Age = 22
    };
    var student3 = new Student
    {
        Name = "dent3",
        Surname = "Stu",
        Age = 23
    };
    var student4 = new Student
    {
        Name = "dent4",
        Surname = "Stu",
        Age = 24
    };
    var student5 = new Student
    {
        Name = "dent5",
        Surname = "Stu",
        Age = 25
    };
    var student6 = new Student
    {
        Name = "dent6",
        Surname = "Stu",
        Age = 26
    };
    var student7 = new Student
    {
        Name = "dent7",
        Surname = "Stu",
        Age = 27
    };

    dbContext.Students.Add(student1);
    dbContext.Students.Add(student2);
    dbContext.Students.Add(student3);
    dbContext.Students.Add(student4);
    dbContext.Students.Add(student5);
    dbContext.Students.Add(student6);
    dbContext.Students.Add(student7);

    dbContext.Addresses.Add(new Address { City = "City", Street = "Street", Number = 1 ,Student=student1});
    dbContext.Addresses.Add(new Address { City = "City", Street = "Street", Number = 2, Student = student2 });
    dbContext.Addresses.Add(new Address { City = "City", Street = "Street", Number = 3, Student = student3 });
    dbContext.Addresses.Add(new Address { City = "City", Street = "Street", Number = 4, Student = student4 });
    dbContext.Addresses.Add(new Address { City = "City", Street = "Street", Number = 5, Student = student5 });
    dbContext.Addresses.Add(new Address { City = "City", Street = "Street", Number = 6, Student = student6 });
    dbContext.Addresses.Add(new Address { City = "City", Street = "Street", Number = 7, Student = student7 });

    dbContext.SaveChanges();
}

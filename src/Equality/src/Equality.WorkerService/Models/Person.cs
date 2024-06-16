namespace Equality.WorkerService.Models;

public class Person
{
    public Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName { get; init; }
    public string LastName { get; init; }
}

public class Student : Person
{
    public Student(string firstName, string lastName) : base(firstName, lastName)
    {
    }
}

public class PhD : Student
{
    public PhD(string firstName, string lastName) : base(firstName, lastName)
    {
    }
}

public class Professor : PhD
{
    public Professor(string firstName, string lastName) : base(firstName, lastName)
    {
    }
}

public class Author : Person
{
    public Author(string firstName, string lastName) : base(firstName, lastName)
    {
    }
}
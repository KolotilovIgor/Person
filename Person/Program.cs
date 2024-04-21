using System;
using System.Collections.Generic;

class Person
{
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public List<Person> Children { get; set; }
    public Person Spouse { get; set; }

    public Person(string name, DateTime birthDate)
    {
        Name = name;
        BirthDate = birthDate;
        Children = new List<Person>();
        Spouse = null;
    }

    public void AddChild(Person child)
    {
        Children.Add(child);
    }

    public void SetSpouse(Person spouse)
    {
        Spouse = spouse;
    }

    public override string ToString()
    {
        return $"{Name} (родился/родилась {BirthDate.ToShortDateString()})";
    }

    public void PrintFamilyTree()
    {
        Console.WriteLine($"Личность: {Name} (родился/родилась {BirthDate.ToShortDateString()})");
        Console.WriteLine("│");
        if (Spouse != null)
        {
            Console.WriteLine($"└─ Супруг(а): {Spouse.Name} (родился/родилась {BirthDate.ToShortDateString()})");
            Console.WriteLine("│");
        }

        Console.WriteLine("└─ Дети:");        
        foreach (var child in Children)
        {
            Console.WriteLine($"└─ {child.Name} (родился/родилась {BirthDate.ToShortDateString()})");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {

        Person father = new Person("Иван", new DateTime(1970, 5, 10));
        Person mother = new Person("Мария", new DateTime(1975, 8, 15));
        Person child1 = new Person("Алексей", new DateTime(1995, 3, 20));
        Person child2 = new Person("Елена", new DateTime(2000, 7, 25));

        father.SetSpouse(mother);
        mother.SetSpouse(father);
        father.AddChild(child1);
        mother.AddChild(child1);
        father.AddChild(child2);
        mother.AddChild(child2);

        // Выводим информацию о семье
        Console.WriteLine("Генеалогическое дерево:");
        father.PrintFamilyTree();
        Console.WriteLine();
        mother.PrintFamilyTree();
    }
}
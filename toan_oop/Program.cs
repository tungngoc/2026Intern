using System.Diagnostics;
using System.Runtime.CompilerServices;

public class Person
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public virtual void DisplayInfo()
    {
        Console.WriteLine("ID: ", Id);
        Console.WriteLine("Name ", Name);
    }
}

public class Student : Person
{
    public string? Grade { get; set; }
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Grade: ", Grade);
    }
}

public class Librarian : Person
{
    public string? EmployeeNumber { get; set; }
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Employee Number: " ,EmployeeNumber);
    }
}

public abstract class LibraryItem
{
    public int? ItemId { get; set; }
    public string? Title { get; set; }

    public abstract string GetItemType();

}

public class Book : LibraryItem
{
    public string? Author { get; set; }
    public override string GetItemType()
    {
        return "Book";
    }
}

public class DVD : LibraryItem
{
    private int duration;
    public int Duration
    {
        get => duration;
        set
        {
            if (value < 0)
                throw new ArgumentException("Duration can not negative");
            duration = value;
        }
    }
    public  override string GetItemType()
    {
        return "DVD";
    }

}

public class Library
{
    public List<LibraryItem> LibraryItems { get; set; }

    public Library()
    {
        LibraryItems = new List<LibraryItem>();
    }
    public void AddItem(LibraryItem item)
    {
        LibraryItems.Add(item);
    }

    public void RemoveItem(int itemID)
    {
        LibraryItems.RemoveAll(i => i.ItemId == itemID); 
    }

    public void DisplayAllItems()
    {
        foreach (var item in LibraryItems)
        {
            Console.WriteLine($"ID: {item.ItemId}, Title: {item.Title}, Type: {item.GetItemType()}");
        }
    }
}

public class Program
{
    public static void Main()
    {
        // Create people
        Student student = new Student
        {
            Id = 1,
            Name = "Alice",
            Grade = "A"
        };

        Librarian librarian = new Librarian
        {
            Id = 2,
            Name = "Mr. Smith",
            EmployeeNumber = "LIB123"
        };

        // Display people info
        Console.WriteLine("---- People ----");
        student.DisplayInfo();
        Console.WriteLine();
        librarian.DisplayInfo();

        // Create library items
        Book book1 = new Book
        {
            ItemId = 101,
            Title = "C# Programming",
            Author = "John Doe"
        };

        DVD dvd1 = new DVD
        {
            ItemId = 201,
            Title = "OOP Concepts",
            Duration = 120
        };

        // Create library
        Library library = new Library();

        // Add items
        library.AddItem(book1);
        library.AddItem(dvd1);

        // Display library items
        Console.WriteLine("\n---- Library Items ----");
        library.DisplayAllItems();

        // Remove an item
        Console.WriteLine("\nRemoving item with ID 101...");
        library.RemoveItem(101);

        // Display again
        Console.WriteLine("\n---- Library Items After Removal ----");
        library.DisplayAllItems();

        Console.WriteLine("\nProgram finished. Press any key to exit.");
        Console.ReadKey();
    }
}






// C# program to illustrate the
// Initialization of an object
using System;

// Class Declaration
public class Dog
{

    // Instance Variables
    String name;
    String breed;
    int age;
    String color;

    // Constructor Declaration of Class
    public Dog(String name, String breed,
                int age, String color)
    {
        this.name = name;
        this.breed = breed;
        this.age = age;
        this.color = color;
    }

    // Property 1
    public String GetName()
    {
        return name;
    }

    // Property 2
    public String GetBreed()
    {
        return breed;
    }

    // Property 3
    public int GetAge()
    {
        return age;
    }

    // Property 4
    public String GetColor()
    {
        return color;
    }

    // Method 1
    public String ToString()
    {
        return ("Hi my name is " + this.GetName()
                + ".\nMy breed, age and color are " + this.GetBreed()
                + ", " + this.GetAge() + ", " + this.GetColor());
    }

    // Main Method
    public static void Main(String[] args)
    {

        // Creating object
        Dog tuffy = new Dog("tuffy", "papillon", 5, "white");
        Console.WriteLine(tuffy.ToString());
    }
}

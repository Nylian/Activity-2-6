using System;

public struct Time
{
    private readonly int minutes;

    // Constructor with hours and minutes
    public Time(int hh, int mm)
    {
        this.minutes = 60 * hh + mm;
    }

    // Additional constructor with total minutes
    public Time(int totalMinutes)
    {
        this.minutes = totalMinutes;
    }

    // Read-only Hour property
    public int Hour
    {
        get { return minutes / 60; }
    }

    // Read-only Minute property
    public int Minute
    {
        get { return minutes % 60; }
    }

    // Read-only TotalMinutes property
    public int TotalMinutes
    {
        get { return minutes; }
    }

    // Overload + operator
    public static Time operator +(Time t1, Time t2)
    {
        return new Time(t1.minutes + t2.minutes);
    }

    // Overload - operator
    public static Time operator -(Time t1, Time t2)
    {
        return new Time(t1.minutes - t2.minutes);
    }

    public override string ToString()
    {
        return string.Format("{0:D2}:{1:D2}", Hour, Minute);
    }
}

public class TestTime
{
    public static void Main()
    {
        // Create Time variables
        Time morning = new Time(10, 5);    // 10:05
        Time afternoon = new Time(14, 30); // 14:30
        Time lateNight = new Time(23, 45);  // 23:45

        // Test operator overloading
        Time sum = morning + afternoon;
        Time difference = lateNight - morning;

        // Create Time using the new constructor
        Time fromMinutes = new Time(125); // 02:05

        Console.WriteLine("Morning time: " + morning);
        Console.WriteLine("Afternoon time: " + afternoon);
        Console.WriteLine("Late night time: " + lateNight);

        Console.WriteLine("\nOperator overloading results:");
        Console.WriteLine($"{morning} + {afternoon} = {sum}");
        Console.WriteLine($"{lateNight} - {morning} = {difference}");

        Console.WriteLine("\nUsing the Time(int) constructor:");
        Console.WriteLine("125 minutes = " + fromMinutes);

        // Demonstrate wrapping around midnight
        Time longTime = new Time(25, 30); // 25:30 (next day)
        Time shortTime = new Time(1, 15); // 01:15
        Time wrapAround = longTime - shortTime;

        Console.WriteLine("\nTesting time wrapping:");
        Console.WriteLine($"{longTime} - {shortTime} = {wrapAround}");
        Console.WriteLine($"Total minutes in {wrapAround}: {wrapAround.TotalMinutes}");
    }
}
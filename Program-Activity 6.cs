using System;

public struct Time
{
    private readonly int minutes;

    // Constructor with hours and minutes
    public Time(int hh, int mm)
    {
        this.minutes = 60 * hh + mm;
    }

    // Constructor with total minutes
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

    // Implicit conversion from int (minutes) to Time
    public static implicit operator Time(int minutes)
    {
        return new Time(minutes);
    }

    // Explicit conversion from Time to int (minutes)
    public static explicit operator int(Time time)
    {
        return time.minutes;
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
        // Demonstrate implicit conversion (int to Time)
        Time timeFromInt = 125; // 125 minutes = 02:05
        Console.WriteLine("Implicit conversion from int:");
        Console.WriteLine($"125 minutes = {timeFromInt}");

        // Demonstrate explicit conversion (Time to int)
        Time afternoon = new Time(14, 30);
        int minutes = (int)afternoon;
        Console.WriteLine("\nExplicit conversion to int:");
        Console.WriteLine($"{afternoon} = {minutes} minutes");

        // Using conversions in expressions
        Time result = 90 + afternoon; // implicit conversion of 90
        Console.WriteLine("\nUsing conversions in expressions:");
        Console.WriteLine($"90 + {afternoon} = {result}");

        int totalMinutes = (int)(afternoon + 45); // explicit conversion
        Console.WriteLine($"{afternoon} + 45 minutes = {totalMinutes} minutes");

        // Chaining conversions
        Time t1 = 60; // 01:00
        Time t2 = new Time(1, 30); // 01:30
        int diff = (int)(t2 - t1); // 30 minutes
        Console.WriteLine("\nChaining conversions:");
        Console.WriteLine($"{t2} - {t1} = {diff} minutes");
    }
}
using System;

public struct Time
{
    private readonly int minutes;

    public Time(int hh, int mm)
    {
        this.minutes = 60 * hh + mm;
    }

    public override string ToString()
    {
        // Format as HH:MM for better readability
        return $"{minutes / 60:D2}:{minutes % 60:D2}";
    }
}

public class TestTime
{
    public static void Main()
    {
        // Create some Time variables
        Time morning = new Time(10, 5);  // 10:05 AM
        Time midnight = new Time(0, 45); // 00:45 AM
        Time afternoon = new Time(14, 30); // 2:30 PM

        // Print the times
        Console.WriteLine("Morning time: " + morning);
        Console.WriteLine("Midnight time: " + midnight);
        Console.WriteLine("Afternoon time: " + afternoon);

        // Create and print another time
        Time customTime = new Time(23, 59);
        Console.WriteLine("Custom time: " + customTime);
    }
}
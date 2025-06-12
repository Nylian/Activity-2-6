using System;

public struct Time
{
    private readonly int minutes;

    public Time(int hh, int mm)
    {
        this.minutes = 60 * hh + mm;
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

    public override string ToString()
    {
        return string.Format("{0:D2}:{1:D2}", Hour, Minute);
    }
}

public class TestTime
{
    public static void Main()
    {
        // Create some Time variables
        Time morning = new Time(10, 5);    // 10:05
        Time midnight = new Time(0, 45);    // 00:45
        Time afternoon = new Time(14, 30);  // 14:30
        Time lateNight = new Time(23, 45);   // 23:45

        // Print the times using ToString()
        Console.WriteLine("Morning time: " + morning);
        Console.WriteLine("Midnight time: " + midnight);
        Console.WriteLine("Afternoon time: " + afternoon);
        Console.WriteLine("Late night time: " + lateNight);

        // Demonstrate using the properties
        Console.WriteLine("\nTesting properties:");
        Console.WriteLine($"Late night time is {lateNight.Hour} hours and {lateNight.Minute} minutes");
        Console.WriteLine($"Afternoon time is {afternoon.Hour:D2}:{afternoon.Minute:D2}");
    }
}
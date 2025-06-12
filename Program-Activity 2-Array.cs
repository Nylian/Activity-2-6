using System;

public class StudentGrades
{
    public static void Main(string[] args)
    {
        // Declare and initialize a 2D array to store grades for 5 students across 3 subjects.
        int[,] grades = {
            {85, 92, 78},
            {90, 88, 95},
            {76, 80, 85},
            {92, 98, 89},
            {88, 75, 90}
        };

        // Display all the grades in a matrix form.
        Console.WriteLine("Student Grades:");
        for (int i = 0; i < grades.GetLength(0); i++)
        {
            for (int j = 0; j < grades.GetLength(1); j++)
            {
                Console.Write(grades[i, j] + "\t");
            }
            Console.WriteLine();
        }

        // Calculate and display the average grade for each student.
        Console.WriteLine("\nAverage Grades:");
        for (int i = 0; i < grades.GetLength(0); i++)
        {
            double sum = 0;
            for (int j = 0; j < grades.GetLength(1); j++)
            {
                sum += grades[i, j];
            }
            double average = sum / grades.GetLength(1);
            Console.WriteLine($"Student {i + 1}: {average:F2}");
        }

        // Find the highest grade for each subject and display the result.
        Console.WriteLine("\nHighest Grades per Subject:");
        for (int j = 0; j < grades.GetLength(1); j++)
        {
            int highest = grades[0, j];
            for (int i = 1; i < grades.GetLength(0); i++)
            {
                if (grades[i, j] > highest)
                {
                    highest = grades[i, j];
                }
            }
            Console.WriteLine($"Subject {j + 1}: {highest}");
        }
    }
}

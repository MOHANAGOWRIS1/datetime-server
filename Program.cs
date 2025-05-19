using System;
class Program
{
    static void Main(string[] args)
    {
        // Get the local time.
        DateTime localTime = DateTime.Now;
        Console.WriteLine("Local Time: " + localTime);

        // List of country time zones as examples.
        string[] timeZones = { "Pacific Standard Time", // USA (California)
                               "Eastern Standard Time", // USA (New York)
                               "Central European Standard Time", // Germany
                               "India Standard Time", // India
                               "Greenwich Mean Time", // UK
                               "Australian Eastern Standard Time" // Australia
                             };

        Console.WriteLine("\nSelect a time zone from the following options:");
        for (int i = 0; i < timeZones.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {timeZones[i]}");
        }

        Console.Write("\nEnter the number of your choice: ");
        string userInput = Console.ReadLine();

        try
        {
            // Validate user input and parse it.
            int choice = int.Parse(userInput);
            if (choice < 1 || choice > timeZones.Length)
            {
                throw new ArgumentOutOfRangeException("Invalid choice. Please select a valid time zone number.");
            }

            // Get the selected time zone.
            string selectedTimeZoneId = timeZones[choice - 1];
            TimeZoneInfo targetTimeZone = TimeZoneInfo.FindSystemTimeZoneById(selectedTimeZoneId);

            // Convert local time to the selected time zone.
            DateTime targetTime = TimeZoneInfo.ConvertTime(localTime, TimeZoneInfo.Local, targetTimeZone);
            Console.WriteLine($"Time in {selectedTimeZoneId}: {targetTime}");
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Error: Invalid input format. Please enter a number.");
            Console.WriteLine("Exception message: " + ex.Message);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        catch (TimeZoneNotFoundException ex)
        {
            Console.WriteLine("Error: The selected time zone ID was not found.");
            Console.WriteLine("Exception message: " + ex.Message);
        }
        catch (InvalidTimeZoneException ex)
        {
            Console.WriteLine("Error: The selected time zone is invalid.");
            Console.WriteLine("Exception message: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An unexpected error occurred: " + ex.Message);
        }
    }
}
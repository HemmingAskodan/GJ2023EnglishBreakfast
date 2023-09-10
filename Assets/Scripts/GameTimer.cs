using System;
using System.Timers;

class GameTimer
{
    public static Timer timer;
    private static int countdown = 5 * 60; // 5 minutes in seconds

    static void Main(string[] args)
    {
        // Create a new timer with a 1-second interval
        timer = new Timer(1000);

        // Hook up the Elapsed event handler
        timer.Elapsed += TimerElapsed;

        // Start the timer
        timer.Start();

        Console.WriteLine("5-minute timer started. Press any key to stop.");
        Console.ReadKey();

        // Stop the timer when you're done with it
        timer.Stop();
        timer.Dispose();
    }

    private static void TimerElapsed(object sender, ElapsedEventArgs e)
    {
        countdown--;

        if (countdown == 0)
        {
            Console.WriteLine("Timer expired. 5 minutes have passed.");
            timer.Stop();
        }
        else
        {
            int minutes = countdown / 60;
            int seconds = countdown % 60;
            Console.WriteLine($"Time remaining: {minutes} minutes {seconds} seconds");
        }
    }
}

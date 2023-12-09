class Program
{
    static void Main()
    {
        while (true)
        {
            ShowMainMenu();
            int choice = GetMenuChoice();

            switch (choice)
            {
                case 1:
                    RunBreathingActivity();
                    break;
                case 2:
                    RunReflectionActivity();
                    break;
                case 3:
                    RunListingActivity();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void ShowMainMenu()
    {
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");
        Console.WriteLine("4. Exit");
        Console.Write("Choose an option: ");
    }

    static int GetMenuChoice()
    {
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice))
        {
            Console.WriteLine("Invalid input. Please try again.");
            Console.Write("Choose an option: ");
        }
        return choice;
    }

    static void RunBreathingActivity()
    {
        RunCommonActivity("Breathing Activity", "This activity will help you relax by inhaling and exhaling slowly. Clear your mind and focus on your breath.");
        RunBreathingAnimation();
    }

    static void RunReflectionActivity()
    {
        RunCommonActivity("Reflection Activity", "This activity will help you reflect on moments in your life where you demonstrated strength and resilience. It will help you recognize the power you have and how you can use it in other aspects of your life.");
        RunReflectionAnimation();
    }

    static void RunListingActivity()
    {
        RunCommonActivity("Listing Activity", "This activity will help you reflect on the good things in your life by making you list as many things as you can in a specific area.");
        RunListingAnimation();
    }

    static void RunCommonActivity(string activityName, string activityDescription)
    {
        Console.WriteLine($"{activityName}: {activityDescription}");
        int duration = GetActivityDuration();
        Console.WriteLine("Get ready to start...");
        Thread.Sleep(3000);
    }

    static int GetActivityDuration()
    {
        Console.Write("Enter duration in seconds: ");
        int duration;
        while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
        {
            Console.WriteLine("Invalid input. Please try again.");
            Console.Write("Enter duration in seconds: ");
        }
        return duration;
    }

    static void RunBreathingAnimation()
    {
        Console.WriteLine("Inhale...");
        Thread.Sleep(3000);
        Console.WriteLine("Exhale...");
    }

    static void RunReflectionAnimation()
    {
    }

    static void RunListingAnimation()
    {
    }
}

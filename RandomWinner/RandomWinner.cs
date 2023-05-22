public class RandomWinner
{
    private Dictionary<string, int> employees;

    public RandomWinner()
    {
        employees = new Dictionary<string, int>()
        {
            {"John", 5},
            {"Mike", 3},
            {"Walter", 8},
            {"Gus", 2},
            {"Jane", 4},
            {"Robin", 6},
            {"Lily", 1},
            {"Marshal", 7},
            {"Barney", 9},
            {"Ted", 10}
        };
    }

    public void Run()
    {
        List<string> participants = GetParticipants();

        Random random = new Random();
        string winner = participants[random.Next(participants.Count)];
        Console.WriteLine("The winner is: " + winner);

        CalculateWinningPercentage(participants);
    }

    private List<string> GetParticipants()
    {
        return employees.SelectMany(employee => Enumerable.Repeat(employee.Key, employee.Value)).ToList();
    }

    private void CalculateWinningPercentage(List<string> participants)
    {
        int totalParticipants = participants.Count;

        var winningPercentages = employees.ToDictionary(
            employee => employee.Key,
            employee => (double)employee.Value / totalParticipants * 100
        );

        Console.WriteLine("\nWinning Percentages:");
        foreach (var employee in winningPercentages)
        {
            Console.WriteLine(employee.Key + ": " + employee.Value.ToString("0.00") + "%");
        }
    }
}

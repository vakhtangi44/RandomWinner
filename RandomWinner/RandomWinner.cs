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
            {"Gus", 15},
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

    public void TestCode(int tries)
    {
        Dictionary<string, int> wins = new Dictionary<string, int>();

        for (int i = 0; i < tries; i++)
        {
            List<string> participants = GetParticipants();
            Random random = new Random();
            string winner = participants[random.Next(participants.Count)];

            if (wins.ContainsKey(winner))
                wins[winner]++;
            else
                wins[winner] = 1;
        }

        Console.WriteLine("\nTest Results (Number of Wins):");
        foreach (var employee in wins)
        {
            Console.WriteLine(employee.Key + ": " + employee.Value);
        }

        CalculateWinningPercentage(wins.Select(x => x.Key).ToList());
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
            employee => (double)participants.Count(p => p == employee.Key) / totalParticipants * 100
        );

        Console.WriteLine("\nWinning Percentages:");
        foreach (var employee in winningPercentages)
        {
            Console.WriteLine(employee.Key + ": " + employee.Value.ToString("0.00") + "%");
        }
    }
}

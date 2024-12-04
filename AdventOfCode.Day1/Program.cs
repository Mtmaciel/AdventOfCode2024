namespace AdventOfCode.Day1;

class Program
{
    static void Main(string[] args)
    {
        string readText = File.ReadAllText(".\\input.txt");
        int result;
        
        Console.WriteLine($"1- Calculate Distance");
        Console.WriteLine($"2- Calculate Similarity");
        var option = Console.ReadLine();

        if(option == "1"){
            result = CalculateDistance(readText);
        }else{
            result = CalculateSimilarity(readText);
        }
        
        Console.WriteLine($"Final result {result}");
    }

    public static int CalculateDistance(string inputTxt){
        List<int> List1 = [];
        List<int> List2 = [];
        int distance = 0;

        var lines = inputTxt.Split("\r\n");
        foreach (var line in lines)
        {
            var spliced = line.Split("   ");
            List1.Add(Convert.ToInt32(spliced[0]));
            List2.Add(Convert.ToInt32(spliced[1]));
        }
        
        List1 = [.. List1.OrderBy(x => x)];
        List2 = [.. List2.OrderBy(x => x)];
        
        for (int i = 0; i < List1.Count; i++)
        {
            distance += Math.Abs(List1[i] - List2[i]);    
        }

        return distance;
    }

    public static int CalculateSimilarity(string inputTxt){
        List<int> List1 = [];
        List<int> List2 = [];
        int similarity = 0;

        var lines = inputTxt.Split("\r\n");
        foreach (var line in lines)
        {
            var spliced = line.Split("   ");
            List1.Add(Convert.ToInt32(spliced[0]));
            List2.Add(Convert.ToInt32(spliced[1]));
        }

        foreach (var id1 in List1)
        {
            var checks = List2.Where(x => x == id1).Count();
            similarity += id1*checks;
        }

        return similarity;
    }
}
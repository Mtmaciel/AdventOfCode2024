namespace AdventOfCode.Day2;

class Program
{
    static void Main(string[] args)
    {
        string readText = File.ReadAllText(".\\input.txt");
        int result = 0;
        
        Console.WriteLine($"1- Report Safety");
        Console.WriteLine($"2- Report Safety with First level error Safe");
        var option = Console.ReadLine();

        if(option == "1"){
            result = ReportSafety(readText,false);
        }
        else{
            result = ReportSafety(readText,true);
        }
        
        Console.WriteLine($"Final result {result}");
    }

    private static int ReportSafety(string fileInput,bool firstLevelErrorSafe){
        int result=0;

        var lines = fileInput.Split("\r\n");
        bool levelRecovery;

        foreach (var line in lines)
        {
            List<int> report = [.. line.Split(" ").Select(x => Convert.ToInt32(x))]; 
            //Define se Esta aumentando ou diminuindo o nivel conforme as duas primeiras posições;
            var increasing = report[0] < report[1];
            var safe = true;
            levelRecovery = firstLevelErrorSafe;

            for (int i = 1; i < report.Count; i++)
            {
                // Se mudar a ordenação do nivel ou eles ficarem iguais sai do loop;
                if (increasing != report[i-1] < report[i] || report[i-1] == report[i]){
                    if (levelRecovery){
                        levelRecovery = false;
                        report.RemoveAt(i);
                        if (increasing != report[i-1] < report[i] || report[i-1] == report[i]){
                            safe = false;
                            break;
                        }
                    }else{
                        safe = false;
                        break;
                    }
                }
                // Se a diferença absoluta fr maior que 3 sai do loop;
                if (Math.Abs(report[i] - report[i-1]) > 3){
                    if (levelRecovery){
                        levelRecovery = false;
                         report.RemoveAt(i);
                        if (Math.Abs(report[i] - report[i-1]) > 3){
                            safe = false;
                            break;
                        }
                    }else{
                        safe = false;
                        break;
                    }
                }
            }
            if (safe){
                result++;
            }

        }
        return result;
    }
}

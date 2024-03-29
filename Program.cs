// See https://aka.ms/new-console-template for more information
//1.
//class Cross
//{
//    protected string _LastName;
//    protected string _Group;
//    protected int _score;

//    public Cross(string LastName, string Group, int score)
//    {
//        this._LastName = LastName;
//        this._Group = Group;
//        this._score = score;
//    }
//    public string LastName { get { return this._LastName; } }
//    public string Group { get { return this._Group; } }
//    public int score { get { return this._score; } }
//    public void Print()
//    {
//        Console.WriteLine($"Name:{LastName} Group:{Group} Score:{score}");
//    }
//}

//abstract class Winers
//{
//    public abstract void Winer(Cross[] array);
//}
//class Run100 : Winers
//{
//    public override void Winer(Cross[] array)
//    {
//        int res = 0;
//        for (int i = 1; i < array.Length; i++)
//        {
//            for (int j = 1; j < array.Length; j++)
//            {
//                if (array[j - 1].score < array[j].score)
//                {
//                    Cross p = array[j];
//                    array[j] = array[j - 1];
//                    array[j - 1] = p;
//                }
//            }
//        }
//        for (int i = 0; i < array.Length; i++)
//        {
//            if (array[i].score >= 100)
//            {
//                res = i;
//            }
//        }
//        Console.WriteLine("Race 100 meters");
//        for (int i = 0; i <= res; i++)
//        {
//            Console.Write($"Place: {i + 1}\t\t");
//            array[i].Print();
//        }
//    }
//}
//class Run500 : Winers
//{
//    public override void Winer(Cross[] array)
//    {
//        int res = 0;
//        for (int i = 1; i < array.Length; i++)
//        {
//            for (int j = 1; j < array.Length; j++)
//            {
//                if (array[j - 1].score < array[j].score)
//                {
//                    Cross p = array[j];
//                    array[j] = array[j - 1];
//                    array[j - 1] = p;
//                }
//            }
//        }
//        for (int i = 0; i < array.Length; i++)
//        {
//            if (array[i].score >= 500)
//            {
//                res = i;
//            }
//        }
//        Console.WriteLine("Race 500 meters");
//        for (int i = 0; i <= res; i++)
//        {
//            Console.Write($"Place: {i + 1}\t\t");
//            array[i].Print();
//        }
//    }
//}
//internal class Program
//{


//    static void Main(string[] args)
//    {
//        Run100 r = new Run100();
//        Cross[] ARRAY = new Cross[3];


//        ARRAY[0] = new Cross("Sidney", "2", 521);
//        ARRAY[1] = new Cross("Rosa", "1", 523);
//        ARRAY[2] = new Cross("Adrian", "3", 128);
//        Sort(ARRAY);
//        Run100 array1 = new Run100();
//        array1.Winer(ARRAY);
//        Console.WriteLine();
//        Run500 array2 = new Run500();
//        array2.Winer(ARRAY);
//    }
//    static void Sort(Cross[] array)
//    {
//        for (int j = 0; j < array.Length - 1; j++)
//        {
//            for (int i = 1; i < array.Length; i++)
//            {
//                if (array[i - 1].score < array[i].score)
//                {
//                    Cross p = array[i - 1];
//                    array[i - 1] = array[i];
//                    array[i] = p;
//                }
//            }
//        }
//    }
//}




// 2
//public abstract class Discipline
//{
//    public string DisciplineName { get; protected set; }

//    public abstract void Print();
//}

//public class LongJump : Discipline
//{
//    public LongJump()
//    {
//        DisciplineName = "Long Jump";
//    }

//    public override void Print()
//    {
//        Console.WriteLine($"Discipline: {DisciplineName}");
//    }
//}

//public class HighJump : Discipline
//{
//    public HighJump()
//    {
//        DisciplineName = "High Jump";
//    }

//    public override void Print()
//    {
//        Console.WriteLine($"Discipline: {DisciplineName}");
//    }
//}

//public class Program
//{
//    public static void Main()
//    {
//        Discipline longJump = new LongJump();
//        Discipline highJump = new HighJump();

//        double[][] jumpResults = new double[][]
//        {
//            new double[] { 5.6, 5.9, 6.1 },
//            new double[] { 5.8, 6.0, 6.2 },
//            new double[] { 5.7, 6.0, 6.3 }
//        };

//        Console.WriteLine("Table of results:");

//        longJump.Print();
//        for (int i = 0; i < jumpResults.Length; i++)
//        {
//            double bestLongJump = FindBestResult(jumpResults[i]);
//            Console.WriteLine($"Best long jump result for participant {i + 1}: {bestLongJump}");
//        }

//        highJump.Print();
//        for (int i = 0; i < jumpResults.Length; i++)
//        {
//            double bestHighJump = FindBestResult(jumpResults[i]);
//            Console.WriteLine($"Best high jump result for participant {i + 1}: {bestHighJump}");
//        }
//    }

//    public static double FindBestResult(double[] results)
//    {
//        double bestResult = results[0];
//        for (int i = 1; i < results.Length; i++)
//        {
//            if (results[i] > bestResult)
//            {
//                bestResult = results[i];
//            }
//        }
//        return bestResult;
//    }
//}

// 3
public class FootballTeam
{
    private string name;
    private int scored;
    private int conceded;
    private int points;

    public FootballTeam(string name)
    {
        this.name = name;
        scored = 0;
        conceded = 0;
        points = 0;
    }

    public string Name { get { return name; } set { name = value; } }

    public void Result(int scored, int conceded)
    {
        this.scored += scored;
        this.conceded += conceded;
        if (scored > conceded)
            points += 3;
        else if (scored == conceded)
            points += 1;
    }

    public int Points { get { return points; } }

    public int Difference { get { return scored - conceded; } }

    public static void Print(FootballTeam[] teams)
    {
        Console.WriteLine("Place | Team     | Points");
        for (int i = 0; i < teams.Length; i++)
        {
            Console.WriteLine("{0,-6} | {1,-8} | {2}", i + 1, teams[i].Name, teams[i].Points);
        }
    }
}

public class WomenFootballTeam : FootballTeam
{
    public WomenFootballTeam(string name) : base(name)
    {
    }
}

public class MenFootballTeam : FootballTeam
{
    public MenFootballTeam(string name) : base(name)
    {
    }
}

class Program
{
    static void Main(string[] args)
    {
        FootballTeam[] teams = new FootballTeam[]
        {
            new WomenFootballTeam("CSKA Women"),
            new WomenFootballTeam("Zenit Women"),
            new MenFootballTeam("Dynamo Men"),
            new MenFootballTeam("Spartak Men")
        };

        Match(ref teams[0], ref teams[1]);
        Match(ref teams[0], ref teams[2]);
        Match(ref teams[1], ref teams[0]);
        Match(ref teams[1], ref teams[2]);

        Sort(teams);
        FootballTeam.Print(teams);
    }

    static void Match(ref FootballTeam team1, ref FootballTeam team2)
    {
        Random random = new Random();
        int scored = random.Next(0, 5);
        int conceded = random.Next(0, 5);
        team1.Result(scored, conceded);
        team2.Result(conceded, scored);
    }

    static void Sort(FootballTeam[] teams)
    {
        for (int i = 0; i < teams.Length - 1; i++)
        {
            for (int j = 0; j < teams.Length - i - 1; j++)
            {
                if (teams[j].Points < teams[j + 1].Points ||
                   (teams[j].Points == teams[j + 1].Points && teams[j].Difference < teams[j + 1].Difference))
                {
                    FootballTeam temp = teams[j];
                    teams[j] = teams[j + 1];
                    teams[j + 1] = temp;
                }
            }
        }
    }
}





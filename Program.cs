// See https://aka.ms/new-console-template for more information
//1.
class Cross
{
    protected string _LastName;
    protected string _Group;
    protected int _score;

    public Cross(string LastName, string Group, int score)
    {
        this._LastName = LastName;
        this._Group = Group;
        this._score = score;
    }

    public string LastName { get { return this._LastName; } }
    public string Group { get { return this._Group; } }
    public int Score { get { return this._score; } }

    public void Print()
    {
        Console.WriteLine($"Name: {LastName} Group: {Group} Score: {Score}");
    }
}

abstract class Winners
{
    public abstract void Winner(Cross[] array);

    protected void Sort(Cross[] array)
    {
        if (array == null || array.Length == 0)
        {
            return;
        }

        for (int j = 0; j < array.Length - 1; j++)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] != null && array[i] != null && array[i - 1].Score < array[i].Score)
                {
                    Cross temp = array[i - 1];
                    array[i - 1] = array[i];
                    array[i] = temp;
                }
            }
        }
    }
}

class Run100 : Winners
{
    public override void Winner(Cross[] array)
    {
        if (array == null || array.Length == 0)
        {
            return;
        }

        int res = 0;

        Sort(array);

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] != null && array[i].Score >= 100)
            {
                res = i;
            }
        }

        Console.WriteLine("Race 100 meters");
        for (int i = 0; i <= res; i++)
        {
            Console.Write($"Place: {i + 1}\t\t");
            array[i].Print();
        }
    }
}

class Run500 : Winners
{
    public override void Winner(Cross[] array)
    {
        if (array == null || array.Length == 0)
        {
            return;
        }

        int res = 0;

        Sort(array);

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] != null && array[i].Score >= 500)
            {
                res = i;
            }
        }

        Console.WriteLine("Race 500 meters");
        for (int i = 0; i <= res; i++)
        {
            Console.Write($"Place: {i + 1}\t\t");
            array[i].Print();
        }
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        Cross[] ARRAY = new Cross[3];
        ARRAY[0] = new Cross("Sidney", "2", 521);
        ARRAY[1] = new Cross("Rosa", "1", 523);
        ARRAY[2] = new Cross("Adrian", "3", 128);

        Winners run100 = new Run100();
        Winners run500 = new Run500();

        Console.WriteLine("Results:");

        run100.Winner(ARRAY);
        Console.WriteLine();
        run500.Winner(ARRAY);
    }
}






// 2

//public abstract class Discipline
//{
//    protected static string nameOfDiscipline;

//    private string surname;
//    private double[] results;

//    public Discipline(string surname, double[] results)
//    {
//        this.surname = surname;
//        this.results = results;
//    }

//    public virtual string NameOfDiscipline
//    {
//        get { return nameOfDiscipline; }
//    }

//    public double GetBestResult()
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

//    public static void Print(Discipline[] results)
//    {
//        for (int i = 0; i < results.Length; i++)
//        {
//            Console.WriteLine($"Surname: {results[i].surname}");
//            Console.WriteLine($"Best result: {results[i].GetBestResult()}");
//        }
//    }
//}

//public class HighJump : Discipline
//{
//    public HighJump(string surname, double[] results) : base(surname, results)
//    {
//    }

//    public static new string NameOfDiscipline
//    {
//        get { return "\nHigh Jump"; }
//    }
//}

//public class LongJump : Discipline
//{
//    public LongJump(string surname, double[] results) : base(surname, results)
//    {
//    }

//    public static new string NameOfDiscipline
//    {
//        get { return "\nLong Jump"; }
//    }
//}

//internal class Program
//{
//    public static void Main()
//    {
//        LongJump[] jumpResults1 = {
//            new LongJump("Ivanov", new double[] { 3.2, 2.9, 3.1 }),
//            new LongJump("Petrov", new double[] { 2.8, 2.0, 3.2 }),
//            new LongJump("Sidorov", new double[] { 3.7, 3.0, 2.3 })
//        };

//        HighJump[] jumpResults2 = {
//            new HighJump("Malinkin", new double[] { 5.6, 5.9, 6.1 }),
//            new HighJump("Lazarev", new double[] { 5.8, 6.0, 6.2 }),
//            new HighJump("Perov", new double[] { 5.7, 6.0, 6.3 })
//        };

//        Console.WriteLine("Table of results:");
//        Console.WriteLine(LongJump.NameOfDiscipline);
//        Discipline.Print(jumpResults1);
//        Console.WriteLine(HighJump.NameOfDiscipline);
//        Discipline.Print(jumpResults2);
//    }
//}



// 3
//public class FootballTeam
//{
//    private string name;
//    private int scored;
//    private int conceded;
//    private int points;

//    public FootballTeam(string name)
//    {
//        this.name = name;
//        scored = 0;
//        conceded = 0;
//        points = 0;
//    }

//    public string Name { get { return name; } set { name = value; } }

//    public void Result(int scored, int conceded)
//    {
//        this.scored += scored;
//        this.conceded += conceded;
//        if (scored > conceded)
//            points += 3;
//        else if (scored == conceded)
//            points += 1;
//    }

//    public int Points { get { return points; } }

//    public int Difference { get { return scored - conceded; } }

//    public static void Print(FootballTeam[] teams)
//    {
//        Console.WriteLine("Place | Team     | Points");
//        for (int i = 0; i < teams.Length; i++)
//        {
//            Console.WriteLine("{0,-6} | {1,-8} | {2}", i + 1, teams[i].Name, teams[i].Points);
//        }
//    }
//}

//public class WomenFootballTeam : FootballTeam
//{
//    public WomenFootballTeam(string name) : base(name)
//    {
//    }
//}

//public class MenFootballTeam : FootballTeam
//{
//    public MenFootballTeam(string name) : base(name)
//    {
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        FootballTeam[] teams = new FootballTeam[]
//        {
//            new WomenFootballTeam("CSKA Women"),
//            new WomenFootballTeam("Zenit Women"),
//            new MenFootballTeam("Dynamo Men"),
//            new MenFootballTeam("Spartak Men")
//        };

//        Match(ref teams[0], ref teams[1]);
//        Match(ref teams[0], ref teams[2]);
//        Match(ref teams[1], ref teams[0]);
//        Match(ref teams[1], ref teams[2]);

//        Sort(teams);
//        FootballTeam.Print(teams);
//    }

//    static void Match(ref FootballTeam team1, ref FootballTeam team2)
//    {
//        Random random = new Random();
//        int scored = random.Next(0, 5);
//        int conceded = random.Next(0, 5);
//        team1.Result(scored, conceded);
//        team2.Result(conceded, scored);
//    }

//    static void Sort(FootballTeam[] teams)
//    {
//        for (int i = 0; i < teams.Length - 1; i++)
//        {
//            for (int j = 0; j < teams.Length - i - 1; j++)
//            {
//                if (teams[j].Points < teams[j + 1].Points ||
//                   (teams[j].Points == teams[j + 1].Points && teams[j].Difference < teams[j + 1].Difference))
//                {
//                    FootballTeam temp = teams[j];
//                    teams[j] = teams[j + 1];
//                    teams[j + 1] = temp;
//                }
//            }
//        }
//    }
//}





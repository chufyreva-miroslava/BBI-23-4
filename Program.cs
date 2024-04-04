// See https://aka.ms/new-console-template for more information
//1
//class Cross
//{
//    private string _lastName;
//    private string _group;
//    private int _score;

//    public Cross(string lastName, string group, int score)
//    {
//        this._lastName = lastName;
//        this._group = group;
//        this._score = score;
//    }

//    public string LastName { get { return this._lastName; } }
//    public string Group { get { return this._group; } }
//    public int Score { get { return this._score; } }

//    public void Print()
//    {
//        Console.WriteLine($"Name: {LastName} Group: {Group} Score: {Score}");
//    }
//}

//abstract class Winners
//{
//    public abstract void Winner(Cross[] array);

//    protected void QuickSort(Cross[] array, int left, int right)
//    {
//        if (left < right)
//        {
//            int pivot = Partition(array, left, right);
//            QuickSort(array, left, pivot - 1);
//            QuickSort(array, pivot + 1, right);
//        }
//    }

//    private int Partition(Cross[] array, int left, int right)
//    {
//        Cross pivot = array[right];
//        int i = left - 1;

//        for (int j = left; j < right; j++)
//        {
//            if (array[j].Score <= pivot.Score)
//            {
//                i++;
//                Swap(array, i, j);
//            }
//        }

//        Swap(array, i + 1, right);
//        return i + 1;
//    }

//    private void Swap(Cross[] array, int index1, int index2)
//    {
//        Cross temp = array[index1];
//        array[index1] = array[index2];
//        array[index2] = temp;
//    }
//}

//class Run100 : Winners
//{
//    public override void Winner(Cross[] array)
//    {
//        if (array == null || array.Length == 0)
//        {
//            return;
//        }

//        QuickSort(array, 0, array.Length - 1);

//        int res = 0;
//        for (int i = 0; i < array.Length; i++)
//        {
//            if (array[i].Score >= 100)
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

//class Run500 : Winners
//{
//    public override void Winner(Cross[] array)
//    {
//        if (array == null || array.Length == 0)
//        {
//            return;
//        }

//        QuickSort(array, 0, array.Length - 1);

//        int res = 0;
//        for (int i = 0; i < array.Length; i++)
//        {
//            if (array[i].Score >= 500)
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
//        Cross[] array = new Cross[3];
//        array[0] = new Cross("Sidney", "2", 521);
//        array[1] = new Cross("Rosa", "1", 523);
//        array[2] = new Cross("Adrian", "3", 128);

//        Winners run100 = new Run100();
//        Winners run500 = new Run500();

//        Console.WriteLine("Results:");
//        run100.Winner(array);
//        Console.WriteLine();
//        run500.Winner(array);
//    }
//}



// 2
//public struct Athlete
//{
//    public string Surname { get; }
//    public double[] Results { get; }

//    public Athlete(string surname, double[] results)
//    {
//        Surname = surname;
//        Results = results;

//    }

//}

//public abstract class Discipline
//{
//    public abstract string NameOfDiscipline { get; }

//    public abstract double GetBestResult(double[] results);

//    public static void Print(Athlete[] athletes)
//    {
//        Console.WriteLine("Table of results:");
//        foreach (var athlete in athletes)
//        {
//            Console.WriteLine($"Surname: {athlete.Surname}");
//            Console.WriteLine($"Best result: {athlete.Results.Max()}");
//        }
//    }
//}

//public class HighJump : Discipline
//{
//    public HighJump() { }

//    public override string NameOfDiscipline
//    {
//        get { return "\nHigh Jump"; }
//    }

//    public override double GetBestResult(double[] results)
//    {
//        return results.Max();
//    }
//}

//public class LongJump : Discipline
//{
//    public LongJump() { }

//    public override string NameOfDiscipline
//    {
//        get { return "\nLong Jump"; }
//    }

//    public override double GetBestResult(double[] results)
//    {
//        return results.Max();
//    }
//}

//internal class Program
//{
//    public static void Main()
//    {
//        Athlete[] longJumpResults = {
//            new Athlete("Ivanov", new double[] { 3.2, 2.9, 3.1 }),
//            new Athlete("Petrov", new double[] { 2.8, 2.0, 3.2 }),
//            new Athlete("Sidorov", new double[] { 3.7, 3.0, 2.3 })
//        };

//        Athlete[] highJumpResults = {
//            new Athlete("Malinkin", new double[] { 5.6, 5.9, 6.1 }),
//            new Athlete("Lazarev", new double[] { 5.8, 6.0, 6.2 }),
//            new Athlete("Perov", new double[] { 5.7, 6.0, 6.3 })
//        };

//        Console.WriteLine("Table of results:");
//        Console.WriteLine(new LongJump().NameOfDiscipline);
//        Discipline.Print(longJumpResults);
//        Console.WriteLine(new HighJump().NameOfDiscipline);
//        Discipline.Print(highJumpResults);
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





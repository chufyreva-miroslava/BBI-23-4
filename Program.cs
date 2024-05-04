using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;
using System.Text;


public abstract class Task
{
    public abstract string ToString();
}

public class Task8 : Task
{
    private string text;
    private string processedText;

    public Task8(string text)
    {
        this.text = text;
        ProcessText();
    }

    private void ProcessText()
    {
        int index = 0;
        processedText = "";

        while (index < text.Length)
        {
            string currentStr = "";
            //Проверка есть ли полная строка в тексте ещё
            if (index + 49 < text.Length)
            {
                //Проверка есть ли символ за строкой и будет ли он пробелом
                if (index + 50 < text.Length && text[index + 50] == ' ')
                {
                    currentStr = text.Substring(index, 50);
                    processedText += currentStr + "\n";
                    index = index + 51;
                }
                else
                {
                    int indexSpace = -1;
                    //Ищем ближайший с конца пробел
                    for (int i = index + 49; i >= index; --i)
                    {
                        if (text[i] == ' ')
                        {
                            indexSpace = i;
                            break;
                        }
                    }

                    currentStr = text.Substring(index, indexSpace - index);

                    index = indexSpace + 1;

                    processedText += currentStr + "\n";
                }
            }
            else
            {
                currentStr = text.Substring(index);
                if (currentStr.Length != 50)
                {
                    int spaceCount = 50 - currentStr.Length;
                    currentStr += new string(' ', spaceCount);
                }
                processedText += currentStr + "\n";
                index += 50;
            }

        }

        FormattingTextByWidth();
    }

    private void FormattingTextByWidth()
    {
        string[] lines = processedText.Split('\n'); //в аждой ячеку массива хранится строка

        string result = ""; //итоговый текст

        foreach (string line in lines)
        {
            string[] words = line.TrimEnd().Split();//удаляем все лишние пробелы в конце строки
            int totalWordLength = words.Sum(word => word.Length);// длина слов в строке
            int totalSpacesToAdd = 50 - totalWordLength;
            int spaceBetweenWord; //кол-во пробелов между словами, которое требуется для выравнивания по ширине
            if (words.Length > 1) spaceBetweenWord = totalSpacesToAdd / (words.Length - 1);
            else spaceBetweenWord = 0;

            int allSpaces; // кол-во пробелов, которое не хватает между словами для выравнивания по ширине
            if (words.Length > 1) allSpaces = totalSpacesToAdd % (words.Length - 1);
            else allSpaces = 0;

            StringBuilder formattedLine = new StringBuilder(); //переменная для хранения отформатированной строки по ширине

            for (int i = 0; i < words.Length - 1; i++) //добавление необхлдимых пробелов
            {
                formattedLine.Append(words[i]);
                formattedLine.Append(' ', spaceBetweenWord + (allSpaces > 0 ? 1 : 0));
                allSpaces = Math.Max(0, allSpaces - 1);
            }

            formattedLine.Append(words[words.Length - 1]);
            result += formattedLine.ToString() + "\n";

        }
        processedText = result;

    }


    public override string ToString()
    {

        return processedText;
    }
}

public class Task9 : Task
{
    private string text;
    private string compressedText;
    private Dictionary<char, bool> symbolEncode; // Словарь по которому можно понять какие символы не встречаются в тексте
    private Dictionary<char, string> codeTable;

    public Task9(string text)
    {
        this.text = text;
        FillEncodeDictionary();
        FillCodeTable();
        CompressText();
    }

    // Заполнение начальное всех возможных символов для шифровки. Я беру символы ASCII от 33-126 и русский алфавит.Буквы е и Ё располагаются отдельно
    private void FillEncodeDictionary()
    {
        symbolEncode = new Dictionary<char, bool>();

        for (char sym = '!'; sym <= '~'; ++sym)
        {
            symbolEncode.Add(sym, true);
        }

        for (char sym = 'А'; sym <= 'я'; ++sym)
        {
            symbolEncode.Add(sym, true);
        }

        symbolEncode.Add('ё', true);
        symbolEncode.Add('Ё', true);
    }
    //Заполнение таблицы кодов
    private void FillCodeTable()
    {
        codeTable = new Dictionary<char, string>();
        var mostFrequentPairs = ProcessText();
        // Создаем массив символов, которые можно использовать для сжатия
        var acceptedSymbolsForEncode = symbolEncode.Where(x => x.Value).Select(x => x.Key).ToArray();

        int index = 0;

        //Заполняем таблицу. Взял while, чтобы не было ошибки выхода за границы массива
        while (index < mostFrequentPairs.Length && index < acceptedSymbolsForEncode.Length)
        {
            codeTable.Add(acceptedSymbolsForEncode[index], mostFrequentPairs[index]);
            index++;
        }



    }
    //Функция обрабатывает текс и возвращает самые часто-встречающиеся пары. Я предпологаю что текст будет больше 2 символов, Если нет, то будет ошибка.
    private string[] ProcessText()
    {

        var uniquePair = new Dictionary<string, int>(); // Словарь для уникальных пар

        string currentPair = "";
        //Заносим 1 пару
        for (int i = 0; i < 2; ++i)
        {
            // Проверка на наличие символа и если он есть, то помечаем это, чтобы не использовать его в сжатии
            if (symbolEncode.ContainsKey(text[i]) && symbolEncode[text[i]])
            {
                symbolEncode[text[i]] = false;
            }
            currentPair += text[i];
        }

        uniquePair.Add(currentPair, 1);

        //Проход по всему тексту
        for (int i = 2; i < text.Length; ++i)
        {
            if (symbolEncode.ContainsKey(text[i]) && symbolEncode[text[i]])
            {
                symbolEncode[text[i]] = false;
            }

            currentPair = currentPair.Substring(1) + text[i];
            //Добавление или увелечение значения в словаре уникальных пар
            if (!uniquePair.ContainsKey(currentPair))
            {
                uniquePair.Add(currentPair, 1);
            }
            else
            {
                uniquePair[currentPair]++;
            }

        }


        //Из таблицы выбыраем самые часто встречающиеся пары. Число в Take() означает сколько пар будет взято. Рекомендую брать больше 5-8. Чем больше, тем лучше будет сжатие
        var mostFrequentPairs = uniquePair.Select(x => new
        {
            pair = x.Key,
            count = x.Value
        }).OrderByDescending(x => x.count).Take(10).Select(x => x.pair).ToArray();

        return mostFrequentPairs;

    }

    public Dictionary<char, string> GiveTable()
    {
        return codeTable;
    }

    //Функция сжатия текста
    private void CompressText()
    {
        compressedText = text;
        foreach (var pair in codeTable)
        {
            compressedText = compressedText.Replace(pair.Value, pair.Key.ToString());
        }
    }

    public override string ToString()
    {

        return compressedText;
    }


}

public class Task10 : Task
{
    private string text;
    private string decompressedText;


    private Dictionary<char, string> codeTable;

    public Task10(string cipherText, Dictionary<char, string> codeTable)
    {
        this.text = cipherText;
        this.codeTable = codeTable;

        DecompressText();
    }

    private void DecompressText()
    {
        decompressedText = text;

        foreach (var pair in codeTable)
        {
            decompressedText = decompressedText.Replace(pair.Key.ToString(), pair.Value);
        }
    }

    public override string ToString()
    {
        return decompressedText;
    }
}

public class Task12 : Task
{
    private string input;
    public Task12(string input)
    {
        this.input = input;
    }
    public override string ToString()
    {
        Dictionary<string, string> wordCodes = new Dictionary<string, string>();
        string[] lines = input.Split(Environment.NewLine);
        string text = "Задача 12:\n";
        foreach (var line in lines)
        {
            if (line.Contains(":"))
            {
                string[] parts = line.Split(":");
                wordCodes[parts[1].Trim()] = parts[0].Trim();
            }
            else
            {
                text += line + " ";
            }
        }


        wordCodes["Двигатель"] = "#$@^";
        wordCodes["сложная"] = "*@!&";
        wordCodes["подъём"] = "!@#$%";
        wordCodes["движение"] = "%^&*(";
        wordCodes["сжатию"] = "&*()!";

        foreach (var code in wordCodes)
        {
            text = text.Replace(code.Key, code.Value);
        }

        return text.Trim();
    }
}

class Task13 : Task
{
    private Dictionary<char, double> resultMapping;
    private string text;
    public Dictionary<char, double> ResultMapping
    {
        get => resultMapping;
    }
    public Task13(string text)
    {
        this.text = text;
        resultMapping = new Dictionary<char, double>();
    }

    public void Solution()
    {
        string[] words = text.Split(" ,-!.:;".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        SortedDictionary<char, int> statistics = new SortedDictionary<char, int>();
        foreach (string word in words)
        {
            char startingChar = word.ToLower()[0];
            if (statistics.ContainsKey(startingChar))
                statistics[startingChar]++;
            else
                statistics.Add(startingChar, 1);
        }
        foreach (var entry in statistics)
        {
            resultMapping.Add(entry.Key, entry.Value / (double)words.Length);
        }
    }
    public override string ToString()
    {
        Solution();
        return string.Join(Environment.NewLine, resultMapping);
    }
}
class Task15 : Task
{
    private int resultValue;
    private string text;
    public int ResultValue
    {
        get => resultValue;
    }
    public Task15(string text)
    {
        this.text = text;
        resultValue = 0;
    }

    protected void Solution()
    {
        for (int index = 0; index < text.Length; index++)
        {
            if (text[index] >= '0' && text[index] <= '9')
            {
                int number = 0;
                while (index < text.Length && text[index] >= '0' && text[index] <= '9')
                {
                    number *= 10;
                    number += text[index] - '0';
                    index++;
                }
                --index;
                resultValue += number;
            }
        }
    }
    public override string ToString()
    {
        Solution();
        return resultValue.ToString();
    }
}
class Program
{
    static void Main(string[] args)
    {
        string text = "Двигатель самолета – это сложная инженерная конструкция, обеспечивающая подъем, управление и движение в воздухе. Он состоит из множества компонентов, каждый из которых играет важную роль в общей работе механизма. Внутреннее устройство двигателя включает в себя компрессор, камеру сгорания, турбину и системы управления и охлаждения. Принцип работы основан на воздушно-топливной смеси, которая подвергается сжатию, воспламенению и расширению, обеспечивая движение воздушного судна.";

        Task8 tsk8 = new Task8(text);
        Console.WriteLine(tsk8.ToString());
        Console.WriteLine();

        Task9 tsk9 = new Task9(text);
        Console.WriteLine(text);
        Console.WriteLine();

        string ciphertext = tsk9.ToString();
        Console.WriteLine(ciphertext);
        Console.WriteLine();

        Task10 tsk10 = new Task10(ciphertext, tsk9.GiveTable());
        Console.WriteLine(tsk10.ToString());

        Task13 task13 = new Task13(text);
        Console.WriteLine(task13.ToString());

        Task15 task15 = new Task15("12 sdfd 34 werwers 11");
        Console.WriteLine(task15.ToString());
    }
}

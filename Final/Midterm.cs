using System;
using System.IO;

public class Midterm {

    public static int GetLineCount(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException("File not found", path);
        }

        int count = 0;
        using (StreamReader reader = new StreamReader(path))
        {
            while (!reader.EndOfStream)
            {
                reader.ReadLine();
                count++;
            }
        }

        return count;

    }

    public static void Main()
    {
        const string path = @"Data\C# Midterm Project - Operators.csv";

        if (!File.Exists(path))
        {
            Console.WriteLine("File Doesn't Exist");
        }

        int lineCount = GetLineCount(path);

        Operator[] ops = new Operator[lineCount-1];
        int score = 0;
        int maxScore = 0;

        try
        {
            using (StreamReader reader = new StreamReader(path))
            {
                reader.ReadLine();

                for (int i = 0; i < ops.Length; i++)
                {
                    string line = reader.ReadLine();
                    string[] columns = line.Split(',');


                    string name = columns[0];
                    string clue1 = columns[1];
                    string clue2 = columns[2];
                    string clue3 = columns[3];
                    string map = columns[4];

                    ops[i] = new Operator(name, clue1, clue2, clue3, map);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("error");
            throw e;
        }


        Console.WriteLine("Welcome to my 'Rainbow Six: Siege' Operator Guessing Game!");
        int userNum = 0;
        string userGuess = "";
        int op = 0;
        int guessNum = 1;
        string[] sorted = new string[ops.Length];

        //adds the names of all operators to a string arrray
        for (int i = 0; i < sorted.Length; i++)
        {
            sorted[i] = ops[i].Name;
        }

        //sorts the string array of operators alphabetically
        for (int i = 0; i < sorted.Length; i++)
        {
            int minIndex = i;
            for (int j = i+1; j < sorted.Length; j++)
            {
                if (sorted[j].CompareTo(sorted[minIndex]) < 0)
                {
                    minIndex = j;
                }
            }
            if (i != minIndex)
            {
                (sorted[minIndex], sorted[i]) = (sorted[i], sorted[minIndex]);
            }
        }

        

        

        while (userNum != 3)
        {
            Console.WriteLine("\n1. Guess an Operator");
            Console.WriteLine("2. Display the Operators to guess from");
            Console.WriteLine("3. Exit");
            guessNum = 1;
            bool correct = false;

            try
            {
                userNum = int.Parse(Console.ReadLine());
                if (userNum < 1 || userNum > 3)
                {
                    Console.WriteLine("Please enter a number between 1 and 3");
                }
            }catch
            {
                Console.WriteLine("Please enter a number between 1 and 3");
            }

            if (userNum == 1 && op < ops.Length) //userNum = 1
            {
                while (guessNum <= 3 && correct == false)
                {
                    if (guessNum == 1){
                        Console.WriteLine("\n" + ops[op].Clue1);
                        userGuess = Console.ReadLine();
                        if (userGuess == ops[op].Name)
                        {
                            Console.WriteLine("Correct!");
                            correct = true;
                            score++;
                            op++;
                        }
                        else
                        {
                            guessNum++;
                            Console.WriteLine("Incorrect. Displaying the next clue.");
                        }
                    }

                    if (guessNum == 2)
                    {
                        Console.WriteLine("\n" + ops[op].Clue2);
                        userGuess = Console.ReadLine();
                        if (userGuess == ops[op].Name)
                        {
                            Console.WriteLine("Correct!");
                            correct = true;
                            score++;
                            op++;
                        }
                        else
                        {
                            guessNum++;
                            Console.WriteLine("Incorrect. Displaying the final clue.");
                        }
                    }

                    if (guessNum == 3)
                    {
                        Console.WriteLine("\n" + ops[op].Clue3);
                        userGuess = Console.ReadLine();
                        if (userGuess == ops[op].Name)
                        {
                            Console.WriteLine("Correct!");
                            correct = true;
                            score++;
                            op++;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect.");
                            Console.WriteLine("The Operator was: " + ops[op].Name);
                            op++;
                            guessNum++;
                        }
                    }

                    if (correct == true)
                    {
                        Console.WriteLine("\nBONUS ROUND\nGuess the map that this operator came with.");
                        userGuess = Console.ReadLine();
                        if (userGuess == ops[op-1].Map)
                        {
                            score++;
                            Console.WriteLine("Congrats, you earned yourself another point.");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, that's incorrect. The correct map is " + ops[op-1].Map);
                        }
                    }
                    
                }

            }
            else if(userNum == 1)
            {
                Console.WriteLine("\nYou have gone through all the operators, there are no more to guess.");
            }

            if (userNum == 2) // userNum = 2
            {
                for (int i = 0; i < sorted.Length; i++)
                {
                    Console.WriteLine(sorted[i]);
                }
            }

            maxScore = op;

            if (userNum == 3) // userNum = 3
            {
                Console.WriteLine("\nThank you for Playing!");
                Console.WriteLine("You got " + score + "/" + maxScore);
                break;
            }



        }
    }
}

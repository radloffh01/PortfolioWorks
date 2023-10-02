using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Final {
    public static void Main()
    {
        List<Team> teams = new List<Team> ();
        Team manU = new Team("Manchester United");
        Team manC = new Team("Manchester City");
        Team barc = new Team("Barcelona FC");
        teams.Add(manU);
        teams.Add(manC);
        teams.Add(barc);

        string userSymbol, userTeam;
        int userColor;
        Console.WriteLine("What Symbol/Character do you want to be:");
        userSymbol = Console.ReadLine();

        while (userSymbol.Length == 0 || userSymbol.Length > 1)
        {
            Console.WriteLine("Please enter a single symbol/character.");
            userSymbol = Console.ReadLine();
        }
        char uSym = userSymbol[0];

        Console.WriteLine("What is your team name:\nFor Example:");
        teams.OrderBy(z => z.Name)
            .ToList()
            .ForEach(Console.WriteLine);


        userTeam = Console.ReadLine();

        Console.WriteLine("What color do you want to be:");
        Console.WriteLine("0. Blue");
        Console.WriteLine("1. Red");
        Console.WriteLine("2. Green");
        Console.WriteLine("3. Yellow");
        Console.WriteLine("4. Magenta");
        userColor = int.Parse(Console.ReadLine());

        while (userColor < 0 || userColor > 4)
        {
            Console.WriteLine("Please enter a number between 0 and 4.");
            userColor = int.Parse(Console.ReadLine());
        }

        Color uCol;

        if (userColor == 0)
        {
            uCol = Color.blue;
        }
        else if (userColor == 1)
        {
            uCol = Color.red;
        } else if (userColor == 2)
        {
            uCol = Color.green;
        } else if (userColor == 3)
        {
            uCol = Color.yellow;
        }
        else
        {
            uCol = Color.magenta;
        }

        int uForm = 0;
        while (uForm < 1 ||uForm > 3) {
            Console.WriteLine("What formation do you want to play:");
            Console.WriteLine("1. 3-5-2");
            Console.WriteLine("2. 4-4-2:");
            Console.WriteLine("3. 5-3-2");
            uForm = int.Parse(Console.ReadLine());
            if (uForm < 1 || uForm > 3)
            {
                Console.WriteLine("Please enter a number between 1 and 3");
            }
        }
        




        string compSymbol, compTeam;
        int compColor;
        Console.WriteLine("What Symbol/Character do you want the computer to be:");
        compSymbol = Console.ReadLine();

        while (compSymbol.Length == 0 || compSymbol.Length > 1 || compSymbol == userSymbol)
        {
            Console.WriteLine("Please enter a single symbol/character that is different from your symbol.");
            compSymbol = Console.ReadLine();
        }
        char cSym = compSymbol[0];

        Console.WriteLine("What do you want the computers team to be:");
        compTeam = Console.ReadLine();


        Console.WriteLine("What color do you want the computer to be:");
        Console.WriteLine("0. Blue");
        Console.WriteLine("1. Red");
        Console.WriteLine("2. Green");
        Console.WriteLine("3. Yellow");
        Console.WriteLine("4. Magenta");
        compColor = int.Parse(Console.ReadLine());

        while (compColor < 0 || compColor > 4 || compColor ==userColor)
        {
            Console.WriteLine("Please enter a number between 0 and 4 that is different from your color.");
            compColor = int.Parse(Console.ReadLine());
        }

        Color cCol;

        if (compColor == 0)
        {
            cCol = Color.blue;
        }
        else if (compColor == 1)
        {
            cCol = Color.red;
        }
        else if (compColor == 2)
        {
            cCol = Color.green;
        }
        else if (compColor == 3)
        {
            cCol = Color.yellow;
        }
        else
        {
            cCol = Color.magenta;
        }

        int cForm = 0;
        while (cForm < 1 || cForm > 3)
        {
            Console.WriteLine("What formation do you want to play against:");
            Console.WriteLine("1. 3-5-2");
            Console.WriteLine("2. 4-4-2:");
            Console.WriteLine("3. 5-3-2");
            cForm = int.Parse(Console.ReadLine());
            if (cForm < 1 || cForm > 3)
            {
                Console.WriteLine("Please enter a number between 1 and 3");
            }
        }

        //end asking setup questions

        //start setting up grid

        Character[,] grid = new Character[14, 10];
        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                Fill fill = new Fill(' ');
                grid[x, y] = fill;
            }
        }

        Character a = new Character('A');
        Character b = new Character('B');
        Character c = new Character('C');
        Character d = new Character('D');
        Character e = new Character('E');
        Character f = new Character('F');
        Character g = new Character('G');
        Character h = new Character('H');
        Character i = new Character('I');
        Character j = new Character('J');
        Character k = new Character('K');
        Character l = new Character('L');
        Character m = new Character('M');

        grid[1,0] = a;
        grid[2, 0] = b;
        grid[3, 0] = c;
        grid[4, 0] = d;
        grid[5, 0] = e;
        grid[6, 0] = f;
        grid[7, 0] = g;
        grid[8, 0] = h;
        grid[9, 0] = i;
        grid[10, 0] = j;
        grid[11, 0] = k;
        grid[12, 0] = l;
        grid[13, 0] = m;
        

        GridNum one = new GridNum('1', false);
        GridNum two = new GridNum('2', false);
        GridNum three = new GridNum('3', false);
        GridNum four = new GridNum('4', false);
        GridNum five = new GridNum('5', false);
        GridNum six = new GridNum('6', false);
        GridNum seven = new GridNum('7', false);
        GridNum eight = new GridNum('8', false);
        GridNum nine = new GridNum('9', false);
        

        grid[0, 1] = one;
        grid[0, 2] = two;
        grid[0, 3] = three;
        grid[0, 4] = four;
        grid[0, 5] = five;
        grid[0, 6] = six;
        grid[0, 7] = seven;
        grid[0, 8] = eight;
        grid[0, 9] = nine;

        
            Player d1 = new Player(uSym, uCol);
            Player d2 = new Player(uSym, uCol);
            Player d3 = new Player(uSym, uCol);
            Player d4 = new Player(uSym, uCol);
            Player d5 = new Player(uSym, uCol);
            Player m1 = new Player(uSym, uCol);
            Player m2 = new Player(uSym, uCol);
            Player m3 = new Player(uSym, uCol);
            Player m4 = new Player(uSym, uCol);
            Player m5 = new Player(uSym, uCol);
            Player a1 = new Player(uSym, uCol);
            Player a2 = new Player(uSym, uCol);
        Player rem = new Player(uSym, uCol);

        if (uForm == 1)
        {
            grid[12, 2] = d1;
            grid[12, 5] = d2;
            grid[12, 8] = d3;

            grid[10, 1] = m1;
            grid[10, 3] = m2;
            grid[10, 5] = m3;
            grid[10, 7] = m4;
            grid[10, 9] = m5;
        }

        if (uForm == 2)
        {
            grid[12, 2] = d1;
            grid[12, 4] = d2;
            grid[12, 6] = d3;
            grid[12, 8] = d4;

            grid[10, 2] = m1;
            grid[10, 4] = m2;
            grid[10, 6] = m3;
            grid[10, 8] = m4;
        }

        if (uForm == 3)
        {
            grid[12, 1] = d1;
            grid[12, 3] = d2;
            grid[12, 5] = d3;
            grid[12, 7] = d4;
            grid[12, 9] = d5;

            grid[10, 2] = m1;
            grid[10, 5] = m2;
            grid[10, 8] = m3;
        }

        grid[8, 4] = a1;
        grid[8, 6] = a2;



        Player cd1 = new Player(cSym, cCol);
        Player cd2 = new Player(cSym, cCol);
        Player cd3 = new Player(cSym, cCol);
        Player cd4 = new Player(cSym, cCol);
        Player cd5 = new Player(cSym, cCol);
        Player cm1 = new Player(cSym, cCol);
        Player cm2 = new Player(cSym, cCol);
        Player cm3 = new Player(cSym, cCol);
        Player cm4 = new Player(cSym, cCol);
        Player cm5 = new Player(cSym, cCol);
        Player ca1 = new Player(cSym, cCol);
        Player ca2 = new Player(cSym, cCol);

        
        grid[6, 4] = ca1;
        grid[6, 6] = ca2;

        if (cForm == 1)
        {
            grid[4, 1] = cm1;
            grid[4, 3] = cm2;
            grid[4, 5] = cm3;
            grid[4, 7] = cm4;
            grid[4, 9] = cm5;

            grid[2, 2] = cd1;
            grid[2, 5] = cd2;
            grid[2, 8] = cd3;
        }

        if (cForm == 2) {
            grid[4, 2] = cm1;
            grid[4, 4] = cm2;
            grid[4, 6] = cm3;
            grid[4, 8] = cm4;
            grid[2, 2] = cd1;
            grid[2, 4] = cd2;
            grid[2, 6] = cd3;
            grid[2, 8] = cd4;
        }

        if (cForm == 3)
        {
            grid[4, 2] = cm1;
            grid[4, 5] = cm2;
            grid[4, 8] = cm3;

            grid[2, 1] = cd1;
            grid[2, 3] = cd2;
            grid[2, 5] = cd3;
            grid[2, 7] = cd4;
            grid[2, 9] = cd5;
        }

        Player ball = new Player('O', Color.white);
        grid[7, 5] = ball;

        int diff = 0;
        while (diff < 1 || diff > 3) {
            Console.WriteLine("\nDifficulty:");
            Console.WriteLine("1. Easy");
            Console.WriteLine("2. Medium");
            Console.WriteLine("3. Hard");
            diff = int.Parse(Console.ReadLine());
            if (diff < 1 || diff > 3)
            {
                Console.WriteLine("Please enter a number between 1 and 3");
            }
        }

        int difficulty = 0;
        Difficulty diffic;
        if (diff == 1)
        {
            difficulty = 40;
            diffic = Difficulty.Easy;
        }
        else if(diff == 2)
        {
            difficulty = 50;
            diffic = Difficulty.Normal;
        }
        else
        {
            difficulty = 60;
            diffic = Difficulty.Hard;
        }
        PrintPitch(grid);

        Console.WriteLine("\nThe goal is the number 5 and the dashes around it.");
        Console.WriteLine("Try to score with as few passes as possible.\nGood Luck. (Enter to Continue)");
        Console.ReadLine();

        for (int x  = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                if (grid[x, y] is Player) //need to fix this
                {
                    Player p = (Player)grid[x, y];
                    if (p.Col == uCol && p.Letter == uSym) { 
                        Fill fill = new Fill(' ');
                        grid[x, y] = fill;
                    }
                }
            }
        }
        int ballX;
        int ballY;

        if (uForm == 1)
        {
            ballX = 2;
            ballY = 7;
            grid[7, 2] = ball;
            grid[7, 5] = d2;
            grid[7, 8] = d3;

            grid[5, 1] = m1;
            grid[5, 3] = m2;
            grid[5, 5] = m3;
            grid[5, 7] = m4;
            grid[5, 9] = m5;

            grid[3, 4] = a1;
            grid[3, 6] = a2;

        }else if (uForm == 2)
        {
            ballX = 2;
            ballY = 7;
            grid[7, 2] = ball;
            grid[7, 4] = d2;
            grid[7, 6] = d3;
            grid[7, 8] = d4;

            grid[5, 2] = m1;
            grid[5, 4] = m2;
            grid[5, 6] = m3;
            grid[5, 8] = m4;

            grid[3, 4] = a1;
            grid[3, 6] = a2;
        }
        else
        {
            ballX = 1;
            ballY = 7;
            grid[7, 1] = ball;
            grid[7, 3] = d2;
            grid[7, 5] = d3;
            grid[7, 7] = d4;
            grid[7, 9] = d5;

            grid[5, 2] = m1;
            grid[5, 5] = m2;
            grid[5, 8] = m3;

            grid[3, 4] = a1;
            grid[3, 6] = a2;
        }

        grid[7, 5] = new Fill(' ');

        PrintPitch(grid);

        int turns = 0;
        int direction = 0;
        Random randomNum = new Random();
        bool goal = false;
        int userAct = 0;
        Character cRow = new Character('Z');
        int row = 0;
        int colm = 0;
        while (goal == false) {
            Console.WriteLine("1. Pass");
            Console.WriteLine("2. Dribble");
            Console.WriteLine("3. Shoot");
            userAct = int.Parse(Console.ReadLine());

            if (userAct < 1 || userAct > 3)
            {
                Console.WriteLine("Enter a number between 1 and 3.");
            }

            if (userAct == 1)
            {
                while (cRow.Letter < a.Letter || cRow.Letter > m.Letter) {
                    Console.WriteLine("What row do you want to pass to:");
                    cRow.Letter = char.Parse(Console.ReadLine());
                }

                while (colm < 1 || colm > 9)
                {
                    Console.WriteLine("What column do you want to pass to:");
                    colm = int.Parse(Console.ReadLine());
                }

                row = CheckRow(cRow);
                

                if (grid[row, colm].Letter == uSym && randomNum.Next(100) > difficulty) {
                        grid[row, colm] = ball;
                        grid[ballY, ballX] = new Player(uSym, uCol);
                        turns++;
                        ballY = row;
                        ballX = colm;
                        cRow.Letter = 'Z';
                        colm = 0;
                }
                else
                {
                    Console.WriteLine("You passed the ball away.");
                    cRow.Letter = 'Z';
                    colm = 0;
                    turns++;
                }
            }else if (userAct == 2)
            {
                while (direction < 1 || direction > 3) {
                    Console.WriteLine("Do you want to dribble:");
                    Console.WriteLine("1. Up");
                    Console.WriteLine("2. Left");
                    Console.WriteLine("3. Right");
                    direction = int.Parse(Console.ReadLine());
                }

                if (direction == 1 && grid[ballY-1, ballX].Letter == ' ')
                {
                    grid[ballY - 1, ballX] = ball;
                    grid[ballY, ballX] = new Fill(' ');
                    ballY = ballY - 1;
                    turns++;
                }
                else if (direction == 2 && grid[ballY, ballX - 1].Letter == ' ')
                {
                    grid[ballY, ballX-1] = ball;
                    grid[ballY, ballX] = new Fill(' ');
                    ballX = ballX - 1;
                    turns++;
                }else if (direction == 3 && grid[ballY, ballX+1].Letter == ' ')
                {
                    grid[ballY, ballX+1] = ball;
                    grid[ballY, ballX] = new Fill(' ');
                    ballX = ballX + 1;
                    turns++;
                }
                else
                {
                    Console.WriteLine("You dribbled the ball away");
                    turns++;
                }
                direction = 0;
            }else if (userAct == 3)
            {
                if (ballY > 6)
                {
                    Console.WriteLine("Nice Try, but you are do far out.");
                    turns++;
                }else if (ballY >=4)
                {
                    if (randomNum.Next(100) + 10 > difficulty)
                    {
                        Console.WriteLine("GOOOOOOOOAAAAAAAAAL!!!!!!!!!");
                        goal = true;
                        turns++;
                    }
                    else{
                        Console.WriteLine("Nice Try, but the goalie saved it. Try Again?");
                        turns++;
                    }
                }else if (ballY > 1)
                {
                    if (randomNum.Next(100) + 10 > difficulty)
                    {
                        Console.WriteLine("GOOOOOOOOAAAAAAAAAL");
                        goal = true;
                        turns++;
                    }
                    else
                    {
                        Console.WriteLine("Nice Try, but the goalie saved it. Try Again?");
                        turns++;
                    }
                }
            }

            PrintPitch(grid);
        }
        //Console.WriteLine(turns);

        using (StreamWriter writer = new StreamWriter("results.txt"))
        {
            writer.WriteLine(userTeam + " vs. " + compTeam);
            writer.WriteLine("It took you " + turns + " turns to score.");
            writer.WriteLine("You played on " + diffic + " difficulty.");
        }

    }

    public static void PrintPitch<T>(T[,] g)
    {
        for (int x = 0; x < g.GetLength(0); x++)
        {
            for (int y = 0; y < g.GetLength(1); y++)
            {
                Console.Write(g[x, y]);
                Console.ResetColor();
            }
            Console.WriteLine("");
        }
    }

    public static int CheckRow(Character c)
    {
        if (c.Letter == 'A')
        {
            return 1;
        }
        else if(c.Letter == 'B')
        {
            return 2;
        }else if (c.Letter == 'C')
        {
            return 3;
        }else if (c.Letter == 'D')
        {
            return 4;
        }else if (c.Letter == 'E')
        {
            return 5;
        }else if (c.Letter == 'F')
        {
            return 6;
        }else if (c.Letter == 'G')
        {
            return 7;
        }else if (c.Letter == 'H')
        {
            return 8;
        }else if (c.Letter == 'I')
        {
            return 9;
        }else if (c.Letter == 'J')
        {
            return 10;
        }else if (c.Letter == 'K')
        {
            return 11;
        }else if (c.Letter == 'L')
        {
            return 12;
        }
        else
        {
            return 13;
        }
    }
}

using System;
public class Player : Character {
    protected Color color;
    public Player(char c, Color col) : base(c)
    {
        color = col;
    }

    public override string ToString()
    {
        switch (color)
        {
            case Color.blue:
                Console.ForegroundColor = ConsoleColor.Blue;
                return $" {Letter}";
            case Color.red:
                Console.ForegroundColor = ConsoleColor.Red;
                return $" {Letter}";
            case Color.yellow:
                Console.ForegroundColor = ConsoleColor.Yellow;
                return $" {Letter}";
            case Color.green:
                Console.ForegroundColor = ConsoleColor.Green;
                return $" {Letter}";
            case Color.magenta:
                Console.ForegroundColor = ConsoleColor.Magenta;
                return $" {Letter}";
            default:
                Console.ForegroundColor= ConsoleColor.White;
                return $" {Letter}";

        }
    }
    public Color Col { get; }
}

using System;

public class GridNum : Character {
    public GridNum(char c, Boolean digit) : base(c)
    {
        Digit = digit;
    }

    public override string ToString()
    {
        if (Digit)
        {
            return $"_1{Letter}";
        }
        return $"_{Letter}";
    }

    public Boolean Digit
    {
        get;
        set;
    }
}

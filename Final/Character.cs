
public class Character {

    public Character(char letter)
    {
        Letter = letter;
    }

    public override string ToString()
    {
        return $"{Letter}|";
    }

    public char Letter
    {
        get;
        set;
    }
}

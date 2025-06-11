class Cell
{
    public char Visuals { get; }

    public Point position;

    public Cell(char visuals, int x, int y)
    {
        this.Visuals = visuals;
        position = new Point(x, y);
    }

    public Character? Occupant { get; private set; }

    internal bool IsOccupied()
    {
        return Occupant != null;
    }

    internal void Leave()
    {
        Occupant = null;
    }

    internal void Occupy(Character character)
    {
        ArgumentNullException.ThrowIfNull(character);
        Occupant = character;
    }

    internal void Display()
    {
        if (IsOccupied())
        {
            Occupant?.Display();
        }
        else
        {
            Console.SetCursorPosition(position.x, position.y);
            char cellData = Visuals;
            Console.Write(cellData);
        }
    }
}
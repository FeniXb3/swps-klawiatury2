class Cell
{
    public char Visuals { get; }

    public Cell(char visuals)
    {
        this.Visuals = visuals;
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
}
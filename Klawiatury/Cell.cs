class Cell
{
    public char Visuals { get; }

    private Character? occupant;

    public Cell(char visuals)
    {
        this.Visuals = visuals;
    }

    internal Character GetOccupant()
    {
        return occupant;
    }

    internal bool IsOccupied()
    {
        return occupant != null;
    }

    internal void Leave()
    {
        occupant = null;
    }

    internal void Occupy(Character character)
    {
        if (character == null)
        {
            throw new ArgumentNullException(nameof(character));
        }
        occupant = character;
    }
}
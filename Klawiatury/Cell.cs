


class Cell
{
    public char visuals;
    private Character? occupant;

    public Cell(char visuals)
    {
        this.visuals = visuals;
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
        occupant = character;
    }
}
class Level
{
    private string[] levelData =
    [
        "####.###################################",
        "........................................",
        "#...%.............................######",
        "#...............#...................#",
        "#.................................###",
        "#.................................#",
        "#.................................#",
        "#.................................#",
        "#.................................#",
        "#.................................#",
        "#.................................#",
        "###################################",
    ];

    public void Display()
    {
        foreach (string row in levelData)
        {
            Console.WriteLine(row);
        }
    }

    public int GetHeight()
    {
        return levelData.Length;
    }

    public void RedrawCell(Point position)
    {
        Console.SetCursorPosition(position.x, position.y);
        string row = levelData[position.y];
        char cellData = row[position.x];
        Console.Write(cellData);
    }

    public char GetCell(int x, int y)
    {
        return levelData[y][x];
    }

    public int GetRowWidth(int rowIndex)
    {
        return levelData[rowIndex].Length;
    }

    public bool IsWalkable(int x, int y)
    {
        return x >= 0 && x < GetRowWidth(y) && GetCell(x, y) != '#';
        // return !(x >= GetRowWidth(y) || x < 0 || GetCell(x, y) == '#');
    }
}
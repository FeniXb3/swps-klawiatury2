class Level
{
    private string[] levelVisuals =
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
        "###.###############################",
    ];

    Cell[][] levelData;

    public Level()
    {
        levelData = new Cell[levelVisuals.Length][];
        for (int y = 0; y < levelVisuals.Length; y++)
        {
            string visualsRow = levelVisuals[y];
            Cell[] dataRow = new Cell[visualsRow.Length];

            for (int x = 0; x < visualsRow.Length; x++)
            {
                dataRow[x] = new Cell(visualsRow[x]);
            }

            levelData[y] = dataRow;
        }
    }

    public void Display()
    {
        foreach (Cell[] row in levelData)
        {
            foreach (Cell cell in row)
            {
                Console.Write(cell.visuals);
            }
            Console.WriteLine();
        }
    }

    public int GetHeight()
    {
        return levelData.Length;
    }

    public void RedrawCell(Point position)
    {
        Console.SetCursorPosition(position.x, position.y);
        Cell[] row = levelData[position.y];
        char cellData = row[position.x].visuals;
        Console.Write(cellData);
    }

    public char GetCellVisuals(int x, int y)
    {
        return GetCell(x, y).visuals;
    }

    public int GetRowWidth(int rowIndex)
    {
        return levelData[rowIndex].Length;
    }

    public bool IsWalkable(int x, int y)
    {
        return y >= 0 && y < GetHeight() && x >= 0 && x < GetRowWidth(y) && GetCellVisuals(x, y) != '#';
    }

    public Cell GetCell(int x, int y)
    {
        return levelData[y][x];
    }
    
    public  Cell GetCell(Point coordinates)
    {
        return GetCell(coordinates.x, coordinates.y);
    }

    public bool IsCellOccupied(int x, int y)
    {
        return GetCell(x, y).IsOccupied(); 
    }

    public void OccupyCell(Point position, Character character)
    {
        GetCell(position).Occupy(character);
    }

    public void LeaveCell(Point position)
    {
        GetCell(position).Leave();
    }
}
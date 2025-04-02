class Player
{
    public string name;
    public Point position;
    public int speed = 1;

    public Player(string name)
    {
        this.name = name;
        position = new Point(0, 0);
    }
}

class PlayerClone : Player
{
    public PlayerClone(string name, string avatar) : base(name, avatar)
    {
    }

    public PlayerClone(string name, string avatar, Point position, Dictionary<ConsoleKey, string> keyActionMap) : base(name, avatar, position, keyActionMap)
    {
    }

    public override string ChooseAction()
    {
        return "moveDown";
    }
}

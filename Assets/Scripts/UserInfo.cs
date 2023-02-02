
public struct UserInfo 
{
    public string Name;
    public int Score;
    public BulletData CurrentBullet;

    public UserInfo(string name)
    {
        Name = name;
        Score = 0;
        CurrentBullet = new BulletData();
    }
}
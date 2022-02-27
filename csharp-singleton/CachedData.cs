namespace csharp_singleton;

public class CachedData
{
    public Dictionary<int, string> Planets { get; }
    public Dictionary<int, Dictionary<int, string>> Satellites { get; }

    public CachedData(Dictionary<int, string> planets, Dictionary<int, Dictionary<int, string>> satellites)
    {
        Planets = planets;
        Satellites = satellites;
    }
}
namespace csharp_singleton;

internal static class Program
{
    public static void Main()
    {
        Console.WriteLine("LOADING DATA FROM DATABASE ....");
        Console.WriteLine("[x] Loading planets ....");
        // key -> planet id
        // value -> planet name
        var planets = new Dictionary<int, string>()
        {
            {1, "Mercury"},
            {2, "Venus"},
            {3, "Earth"},
            {4, "Mars"},
            {5, "Jupiter"},
            {6, "Saturn"},
            {7, "Uranus"},
            {8, "Neptune"}
        };

        Console.WriteLine("[x] Loading satellites ....");
        // key -> planet id
        // value -> planet satellites (Dictionary)
        //          key -> satellite id
        //          value -> satellite name
        var satellites = new Dictionary<int, Dictionary<int, string>>()
        {
            // Earth
            {3, new Dictionary<int, string>()
            {
                {1, "Moon"}
            }},
            // Mars
            {4, new Dictionary<int, string>()
            {
                {1, "Phobos"},
                {2, "Deimos"}
            }},
            // Jupiter
            {5, new Dictionary<int, string>()
            {
                // only the first 4 ;-)
                {1, "Metis"},
                {2, "Adrastea"},
                {3, "Amalthea"},
                {4, "Thebe"}
            }},
            // Saturn
            {6, new Dictionary<int, string>()
            {
                // only the first 4 ;-)
                {1, "Pan"},
                {2, "Daphnis"},
                {3, "Atlas"},
                {4, "Prometheus"}
            }},
            // Uranus
            {7, new Dictionary<int, string>()
            {
                // only the first 4 ;-)
                {1, "Ariel"},
                {2, "Umbriel"},
                {3, "Titania"},
                {4, "Oberon"}
            }},
            // Neptune
            {8, new Dictionary<int, string>()
            {
                // only the first 4 ;-)
                {1, "Triton"},
                {2, "Nereid"},
                {3, "Naiad"},
                {4, "Thalassa"}
            }}
        };

        Console.WriteLine("[x] Caching data ....");
        CacheExample.CreateInstance(new CachedData(planets, satellites));

        Console.WriteLine("FETCHING DATA FROM CACHE ....");
        Console.WriteLine("[x] Loading cache instance ....");
        var cache = CacheExample.Instance;
        var cachedData = cache.Data;

        var cachedPlanets = cachedData.Planets;
        var cachedSatellites = cachedData.Satellites;

        Console.WriteLine("[x] Printing cached data");
        foreach (var planet in cachedPlanets)
        {
            Console.WriteLine("- {0}", planet.Value);
            if (cachedSatellites.ContainsKey(planet.Key))
            {
                foreach (var sat in cachedSatellites[planet.Key])
                {
                    Console.WriteLine("    * {0}", sat.Value);
                }
            }
            else
            {
                Console.WriteLine("    {0} has no satellites", planet.Value);
            }
        }

    }
}
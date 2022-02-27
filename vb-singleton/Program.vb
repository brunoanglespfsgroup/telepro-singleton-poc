Imports System

Module Program
    Sub Main(args As String())
        Console.WriteLine("LOADING DATA FROM DATABASE ....")
        
        Console.WriteLine("[x] Loading planets ....")
        ' key -> planet id
        ' value -> planet name
        Dim planets as New Dictionary(Of Integer, String)
        planets.Add(1, "Mercury")
        planets.Add(2, "Venus")
        planets.Add(3, "Earth")
        planets.Add(4, "Mars")
        planets.Add(5, "Jupiter")
        planets.Add(6, "Saturn")
        planets.Add(7, "Uranus")
        planets.Add(8, "Neptune")
        
        Console.WriteLine("[x] Loading satellites ....")
        ' key -> planet id
        ' value -> planet satellites (Dictionary)
        '          key -> satellite id
        '          value -> satellite name
        Dim satellites as new Dictionary(Of Integer, Dictionary(Of Integer,String))
        
        Dim earthSatellites as New Dictionary(Of Integer, String)
        earthSatellites.Add(1, "Moon")
        satellites.Add(3, earthSatellites)
        
        Dim marsSatellites as New Dictionary(Of Integer, String)
        marsSatellites.Add(1, "Phobos")
        marsSatellites.Add(2, "Deimos")
        satellites.Add(4, marsSatellites)
        
        Dim jupiterSatellites as New Dictionary(Of Integer, String)
        ' only the first 4 ;-)
        jupiterSatellites.Add(1, "Metis")
        jupiterSatellites.Add(2, "Adrastea")
        jupiterSatellites.Add(3, "Amalthea")
        jupiterSatellites.Add(4, "Thebe")
        satellites.Add(5, jupiterSatellites)
        
        Dim saturnSatellites as New Dictionary(Of Integer, String)
        ' only the first 4 ;-)
        saturnSatellites.Add(1, "Pan")
        saturnSatellites.Add(2, "Daphnis")
        saturnSatellites.Add(3, "Atlas")
        saturnSatellites.Add(4, "Prometheus")
        satellites.Add(6, saturnSatellites)
        
        Dim uranusSatellites as New Dictionary(Of Integer, String)
        ' only the first 4 ;-)
        uranusSatellites.Add(1, "Ariel")
        uranusSatellites.Add(2, "Umbriel")
        uranusSatellites.Add(3, "Titania")
        uranusSatellites.Add(4, "Oberon")
        satellites.Add(7, uranusSatellites)
        
        Dim neptuneSatellites as New Dictionary(Of Integer, String)
        ' only the first 4 ;-)
        neptuneSatellites.Add(1, "Triton")
        neptuneSatellites.Add(2, "Nereid")
        neptuneSatellites.Add(3, "Naiad")
        neptuneSatellites.Add(4, "Thalassa")
        satellites.Add(8, neptuneSatellites)

        Console.WriteLine("[x] Caching data ....")
        CacheExample.CreateInstance(new CachedData(planets, satellites))
        
        Console.WriteLine("FETCHING DATA FROM CACHE ....")
        Console.WriteLine("[x] Loading cache instance ....")
        Dim cache = CacheExample.GetInstance()
        Dim cachedData = cache.GetData()
        
        Dim cachedPlanets = cachedData.GetPlanets()
        Dim cachedSatellites = cachedData.GetSatellites()
        
        Console.WriteLine("[x] Printing cached data")
        For Each planet As KeyValuePair(Of Integer, String) In cachedPlanets
            Console.WriteLine("- {0}", planet.Value)
            If cachedSatellites.ContainsKey(planet.Key)
                For Each sat As KeyValuePair(Of Integer, String) in cachedSatellites(planet.Key)
                    Console.WriteLine("    * {0}", sat.Value)
                Next sat
            Else
                Console.WriteLine("    {0} has no satellites",  planet.Value)
            End If
        Next planet
        
    End Sub
End Module

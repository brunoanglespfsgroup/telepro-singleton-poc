Public Class CachedData
    Private ReadOnly _planets as Dictionary(Of Integer, String)
    Private ReadOnly _satellites as Dictionary(Of Integer, Dictionary(Of Integer, String))

    Public Sub New (planets as Dictionary (Of Integer, String), 
                    satellites as Dictionary(Of Integer, Dictionary(Of Integer, String)))
        _planets = planets
        _satellites = satellites
    End Sub
    
    Public Function GetPlanets() As Dictionary(Of Integer, String)
        Return _planets
    End Function
    
    Public  Function  GetSatellites() As Dictionary(Of Integer, Dictionary(Of Integer, String))
        Return _satellites
    End Function
End Class
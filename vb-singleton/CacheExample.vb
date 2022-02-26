Imports System.Threading
' https://www.techcoil.com/blog/implementing-the-singleton-pattern-in-visual-basic-dot-net/
Public Class CacheExample
 
    ' For SyncLock to mark a critical section
    Private Shared ReadOnly _classLocker As New Object()
 
    ' Allocate memory space to hold the 
    ' single object instance
    Private Shared _objSingleton As CacheExample
    
    ' It will hold cached data
    Private _cachedData as CAchedData
 
    ' Make the only constructor private 
    ' to prevent initialization outside of 
    ' the class.
    Private Sub New()
    End Sub
 
    ' Expose getInstance() for the retrieval 
    ' of the single object instance.
    Public Shared Function GetInstance() As CacheExample
 
        ' Initialize singleton through lazy 
        ' initialization to prevent unused 
        ' singleton from taking up program 
        ' memory
        If (_objSingleton Is Nothing) Then
            ' Mark a critical section where 
            ' threads take turns to execute
            SyncLock (_classLocker)
                If (_objSingleton Is Nothing) Then
                    _objSingleton = New CacheExample()
                End If
            End SyncLock
        End If
        Return _objSingleton
 
    End Function
    
    Public Shared Function CreateInstance(data as CachedData) As CacheExample
        Dim cache = CacheExample.GetInstance()
        cache._cachedData = data
        Return cache
    End Function
    
    Public Function GetData() As CachedData
        Return _cachedData
    End Function
 
End Class
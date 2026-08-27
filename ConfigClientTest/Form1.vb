Imports Utility
Imports Utility.Types
Imports Utility.Types.ERRORTYPE

Public Class Form1

    Private m_Functions As New Functions

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ServerConfigCollection As Collections.SortedList = New Collections.SortedList

        ' Remote Config Server
        Dim ConfigServer As New ConfigService.ConfigClient

        ' Local Config Server
        Dim LocalConfig As New LocalConfig.ConfigClient

        ' Remote
        ServerConfigCollection = ConfigServer.GetConfigCollection("server")

        ' Local
        'ServerConfigCollection = LocalConfig.GetConfigCollection("server")

        If ServerConfigCollection.Count > 0 Then
            Debug.Print(ServerConfigCollection.Count & " server config items loaded.")
        Else
            Debug.Print("An error occured retrieving the Server config items.")
        End If

    End Sub
End Class

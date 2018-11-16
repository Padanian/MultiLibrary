Imports System.Configuration
Imports System.IO
Imports MultiLibrary

Public Class Form1
    Dim pp0 As New MultiLibrary.MultiGenPointCalendarClock
    Dim pp1 As New MultiLibrary.MultiGenPointCalendarClock
    Dim pp2 As New MultiLibrary.MultiGenPointCalendarClock

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With pp0
            .Location = New Point(50, 50)
            .Name = "pp0"
        End With
        Me.Controls.Add(pp0)
        With pp1
            .Location = New Point(150, 50)
            .Name = "pp1"
        End With
        Me.Controls.Add(pp1)
        With pp2
            .Location = New Point(250, 50)
            .Name = "pp2"
        End With
        Me.Controls.Add(pp2)

        For Each pp In Me.Controls
            If TypeOf (pp) Is MultiGenPointCalendarClock Then

                Dim bf As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
                Dim filename As String = Application.LocalUserAppDataPath & "\" & pp.Name & ".mgpcc"

                If File.Exists(filename) Then

                    Dim fStream As New FileStream(filename, FileMode.OpenOrCreate)
                    pp.Settings = bf.Deserialize(fStream)
                    fStream.Close()
                Else
                    pp0.Settings = {0, 0, 0, 0, 0, 0}

                    Dim fStream As New FileStream(filename, FileMode.OpenOrCreate)
                    bf.Serialize(fStream, pp.Settings) ' write to file
                    fStream.Close()
                End If
            End If
        Next


    End Sub

    Private Sub Form1_closing(sender As Object, e As EventArgs) Handles Me.Closing

        For Each pp In Me.Controls
            If TypeOf (pp) Is MultiGenPointCalendarClock Then

                Dim bf As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
                Dim filename As String = Application.LocalUserAppDataPath & "\" & pp.Name & ".mgpcc"

                Dim fStream As New FileStream(filename, FileMode.OpenOrCreate)
                bf.Serialize(fStream, pp.Settings) ' write to file
                fStream.Close()

            End If
        Next

    End Sub

End Class

Imports System.Configuration
Imports System.IO
Imports MultiLibrary

Public Class Form1
    'Dim pp0 As New MultiLibrary.MultiGenPointCalendarClock
    'Dim pp1 As New MultiLibrary.MultiGenPointCalendarClock
    'Dim pp2 As New MultiLibrary.MultiGenPointCalendarClock

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'With pp0
        '    .Location = New Point(50, 50)
        '    .Name = "pp0"
        'End With
        'Me.Controls.Add(pp0)
        'With pp1
        '    .Location = New Point(150, 50)
        '    .Name = "pp1"
        'End With
        'Me.Controls.Add(pp1)
        'With pp2
        '    .Location = New Point(250, 50)
        '    .Name = "pp2"
        'End With
        'Me.Controls.Add(pp2)

        For Each pp In Me.Controls
            If TypeOf (pp) Is MultiGenPointCalendarClock Then

                Dim bf As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
                Dim filename As String = Application.LocalUserAppDataPath & "\" & pp.Name & ".mgpcc"

                If File.Exists(filename) Then

                    Dim fStream As New FileStream(filename, FileMode.OpenOrCreate)
                    pp.Settings = bf.Deserialize(fStream)
                    fStream.Close()
                Else
                    'pp0.Settings = {0, 0, 0, 0, 0, 0}

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

    Private Sub MultiTrimmerKnob1_Load() Handles MultiTrimmerKnob1.ValueChanged, MultiTrimmerKnob2.ValueChanged
        MultiVerticalMeter1.value = MultiTrimmerKnob1.value
        MultiGauge1.value = MultiTrimmerKnob1.value
        MultiGauge2.value = MultiTrimmerKnob1.value / 2
    End Sub


    Private Sub MultiPanelSwitch1_Click() Handles MultiPanelSwitch1.PositionChanged
        If MultiPanelSwitch1.selectedPosition = 0 Then
            MultiPanelSemaphor1.semaphorColor = Color.Red
        ElseIf MultiPanelSwitch1.selectedPosition = 1 Then
            MultiPanelSemaphor1.semaphorColor = Color.Yellow
        ElseIf MultiPanelSwitch1.selectedPosition = 2 Then
            MultiPanelSemaphor1.semaphorColor = Color.Blue
        End If
    End Sub
    Private Sub MultiPanelSwitch2_Click() Handles MultiPanelSwitch2.PositionChanged
        If MultiPanelSwitch2.selectedPosition = 0 Then
            MultiPanelSemaphor2.semaphorColor = Color.Green
        ElseIf MultiPanelSwitch2.selectedPosition = 1 Then
            MultiPanelSemaphor2.semaphorColor = Color.Black
        ElseIf MultiPanelSwitch2.selectedPosition = 2 Then
            MultiPanelSemaphor2.semaphorColor = Color.Blue
        End If
    End Sub


    Private Sub MultiTrimmerKnob2_Load() Handles MultiTrimmerKnob2.ValueChanged
        MultiAmmVoltmeter1.value = MultiTrimmerKnob2.value
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.Show()
        Me.Hide()
    End Sub
End Class

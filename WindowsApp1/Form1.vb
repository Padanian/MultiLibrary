Imports MultiLibrary

Public Class Form1
    Dim pp0 As New MultiLibrary.MultiGenPointCalendarClock
    Dim pp1 As New MultiLibrary.MultiGenPointCalendarClock
    Dim pp2 As New MultiLibrary.MultiGenPointCalendarClock

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With pp0
            .Location = New Point(50, 50)
        End With
        Me.Controls.Add(pp0)
        With pp1
            .Location = New Point(150, 50)
        End With
        Me.Controls.Add(pp1)
        With pp2
            .Location = New Point(250, 50)
        End With
        Me.Controls.Add(pp2)

        pp0.AppSettings = My.Settings
        pp1.AppSettings = My.Settings
        pp2.AppSettings = My.Settings


        'pp0.AppSettings.Item("MGPCCSettings0") = pp0.Settings(0)
        'pp1.AppSettings.Item("MGPCCSettings0") = pp1.Settings(0)
        'pp2.AppSettings.Item("MGPCCSettings0") = pp2.Settings(0)
        'pp0.AppSettings.Item("MGPCCSettings1") = pp0.Settings(1)
        'pp1.AppSettings.Item("MGPCCSettings1") = pp1.Settings(1)
        'pp2.AppSettings.Item("MGPCCSettings1") = pp2.Settings(1)
        'pp0.AppSettings.Item("MGPCCSettings2") = pp0.Settings(2)
        'pp1.AppSettings.Item("MGPCCSettings2") = pp1.Settings(2)
        'pp2.AppSettings.Item("MGPCCSettings2") = pp2.Settings(2)
        'pp0.AppSettings.Item("MGPCCSettings3") = pp0.Settings(3)
        'pp1.AppSettings.Item("MGPCCSettings3") = pp1.Settings(3)
        'pp2.AppSettings.Item("MGPCCSettings3") = pp2.Settings(3)
        'pp0.AppSettings.Item("MGPCCSettings4") = pp0.Settings(4)
        'pp1.AppSettings.Item("MGPCCSettings4") = pp1.Settings(4)
        'pp2.AppSettings.Item("MGPCCSettings4") = pp2.Settings(4)
        'pp0.AppSettings.Item("MGPCCSettings5") = pp0.Settings(5)
        'pp1.AppSettings.Item("MGPCCSettings5") = pp1.Settings(5)
        'pp2.AppSettings.Item("MGPCCSettings5") = pp2.Settings(5)

    End Sub

    Private Sub Form1_closing(sender As Object, e As EventArgs) Handles Me.Closing
        pp0.AppSettings.Save()
        pp1.AppSettings.Save()
        pp2.AppSettings.Save()

    End Sub

End Class

Imports System.Windows.Forms
Public Class frmCalendarClockSettings
    Public Settings As Integer()

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        Dim F1Start As Integer = dtpF1Start.Value.Hour * 12 + dtpF1Start.Value.Minute \ 5
        Dim F2Start As Integer = dtpF2Start.Value.Hour * 12 + dtpF2Start.Value.Minute \ 5
        Dim F3Start As Integer = dtpF3Start.Value.Hour * 12 + dtpF3Start.Value.Minute \ 5
        Dim F1Stop As Integer = dtpF1Stop.Value.Hour * 12 + dtpF1Stop.Value.Minute \ 5
        Dim F2Stop As Integer = dtpF2Stop.Value.Hour * 12 + dtpF2Stop.Value.Minute \ 5
        Dim F3Stop As Integer = dtpF3Stop.Value.Hour * 12 + dtpF3Stop.Value.Minute \ 5

        If (F1Start < F1Stop Or (F1Start = 0 And F1Stop = 0)) And
            (F1Stop < F2Start Or F2Start = 0) And
            (F2Start < F2Stop Or (F2Start = 0 And F2Stop = 0)) And
            (F2Stop < F3Start Or F2Start = 0) And
            (F3Start < F3Stop Or (F3Start = 0 And F3Start = 0)) Then

            Settings = {F1Start, F1Stop, F2Start, F2Stop, F3Start, F3Stop}

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dtpF1Start_ValueChanged(sender As Object, e As EventArgs) Handles dtpF1Start.ValueChanged
        dtpF1Stop.MinDate = dtpF1Start.Value
    End Sub

    Private Sub dtpF1Stop_ValueChanged(sender As Object, e As EventArgs) Handles dtpF1Stop.ValueChanged
        dtpF2Start.MinDate = dtpF1Stop.Value
    End Sub

    Private Sub dtpF2Start_ValueChanged(sender As Object, e As EventArgs) Handles dtpF2Start.ValueChanged
        dtpF2Stop.MinDate = dtpF2Start.Value
    End Sub

    Private Sub dtpF2Stop_ValueChanged(sender As Object, e As EventArgs) Handles dtpF2Stop.ValueChanged
        dtpF3Start.MinDate = dtpF2Stop.Value
    End Sub

    Private Sub dtpF3Start_ValueChanged(sender As Object, e As EventArgs) Handles dtpF3Start.ValueChanged
        dtpF3Stop.MinDate = dtpF3Start.Value
    End Sub
End Class

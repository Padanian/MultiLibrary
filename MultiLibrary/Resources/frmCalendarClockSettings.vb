Imports System.Windows.Forms
Public Class frmCalendarClockSettings
    Public mgppSettings As Integer()

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        Dim F1Start As Integer = dtpF1Start.Value.Hour * 12 + dtpF1Start.Value.Minute \ 5
        Dim F2Start As Integer = dtpF2Start.Value.Hour * 12 + dtpF2Start.Value.Minute \ 5
        Dim F3Start As Integer = dtpF3Start.Value.Hour * 12 + dtpF3Start.Value.Minute \ 5
        Dim F1Stop As Integer = dtpF1Stop.Value.Hour * 12 + dtpF1Stop.Value.Minute \ 5
        Dim F2Stop As Integer = dtpF2Stop.Value.Hour * 12 + dtpF2Stop.Value.Minute \ 5
        Dim F3Stop As Integer = dtpF3Stop.Value.Hour * 12 + dtpF3Stop.Value.Minute \ 5

        If chkF2.Checked = False Then
            F2Start = 0
            F2Stop = 0
        End If
        If chkF3.Checked = False Then
            F3Start = 0
            F3Stop = 0
        End If

        If (F1Start < F1Stop Or (F1Start = 0 And F1Stop = 0)) Then
            If chkF2.Checked Then
                If (F1Stop < F2Start Or F2Start = 0) And (F2Start < F2Stop Or (F2Start = 0 And F2Stop = 0)) Then
                    If chkF3.Checked Then
                        If (F2Stop < F3Start Or F2Start = 0) And (F3Start < F3Stop Or (F3Start = 0 And F3Start = 0)) Then
                            mgppSettings = {F1Start, F1Stop, F2Start, F2Stop, F3Start, F3Stop}
                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                            Me.Close()
                        Else
                            Exit Sub
                        End If
                    Else
                        mgppSettings = {F1Start, F1Stop, F2Start, F2Stop, F3Start, F3Stop}
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        Me.Close()
                    End If
                Else
                    Exit Sub
                End If
            Else
                mgppSettings = {F1Start, F1Stop, F2Start, F2Stop, F3Start, F3Stop}
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()

            End If
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

    Private Sub chkF2_CheckedChanged(sender As Object, e As EventArgs) Handles chkF2.CheckedChanged
        If chkF2.Checked = False Then
            dtpF2Start.Enabled = False
            dtpF2Stop.Enabled = False
            Label2.Enabled = False
        Else
            dtpF2Start.Enabled = True
            dtpF2Stop.Enabled = True
            Label2.Enabled = True
        End If
    End Sub

    Private Sub chkF3_CheckedChanged(sender As Object, e As EventArgs) Handles chkF3.CheckedChanged
        If chkF3.Checked = False Then
            dtpF3Start.Enabled = False
            dtpF3Stop.Enabled = False
            Label3.Enabled = False
        Else
            dtpF3Start.Enabled = True
            dtpF3Stop.Enabled = True
            Label3.Enabled = True
        End If

    End Sub

    Private Sub frmCalendarClockSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If Not mgppSettings.SequenceEqual({0, 0, 0, 0, 0, 0}) Then
                Dim midnight = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0)
                If mgppSettings(0) = 0 And mgppSettings(1) = 0 And mgppSettings(2) = 0 And mgppSettings(3) = 0 Then
                    dtpF1Start.Value = midnight.AddHours(mgppSettings(4) \ 12).AddMinutes((mgppSettings(4) Mod 12) * 5)
                    dtpF1Stop.Value = midnight.AddHours(mgppSettings(5) \ 12).AddMinutes((mgppSettings(5) Mod 12) * 5)
                ElseIf mgppSettings(0) = 0 And mgppSettings(1) = 0 Then
                    chkF2.Checked = True
                    dtpF1Start.Value = midnight.AddHours(mgppSettings(2) \ 12).AddMinutes((mgppSettings(2) Mod 12) * 5)
                    dtpF1Stop.Value = midnight.AddHours(mgppSettings(3) \ 12).AddMinutes((mgppSettings(3) Mod 12) * 5)
                    dtpF2Start.Value = midnight.AddHours(mgppSettings(4) \ 12).AddMinutes((mgppSettings(4) Mod 12) * 5)
                    dtpF2Stop.Value = midnight.AddHours(mgppSettings(5) \ 12).AddMinutes((mgppSettings(5) Mod 12) * 5)
                Else
                    chkF2.Checked = True
                    chkF3.Checked = True
                    dtpF1Start.Value = midnight.AddHours(mgppSettings(0) \ 12).AddMinutes((mgppSettings(0) Mod 12) * 5)
                    dtpF1Stop.Value = midnight.AddHours(mgppSettings(1) \ 12).AddMinutes((mgppSettings(1) Mod 12) * 5)
                    dtpF2Start.Value = midnight.AddHours(mgppSettings(2) \ 12).AddMinutes((mgppSettings(2) Mod 12) * 5)
                    dtpF2Stop.Value = midnight.AddHours(mgppSettings(3) \ 12).AddMinutes((mgppSettings(3) Mod 12) * 5)
                    dtpF3Start.Value = midnight.AddHours(mgppSettings(4) \ 12).AddMinutes((mgppSettings(4) Mod 12) * 5)
                    dtpF3Stop.Value = midnight.AddHours(mgppSettings(5) \ 12).AddMinutes((mgppSettings(5) Mod 12) * 5)
                End If
            End If
        Catch
        End Try

    End Sub
End Class

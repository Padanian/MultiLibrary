﻿Public Class MultiAmmVoltmeter

    Const Pi As Double = Math.PI
    Dim x1, y1, x2, y2 As Integer
    Dim xp1, yp1, xp2, yp2 As Int32
    Private m_value As Double = 0
    Private m_minimum As Double = 0
    Private m_maximum As Double = 400
    Private m_Units As String = "V"
    Dim centreX As Integer = 125
    Dim centreY As Integer = 125
    Dim apen As New Pen(Color.LightGray, 1)
    Dim bpen As New Pen(Color.Gray, 1)
    Dim cpen As New Pen(Color.Black, 1)
    Dim lpen As New Pen(Color.Black, 2)
    Dim rpen As New Pen(Color.Black, 4)
    Dim tpen As New Pen(Color.Transparent, 2)
    Dim radius As Integer = 120
    Dim changed As Boolean = True
    Dim Lend As Double
    Public Property units As String
        Get
            units = m_Units
        End Get
        Set(units As String)
            If units = "V" Then
                lblUnits.Text = "Volts"
                m_Units = units
            ElseIf units = "A" Then
                lblUnits.Text = "Ampere"
                m_Units = units
            ElseIf units = "H" Then
                lblUnits.Text = "Hertz"
                m_Units = units

            Else
                Exit Property
            End If

        End Set
    End Property

    Public Property value As Double
        Get
            value = m_value
        End Get
        Set(value As Double)

            Dim uu As String
            If units = "H" Then
                uu = "Hz"
            Else
                uu = units
            End If


            If value < m_minimum Then
                lblValue.Text = Format(Math.Round(value, 1), "###0.0#") & " " & uu
                value = m_minimum
                m_value = value
            ElseIf value > m_maximum Then
                lblValue.Text = Format(Math.Round(value, 1), "###0.0#") & " " & uu
                value = m_maximum
                m_value = value
            Else
                lblValue.Text = Format(Math.Round(value, 1), "###0.0#") & " " & uu
                m_value = value
            End If

            Me.Refresh()
        End Set
    End Property
    Public Property minimum As Double
        Get
            minimum = m_minimum
        End Get
        Set(minimum As Double)
            If minimum > maximum Then
                MsgBox("Min can't be greater than Max")
                Exit Property
            End If
            m_minimum = minimum
            For Each lbl In Me.Controls
                Select Case lbl.tag
                    Case "lbl0"
                        lbl.text = minimum
                    Case "lbl2"
                        lbl.text = (maximum - minimum) / 16 * (2.ToString.PadLeft(2, "0")) + minimum
                    Case "lbl4"
                        lbl.text = (maximum - minimum) / 16 * (4.ToString.PadLeft(2, "0")) + minimum
                    Case "lbl6"
                        lbl.text = (maximum - minimum) / 16 * (6.ToString.PadLeft(2, "0")) + minimum
                    Case "lbl8"
                        lbl.text = (maximum - minimum) / 16 * (8.ToString.PadLeft(2, "0")) + minimum
                    Case "lbl10"
                        lbl.text = (maximum - minimum) / 16 * (10.ToString.PadLeft(2, "0")) + minimum
                    Case "lbl12"
                        lbl.text = (maximum - minimum) / 16 * (12.ToString.PadLeft(2, "0")) + minimum
                    Case "lbl14"
                        lbl.text = (maximum - minimum) / 16 * (14.ToString.PadLeft(2, "0")) + minimum
                    Case "lbl16"
                        lbl.text = (maximum - minimum) / 16 * (16.ToString.PadLeft(2, "0")) + minimum

                End Select
            Next
            changed = True
            Me.Refresh()
        End Set
    End Property
    Public Property maximum As Double
        Get
            maximum = m_maximum
        End Get
        Set(maximum As Double)
            If maximum < minimum Then
                MsgBox("Max can't be smaller than Min")
                Exit Property
            End If
            m_maximum = maximum
            For Each lbl In Me.Controls
                Select Case lbl.tag
                    Case "lbl0"
                        lbl.text = minimum
                    Case "lbl2"
                        lbl.text = (maximum - minimum) / 16 * (2.ToString.PadLeft(2, "0")) + minimum
                    Case "lbl4"
                        lbl.text = (maximum - minimum) / 16 * (4.ToString.PadLeft(2, "0")) + minimum
                    Case "lbl6"
                        lbl.text = (maximum - minimum) / 16 * (6.ToString.PadLeft(2, "0")) + minimum
                    Case "lbl8"
                        lbl.text = (maximum - minimum) / 16 * (8.ToString.PadLeft(2, "0")) + minimum
                    Case "lbl10"
                        lbl.text = (maximum - minimum) / 16 * (10.ToString.PadLeft(2, "0")) + minimum
                    Case "lbl12"
                        lbl.text = (maximum - minimum) / 16 * (12.ToString.PadLeft(2, "0")) + minimum
                    Case "lbl14"
                        lbl.text = (maximum - minimum) / 16 * (14.ToString.PadLeft(2, "0")) + minimum
                    Case "lbl16"
                        lbl.text = (maximum - minimum) / 16 * (16.ToString.PadLeft(2, "0")) + minimum

                End Select
            Next
            changed = True
            Me.Refresh()
        End Set
    End Property
    Private Sub GaugePaint(sender As Object, e As PaintEventArgs) Handles Me.Paint


        Dim i As Integer = 0
        For num As Double = -Pi To -Pi / 2 + 0.001 Step Pi / 32

            Dim cosnum = Math.Cos(num)
            Dim cossin = Math.Sin(num)

            x1 = Math.Truncate(radius * cosnum + centreX)
            y1 = Math.Truncate(radius * cossin + centreY)
            If i Mod 2 = 0 Then
                x2 = Math.Truncate(7 / 8 * radius * cosnum + centreX)
                y2 = Math.Truncate(7 / 8 * radius * cossin + centreY)
            Else
                x2 = Math.Truncate(15 / 16 * radius * cosnum + centreX)
                y2 = Math.Truncate(15 / 16 * radius * cossin + centreY)
            End If

            e.Graphics.DrawLine(apen, x1, y1, x2, y2)
            If changed Then
                addlabel(i)
            End If

            i += 1
        Next

        e.Graphics.DrawArc(bpen, centreX - 15, centreY - 15, 30, 30, 180, 90)
        e.Graphics.DrawLine(bpen, centreX, centreY + 1, centreX - 15, centreY + 1)
        e.Graphics.DrawLine(bpen, centreX + 1, centreY, centreX + 1, centreY - 15)

        changed = False

        e.Graphics.DrawRectangle(lpen, 1, 1, 148, 148)
        redrawLine(e)

    End Sub
    Private Sub addlabel(ByVal i As Integer)
        Dim lblScale As New Label
        With lblScale
            .Location = New Point(x2 - 4, y2 - 2)
            .Size = New Size(24, 10)
            .Text = (maximum - minimum) / 16 * (i.ToString.PadLeft(2, "0")) + minimum
            .Font = New Font("Segoe UI", 5, FontStyle.Regular)
            .ForeColor = Color.Black
            .BackColor = Color.Transparent
            .TextAlign = ContentAlignment.TopLeft
            .Tag = "lbl" & i.ToString
        End With
        For Each lbl In Me.Controls
            If TypeOf (lbl) Is Label And lbl.tag = "lbl" & i.ToString Then
                Exit Sub
            End If
        Next
        If i Mod 2 = 0 Then
            Me.Controls.Add(lblScale)
            lblScale.BringToFront()
        End If
    End Sub
    Sub New()

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        maximum = 400
        minimum = 0
        value = minimum
        units = "V"

    End Sub
    Public Sub redrawLine(e As PaintEventArgs)
        Dim newLend As Double = -Pi / 2 * ((maximum - value) / (maximum - minimum)) - Pi / 2
        If newLend <> Lend Then
            Lend = newLend

            Dim coslend As Double = Math.Cos(Lend)
            Dim sinlend As Double = Math.Sin(Lend)

            xp1 = Math.Truncate(85 * coslend + centreX)
            yp1 = Math.Truncate(85 * sinlend + centreY)
            xp2 = Math.Truncate(15 * coslend + centreX)
            yp2 = Math.Truncate(15 * sinlend + centreY)

            e.Graphics.DrawLine(rpen, xp1, yp1, xp2, yp2)
        End If
    End Sub


End Class

Public Class MultiAmmVoltmeter

    Const Pi As Double = Math.PI
    Dim x1, y1, x2, y2 As Integer
    Dim xp1, yp1, xp2, yp2 As Int32
    Private m_value As Decimal
    Private m_minimum As Integer
    Private m_maximum As Integer
    Private m_Units As String = "V"
    Dim centreX As Integer = 125
    Dim centreY As Integer = 125
    Dim apen As New Pen(Color.LightGray, 1)
    Dim bpen As New Pen(Color.Gray, 1)
    Dim cpen As New Pen(Color.Black, 1)
    Dim lpen As New Pen(Color.Black, 2)
    Dim rpen As New Pen(Color.Black, 4)
    Dim tpen As New Pen(Color.Transparent, 2)
    Dim radius As Double = 120
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

    Public Property value As Decimal
        Get
            value = m_value
        End Get
        Set(value As Decimal)
            If value >= minimum And value <= maximum Then
                m_value = value
                Me.Refresh()
            Else
                Exit Property
            End If
        End Set
    End Property
    Public Property minimum As Integer
        Get
            minimum = m_minimum
        End Get
        Set(minimum As Integer)
            If minimum > maximum Then
                MsgBox("Min can't be greater than Max")
                Exit Property
            End If
            m_minimum = minimum
            If value < minimum Then
                value = minimum
            End If
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
            Dim c = value
            value = c
            Me.Refresh()
        End Set
    End Property
    Public Property maximum As Integer
        Get
            maximum = m_maximum
        End Get
        Set(maximum As Integer)
            If maximum < minimum Then
                MsgBox("Max can't be smaller than Min")
                Exit Property
            End If
            m_maximum = maximum
            If value > maximum Then
                value = maximum
            End If
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
            Dim c = value
            value = c
            Me.Refresh()
        End Set
    End Property
    Private Sub GaugePaint(sender As Object, e As PaintEventArgs) Handles Me.Paint

        e.Graphics.DrawRectangle(lpen, 1, 1, 148, 148)

        Dim i As Integer = 0
        For num As Double = -Pi To -Pi / 2 + 0.001 Step Pi / 32
            x1 = Convert.ToInt32(radius * Math.Cos(num) + centreX)
            y1 = Convert.ToInt32(radius * Math.Sin(num) + centreY)
            If i Mod 2 = 0 Then
                x2 = Convert.ToInt32(7 / 8 * radius * Math.Cos(num) + centreX)
                y2 = Convert.ToInt32(7 / 8 * radius * Math.Sin(num) + centreY)
            Else
                x2 = Convert.ToInt32(15 / 16 * radius * Math.Cos(num) + centreX)
                y2 = Convert.ToInt32(15 / 16 * radius * Math.Sin(num) + centreY)
            End If

            e.Graphics.DrawLine(apen, x1, y1, x2, y2)
            addlabel(i)
            i += 1
        Next

        e.Graphics.DrawArc(bpen, centreX - 15, centreY - 15, 30, 30, 180, 90)
        e.Graphics.DrawLine(bpen, centreX, centreY + 1, centreX - 15, centreY + 1)
        e.Graphics.DrawLine(bpen, centreX + 1, centreY, centreX + 1, centreY - 15)


        redrawLine(e)

    End Sub
    Private Sub addlabel(ByVal i As Integer)
        Dim lblScale As New Label
        With lblScale
            .Location = New Point(x2 - 4, y2 - 4)
            .Size = New Size(18, 10)
            .Text = (maximum - minimum) / 16 * (i.ToString.PadLeft(2, "0"))
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
        End If
    End Sub
    Sub New()

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        minimum = 0
        maximum = 400
        value = 0
        units = "V"

    End Sub
    Public Sub redrawLine(e As PaintEventArgs)
        Dim Lend As Double = -Pi / 2 * ((maximum - value) / (maximum - minimum)) - Pi / 2


        xp1 = Convert.ToInt32(90 * Math.Cos(Lend) + centreX)
        yp1 = Convert.ToInt32(90 * Math.Sin(Lend) + centreY)
        xp2 = Convert.ToInt32(15 * Math.Cos(Lend) + centreX)
        yp2 = Convert.ToInt32(15 * Math.Sin(Lend) + centreY)

        e.Graphics.DrawLine(rpen, xp1, yp1, xp2, yp2)

    End Sub


End Class

Public Class MultiGenPointCalendarStrip
    Dim pbBoxes As PictureBox() = New PictureBox(287) {}
    Dim apen As New Pen(Color.LightGray, 1)
    Dim bpen As New Pen(Color.Gray, 1)
    Dim cpen As New Pen(Color.Black, 1)
    Dim lpen As New Pen(Color.Black, 10)
    Dim tpen As New Pen(Color.Transparent, 2)
    Private m_settings As Integer()

    Private Sub MePaint(sender As Object, e As PaintEventArgs) Handles Me.Paint

        e.Graphics.DrawLine(cpen, 0, 0, 0, 30)
        e.Graphics.DrawLine(cpen, 287, 0, 287, 30)
        For i = 12 To 287 Step 12
            e.Graphics.DrawLine(cpen, i, 14, i, 22)
        Next

        For i = 2 To 23 Step 2
            Dim lbl As New Label
            With lbl
                .Text = i.ToString.PadLeft(2, "0")
                .Location = New Point(12 * (i - 1) + 7, 2)
                .Visible = True
                .Size = New Size(18, 10)
                .Font = New Font("Segoe UI", 5, FontStyle.Regular)
                .Name = "lbl" & i.ToString.PadLeft(2, "0")
            End With
            Me.Controls.Add(lbl)
        Next
        e.Graphics.DrawLine(lpen, Settings(0), 25, Settings(1), 25)
        e.Graphics.DrawLine(lpen, Settings(2), 25, Settings(3), 25)
        e.Graphics.DrawLine(lpen, Settings(4), 25, Settings(5), 25)



    End Sub
    Public Sub New()
        InitializeComponent()
        Settings = {0, 0, 0, 0, 0, 0}
    End Sub
    Public Property Settings As Integer()
        Get
            Settings = m_settings
        End Get
        Set(Settings As Integer())
            If Settings.Count = 6 Then
                Array.Sort(Settings)
                m_settings = Settings
                Me.Refresh()
            End If
        End Set
    End Property



End Class

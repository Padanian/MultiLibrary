Public Class MultiPumpPanel
    Const Pi As Double = Math.PI
    Dim x1, y1, x2, y2, x3, y3 As Integer
    Dim xp1, yp1, xp2, yp2 As Int32
    Private m_lbltext As String = "Text"
    Private m_lblPumptext As String = "Text"
    Private m_semaphortext As String = "Text"
    Private m_selectedPositionOnOffSwitch As Integer
    Private m_selectedPositionPumpSwitch As Integer = 1
    Private m_positionsOnOffSwitch As Integer = 2
    Private m_positionsPumpSwitch As Integer = 3
    Private m_WarningThreshold As Integer = 80
    Private m_semaphorColor As Color = Color.Yellow
    Private m_isSemaphorVisible As Boolean
    Private m_isSemaphorBlinking As Boolean

    Dim centreX As Double = 32
    Dim centreY As Double = 44
    Dim apen As New Pen(Color.LightGray, 1)
    Dim lpen As New Pen(Color.Black, 2)
    Dim angleSwitchOnOff As Double = -3 / 4 * Pi
    Dim angleSwitchPump As Double = -1 / 2 * Pi
    Dim blinkingSemaphorTimer As New Timer
    Dim pbSemaphor As New PictureBox
    Dim lblSemaphorText As New Label
    Dim clickAreaOnOffSwitch As Rectangle = New Rectangle(0, 0, 64, 100)
    Dim clickAreaPumpSwitch As Rectangle = New Rectangle(101, 0, 64, 100)

    Private m_hourCounterPump1 As Integer
    Private m_hourCounterPump2 As Integer
    Private m_pump1Running As Boolean
    Private m_pump2Running As Boolean
    Private m_pump1Alarm As Boolean
    Private m_pump2Alarm As Boolean

    Sub New()

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        AddHandler blinkingSemaphorTimer.Tick, AddressOf blinkingSemaphor
        With pbSemaphor
            .Location = New Point(6, 142)
            .Size = New Size(52, 52)
            .Name = "pbSemaphor"
            .Visible = False
            .Image = My.Resources.led_amber_black
            .SizeMode = PictureBoxSizeMode.Zoom
        End With
        Me.Controls.Add(pbSemaphor)

        With lblSemaphorText
            .Size = New Size(58, 18)
            .Font = New Font("SegoeUI", 8.25, FontStyle.Regular)
            .Name = "lblSemaphorText"
            .Location = New Point(3, 116)
            .Text = m_semaphortext
            .Visible = False
            .TextAlign = ContentAlignment.MiddleCenter
        End With
        Me.Controls.Add(lblSemaphorText)



    End Sub
    Private Sub MultiPumpPanel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pbPump1LED.Image = My.Resources.led_off_black
        pbPump2LED.Image = My.Resources.led_off_black
        lbltext = "Switch"
        semaphortext = "Signals"
        isSemaphorVisible = True
        semaphorColor = Color.Black
        lblPumptext = "Mode"

        For Each ctl In Me.Controls
            If ctl.name <> pbSwitchOnOff.Name Then
                ctl.enabled = False
            End If
        Next
    End Sub
    Private Sub pbSwitchOnOff_click(sender As Object, e As EventArgs) Handles pbSwitchOnOff.Click
        m_selectedPositionOnOffSwitch += 1
        If m_selectedPositionOnOffSwitch > m_positionsOnOffSwitch - 1 Then
            m_selectedPositionOnOffSwitch = 0
            For Each ctl In Me.Controls
                If ctl.name <> pbSwitchOnOff.Name Then
                    ctl.enabled = False
                End If
            Next
            angleSwitchOnOff = -3 / 4 * Pi
            Me.Refresh()
            Exit Sub
        End If
        If m_positionsOnOffSwitch = 2 Then
            For Each ctl In Me.Controls
                If ctl.name <> pbSwitchOnOff.Name Then
                    ctl.enabled = True
                End If
            Next
            angleSwitchOnOff += Pi / 2
        End If



        Me.Refresh()
    End Sub
    Private Sub pbSwitchPump_click(sender As Object, e As EventArgs) Handles pbSwitchPump.Click

        m_selectedPositionPumpSwitch += 1
        If m_selectedPositionPumpSwitch > m_positionsPumpSwitch - 1 Then
            m_selectedPositionPumpSwitch = 0
            angleSwitchPump = -3 / 4 * Pi
            Me.Refresh()
            Exit Sub
        End If
        If m_positionsPumpSwitch = 2 Then
            angleSwitchPump += Pi / 2
        Else
            angleSwitchPump += Pi / 4
        End If

        Me.Refresh()
    End Sub
    Public Property isSemaphorVisible As Boolean
        Get
            isSemaphorVisible = m_isSemaphorVisible
        End Get
        Set(isSemaphorVisible As Boolean)
            m_isSemaphorVisible = isSemaphorVisible
            If isSemaphorVisible Then
                Me.Height = 200
                pbSemaphor.Visible = True
            Else
                Me.Height = 100
                pbSemaphor.Visible = False
            End If


        End Set
    End Property
    Public Property isSemaphorBlinking As Boolean
        Get
            isSemaphorBlinking = m_isSemaphorBlinking
        End Get
        Set(isSemaphorBlinking As Boolean)
            m_isSemaphorBlinking = isSemaphorBlinking
            Me.Refresh()
        End Set
    End Property
    Public Property semaphorColor As Color
        Get
            semaphorColor = m_semaphorColor
        End Get
        Set(semaphorColor As Color)
            Select Case semaphorColor
                Case Color.Yellow
                    pbSemaphor.Image = My.Resources.led_amber_black
                Case Color.Blue
                    pbSemaphor.Image = My.Resources.led_blue_black
                Case Color.Green
                    pbSemaphor.Image = My.Resources.led_green_black
                Case Color.Red
                    pbSemaphor.Image = My.Resources.led_red_black
                Case Color.Black
                    pbSemaphor.Image = My.Resources.led_off_black
                Case Else
                    pbSemaphor.Image = My.Resources.led_off_black
                    semaphorColor = Color.Yellow
                    m_semaphorColor = Color.Yellow
                    Exit Property
            End Select
            m_semaphorColor = semaphorColor

        End Set
    End Property
    Public ReadOnly Property positions As Integer
        Get
            positions = m_positionsOnOffSwitch
        End Get
    End Property
    Public Property lblPumptext As String
        Get
            lblPumptext = m_lblPumptext
        End Get
        Set(lblPumptext As String)
            If lblPumptext.Length < 10 Then
                m_lblPumptext = lblPumptext
                lblPumpTag.Text = lblPumptext
            End If
            Me.Refresh()
        End Set
    End Property
    Public Property hourCounterPump1 As Integer
        Get
            hourCounterPump1 = m_hourCounterPump1
        End Get
        Set(hourCounterPump1 As Integer)
            If hourCounterPump1 >= 0 And hourCounterPump1 < 999999 Then
                m_hourCounterPump1 = hourCounterPump1
                lblCounterPump1.Text = hourCounterPump1.ToString.PadLeft(6, "0")
            End If
        End Set
    End Property
    Public Property hourCounterPump2 As Integer
        Get
            hourCounterPump2 = m_hourCounterPump2
        End Get
        Set(hourCounterPump2 As Integer)
            If hourCounterPump2 >= 0 And hourCounterPump2 < 999999 Then
                m_hourCounterPump2 = hourCounterPump2
                lblCounterPump2.Text = hourCounterPump2.ToString.PadLeft(6, "0")
            End If
        End Set
    End Property
    Public Property pump1Running As Boolean
        Get
            pump1Running = m_pump1Running
        End Get
        Set(pump1Running As Boolean)
            If Not pump1Alarm Then
                m_pump1Running = pump1Running
                pbPump1LED.Image = My.Resources.led_green_black
            End If
            If Not pump1Running And Not pump1Alarm Then
                pbPump1LED.Image = My.Resources.led_off_black
            End If
        End Set
    End Property
    Public Property pump2Running As Boolean
        Get
            pump2Running = m_pump2Running
        End Get
        Set(pump2Running As Boolean)
            If Not pump2Alarm Then
                m_pump2Running = pump2Running
                pbPump2LED.Image = My.Resources.led_green_black
            End If
            If Not pump2Running And Not pump2Alarm Then
                pbPump2LED.Image = My.Resources.led_off_black
            End If
        End Set
    End Property
    Public Property pump1Alarm As Boolean
        Get
            pump1Alarm = m_pump1Alarm
        End Get
        Set(pump1Alarm As Boolean)
            If Not pump1Running Then
                m_pump1Alarm = pump1Alarm
                pbPump1LED.Image = My.Resources.led_red_black
            End If
            If Not pump1Running And Not pump1Alarm Then
                pbPump1LED.Image = My.Resources.led_off_black
            End If
        End Set
    End Property
    Public Property pump2Alarm As Boolean
        Get
            pump2Alarm = m_pump2Alarm
        End Get
        Set(pump2Alarm As Boolean)
            If Not pump2Running Then
                m_pump2Alarm = pump2Alarm
                pbPump2LED.Image = My.Resources.led_red_black
            End If
            If Not pump2Running And Not pump2Alarm Then
                pbPump2LED.Image = My.Resources.led_off_black
            End If
        End Set
    End Property
    Public Property lbltext As String
        Get
            lbltext = m_lbltext
        End Get
        Set(lbltext As String)
            If lbltext.Length < 10 Then
                m_lbltext = lbltext
                lblSwitchTag.Text = lbltext
            End If
            Me.Refresh()
        End Set
    End Property
    Public Property semaphortext As String
        Get
            semaphortext = m_semaphortext
        End Get
        Set(semaphortext As String)
            If semaphortext.Length < 10 Then
                m_semaphortext = semaphortext
                lblSemaphorText.Text = semaphortext
            End If
            Me.Refresh()
        End Set
    End Property
    Public ReadOnly Property selectedPositionOnOffSwitch As Integer
        Get
            selectedPositionOnOffSwitch = m_selectedPositionOnOffSwitch
        End Get
    End Property
    Public ReadOnly Property selectedPositionPumpSwitch As Integer
        Get
            selectedPositionPumpSwitch = m_selectedPositionPumpSwitch
        End Get
    End Property
    Private Sub GaugePaint(sender As Object, e As PaintEventArgs) Handles Me.Paint

#Region "Switch ON OFF"
        drawswitch(1, angleSwitchOnOff)

        Dim m_step As Double
        If m_positionsOnOffSwitch = 2 Then
            m_step = Pi / 2
        Else
            m_step = Pi / 4
        End If


        e.Graphics.DrawRectangle(apen, 1, 78, 62, 21)

        lblSwitchTag.Text = lbltext


        If isSemaphorVisible And Not isSemaphorBlinking Then
            With blinkingSemaphorTimer
                .Enabled = False
                .Stop()
            End With
            pbSemaphor.Visible = True
            e.Graphics.DrawRectangle(apen, 1, 115, 62, 21)
            lblSemaphorText.Visible = True
            Select Case m_semaphorColor
                Case Color.Yellow
                    pbSemaphor.Image = My.Resources.led_amber_black
                Case Color.Blue
                    pbSemaphor.Image = My.Resources.led_blue_black
                Case Color.Green
                    pbSemaphor.Image = My.Resources.led_green_black
                Case Color.Red
                    pbSemaphor.Image = My.Resources.led_red_black
            End Select

        ElseIf isSemaphorVisible And isSemaphorBlinking Then
            If blinkingSemaphorTimer.Enabled = False Then
                With blinkingSemaphorTimer
                    .Interval = 1000
                    .Enabled = True
                    .Start()
                End With
            End If
            e.Graphics.DrawRectangle(apen, 1, 115, 62, 21)
            lblSemaphorText.Visible = True
        ElseIf Not isSemaphorVisible Then
            With blinkingSemaphorTimer
                .Enabled = False
                .Stop()
            End With
            pbSemaphor.Visible = False
            lblSemaphorText.Visible = False
        End If
#End Region

#Region "Switch 1 auto 2"

        Dim offset As Integer = 86
        drawswitch(2, angleSwitchPump)

        m_step = Pi / 4

        e.Graphics.DrawRectangle(apen, 1 + offset, 78, 62, 21)

        lblPumpTag.Text = lblPumptext


#End Region

    End Sub
    Private Sub blinkingSemaphor()

        pbSemaphor.Visible = True
        If m_semaphorColor <> Color.Black Then
            If DateTime.Now.Second Mod 2 = 0 Then
                Select Case m_semaphorColor
                    Case Color.Yellow
                        pbSemaphor.Image = My.Resources.led_amber_black
                    Case Color.Blue
                        pbSemaphor.Image = My.Resources.led_blue_black
                    Case Color.Green
                        pbSemaphor.Image = My.Resources.led_green_black
                    Case Color.Red
                        pbSemaphor.Image = My.Resources.led_red_black
                End Select
            Else
                pbSemaphor.Image = My.Resources.led_off_black
            End If
        End If

    End Sub
    Public Sub drawswitch(e, angle)

        If e = 2 Then
            If angle = -3 / 4 * Pi Then
                pbSwitchPump.Image = My.Resources.PanelSwitchOnPump1
            ElseIf angle = -1 / 2 * Pi Then
                pbSwitchPump.Image = My.Resources.PanelSwitchOnPumpAut
            ElseIf angle = -1 / 4 * Pi Then
                pbSwitchPump.Image = My.Resources.PanelSwitchOnPump2
            End If
        ElseIf e = 1 Then
            If angle = -3 / 4 * Pi Then
                pbSwitchOnOff.Image = My.Resources.PanelSwitchOff_2pos
            ElseIf angle = -1 / 4 * Pi Then
                pbSwitchOnOff.Image = My.Resources.PanelSwitchOn_2pos
            End If
        End If


    End Sub
End Class


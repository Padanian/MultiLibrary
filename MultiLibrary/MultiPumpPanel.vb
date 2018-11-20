Imports System.IO

Public Class MultiPumpPanel
    Const Pi As Double = Math.PI
    Private m_lbltext As String = "Text"
    Private m_lblPumptext As String = "Text"
    Private m_semaphortext As String = "Text"
    Private m_selectedPositionOnOffSwitch As Integer
    Private m_selectedPositionPumpSwitch As Integer = 1
    Private m_positionsOnOffSwitch As Integer = 2
    Private m_positionsPumpSwitch As Integer = 3
    Private m_WarningThreshold As Integer = 80
    Private m_semaphorColor As Color = Color.Yellow
    Private m_SemaphorVisible As Boolean
    Private m_SemaphorBlinking As Boolean

    Private mySettings As New Settings

    Dim apen As New Pen(Color.LightGray, 1)
    Dim angleSwitchOnOff As Double = -3 / 4 * Pi
    Dim angleSwitchPump As Double = -1 / 2 * Pi
    Dim blinkingSemaphorTimer As New Timer
    Dim pumpRotationTimer As New Timer
    Dim pbSemaphor As New PictureBox
    Dim lblSemaphorText As New Label
    Dim clickAreaOnOffSwitch As Rectangle = New Rectangle(0, 0, 64, 100)
    Dim clickAreaPumpSwitch As Rectangle = New Rectangle(101, 0, 64, 100)

    Private m_hourCounterPump1 As Integer
    Private m_hourCounterPump2 As Integer
    Private m_pump1Running As Boolean
    Private m_pump2Running As Boolean
    Private m_nupLeadLagtime As Integer = 168
    Private m_pump1Alarm As Boolean
    Private m_pump2Alarm As Boolean
    Private m_Pump1StartedDateTime As DateTime
    Private m_Pump2StartedDateTime As DateTime
    Private m_nupRitardi As Integer
    Private m_chkTestRotation As Boolean

    Private hourUpdate As Boolean = True

    Private Event SwitchedON()
    Private Event SwitchedOFF()
    Private Event richiestaPartenzaPompa1()
    Private Event richiestoSpegnimentoPompa1()
    Private Event richiestaPartenzaPompa2()
    Private Event richiestoSpegnimentoPompa2()
    Private Event allarmePompe()






    Sub New()


        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        Dim bf As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
        Dim filename As String = Application.LocalUserAppDataPath & "\" & Me.Name & ".mpp"

        If File.Exists(filename) Then

            Dim fStream As New FileStream(filename, FileMode.OpenOrCreate)
            mySettings = bf.Deserialize(fStream)
            fStream.Close()

            m_Pump1StartedDateTime = mySettings.m_Pump1StartedDateTime
            m_Pump2StartedDateTime = mySettings.m_Pump2StartedDateTime
            m_nupLeadLagtime = mySettings.m_nupLeadLagtime
            m_hourCounterPump1 = mySettings.m_hourCounterPump1
            m_hourCounterPump2 = mySettings.m_hourCounterPump2
            m_nupRitardi = mySettings.m_nupRitardi
            m_chkTestRotation = mySettings.m_chkTestRotation
            m_selectedPositionOnOffSwitch = mySettings.m_selectedPositionOnOffSwitch
            m_selectedPositionPumpSwitch = mySettings.m_selectedPositionPumpSwitch


        Else
            m_Pump1StartedDateTime = #01/01/0001 00:01#
            m_Pump2StartedDateTime = #01/01/0001 00:01#
            m_nupLeadLagtime = 168
            m_hourCounterPump1 = 0
            m_hourCounterPump2 = 0
            m_nupRitardi = 0
            m_chkTestRotation = False
            m_selectedPositionOnOffSwitch = 0
            m_selectedPositionPumpSwitch = 1

            mySettings.m_Pump1StartedDateTime = m_Pump1StartedDateTime
            mySettings.m_Pump2StartedDateTime = m_Pump2StartedDateTime
            mySettings.m_nupLeadLagtime = m_nupLeadLagtime
            mySettings.m_hourCounterPump1 = m_hourCounterPump1
            mySettings.m_hourCounterPump2 = m_hourCounterPump2
            mySettings.m_nupRitardi = m_nupRitardi
            mySettings.m_chkTestRotation = m_chkTestRotation
            mySettings.m_selectedPositionOnOffSwitch = m_selectedPositionOnOffSwitch
            mySettings.m_selectedPositionPumpSwitch = m_selectedPositionPumpSwitch


            Dim fStream As New FileStream(filename, FileMode.OpenOrCreate)
            bf.Serialize(fStream, mySettings) ' write to file
            fStream.Close()
        End If


        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        AddHandler blinkingSemaphorTimer.Tick, AddressOf blinkingSemaphor
        AddHandler pumpRotationTimer.Tick, AddressOf pumpRotation

        With pumpRotationTimer
            .Interval = 86400000
        End With

        With pbSemaphor
            .Location = New Point(6, 142)
            .Size = New Size(52, 52)
            .Name = "pbSemaphor"
            .Visible = False
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

        AddHandler Me.SwitchedON, AddressOf pbSwitchOnOff_SwitchedON
        AddHandler Me.SwitchedOFF, AddressOf pbSwitchOnOff_SwitchedOFF
        AddHandler Me.allarmePompe, AddressOf gestioneSemaphor
    End Sub
    Private Sub MultiPumpPanel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pbPump1LED.Image = My.Resources.led_off_black
        pbPump2LED.Image = My.Resources.led_off_black
        lbltext = "Switch"
        lblPumpText = "Mode"
        semaphortext = "Signals"
        semaphorColor = Color.Black
        SemaphorVisible = True
        SemaphorBlinking = False


        m_selectedPositionPumpSwitch = selectedPositionPumpSwitch
        If m_selectedPositionPumpSwitch = 0 Then
            angleSwitchPump = -3 / 4 * Pi
        ElseIf m_selectedPositionPumpSwitch = 1 Then
            angleSwitchPump = -1 / 2 * Pi
        Else
            angleSwitchPump = -1 / 4 * Pi
        End If

        m_selectedPositionOnOffSwitch = selectedPositionOnOffSwitch
        If m_selectedPositionOnOffSwitch = 0 Then
            angleSwitchOnOff = -3 / 4 * Pi
            RaiseEvent SwitchedOFF()
        Else
            angleSwitchOnOff = -1 / 4 * Pi
            RaiseEvent SwitchedON()
        End If

        hourCounterPump1 = m_hourCounterPump1
        hourCounterPump2 = m_hourCounterPump2
        nupLeadLagTime.Value = m_nupLeadLagtime
        nupRitardi.Value = m_nupRitardi
        chkTestRotation.Checked = m_chkTestRotation

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
            RaiseEvent SwitchedOFF()
            Me.Refresh()
            mySettingsSave()
            Exit Sub
        End If
        If m_positionsOnOffSwitch = 2 Then
            For Each ctl In Me.Controls
                ctl.enabled = True
            Next
            angleSwitchOnOff += Pi / 2
            RaiseEvent SwitchedON()
            Me.Refresh()
            mySettingsSave()
        End If

    End Sub
    Private Sub pbSwitchPump_click(sender As Object, e As EventArgs) Handles pbSwitchPump.Click

        m_selectedPositionPumpSwitch += 1
        If m_selectedPositionPumpSwitch > m_positionsPumpSwitch - 1 Then
            m_selectedPositionPumpSwitch = 0
            angleSwitchPump = -3 / 4 * Pi
            RaiseEvent SwitchedON()
            Me.Refresh()
            mySettingsSave()
            Exit Sub
        End If
        If m_positionsPumpSwitch = 2 Then
            angleSwitchPump += Pi / 2
            RaiseEvent SwitchedON()
        Else
            angleSwitchPump += Pi / 4
            RaiseEvent SwitchedON()
            Me.Refresh()
            mySettingsSave()

        End If
    End Sub
    Public Property SemaphorVisible As Boolean
        Get
            SemaphorVisible = m_SemaphorVisible
        End Get
        Set(SemaphorVisible As Boolean)
            m_SemaphorVisible = SemaphorVisible
            If SemaphorVisible Then
                Me.Height = 200
                pbSemaphor.Visible = True
            Else
                Me.Height = 100
                pbSemaphor.Visible = False
            End If


        End Set
    End Property
    Public Property SemaphorBlinking As Boolean
        Get
            SemaphorBlinking = m_SemaphorBlinking
        End Get
        Set(SemaphorBlinking As Boolean)
            m_SemaphorBlinking = SemaphorBlinking
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
    Private Sub ritardoP1Start()
        Dim start As DateTime = DateTime.Now
        While DateDiff(DateInterval.Second, start, DateTime.Now) < nupRitardi.Value
            Application.DoEvents()
        End While
        If m_pump1Alarm Then
            pbPump1LED.Image = My.Resources.led_red_black
        Else
            pbPump1LED.Image = My.Resources.led_green_black
        End If
    End Sub
    Private Sub ritardoP1Stop()
        Dim start As DateTime = DateTime.Now
        While DateDiff(DateInterval.Second, start, DateTime.Now) < nupRitardi.Value
            Application.DoEvents()
        End While
        If m_pump1Alarm Then
            pbPump1LED.Image = My.Resources.led_red_black
        Else
            pbPump1LED.Image = My.Resources.led_off_black
        End If
    End Sub
    Private Sub ritardoP2Start()
        Dim start As DateTime = DateTime.Now
        While DateDiff(DateInterval.Second, start, DateTime.Now) < nupRitardi.Value
            Application.DoEvents()
        End While
        If m_pump2Alarm Then
            pbPump2LED.Image = My.Resources.led_red_black
        Else
            pbPump2LED.Image = My.Resources.led_green_black
        End If
    End Sub
    Private Sub ritardoP2Stop()
        Dim start As DateTime = DateTime.Now
        While DateDiff(DateInterval.Second, start, DateTime.Now) < nupRitardi.Value
            Application.DoEvents()
        End While
        If m_pump2Alarm Then
            pbPump2LED.Image = My.Resources.led_red_black
        Else
            pbPump2LED.Image = My.Resources.led_off_black
        End If
    End Sub
    Public ReadOnly Property isPump1Running As Boolean
        Get
            Return m_pump1Running
        End Get
    End Property
    Public ReadOnly Property isPump2Running As Boolean
        Get
            Return m_pump2Running
        End Get
    End Property
    Private Property pump1Running As Boolean
        Get
            pump1Running = m_pump1Running
        End Get
        Set(pump1Running As Boolean)
            hourUpdate = False
            If Not pump1Alarm Then

                Dim trdDatiStart As Task = New Task(AddressOf ritardoP1Start)
                Dim trdDatiStop As Task = New Task(AddressOf ritardoP1Stop)

                If m_pump1Running = False And pump1Running = True Then
                    pbPump1LED.Image = My.Resources.led_blue_black
                    trdDatiStart.Start()
                ElseIf m_pump1Running = True And pump1Running = False Then
                    pbPump1LED.Image = My.Resources.led_blue_black
                    trdDatiStop.Start()
                End If

                m_pump1Running = pump1Running
            End If
            hourUpdate = True
        End Set
    End Property
    Private Property pump2Running As Boolean
        Get
            pump2Running = m_pump2Running
        End Get
        Set(pump2Running As Boolean)
            hourUpdate = False
            If Not pump2Alarm Then

                Dim trdDatiStart As Task = New Task(AddressOf ritardoP2Start)
                Dim trdDatiStop As Task = New Task(AddressOf ritardoP2Stop)


                If m_pump2Running = False And pump2Running = True Then
                    pbPump2LED.Image = My.Resources.led_blue_black
                    trdDatiStart.Start()
                ElseIf m_pump2Running = True And pump2Running = False Then
                    pbPump2LED.Image = My.Resources.led_blue_black
                    trdDatiStop.Start()
                End If

                m_pump2Running = pump2Running
            End If
            hourUpdate = True
        End Set
    End Property
    Public Property pump1Alarm As Boolean
        Get
            pump1Alarm = m_pump1Alarm
        End Get
        Set(pump1Alarm As Boolean)
            m_pump1Alarm = pump1Alarm
            If m_pump1Alarm Then
                m_pump1Running = False
                pbPump1LED.Image = My.Resources.led_red_black
                RaiseEvent allarmePompe()
            ElseIf Not m_pump1Alarm And m_pump1Running Then
                pbPump1LED.Image = My.Resources.led_green_black
                RaiseEvent allarmePompe()
            ElseIf Not m_pump1Alarm And Not m_pump1Running Then
                pbPump1LED.Image = My.Resources.led_off_black
                RaiseEvent allarmePompe()
            End If
            hourUpdate = False
            pumpRotation()
        End Set
    End Property
    Public Property pump2Alarm As Boolean
        Get
            pump2Alarm = m_pump2Alarm
        End Get
        Set(pump2Alarm As Boolean)
            m_pump2Alarm = pump2Alarm
            If m_pump2Alarm Then
                m_pump2Running = False
                pbPump2LED.Image = My.Resources.led_red_black
                RaiseEvent allarmePompe()
            ElseIf Not m_pump2Alarm And m_pump2Running Then
                pbPump2LED.Image = My.Resources.led_green_black
                RaiseEvent allarmePompe()
            ElseIf Not m_pump2Alarm And Not m_pump2Running Then
                pbPump2LED.Image = My.Resources.led_off_black
                RaiseEvent allarmePompe()
            End If
            hourUpdate = False
            pumpRotation()
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
    Public Property lblPumpText As String
        Get
            lblPumpText = m_lblPumptext
        End Get
        Set(lblPumpText As String)
            If lblPumpText.Length < 10 Then
                m_lblPumptext = lblPumpText
                lblPumpTag.Text = lblPumpText
            End If
            Me.Refresh()
        End Set
    End Property
    Private Sub gestioneSemaphor()
        If m_pump1Alarm Xor m_pump2Alarm Then
            semaphorColor = Color.Yellow
            SemaphorBlinking = True
        End If
        If m_pump1Alarm And m_pump2Alarm Then
            semaphorColor = Color.Red
            SemaphorBlinking = True
        End If
        If Not m_pump1Alarm And Not m_pump2Alarm Then
            semaphorColor = Color.Green
            SemaphorBlinking = False
        End If
    End Sub
    Private Sub chkTestRotation_CheckedChanged(sender As Object, e As EventArgs) Handles chkTestRotation.CheckedChanged

        pumpRotationTimer.Enabled = False
        pumpRotationTimer.Stop()

        If chkTestRotation.Checked Then
            pumpRotationTimer.Interval = 1000
        Else
            pumpRotationTimer.Interval = 86400000
        End If

        pumpRotationTimer.Enabled = True
        pumpRotationTimer.Start()

        mySettingsSave()

    End Sub
    Private Sub nupRitardi_ValueChanged(sender As Object, e As EventArgs) Handles nupRitardi.ValueChanged
        m_nupRitardi = nupRitardi.Value
        mySettingsSave()
    End Sub
    Private Sub nupLeadLagTime_ValueChanged(sender As Object, e As EventArgs) Handles nupLeadLagTime.ValueChanged
        m_nupLeadLagtime = nupLeadLagTime.Value
        mySettingsSave()
    End Sub

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


        If SemaphorVisible And Not SemaphorBlinking Then
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

        ElseIf SemaphorVisible And SemaphorBlinking Then
            If blinkingSemaphorTimer.Enabled = False Then
                With blinkingSemaphorTimer
                    .Interval = 1000
                    .Enabled = True
                    .Start()
                End With
            End If
            e.Graphics.DrawRectangle(apen, 1, 115, 62, 21)
            lblSemaphorText.Visible = True
        ElseIf Not SemaphorVisible Then
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

        lblPumpTag.Text = lblPumpText


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
    Private Sub drawswitch(e, angle)

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

    Private Sub pbSwitchOnOff_SwitchedON() Handles Me.SwitchedON
        If selectedPositionPumpSwitch = 0 Then
            'Pompa 1 in marcia override
            If Not pump1Alarm Then
                'Pompa 1 in marcia, determina l'ora di partenza e salvala
                pump1Running = True
                m_Pump1StartedDateTime = DateTime.Now
                mySettingsSave()

                'Pompa 2 a riposo, calcola quanto ha marciato e aggiorna il contatore
                pump2Running = False
                hourCounterPump2 += DateDiff(DateInterval.Hour, DateTime.Now, m_Pump2StartedDateTime)
            End If
        ElseIf selectedPositionPumpSwitch = 2 Then
            If Not pump2Alarm Then
                'Pompa 2 in marcia, determina l'ora di partenza e salvala
                pump2Running = True
                m_Pump2StartedDateTime = DateTime.Now
                mySettingsSave()

                'Pompa 1 a riposo, calcola quanto ha marciato e aggiorna il contatore
                pump1Running = False
                hourCounterPump1 += DateDiff(DateInterval.Hour, DateTime.Now, m_Pump1StartedDateTime)
            End If
        ElseIf selectedPositionPumpSwitch = 1 Then
            If Not pump1Alarm And Not pump2Alarm Then

                pumpRotationTimer.Start()

                If hourCounterPump1 > hourCounterPump2 Then
                    'Pompa 2 in marcia, determina l'ora di partenza e salvala
                    pump2Running = True
                    m_Pump2StartedDateTime = DateTime.Now
                    mySettingsSave()

                    'Pompa 1 a riposo, calcola quanto ha marciato e aggiorna il contatore
                    pump1Running = False
                    hourCounterPump1 += DateDiff(DateInterval.Hour, DateTime.Now, m_Pump1StartedDateTime)
                Else
                    'Pompa 1 in marcia, determina l'ora di partenza e salvala
                    pump1Running = True
                    m_Pump1StartedDateTime = DateTime.Now
                    mySettingsSave()

                    'Pompa 2 a riposo, calcola quanto ha marciato e aggiorna il contatore
                    pump2Running = False
                    hourCounterPump2 += DateDiff(DateInterval.Hour, DateTime.Now, m_Pump2StartedDateTime)
                End If
            ElseIf pump1Alarm And Not pump2Alarm Then
                'Pompa 2 in marcia, determina l'ora di partenza e salvala
                pump2Running = True
                m_Pump2StartedDateTime = DateTime.Now
                mySettingsSave()

                'Pompa 1 a riposo, calcola quanto ha marciato e aggiorna il contatore
                pump1Running = False
                hourCounterPump1 += DateDiff(DateInterval.Hour, DateTime.Now, m_Pump1StartedDateTime)
            ElseIf pump2Alarm And Not pump1Alarm Then
                'Pompa 1 in marcia, determina l'ora di partenza e salvala
                pump1Running = True
                m_Pump1StartedDateTime = DateTime.Now
                mySettingsSave()

                'Pompa 2 a riposo, calcola quanto ha marciato e aggiorna il contatore
                pump2Running = False
                hourCounterPump2 += DateDiff(DateInterval.Hour, DateTime.Now, m_Pump2StartedDateTime)
            ElseIf pump1Alarm And pump2Alarm Then
                pump1Running = False
                pump2Running = False
            End If
        End If

        gestioneSemaphor()

    End Sub
    Private Sub pbSwitchOnOff_SwitchedOFF() Handles Me.SwitchedOFF
        pump1Running = False
        pump2Running = False
        hourCounterPump1 += DateTime.Now.Hour - m_Pump1StartedDateTime.Hour
        hourCounterPump2 += DateTime.Now.Hour - m_Pump2StartedDateTime.Hour
        semaphorColor = Color.Black
        SemaphorBlinking = False

    End Sub
    Private Sub pumpRotation()

        If hourUpdate Then
            If pump1Running And Not pump1Alarm Then
                hourCounterPump1 += 1
            ElseIf pump2Running And Not pump2Alarm Then
                hourCounterPump2 += 1
            End If
        End If

        hourUpdate = True

        If pump1Alarm And Not pump2Alarm And (m_selectedPositionPumpSwitch = 2 Or m_selectedPositionPumpSwitch = 1) Then
            'Pompa 2 in marcia, determina l'ora di partenza e salvala
            pump2Running = True
            m_Pump2StartedDateTime = DateTime.Now
            mySettingsSave()

            pump1Running = False
            Exit Sub
        End If

        If pump2Alarm And Not pump1Alarm And (m_selectedPositionPumpSwitch = 0 Or m_selectedPositionPumpSwitch = 1) Then
            'Pompa 1 in marcia, determina l'ora di partenza e salvala
            pump1Running = True
            m_Pump1StartedDateTime = DateTime.Now
            mySettingsSave()

            pump2Running = False
            Exit Sub
        End If

        If (pump2Alarm And pump1Alarm) Or
            (pump1Alarm And m_selectedPositionPumpSwitch = 0) Or
            (pump2Alarm And m_selectedPositionPumpSwitch = 2) Then

            'Pompa 1 a riposo
            pump1Running = False

            'Pompa 2 a riposo
            pump2Running = False

            Exit Sub
        End If


        If hourCounterPump1 - hourCounterPump2 > nupLeadLagTime.Value Then
            If Not pump2Alarm And m_selectedPositionPumpSwitch = 1 Then
                'Pompa 2 in marcia, determina l'ora di partenza e salvala
                pump2Running = True
                m_Pump2StartedDateTime = DateTime.Now
                mySettingsSave()

                'Pompa 1 a riposo, calcola quanto ha marciato e aggiorna il contatore
                pump1Running = False
                hourCounterPump1 += DateDiff(DateInterval.Hour, DateTime.Now, m_Pump1StartedDateTime)
            End If
        ElseIf hourCounterPump2 - hourCounterPump1 > nupLeadLagTime.Value Then
            If Not pump1Alarm And m_selectedPositionPumpSwitch = 1 Then
                'Pompa 1 in marcia, determina l'ora di partenza e salvala
                pump1Running = True
                m_Pump1StartedDateTime = DateTime.Now
                mySettingsSave()

                'Pompa 2 a riposo, calcola quanto ha marciato e aggiorna il contatore
                pump2Running = False
                hourCounterPump2 += DateDiff(DateInterval.Hour, DateTime.Now, m_Pump2StartedDateTime)
            End If
        End If

        mySettingsSave()

    End Sub
    Private Sub mySettingsSave()

        mySettings.m_Pump1StartedDateTime = m_Pump1StartedDateTime
        mySettings.m_Pump2StartedDateTime = m_Pump2StartedDateTime
        mySettings.m_nupLeadLagtime = m_nupLeadLagtime
        mySettings.m_hourCounterPump1 = m_hourCounterPump1
        mySettings.m_hourCounterPump2 = m_hourCounterPump2
        mySettings.m_nupRitardi = m_nupRitardi
        mySettings.m_chkTestRotation = m_chkTestRotation
        mySettings.m_selectedPositionOnOffSwitch = m_selectedPositionOnOffSwitch
        mySettings.m_selectedPositionPumpSwitch = m_selectedPositionPumpSwitch


        Dim bf As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter

        Dim filename As String = Application.LocalUserAppDataPath & "\" & Me.Name & ".mpp"
        Dim fStream As New FileStream(filename, FileMode.OpenOrCreate)
        bf.Serialize(fStream, mySettings) ' write to file
        fStream.Close()

    End Sub


End Class
<Serializable>
Class Settings
    Property m_Pump1StartedDateTime As DateTime
    Property m_Pump2StartedDateTime As DateTime
    Property m_nupLeadLagtime As Integer
    Property m_hourCounterPump1 As Integer
    Property m_hourCounterPump2 As Integer
    Property m_nupRitardi As Integer
    Property m_chkTestRotation As Boolean
    Property m_selectedPositionOnOffSwitch As Integer
    Property m_selectedPositionPumpSwitch As Integer
End Class
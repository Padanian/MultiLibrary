Public Class MultiGenTemperatureIconRight
    Private m_Tname As String
    Private m_TempValue As Decimal
    Private m_LEDcolor As Color
    Public Property Tname As String
        Get
            Tname = m_Tname
        End Get
        Set(Tname As String)
            If Tname.Length = 5 Then
                lblName.Text = Tname
                m_Tname = Tname
            End If
            lblName.Invalidate()
        End Set
    End Property
    Public Property TempValue As Decimal
        Get
            TempValue = m_TempValue
        End Get
        Set(TempValue As Decimal)
            lblTemp.Text = Format(TempValue, "##0.0#°C")
            m_TempValue = TempValue
            lblTemp.Invalidate()
        End Set
    End Property
    Public Property LEDcolor As Color
        Get
            LEDcolor = m_LEDcolor
        End Get
        Set(LEDcolor As Color)
            If LEDcolor = Color.Red Then
                pbLED.Image = My.Resources.ledred
            End If
            If LEDcolor = Color.Green Then
                pbLED.Image = My.Resources.ledgreen
            End If
            If LEDcolor = Color.Gray Then
                pbLED.Image = My.Resources.ledoff
            End If
            pbLED.Invalidate()
            m_LEDcolor = LEDcolor
        End Set
    End Property
    Public Sub New()

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Tname = "Temp1"
        LEDcolor = Color.Gray
        TempValue = 99.9
    End Sub
End Class

Imports System.Configuration
Imports System.IO
Imports MultiLibrary
Imports EasyModbus
Imports System.IO.Ports

Public Class Form1

    Dim sbMst As New ModbusClient()  'dichiarazione canale modbus master
    Const timeoutModbus = 250 'timeout modbus
    Dim MultiAmmVoltmeter1 As New MultiAmmVoltmeter
    Dim MultiAmmVoltmeter2 As New MultiAmmVoltmeter




    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            If sbMst.Connected Then
                sbMst.Disconnect()
            End If

            Dim port As Integer = 10
            sbMst.Baudrate = 38400

            sbMst.NumberOfRetries = 2
            sbMst.UnitIdentifier = 1
            sbMst.SerialPort = "COM10"

            sbMst.Parity = Parity.None
            sbMst.StopBits = 1
            sbMst.ConnectionTimeout = 200

            sbMst.Connect()
            Timer1.Enabled = True

        Catch ex As Exception

            If sbMst.Connected() Then
                sbMst.Disconnect()
                Timer1.Enabled = False
            End If

        End Try

        Me.Controls.Add(MultiAmmVoltmeter1)
        MultiAmmVoltmeter1.Location = New Point(12, 23)

        Me.Controls.Add(MultiAmmVoltmeter2)
        MultiAmmVoltmeter2.Location = New Point(168, 23)
        MultiAmmVoltmeter2.units = "H"

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            MultiAmmVoltmeter1.minimum = 216
            MultiAmmVoltmeter1.maximum = 232
            MultiAmmVoltmeter2.minimum = 49
            MultiAmmVoltmeter2.maximum = 51


            Dim reading As Integer() = sbMst.ReadInputRegisters(270, 2)
            Dim temp As Decimal = EasyModbus.ModbusClient.ConvertRegistersToFloat({reading(1), reading(0)})
            MultiAmmVoltmeter1.value = temp
            reading = sbMst.ReadInputRegisters(218, 2)
            temp = EasyModbus.ModbusClient.ConvertRegistersToFloat({reading(1), reading(0)})
            MultiAmmVoltmeter2.value = temp
            MultiAmmVoltmeter1.Refresh()
        Catch ex As Exception


        End Try

    End Sub
End Class

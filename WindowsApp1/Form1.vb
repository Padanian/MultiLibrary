Imports MultiLibrary
Imports EasyModbus
Imports System.IO.Ports

Public Class Form1

    Dim sbMst As New ModbusClient()  'dichiarazione canale modbus master
    Dim MultiAmmVoltmeter1 As New MultiAmmVoltmeter
    Dim MultiAmmVoltmeter2 As New MultiAmmVoltmeter
    Dim MultiAmmVoltmeter3 As New MultiAmmVoltmeter




    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MultiAmmVoltmeter1.minimum = 224
        MultiAmmVoltmeter1.maximum = 236
        MultiAmmVoltmeter2.minimum = 49.95
        MultiAmmVoltmeter2.maximum = 50.05
        MultiAmmVoltmeter3.minimum = 0
        MultiAmmVoltmeter3.maximum = 10


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
            sbMst.ConnectionTimeout = 150

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

        Me.Controls.Add(MultiAmmVoltmeter3)
        MultiAmmVoltmeter3.Location = New Point(324, 23)
        MultiAmmVoltmeter3.units = "A"


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try


            sbMst.UnitIdentifier = 1
            Dim reading As Integer() = sbMst.ReadInputRegisters(270, 2)
            Dim temp As Decimal = EasyModbus.ModbusClient.ConvertRegistersToFloat({reading(1), reading(0)})
            MultiAmmVoltmeter1.value = temp
            reading = sbMst.ReadInputRegisters(218, 2)
            temp = EasyModbus.ModbusClient.ConvertRegistersToFloat({reading(1), reading(0)})
            MultiAmmVoltmeter2.value = temp
            reading = sbMst.ReadInputRegisters(232, 2)
            temp = EasyModbus.ModbusClient.ConvertRegistersToFloat({reading(1), reading(0)})
            MultiAmmVoltmeter3.value = temp

            sbMst.UnitIdentifier = 2
            If MultiPumpPanel1.isPump1Running And Not MultiPumpPanel1.isPump2Running Then
                sbMst.WriteMultipleRegisters(1, {1})
            ElseIf MultiPumpPanel1.isPump2Running And Not MultiPumpPanel1.isPump1Running Then
                sbMst.WriteSingleRegister(1, 2)
            ElseIf MultiPumpPanel1.isPump2Running And MultiPumpPanel1.isPump1Running Then
                sbMst.WriteSingleRegister(1, 3)
            Else
                sbMst.WriteSingleRegister(1, 0)
            End If

        Catch ex As Exception


        End Try

    End Sub
End Class

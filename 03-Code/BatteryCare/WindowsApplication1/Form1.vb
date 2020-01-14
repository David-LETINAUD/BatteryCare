
Public Class BatteryCare_form

    Dim BatteryLevel As Integer
    Dim SeuilCharge As Integer = 40
    Dim SeuilDecharge As Integer = 80

    Dim FlagVerifAlim As Boolean = True
    Dim FlagVerifModule As Boolean = True
    Dim FlagClose As Boolean = False

    Dim COM As String = Nothing
    Dim nbSec As Integer

    Dim COM_error As Boolean = False



    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Label1.Text = SystemInformation.PowerStatus.BatteryLifePercent * 100
        Timer1.Start()

        Me.ShowInTaskbar = False
        'Me.WindowState = FormWindowState.Minimized
        'Me.Visible = False
        'Me.NotifyIcon.Icon = Me.Icon

        Me.MinimizeBox = False
        'Me.MaximizeBox = False

        ' Gestion de la ComboBox selection de ports COM
        CB_PortCom.Items.Clear()
        For Each sp As String In My.Computer.Ports.SerialPortNames  'détection des ports pouvant être utilisés
            CB_PortCom.Items.Add(sp)
        Next

        'AddHandler Microsoft.Win32.SystemEvents.EventsThreadShutdown, AddressOf Standby
        AddHandler Microsoft.Win32.SystemEvents.PowerModeChanged, AddressOf Standby
    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ' Incrémentation des secondes
        nbSec = nbSec + 1

        ' Calcul du niveau de batterie
        BatteryLevel = SystemInformation.PowerStatus.BatteryLifePercent * 100

        ' Gestion de la Progress Barre
        PgB_Batterie.Value = SystemInformation.PowerStatus.BatteryLifePercent * 100

        ' Gestion du label % de charge
        If SystemInformation.PowerStatus.PowerLineStatus = PowerLineStatus.Online Then
            LBL_Batterie.Text = Convert.ToString(BatteryLevel) + "%" + " en charge"
            Voyant.BackColor = Color.Lime
            BT_Manuel.BackColor = Color.Red
            FlagVerifAlim = True
        ElseIf SystemInformation.PowerStatus.PowerLineStatus = PowerLineStatus.Offline Then
            LBL_Batterie.Text = Convert.ToString(BatteryLevel) + "% restant"
            Voyant.BackColor = Color.Red
            BT_Manuel.BackColor = Color.Lime
            FlagVerifModule = True
        End If


        ' Toutes les 10 sec
        If nbSec >= 10 Then

            ' Gestion de la ComboBox selection de ports COM
            CB_PortCom.Items.Clear()
            For Each sp As String In My.Computer.Ports.SerialPortNames  'détection des ports pouvant être utilisés
                CB_PortCom.Items.Add(sp)
            Next

            ' Envoie d'une commande 
            'If SerialPort.IsOpen And SeuilCharge <> Nothing And SeuilDecharge <> Nothing Then
            If SeuilCharge <> Nothing And SeuilDecharge <> Nothing Then
                If BatteryLevel <= SeuilCharge And SystemInformation.PowerStatus.PowerLineStatus = PowerLineStatus.Offline Then

                    SetCharge()

                ElseIf BatteryLevel >= SeuilDecharge And SystemInformation.PowerStatus.PowerLineStatus = PowerLineStatus.Online Then

                    SetDischarge()

                End If

            End If

            ' Gestion de non charge
            If SeuilCharge <> Nothing And SystemInformation.PowerStatus.PowerLineStatus = PowerLineStatus.Offline And FlagVerifAlim = True And BatteryLevel < SeuilCharge Then
                FlagVerifAlim = False
                NotifyIcon.BalloonTipText = "Vérifier le branchement de l'alimentation"
                NotifyIcon.ShowBalloonTip(500)
            End If
            ' Gestion de surcharge
            If SeuilDecharge <> Nothing And SystemInformation.PowerStatus.PowerLineStatus = PowerLineStatus.Online And FlagVerifModule = True And BatteryLevel > SeuilDecharge Then
                FlagVerifModule = False
                NotifyIcon.BalloonTipText = "Vérifier le branchement du module et la connection bluetooth"
                NotifyIcon.ShowBalloonTip(500)
            End If

            nbSec = 0
        End If



    End Sub


    Private Sub Form1_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize

        If Me.WindowState = FormWindowState.Minimized Then
            Me.Visible = False
            NotifyIcon.BalloonTipText = "BatteryCare en arrière plan" + vbCrLf + "Ne pas fermer"
            NotifyIcon.ShowBalloonTip(500)
        Else
            Me.Visible = True
        End If

    End Sub

    Private Sub TB_SeuilCharge_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_SeuilCharge.TextChanged
        If (TB_SeuilCharge.Text <> Nothing) Then

            If (TB_SeuilCharge.Text > 9) Then

                If (TB_SeuilDecharge.Text <> Nothing) Then
                    If (TB_SeuilDecharge.Text < TB_SeuilCharge.Text) Then 'Seuil de décharge plus grand que celui de charge
                        TB_SeuilCharge.Clear()
                        MsgBox("Erreur" + vbCrLf + "Le seuil de charge doit être inférieur à celui de décharge")
                    Else
                        SeuilCharge = TB_SeuilCharge.Text
                        FlagVerifAlim = True
                    End If
                Else
                    SeuilCharge = TB_SeuilCharge.Text
                End If

            End If


        End If

    End Sub


    Private Sub TB_SeuilDecharge_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_SeuilDecharge.TextChanged

        If (TB_SeuilDecharge.Text <> Nothing) Then

            If (TB_SeuilDecharge.Text > 9) Then

                If (TB_SeuilCharge.Text <> Nothing) Then
                    If (TB_SeuilDecharge.Text < TB_SeuilCharge.Text) Then 'Seuil de décharge plus grand que celui de charge
                        TB_SeuilDecharge.Clear()
                        MsgBox("Erreur" + vbCrLf + "Le seuil de décharge doit être supérieur à celui de charge")
                    Else
                        SeuilDecharge = TB_SeuilDecharge.Text
                    End If
                Else
                    SeuilDecharge = TB_SeuilDecharge.Text
                End If

            End If

        End If

    End Sub


    Private Sub CB_PortCom_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_PortCom.SelectedIndexChanged
        COM = CB_PortCom.SelectedItem
        If (COM <> Nothing And SerialPort.IsOpen = False) Then
            SerialPort.PortName = COM
            'SerialPort.Open()    ' Ouvre le port COM
        End If

    End Sub


    Function ReceiveSerialData() As String
        Dim Incoming As String
        Try
            Incoming = SerialPort.ReadExisting()
            If Incoming Is Nothing Then
                Return "nothing" & vbCrLf
            Else
                Return Incoming
            End If
        Catch ex As TimeoutException
            Return "Error: Serial Port read timed out."
        End Try

    End Function

    Function SetCharge() As Integer
        If (COM <> Nothing) And Not (SerialPort.IsOpen) Then
            SerialPort.PortName = COM
            Try
                SerialPort.Open()    'Ouvre le port COM
            Catch ex1 As Exception
                If COM_error = False Then
                    NotifyIcon.BalloonTipText = "Vérifier le branchement du module."
                    NotifyIcon.ShowBalloonTip(500)
                    COM_error = True
                End If
                Return 1
            End Try

            ' Si le port COM est ouvert
            If SerialPort.IsOpen Then
                COM_error = False
                SerialPort.Write("c")
                SerialPort.Close()    'Ferme le port COM
            End If

        End If

        Return 0
    End Function

    Function SetDischarge() As Integer
        If (COM <> Nothing) And Not (SerialPort.IsOpen) Then
            SerialPort.PortName = COM
            Try
                SerialPort.Open()    'Ouvre le port COM
            Catch ex1 As Exception
                If COM_error = False Then
                    NotifyIcon.BalloonTipText = "Vérifier le branchement du module."
                    NotifyIcon.ShowBalloonTip(500)
                    COM_error = True
                End If
                Return 1
            End Try

            ' Si le port COM est ouvert
            If SerialPort.IsOpen Then
                COM_error = False
                SerialPort.Write("d")
                SerialPort.Close()    'Ferme le port COM
            End If

        End If

        Return 0
    End Function


    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If FlagClose = False Then

            e.Cancel = True
            Me.Hide()

        End If

    End Sub

    Private Sub NotifyIcon_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon.MouseDoubleClick
        Me.Show()
    End Sub


    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        FlagClose = True

        SerialPort.Close()
        Application.Exit()

        FlagClose = False
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Me.Show()
    End Sub


    Private Sub Standby(ByVal sender As Object, ByVal e As Microsoft.Win32.PowerModeChangedEventArgs)
        'SerialPort.Write("c")

        If e.Mode = Microsoft.Win32.PowerModes.Suspend Then   ' CA marche en mise en veille
            'utiliser .suspend pour connaitre le début de la mise en veille
            SetDischarge()

            'End If
        ElseIf e.Mode = Microsoft.Win32.PowerModes.Resume Then
            'utiliser .resume pour connaitre la fin de la mise en veille
            'SerialPort.Open()
            'SetDischarge()
        End If

    End Sub

    Public Sub Handler_SessionEnding(ByVal sender As Object,
               ByVal e As Microsoft.Win32.SessionEndingEventArgs)
        If e.Reason = Microsoft.Win32.SessionEndReasons.Logoff Then
            'MessageBox.Show("User is logging off")
            SetDischarge()
        ElseIf e.Reason = Microsoft.Win32.SessionEndReasons.SystemShutdown Then
            'MessageBox.Show("System is shutting down")
            SetDischarge()
        End If
    End Sub

    Private Sub BT_Manuel_Click(sender As Object, e As EventArgs) Handles BT_Manuel.Click
        If SystemInformation.PowerStatus.PowerLineStatus = PowerLineStatus.Online Then
            SetDischarge()
        ElseIf SystemInformation.PowerStatus.PowerLineStatus = PowerLineStatus.Offline Then
            SetCharge()
        End If
    End Sub
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BatteryCare_form
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BatteryCare_form))
        Me.LBL_Batterie = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.NotifyIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PgB_Batterie = New System.Windows.Forms.ProgressBar()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.Voyant = New Microsoft.VisualBasic.PowerPacks.OvalShape()
        Me.LBL_Conseils = New System.Windows.Forms.Label()
        Me.TB_SeuilCharge = New System.Windows.Forms.TextBox()
        Me.LBL_TiretDu6 = New System.Windows.Forms.Label()
        Me.TB_SeuilDecharge = New System.Windows.Forms.TextBox()
        Me.SerialPort = New System.IO.Ports.SerialPort(Me.components)
        Me.CB_PortCom = New System.Windows.Forms.ComboBox()
        Me.BT_Manuel = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LBL_Batterie
        '
        Me.LBL_Batterie.AutoSize = True
        Me.LBL_Batterie.Location = New System.Drawing.Point(23, 28)
        Me.LBL_Batterie.Name = "LBL_Batterie"
        Me.LBL_Batterie.Size = New System.Drawing.Size(94, 13)
        Me.LBL_Batterie.TabIndex = 0
        Me.LBL_Batterie.Text = "Niveau de batterie"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'NotifyIcon
        '
        Me.NotifyIcon.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NotifyIcon.Icon = CType(resources.GetObject("NotifyIcon.Icon"), System.Drawing.Icon)
        Me.NotifyIcon.Text = "BatteryCare"
        Me.NotifyIcon.Visible = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.ToolStripMenuItem3})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(121, 70)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(120, 22)
        Me.ToolStripMenuItem1.Text = "Quitter"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(120, 22)
        Me.ToolStripMenuItem2.Text = "Agrandir"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(120, 22)
        Me.ToolStripMenuItem3.Text = "Infos"
        '
        'PgB_Batterie
        '
        Me.PgB_Batterie.BackColor = System.Drawing.SystemColors.Control
        Me.PgB_Batterie.Location = New System.Drawing.Point(9, 46)
        Me.PgB_Batterie.Name = "PgB_Batterie"
        Me.PgB_Batterie.Size = New System.Drawing.Size(128, 23)
        Me.PgB_Batterie.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.PgB_Batterie.TabIndex = 1
        Me.PgB_Batterie.UseWaitCursor = True
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.Voyant})
        Me.ShapeContainer1.Size = New System.Drawing.Size(161, 111)
        Me.ShapeContainer1.TabIndex = 2
        Me.ShapeContainer1.TabStop = False
        '
        'Voyant
        '
        Me.Voyant.BackColor = System.Drawing.Color.Lime
        Me.Voyant.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.Voyant.BorderColor = System.Drawing.Color.Transparent
        Me.Voyant.FillGradientColor = System.Drawing.Color.DarkRed
        Me.Voyant.Location = New System.Drawing.Point(10, 28)
        Me.Voyant.Name = "Voyant"
        Me.Voyant.Size = New System.Drawing.Size(13, 13)
        '
        'LBL_Conseils
        '
        Me.LBL_Conseils.AutoSize = True
        Me.LBL_Conseils.Location = New System.Drawing.Point(7, 72)
        Me.LBL_Conseils.Name = "LBL_Conseils"
        Me.LBL_Conseils.Size = New System.Drawing.Size(132, 13)
        Me.LBL_Conseils.TabIndex = 3
        Me.LBL_Conseils.Text = "Mode Auto | Mode Manuel"
        '
        'TB_SeuilCharge
        '
        Me.TB_SeuilCharge.Location = New System.Drawing.Point(14, 88)
        Me.TB_SeuilCharge.Name = "TB_SeuilCharge"
        Me.TB_SeuilCharge.Size = New System.Drawing.Size(18, 20)
        Me.TB_SeuilCharge.TabIndex = 4
        Me.TB_SeuilCharge.Text = "40"
        Me.TB_SeuilCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LBL_TiretDu6
        '
        Me.LBL_TiretDu6.AutoSize = True
        Me.LBL_TiretDu6.Location = New System.Drawing.Point(33, 91)
        Me.LBL_TiretDu6.Name = "LBL_TiretDu6"
        Me.LBL_TiretDu6.Size = New System.Drawing.Size(10, 13)
        Me.LBL_TiretDu6.TabIndex = 5
        Me.LBL_TiretDu6.Text = "-"
        '
        'TB_SeuilDecharge
        '
        Me.TB_SeuilDecharge.Location = New System.Drawing.Point(42, 88)
        Me.TB_SeuilDecharge.Name = "TB_SeuilDecharge"
        Me.TB_SeuilDecharge.Size = New System.Drawing.Size(18, 20)
        Me.TB_SeuilDecharge.TabIndex = 6
        Me.TB_SeuilDecharge.Text = "80"
        Me.TB_SeuilDecharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CB_PortCom
        '
        Me.CB_PortCom.FormattingEnabled = True
        Me.CB_PortCom.Location = New System.Drawing.Point(9, 3)
        Me.CB_PortCom.Name = "CB_PortCom"
        Me.CB_PortCom.Size = New System.Drawing.Size(128, 21)
        Me.CB_PortCom.TabIndex = 7
        Me.CB_PortCom.Text = "Connection au module"
        '
        'BT_Manuel
        '
        Me.BT_Manuel.BackColor = System.Drawing.Color.Red
        Me.BT_Manuel.FlatAppearance.BorderSize = 0
        Me.BT_Manuel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BT_Manuel.Location = New System.Drawing.Point(93, 91)
        Me.BT_Manuel.Name = "BT_Manuel"
        Me.BT_Manuel.Size = New System.Drawing.Size(14, 13)
        Me.BT_Manuel.TabIndex = 8
        Me.BT_Manuel.UseVisualStyleBackColor = False
        '
        'BatteryCare_form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(146, 111)
        Me.Controls.Add(Me.BT_Manuel)
        Me.Controls.Add(Me.CB_PortCom)
        Me.Controls.Add(Me.TB_SeuilDecharge)
        Me.Controls.Add(Me.LBL_TiretDu6)
        Me.Controls.Add(Me.TB_SeuilCharge)
        Me.Controls.Add(Me.LBL_Conseils)
        Me.Controls.Add(Me.PgB_Batterie)
        Me.Controls.Add(Me.LBL_Batterie)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(162, 150)
        Me.MinimumSize = New System.Drawing.Size(162, 150)
        Me.Name = "BatteryCare_form"
        Me.Text = "BatteryCare"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LBL_Batterie As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents PgB_Batterie As System.Windows.Forms.ProgressBar
    Friend WithEvents LBL_Conseils As System.Windows.Forms.Label
    Friend WithEvents TB_SeuilCharge As System.Windows.Forms.TextBox
    Friend WithEvents LBL_TiretDu6 As System.Windows.Forms.Label
    Friend WithEvents TB_SeuilDecharge As System.Windows.Forms.TextBox
    Friend WithEvents SerialPort As System.IO.Ports.SerialPort
    Friend WithEvents CB_PortCom As System.Windows.Forms.ComboBox
    Public WithEvents NotifyIcon As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ShapeContainer1 As PowerPacks.ShapeContainer
    Private WithEvents Voyant As PowerPacks.OvalShape
    Friend WithEvents BT_Manuel As Button
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.lblAnswer = New System.Windows.Forms.Label()
        Me.butStart = New System.Windows.Forms.Button()
        Me.cmbSelect = New System.Windows.Forms.ComboBox()
        Me.ofdFile = New System.Windows.Forms.OpenFileDialog()
        Me.cdgBackground = New System.Windows.Forms.ColorDialog()
        Me.SuspendLayout()
        '
        'lblAnswer
        '
        Me.lblAnswer.AutoSize = True
        Me.lblAnswer.Location = New System.Drawing.Point(25, 9)
        Me.lblAnswer.Name = "lblAnswer"
        Me.lblAnswer.Size = New System.Drawing.Size(42, 13)
        Me.lblAnswer.TabIndex = 0
        Me.lblAnswer.Text = "Answer"
        '
        'butStart
        '
        Me.butStart.BackColor = System.Drawing.Color.Transparent
        Me.butStart.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.butStart.Location = New System.Drawing.Point(146, 4)
        Me.butStart.Name = "butStart"
        Me.butStart.Size = New System.Drawing.Size(75, 23)
        Me.butStart.TabIndex = 1
        Me.butStart.Text = "Decide"
        Me.butStart.UseVisualStyleBackColor = False
        '
        'cmbSelect
        '
        Me.cmbSelect.FormattingEnabled = True
        Me.cmbSelect.Items.AddRange(New Object() {"Ant", "Rnd()", "File"})
        Me.cmbSelect.Location = New System.Drawing.Point(100, 4)
        Me.cmbSelect.Name = "cmbSelect"
        Me.cmbSelect.Size = New System.Drawing.Size(121, 21)
        Me.cmbSelect.TabIndex = 2
        Me.cmbSelect.Visible = False
        '
        'ofdFile
        '
        Me.ofdFile.InitialDirectory = "C:\Program Files\YesNo"
        Me.ofdFile.ShowReadOnly = True
        Me.ofdFile.Title = "Choose File"
        '
        'cdgBackground
        '
        Me.cdgBackground.AnyColor = True
        Me.cdgBackground.Color = System.Drawing.SystemColors.Control
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(242, 34)
        Me.Controls.Add(Me.cmbSelect)
        Me.Controls.Add(Me.butStart)
        Me.Controls.Add(Me.lblAnswer)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(258, 69)
        Me.Name = "Form1"
        Me.Text = "YesNo Decision Maker"
        Me.TransparencyKey = System.Drawing.Color.Transparent
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblAnswer As System.Windows.Forms.Label
    Friend WithEvents butStart As System.Windows.Forms.Button
    Friend WithEvents cmbSelect As System.Windows.Forms.ComboBox
    Friend WithEvents ofdFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cdgBackground As System.Windows.Forms.ColorDialog

End Class

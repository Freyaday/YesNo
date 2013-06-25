Public Class Form1
    Public bolAnswer As Boolean
    Public strYes() As String = {"Yes"}
    Public strNo() As String = {"No"}
    Public intYesLines As Integer = 0
    Public intNoLines As Integer = 0
    Public bolAnt(99, 99) As Boolean
    Public bytXant As Byte = CByte(100 * Rnd())
    Public bytYant As Byte = CByte(100 * Rnd())
    Public bytDant As Byte = CByte(4 * Rnd())
    Public datClick As Date
    Public bolIsKeyDown As Boolean = False
    'Public ftsFlatStyles() As System.Windows.Forms.FlatStyle = {FlatStyle.Flat, FlatStyle.Popup, FlatStyle.Standard} 'Stupid Windows not redrawing the button.
    'Public bytFstyle As Byte = 2

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Randomize()
        Randomize() 'Boss said to make it more random
      
        For bytX As Byte = 0 To 99
            For bytY As Byte = 0 To 99
                bolAnt(bytX, bytY) = Rnd() >= 0.5
            Next
        Next
        'Try
        '    Dim objYesReader As New System.IO.StreamReader(My.Resources.Yes)
        '    'C:\Program Files\YesNo\
        '    Do Until objYesReader.EndOfStream
        '        strYes(intYesLines) = objYesReader.ReadLine
        '        intYesLines += 1
        '        ReDim Preserve strYes(intYesLines)
        '        strYes(intYesLines) = "Yes"
        '    Loop
        '    objYesReader.Close()
        'Catch ex As Exception
        'End Try

        'Try
        '    Dim objNoReader As New System.IO.StreamReader(My.Resources.No)
        '    'C:\Program Files\YesNo\
        '    Do Until objNoReader.EndOfStream
        '        strNo(intNoLines) = objNoReader.ReadLine
        '        intNoLines += 1
        '        ReDim Preserve strNo(intNoLines)
        '        strNo(intNoLines) = "No"
        '    Loop
        '    objNoReader.Close()
        'Catch ex As Exception
        'End Try
        'This is what I get for being clever. I have to scrap the whole thing when Boss2 insists the install instructions are "too complicated" and "shouldn't even be". Sigh.

        strYes = Split(My.Resources.Yes, Environment.NewLine, , CompareMethod.Text)
        intYesLines = strYes.Length
        ' intYesLines += 1
        ReDim Preserve strYes(intYesLines)
        strYes(intYesLines) = "Yes"

        strNo = Split(My.Resources.No, Environment.NewLine, , CompareMethod.Text)
        intNoLines = strNo.Length
        'intNoLines += 1
        ReDim Preserve strNo(intNoLines)
        strNo(intNoLines) = "No"
    End Sub
    Private Sub butStart_Click(sender As Object, e As EventArgs) Handles butStart.Click
        datClick = Date.Now
    End Sub
    Private Sub Decide(Optional ByRef bytChoose As Byte = 3)

        Select Case bytChoose
            Case 0
                GoTo Ant
            Case 1
                GoTo Rnd
            Case 2
                GoTo FS
        End Select


        If Rnd() <= 0.5 Then
Rnd:        If Rnd() <= 0.7 Then
                bolAnswer = bolAnswer = False
            End If
        Else
Ant:        If bolAnt(bytXant, bytYant) Then
                bytDant = (bytDant + 3) Mod 4
            Else
                bytDant = (bytDant + 1) Mod 4
            End If
            Select Case bytDant
                Case 0
                    bytYant = (bytYant + 3) Mod 100
                Case 1
                    bytXant = (bytXant + 1) Mod 100
                Case 2
                    bytYant = (bytYant + 1) Mod 100
                Case 3
                    bytXant = (bytXant + 3) Mod 100
            End Select
            bolAnt(bytXant, bytYant) = bolAnt(bytXant, bytYant) = False
            bolAnswer = bolAnt(bytXant, bytYant)
        End If
        If bytChoose <> 3 Then
            GoTo YN
        End If

        GoTo YN

FS:     ofdFile.ShowDialog() 'Boss said it was too random
        Try
            Dim objByteReader As New System.IO.StreamReader(ofdFile.FileName)
            For bytCount As Byte = 0 To 18 'Chosen by blessed d20. Guaranteed to be random.
                bolAnswer = (CByte(objByteReader.Read) Mod 2) = 1
            Next
        Catch ex As Exception
            If ofdFile.FileName = "" Then
                MsgBox("Choose a file!", MsgBoxStyle.Exclamation, "Error!")
                GoTo FS
            Else
            End If
        End Try

YN:     If bolAnswer Then
            lblAnswer.Text = strYes(CInt(Int((intYesLines + 1) * Rnd())))
        Else
            lblAnswer.Text = strNo(CInt(Int((intNoLines + 1) * Rnd())))
        End If
    End Sub

    Private Sub butStart_MouseUp(sender As Object, e As MouseEventArgs) Handles butStart.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            cdgBackground.ShowDialog()          'Boss wanted to be more colorful. SIGH.
            Me.BackColor = cdgBackground.Color
        ElseIf Date.Now.Subtract(datClick).Milliseconds < 300 Then
            Decide()
        ElseIf Date.Now.Subtract(datClick).Milliseconds > 300 And Date.Now.Subtract(datClick).Milliseconds < 1000 Then
            cmbSelect.Visible = True
            cmbSelect.Focus()
        Else

        End If
    End Sub

    Private Sub cmbSelect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSelect.SelectedIndexChanged
        cmbSelect.Visible = False
        Decide(CByte(cmbSelect.SelectedIndex))
        bolIsKeyDown = False 'weirdass bug.
    End Sub

    Private Sub Form1_MouseWheel(sender As Object, e As MouseEventArgs) Handles MyBase.MouseWheel
        Dim Rainbow As New Random
 
        Me.BackColor = Color.FromArgb(Rainbow.Next(0, 255), Rainbow.Next(0, 255), Rainbow.Next(0, 255))

        If bolIsKeyDown Then
            Me.Opacity = (Me.Opacity + WheelTick(e.Delta) - 0.01) Mod 1 + 0.01
        End If
    End Sub
    Private Function WheelTick(ByRef Delta)
        If Delta > 0 Then
            Return 0.01
        ElseIf Delta < 0 Then
            Return -0.01
        Else
            Return 0
        End If
    End Function
    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        'If e.KeyCode = Keys.Alt Then
        '    bytFstyle = (bytFstyle + 1) Mod 3
        'ElseIf e.KeyCode = Keys.Control Then
        '    bytFstyle = (bytFstyle - 1) Mod 3
        'Else
        bolIsKeyDown = True
        If e.KeyCode = Keys.Home Then
            Me.Opacity = 1
        End If
        If e.KeyCode = Keys.End Then
            Me.Opacity = 0.01
        End If
        'End If
        'butStart.FlatStyle = ftsFlatStyles(bytFstyle)
    End Sub

    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        bolIsKeyDown = False
    End Sub

    Private Sub Form1_BackColorChanged(sender As Object, e As EventArgs) Handles MyBase.BackColorChanged
        If 127 < (CInt(Me.BackColor.R) + CInt(Me.BackColor.G) + CInt(Me.BackColor.B)) / 3 Then
            lblAnswer.ForeColor = Color.Black
        Else
            lblAnswer.ForeColor = Color.White
        End If
    End Sub

End Class

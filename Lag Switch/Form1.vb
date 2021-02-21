Public Class Form1

    Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Integer) As Short

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckBox1.Checked = My.Settings.topmost
        Me.TopMost = My.Settings.topmost
        If My.Settings.lagged = True Then
            Button1.Text = "Stop"
        Else
            Button1.Text = "Lag"
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Me.TopMost = True
            My.Settings.topmost = True
        Else
            Me.TopMost = False
            My.Settings.topmost = False
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If My.Settings.lagged = False Then
            Shell("ipconfig /release")
            My.Settings.lagged = True
            Button1.Text = "Stop"
        Else
            Shell("ipconfig /renew")
            My.Settings.lagged = False
            Button1.Text = "Lag"
        End If
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If (GetAsyncKeyState(Keys.F9)) Then
            Button1.PerformClick()
            Threading.Thread.Sleep(500)
        End If
    End Sub
End Class
Public Class Preferences
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
    End Sub

    Private Sub Btn_Imperial_Click(sender As Object, e As EventArgs) Handles Btn_Imperial.Click
        ImperialBool = True
        Form2.RouteStats()
        Lbl_UnitMeasurement.Text = kmstring + ", " + mstring
        Lbl_WalkingSpeed.Text = WalkingSpeed.ToString + kmstring + "/h"
    End Sub

    Private Sub Btn_Metric_Click(sender As Object, e As EventArgs) Handles Btn_Metric.Click
        ImperialBool = False
        Form2.RouteStats()
        Lbl_UnitMeasurement.Text = kmstring + ", " + mstring
        Lbl_WalkingSpeed.Text = WalkingSpeed.ToString + kmstring + "/h"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        WalkingSpeed -= 1
        If WalkingSpeed = 1 Then
            Button2.Enabled = False
        End If
        Button3.Enabled = True
        Lbl_WalkingSpeed.Text = WalkingSpeed.ToString + kmstring + "/h"
        Form2.RouteStats()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        WalkingSpeed += 1
        If WalkingSpeed = 10 Then
            Button3.Enabled = False
        End If
        Button2.Enabled = True
        Lbl_WalkingSpeed.Text = WalkingSpeed.ToString + kmstring + "/h"
        Form2.RouteStats()
    End Sub
End Class
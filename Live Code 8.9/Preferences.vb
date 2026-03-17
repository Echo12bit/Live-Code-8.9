Public Class Preferences
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide() 'button that hides the form if clicked
    End Sub

    Private Sub Btn_Imperial_Click(sender As Object, e As EventArgs) Handles Btn_Imperial.Click
        ImperialBool = True 'boolean value indicating imperial measurements
        Form2.RouteStats() 'updates route statistics with imperial quantities
        Lbl_UnitMeasurement.Text = kmstring + ", " + mstring
        Lbl_WalkingSpeed.Text = WalkingSpeed.ToString + kmstring + "/h"
        'updates labels with imperial quantities
    End Sub

    Private Sub Btn_Metric_Click(sender As Object, e As EventArgs) Handles Btn_Metric.Click
        ImperialBool = False 'boolean value indicating metric measurements
        Form2.RouteStats() 'updates route statistics with metric quantities
        Lbl_UnitMeasurement.Text = kmstring + ", " + mstring
        Lbl_WalkingSpeed.Text = WalkingSpeed.ToString + kmstring + "/h"
        'updates labels with metric quantities
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        WalkingSpeed -= 1 'decrements walking speed by 1
        If WalkingSpeed = 1 Then
            Button2.Enabled = False 'dsables walking speed down button if it falls to 1
        End If
        Button3.Enabled = True 'enables walking speed up button
        Lbl_WalkingSpeed.Text = WalkingSpeed.ToString + kmstring + "/h"
        'updates walking speed label with correct speed 
        Form2.RouteStats() 'updates route statistics with correct walking speed
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        WalkingSpeed += 1 'increments walking speed by 1
        If WalkingSpeed = 10 Then
            Button3.Enabled = False 'dsables walking speed up button if it rises to 10
        End If
        Button2.Enabled = True 'enables walking speed up button
        Lbl_WalkingSpeed.Text = WalkingSpeed.ToString + kmstring + "/h"
        'updates walking speed label with correct speed 
        Form2.RouteStats() 'updates route statistics with correct walking speed
    End Sub
End Class
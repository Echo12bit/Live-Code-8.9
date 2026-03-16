<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Preferences
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
        Button1 = New Button()
        Lbl_UnitQuantity = New Label()
        Btn_Imperial = New Button()
        Btn_Metric = New Button()
        Label1 = New Label()
        Button2 = New Button()
        Button3 = New Button()
        Lbl_WalkingSpeed = New Label()
        Lbl_UnitMeasurement = New Label()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(262, 236)
        Button1.Name = "Button1"
        Button1.Size = New Size(94, 29)
        Button1.TabIndex = 0
        Button1.Text = "Hide"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Lbl_UnitQuantity
        ' 
        Lbl_UnitQuantity.AutoSize = True
        Lbl_UnitQuantity.Font = New Font("Dubai", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Lbl_UnitQuantity.Location = New Point(21, 34)
        Lbl_UnitQuantity.Name = "Lbl_UnitQuantity"
        Lbl_UnitQuantity.Size = New Size(261, 34)
        Lbl_UnitQuantity.TabIndex = 28
        Lbl_UnitQuantity.Text = "Prefered Unit Measurement:"
        ' 
        ' Btn_Imperial
        ' 
        Btn_Imperial.Location = New Point(21, 80)
        Btn_Imperial.Name = "Btn_Imperial"
        Btn_Imperial.Size = New Size(94, 29)
        Btn_Imperial.TabIndex = 29
        Btn_Imperial.Text = "Imperial"
        Btn_Imperial.UseVisualStyleBackColor = True
        ' 
        ' Btn_Metric
        ' 
        Btn_Metric.Location = New Point(121, 80)
        Btn_Metric.Name = "Btn_Metric"
        Btn_Metric.Size = New Size(94, 29)
        Btn_Metric.TabIndex = 30
        Btn_Metric.Text = "Metric"
        Btn_Metric.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Dubai", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(21, 154)
        Label1.Name = "Label1"
        Label1.Size = New Size(148, 34)
        Label1.TabIndex = 31
        Label1.Text = "Walking Speed:"
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(35, 191)
        Button2.Name = "Button2"
        Button2.Size = New Size(36, 29)
        Button2.TabIndex = 32
        Button2.Text = "-"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(77, 191)
        Button3.Name = "Button3"
        Button3.Size = New Size(36, 29)
        Button3.TabIndex = 33
        Button3.Text = "+"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Lbl_WalkingSpeed
        ' 
        Lbl_WalkingSpeed.AutoSize = True
        Lbl_WalkingSpeed.Font = New Font("Dubai", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Lbl_WalkingSpeed.Location = New Point(121, 192)
        Lbl_WalkingSpeed.Name = "Lbl_WalkingSpeed"
        Lbl_WalkingSpeed.Size = New Size(63, 29)
        Lbl_WalkingSpeed.TabIndex = 34
        Lbl_WalkingSpeed.Text = "--km/h"
        ' 
        ' Lbl_UnitMeasurement
        ' 
        Lbl_UnitMeasurement.AutoSize = True
        Lbl_UnitMeasurement.Font = New Font("Dubai", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Lbl_UnitMeasurement.Location = New Point(231, 81)
        Lbl_UnitMeasurement.Name = "Lbl_UnitMeasurement"
        Lbl_UnitMeasurement.Size = New Size(54, 29)
        Lbl_UnitMeasurement.TabIndex = 35
        Lbl_UnitMeasurement.Text = "km, m"
        ' 
        ' Preferences
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(385, 279)
        Controls.Add(Lbl_UnitMeasurement)
        Controls.Add(Lbl_WalkingSpeed)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(Label1)
        Controls.Add(Btn_Metric)
        Controls.Add(Btn_Imperial)
        Controls.Add(Lbl_UnitQuantity)
        Controls.Add(Button1)
        Name = "Preferences"
        Text = "Preferences"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Lbl_UnitQuantity As Label
    Friend WithEvents Btn_Imperial As Button
    Friend WithEvents Btn_Metric As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Lbl_WalkingSpeed As Label
    Friend WithEvents Lbl_UnitMeasurement As Label
End Class

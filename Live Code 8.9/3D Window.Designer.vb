<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Btn_Reset = New Button()
        Btn_Regenerate = New Button()
        Btn_Orbit = New Button()
        Timer1 = New Timer(components)
        Btn_Hide = New Button()
        PictureBox1 = New PictureBox()
        PictureBox2 = New PictureBox()
        Label1 = New Label()
        PictureBox4 = New PictureBox()
        PictureBox3 = New PictureBox()
        PictureBox10 = New PictureBox()
        PictureBox9 = New PictureBox()
        PictureBox8 = New PictureBox()
        PictureBox7 = New PictureBox()
        Txt_Extremity = New TextBox()
        Btn_UpdateExtremity = New Button()
        Txt_Angle = New TextBox()
        Btn_UpdateAngle = New Button()
        Btn_OctaveDown = New Button()
        Btn_OctaveUp = New Button()
        Txt_Lacunarity = New TextBox()
        Btn_UpdateLacunarity = New Button()
        Label8 = New Label()
        Lbl_Length = New Label()
        Lbl_MaxElevation = New Label()
        Lbl_MinElevation = New Label()
        Lbl_TotalElevation = New Label()
        Lbl_Duration = New Label()
        PictureBox5 = New PictureBox()
        Lbl_Elevation = New Label()
        Lbl_Distance = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        Label9 = New Label()
        Label10 = New Label()
        Label11 = New Label()
        Label12 = New Label()
        Label13 = New Label()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox10, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox9, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox8, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox7, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox5, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Btn_Reset
        ' 
        Btn_Reset.Location = New Point(11, 149)
        Btn_Reset.Name = "Btn_Reset"
        Btn_Reset.Size = New Size(182, 57)
        Btn_Reset.TabIndex = 0
        Btn_Reset.Text = "Reset"
        Btn_Reset.UseVisualStyleBackColor = True
        ' 
        ' Btn_Regenerate
        ' 
        Btn_Regenerate.Location = New Point(11, 262)
        Btn_Regenerate.Name = "Btn_Regenerate"
        Btn_Regenerate.Size = New Size(182, 61)
        Btn_Regenerate.TabIndex = 1
        Btn_Regenerate.Text = "Regenerate"
        Btn_Regenerate.UseVisualStyleBackColor = True
        ' 
        ' Btn_Orbit
        ' 
        Btn_Orbit.Location = New Point(13, 57)
        Btn_Orbit.Name = "Btn_Orbit"
        Btn_Orbit.Size = New Size(182, 60)
        Btn_Orbit.TabIndex = 2
        Btn_Orbit.Text = "Orbit"
        Btn_Orbit.UseVisualStyleBackColor = True
        ' 
        ' Timer1
        ' 
        Timer1.Interval = 1
        ' 
        ' Btn_Hide
        ' 
        Btn_Hide.Location = New Point(7, 993)
        Btn_Hide.Name = "Btn_Hide"
        Btn_Hide.Size = New Size(182, 60)
        Btn_Hide.TabIndex = 3
        Btn_Hide.Text = "Hide"
        Btn_Hide.UseVisualStyleBackColor = True
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.FromArgb(CByte(0), CByte(70), CByte(120))
        PictureBox1.Location = New Point(-9, -3)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(171, 426)
        PictureBox1.TabIndex = 4
        PictureBox1.TabStop = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.FromArgb(CByte(0), CByte(70), CByte(120))
        PictureBox2.Location = New Point(190, 534)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(63, 57)
        PictureBox2.TabIndex = 5
        PictureBox2.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.FromArgb(CByte(0), CByte(70), CByte(120))
        Label1.Font = New Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = SystemColors.ButtonHighlight
        Label1.Location = New Point(11, 19)
        Label1.Name = "Label1"
        Label1.Size = New Size(249, 35)
        Label1.TabIndex = 7
        Label1.Text = "EIGER MESH 3D"
        ' 
        ' PictureBox4
        ' 
        PictureBox4.BackColor = Color.Yellow
        PictureBox4.Location = New Point(427, 149)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(5, 342)
        PictureBox4.TabIndex = 20
        PictureBox4.TabStop = False
        ' 
        ' PictureBox3
        ' 
        PictureBox3.BackColor = Color.Yellow
        PictureBox3.Location = New Point(398, 149)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(5, 342)
        PictureBox3.TabIndex = 19
        PictureBox3.TabStop = False
        ' 
        ' PictureBox10
        ' 
        PictureBox10.BackColor = Color.Yellow
        PictureBox10.Location = New Point(668, 149)
        PictureBox10.Name = "PictureBox10"
        PictureBox10.Size = New Size(5, 342)
        PictureBox10.TabIndex = 26
        PictureBox10.TabStop = False
        ' 
        ' PictureBox9
        ' 
        PictureBox9.BackColor = Color.Yellow
        PictureBox9.Location = New Point(630, 149)
        PictureBox9.Name = "PictureBox9"
        PictureBox9.Size = New Size(5, 342)
        PictureBox9.TabIndex = 25
        PictureBox9.TabStop = False
        ' 
        ' PictureBox8
        ' 
        PictureBox8.BackColor = Color.Yellow
        PictureBox8.Location = New Point(598, 149)
        PictureBox8.Name = "PictureBox8"
        PictureBox8.Size = New Size(5, 342)
        PictureBox8.TabIndex = 24
        PictureBox8.TabStop = False
        ' 
        ' PictureBox7
        ' 
        PictureBox7.BackColor = Color.Yellow
        PictureBox7.Location = New Point(563, 149)
        PictureBox7.Name = "PictureBox7"
        PictureBox7.Size = New Size(5, 342)
        PictureBox7.TabIndex = 23
        PictureBox7.TabStop = False
        ' 
        ' Txt_Extremity
        ' 
        Txt_Extremity.Location = New Point(10, 415)
        Txt_Extremity.Name = "Txt_Extremity"
        Txt_Extremity.Size = New Size(125, 27)
        Txt_Extremity.TabIndex = 27
        ' 
        ' Btn_UpdateExtremity
        ' 
        Btn_UpdateExtremity.Location = New Point(155, 415)
        Btn_UpdateExtremity.Name = "Btn_UpdateExtremity"
        Btn_UpdateExtremity.Size = New Size(76, 29)
        Btn_UpdateExtremity.TabIndex = 28
        Btn_UpdateExtremity.Text = "Update"
        Btn_UpdateExtremity.UseVisualStyleBackColor = True
        ' 
        ' Txt_Angle
        ' 
        Txt_Angle.Location = New Point(7, 881)
        Txt_Angle.Name = "Txt_Angle"
        Txt_Angle.Size = New Size(125, 27)
        Txt_Angle.TabIndex = 29
        ' 
        ' Btn_UpdateAngle
        ' 
        Btn_UpdateAngle.Location = New Point(153, 879)
        Btn_UpdateAngle.Name = "Btn_UpdateAngle"
        Btn_UpdateAngle.Size = New Size(76, 29)
        Btn_UpdateAngle.TabIndex = 30
        Btn_UpdateAngle.Text = "Update"
        Btn_UpdateAngle.UseVisualStyleBackColor = True
        ' 
        ' Btn_OctaveDown
        ' 
        Btn_OctaveDown.Location = New Point(10, 558)
        Btn_OctaveDown.Name = "Btn_OctaveDown"
        Btn_OctaveDown.Size = New Size(64, 51)
        Btn_OctaveDown.TabIndex = 31
        Btn_OctaveDown.Text = "Down"
        Btn_OctaveDown.UseVisualStyleBackColor = True
        ' 
        ' Btn_OctaveUp
        ' 
        Btn_OctaveUp.Location = New Point(98, 558)
        Btn_OctaveUp.Name = "Btn_OctaveUp"
        Btn_OctaveUp.Size = New Size(64, 51)
        Btn_OctaveUp.TabIndex = 32
        Btn_OctaveUp.Text = "Up"
        Btn_OctaveUp.UseVisualStyleBackColor = True
        ' 
        ' Txt_Lacunarity
        ' 
        Txt_Lacunarity.Location = New Point(9, 701)
        Txt_Lacunarity.Name = "Txt_Lacunarity"
        Txt_Lacunarity.Size = New Size(125, 27)
        Txt_Lacunarity.TabIndex = 33
        ' 
        ' Btn_UpdateLacunarity
        ' 
        Btn_UpdateLacunarity.Location = New Point(153, 701)
        Btn_UpdateLacunarity.Name = "Btn_UpdateLacunarity"
        Btn_UpdateLacunarity.Size = New Size(76, 29)
        Btn_UpdateLacunarity.TabIndex = 34
        Btn_UpdateLacunarity.Text = "Update"
        Btn_UpdateLacunarity.UseVisualStyleBackColor = True
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.BackColor = Color.FromArgb(CByte(54), CByte(69), CByte(79))
        Label8.Font = New Font("Dubai", 12F, FontStyle.Bold Or FontStyle.Underline, GraphicsUnit.Point, CByte(0))
        Label8.ForeColor = SystemColors.ButtonHighlight
        Label8.Location = New Point(1630, 854)
        Label8.Name = "Label8"
        Label8.Size = New Size(150, 34)
        Label8.TabIndex = 59
        Label8.Text = "Route Statistics"
        ' 
        ' Lbl_Length
        ' 
        Lbl_Length.AutoSize = True
        Lbl_Length.BackColor = Color.FromArgb(CByte(54), CByte(69), CByte(79))
        Lbl_Length.Font = New Font("Dubai", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Lbl_Length.ForeColor = SystemColors.ButtonHighlight
        Lbl_Length.Location = New Point(1517, 892)
        Lbl_Length.Name = "Lbl_Length"
        Lbl_Length.Size = New Size(116, 34)
        Lbl_Length.TabIndex = 60
        Lbl_Length.Text = "Length: ----"
        ' 
        ' Lbl_MaxElevation
        ' 
        Lbl_MaxElevation.AutoSize = True
        Lbl_MaxElevation.BackColor = Color.FromArgb(CByte(54), CByte(69), CByte(79))
        Lbl_MaxElevation.Font = New Font("Dubai", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Lbl_MaxElevation.ForeColor = SystemColors.ButtonHighlight
        Lbl_MaxElevation.Location = New Point(1517, 918)
        Lbl_MaxElevation.Name = "Lbl_MaxElevation"
        Lbl_MaxElevation.Size = New Size(226, 34)
        Lbl_MaxElevation.TabIndex = 61
        Lbl_MaxElevation.Text = "Maximum Elevation: ----"
        ' 
        ' Lbl_MinElevation
        ' 
        Lbl_MinElevation.AutoSize = True
        Lbl_MinElevation.BackColor = Color.FromArgb(CByte(54), CByte(69), CByte(79))
        Lbl_MinElevation.Font = New Font("Dubai", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Lbl_MinElevation.ForeColor = SystemColors.ButtonHighlight
        Lbl_MinElevation.Location = New Point(1517, 952)
        Lbl_MinElevation.Name = "Lbl_MinElevation"
        Lbl_MinElevation.Size = New Size(222, 34)
        Lbl_MinElevation.TabIndex = 62
        Lbl_MinElevation.Text = "Minimum Elevation: ----"
        ' 
        ' Lbl_TotalElevation
        ' 
        Lbl_TotalElevation.AutoSize = True
        Lbl_TotalElevation.BackColor = Color.FromArgb(CByte(54), CByte(69), CByte(79))
        Lbl_TotalElevation.Font = New Font("Dubai", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Lbl_TotalElevation.ForeColor = SystemColors.ButtonHighlight
        Lbl_TotalElevation.Location = New Point(1517, 986)
        Lbl_TotalElevation.Name = "Lbl_TotalElevation"
        Lbl_TotalElevation.Size = New Size(186, 34)
        Lbl_TotalElevation.TabIndex = 63
        Lbl_TotalElevation.Text = "Total Elevation: ----"
        ' 
        ' Lbl_Duration
        ' 
        Lbl_Duration.AutoSize = True
        Lbl_Duration.BackColor = Color.FromArgb(CByte(54), CByte(69), CByte(79))
        Lbl_Duration.Font = New Font("Dubai", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Lbl_Duration.ForeColor = SystemColors.ButtonHighlight
        Lbl_Duration.Location = New Point(1517, 1020)
        Lbl_Duration.Name = "Lbl_Duration"
        Lbl_Duration.Size = New Size(133, 34)
        Lbl_Duration.TabIndex = 64
        Lbl_Duration.Text = "Duration: ----"
        ' 
        ' PictureBox5
        ' 
        PictureBox5.BackColor = Color.FromArgb(CByte(54), CByte(69), CByte(79))
        PictureBox5.Location = New Point(1487, 854)
        PictureBox5.Name = "PictureBox5"
        PictureBox5.Size = New Size(412, 200)
        PictureBox5.TabIndex = 58
        PictureBox5.TabStop = False
        ' 
        ' Lbl_Elevation
        ' 
        Lbl_Elevation.AutoSize = True
        Lbl_Elevation.BackColor = Color.Transparent
        Lbl_Elevation.Font = New Font("Dubai", 8F, FontStyle.Bold)
        Lbl_Elevation.ForeColor = SystemColors.ButtonHighlight
        Lbl_Elevation.Location = New Point(307, 849)
        Lbl_Elevation.Name = "Lbl_Elevation"
        Lbl_Elevation.Size = New Size(92, 24)
        Lbl_Elevation.TabIndex = 65
        Lbl_Elevation.Text = "Elevation (m)"
        ' 
        ' Lbl_Distance
        ' 
        Lbl_Distance.AutoSize = True
        Lbl_Distance.BackColor = Color.Transparent
        Lbl_Distance.Font = New Font("Dubai", 8F, FontStyle.Bold)
        Lbl_Distance.ForeColor = SystemColors.ButtonHighlight
        Lbl_Distance.Location = New Point(1379, 1029)
        Lbl_Distance.Name = "Lbl_Distance"
        Lbl_Distance.Size = New Size(94, 24)
        Lbl_Distance.TabIndex = 66
        Lbl_Distance.Text = "Distance (km)"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.FromArgb(CByte(0), CByte(70), CByte(120))
        Label3.Font = New Font("Dubai", 8F)
        Label3.ForeColor = SystemColors.ButtonHighlight
        Label3.Location = New Point(11, 120)
        Label3.Name = "Label3"
        Label3.Size = New Size(182, 24)
        Label3.TabIndex = 67
        Label3.Text = "ⓘ Toggle rotation of the mesh"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.FromArgb(CByte(0), CByte(70), CByte(120))
        Label2.Font = New Font("Dubai", 8F)
        Label2.ForeColor = SystemColors.ButtonHighlight
        Label2.Location = New Point(12, 209)
        Label2.Name = "Label2"
        Label2.Size = New Size(146, 48)
        Label2.TabIndex = 68
        Label2.Text = "ⓘ Reset the mesh to its " & vbCrLf & "    defult oreientation"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.FromArgb(CByte(0), CByte(70), CByte(120))
        Label4.Font = New Font("Dubai", 8F)
        Label4.ForeColor = SystemColors.ButtonHighlight
        Label4.Location = New Point(11, 326)
        Label4.Name = "Label4"
        Label4.Size = New Size(220, 48)
        Label4.TabIndex = 69
        Label4.Text = "ⓘ  Create a new random terrain map " & vbCrLf & "      bound by all specified paramiters"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.FromArgb(CByte(0), CByte(70), CByte(120))
        Label5.Font = New Font("Dubai", 8F)
        Label5.ForeColor = SystemColors.ButtonHighlight
        Label5.Location = New Point(10, 445)
        Label5.Name = "Label5"
        Label5.Size = New Size(263, 72)
        Label5.TabIndex = 70
        Label5.Text = "ⓘ  Will determine how dramatic the" & vbCrLf & "      landscape looks - must be an integer value" & vbCrLf & "        between 1 and 60"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.BackColor = Color.FromArgb(CByte(0), CByte(70), CByte(120))
        Label6.Font = New Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.ForeColor = SystemColors.ButtonHighlight
        Label6.ImageAlign = ContentAlignment.TopCenter
        Label6.Location = New Point(10, 376)
        Label6.Name = "Label6"
        Label6.Size = New Size(148, 34)
        Label6.TabIndex = 71
        Label6.Text = "Extremity Value:"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.BackColor = Color.FromArgb(CByte(0), CByte(70), CByte(120))
        Label7.Font = New Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.ForeColor = SystemColors.ButtonHighlight
        Label7.ImageAlign = ContentAlignment.TopCenter
        Label7.Location = New Point(10, 662)
        Label7.Name = "Label7"
        Label7.Size = New Size(153, 34)
        Label7.TabIndex = 72
        Label7.Text = "Lacunarity Value:"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.BackColor = Color.FromArgb(CByte(0), CByte(70), CByte(120))
        Label9.Font = New Font("Dubai", 8F)
        Label9.ForeColor = SystemColors.ButtonHighlight
        Label9.Location = New Point(9, 733)
        Label9.Name = "Label9"
        Label9.Size = New Size(244, 96)
        Label9.TabIndex = 73
        Label9.Text = "ⓘ  Determines how much weight each " & vbCrLf & "    octave carries in the overall mesh in " & vbCrLf & "    relation its previous - must be a decimal" & vbCrLf & "    value between 0 and 1"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.BackColor = Color.FromArgb(CByte(0), CByte(70), CByte(120))
        Label10.Font = New Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label10.ForeColor = SystemColors.ButtonHighlight
        Label10.ImageAlign = ContentAlignment.TopCenter
        Label10.Location = New Point(9, 519)
        Label10.Name = "Label10"
        Label10.Size = New Size(145, 34)
        Label10.TabIndex = 74
        Label10.Text = "Octave Number:"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.BackColor = Color.FromArgb(CByte(0), CByte(70), CByte(120))
        Label11.Font = New Font("Dubai", 8F)
        Label11.ForeColor = SystemColors.ButtonHighlight
        Label11.Location = New Point(12, 612)
        Label11.Name = "Label11"
        Label11.Size = New Size(256, 48)
        Label11.TabIndex = 75
        Label11.Text = "ⓘ  Increment/derement the number" & vbCrLf & "      of layers of terrain that overlay the mesh"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.BackColor = Color.FromArgb(CByte(0), CByte(70), CByte(120))
        Label12.Font = New Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label12.ForeColor = SystemColors.ButtonHighlight
        Label12.ImageAlign = ContentAlignment.TopCenter
        Label12.Location = New Point(11, 839)
        Label12.Name = "Label12"
        Label12.Size = New Size(152, 34)
        Label12.TabIndex = 76
        Label12.Text = "Angle of horizon:"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.BackColor = Color.FromArgb(CByte(0), CByte(70), CByte(120))
        Label13.Font = New Font("Dubai", 8F)
        Label13.ForeColor = SystemColors.ButtonHighlight
        Label13.Location = New Point(7, 911)
        Label13.Name = "Label13"
        Label13.Size = New Size(262, 72)
        Label13.TabIndex = 77
        Label13.Text = "ⓘ  Determines the angle of slant of the mesh" & vbCrLf & "   - must be an integer value between 15 and " & vbCrLf & "     180 exclusive"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1924, 1055)
        Controls.Add(Label13)
        Controls.Add(Label12)
        Controls.Add(Label11)
        Controls.Add(Label10)
        Controls.Add(Label9)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label2)
        Controls.Add(Label3)
        Controls.Add(Lbl_Distance)
        Controls.Add(Lbl_Elevation)
        Controls.Add(Lbl_Duration)
        Controls.Add(Lbl_TotalElevation)
        Controls.Add(Lbl_MinElevation)
        Controls.Add(Lbl_MaxElevation)
        Controls.Add(Lbl_Length)
        Controls.Add(Label8)
        Controls.Add(PictureBox5)
        Controls.Add(Btn_UpdateLacunarity)
        Controls.Add(Txt_Lacunarity)
        Controls.Add(Btn_OctaveUp)
        Controls.Add(Btn_OctaveDown)
        Controls.Add(Btn_UpdateAngle)
        Controls.Add(Txt_Angle)
        Controls.Add(Btn_UpdateExtremity)
        Controls.Add(Txt_Extremity)
        Controls.Add(PictureBox4)
        Controls.Add(PictureBox3)
        Controls.Add(PictureBox10)
        Controls.Add(PictureBox9)
        Controls.Add(PictureBox8)
        Controls.Add(PictureBox7)
        Controls.Add(Label1)
        Controls.Add(Btn_Hide)
        Controls.Add(Btn_Orbit)
        Controls.Add(Btn_Regenerate)
        Controls.Add(Btn_Reset)
        Controls.Add(PictureBox1)
        Controls.Add(PictureBox2)
        Name = "Form1"
        Text = "t2"
        WindowState = FormWindowState.Maximized
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox10, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox9, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox8, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox7, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox5, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Btn_Reset As Button
    Friend WithEvents Btn_Regenerate As Button
    Friend WithEvents Btn_Orbit As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Btn_Hide As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox10 As PictureBox
    Friend WithEvents PictureBox9 As PictureBox
    Friend WithEvents PictureBox8 As PictureBox
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents Txt_Extremity As TextBox
    Friend WithEvents Btn_UpdateExtremity As Button
    Friend WithEvents Txt_Angle As TextBox
    Friend WithEvents Btn_UpdateAngle As Button
    Friend WithEvents Btn_OctaveDown As Button
    Friend WithEvents Btn_OctaveUp As Button
    Friend WithEvents Txt_Lacunarity As TextBox
    Friend WithEvents Btn_UpdateLacunarity As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents Lbl_Length As Label
    Friend WithEvents Lbl_MaxElevation As Label
    Friend WithEvents Lbl_MinElevation As Label
    Friend WithEvents Lbl_TotalElevation As Label
    Friend WithEvents Lbl_Duration As Label
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents Lbl_Elevation As Label
    Friend WithEvents Lbl_Distance As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label

End Class

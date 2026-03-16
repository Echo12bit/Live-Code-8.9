<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Label1 = New Label()
        Btn_Export = New Button()
        Timer1 = New Timer(components)
        PictureBox3 = New PictureBox()
        PictureBox4 = New PictureBox()
        PictureBox7 = New PictureBox()
        PictureBox8 = New PictureBox()
        PictureBox9 = New PictureBox()
        PictureBox10 = New PictureBox()
        Btn_Exit = New Button()
        StartNode = New Button()
        EndNode = New Button()
        Btn_Generate = New Button()
        Btn_Clear = New Button()
        Btn_WidthDown = New Button()
        Btn_DepthDown = New Button()
        Btn_WidthUp = New Button()
        Btn_DepthUp = New Button()
        Lbl_MapSize = New Label()
        MeshFuctions = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        PictureBox11 = New PictureBox()
        Label5 = New Label()
        Label6 = New Label()
        PictureBox1 = New PictureBox()
        PictureBox2 = New PictureBox()
        Label7 = New Label()
        Btn_RouteColouring = New Button()
        Btn_Preferances = New Button()
        PictureBox5 = New PictureBox()
        Label8 = New Label()
        Lbl_Length = New Label()
        Lbl_MaxElevation = New Label()
        Lbl_MinElevation = New Label()
        Lbl_TotalElevation = New Label()
        Lbl_Duration = New Label()
        Lbl_Distance = New Label()
        Lbl_Elevation = New Label()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox7, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox8, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox9, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox10, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox11, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox5, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.FromArgb(CByte(0), CByte(70), CByte(120))
        Label1.Font = New Font("Arial", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = SystemColors.ButtonHighlight
        Label1.Location = New Point(12, 19)
        Label1.Name = "Label1"
        Label1.Size = New Size(285, 39)
        Label1.TabIndex = 2
        Label1.Text = "EIGER MESH 3D"
        ' 
        ' Btn_Export
        ' 
        Btn_Export.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Btn_Export.Location = New Point(20, 893)
        Btn_Export.Name = "Btn_Export"
        Btn_Export.Size = New Size(206, 57)
        Btn_Export.TabIndex = 3
        Btn_Export.Text = "3D Export"
        Btn_Export.UseVisualStyleBackColor = True
        ' 
        ' Timer1
        ' 
        Timer1.Interval = 1
        ' 
        ' PictureBox3
        ' 
        PictureBox3.BackColor = Color.Yellow
        PictureBox3.Location = New Point(463, 110)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(5, 342)
        PictureBox3.TabIndex = 6
        PictureBox3.TabStop = False
        ' 
        ' PictureBox4
        ' 
        PictureBox4.BackColor = Color.Yellow
        PictureBox4.Location = New Point(492, 110)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(5, 342)
        PictureBox4.TabIndex = 12
        PictureBox4.TabStop = False
        ' 
        ' PictureBox7
        ' 
        PictureBox7.BackColor = Color.Yellow
        PictureBox7.Location = New Point(628, 110)
        PictureBox7.Name = "PictureBox7"
        PictureBox7.Size = New Size(5, 342)
        PictureBox7.TabIndex = 15
        PictureBox7.TabStop = False
        ' 
        ' PictureBox8
        ' 
        PictureBox8.BackColor = Color.Yellow
        PictureBox8.Location = New Point(663, 110)
        PictureBox8.Name = "PictureBox8"
        PictureBox8.Size = New Size(5, 342)
        PictureBox8.TabIndex = 16
        PictureBox8.TabStop = False
        ' 
        ' PictureBox9
        ' 
        PictureBox9.BackColor = Color.Yellow
        PictureBox9.Location = New Point(695, 110)
        PictureBox9.Name = "PictureBox9"
        PictureBox9.Size = New Size(5, 342)
        PictureBox9.TabIndex = 17
        PictureBox9.TabStop = False
        ' 
        ' PictureBox10
        ' 
        PictureBox10.BackColor = Color.Yellow
        PictureBox10.Location = New Point(733, 110)
        PictureBox10.Name = "PictureBox10"
        PictureBox10.Size = New Size(5, 342)
        PictureBox10.TabIndex = 18
        PictureBox10.TabStop = False
        ' 
        ' Btn_Exit
        ' 
        Btn_Exit.Location = New Point(20, 956)
        Btn_Exit.Name = "Btn_Exit"
        Btn_Exit.Size = New Size(206, 57)
        Btn_Exit.TabIndex = 19
        Btn_Exit.Text = "Exit"
        Btn_Exit.UseVisualStyleBackColor = True
        ' 
        ' StartNode
        ' 
        StartNode.BackColor = Color.Lime
        StartNode.FlatStyle = FlatStyle.Flat
        StartNode.Location = New Point(347, 191)
        StartNode.Name = "StartNode"
        StartNode.Size = New Size(94, 29)
        StartNode.TabIndex = 20
        StartNode.UseVisualStyleBackColor = False
        ' 
        ' EndNode
        ' 
        EndNode.BackColor = Color.Red
        EndNode.FlatStyle = FlatStyle.Flat
        EndNode.Location = New Point(326, 299)
        EndNode.Name = "EndNode"
        EndNode.Size = New Size(94, 29)
        EndNode.TabIndex = 21
        EndNode.UseVisualStyleBackColor = False
        ' 
        ' Btn_Generate
        ' 
        Btn_Generate.Location = New Point(20, 535)
        Btn_Generate.Name = "Btn_Generate"
        Btn_Generate.Size = New Size(206, 63)
        Btn_Generate.TabIndex = 22
        Btn_Generate.Text = "Generate"
        Btn_Generate.UseVisualStyleBackColor = True
        ' 
        ' Btn_Clear
        ' 
        Btn_Clear.Location = New Point(20, 605)
        Btn_Clear.Name = "Btn_Clear"
        Btn_Clear.Size = New Size(206, 63)
        Btn_Clear.TabIndex = 26
        Btn_Clear.Text = "Clear"
        Btn_Clear.UseVisualStyleBackColor = True
        ' 
        ' Btn_WidthDown
        ' 
        Btn_WidthDown.BackColor = SystemColors.ButtonHighlight
        Btn_WidthDown.Font = New Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Btn_WidthDown.Location = New Point(12, 122)
        Btn_WidthDown.Name = "Btn_WidthDown"
        Btn_WidthDown.Size = New Size(54, 51)
        Btn_WidthDown.TabIndex = 27
        Btn_WidthDown.Text = "-"
        Btn_WidthDown.TextAlign = ContentAlignment.TopCenter
        Btn_WidthDown.UseVisualStyleBackColor = False
        ' 
        ' Btn_DepthDown
        ' 
        Btn_DepthDown.Font = New Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Btn_DepthDown.Location = New Point(12, 191)
        Btn_DepthDown.Name = "Btn_DepthDown"
        Btn_DepthDown.Size = New Size(54, 51)
        Btn_DepthDown.TabIndex = 29
        Btn_DepthDown.Text = "-"
        Btn_DepthDown.TextAlign = ContentAlignment.TopCenter
        Btn_DepthDown.UseVisualStyleBackColor = True
        ' 
        ' Btn_WidthUp
        ' 
        Btn_WidthUp.Font = New Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Btn_WidthUp.Location = New Point(72, 122)
        Btn_WidthUp.Name = "Btn_WidthUp"
        Btn_WidthUp.Size = New Size(54, 51)
        Btn_WidthUp.TabIndex = 30
        Btn_WidthUp.Text = "+"
        Btn_WidthUp.TextAlign = ContentAlignment.TopCenter
        Btn_WidthUp.UseVisualStyleBackColor = True
        ' 
        ' Btn_DepthUp
        ' 
        Btn_DepthUp.Font = New Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Btn_DepthUp.Location = New Point(72, 191)
        Btn_DepthUp.Name = "Btn_DepthUp"
        Btn_DepthUp.Size = New Size(54, 51)
        Btn_DepthUp.TabIndex = 31
        Btn_DepthUp.Text = "+"
        Btn_DepthUp.TextAlign = ContentAlignment.TopCenter
        Btn_DepthUp.UseVisualStyleBackColor = True
        ' 
        ' Lbl_MapSize
        ' 
        Lbl_MapSize.AutoSize = True
        Lbl_MapSize.BackColor = Color.FromArgb(CByte(0), CByte(70), CByte(120))
        Lbl_MapSize.BorderStyle = BorderStyle.FixedSingle
        Lbl_MapSize.Font = New Font("Dubai", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Lbl_MapSize.ForeColor = SystemColors.ButtonHighlight
        Lbl_MapSize.Location = New Point(12, 259)
        Lbl_MapSize.Name = "Lbl_MapSize"
        Lbl_MapSize.Size = New Size(82, 41)
        Lbl_MapSize.TabIndex = 32
        Lbl_MapSize.Text = "Label2"
        ' 
        ' MeshFuctions
        ' 
        MeshFuctions.AutoSize = True
        MeshFuctions.BackColor = Color.FromArgb(CByte(0), CByte(70), CByte(120))
        MeshFuctions.Font = New Font("Dubai", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        MeshFuctions.ForeColor = SystemColors.ButtonHighlight
        MeshFuctions.Location = New Point(72, 72)
        MeshFuctions.Name = "MeshFuctions"
        MeshFuctions.Size = New Size(147, 34)
        MeshFuctions.TabIndex = 33
        MeshFuctions.Text = "MeshFunctions"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.FromArgb(CByte(0), CByte(70), CByte(120))
        Label2.BorderStyle = BorderStyle.FixedSingle
        Label2.Font = New Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = SystemColors.ButtonHighlight
        Label2.ImageAlign = ContentAlignment.TopCenter
        Label2.Location = New Point(137, 133)
        Label2.Name = "Label2"
        Label2.Size = New Size(139, 36)
        Label2.TabIndex = 34
        Label2.Text = "Width Scaleing"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.FromArgb(CByte(0), CByte(70), CByte(120))
        Label3.BorderStyle = BorderStyle.FixedSingle
        Label3.Font = New Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = SystemColors.ButtonHighlight
        Label3.Location = New Point(137, 202)
        Label3.Name = "Label3"
        Label3.Size = New Size(144, 36)
        Label3.TabIndex = 35
        Label3.Text = "Height Scaleing"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.FromArgb(CByte(0), CByte(70), CByte(120))
        Label4.Font = New Font("Dubai", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = SystemColors.ButtonHighlight
        Label4.Location = New Point(72, 354)
        Label4.Name = "Label4"
        Label4.Size = New Size(135, 34)
        Label4.TabIndex = 36
        Label4.Text = "RoutePlotting"
        ' 
        ' PictureBox11
        ' 
        PictureBox11.BackColor = Color.FromArgb(CByte(54), CByte(69), CByte(79))
        PictureBox11.Location = New Point(20, 465)
        PictureBox11.Name = "PictureBox11"
        PictureBox11.Size = New Size(50, 50)
        PictureBox11.TabIndex = 39
        PictureBox11.TabStop = False
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.FromArgb(CByte(0), CByte(70), CByte(120))
        Label5.BorderStyle = BorderStyle.FixedSingle
        Label5.Font = New Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = SystemColors.ButtonHighlight
        Label5.ImageAlign = ContentAlignment.TopCenter
        Label5.Location = New Point(83, 410)
        Label5.Name = "Label5"
        Label5.Size = New Size(167, 36)
        Label5.TabIndex = 42
        Label5.Text = "Intermediate Node"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.BackColor = Color.FromArgb(CByte(0), CByte(70), CByte(120))
        Label6.BorderStyle = BorderStyle.FixedSingle
        Label6.Font = New Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.ForeColor = SystemColors.ButtonHighlight
        Label6.ImageAlign = ContentAlignment.TopCenter
        Label6.Location = New Point(151, 459)
        Label6.Name = "Label6"
        Label6.Size = New Size(96, 70)
        Label6.TabIndex = 43
        Label6.Text = "Start +" & vbCrLf & "End Node"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.FromArgb(CByte(54), CByte(69), CByte(79))
        PictureBox1.Location = New Point(85, 465)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(50, 50)
        PictureBox1.TabIndex = 44
        PictureBox1.TabStop = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.FromArgb(CByte(54), CByte(69), CByte(79))
        PictureBox2.Location = New Point(20, 400)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(50, 50)
        PictureBox2.TabIndex = 45
        PictureBox2.TabStop = False
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.BackColor = Color.FromArgb(CByte(0), CByte(70), CByte(120))
        Label7.Font = New Font("Dubai", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.ForeColor = SystemColors.ButtonHighlight
        Label7.Location = New Point(72, 752)
        Label7.Name = "Label7"
        Label7.Size = New Size(125, 34)
        Label7.TabIndex = 47
        Label7.Text = "UI Functions"
        ' 
        ' Btn_RouteColouring
        ' 
        Btn_RouteColouring.Location = New Point(20, 674)
        Btn_RouteColouring.Name = "Btn_RouteColouring"
        Btn_RouteColouring.Size = New Size(206, 63)
        Btn_RouteColouring.TabIndex = 48
        Btn_RouteColouring.Text = "Colouring"
        Btn_RouteColouring.UseVisualStyleBackColor = True
        ' 
        ' Btn_Preferances
        ' 
        Btn_Preferances.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Btn_Preferances.Location = New Point(20, 830)
        Btn_Preferances.Name = "Btn_Preferances"
        Btn_Preferances.Size = New Size(206, 57)
        Btn_Preferances.TabIndex = 49
        Btn_Preferances.Text = "Preferances"
        Btn_Preferances.UseVisualStyleBackColor = True
        ' 
        ' PictureBox5
        ' 
        PictureBox5.BackColor = Color.FromArgb(CByte(54), CByte(69), CByte(79))
        PictureBox5.Location = New Point(1479, 855)
        PictureBox5.Name = "PictureBox5"
        PictureBox5.Size = New Size(412, 200)
        PictureBox5.TabIndex = 50
        PictureBox5.TabStop = False
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.BackColor = Color.FromArgb(CByte(54), CByte(69), CByte(79))
        Label8.Font = New Font("Dubai", 12F, FontStyle.Bold Or FontStyle.Underline, GraphicsUnit.Point, CByte(0))
        Label8.ForeColor = SystemColors.ButtonHighlight
        Label8.Location = New Point(1622, 855)
        Label8.Name = "Label8"
        Label8.Size = New Size(150, 34)
        Label8.TabIndex = 51
        Label8.Text = "Route Statistics"
        ' 
        ' Lbl_Length
        ' 
        Lbl_Length.AutoSize = True
        Lbl_Length.BackColor = Color.FromArgb(CByte(54), CByte(69), CByte(79))
        Lbl_Length.Font = New Font("Dubai", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Lbl_Length.ForeColor = SystemColors.ButtonHighlight
        Lbl_Length.Location = New Point(1509, 893)
        Lbl_Length.Name = "Lbl_Length"
        Lbl_Length.Size = New Size(116, 34)
        Lbl_Length.TabIndex = 52
        Lbl_Length.Text = "Length: ----"
        ' 
        ' Lbl_MaxElevation
        ' 
        Lbl_MaxElevation.AutoSize = True
        Lbl_MaxElevation.BackColor = Color.FromArgb(CByte(54), CByte(69), CByte(79))
        Lbl_MaxElevation.Font = New Font("Dubai", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Lbl_MaxElevation.ForeColor = SystemColors.ButtonHighlight
        Lbl_MaxElevation.Location = New Point(1509, 919)
        Lbl_MaxElevation.Name = "Lbl_MaxElevation"
        Lbl_MaxElevation.Size = New Size(226, 34)
        Lbl_MaxElevation.TabIndex = 53
        Lbl_MaxElevation.Text = "Maximum Elevation: ----"
        ' 
        ' Lbl_MinElevation
        ' 
        Lbl_MinElevation.AutoSize = True
        Lbl_MinElevation.BackColor = Color.FromArgb(CByte(54), CByte(69), CByte(79))
        Lbl_MinElevation.Font = New Font("Dubai", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Lbl_MinElevation.ForeColor = SystemColors.ButtonHighlight
        Lbl_MinElevation.Location = New Point(1509, 953)
        Lbl_MinElevation.Name = "Lbl_MinElevation"
        Lbl_MinElevation.Size = New Size(222, 34)
        Lbl_MinElevation.TabIndex = 54
        Lbl_MinElevation.Text = "Minimum Elevation: ----"
        ' 
        ' Lbl_TotalElevation
        ' 
        Lbl_TotalElevation.AutoSize = True
        Lbl_TotalElevation.BackColor = Color.FromArgb(CByte(54), CByte(69), CByte(79))
        Lbl_TotalElevation.Font = New Font("Dubai", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Lbl_TotalElevation.ForeColor = SystemColors.ButtonHighlight
        Lbl_TotalElevation.Location = New Point(1509, 987)
        Lbl_TotalElevation.Name = "Lbl_TotalElevation"
        Lbl_TotalElevation.Size = New Size(186, 34)
        Lbl_TotalElevation.TabIndex = 55
        Lbl_TotalElevation.Text = "Total Elevation: ----"
        ' 
        ' Lbl_Duration
        ' 
        Lbl_Duration.AutoSize = True
        Lbl_Duration.BackColor = Color.FromArgb(CByte(54), CByte(69), CByte(79))
        Lbl_Duration.Font = New Font("Dubai", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Lbl_Duration.ForeColor = SystemColors.ButtonHighlight
        Lbl_Duration.Location = New Point(1509, 1021)
        Lbl_Duration.Name = "Lbl_Duration"
        Lbl_Duration.Size = New Size(133, 34)
        Lbl_Duration.TabIndex = 56
        Lbl_Duration.Text = "Duration: ----"
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
        Lbl_Distance.TabIndex = 57
        Lbl_Distance.Text = "Distance (km)"
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
        Lbl_Elevation.TabIndex = 58
        Lbl_Elevation.Text = "Elevation (m)"
        ' 
        ' Form2
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1924, 1055)
        Controls.Add(Lbl_Elevation)
        Controls.Add(Lbl_Distance)
        Controls.Add(Lbl_Duration)
        Controls.Add(Lbl_TotalElevation)
        Controls.Add(Lbl_MinElevation)
        Controls.Add(Lbl_MaxElevation)
        Controls.Add(Lbl_Length)
        Controls.Add(Label8)
        Controls.Add(PictureBox5)
        Controls.Add(Btn_Preferances)
        Controls.Add(Btn_RouteColouring)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(MeshFuctions)
        Controls.Add(Lbl_MapSize)
        Controls.Add(Btn_DepthUp)
        Controls.Add(Btn_WidthUp)
        Controls.Add(Btn_DepthDown)
        Controls.Add(Btn_WidthDown)
        Controls.Add(Btn_Clear)
        Controls.Add(Btn_Generate)
        Controls.Add(EndNode)
        Controls.Add(StartNode)
        Controls.Add(Btn_Exit)
        Controls.Add(PictureBox4)
        Controls.Add(PictureBox3)
        Controls.Add(PictureBox10)
        Controls.Add(PictureBox9)
        Controls.Add(PictureBox8)
        Controls.Add(PictureBox7)
        Controls.Add(Btn_Export)
        Controls.Add(Label1)
        Controls.Add(PictureBox1)
        Controls.Add(PictureBox11)
        Controls.Add(PictureBox2)
        Name = "Form2"
        Text = "2D Window"
        WindowState = FormWindowState.Maximized
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox7, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox8, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox9, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox10, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox11, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox5, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Btn_Export As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents PictureBox8 As PictureBox
    Friend WithEvents PictureBox9 As PictureBox
    Friend WithEvents PictureBox10 As PictureBox
    Friend WithEvents Btn_Exit As Button
    Friend WithEvents StartNode As Button
    Friend WithEvents EndNode As Button
    Friend WithEvents Btn_Generate As Button
    Friend WithEvents Btn_Clear As Button
    Friend WithEvents Btn_WidthDown As Button
    Friend WithEvents Btn_DepthDown As Button
    Friend WithEvents Btn_WidthUp As Button
    Friend WithEvents Btn_DepthUp As Button
    Friend WithEvents Lbl_MapSize As Label
    Friend WithEvents MeshFuctions As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents PictureBox11 As PictureBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Btn_RouteColouring As Button
    Friend WithEvents Btn_Preferances As Button
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Lbl_Length As Label
    Friend WithEvents Lbl_MaxElevation As Label
    Friend WithEvents Lbl_MinElevation As Label
    Friend WithEvents Lbl_TotalElevation As Label
    Friend WithEvents Lbl_Duration As Label
    Friend WithEvents Lbl_Distance As Label
    Friend WithEvents Lbl_Elevation As Label
End Class

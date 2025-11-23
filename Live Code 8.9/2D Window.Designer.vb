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
        PictureBox1 = New PictureBox()
        Label1 = New Label()
        Btn_Export = New Button()
        Timer1 = New Timer(components)
        PictureBox2 = New PictureBox()
        PictureBox3 = New PictureBox()
        PictureBox4 = New PictureBox()
        PictureBox5 = New PictureBox()
        PictureBox6 = New PictureBox()
        PictureBox7 = New PictureBox()
        PictureBox8 = New PictureBox()
        PictureBox9 = New PictureBox()
        PictureBox10 = New PictureBox()
        Btn_Exit = New Button()
        StartNode = New Button()
        EndNode = New Button()
        Btn_Generate = New Button()
        Btn_Clear = New Button()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox5, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox6, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox7, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox8, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox9, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox10, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.FromArgb(CByte(0), CByte(70), CByte(120))
        PictureBox1.Location = New Point(5, 5)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(277, 710)
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.FromArgb(CByte(0), CByte(70), CByte(120))
        Label1.Font = New Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = SystemColors.ButtonHighlight
        Label1.Location = New Point(12, 26)
        Label1.Name = "Label1"
        Label1.Size = New Size(249, 35)
        Label1.TabIndex = 2
        Label1.Text = "EIGER MESH 3D"
        ' 
        ' Btn_Export
        ' 
        Btn_Export.Location = New Point(12, 122)
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
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.FromArgb(CByte(0), CByte(70), CByte(120))
        PictureBox2.Location = New Point(326, 572)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(960, 98)
        PictureBox2.TabIndex = 5
        PictureBox2.TabStop = False
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
        ' PictureBox5
        ' 
        PictureBox5.BackColor = Color.Yellow
        PictureBox5.Location = New Point(533, 110)
        PictureBox5.Name = "PictureBox5"
        PictureBox5.Size = New Size(5, 342)
        PictureBox5.TabIndex = 13
        PictureBox5.TabStop = False
        ' 
        ' PictureBox6
        ' 
        PictureBox6.BackColor = Color.Yellow
        PictureBox6.Location = New Point(579, 110)
        PictureBox6.Name = "PictureBox6"
        PictureBox6.Size = New Size(5, 342)
        PictureBox6.TabIndex = 14
        PictureBox6.TabStop = False
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
        Btn_Exit.Location = New Point(12, 323)
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
        StartNode.Location = New Point(326, 254)
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
        Btn_Generate.Location = New Point(12, 185)
        Btn_Generate.Name = "Btn_Generate"
        Btn_Generate.Size = New Size(206, 63)
        Btn_Generate.TabIndex = 22
        Btn_Generate.Text = "Generate"
        Btn_Generate.UseVisualStyleBackColor = True
        ' 
        ' Btn_Clear
        ' 
        Btn_Clear.Location = New Point(12, 254)
        Btn_Clear.Name = "Btn_Clear"
        Btn_Clear.Size = New Size(206, 63)
        Btn_Clear.TabIndex = 26
        Btn_Clear.Text = "Clear"
        Btn_Clear.UseVisualStyleBackColor = True
        ' 
        ' Form2
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1320, 703)
        Controls.Add(Btn_Clear)
        Controls.Add(Btn_Generate)
        Controls.Add(EndNode)
        Controls.Add(StartNode)
        Controls.Add(Btn_Exit)
        Controls.Add(PictureBox5)
        Controls.Add(PictureBox4)
        Controls.Add(PictureBox3)
        Controls.Add(PictureBox10)
        Controls.Add(PictureBox9)
        Controls.Add(PictureBox8)
        Controls.Add(PictureBox7)
        Controls.Add(PictureBox6)
        Controls.Add(Btn_Export)
        Controls.Add(Label1)
        Controls.Add(PictureBox1)
        Controls.Add(PictureBox2)
        Name = "Form2"
        Text = "2D Window"
        WindowState = FormWindowState.Maximized
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox5, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox6, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox7, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox8, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox9, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox10, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Btn_Export As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents PictureBox8 As PictureBox
    Friend WithEvents PictureBox9 As PictureBox
    Friend WithEvents PictureBox10 As PictureBox
    Friend WithEvents Btn_Exit As Button
    Friend WithEvents StartNode As Button
    Friend WithEvents EndNode As Button
    Friend WithEvents Btn_Generate As Button
    Friend WithEvents Btn_Clear As Button
End Class

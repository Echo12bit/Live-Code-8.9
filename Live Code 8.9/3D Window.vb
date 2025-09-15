Imports System
Imports System.Math
Imports System.Threading
Imports Live_Code_8._9.Form1

Module Globals3D
    Public OGPointArray(100, 100) As Point3D
    Public XpArray(100, 100) As Double
    Public YpArray(100, 100) As Double
    Public NewPointArray(100, 100) As Point
    Public YValue(100, 100) As Double


    Public Const MapWidth As Integer = 49     'Must be an odd number 
    Public Const MapDepth As Integer = 29     'Must be an odd number
    Public Const PointIncr As Integer = 5
    Public Const StartX As Integer = ((MapWidth / 2) * PointIncr * -1)
    Public Const StartZ As Integer = (MapDepth / 2) * PointIncr

End Module
Public Class Form1
    Dim rnd As New Random()

    Dim AngleY As Double = 0
    Dim AngleX As Double = 0
    Const A As Double = PI / 4
    'Must be an odd number 

    Dim GridPen As New Pen(Color.IndianRed, 0.5)
    Dim MiddleBlue As Color = Color.FromArgb(86, 108, 242)
    Dim BetweenMiddleAndLightBlue As Color = Color.FromArgb(130, 162, 236)

    Dim MouseZoom As Double = 0

    Dim LeftClickDetect As Boolean = False
    Dim RightClickDetect As Boolean = False
    Dim MouseDragging As Boolean = False
    Dim OGMouseLocation As Point

    Dim OrbitSwitch As Boolean = False

    Dim Switch As Boolean = False
    Dim LB As Integer = 3
    Dim UB As Integer = 4


    Structure Point3D
        Public X As Double
        Public Y As Double
        Public Z As Double

        Public Sub New(x As Double, y As Double, z As Double)
            Me.X = x
            Me.Y = y
            Me.Z = z
        End Sub

    End Structure

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form2.Show()
        Me.Hide()
        PictureBox1.Size = New Size(300, Me.Height)
        PictureBox2.Location = New Point(0, Me.Height - 200)

        Me.FormBorderStyle = FormBorderStyle.None   ' Remove borders/title bar
        Me.Size = New Size(1600, 800)
        Me.DoubleBuffered = True

        PictureBox1.Location = New Point(0, 0)
        PictureBox1.Size = New Size(300, Me.Height + 42)
        PictureBox2.Location = New Point(300, (Me.Height + 42) - 240)
        PictureBox2.Size = New Size(Me.Width, 240)
        PictureBox3.Location = New Point(0, 0)
        PictureBox3.Size = New Size(5, Me.Height + 42)
        PictureBox4.Location = New Point(300, 0)
        PictureBox4.Size = New Size(5, Me.Height + 42)
        PictureBox5.Location = New Point(800, (Me.Height + 42) - 240)
        PictureBox5.Size = New Size(5, 240)
        PictureBox6.Location = New Point(1400, (Me.Height + 42) - 240)
        PictureBox6.Size = New Size(5, 240)
        PictureBox7.Location = New Point(Me.Width - 23, 0)
        PictureBox7.Size = New Size(5, Me.Height + 42)
        PictureBox8.Location = New Point(0, 0)
        PictureBox8.Size = New Size(Me.Width, 5)
        PictureBox9.Location = New Point(300, (Me.Height + 42) - 245)
        PictureBox9.Size = New Size(Me.Width, 5)
        PictureBox10.Location = New Point(0, Me.Height + 37)
        PictureBox10.Size = New Size(Me.Width, 5)


        For j = 0 To MapDepth
            For i = 0 To MapWidth
                YValue(i, j) = NotPerlinNoise(i, j)
                OGPointArray(i, j) = New Point3D((StartX) + (i * PointIncr), YValue(i, j), StartZ - (j * PointIncr))
            Next
        Next

        PPand2DArray()
    End Sub
    Sub PPand2DArray()
        PerspectiveProjection()

        For j = 0 To MapDepth
            For i = 0 To MapWidth
                NewPointArray(i, j) = New Point(XpArray(i, j) + Me.Width / 2, YpArray(i, j))
            Next
        Next
    End Sub
    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        e.Graphics.Clear(Color.Black)


        For j = 0 To MapDepth
            For i = 0 To MapWidth - 1
                GridPen.Color = ColorGradient(i, j)
                GridPen.Width = 0.5
                If PathMark(i, j) = True And PathMark(i + 1, j) = True Then
                    GridPen.Color = Color.Yellow
                    GridPen.Width = 2
                End If
                e.Graphics.DrawLine(GridPen, NewPointArray(i, j), NewPointArray(i + 1, j))
            Next
        Next

        For i = 0 To MapWidth
            For j = 0 To MapDepth - 1
                GridPen.Color = ColorGradient(i, j)
                GridPen.Width = 0.5
                If PathMark(i, j) = True And PathMark(i, j + 1) = True Then
                    GridPen.Color = Color.Yellow
                    GridPen.Width = 2
                End If
                e.Graphics.DrawLine(GridPen, NewPointArray(i, j), NewPointArray(i, j + 1))
            Next
        Next

        For j = 0 To MapDepth - 1
            For i = 0 To MapWidth - 1
                GridPen.Color = ColorGradient(i, j)
                GridPen.Width = 0.5
                If PathMark(i + 1, j) = True And PathMark(i, j + 1) = True Then
                    GridPen.Color = Color.Yellow
                    GridPen.Width = 2
                End If
                e.Graphics.DrawLine(GridPen, NewPointArray(i + 1, j), NewPointArray(i, j + 1))
            Next
        Next



    End Sub

    Public Function ColorGradient(ByVal i As Integer, ByVal j As Integer) As Color
        If OGPointArray(i, j).Y < 120 Then
            Return Color.LightBlue
        ElseIf OGPointArray(i, j).Y >= 120 And OGPointArray(i, j).Y < 140 Then
            Return BetweenMiddleAndLightBlue
        ElseIf OGPointArray(i, j).Y >= 140 And OGPointArray(i, j).Y < 160 Then
            Return MiddleBlue
        Else
            Return Color.Blue
        End If
    End Function

    Sub PerspectiveProjection()

        For j = 0 To MapDepth
            For i = 0 To MapWidth
                XpArray(i, j) = (OGPointArray(i, j).X / ((OGPointArray(i, j).Z + 200) * Tan(A / 2))) * 200
            Next
        Next

        For j = 0 To MapDepth
            For i = 0 To MapWidth
                YpArray(i, j) = (OGPointArray(i, j).Y / ((OGPointArray(i, j).Z + 200) * Tan(A / 2))) * 200
            Next
        Next


    End Sub


    Function NotPerlinNoise(ByVal i As Integer, ByVal j As Integer) As Integer
        Dim YValue1 As Integer
        Dim YValue2 As Integer
        Dim NewYValue As Integer



        If i = 0 Or i = MapWidth Or j = 0 Or j = MapDepth Then
            NewYValue = 160
            Return NewYValue
        Else
            YValue1 = OGPointArray(i - 1, j).Y
            YValue2 = OGPointArray(i, j - 1).Y
            NewYValue = (YValue1 + YValue2) \ 2

        End If
        If Switch = False Then
            If NewYValue <= 140 Then
                UB += 1

            ElseIf NewYValue >= 170 Then
                UB -= 1
            End If
            Switch = True
        End If

        'Return NewYValue
        Return rnd.Next(NewYValue - LB, NewYValue + UB)
    End Function

    Sub RotateY()
        For j = 0 To MapDepth
            For i = 0 To MapWidth
                Dim TempX As Double = OGPointArray(i, j).X
                Dim TempY As Double = OGPointArray(i, j).Y
                Dim TempZ As Double = OGPointArray(i, j).Z
                OGPointArray(i, j).X = (TempX * Cos(AngleY)) + (TempZ * Sin(AngleY))
                OGPointArray(i, j).Z = (TempZ * Cos(AngleY)) - (TempX * Sin(AngleY))
            Next
        Next

        PPand2DArray()
    End Sub

    Sub RotateX()
        For j = 0 To MapDepth
            For i = 0 To MapWidth
                Dim TempX As Double = OGPointArray(i, j).X
                Dim TempY As Double = OGPointArray(i, j).Y
                Dim TempZ As Double = OGPointArray(i, j).Z
                OGPointArray(i, j).Y = (TempY * Cos(AngleX)) - (TempZ * Sin(AngleX))
                OGPointArray(i, j).Z = (TempY * Sin(AngleX)) + (TempZ * Cos(AngleX))
            Next
        Next

        PPand2DArray()
    End Sub

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        OGMouseLocation = e.Location
        Select Case e.Button
            Case MouseButtons.Left
                LeftClickDetect = True
                MouseDragging = True
            Case MouseButtons.Right
                RightClickDetect = True
                MouseDragging = True
        End Select
    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If MouseDragging Then
            Dim MouseXMovement As Double = OGMouseLocation.X - e.X
            Dim MouseYMovement As Double = OGMouseLocation.Y - e.Y

            If LeftClickDetect = True Then
                AngleY = MouseXMovement * 0.002
                RotateY()
            ElseIf RightClickDetect = True Then
                AngleX = MouseYMovement * 0.002
                RotateX()
            End If

            OGMouseLocation = e.Location
            Me.Invalidate()
        End If
    End Sub

    Private Sub Form1_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        LeftClickDetect = False
        RightClickDetect = False
    End Sub

    Private Sub Form1_MouseWheel(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel
        MouseZoom += e.Delta / 1200

        PPand2DArray()
        Me.Invalidate()
    End Sub

    Private Sub Btn_Reset_Click(sender As Object, e As EventArgs) Handles Btn_Reset.Click
        For j = 0 To MapDepth
            For i = 0 To MapWidth
                OGPointArray(i, j) = New Point3D((StartX) + (i * PointIncr), YValue(i, j), StartZ - (j * PointIncr))
            Next
        Next

        PPand2DArray()
        Me.Invalidate()
    End Sub

    Private Sub Btn_Regenerate_Click(sender As Object, e As EventArgs) Handles Btn_Regenerate.Click
        For j = 0 To MapDepth
            For i = 0 To MapWidth
                YValue(i, j) = NotPerlinNoise(i, j)
                OGPointArray(i, j).Y = YValue(i, j)
            Next
        Next

        PPand2DArray()
        Me.Invalidate()
    End Sub

    Private Sub Btn_Orbit_Click(sender As Object, e As EventArgs) Handles Btn_Orbit.Click
        If OrbitSwitch = False Then
            Timer1.Start()
            OrbitSwitch = True
        Else
            Timer1.Stop()
            OrbitSwitch = False
        End If


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        AngleY = 0.002
        RotateY()
        Me.Invalidate()
    End Sub

    Private Sub Btn_Hide_Click(sender As Object, e As EventArgs) Handles Btn_Hide.Click
        Form2.Show()
        Me.Hide()
    End Sub


End Class

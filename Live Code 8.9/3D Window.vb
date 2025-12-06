Imports System
Imports System.Drawing.Drawing2D
Imports System.Math
Imports System.Threading
Imports Live_Code_8._9.Form1

Module Globals3D

    Public MapWidth As Integer = 40    'Must be an even number
    Public MapDepth As Integer = 40    'Must be an even number
    Public ThreeDScaleFactor As Integer = 5
    Public StartX As Integer = ((MapWidth / 2) * ThreeDScaleFactor * -1)
    Public StartZ As Integer = (MapDepth / 2) * ThreeDScaleFactor

    Public OGPointArray(MapWidth, MapDepth) As Point3D
    Public XpArray(MapWidth, MapDepth) As Double
    Public YpArray(MapWidth, MapDepth) As Double
    Public NewPointArray(MapWidth, MapDepth) As Point
    Public YValue(MapWidth, MapDepth) As Double

    Public ChunkSize As Integer = 5
    Public XChunkAmount As Integer = MapWidth / ChunkSize
    Public ZChunkAmount As Integer = MapDepth / ChunkSize

    Public FinalElevationArray(MapWidth, MapDepth) As Double

    Public TopTriangles(MapWidth, MapDepth)() As Point
    Public BottemTriangles(MapWidth, MapDepth)() As Point


End Module
Public Class Form1
    Dim rnd As New Random()

    Dim AngleY As Double = 0
    Dim AngleX As Double = 0
    Const A As Double = PI / 6
    'Must be an odd number

    Dim GridPen As New Pen(Color.IndianRed, 0.5)
    Dim MiddleBlue As Color = Color.FromArgb(86, 108, 242)
    Dim BetweenMiddleAndLightBlue As Color = Color.FromArgb(130, 162, 236)
    Dim LighterIndianRed As Color = Color.FromArgb(235, 130, 130)

    Dim MouseZoom As Double = 0

    Dim LeftClickDetect As Boolean = False
    Dim RightClickDetect As Boolean = False
    Dim MouseDragging As Boolean = False
    Dim OGMouseLocation As Point

    Dim OrbitSwitch As Boolean = False

    Dim compass As Bitmap
    Dim CompassAngle As Double
    Dim compassBool As Boolean
    Dim TotalAngle As Double



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
        Me.Show()
        Form2.Hide()
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
        'PictureBox5.Location = New Point(800, (Me.Height + 42) - 240)
        'PictureBox5.Size = New Size(5, 240)
        'PictureBox6.Location = New Point(1400, (Me.Height + 42) - 240)
        'PictureBox6.Size = New Size(5, 240)
        PictureBox7.Location = New Point(Me.Width - 23, 0)
        PictureBox7.Size = New Size(5, Me.Height + 42)
        PictureBox8.Location = New Point(0, 0)
        PictureBox8.Size = New Size(Me.Width, 5)
        PictureBox9.Location = New Point(300, (Me.Height + 42) - 245)
        PictureBox9.Size = New Size(Me.Width, 5)
        PictureBox10.Location = New Point(0, Me.Height + 37)
        PictureBox10.Size = New Size(Me.Width, 5)


        compass = New Bitmap("C:\Users\ngree\Documents\Sam's folder\VB code (on laptop)\NEA Stuff\Compase 5.png")
        compass = New Bitmap(compass, 200, 200)

        PPand2DArray()
    End Sub

    Private Sub Form1_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        PPand2DArray()
    End Sub

    Sub PPand2DArray()
        PerspectiveProjection()

        For j = 0 To MapDepth
            For i = 0 To MapWidth
                NewPointArray(i, j) = New Point(XpArray(i, j) + Me.Width / 2, YpArray(i, j))
            Next
        Next

        For j = 0 To MapDepth - 1
            For i = 0 To MapWidth - 1
                TopTriangles(i, j) = {
                    NewPointArray(i, j),
                    NewPointArray(i + 1, j),
                    NewPointArray(i, j + 1)
                }

                BottemTriangles(i, j) = {
                    NewPointArray(i + 1, j + 1),
                    NewPointArray(i + 1, j),
                    NewPointArray(i, j + 1)
                }
            Next
        Next

    End Sub

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        e.Graphics.Clear(Color.Black)
        Dim CustomBrush As New SolidBrush(LighterIndianRed)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        '///////////////// Draws lines \\\\\\\\\\\\\\\\\\\\

        For j = 0 To MapDepth - 1
            For i = 0 To MapWidth - 1
                If TopTriangles(i, j) IsNot Nothing Then
                    CustomBrush.Color = ColorGradient(i, j)
                    e.Graphics.FillPolygon(CustomBrush, TopTriangles(i, j))
                End If
            Next
        Next


        For j = 0 To MapDepth - 1
            For i = 0 To MapWidth - 1
                If BottemTriangles(i, j) IsNot Nothing Then
                    CustomBrush.Color = OffColorGradient(i, j)
                    e.Graphics.FillPolygon(CustomBrush, BottemTriangles(i, j))
                End If
            Next
        Next


        For j = 0 To MapDepth
            For i = 0 To MapWidth - 1
                GridPen.Color = Color.Wheat
                GridPen.Width = 0.25
                'e.Graphics.DrawLine(GridPen, NewPointArray(i, j), NewPointArray(i + 1, j))
            Next
        Next

        For i = 0 To MapWidth
            For j = 0 To MapDepth - 1
                GridPen.Color = Color.Wheat
                GridPen.Width = 0.25
                'e.Graphics.DrawLine(GridPen, NewPointArray(i, j), NewPointArray(i, j + 1))
            Next
        Next

        For j = 0 To MapDepth - 1
            For i = 0 To MapWidth - 1
                GridPen.Color = Color.Wheat
                GridPen.Width = 0.25
                'e.Graphics.DrawLine(GridPen, NewPointArray(i + 1, j), NewPointArray(i, j + 1))
            Next
        Next

        GridPen.Width = 4
        For i = 0 To PathMark.Count - 2
            If i = 0 Then
                GridPen.Color = Color.Lime
            ElseIf i = PathMark.Count - 2 Then
                GridPen.Color = Color.Red
            Else
                GridPen.Color = Color.Yellow
            End If
            e.Graphics.DrawLine(GridPen, NewPointArray(PathMark(i).X, PathMark(i).Y), NewPointArray(PathMark(i + 1).X, PathMark(i + 1).Y))
        Next
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        If compassBool Then
            TotalAngle = 0
            CompassAngle = 0
            compassBool = False
        End If

        CompassAngle = TotalAngle * (180 / PI)
        MyBase.OnPaint(e)
        Dim g = e.Graphics

        Dim CentreX As Integer = 1750
        Dim CentreY As Integer = 150

        g.TranslateTransform(CentreX, CentreY)
        g.RotateTransform(CompassAngle)
        g.TranslateTransform(-compass.Width \ 2, -compass.Height \ 2)

        g.DrawImage(compass, 0, 0)
    End Sub

    Public Function ColorGradient(ByVal i As Integer, ByVal j As Integer) As Color
        If OGPointArray(i, j).Y < 145 Then
            Return Color.LightBlue
        ElseIf OGPointArray(i, j).Y >= 145 And OGPointArray(i, j).Y < 150 Then
            Return BetweenMiddleAndLightBlue
        ElseIf OGPointArray(i, j).Y >= 150 And OGPointArray(i, j).Y < 157 Then
            Return MiddleBlue
        Else
            Return Color.Blue
        End If
    End Function

    Public Function OffColorGradient(ByVal i As Integer, ByVal j As Integer) As Color
        If OGPointArray(i, j).Y < 145 Then
            Return Color.FromArgb(150, 200, 220)
        ElseIf OGPointArray(i, j).Y >= 145 And OGPointArray(i, j).Y < 150 Then
            Return Color.FromArgb(115, 145, 220)
        ElseIf OGPointArray(i, j).Y >= 150 And OGPointArray(i, j).Y < 157 Then
            Return Color.FromArgb(70, 95, 230)
        Else
            Return Color.FromArgb(0, 0, 220)
        End If
    End Function

    Sub PerspectiveProjection()
        For j = 0 To MapDepth
            For i = 0 To MapWidth
                XpArray(i, j) = (OGPointArray(i, j).X / ((OGPointArray(i, j).Z + 300) * Tan(A / 2))) * 200
            Next
        Next

        For j = 0 To MapDepth
            For i = 0 To MapWidth
                YpArray(i, j) = ((OGPointArray(i, j).Y) / ((OGPointArray(i, j).Z + 300) * Tan(A / 2))) * 200
            Next
        Next
    End Sub

    Sub PerlinNoise()
        Dim rand As New Random()
        Dim MaxVal As Double = 1.67 * ChunkSize
        Dim CardinalDirectionArray(XChunkAmount, ZChunkAmount) As Integer

        For y = 0 To ZChunkAmount
            For x = 0 To XChunkAmount
                CardinalDirectionArray(x, y) = rand.Next(0, 12)
            Next
        Next

        Dim TLElevationArray(MapWidth, MapDepth) As Double
        Dim TRElevationArray(MapWidth, MapDepth) As Double
        Dim BLElevationArray(MapWidth, MapDepth) As Double
        Dim BRElevationArray(MapWidth, MapDepth) As Double

        Dim TLTRElevationArray(MapWidth, MapDepth) As Double
        Dim BLBRElevationArray(MapWidth, MapDepth) As Double


        For y = 0 To ZChunkAmount - 1
            For x = 0 To XChunkAmount - 1

                For b1 = 0 To ChunkSize
                    For a1 = 0 To ChunkSize

                        TLElevationArray((x * ChunkSize) + a1, (y * ChunkSize) + b1) = (Cos((CardinalDirectionArray(x, y) * PI) / 6) * a1) + (Sin((CardinalDirectionArray(x, y) * PI) / 6) * b1)
                        TRElevationArray((x * ChunkSize) + a1, (y * ChunkSize) + b1) = (Cos((CardinalDirectionArray(x + 1, y) * PI) / 6) * (ChunkSize - a1)) + (Sin((CardinalDirectionArray(x + 1, y) * PI) / 6) * b1)
                        BLElevationArray((x * ChunkSize) + a1, (y * ChunkSize) + b1) = (Cos((CardinalDirectionArray(x, y + 1) * PI) / 6) * a1) + (Sin((CardinalDirectionArray(x, y + 1) * PI) / 6) * (ChunkSize - b1))
                        BRElevationArray((x * ChunkSize) + a1, (y * ChunkSize) + b1) = (Cos((CardinalDirectionArray(x + 1, y + 1) * PI) / 6) * (ChunkSize - a1)) + (Sin((CardinalDirectionArray(x + 1, y + 1) * PI) / 6) * (ChunkSize - b1))
                    Next
                Next

            Next
        Next

        Dim TopTempDifference As Double
        Dim BottemTempDifference As Double
        Dim MergeTempDifference As Double
        Dim xf As Double


        Dim Temp1 As Double
        For y = 0 To MapDepth
            For x = 0 To MapWidth

                Temp1 = TLElevationArray(x, y)
                xf = Abs((Temp1 + MaxVal) / (MaxVal * 2))
                TLElevationArray(x, y) = 6 * (xf ^ 5) - 15 * (xf ^ 4) + 10 * (xf ^ 3)

                Temp1 = TRElevationArray(x, y)
                xf = Abs((Temp1 + MaxVal) / (MaxVal * 2))
                TRElevationArray(x, y) = 6 * (xf ^ 5) - 15 * (xf ^ 4) + 10 * (xf ^ 3)

                Temp1 = BLElevationArray(x, y)
                xf = Abs((Temp1 + MaxVal) / (MaxVal * 2))
                BLElevationArray(x, y) = 6 * (xf ^ 5) - 15 * (xf ^ 4) + 10 * (xf ^ 3)

                Temp1 = BRElevationArray(x, y)
                xf = Abs((Temp1 + MaxVal) / (MaxVal * 2))
                BRElevationArray(x, y) = 6 * (xf ^ 5) - 15 * (xf ^ 4) + 10 * (xf ^ 3)
            Next
        Next



        For y = 0 To ZChunkAmount - 1
            For x = 0 To XChunkAmount - 1

                For b1 = 0 To ChunkSize
                    For a1 = 0 To ChunkSize

                        TopTempDifference = TRElevationArray((x * ChunkSize) + a1, (y * ChunkSize) + b1) - TLElevationArray((x * ChunkSize) + a1, (y * ChunkSize) + b1)
                        TLTRElevationArray((x * ChunkSize) + a1, (y * ChunkSize) + b1) = TLElevationArray((x * ChunkSize) + a1, (y * ChunkSize) + b1) + ((TopTempDifference / 5) * a1)

                        BottemTempDifference = BRElevationArray((x * ChunkSize) + a1, (y * ChunkSize) + b1) - BLElevationArray((x * ChunkSize) + a1, (y * ChunkSize) + b1)
                        BLBRElevationArray((x * ChunkSize) + a1, (y * ChunkSize) + b1) = BLElevationArray((x * ChunkSize) + a1, (y * ChunkSize) + b1) + ((BottemTempDifference / 5) * a1)

                        MergeTempDifference = BLBRElevationArray((x * ChunkSize) + a1, (y * ChunkSize) + b1) - TLTRElevationArray((x * ChunkSize) + a1, (y * ChunkSize) + b1)
                        FinalElevationArray((x * ChunkSize) + a1, (y * ChunkSize) + b1) = TLTRElevationArray((x * ChunkSize) + a1, (y * ChunkSize) + b1) + ((MergeTempDifference / 5) * a1)

                    Next
                Next
            Next
        Next

        For y = 0 To ZChunkAmount - 1
            For x = 0 To XChunkAmount - 1

                For a1 = 0 To ChunkSize
                    For b1 = 0 To ChunkSize

                        MergeTempDifference = BLBRElevationArray((x * ChunkSize) + a1, (y * ChunkSize) + b1) - TLTRElevationArray((x * ChunkSize) + a1, (y * ChunkSize) + b1)
                        FinalElevationArray((x * ChunkSize) + a1, (y * ChunkSize) + b1) = TLTRElevationArray((x * ChunkSize) + a1, (y * ChunkSize) + b1) + ((MergeTempDifference / 5) * a1)

                    Next
                Next
            Next
        Next


        Dim TempAvg As Double
        Dim a2 As Double
        Dim b2 As Double
        For y = 0 To MapDepth
            For x = 0 To MapWidth

                If x Mod ChunkSize = 0 And x <> 0 Then

                    a2 = FinalElevationArray(x - 1, y)
                    b2 = FinalElevationArray(x, y)
                    TempAvg = (b2 - a2) / 4
                    FinalElevationArray(x - 1, y) = TempAvg + a2
                    FinalElevationArray(x, y) = b2 - TempAvg
                End If
            Next
        Next

        For x = 0 To MapWidth
            For y = 0 To MapDepth

                If y Mod ChunkSize = 0 And y <> 0 Then

                    a2 = FinalElevationArray(x, y - 1)
                    b2 = FinalElevationArray(x, y)
                    TempAvg = (b2 - a2) / 4
                    FinalElevationArray(x, y - 1) = TempAvg + a2
                    FinalElevationArray(x, y) = b2 - TempAvg
                End If
            Next
        Next



    End Sub

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
                TotalAngle += AngleY
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
        MouseDragging = False
    End Sub

    Private Sub Form1_MouseWheel(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel
        MouseZoom += e.Delta / 1200

        PPand2DArray()
        Me.Invalidate()
    End Sub

    Private Sub Btn_Reset_Click(sender As Object, e As EventArgs) Handles Btn_Reset.Click
        Reset()
    End Sub

    Private Sub Btn_Regenerate_Click(sender As Object, e As EventArgs) Handles Btn_Regenerate.Click
        PerlinNoise()
        For j = 0 To MapDepth
            For i = 0 To MapWidth
                YValue(i, j) = (FinalElevationArray(i, j) * 30) + 135
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
        TotalAngle += AngleY
        RotateY()
        Me.Invalidate()
    End Sub

    Private Sub Btn_Hide_Click(sender As Object, e As EventArgs) Handles Btn_Hide.Click
        Timer1.Stop()
        Reset()
        OrbitSwitch = False
        Form2.Show()
        Me.Hide()
    End Sub

    Sub Reset()
        For j = 0 To MapDepth
            For i = 0 To MapWidth
                OGPointArray(i, j) = New Point3D((StartX) + (i * ThreeDScaleFactor), YValue(i, j), StartZ - (j * ThreeDScaleFactor))
            Next
        Next
        PPand2DArray()
        Me.Invalidate()
        compassBool = True
    End Sub

End Class

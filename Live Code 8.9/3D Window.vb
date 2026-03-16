Imports System
Imports System.Drawing.Drawing2D
Imports System.Math
Imports System.Threading
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
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
    Public OctaveNum As Integer = 5
    Public Lacunarity As Double = 0.5
    Public XChunkAmount As Integer = MapWidth / ChunkSize
    Public ZChunkAmount As Integer = MapDepth / ChunkSize

    Public FinalElevationArray(MapWidth, MapDepth) As Double

    Public TopTriangleItemList As New List(Of Triangle3D)
    Public BottemTriangleItemList As New List(Of Triangle3D)

    Public SortedTopTriangleItemList As New List(Of Triangle3D)
    Public SortedBottemTriangleItemList As New List(Of Triangle3D)

    Public Extremity As Integer = 40

    Public YValForColour As Double



    Public PerlinNoisePerm() As Integer = {151, 160, 137, 91, 90, 15, 131, 13, 201, 95, 96, 53, 194, 233, 7, 225,
                      140, 36, 103, 30, 69, 142, 8, 99, 37, 240, 21, 10, 23, 190, 6, 148,
                      247, 120, 234, 75, 0, 26, 197, 62, 94, 252, 219, 203, 117, 35, 11, 32,
                       57, 177, 33, 88, 237, 149, 56, 87, 174, 20, 125, 136, 171, 168, 68, 175,
                       74, 165, 71, 134, 139, 48, 27, 166, 77, 146, 158, 231, 83, 111, 229, 122,
                       60, 211, 133, 230, 220, 105, 92, 41, 55, 46, 245, 40, 244, 102, 143, 54,
                       65, 25, 63, 161, 1, 216, 80, 73, 209, 76, 132, 187, 208, 89, 18, 169,
                      200, 196, 135, 130, 116, 188, 159, 86, 164, 100, 109, 198, 173, 186, 3, 64,
                       52, 217, 226, 250, 124, 123, 5, 202, 38, 147, 118, 126, 255, 82, 85, 212,
                      207, 206, 59, 227, 47, 16, 58, 17, 182, 189, 28, 42, 223, 183, 170, 213,
                      119, 248, 152, 2, 44, 154, 163, 70, 221, 153, 101, 155, 167, 43, 172, 9,
                      129, 22, 39, 253, 19, 98, 108, 110, 79, 113, 224, 232, 178, 185, 112, 104,
                      218, 246, 97, 228, 251, 34, 242, 193, 238, 210, 144, 12, 191, 179, 162, 241,
                       81, 51, 145, 235, 249, 14, 239, 107, 49, 192, 214, 31, 181, 199, 106, 157,
                      184, 84, 204, 176, 115, 121, 50, 45, 127, 4, 150, 254, 138, 236, 205, 93,
                      222, 114, 67, 29, 24, 72, 243, 141, 128, 195, 78, 66, 215, 61, 156, 180}


End Module
Public Class Form1
    Dim rnd As New Random()

    Dim AngleY As Double = 0
    Dim AngleX As Double = 0
    Dim A As Double = PI / 6


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

    Dim UpdateExtremityBool As Boolean
    Dim UpdateAngleBool As Boolean
    Dim UpdateLacunarityBool As Boolean

    Public Structure Triangle3D
        Public P1 As Point
        Public P2 As Point
        Public P3 As Point
        Public Depth As Double
        Public Elevation As Double
    End Structure

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

        'PictureBox1.Location = New Point(0, 0)
        'PictureBox1.Size = New Size(300, Me.Height + 42)
        'PictureBox2.Location = New Point(300, (Me.Height + 42) - 240)
        'PictureBox2.Size = New Size(Me.Width, 240)
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
        TopTriangleItemList.Clear()
        BottemTriangleItemList.Clear()

        For j = 0 To MapDepth
            For i = 0 To MapWidth
                NewPointArray(i, j) = New Point(XpArray(i, j) + Me.Width / 2, YpArray(i, j))
            Next
        Next

        For j = 0 To MapDepth - 1
            For i = 0 To MapWidth - 1
                Dim TopTriangle As New Triangle3D()
                TopTriangle.P1 = NewPointArray(i, j)
                TopTriangle.P2 = NewPointArray(i + 1, j)
                TopTriangle.P3 = NewPointArray(i, j + 1)

                TopTriangle.Depth = (
                    OGPointArray(i, j).Z +
                    OGPointArray(i + 1, j).Z +
                    OGPointArray(i, j + 1).Z
                ) / 3

                TopTriangle.Elevation = (
                    YValue(i, j) +
                    YValue(i + 1, j) +
                    YValue(i, j + 1)
                ) / 3

                TopTriangleItemList.Add(TopTriangle)


                Dim BottemTriangle As New Triangle3D()
                BottemTriangle.P1 = NewPointArray(i + 1, j)
                BottemTriangle.P2 = NewPointArray(i, j + 1)
                BottemTriangle.P3 = NewPointArray(i + 1, j + 1)

                BottemTriangle.Depth = (
                    OGPointArray(i + 1, j).Z +
                    OGPointArray(i, j + 1).Z +
                    OGPointArray(i + 1, j).Z
                ) / 3

                BottemTriangle.Elevation = (
                    YValue(i, j) +
                    YValue(i + 1, j) +
                    YValue(i, j + 1)
                ) / 3

                BottemTriangleItemList.Add(BottemTriangle)
            Next
        Next
    End Sub

    Function MergeSortTriangles(ByVal TempList As List(Of Triangle3D)) As List(Of Triangle3D)
        Dim ListOfItems As New List(Of List(Of Triangle3D))
        Dim Item As List(Of Triangle3D)
        Dim Index As Integer
        Dim NewList As List(Of Triangle3D)

        For x = 0 To TempList.Count - 1
            Item = New List(Of Triangle3D)()
            Item.Add(TempList(x))
            ListOfItems.Add(Item)
        Next

        While ListOfItems.Count <> 1
            Index = 0
            While Index < ListOfItems.Count - 1
                NewList = MergeSort(ListOfItems(Index), ListOfItems(Index + 1))
                ListOfItems(Index) = NewList
                ListOfItems.RemoveAt(Index + 1)
                Index += 1
            End While
        End While

        Return ListOfItems(0)

    End Function

    Function MergeSort(ByVal List1 As List(Of Triangle3D), ByVal List2 As List(Of Triangle3D)) As List(Of Triangle3D)
        Dim NewList As New List(Of Triangle3D)
        Dim Index1 As Integer = 0
        Dim Index2 As Integer = 0

        While Index1 < List1.Count And Index2 < List2.Count
            If List1(Index1).Depth < List2(Index2).Depth Then
                NewList.Add(List2(Index2))
                Index2 += 1
            ElseIf List1(Index1).Depth > List2(Index2).Depth Then
                NewList.Add(List1(Index1))
                Index1 += 1
            ElseIf List1(Index1).Depth = List2(Index2).Depth Then
                NewList.Add(List1(Index1))
                NewList.Add(List2(Index2))
                Index1 += 1
                Index2 += 1
            End If
        End While

        If Index1 < List1.Count Then
            For item = Index1 To List1.Count - 1
                NewList.Add(List1(item))
            Next
        ElseIf Index2 < List2.Count Then
            For item = Index2 To List2.Count - 1
                NewList.Add(List2(item))
            Next
        End If
        Return NewList
    End Function

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        e.Graphics.Clear(Color.Black)
        Dim CustomBrush As New SolidBrush(LighterIndianRed)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        RoutePen.Width = RouteWidth
        RoutePen.Color = RouteColour

        SortedTopTriangleItemList = MergeSortTriangles(TopTriangleItemList)
        SortedBottemTriangleItemList = MergeSortTriangles(BottemTriangleItemList)

        For i = 0 To SortedTopTriangleItemList.Count - 1
            If SortedTopTriangleItemList IsNot Nothing Then
                Dim TopPoints() As Point = {SortedTopTriangleItemList(i).P1, SortedTopTriangleItemList(i).P2, SortedTopTriangleItemList(i).P3}
                YValForColour = SortedTopTriangleItemList(i).Elevation
                CustomBrush.Color = ColorGradient(YValForColour)
                e.Graphics.FillPolygon(CustomBrush, TopPoints)

                Dim TempPoint1 As New Point
                Dim TempPoint2 As New Point
                For x = 0 To PathMark.Count - 2
                    TempPoint1 = NewPointArray(PathMark(x).X, PathMark(x).Y)
                    TempPoint2 = NewPointArray(PathMark(x + 1).X, PathMark(x + 1).Y)

                    If TempPoint1 = SortedTopTriangleItemList(i).P1 Then
                        If TempPoint2 = SortedTopTriangleItemList(i).P2 Then
                            e.Graphics.DrawLine(RoutePen, TempPoint1, TempPoint2)
                        ElseIf TempPoint2 = SortedTopTriangleItemList(i).P3 Then
                            e.Graphics.DrawLine(RoutePen, TempPoint1, TempPoint2)
                        End If
                    ElseIf TempPoint1 = SortedTopTriangleItemList(i).P2 Then
                        If TempPoint2 = SortedTopTriangleItemList(i).P1 Then
                            e.Graphics.DrawLine(RoutePen, TempPoint1, TempPoint2)
                        ElseIf TempPoint2 = SortedTopTriangleItemList(i).P3 Then
                            e.Graphics.DrawLine(RoutePen, TempPoint1, TempPoint2)
                        End If
                    ElseIf TempPoint1 = SortedTopTriangleItemList(i).P3 Then
                        If TempPoint2 = SortedTopTriangleItemList(i).P1 Then
                            e.Graphics.DrawLine(RoutePen, TempPoint1, TempPoint2)
                        ElseIf TempPoint2 = SortedTopTriangleItemList(i).P2 Then
                            e.Graphics.DrawLine(RoutePen, TempPoint1, TempPoint2)
                        End If
                    End If
                Next


            End If
            If SortedBottemTriangleItemList IsNot Nothing Then
                Dim BottemPoints() As Point = {SortedBottemTriangleItemList(i).P1, SortedBottemTriangleItemList(i).P2, SortedBottemTriangleItemList(i).P3}
                YValForColour = SortedBottemTriangleItemList(i).Elevation
                CustomBrush.Color = OffColorGradient(YValForColour)
                e.Graphics.FillPolygon(CustomBrush, BottemPoints)

                Dim TempPoint1 As New Point
                Dim TempPoint2 As New Point
                For x = 0 To PathMark.Count - 2
                    TempPoint1 = NewPointArray(PathMark(x).X, PathMark(x).Y)
                    TempPoint2 = NewPointArray(PathMark(x + 1).X, PathMark(x + 1).Y)

                    If TempPoint1 = SortedBottemTriangleItemList(i).P1 Then
                        If TempPoint2 = SortedBottemTriangleItemList(i).P2 Then
                            e.Graphics.DrawLine(RoutePen, TempPoint1, TempPoint2)
                        ElseIf TempPoint2 = SortedBottemTriangleItemList(i).P3 Then
                            e.Graphics.DrawLine(RoutePen, TempPoint1, TempPoint2)
                        End If
                    ElseIf TempPoint1 = SortedBottemTriangleItemList(i).P2 Then
                        If TempPoint2 = SortedBottemTriangleItemList(i).P1 Then
                            e.Graphics.DrawLine(RoutePen, TempPoint1, TempPoint2)
                        ElseIf TempPoint2 = SortedBottemTriangleItemList(i).P3 Then
                            e.Graphics.DrawLine(RoutePen, TempPoint1, TempPoint2)
                        End If
                    ElseIf TempPoint1 = SortedBottemTriangleItemList(i).P3 Then
                        If TempPoint2 = SortedBottemTriangleItemList(i).P1 Then
                            e.Graphics.DrawLine(RoutePen, TempPoint1, TempPoint2)
                        ElseIf TempPoint2 = SortedBottemTriangleItemList(i).P2 Then
                            e.Graphics.DrawLine(RoutePen, TempPoint1, TempPoint2)
                        End If
                    End If
                Next
            End If
        Next


        For j = 0 To MapDepth
            For i = 0 To MapWidth - 1
                RoutePen.Color = Color.Wheat
                RoutePen.Width = 0.25
                'e.Graphics.DrawLine(GridPen, NewPointArray(i, j), NewPointArray(i + 1, j))
            Next
        Next

        For i = 0 To MapWidth
            For j = 0 To MapDepth - 1
                RoutePen.Color = Color.Wheat
                RoutePen.Width = 0.25
                'e.Graphics.DrawLine(GridPen, NewPointArray(i, j), NewPointArray(i, j + 1))
            Next
        Next

        For j = 0 To MapDepth - 1
            For i = 0 To MapWidth - 1
                RoutePen.Color = Color.Wheat
                RoutePen.Width = 0.25
                'e.Graphics.DrawLine(GridPen, NewPointArray(i + 1, j), NewPointArray(i, j + 1))
            Next
        Next
        Dim RectBrush As New SolidBrush(Color.FromArgb(0, 70, 120))
        Dim PicBox2 As New Rectangle(300, (Me.Height) - 240, Me.Width, 240)
        Dim PicBox1 As New Rectangle(0, 0, 300, (Me.Height + 42))
        e.Graphics.FillRectangle(RectBrush, PicBox2)
        e.Graphics.FillRectangle(RectBrush, PicBox1)


        Dim TempPen As New Pen(Color.White, 4)
        e.Graphics.DrawLine(TempPen, New Point(400, 1020), New Point(400, 870))
        e.Graphics.DrawLine(TempPen, New Point(400, 1020), New Point(1400, 1020))

        TempPen.Width = 1
        For x = 0 To PathMark.Count - 2
            e.Graphics.DrawLine(TempPen, ElevationCoordiates(x), ElevationCoordiates(x + 1))
        Next


        Dim ArrowBrush As New SolidBrush(Color.White)
        Dim ArrowPoints1() As Point = {New Point(392, 870), New Point(408, 870), New Point(400, 855)}
        e.Graphics.FillPolygon(ArrowBrush, ArrowPoints1)
        Dim ArrowPoints2() As Point = {New Point(1400, 1012), New Point(1400, 1028), New Point(1415, 1020)}
        e.Graphics.FillPolygon(ArrowBrush, ArrowPoints2)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        If compass Is Nothing Then Exit Sub
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

    Public Function ColorGradient(ByVal YValForColour) As Color
        If YValForColour < 0.6 Then
            Return Color.FromArgb(220, 220, 220)
        ElseIf YValForColour >= 0.6 And YValForColour < 0.7 Then
            Return Color.FromArgb(200, 200, 200)
        ElseIf YValForColour >= 0.7 And YValForColour < 0.8 Then
            Return Color.FromArgb(180, 180, 180)
        ElseIf YValForColour >= 0.8 And YValForColour < 0.9 Then
            Return Color.FromArgb(160, 160, 160)
        ElseIf YValForColour >= 0.9 And YValForColour < 1 Then
            Return Color.FromArgb(140, 140, 140)
        ElseIf YValForColour >= 1 And YValForColour < 1.1 Then
            Return Color.FromArgb(120, 120, 120)
        ElseIf YValForColour >= 1.1 And YValForColour < 1.2 Then
            Return Color.FromArgb(100, 100, 100)
        Else
            Return Color.FromArgb(80, 80, 80)
        End If
    End Function

    Public Function OffColorGradient(ByVal YValForColour) As Color
        If YValForColour < 0.6 Then
            Return Color.FromArgb(225, 225, 225)
        ElseIf YValForColour >= 0.6 And YValForColour < 0.7 Then
            Return Color.FromArgb(205, 205, 205)
        ElseIf YValForColour >= 0.7 And YValForColour < 0.8 Then
            Return Color.FromArgb(185, 185, 185)
        ElseIf YValForColour >= 0.8 And YValForColour < 0.9 Then
            Return Color.FromArgb(165, 165, 165)
        ElseIf YValForColour >= 0.9 And YValForColour < 1 Then
            Return Color.FromArgb(145, 145, 145)
        ElseIf YValForColour >= 1 And YValForColour < 1.1 Then
            Return Color.FromArgb(125, 125, 125)
        ElseIf YValForColour >= 1.1 And YValForColour < 1.2 Then
            Return Color.FromArgb(105, 105, 105)
        Else
            Return Color.FromArgb(85, 85, 85)
        End If
    End Function

    Sub KeyFunctions()
        Array.Clear(YValue, 0, YValue.Length)
        For q = 0 To OctaveNum - 1
            PerlinNoise()

            For j = 0 To MapDepth
                For i = 0 To MapWidth
                    YValue(i, j) += (FinalElevationArray(i, j) * (Lacunarity ^ q))
                Next
            Next
        Next

        For j = 0 To MapDepth
            For i = 0 To MapWidth
                OGPointArray(i, j) = New Point3D((StartX) + (i * ThreeDScaleFactor), (YValue(i, j) * Extremity) + 110, StartZ - (j * ThreeDScaleFactor))
            Next
        Next
    End Sub

    Sub PerspectiveProjection()
        For j = 0 To MapDepth
            For i = 0 To MapWidth
                XpArray(i, j) = (OGPointArray(i, j).X / ((OGPointArray(i, j).Z + 250) * Tan(A / 2))) * 200
            Next
        Next

        For j = 0 To MapDepth
            For i = 0 To MapWidth
                YpArray(i, j) = ((OGPointArray(i, j).Y) / ((OGPointArray(i, j).Z + 250) * Tan(A / 2))) * 200
            Next
        Next
    End Sub

    Sub PerlinNoise()
        Dim rand As New Random()
        Dim MaxVal As Double = 1.67 * ChunkSize
        Dim RandomNumber As Integer
        Dim CardinalDirectionArray(XChunkAmount, ZChunkAmount) As Integer

        For y = 0 To ZChunkAmount
            For x = 0 To XChunkAmount
                RandomNumber = (rand.Next(0, 256))
                RandomNumber = PerlinNoisePerm(RandomNumber) Mod 16
                If RandomNumber >= 12 Then
                    RandomNumber -= 12
                End If
                CardinalDirectionArray(x, y) = RandomNumber
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
                xf = (Temp1 + MaxVal) / (MaxVal * 2)
                TLElevationArray(x, y) = 6 * (xf ^ 5) - 15 * (xf ^ 4) + 10 * (xf ^ 3)

                Temp1 = TRElevationArray(x, y)
                xf = (Temp1 + MaxVal) / (MaxVal * 2)
                TRElevationArray(x, y) = 6 * (xf ^ 5) - 15 * (xf ^ 4) + 10 * (xf ^ 3)

                Temp1 = BLElevationArray(x, y)
                xf = (Temp1 + MaxVal) / (MaxVal * 2)
                BLElevationArray(x, y) = 6 * (xf ^ 5) - 15 * (xf ^ 4) + 10 * (xf ^ 3)

                Temp1 = BRElevationArray(x, y)
                xf = (Temp1 + MaxVal) / (MaxVal * 2)
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


    Private Sub Btn_Reset_Click(sender As Object, e As EventArgs) Handles Btn_Reset.Click
        Reset()
    End Sub

    Private Sub Btn_Regenerate_Click(sender As Object, e As EventArgs) Handles Btn_Regenerate.Click
        Array.Clear(YValue, 0, YValue.Length)
        For q = 0 To OctaveNum - 1
            PerlinNoise()

            For j = 0 To MapDepth
                For i = 0 To MapWidth
                    YValue(i, j) += (FinalElevationArray(i, j) * (Lacunarity ^ q))
                Next
            Next
        Next

        For j = 0 To MapDepth
            For i = 0 To MapWidth
                OGPointArray(i, j).Y = (YValue(i, j) * Extremity) + 110
            Next
        Next

        PPand2DArray()
        Form2.ElevationProfile()
        Form2.RouteStats()
        Me.Invalidate()
    End Sub
    Sub WriteRouteStats()
        If RouteStatsBool = True Then

            Lbl_Length.Text = "Lenght: " + RouteDistance.ToString + kmstring
            Lbl_MaxElevation.Text = "Maxumum Elevation: " + RouteMaxHeight.ToString + mstring
            Lbl_MinElevation.Text = "Minumum Elevation: " + RouteMinHeight.ToString + mstring
            Lbl_TotalElevation.Text = "Total Elevation: " + RouteTotalHeight.ToString + mstring
            Lbl_Duration.Text = "Duration: " + RouteTime.ToString + "h"
        Else
            Lbl_Length.Text = "Lenght: ----"
            Lbl_MaxElevation.Text = "Maxumum Elevation: ----"
            Lbl_MinElevation.Text = "Minumum Elevation: ----"
            Lbl_TotalElevation.Text = "Total Elevation: ----"
            Lbl_Duration.Text = "Duration: ----"
        End If
        Lbl_Elevation.Text = "Elevation (" + mstring + ")"
        Lbl_Distance.Text = "Distance (" + kmstring + ")"
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
                OGPointArray(i, j) = New Point3D((StartX) + (i * ThreeDScaleFactor), (YValue(i, j) * Extremity) + 110, StartZ - (j * ThreeDScaleFactor))
            Next
        Next
        PPand2DArray()
        compassBool = True
        Me.Invalidate()

    End Sub

    Private Sub Txt_Extremity_TextChanged(sender As Object, e As EventArgs) Handles Txt_Extremity.TextChanged
        UpdateExtremityBool = False
        Dim TempInput As String = Txt_Extremity.Text
        Dim TempValidInput As Integer
        Integer.TryParse(TempInput, TempValidInput)


        If TempValidInput > 0 And TempValidInput < 60 Then
            Extremity = TempValidInput
            UpdateExtremityBool = True
        End If

    End Sub

    Private Sub Btn_UpdateExtremity_Click(sender As Object, e As EventArgs) Handles Btn_UpdateExtremity.Click
        If UpdateExtremityBool = True Then
            For j = 0 To MapDepth
                For i = 0 To MapWidth
                    OGPointArray(i, j).Y = (YValue(i, j) * Extremity) + 110
                Next
            Next
            PPand2DArray()
            Me.Invalidate()
        End If
    End Sub

    Private Sub Txt_Angle_TextChanged(sender As Object, e As EventArgs) Handles Txt_Angle.TextChanged
        UpdateAngleBool = False
        Dim TempInput = Txt_Angle.Text
        Dim TempValidInput As Integer
        Integer.TryParse(TempInput, TempValidInput)


        If TempValidInput > 15 And TempValidInput < 180 Then

            A = TempValidInput / 180 * PI
            UpdateAngleBool = True
        End If

    End Sub

    Private Sub Btn_UpdateAngle_Click(sender As Object, e As EventArgs) Handles Btn_UpdateAngle.Click
        If UpdateAngleBool = True Then
            PPand2DArray()
            Invalidate()
        End If
    End Sub

    Private Sub Btn_OctaveDown_Click(sender As Object, e As EventArgs) Handles Btn_OctaveDown.Click
        If OctaveNum = 10 Then
            Btn_OctaveUp.Enabled = True
        End If
        OctaveNum -= 1
        KeyFunctions()
        PPand2DArray()
        Me.Invalidate()
        If OctaveNum = 1 Then
            Btn_OctaveDown.Enabled = False
        End If
    End Sub

    Private Sub Btn_OctaveUp_Click(sender As Object, e As EventArgs) Handles Btn_OctaveUp.Click
        If OctaveNum = 1 Then
            Btn_OctaveDown.Enabled = True
        End If
        OctaveNum += 1
        KeyFunctions()
        PPand2DArray()
        compassBool = True
        Me.Invalidate()
        If OctaveNum = 10 Then
            Btn_OctaveUp.Enabled = False
        End If
    End Sub

    Private Sub Txt_Lacunarity_TextChanged(sender As Object, e As EventArgs) Handles Txt_Lacunarity.TextChanged
        UpdateLacunarityBool = False
        Dim TempInput = Txt_Lacunarity.Text
        Dim TempValidInput As Double
        Double.TryParse(TempInput, TempValidInput)


        If TempValidInput > 0 And TempValidInput < 1 Then

            Lacunarity = TempValidInput
            UpdateLacunarityBool = True
        End If
    End Sub

    Private Sub Btn_UpdateLacunarity_Click(sender As Object, e As EventArgs) Handles Btn_UpdateLacunarity.Click
        If UpdateLacunarityBool = True Then
            KeyFunctions()
            PPand2DArray()
            Me.Invalidate()
        End If
    End Sub
End Class

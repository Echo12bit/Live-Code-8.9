Imports System
Imports System.Drawing.Drawing2D
Imports System.Math
Imports System.Runtime.InteropServices.JavaScript.JSType
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
    'ken perlins origional permutations table of randomly ordered numbers

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
        'creation of custom 3D point structure to faclilitate the use of 3D coordiantes
    End Structure


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form2.Show()
        Me.Hide()
        Me.Show()
        Form2.Hide()
        Form2.Show()
        Me.Hide() 'makes the program full screen
        PictureBox1.Size = New Size(300, Me.Height)
        PictureBox2.Location = New Point(0, Me.Height - 200)

        Me.FormBorderStyle = FormBorderStyle.None   'Remove borders/title bar
        Me.Size = New Size(1600, 800)
        Me.DoubleBuffered = True

        PictureBox3.Location = New Point(0, 0)
        PictureBox3.Size = New Size(5, Me.Height + 42)
        PictureBox4.Location = New Point(300, 0)
        PictureBox4.Size = New Size(5, Me.Height + 42)
        PictureBox7.Location = New Point(Me.Width - 23, 0)
        PictureBox7.Size = New Size(5, Me.Height + 42)
        PictureBox8.Location = New Point(0, 0)
        PictureBox8.Size = New Size(Me.Width, 5)
        PictureBox9.Location = New Point(300, (Me.Height + 42) - 245)
        PictureBox9.Size = New Size(Me.Width, 5)
        PictureBox10.Location = New Point(0, Me.Height + 37)
        PictureBox10.Size = New Size(Me.Width, 5)
        'initialises pictureboxes that build the background UI

        compass = New Bitmap("C:\Users\ngree\Documents\Sam's folder\VB code (on laptop)\NEA Stuff\Compase 5.png")
        'imports compass image from files
        compass = New Bitmap(compass, 200, 200)
        'stores the image to a bitmap
        PPand2DArray() 'sub call to initialise the process of projecting 3D graphcis
    End Sub

    Private Sub Form1_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        PPand2DArray()
    End Sub

    Sub PPand2DArray()
        PerspectiveProjection() 'sub call to the perspective projection
        TopTriangleItemList.Clear()
        BottemTriangleItemList.Clear()
        'clears lists of pervious graphics
        For j = 0 To MapDepth
            For i = 0 To MapWidth
                NewPointArray(i, j) = New Point(XpArray(i, j) + Me.Width / 2, YpArray(i, j))
            Next
        Next
        'initialialises the set of projected points
        For j = 0 To MapDepth - 1
            For i = 0 To MapWidth - 1
                Dim TopTriangle As New Triangle3D()
                TopTriangle.P1 = NewPointArray(i, j)
                TopTriangle.P2 = NewPointArray(i + 1, j)
                TopTriangle.P3 = NewPointArray(i, j + 1)
                'groups adjacent points into triangles
                TopTriangle.Depth = (
                    OGPointArray(i, j).Z +
                    OGPointArray(i + 1, j).Z +
                    OGPointArray(i, j + 1).Z
                ) / 3
                'finds an average Z value of the 3 points
                TopTriangle.Elevation = (
                    YValue(i, j) +
                    YValue(i + 1, j) +
                    YValue(i, j + 1)
                ) / 3
                'finds an average Y value of the 3 points
                TopTriangleItemList.Add(TopTriangle)
                'adds this structure to a list of all the triangles

                Dim BottemTriangle As New Triangle3D()
                BottemTriangle.P1 = NewPointArray(i + 1, j)
                BottemTriangle.P2 = NewPointArray(i, j + 1)
                BottemTriangle.P3 = NewPointArray(i + 1, j + 1)
                'creates the trinagles on the the side of the hypotenuse to the previous triangles
                BottemTriangle.Depth = (
                    OGPointArray(i + 1, j).Z +
                    OGPointArray(i, j + 1).Z +
                    OGPointArray(i + 1, j).Z
                ) / 3
                'finds an average Z value of the 3 points
                BottemTriangle.Elevation = (
                    YValue(i, j) +
                    YValue(i + 1, j) +
                    YValue(i, j + 1)
                ) / 3
                'finds an average Y value of the 3 points
                BottemTriangleItemList.Add(BottemTriangle)
                'adds this structure to a list of all the triangles
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
        'adds each triangle to an individual list
        While ListOfItems.Count <> 1
            Index = 0
            While Index < ListOfItems.Count - 1
                NewList = MergeSort(ListOfItems(Index), ListOfItems(Index + 1)) 'function call to sort two adjacent lists
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
            If List1(Index1).Depth < List2(Index2).Depth Then 'compares values in adjacent lists
                NewList.Add(List2(Index2)) 'adds item of smaller Z value to the new list
                Index2 += 1 'increments the index of the 2nd old list
            ElseIf List1(Index1).Depth > List2(Index2).Depth Then 'compares values in adjacent lists
                NewList.Add(List1(Index1)) 'adds item of smaller Z value to the new list
                Index1 += 1 'increments the index of the 1st old list
            ElseIf List1(Index1).Depth = List2(Index2).Depth Then 'if both lists hold the same value
                NewList.Add(List1(Index1))
                NewList.Add(List2(Index2)) 'add both of them to the new list
                Index1 += 1
                Index2 += 1 'increment the index of both lists
            End If
        End While

        If Index1 < List1.Count Then 'checks if there are still remaining items in list 1
            For item = Index1 To List1.Count - 1
                NewList.Add(List1(item)) 'if so it adds all remaining items in list1 to the new list
            Next
        ElseIf Index2 < List2.Count Then 'checks if there are still remaining items in list 2
            For item = Index2 To List2.Count - 1
                NewList.Add(List2(item)) 'if so it adds all remaining items in list2 to the new list
            Next
        End If
        Return NewList 'returns the newlist
    End Function

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        e.Graphics.Clear(Color.Black)
        Dim CustomBrush As New SolidBrush(LighterIndianRed)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        RoutePen.Width = RouteWidth
        RoutePen.Color = RouteColour

        SortedTopTriangleItemList = MergeSortTriangles(TopTriangleItemList) 'function call to sort top triangles acording to Z value
        SortedBottemTriangleItemList = MergeSortTriangles(BottemTriangleItemList) 'function call to sort bottem triangles acording to Z value

        For i = 0 To SortedTopTriangleItemList.Count - 1
            If SortedTopTriangleItemList IsNot Nothing Then 'ensures there are triangles in the list
                Dim TopPoints() As Point = {SortedTopTriangleItemList(i).P1, SortedTopTriangleItemList(i).P2, SortedTopTriangleItemList(i).P3}
                YValForColour = SortedTopTriangleItemList(i).Elevation 'takes average height value of the triangle
                CustomBrush.Color = ColorGradient(YValForColour) 'function call to return a color for the brush drawing the graphcis based on the elevation of the triangle
                e.Graphics.FillPolygon(CustomBrush, TopPoints) 'fills the triangular area between 3 adjacent vertexes of the grid

                Dim TempPoint1 As New Point
                Dim TempPoint2 As New Point
                For x = 0 To PathMark.Count - 2
                    TempPoint1 = NewPointArray(PathMark(x).X, PathMark(x).Y)
                    TempPoint2 = NewPointArray(PathMark(x + 1).X, PathMark(x + 1).Y)
                    'stores the location of two adjacent points in the route to two temporary variables
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
                    'esentially this whole block of code is to locate which edge of the triangle, the route falls allong, and draw a line along this edge to build part of the route
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
            'same block of code but for the bottem triangles instead of the top triangles
        Next

        Dim RectBrush As New SolidBrush(Color.FromArgb(0, 70, 120))
        Dim PicBox2 As New Rectangle(300, (Me.Height) - 240, Me.Width, 240)
        Dim PicBox1 As New Rectangle(0, 0, 300, (Me.Height + 42))
        e.Graphics.FillRectangle(RectBrush, PicBox2)
        e.Graphics.FillRectangle(RectBrush, PicBox1)
        'some graphical UI formatting

        Dim TempPen As New Pen(Color.White, 4)
        e.Graphics.DrawLine(TempPen, New Point(400, 1020), New Point(400, 870))
        e.Graphics.DrawLine(TempPen, New Point(400, 1020), New Point(1400, 1020))
        'draws the x and y axis for the elevation profile
        TempPen.Width = 1
        For x = 0 To PathMark.Count - 2
            e.Graphics.DrawLine(TempPen, ElevationCoordiates(x), ElevationCoordiates(x + 1))
        Next
        'draws a continuous line connecting descrete height values to make the elevation profile

        Dim ArrowBrush As New SolidBrush(Color.White)
        Dim ArrowPoints1() As Point = {New Point(392, 870), New Point(408, 870), New Point(400, 855)}
        e.Graphics.FillPolygon(ArrowBrush, ArrowPoints1)
        Dim ArrowPoints2() As Point = {New Point(1400, 1012), New Point(1400, 1028), New Point(1415, 1020)}
        e.Graphics.FillPolygon(ArrowBrush, ArrowPoints2)
        'adds arrrows to the end of the x and y axis elevation profile to show direction
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        If compass Is Nothing Then Exit Sub
        If compassBool Then
            TotalAngle = 0 'angle of rotation for the compass set to 0
            CompassAngle = 0
            compassBool = False
        End If

        CompassAngle = TotalAngle * (180 / PI) 'converts inputed angle in degrees to radians 
        MyBase.OnPaint(e)
        Dim g = e.Graphics

        Dim CentreX As Integer = 1750
        Dim CentreY As Integer = 150
        'finds centre of rotation of the compass
        g.TranslateTransform(CentreX, CentreY) 'transposes the centre of matrix rotation to the centre point specified
        g.RotateTransform(CompassAngle) 'rotates the compass bitmap through specified angle
        g.TranslateTransform(-compass.Width \ 2, -compass.Height \ 2) 'updates centre of rotation
        g.DrawImage(compass, 0, 0) 'draws rotated compass to form
    End Sub

    Public Function ColorGradient(ByVal YValForColour) As Color
        If YValForColour < 0.6 Then 'lowest elevation value
            Return Color.FromArgb(220, 220, 220) 'returns the darkest grayscled colour
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
        ElseIf YValForColour >= 1.1 And YValForColour < 1.2 Then 'higher elevation value
            Return Color.FromArgb(100, 100, 100) 'returns a lighter shade of gray
        Else
            Return Color.FromArgb(80, 80, 80)
        End If
        'function that returns a colour based on the height of terrain determined by the argument 
    End Function

    Public Function OffColorGradient(ByVal YValForColour) As Color
        If YValForColour < 0.6 Then
            Return Color.FromArgb(225, 225, 225) 'all rgb colours offset by 5 to distingush slighly from the top triangles
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
        'function for colours of the bottem triangles
    End Function

    Sub KeyFunctions()
        Array.Clear(YValue, 0, YValue.Length) 'clears the array of height values
        For q = 0 To OctaveNum - 1
            PerlinNoise() 'sub call to perlin noise to generate new random height map

            For j = 0 To MapDepth
                For i = 0 To MapWidth
                    YValue(i, j) += (FinalElevationArray(i, j) * (Lacunarity ^ q)) 'each octave has decreasing weight over its previous, dtermined by lacunarity value
                Next 'sums values of height across differnet octaves
            Next
        Next

        For j = 0 To MapDepth
            For i = 0 To MapWidth
                OGPointArray(i, j) = New Point3D((StartX) + (i * ThreeDScaleFactor), (YValue(i, j) * Extremity) + 110, StartZ - (j * ThreeDScaleFactor))
                'ineserts each height value tinto corresponding 3D terrain point
            Next
        Next
    End Sub

    Sub PerspectiveProjection()
        For j = 0 To MapDepth
            For i = 0 To MapWidth 'cycles through every point on the mesh
                XpArray(i, j) = (OGPointArray(i, j).X / ((OGPointArray(i, j).Z + 250) * Tan(A / 2))) * 200
            Next
        Next
        'uses formula to project 3D coordinate to a 2D point, finding the X coordinate of the 2D point in terms of its 3D X and Z components
        For j = 0 To MapDepth
            For i = 0 To MapWidth
                YpArray(i, j) = ((OGPointArray(i, j).Y) / ((OGPointArray(i, j).Z + 250) * Tan(A / 2))) * 200
            Next
        Next
        'uses formula to project 3D coordinate to a 2D point, finding the Y coordinate of the 2D point in terms of its 3D Y and Z components
    End Sub

    Sub PerlinNoise()
        'sub procedure for ken perlins noise algorithm//
        Dim rand As New Random() 'initialises a random variable
        Dim MaxVal As Double = 1.67 * ChunkSize 'determins a maximum value for the dot product between any two vectors in the chunk, based on the chunk size
        Dim RandomNumber As Integer
        Dim CardinalDirectionArray(XChunkAmount, ZChunkAmount) As Integer 'defines am array to hold direction vectors on the vertexes of each chunk

        For y = 0 To ZChunkAmount
            For x = 0 To XChunkAmount
                RandomNumber = (rand.Next(0, 256)) 'generates a random number between 0 and 256
                RandomNumber = PerlinNoisePerm(RandomNumber) Mod 16 'uses random value to pull a value from the perutations table
                'then takes the last 4 bits of this number to get a number in the range 0 - 15
                If RandomNumber >= 12 Then
                    RandomNumber -= 12
                End If
                'wrap around function for values >= 12 to bound range between 0 and 11
                CardinalDirectionArray(x, y) = RandomNumber 'stores this value as the direction vector at the chunk edge
            Next
        Next

        Dim TLElevationArray(MapWidth, MapDepth) As Double
        Dim TRElevationArray(MapWidth, MapDepth) As Double
        Dim BLElevationArray(MapWidth, MapDepth) As Double
        Dim BRElevationArray(MapWidth, MapDepth) As Double

        Dim TLTRElevationArray(MapWidth, MapDepth) As Double
        Dim BLBRElevationArray(MapWidth, MapDepth) As Double
        'defines arrays for combinations of chunk points
        For y = 0 To ZChunkAmount - 1
            For x = 0 To XChunkAmount - 1

                For b1 = 0 To ChunkSize
                    For a1 = 0 To ChunkSize

                        TLElevationArray((x * ChunkSize) + a1, (y * ChunkSize) + b1) = (Cos((CardinalDirectionArray(x, y) * PI) / 6) * a1) + (Sin((CardinalDirectionArray(x, y) * PI) / 6) * b1)
                        TRElevationArray((x * ChunkSize) + a1, (y * ChunkSize) + b1) = (Cos((CardinalDirectionArray(x + 1, y) * PI) / 6) * (ChunkSize - a1)) + (Sin((CardinalDirectionArray(x + 1, y) * PI) / 6) * b1)
                        BLElevationArray((x * ChunkSize) + a1, (y * ChunkSize) + b1) = (Cos((CardinalDirectionArray(x, y + 1) * PI) / 6) * a1) + (Sin((CardinalDirectionArray(x, y + 1) * PI) / 6) * (ChunkSize - b1))
                        BRElevationArray((x * ChunkSize) + a1, (y * ChunkSize) + b1) = (Cos((CardinalDirectionArray(x + 1, y + 1) * PI) / 6) * (ChunkSize - a1)) + (Sin((CardinalDirectionArray(x + 1, y + 1) * PI) / 6) * (ChunkSize - b1))
                        'performs dot product between each infulence vector and each point in the chunk
                        'stores the results into 4 different arrays 
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
                xf = (Temp1 + MaxVal) / (MaxVal * 2) 'scales the points in the range 0 - 1
                TLElevationArray(x, y) = 6 * (xf ^ 5) - 15 * (xf ^ 4) + 10 * (xf ^ 3)
                'uses a 5th degree polynomial, passing the weight values as the domain and producing an output that is re stored to the array
                Temp1 = TRElevationArray(x, y)
                xf = (Temp1 + MaxVal) / (MaxVal * 2)
                TRElevationArray(x, y) = 6 * (xf ^ 5) - 15 * (xf ^ 4) + 10 * (xf ^ 3)

                Temp1 = BLElevationArray(x, y)
                xf = (Temp1 + MaxVal) / (MaxVal * 2)
                BLElevationArray(x, y) = 6 * (xf ^ 5) - 15 * (xf ^ 4) + 10 * (xf ^ 3)

                Temp1 = BRElevationArray(x, y)
                xf = (Temp1 + MaxVal) / (MaxVal * 2)
                BRElevationArray(x, y) = 6 * (xf ^ 5) - 15 * (xf ^ 4) + 10 * (xf ^ 3)
                'smooth step function applied to each array
            Next
        Next



        For y = 0 To ZChunkAmount - 1
            For x = 0 To XChunkAmount - 1

                For b1 = 0 To ChunkSize
                    For a1 = 0 To ChunkSize

                        TopTempDifference = TRElevationArray((x * ChunkSize) + a1, (y * ChunkSize) + b1) - TLElevationArray((x * ChunkSize) + a1, (y * ChunkSize) + b1)
                        TLTRElevationArray((x * ChunkSize) + a1, (y * ChunkSize) + b1) = TLElevationArray((x * ChunkSize) + a1, (y * ChunkSize) + b1) + ((TopTempDifference / 5) * a1)
                        'linear interpolation between topleft and topright infuence vector arrays
                        BottemTempDifference = BRElevationArray((x * ChunkSize) + a1, (y * ChunkSize) + b1) - BLElevationArray((x * ChunkSize) + a1, (y * ChunkSize) + b1)
                        BLBRElevationArray((x * ChunkSize) + a1, (y * ChunkSize) + b1) = BLElevationArray((x * ChunkSize) + a1, (y * ChunkSize) + b1) + ((BottemTempDifference / 5) * a1)
                        'linear interpolation between bottemleft and bottemright infuence vector arrays
                        MergeTempDifference = BLBRElevationArray((x * ChunkSize) + a1, (y * ChunkSize) + b1) - TLTRElevationArray((x * ChunkSize) + a1, (y * ChunkSize) + b1)
                        FinalElevationArray((x * ChunkSize) + a1, (y * ChunkSize) + b1) = TLTRElevationArray((x * ChunkSize) + a1, (y * ChunkSize) + b1) + ((MergeTempDifference / 5) * a1)
                        'linear interpolation again combining two new arrays to produce a final weighting for every point in the mesh
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
                        'performs a correction at the boundary between two chunks where 2 values were prodcued for the same point
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

                    a2 = FinalElevationArray(x - 1, y) 'takes point at the edge of one chunk boundary
                    b2 = FinalElevationArray(x, y) 'takes point at the same edge of the next chunk boundary
                    TempAvg = (b2 - a2) / 4 'averages these points
                    FinalElevationArray(x - 1, y) = TempAvg + a2 'rewirtes them to the final weighting array
                    FinalElevationArray(x, y) = b2 - TempAvg
                End If
            Next
        Next
        'linear interpolation for points adjacent to neighboring chunks on horisontal bounadries, to soften the transition between chunks
        For x = 0 To MapWidth
            For y = 0 To MapDepth

                If y Mod ChunkSize = 0 And y <> 0 Then

                    a2 = FinalElevationArray(x, y - 1) 'takes point at the edge of one chunk boundary
                    b2 = FinalElevationArray(x, y) 'takes point at the same edge of the next chunk boundary
                    TempAvg = (b2 - a2) / 4 'averages these points
                    FinalElevationArray(x, y - 1) = TempAvg + a2 'rewirtes them to the final weighting array
                    FinalElevationArray(x, y) = b2 - TempAvg
                End If
            Next
        Next
        'linear interpolation for points adjacent to neighboring chunks on vertical bounadries, to soften the transition between chunks

    End Sub

    Sub RotateY()
        For j = 0 To MapDepth
            For i = 0 To MapWidth
                Dim TempX As Double = OGPointArray(i, j).X
                Dim TempY As Double = OGPointArray(i, j).Y
                Dim TempZ As Double = OGPointArray(i, j).Z 'stores coordinate of point to be rtotated to temprary X, Y and Z variables
                OGPointArray(i, j).X = (TempX * Cos(AngleY)) + (TempZ * Sin(AngleY))
                OGPointArray(i, j).Z = (TempZ * Cos(AngleY)) - (TempX * Sin(AngleY)) '3D matrix rotation around the y axis
            Next
        Next
        PPand2DArray() 'Sub call to perform perspective projection and graphics processing
    End Sub

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        'detects a mouse click on the form
        OGMouseLocation = e.Location 'stores the cursor location as soon at the mouse is clicked
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
            Dim MouseXMovement As Double = OGMouseLocation.X - e.X 'takes differnece between when the cursor location was last updated and itys current position
            Dim MouseYMovement As Double = OGMouseLocation.Y - e.Y

            If LeftClickDetect = True Then
                AngleY = MouseXMovement * 0.002 'defines an angle of rotation relative to how far the mouse was dragged through between two updates
                TotalAngle += AngleY 'compounds this angle whilst the mouse is dragging
                RotateY() 'sub call to matix rotation of mesh
            End If

            OGMouseLocation = e.Location 'updates the cursor location on the form
            Me.Invalidate() 'invalidates the form to draw the mesh at its new orientation
        End If
    End Sub

    Private Sub Form1_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        LeftClickDetect = False 'updates boolean values to deictate that the mesh is no longer being dragged
        RightClickDetect = False
        MouseDragging = False
    End Sub


    Private Sub Btn_Reset_Click(sender As Object, e As EventArgs) Handles Btn_Reset.Click
        Reset() 'sub call to reset the mesh orientation
    End Sub

    Private Sub Btn_Regenerate_Click(sender As Object, e As EventArgs) Handles Btn_Regenerate.Click
        Array.Clear(YValue, 0, YValue.Length) 'clears existing heights
        For q = 0 To OctaveNum - 1 'loop for number of octaves
            PerlinNoise() 'sub call to perlin noise algorithm

            For j = 0 To MapDepth
                For i = 0 To MapWidth
                    YValue(i, j) += (FinalElevationArray(i, j) * (Lacunarity ^ q)) 'sums height values for individual octaves 
                Next
            Next
        Next

        For j = 0 To MapDepth
            For i = 0 To MapWidth
                OGPointArray(i, j).Y = (YValue(i, j) * Extremity) + 110 'multiplies each height value by the extremity 
            Next
        Next

        PPand2DArray() 'Sub call to perform perspective projection and graphics processing
        Form2.ElevationProfile() 'function call to regenerate the elevation profile
        Form2.RouteStats() 'function call to regenerate route statistics
        Me.Invalidate() 'invalidates the form to rerwirte graphics
    End Sub
    Sub WriteRouteStats()
        If RouteStatsBool = True Then 'comparison to chack weather there are route statistics to be overwritten

            Lbl_Length.Text = "Lenght: " + RouteDistance.ToString + kmstring
            Lbl_MaxElevation.Text = "Maxumum Elevation: " + RouteMaxHeight.ToString + mstring
            Lbl_MinElevation.Text = "Minumum Elevation: " + RouteMinHeight.ToString + mstring
            Lbl_TotalElevation.Text = "Total Elevation: " + RouteTotalHeight.ToString + mstring
            Lbl_Duration.Text = "Duration: " + RouteTime.ToString + "h"
            'writes all the route statistics and correct units of measurements to their corresponding label
        Else
            Lbl_Length.Text = "Lenght: ----"
            Lbl_MaxElevation.Text = "Maxumum Elevation: ----"
            Lbl_MinElevation.Text = "Minumum Elevation: ----"
            Lbl_TotalElevation.Text = "Total Elevation: ----"
            Lbl_Duration.Text = "Duration: ----"
            'otherwise writes null pointers to all labels
        End If
        Lbl_Elevation.Text = "Elevation (" + mstring + ")"
        Lbl_Distance.Text = "Distance (" + kmstring + ")"
        'unit axes labels
    End Sub

    Private Sub Btn_Orbit_Click(sender As Object, e As EventArgs) Handles Btn_Orbit.Click
        If OrbitSwitch = False Then
            Timer1.Start() 'starts the timer for the orbit rotation
            OrbitSwitch = True 'toggle feature on the orbit button making use of a boolean
        Else
            Timer1.Stop() 'stops the timer for the orbit rotation
            OrbitSwitch = False
        End If

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        AngleY = 0.002
        TotalAngle += AngleY 'increments total angle of rotation as duration of orbit increases
        RotateY() 'function call to perform matrix rotation to the orbiting mesh
        Me.Invalidate() 'invalidates the form to update graphics with new orientation of the mesh
    End Sub

    Private Sub Btn_Hide_Click(sender As Object, e As EventArgs) Handles Btn_Hide.Click
        '3D form is to be closed
        Timer1.Stop() 'stops the mesh orbiting
        Reset() 'resets mesh to face north
        OrbitSwitch = False 'untoggles the orbit button the same as if a user had clicked it
        Form2.Show() 'shows the 2D window
        Me.Hide() 'hides current window
    End Sub

    Sub Reset()
        For j = 0 To MapDepth
            For i = 0 To MapWidth
                OGPointArray(i, j) = New Point3D((StartX) + (i * ThreeDScaleFactor), (YValue(i, j) * Extremity) + 110, StartZ - (j * ThreeDScaleFactor))
            Next
        Next
        'resets the 3D coordiantes of all points to their defult positions
        PPand2DArray() 'Sub call to perform perspective projection and graphics processing
        compassBool = True 'alows compass angle to be set to 0
        Me.Invalidate() 'invalidates the form to reset all mesh graphics

    End Sub

    Private Sub Txt_Extremity_TextChanged(sender As Object, e As EventArgs) Handles Txt_Extremity.TextChanged
        UpdateExtremityBool = False
        Dim TempInput As String = Txt_Extremity.Text
        Dim TempValidInput As Integer
        Integer.TryParse(TempInput, TempValidInput) 'only alows integers as valid inputs


        If TempValidInput > 0 And TempValidInput < 60 Then
            Extremity = TempValidInput 'disregards any integer less than 1 and greater than or equal to 60
            UpdateExtremityBool = True 'indicates an update to the extremity
        End If

    End Sub

    Private Sub Btn_UpdateExtremity_Click(sender As Object, e As EventArgs) Handles Btn_UpdateExtremity.Click
        If UpdateExtremityBool = True Then 'checks to see wheater an update has been attempted for the extremity
            For j = 0 To MapDepth
                For i = 0 To MapWidth
                    OGPointArray(i, j).Y = (YValue(i, j) * Extremity) + 110
                Next
            Next
            'rescales all height vlaues in accordance to the new extremity
            PPand2DArray() 'sub call to perspective projection and graphics processing
            Me.Invalidate() 'invalidates the form to change graphics
        End If
    End Sub

    Private Sub Txt_Angle_TextChanged(sender As Object, e As EventArgs) Handles Txt_Angle.TextChanged
        UpdateAngleBool = False
        Dim TempInput = Txt_Angle.Text
        Dim TempValidInput As Integer
        Integer.TryParse(TempInput, TempValidInput) 'only alows integers as valid inputs

        If TempValidInput > 15 And TempValidInput < 180 Then 'disregards any integer less than 16 and greater than or equal to 180
            A = TempValidInput / 180 * PI 'coverts degrees angle input to radians 
            UpdateAngleBool = True 'indicates an update to the angle
        End If

    End Sub

    Private Sub Btn_UpdateAngle_Click(sender As Object, e As EventArgs) Handles Btn_UpdateAngle.Click
        If UpdateAngleBool = True Then  'checks to see wheater an update has been attempted for the angle
            PPand2DArray() 'Sub Call To perspective projection And graphics processing
            Me.Invalidate() 'invalidates the form to change graphics
        End If
    End Sub

    Private Sub Btn_OctaveDown_Click(sender As Object, e As EventArgs) Handles Btn_OctaveDown.Click
        If OctaveNum = 10 Then
            Btn_OctaveUp.Enabled = True 'enables the up octave button
        End If
        OctaveNum -= 1 'decrements the number of octaves of perlin noise
        KeyFunctions()
        PPand2DArray()
        Me.Invalidate()
        If OctaveNum = 1 Then
            Btn_OctaveDown.Enabled = False 'disables this button if the octave number falls to 1
        End If
    End Sub

    Private Sub Btn_OctaveUp_Click(sender As Object, e As EventArgs) Handles Btn_OctaveUp.Click
        If OctaveNum = 1 Then
            Btn_OctaveDown.Enabled = True 'enables the down octave button
        End If
        OctaveNum += 1 'increments the number of octaves of perlin noise
        KeyFunctions()
        PPand2DArray()
        compassBool = True
        Me.Invalidate()
        If OctaveNum = 10 Then
            Btn_OctaveUp.Enabled = False 'disables this button if the octave number rises to 10
        End If
    End Sub

    Private Sub Txt_Lacunarity_TextChanged(sender As Object, e As EventArgs) Handles Txt_Lacunarity.TextChanged
        UpdateLacunarityBool = False
        Dim TempInput = Txt_Lacunarity.Text
        Dim TempValidInput As Double
        Double.TryParse(TempInput, TempValidInput) 'only allows doubles as valid inputs


        If TempValidInput > 0 And TempValidInput < 1 Then 'disregards any value less than 0 and greater than 1
            Lacunarity = TempValidInput
            UpdateLacunarityBool = True 'indicates an update to the lacunarity
        End If
    End Sub

    Private Sub Btn_UpdateLacunarity_Click(sender As Object, e As EventArgs) Handles Btn_UpdateLacunarity.Click
        If UpdateLacunarityBool = True Then 'checks to see wheater an update has been attempted for the lacunarity
            KeyFunctions()
            PPand2DArray()
            'rethreads pipeline
            Me.Invalidate() 'invalidates form to update graphics
        End If
    End Sub
End Class

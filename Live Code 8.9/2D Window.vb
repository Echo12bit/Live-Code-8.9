Imports System.Math
Imports System.Drawing.Drawing2D
Imports System.IO
Imports Live_Code_8._9.Form1
Imports System.Threading

Module Globals2D
    Public PathPointArray(10000) As Point
    Public PathLength As Integer
    Public PathMark As New List(Of Point)
    Public ElevationProfileHeights As New List(Of Double)
    Public MaxElevation As Double
    Public MinElevation As Double
    Public ElevationCoordiates As New List(Of Point)

    Public RouteColour As Color = Color.Yellow
    Public RouteWidth As Double = 4
    Public RoutePen As New Pen(RouteColour, RouteWidth)

    Public GridColour As Color = Color.Wheat
    Public GridWidth As Double = 0.5
    Public GridPen As New Pen(GridColour, GridWidth)

    Public StartNodeColour As Color = Color.Lime
    Public EndNodeColour As Color = Color.Red
    Public IntermediateNodeColour As Color = Color.Yellow

    Public RouteDistance As Double
    Public RouteMaxHeight As Integer
    Public RouteMinHeight As Integer
    Public RouteTotalHeight As Integer
    Public RouteTime As Double

    Public RouteStatsBool As Boolean

    Public HeightScale As Double
    Public WidthScale As Double

    Public ImperialBool As Boolean
    Public MilesMultiplier As Double = 1
    Public FeetMultiplier As Double = 1
    Public kmstring As String = "km"
    Public mstring As String = "m"

    Public WalkingSpeed As Integer = 4
End Module

Public Class Form2
    Dim PointArray2D(MapWidth, MapDepth) As Point
    Dim TranslatedPointArray2D(MapWidth, MapDepth) As Point
    Dim TranslatedPathPointList As New List(Of Point)
    Dim MouseX As Integer
    Dim MouseY As Integer

    Dim StartNodeSwitch As Boolean = False
    Dim StartNodeInPos As Boolean = False
    Dim EndNodeSwitch As Boolean = False
    Dim EndNodeInPos As Boolean = False
    Dim GeneralNodeSwitch As Boolean = False
    Dim GeneralNodeInPos As Boolean = False

    Dim NumOfNodes As Integer

    Dim ClickedButton As Button


    Dim NodeList As New List(Of Button)
    Dim NodesOnGridList As New List(Of Point)


    Const MapWidthBound = 1500
    Const MapDepthBound = 760
    Dim StartMapX As Integer
    Dim StartMapY As Integer
    Dim TempSFWidth As Integer
    Dim TempSFDepth As Integer
    Dim TwoDScaleFactor As Integer
    Dim TranslatedStartX As Integer
    Dim TranslatedStartY As Integer

    Dim StartNodeLocation As New Point(35, 480)
    Dim EndNodeLocation As New Point(100, 480)
    Dim IntermidateNodeLocation As New Point(35, 415)

    Dim GenerateBool As Boolean = True



    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackColor = Color.White
        Me.FormBorderStyle = FormBorderStyle.None
        Me.DoubleBuffered = True

        '////////////////////////////// UI FEATURES \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

        Me.Cursor = Cursors.Cross  'changes cursor to be a cross

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
        'Initialises pictureboxes that build the background UI

        Lbl_MapSize.Text = "Map Size: " + MapWidth.ToString + "x" + MapDepth.ToString
        'writes the initial map dimentions to the label
        CreateNode() 'calls subroutine that creates an intermediate node

        Dim Path As New GraphicsPath()
        Path.AddEllipse(0, 0, 20, 20)
        StartNode.Region = New Region(Path)
        'creates a circular button to be the start node
        Dim Path2 As New GraphicsPath()
        Path2.AddEllipse(0, 0, 20, 20)
        EndNode.Region = New Region(Path2)
        'creates a circular button to be the end node

        StartNode.Location = StartNodeLocation
        EndNode.Location = EndNodeLocation
        'defines the initial location for start and end nodes

        '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\----////////////////////////////////////////

        AddHandler StartNode.Click, AddressOf Node_Click
        AddHandler EndNode.Click, AddressOf Node_Click
        'allows button clicks of start and end nodes to be registered
        Formalities2d() 'call to a subroutine that initialsies a lot of the key functions of the program

        WriteRouteStats() 'call to a subroutine that will initially write null values to all of the route statistics

    End Sub

    Sub Formalities2d()

        '////////////////////////////// ReSize Form 1 Variables \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        ReDim PointArray2D(MapWidth, MapDepth)
        ReDim TranslatedPointArray2D(MapWidth, MapDepth)
        ReDim OGPointArray(MapWidth, MapDepth)
        ReDim XpArray(MapWidth, MapDepth)
        ReDim YpArray(MapWidth, MapDepth)
        ReDim NewPointArray(MapWidth, MapDepth)
        ReDim YValue(MapWidth, MapDepth)
        ReDim FinalElevationArray(MapWidth, MapDepth)
        'rezizes all arrays in relation to user specified mapwidth and mapdepth

        StartX = ((MapWidth / 2) * ThreeDScaleFactor * -1)
        'calculates the 3 dimentinal X coordinate of the top left point of the mesh
        StartZ = (MapDepth / 2) * ThreeDScaleFactor
        'calculates the 3 dimentinal Z coordinate of the top left point of the mesh
        XChunkAmount = MapWidth / ChunkSize 'determines the amount of chunks parallel to the x axis
        ZChunkAmount = MapDepth / ChunkSize 'determines the amount of chunks parallel to the z axis
        '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\----------------////////////////////////////////////////



        '////////////////////////////// ReSize Form 2 Variables \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        TempSFWidth = MapWidthBound \ MapWidth 'stores a value for the proportionate size of the availiable space for the mapwidth vs the actual size of the mapwidth
        TempSFDepth = MapDepthBound \ MapDepth 'stores a value for the proportionate size of the availiable space for the mapdepth vs the actual size of the mapdepth

        If TempSFDepth < TempSFWidth Then 'compares mapwidth and mapdepth proportionate values
            TwoDScaleFactor = TempSFDepth 'enlaregment/ SF determined by depth
        Else
            TwoDScaleFactor = TempSFWidth 'enlaregment/ SF determined by height
        End If
        'decides if the enlagrement of the map is restricted by the mapwidth or mapdepth

        TranslatedStartX = (MapWidth / 2) * TwoDScaleFactor * -1
        TranslatedStartY = (MapDepth / 2) * TwoDScaleFactor

        StartMapX = ((MapWidthBound - (MapWidth * TwoDScaleFactor)) \ 2) + 340 'calculates X coordiate for the top left map point
        StartMapY = ((MapDepthBound - (MapDepth * TwoDScaleFactor)) \ 2) + 40 'calculates Y coordiate for the top left map point


        For j = 0 To MapDepth
            For i = 0 To MapWidth
                PointArray2D(i, j) = New Point((StartX) + (i * ThreeDScaleFactor), (StartZ * -1) + (j * ThreeDScaleFactor))
            Next
        Next
        'creates 2D points as a birds eye view of the 3D terrain mesh and stores them to a 2D array of points

        For j = 0 To MapDepth
            For i = 0 To MapWidth
                TranslatedPointArray2D(i, j) = New Point((StartMapX) + (i * TwoDScaleFactor), (StartMapY) + (j * TwoDScaleFactor))
            Next
        Next
        'creates an enlargement of the 2D array of points that was initiallied above for use in the design a route phase
        '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\----------------////////////////////////////////////////

        Form1.KeyFunctions() 'sub call to 3D form that creates the 3D terrain points and corresponding heignht values
        Me.Invalidate() 'invalidates the form so that graphcis can be drawn
    End Sub

    Private Sub Form2_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        e.Graphics.Clear(Color.Black)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias 'softens the edges between the boundarys of graphics, applies to all graphics

        For j = 0 To MapDepth
            For i = 0 To MapWidth - 1
                YValForColour = YValue(i, j) 'stores height value for each point in the 3D mesh to a temprary variable
                GridPen.Color = Form1.ColorGradient(YValForColour) 'sub call to retrieve a color for the line between two points based on there elevation
                e.Graphics.DrawLine(GridPen, TranslatedPointArray2D(i, j), TranslatedPointArray2D(i + 1, j)) 'draws a line between two adjacently horisontal points
            Next
        Next

        For i = 0 To MapWidth
            For j = 0 To MapDepth - 1
                YValForColour = YValue(i, j)
                GridPen.Color = Form1.ColorGradient(YValForColour)
                e.Graphics.DrawLine(GridPen, TranslatedPointArray2D(i, j), TranslatedPointArray2D(i, j + 1)) 'draws a line between two adjacently vertical points
            Next
        Next

        For j = 0 To MapDepth - 1
            For i = 0 To MapWidth - 1
                YValForColour = YValue(i, j)
                GridPen.Color = Form1.ColorGradient(YValForColour)
                e.Graphics.DrawLine(GridPen, TranslatedPointArray2D(i + 1, j), TranslatedPointArray2D(i, j + 1)) 'draws a line between two adjacently diagonal points
            Next
        Next
        RoutePen.Color = RouteColour 'defines the colour of the pen that draws the route between nodes
        RoutePen.Width = RouteWidth 'defines the width of the pen that draws the route between nodes
        For i = 0 To PathLength - 2
            e.Graphics.DrawLine(RoutePen, TranslatedPathPointList(i), TranslatedPathPointList(i + 1)) 'draws a line between adjacent route points
        Next

        Dim RectBrush As New SolidBrush(Color.FromArgb(0, 70, 120))
        Dim PicBox2 As New Rectangle(300, (Me.Height) - 240, Me.Width, 240)
        Dim PicBox1 As New Rectangle(0, 0, 300, Me.Height + 42)
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

        Dim UIPen As New Pen(Color.White, 2)
        e.Graphics.DrawLine(UIPen, New Point(10, 90), New Point(65, 90))
        e.Graphics.DrawLine(UIPen, New Point(170, 90), New Point(290, 90))
        e.Graphics.DrawLine(UIPen, New Point(10, 370), New Point(68, 370))
        e.Graphics.DrawLine(UIPen, New Point(170, 370), New Point(290, 370))
        e.Graphics.DrawLine(UIPen, New Point(10, 770), New Point(68, 770))
        e.Graphics.DrawLine(UIPen, New Point(170, 770), New Point(290, 770))
        'some more graphical UI formatting


        Dim ArrowBrush As New SolidBrush(Color.White)
        Dim ArrowPoints1() As Point = {New Point(392, 870), New Point(408, 870), New Point(400, 855)}
        e.Graphics.FillPolygon(ArrowBrush, ArrowPoints1)
        Dim ArrowPoints2() As Point = {New Point(1400, 1012), New Point(1400, 1028), New Point(1415, 1020)}
        e.Graphics.FillPolygon(ArrowBrush, ArrowPoints2)
        'adds arrrows to the end of the x and y axis elevation profile to show direction

        StartNode.BackColor = StartNodeColour 'initiallises the color of the start node
        EndNode.BackColor = EndNodeColour 'initiallises the color of the start node

        For i = 0 To NodeList.Count - 1
            NodeList(i).BackColor = IntermediateNodeColour 'initialses the colour of all intermediate nodes
        Next
    End Sub

    Sub PathFinding()
        For l = 0 To NodesOnGridList.Count - 2
            Dim StartPointX As Integer = NodesOnGridList(l).X + 10 'X coordiante of the point underneath where a node on the grid sits
            Dim StartPointY As Integer = NodesOnGridList(l).Y + 10 'Y coordiante of the point underneath where a node on the grid sits
            Dim EndPointX As Integer = NodesOnGridList(l + 1).X + 10 'X coordiante of the point underneath where the next node in the route on the grid sits
            Dim EndPointY As Integer = NodesOnGridList(l + 1).Y + 10 'Y coordiante of the point underneath where the next node in the route on the grid sits
            Dim XDifference As Integer = EndPointX - StartPointX 'finds difference in number of points beween adjacent nodes in the route parralel to x axis
            Dim YDifference As Integer = EndPointY - StartPointY 'finds difference in number of points beween adjacent nodes in the route parralel to y axis

            If XDifference >= 0 And YDifference <= 0 Then 'condition met if the 2nd node is above and right of the first node

                If Abs(XDifference) <= Abs(YDifference) Then 'condition met if the two points are closer horisontally than they are vertically

                    For i = 0 To Abs(XDifference) / TwoDScaleFactor
                        TranslatedPathPointList.Add(New Point(StartPointX + (i * TwoDScaleFactor), StartPointY - (i * TwoDScaleFactor)))
                    Next
                    For i = 1 To (Abs(YDifference) - Abs(XDifference)) / TwoDScaleFactor
                        TranslatedPathPointList.Add(New Point(EndPointX, (StartPointY - Abs(XDifference)) - (i * TwoDScaleFactor)))
                    Next
                    'adds each of the points on the line of most efficient route between to nodes to a list
                Else 'condition met if the two points are closer vertically than they are horisontally

                    For i = 0 To Abs(YDifference) / TwoDScaleFactor
                        TranslatedPathPointList.Add(New Point(StartPointX + (i * TwoDScaleFactor), StartPointY - (i * TwoDScaleFactor)))
                    Next
                    For i = 1 To (Abs(XDifference) - Abs(YDifference)) / TwoDScaleFactor
                        TranslatedPathPointList.Add(New Point((StartPointX + Abs(YDifference)) + (i * TwoDScaleFactor), EndPointY))
                    Next
                    'adds each of the points on the line of most efficient route between to nodes to a list
                End If

            ElseIf XDifference <= 0 And YDifference >= 0 Then 'condition met if the 2nd node is below and left of the first node

                If Abs(XDifference) <= Abs(YDifference) Then 'condition met if the two points are closer horisontally than they are vertically

                    For i = 0 To Abs(XDifference) / TwoDScaleFactor
                        TranslatedPathPointList.Add(New Point(StartPointX - (i * TwoDScaleFactor), StartPointY + (i * TwoDScaleFactor)))
                    Next
                    For i = 1 To (Abs(YDifference) - Abs(XDifference)) / TwoDScaleFactor
                        TranslatedPathPointList.Add(New Point(EndPointX, (StartPointY + Abs(XDifference)) + (i * TwoDScaleFactor)))
                    Next
                    'adds each of the points on the line of most efficient route between to nodes to a list
                Else 'condition met if the two points are closer vertically than they are horisontally

                    For i = 0 To Abs(YDifference) / TwoDScaleFactor
                        TranslatedPathPointList.Add(New Point(StartPointX - (i * TwoDScaleFactor), StartPointY + (i * TwoDScaleFactor)))
                    Next
                    For i = 1 To (Abs(XDifference) - Abs(YDifference)) / TwoDScaleFactor
                        TranslatedPathPointList.Add(New Point((StartPointX - Abs(YDifference)) - (i * TwoDScaleFactor), EndPointY))
                    Next
                    'adds each of the points on the line of most efficient route between to nodes to a list
                End If
            ElseIf XDifference > 0 And YDifference > 0 Then 'condition met if the 2nd node is above and left of the first node

                For i = 0 To Abs(XDifference) / TwoDScaleFactor
                    TranslatedPathPointList.Add(New Point(StartPointX + (i * TwoDScaleFactor), StartPointY))
                Next
                For i = 1 To Abs(YDifference) / TwoDScaleFactor
                    TranslatedPathPointList.Add(New Point(EndPointX, StartPointY + (i * TwoDScaleFactor)))
                Next
                'adds each of the points on the line of most efficient route between to nodes to a list
            ElseIf XDifference < 0 And YDifference < 0 Then 'condition met if the 2nd node is below and right of the first node
                For i = 0 To Abs(XDifference) / TwoDScaleFactor
                    TranslatedPathPointList.Add(New Point(StartPointX - (i * TwoDScaleFactor), StartPointY))
                Next
                For i = 1 To Abs(YDifference) / TwoDScaleFactor
                    TranslatedPathPointList.Add(New Point(EndPointX, StartPointY - (i * TwoDScaleFactor)))
                Next
                'adds each of the points on the line of most efficient route between to nodes to a list
            End If
        Next

        PathLength = TranslatedPathPointList.Count 'stores a value for the lenght of the route

        For i = 0 To PathLength - 1
            PathPointArray(i) = TranslatedPathPointList(i)
            PathPointArray(i) -= New Point(StartMapX + ((MapWidth * TwoDScaleFactor) / 2), StartMapY + ((MapDepth * TwoDScaleFactor) / 2))
            PathPointArray(i).Y /= TwoDScaleFactor
            PathPointArray(i).X /= TwoDScaleFactor
            PathPointArray(i).Y *= ThreeDScaleFactor
            PathPointArray(i).X *= ThreeDScaleFactor
            PathPointArray(i).Y = -PathPointArray(i).Y
        Next
        'untranslates all points in the route from location on 2D map, to standadised location that matches up with the 3D mesh

        For k = 0 To PathLength - 1
            For j = 0 To MapDepth
                For i = 0 To MapWidth
                    If PathPointArray(k).X >= OGPointArray(i, j).X - 1 And PathPointArray(k).X <= OGPointArray(i, j).X + 1 And PathPointArray(k).Y >= OGPointArray(i, j).Z - 1 And PathPointArray(k).Y <= OGPointArray(i, j).Z + 1 Then
                        'compares coordinate of each point in the path to every point on the 3D terrain mesh, allowing for a small tolerance due to rounding values after translation of 2D coordinates
                        PathMark.Add(New Point(i, j)) 'adds the i,j positions of this found point in the route to a point list
                    End If
                Next
            Next
        Next

        Me.Invalidate()
    End Sub

    Sub ElevationProfile()

        ClearProfile() 'sub call to reset all data structures relating to the elevation profile and then clear the old elevation profile graphics from the window
        For j = 0 To MapDepth
            For i = 0 To MapWidth
                If YValue(i, j) > MaxElevation Then MaxElevation = YValue(i, j)
                If YValue(i, j) < MinElevation Then MinElevation = YValue(i, j)
            Next
        Next
        'finds maximum and minimum heights of terrain map

        HeightScale = 150 / MaxElevation 'finds a height scale factor based upon the maximum elevation of the terrain
        WidthScale = 1000 / PathLength 'finds a width scale factor based upon the lenght of the path

        For x = 0 To PathMark.Count - 1
            ElevationProfileHeights.Add((YValue((PathMark(x).X), (PathMark(x).Y))) * HeightScale)
        Next
        'multiplies each height value in the path by the height SF and adds it to a list of heights for the whole path
        For x = 0 To PathMark.Count - 1
            ElevationCoordiates.Add(New Point(((x * WidthScale) + 400), (870 + ElevationProfileHeights(x))))
        Next
        'adds each point of path to a lsit of coordiantes within the elevation profile axes
    End Sub

    Private Sub Btn_Export_Click(sender As Object, e As EventArgs) Handles Btn_Export.Click
        Form1.Show() 'shows the 3D render form
        Me.Hide() 'hides the current form
    End Sub

    Private Sub Form2_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        MouseX = e.X 'holds X coordiate of the current cursor position
        MouseY = e.Y 'holds Y coordiate of the current cursor position
    End Sub

    Private Sub Btn_Exit_Click(sender As Object, e As EventArgs) Handles Btn_Exit.Click
        Application.Exit() 'exits the program
    End Sub

    Private Sub Btn_Generate_Click(sender As Object, e As EventArgs) Handles Btn_Generate.Click
        If GenerateBool Then 'only allows the sub to run if the generate boolean is true meaning the route hasnt already been generated
            If StartNodeInPos = True And EndNodeInPos = True Then 'checks to see if both the start and end node can be found on the grid
                NodesOnGridList.Remove(EndNode.Location) 'last node removed from list as it is always to be visited last so does not need to be factored into the sort
                TravelingSalesman() 'function call to path finding algorithm
                NodesOnGridList.Add(EndNode.Location) 'end node can be re added to list
                PathFinding() 'function call to determine route between idividual nodes
                ElevationProfile() 'function call to create elevation profile of route
                RouteStats() ' function call to produce statistics for route
            End If
            GenerateBool = False 'now that the generate sub routine has been executed, boolean switched to false so it cannot be run again for the same route
        End If

    End Sub

    Sub RouteStats()
        If ImperialBool = True Then 'check if statasitcs are to be in metric or imperial measuremnets
            MilesMultiplier = 0.6 'km to miles multiplier
            FeetMultiplier = 3.3 'meters to feet multiplier
        Else
            MilesMultiplier = 1 'initialised to km
            FeetMultiplier = 1 'initialied to meters
        End If
        RouteDistance = Round((PathMark.Count * 0.1) * MilesMultiplier, 3) 'rounds value for route distance to 3dp
        Dim TempTotalElevation As Double
        Dim TempMaxElevation As Double = 0
        Dim TempMinElevation As Double = 99
        Dim TempList As New List(Of Double)
        For i = 0 To PathMark.Count - 1
            TempList.Add((ElevationProfileHeights(i) / HeightScale) * 1000) 'scales each point
        Next
        For i = 0 To PathMark.Count - 2
            If TempList(i) > TempMaxElevation Then TempMaxElevation = TempList(i) 'comparison to find maximum elevation of the route
            If TempList(i) < TempMinElevation Then TempMinElevation = TempList(i) 'comparison to find minimum elevation of the route

            TempTotalElevation += Abs(TempList(i) - TempList(i + 1)) 'sums the difference between elevation of adjacent points to get a value of the overal elevation gain
        Next

        RouteMaxHeight = Round(TempMaxElevation * FeetMultiplier, 3) 'multiplies maxelevation by coversion to feet/meters and rounds it to 3dp to be stored 
        RouteMinHeight = Round(TempMinElevation * FeetMultiplier, 3) 'multiplies minelevation by coversion to feet/meters and rounds it to 3dp to be stored 

        RouteTotalHeight = Round(TempTotalElevation * FeetMultiplier, 3) 'multiplies totalelevation by coversion to feet/meters and rounds it to 3dp to be stored 
        RouteTime = Round(RouteDistance / WalkingSpeed, 3) 'divided distance by speed and rounds to 3 dp to obtain value for route duration

        RouteStatsBool = True 'allows statistics to override null values

        If ImperialBool = True Then 'check if imperial measurements have been selected
            kmstring = "miles"
            mstring = "ft"
        Else
            kmstring = "km"
            mstring = "m"
        End If
        'changes the names of the units in acordance to preferance

        WriteRouteStats() 'function call to write the route statistics to the 2D window
        Form1.WriteRouteStats() 'function call to write the route statistics to the 3D window
    End Sub

    Sub WriteRouteStats()
        If RouteStatsBool Then 'comparison to chack weather there are route statistics to be overwritten
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
    Private Sub Node_Click(sender As Object, e As EventArgs)
        ClickedButton = DirectCast(sender, Button)
        Dim Tempi As Integer
        Dim Tempj As Integer
        Dim CircleX As Integer
        Dim CircleY As Integer
        Dim TempNodeI As Integer

        If GeneralNodeSwitch = False Then 'GeneralNodeSwitch being false indicates that a node has been selected to be picked up, rather that dropped off
            ClearPath() 'function call to clear a previosly generated path
            For i = 0 To NodesOnGridList.Count - 1
                If NodesOnGridList(i) = ClickedButton.Location Then 'checks to see if the button clicked was one previously on the grid
                    TempNodeI = i
                    NodesOnGridList.RemoveAt(TempNodeI) 'if so, that node is removed from the list of nodes on the list
                    Exit For 'exist imediately if and once this node is found
                End If
            Next

            If ClickedButton.Location = IntermidateNodeLocation Then 'check to see if the node selected is a new intermediate node at its source
                CreateNode() 'if so, sub call to create a new intermediate node to replace it
                NodeList(NodeList.Count - 1).Enabled = False 'disables the new node that was created so that it cannot be clicked whilst holidng the current node, to aviod errors
            End If

            If ClickedButton.Name = "StartNode" Then 'check to see if the button clicked was the startnode
                StartNodeInPos = False 'if so, startnode boolean is set to not in position
            ElseIf ClickedButton.Name = "EndNode" Then 'check to see if the button clicked was the endnode
                EndNodeInPos = False 'if so, endnode boolean is set to not in position
            End If
            Timer1.Start() 'start timer to update button location to the cursor psoition reguarly
            GeneralNodeSwitch = True 'GeneralNodeSwitch set to true to determine that the next click will be to drop of the currently held node
        Else 'comparison determined that the node is to be dropped off
            Timer1.Stop() 'stops timer so node will no longer follow the cursor
            NodeList(NodeList.Count - 1).Enabled = True 'next intermediate node is enabled so can be picked up
            If ClickedButton.Location.X >= StartMapX And ClickedButton.Location.X <= (StartMapX + (MapWidth * TwoDScaleFactor)) And ClickedButton.Location.Y >= StartMapY And ClickedButton.Location.Y <= (StartMapY + (MapDepth * TwoDScaleFactor)) Then
                'comparison to check if the node being dropped of lies within the grid
                For j = 0 To MapDepth
                    For i = 0 To MapWidth
                        If Abs((ClickedButton.Location.X + 10) - TranslatedPointArray2D(i, j).X) <= (TwoDScaleFactor / 2) And Abs((ClickedButton.Location.Y + 10) - TranslatedPointArray2D(i, j).Y) <= (TwoDScaleFactor / 2) Then
                            'if comparison met, find the closest point on the grid to where the node has been dropped
                            Tempi = i
                            Tempj = j
                            'stores this location as a temporary i and j values
                        End If
                    Next
                Next
                CircleX = TranslatedPointArray2D(Tempi, Tempj).X - 10
                CircleY = TranslatedPointArray2D(Tempi, Tempj).Y - 10
                ClickedButton.Location = New Point(CircleX, CircleY) 'snaps the loaction of the clicked button to this closest point on the grid

                If ClickedButton.Name = "StartNode" Then
                    StartNodeInPos = True 'if it was the startnode that was dropped, startnode is indicated to be in position
                    NodesOnGridList.Insert(0, ClickedButton.Location) 'insert the startnode to the first position in the list of nodes on the grid
                ElseIf ClickedButton.Name = "EndNode" Then
                    EndNodeInPos = True 'if it was the endnode that was dropped, endnode is indicated to be in position
                    NodesOnGridList.Add(ClickedButton.Location) 'adds the end node to the back of the list  of nodes on the grid
                Else
                    NodesOnGridList.Add(ClickedButton.Location) 'in the case of an intermediate node, just add it to the list of nodes on the grid
                End If
            Else 'if the clicked node was not dropped within the bounds of the grid

                If ClickedButton.Name = "StartNode" Then
                    ClickedButton.Location = StartNodeLocation 'returns the startnode to its origional location on the UI
                ElseIf ClickedButton.Name = "EndNode" Then
                    ClickedButton.Location = EndNodeLocation 'returns the endnode to its origional location on the UI
                Else 'if it was an intermediate node that was dropped
                    Me.Controls.Remove(NodeList(NodeList.Count - 1))
                    NodeList.RemoveAt(NodeList.Count - 1)
                    ClickedButton.Location = IntermidateNodeLocation
                    'remove next node from spawn location and replace with the node that got dropped, also remove the next node from the list of intermediate nodes
                End If
            End If
            GeneralNodeSwitch = False 'GeneralNodeSwitch set to false to determine that the next click will be to pick up a new node
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ClickedButton.Location = New Point(Cursor.Position.X - 10, Cursor.Position.Y - 10) 'for each tick, aligns the location of the clicekd node to the cursor position
    End Sub

    Sub TravelingSalesman()
        For i = 0 To NodesOnGridList.Count - 2 'loops for every node on the grid
            Dim CurrentShortestDistance As Integer = 1000
            Dim ShortestDistanceIndex As Integer
            Dim TempPoint As Point
            For j = i + 1 To NodesOnGridList.Count - 1 'takes an individual node and loops for a comparison to all other nodes on the grid
                Dim StartPointX As Integer = NodesOnGridList(i).X + 10
                Dim StartPointY As Integer = NodesOnGridList(i).Y + 10
                Dim EndPointX As Integer = NodesOnGridList(j).X + 10
                Dim EndPointY As Integer = NodesOnGridList(j).Y + 10
                Dim XDifference As Integer = EndPointX - StartPointX
                Dim YDifference As Integer = EndPointY - StartPointY

                If Abs(XDifference) + Abs(YDifference) < CurrentShortestDistance Then 'comparison of distance between the selected node and the current node beign checked, and between the selected node and its current nearest node
                    CurrentShortestDistance = Abs(XDifference) + Abs(YDifference) 'if the current node is found to be closer that all of the nodes pervious, update the current shortest distance
                    ShortestDistanceIndex = j 'store the index for the node that produces the shortest distance
                End If
            Next
            TempPoint = NodesOnGridList(ShortestDistanceIndex)
            NodesOnGridList.Remove(TempPoint)
            NodesOnGridList.Insert(i + 1, TempPoint) 'reorders list to bulid most efficeint route from start to end node
        Next
    End Sub
    Sub ClearPath()
        GenerateBool = True
        TranslatedPathPointList.Clear()
        PathMark.Clear()
        Array.Clear(PathPointArray, 0, PathPointArray.Length)
        PathLength = 0
        'clears data structures relating to the storing of path points
        RouteStatsBool = False 'sets the route satistics boolean to false so null values will be written to all catogories
        WriteRouteStats()
        Form1.WriteRouteStats()
        'sub calls to rewirte null values to the route statistics on the UI
        Me.Invalidate() 'invalidates the form to reset route graphics
    End Sub

    Sub ClearProfile()
        MaxElevation = 0
        MinElevation = 0
        HeightScale = 0
        WidthScale = 0
        ElevationCoordiates.Clear()
        ElevationProfileHeights.Clear()
        'clears data structures relating to the elevation profile
        Me.Invalidate() 'invalidates the form to remove elevation profile graphics
    End Sub

    Sub ClearNodes()
        For i = NodeList.Count - 1 To 0 Step -1
            Me.Controls.Remove(NodeList(i))
            NodeList.RemoveAt(NodeList.Count - 1)
        Next
        'deletes every intermediate node systematically
        StartNode.Location = StartNodeLocation 'rests the startnode to its origional location
        EndNode.Location = EndNodeLocation 'rests the endnode to its origional location
        ClearPath() 'sub call to clear the path 
        CreateNode() 'creates one intermediate node to be replaced at its origional location

        NodesOnGridList.Clear() 'clears list of all nodes previously on the grid
    End Sub

    Private Sub Btn_Clear_Click(sender As Object, e As EventArgs) Handles Btn_Clear.Click
        ClearNodes() 'sub call to clear all nodes from the grid
    End Sub

    Sub CreateNode()
        Dim Path3 As New GraphicsPath()
        Path3.AddEllipse(0, 0, 20, 20)

        Dim TempBtn As New Button() With {
                .Name = "Intermediate" & NodeList.Count.ToString,
                .Location = IntermidateNodeLocation,
                .FlatStyle = FlatStyle.Flat,
                .BackColor = IntermediateNodeColour,
                .Region = New Region(Path3)
        }
        'defines properties of intermediate node
        NodeList.Add(TempBtn) 'adds button to form
        Me.Controls.Add(NodeList(NodeList.Count - 1))
        NodeList(NodeList.Count - 1).BringToFront()
        AddHandler NodeList(NodeList.Count - 1).Click, AddressOf Node_Click 'allows clicking the button to be detected

    End Sub

    Private Sub Btn_WidthDown_Click(sender As Object, e As EventArgs) Handles Btn_WidthDown.Click
        If MapWidth = 100 Then
            Btn_WidthUp.Enabled = True 'enables the increase width button if it was perviously disabled
        End If
        MapWidth -= 10 'decrements the mapwidth by 10
        ThreeDScaleFactor = ThreeDScaleFactorDeterminant() 'rescales the map
        Formalities2d() 'redims all arrays/variables with new grid dimensions
        ClearNodes() 'clears any existing nodes from the grid
        Lbl_MapSize.Text = "Map Size: " + MapWidth.ToString + "x" + MapDepth.ToString 'updates label with new grid dimentions
        If MapWidth = 10 Then
            Btn_WidthDown.Enabled = False 'if the mapwidth falls to 10, disable the mapwdith down button
        End If
    End Sub

    Private Sub Btn_WidthUp_Click(sender As Object, e As EventArgs) Handles Btn_WidthUp.Click
        If MapWidth = 10 Then
            Btn_WidthDown.Enabled = True 'enables the decrease width button if it was perviously disabled
        End If
        MapWidth += 10 'increments the mapwidth by 10
        ThreeDScaleFactor = ThreeDScaleFactorDeterminant() 'rescales the map
        Formalities2d() 'redims all arrays/variables with new grid dimensions
        ClearNodes() 'clears any existing nodes from the grid
        Lbl_MapSize.Text = "Map Size: " + MapWidth.ToString + "x" + MapDepth.ToString 'updates label with new grid dimentions
        If MapWidth = 100 Then
            Btn_WidthUp.Enabled = False 'if the mapwidth rises to 100, disable the mapwdith up button
        End If

    End Sub

    Private Sub Btn_DepthDown_Click(sender As Object, e As EventArgs) Handles Btn_DepthDown.Click
        If MapDepth = 100 Then
            Btn_DepthUp.Enabled = True 'enables the increase depth button if it was perviously disabled
        End If
        MapDepth -= 10 'decrements the mapdepth by 10
        ThreeDScaleFactor = ThreeDScaleFactorDeterminant() 'rescales the map
        Formalities2d() 'redims all arrays/variables with new grid dimensions
        ClearNodes() 'clears any existing nodes from the grid
        Lbl_MapSize.Text = "Map Size: " + MapWidth.ToString + "x" + MapDepth.ToString 'updates label with new grid dimentions
        If MapDepth = 10 Then
            Btn_DepthDown.Enabled = False 'if the mapdepth falls to 10, disable the mapdepth down button
        End If
    End Sub

    Private Sub Btn_DepthUp_Click(sender As Object, e As EventArgs) Handles Btn_DepthUp.Click
        If MapDepth = 10 Then
            Btn_DepthDown.Enabled = True 'enables the decrease depth button if it was perviously disabled
        End If

        MapDepth += 10 'increments the mapdepth by 10
        ThreeDScaleFactor = ThreeDScaleFactorDeterminant() 'rescales the map
        Formalities2d() 'redims all arrays/variables with new grid dimensions
        ClearNodes() 'clears any existing nodes from the grid
        Lbl_MapSize.Text = "Map Size: " + MapWidth.ToString + "x" + MapDepth.ToString 'updates label with new grid dimentions
        If MapDepth = 100 Then
            Btn_DepthUp.Enabled = False 'if the mapdepth rises to 100, disable the mapdepth up button
        End If
    End Sub

    Function ThreeDScaleFactorDeterminant()
        Dim TempLargest As Integer
        If MapWidth > MapDepth Then
            TempLargest = MapWidth
        Else
            TempLargest = MapDepth
        End If
        'takes the larger of the two dimensions
        Select Case TempLargest
            Case 10
                Return 20
            Case 20
                Return 10
            Case 30, 40, 50
                Return 5
            Case 60
                Return 4
            Case 70, 80
                Return 3
            Case 90, 100
                Return 2
        End Select
        'returns a value for the SF multiplier between points on the mesh based on how large the overall mesh is
    End Function

    Private Sub Btn_RouteColouring_Click(sender As Object, e As EventArgs) Handles Btn_RouteColouring.Click
        Route_Colouring.Show() 'shows the route colouring form
    End Sub

    Private Sub Btn_Preferances_Click(sender As Object, e As EventArgs) Handles Btn_Preferances.Click
        Preferences.Show() 'shows the preferances form 
    End Sub
End Class
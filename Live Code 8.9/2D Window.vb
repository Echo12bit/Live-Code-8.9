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
        Dim Path2 As New GraphicsPath()
        Path2.AddEllipse(0, 0, 20, 20)
        EndNode.Region = New Region(Path2)

        StartNode.Location = StartNodeLocation
        EndNode.Location = EndNodeLocation

        '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\----////////////////////////////////////////

        AddHandler StartNode.Click, AddressOf Node_Click
        AddHandler EndNode.Click, AddressOf Node_Click

        Formalities2d()

        WriteRouteStats()

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



        StartX = ((MapWidth / 2) * ThreeDScaleFactor * -1)
        StartZ = (MapDepth / 2) * ThreeDScaleFactor


        XChunkAmount = MapWidth / ChunkSize
        ZChunkAmount = MapDepth / ChunkSize
        '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\----------------////////////////////////////////////////



        '////////////////////////////// ReSize Form 2 Variables \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        TempSFWidth = MapWidthBound \ MapWidth
        TempSFDepth = MapDepthBound \ MapDepth

        If TempSFDepth < TempSFWidth Then
            TwoDScaleFactor = TempSFDepth
        Else
            TwoDScaleFactor = TempSFWidth
        End If

        TranslatedStartX = (MapWidth / 2) * TwoDScaleFactor * -1
        TranslatedStartY = (MapDepth / 2) * TwoDScaleFactor

        StartMapX = ((MapWidthBound - (MapWidth * TwoDScaleFactor)) \ 2) + 340
        StartMapY = ((MapDepthBound - (MapDepth * TwoDScaleFactor)) \ 2) + 40


        For j = 0 To MapDepth
            For i = 0 To MapWidth
                PointArray2D(i, j) = New Point((StartX) + (i * ThreeDScaleFactor), (StartZ * -1) + (j * ThreeDScaleFactor))
            Next
        Next


        For j = 0 To MapDepth
            For i = 0 To MapWidth
                TranslatedPointArray2D(i, j) = New Point((StartMapX) + (i * TwoDScaleFactor), (StartMapY) + (j * TwoDScaleFactor))
            Next
        Next
        '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\----------------////////////////////////////////////////
        Form1.KeyFunctions()
        Me.Invalidate()
    End Sub

    Private Sub Form2_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        e.Graphics.Clear(Color.Black)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        For j = 0 To MapDepth
            For i = 0 To MapWidth - 1
                YValForColour = YValue(i, j)
                GridPen.Color = Form1.ColorGradient(YValForColour)
                e.Graphics.DrawLine(GridPen, TranslatedPointArray2D(i, j), TranslatedPointArray2D(i + 1, j))
            Next
        Next

        For i = 0 To MapWidth
            For j = 0 To MapDepth - 1
                YValForColour = YValue(i, j)
                GridPen.Color = Form1.ColorGradient(YValForColour)
                e.Graphics.DrawLine(GridPen, TranslatedPointArray2D(i, j), TranslatedPointArray2D(i, j + 1))
            Next
        Next

        For j = 0 To MapDepth - 1
            For i = 0 To MapWidth - 1
                YValForColour = YValue(i, j)
                GridPen.Color = Form1.ColorGradient(YValForColour)
                e.Graphics.DrawLine(GridPen, TranslatedPointArray2D(i + 1, j), TranslatedPointArray2D(i, j + 1))
            Next
        Next
        RoutePen.Color = RouteColour
        RoutePen.Width = RouteWidth
        For i = 0 To PathLength - 2
            e.Graphics.DrawLine(RoutePen, TranslatedPathPointList(i), TranslatedPathPointList(i + 1))
        Next

        Dim RectBrush As New SolidBrush(Color.FromArgb(0, 70, 120))
        Dim PicBox2 As New Rectangle(300, (Me.Height) - 240, Me.Width, 240)
        Dim PicBox1 As New Rectangle(0, 0, 300, Me.Height + 42)
        e.Graphics.FillRectangle(RectBrush, PicBox2)
        e.Graphics.FillRectangle(RectBrush, PicBox1)

        Dim TempPen As New Pen(Color.White, 4)
        e.Graphics.DrawLine(TempPen, New Point(400, 1020), New Point(400, 870))
        e.Graphics.DrawLine(TempPen, New Point(400, 1020), New Point(1400, 1020))


        TempPen.Width = 1
        For x = 0 To PathMark.Count - 2
            e.Graphics.DrawLine(TempPen, ElevationCoordiates(x), ElevationCoordiates(x + 1))
        Next

        Dim UIPen As New Pen(Color.White, 2)
        e.Graphics.DrawLine(UIPen, New Point(10, 90), New Point(65, 90))
        e.Graphics.DrawLine(UIPen, New Point(170, 90), New Point(290, 90))
        e.Graphics.DrawLine(UIPen, New Point(10, 370), New Point(68, 370))
        e.Graphics.DrawLine(UIPen, New Point(170, 370), New Point(290, 370))
        e.Graphics.DrawLine(UIPen, New Point(10, 770), New Point(68, 770))
        e.Graphics.DrawLine(UIPen, New Point(170, 770), New Point(290, 770))


        Dim ArrowBrush As New SolidBrush(Color.White)
        Dim ArrowPoints1() As Point = {New Point(392, 870), New Point(408, 870), New Point(400, 855)}
        e.Graphics.FillPolygon(ArrowBrush, ArrowPoints1)
        Dim ArrowPoints2() As Point = {New Point(1400, 1012), New Point(1400, 1028), New Point(1415, 1020)}
        e.Graphics.FillPolygon(ArrowBrush, ArrowPoints2)

        StartNode.BackColor = StartNodeColour
        EndNode.BackColor = EndNodeColour

        For i = 0 To NodeList.Count - 1
            NodeList(i).BackColor = IntermediateNodeColour
        Next
    End Sub

    Sub PathFinding()
        For l = 0 To NodesOnGridList.Count - 2
            Dim StartPointX As Integer = NodesOnGridList(l).X + 10
            Dim StartPointY As Integer = NodesOnGridList(l).Y + 10
            Dim EndPointX As Integer = NodesOnGridList(l + 1).X + 10
            Dim EndPointY As Integer = NodesOnGridList(l + 1).Y + 10
            Dim XDifference As Integer = EndPointX - StartPointX
            Dim YDifference As Integer = EndPointY - StartPointY

            If XDifference >= 0 And YDifference <= 0 Then

                If Abs(XDifference) <= Abs(YDifference) Then

                    For i = 0 To Abs(XDifference) / TwoDScaleFactor
                        TranslatedPathPointList.Add(New Point(StartPointX + (i * TwoDScaleFactor), StartPointY - (i * TwoDScaleFactor)))
                    Next
                    For i = 1 To (Abs(YDifference) - Abs(XDifference)) / TwoDScaleFactor
                        TranslatedPathPointList.Add(New Point(EndPointX, (StartPointY - Abs(XDifference)) - (i * TwoDScaleFactor)))
                    Next
                Else

                    For i = 0 To Abs(YDifference) / TwoDScaleFactor
                        TranslatedPathPointList.Add(New Point(StartPointX + (i * TwoDScaleFactor), StartPointY - (i * TwoDScaleFactor)))
                    Next
                    For i = 1 To (Abs(XDifference) - Abs(YDifference)) / TwoDScaleFactor
                        TranslatedPathPointList.Add(New Point((StartPointX + Abs(YDifference)) + (i * TwoDScaleFactor), EndPointY))
                    Next
                End If

            ElseIf XDifference <= 0 And YDifference >= 0 Then

                If Abs(XDifference) <= Abs(YDifference) Then

                    For i = 0 To Abs(XDifference) / TwoDScaleFactor
                        TranslatedPathPointList.Add(New Point(StartPointX - (i * TwoDScaleFactor), StartPointY + (i * TwoDScaleFactor)))
                    Next
                    For i = 1 To (Abs(YDifference) - Abs(XDifference)) / TwoDScaleFactor
                        TranslatedPathPointList.Add(New Point(EndPointX, (StartPointY + Abs(XDifference)) + (i * TwoDScaleFactor)))
                    Next
                Else

                    For i = 0 To Abs(YDifference) / TwoDScaleFactor
                        TranslatedPathPointList.Add(New Point(StartPointX - (i * TwoDScaleFactor), StartPointY + (i * TwoDScaleFactor)))
                    Next
                    For i = 1 To (Abs(XDifference) - Abs(YDifference)) / TwoDScaleFactor
                        TranslatedPathPointList.Add(New Point((StartPointX - Abs(YDifference)) - (i * TwoDScaleFactor), EndPointY))
                    Next

                End If
            ElseIf XDifference > 0 And YDifference > 0 Then
                For i = 0 To Abs(XDifference) / TwoDScaleFactor
                    TranslatedPathPointList.Add(New Point(StartPointX + (i * TwoDScaleFactor), StartPointY))
                Next
                For i = 1 To Abs(YDifference) / TwoDScaleFactor
                    TranslatedPathPointList.Add(New Point(EndPointX, StartPointY + (i * TwoDScaleFactor)))
                Next
            ElseIf XDifference < 0 And YDifference < 0 Then
                For i = 0 To Abs(XDifference) / TwoDScaleFactor
                    TranslatedPathPointList.Add(New Point(StartPointX - (i * TwoDScaleFactor), StartPointY))
                Next
                For i = 1 To Abs(YDifference) / TwoDScaleFactor
                    TranslatedPathPointList.Add(New Point(EndPointX, StartPointY - (i * TwoDScaleFactor)))
                Next
            End If
        Next

        PathLength = TranslatedPathPointList.Count

        For i = 0 To PathLength - 1
            PathPointArray(i) = TranslatedPathPointList(i)
            PathPointArray(i) -= New Point(StartMapX + ((MapWidth * TwoDScaleFactor) / 2), StartMapY + ((MapDepth * TwoDScaleFactor) / 2))
            PathPointArray(i).Y /= TwoDScaleFactor
            PathPointArray(i).X /= TwoDScaleFactor
            PathPointArray(i).Y *= ThreeDScaleFactor
            PathPointArray(i).X *= ThreeDScaleFactor
            PathPointArray(i).Y = -PathPointArray(i).Y
        Next

        For k = 0 To PathLength - 1
            For j = 0 To MapDepth
                For i = 0 To MapWidth
                    If PathPointArray(k).X >= OGPointArray(i, j).X - 1 And PathPointArray(k).X <= OGPointArray(i, j).X + 1 And PathPointArray(k).Y >= OGPointArray(i, j).Z - 1 And PathPointArray(k).Y <= OGPointArray(i, j).Z + 1 Then
                        PathMark.Add(New Point(i, j))
                    End If
                Next
            Next
        Next

        Me.Invalidate()
    End Sub

    Sub ElevationProfile()

        ClearProfile()
        For j = 0 To MapDepth
            For i = 0 To MapWidth
                If YValue(i, j) > MaxElevation Then MaxElevation = YValue(i, j)
                If YValue(i, j) < MinElevation Then MinElevation = YValue(i, j)
            Next
        Next

        HeightScale = 150 / MaxElevation
        WidthScale = 1000 / PathLength

        For x = 0 To PathMark.Count - 1
            ElevationProfileHeights.Add((YValue((PathMark(x).X), (PathMark(x).Y))) * HeightScale)
        Next


        For x = 0 To PathMark.Count - 1
            ElevationCoordiates.Add(New Point(((x * WidthScale) + 400), (870 + ElevationProfileHeights(x))))
        Next
    End Sub

    Private Sub Btn_Export_Click(sender As Object, e As EventArgs) Handles Btn_Export.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Form2_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        MouseX = e.X
        MouseY = e.Y
    End Sub

    Private Sub Btn_Exit_Click(sender As Object, e As EventArgs) Handles Btn_Exit.Click
        Application.Exit()
    End Sub

    Private Sub Btn_Generate_Click(sender As Object, e As EventArgs) Handles Btn_Generate.Click
        If GenerateBool Then
            If StartNodeInPos = True And EndNodeInPos = True Then
                NodesOnGridList.Remove(EndNode.Location)
                TravelingSalesman()
                NodesOnGridList.Add(EndNode.Location)
                PathFinding()
                ElevationProfile()
                RouteStats()
            End If
            GenerateBool = False
        End If

    End Sub

    Sub RouteStats()
        If ImperialBool = True Then
            MilesMultiplier = 0.6
            FeetMultiplier = 3.3
        Else
            MilesMultiplier = 1
            FeetMultiplier = 1
        End If
        RouteDistance = Round((PathMark.Count * 0.1) * MilesMultiplier, 3)
        Dim TempTotalElevation As Double
        Dim TempMaxElevation As Double = 0
        Dim TempMinElevation As Double = 99
        Dim TempList As New List(Of Double)
        For i = 0 To PathMark.Count - 1
            TempList.Add((ElevationProfileHeights(i) / HeightScale) * 1000)
        Next
        For i = 0 To PathMark.Count - 2
            If TempList(i) > TempMaxElevation Then TempMaxElevation = TempList(i)
            If TempList(i) < TempMinElevation Then TempMinElevation = TempList(i)

            TempTotalElevation += Abs(TempList(i) - TempList(i + 1))
        Next

        RouteMaxHeight = Round(TempMaxElevation * FeetMultiplier, 3)
        RouteMinHeight = Round(TempMinElevation * FeetMultiplier, 3)

        RouteTotalHeight = Round(TempTotalElevation * FeetMultiplier)
        RouteTime = Round(RouteDistance / WalkingSpeed, 3)

        RouteStatsBool = True

        If ImperialBool = True Then
            kmstring = "miles"
            mstring = "ft"
        Else
            kmstring = "km"
            mstring = "m"
        End If


        WriteRouteStats()
        Form1.WriteRouteStats()

    End Sub

    Sub WriteRouteStats()
        If RouteStatsBool Then
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
    Private Sub Node_Click(sender As Object, e As EventArgs)
        ClickedButton = DirectCast(sender, Button)
        Dim Tempi As Integer
        Dim Tempj As Integer
        Dim CircleX As Integer
        Dim CircleY As Integer
        Dim TempNodeI As Integer

        If GeneralNodeSwitch = False Then
            ClearPath()
            For i = 0 To NodesOnGridList.Count - 1
                If NodesOnGridList(i) = ClickedButton.Location Then
                    TempNodeI = i
                    NodesOnGridList.RemoveAt(TempNodeI)
                    Exit For
                End If
            Next

            If ClickedButton.Location = IntermidateNodeLocation Then
                CreateNode()
                NodeList(NodeList.Count - 1).Enabled = False
            End If

            If ClickedButton.Name = "StartNode" Then
                StartNodeInPos = False
            ElseIf ClickedButton.Name = "EndNode" Then
                EndNodeInPos = False
            End If
            Timer1.Start()
            GeneralNodeSwitch = True
        Else
            Timer1.Stop()
            NodeList(NodeList.Count - 1).Enabled = True
            If ClickedButton.Location.X >= StartMapX And ClickedButton.Location.X <= (StartMapX + (MapWidth * TwoDScaleFactor)) And ClickedButton.Location.Y >= StartMapY And ClickedButton.Location.Y <= (StartMapY + (MapDepth * TwoDScaleFactor)) Then
                For j = 0 To MapDepth
                    For i = 0 To MapWidth
                        If Abs((ClickedButton.Location.X + 10) - TranslatedPointArray2D(i, j).X) <= (TwoDScaleFactor / 2) And Abs((ClickedButton.Location.Y + 10) - TranslatedPointArray2D(i, j).Y) <= (TwoDScaleFactor / 2) Then
                            Tempi = i
                            Tempj = j
                        End If
                    Next
                Next
                CircleX = TranslatedPointArray2D(Tempi, Tempj).X - 10
                CircleY = TranslatedPointArray2D(Tempi, Tempj).Y - 10
                ClickedButton.Location = New Point(CircleX, CircleY)

                If ClickedButton.Name = "StartNode" Then
                    StartNodeInPos = True
                    NodesOnGridList.Insert(0, ClickedButton.Location)
                ElseIf ClickedButton.Name = "EndNode" Then
                    EndNodeInPos = True
                    NodesOnGridList.Add(ClickedButton.Location)
                Else
                    NodesOnGridList.Add(ClickedButton.Location)
                End If
            Else

                If ClickedButton.Name = "StartNode" Then

                    ClickedButton.Location = StartNodeLocation

                ElseIf ClickedButton.Name = "EndNode" Then

                    ClickedButton.Location = EndNodeLocation
                Else
                    Me.Controls.Remove(NodeList(NodeList.Count - 1))
                    NodeList.RemoveAt(NodeList.Count - 1)
                    ClickedButton.Location = IntermidateNodeLocation
                End If
            End If
            GeneralNodeSwitch = False
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ClickedButton.Location = New Point(Cursor.Position.X - 10, Cursor.Position.Y - 10)
    End Sub

    Sub TravelingSalesman()
        For i = 0 To NodesOnGridList.Count - 2
            Dim CurrentShortestDistance As Integer = 1000
            Dim ShortestDistanceIndex As Integer
            Dim TempPoint As Point
            For j = i + 1 To NodesOnGridList.Count - 1
                Dim StartPointX As Integer = NodesOnGridList(i).X + 10
                Dim StartPointY As Integer = NodesOnGridList(i).Y + 10
                Dim EndPointX As Integer = NodesOnGridList(j).X + 10
                Dim EndPointY As Integer = NodesOnGridList(j).Y + 10
                Dim XDifference As Integer = EndPointX - StartPointX
                Dim YDifference As Integer = EndPointY - StartPointY

                If Abs(XDifference) + Abs(YDifference) < CurrentShortestDistance Then
                    CurrentShortestDistance = Abs(XDifference) + Abs(YDifference)
                    ShortestDistanceIndex = j
                End If
            Next
            TempPoint = NodesOnGridList(ShortestDistanceIndex)
            NodesOnGridList.Remove(TempPoint)
            NodesOnGridList.Insert(i + 1, TempPoint)
        Next
    End Sub
    Sub ClearPath()
        GenerateBool = True
        TranslatedPathPointList.Clear()
        PathMark.Clear()
        Array.Clear(PathPointArray, 0, PathPointArray.Length)
        PathLength = 0
        RouteStatsBool = False
        WriteRouteStats()
        Form1.WriteRouteStats()
        Me.Invalidate()
    End Sub

    Sub ClearProfile()
        MaxElevation = 0
        MinElevation = 0
        HeightScale = 0
        WidthScale = 0
        ElevationCoordiates.Clear()
        ElevationProfileHeights.Clear()
        Me.Invalidate()
    End Sub

    Sub ClearNodes()
        For i = NodeList.Count - 1 To 0 Step -1
            Me.Controls.Remove(NodeList(i))
            NodeList.RemoveAt(NodeList.Count - 1)
        Next
        StartNode.Location = StartNodeLocation
        EndNode.Location = EndNodeLocation
        ClearPath()
        CreateNode()

        NodesOnGridList.Clear()


    End Sub

    Private Sub Btn_Clear_Click(sender As Object, e As EventArgs) Handles Btn_Clear.Click

        ClearNodes()

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

        NodeList.Add(TempBtn)
        Me.Controls.Add(NodeList(NodeList.Count - 1))
        NodeList(NodeList.Count - 1).BringToFront()
        AddHandler NodeList(NodeList.Count - 1).Click, AddressOf Node_Click

    End Sub

    Private Sub Btn_WidthDown_Click(sender As Object, e As EventArgs) Handles Btn_WidthDown.Click
        If MapWidth = 100 Then
            Btn_WidthUp.Enabled = True
        End If
        MapWidth -= 10
        ThreeDScaleFactor = ThreeDScaleFactorDeterminant()
        Formalities2d()
        ClearNodes()
        Lbl_MapSize.Text = "Map Size: " + MapWidth.ToString + "x" + MapDepth.ToString
        If MapWidth = 10 Then
            Btn_WidthDown.Enabled = False
        End If
    End Sub

    Private Sub Btn_WidthUp_Click(sender As Object, e As EventArgs) Handles Btn_WidthUp.Click
        If MapWidth = 10 Then
            Btn_WidthDown.Enabled = True
        End If
        MapWidth += 10
        ThreeDScaleFactor = ThreeDScaleFactorDeterminant()
        Formalities2d()
        ClearNodes()
        Lbl_MapSize.Text = "Map Size: " + MapWidth.ToString + "x" + MapDepth.ToString
        If MapWidth = 100 Then
            Btn_WidthUp.Enabled = False
        End If

    End Sub

    Private Sub Btn_DepthDown_Click(sender As Object, e As EventArgs) Handles Btn_DepthDown.Click
        If MapDepth = 100 Then
            Btn_DepthUp.Enabled = True
        End If
        MapDepth -= 10
        ThreeDScaleFactor = ThreeDScaleFactorDeterminant()
        Formalities2d()
        ClearNodes()
        Lbl_MapSize.Text = "Map Size: " + MapWidth.ToString + "x" + MapDepth.ToString
        If MapDepth = 10 Then
            Btn_DepthDown.Enabled = False
        End If
    End Sub

    Private Sub Btn_DepthUp_Click(sender As Object, e As EventArgs) Handles Btn_DepthUp.Click
        If MapDepth = 10 Then
            Btn_DepthDown.Enabled = True
        End If

        MapDepth += 10
        ThreeDScaleFactor = ThreeDScaleFactorDeterminant()
        Formalities2d()
        ClearNodes()
        Lbl_MapSize.Text = "Map Size: " + MapWidth.ToString + "x" + MapDepth.ToString
        If MapDepth = 100 Then
            Btn_DepthUp.Enabled = False
        End If
    End Sub

    Function ThreeDScaleFactorDeterminant()
        Dim TempLargest As Integer
        If MapWidth > MapDepth Then
            TempLargest = MapWidth
        Else
            TempLargest = MapDepth
        End If

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
    End Function

    Private Sub Btn_2DMeshColoring_Click(sender As Object, e As EventArgs)
        Mesh_Colouring.Show()
    End Sub

    Private Sub Btn_RouteColouring_Click(sender As Object, e As EventArgs) Handles Btn_RouteColouring.Click
        Route_Colouring.Show()
    End Sub

    Private Sub Btn_Preferances_Click(sender As Object, e As EventArgs) Handles Btn_Preferances.Click
        Preferences.Show()
    End Sub
End Class
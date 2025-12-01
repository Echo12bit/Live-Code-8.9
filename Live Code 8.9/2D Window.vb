Imports System.Math
Imports System.Drawing.Drawing2D
Imports System.IO

Module Globals2D
    Public PathPointArray(10000) As Point
    Public PathLength As Integer
    Public PathMark As New List(Of Point)
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

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackColor = Color.White
        Me.FormBorderStyle = FormBorderStyle.None
        Me.DoubleBuffered = True

        '////////////////////////////// UI FEATURES \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

        Me.Cursor = Cursors.Cross

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

        CreateNode()


        Dim Path As New GraphicsPath()
        Path.AddEllipse(0, 0, 20, 20)
        StartNode.Region = New Region(Path)
        Dim Path2 As New GraphicsPath()
        Path2.AddEllipse(0, 0, 20, 20)
        EndNode.Region = New Region(Path)

        StartNode.Location = New Point(500, 900)
        EndNode.Location = New Point(500, 950)

        '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\----////////////////////////////////////////

        For j = 0 To MapDepth
            For i = 0 To MapWidth
                PointArray2D(i, j) = New Point((StartX) + (i * PointIncr), (StartZ * -1) + (j * PointIncr))             'PointArray2D(i, j) = New Point((i * 20) + 600, (j * 20) + 100)
            Next
        Next

        For j = 0 To MapDepth
            For i = 0 To MapWidth
                TranslatedPointArray2D(i, j) = PointArray2D(i, j)
                TranslatedPointArray2D(i, j).X *= 4
                TranslatedPointArray2D(i, j).Y *= 4
                TranslatedPointArray2D(i, j) += New Point(1100, 400)
            Next
        Next

        AddHandler StartNode.Click, AddressOf Node_Click
        AddHandler EndNode.Click, AddressOf Node_Click
    End Sub

    Sub ClearPath()
        TranslatedPathPointList.Clear()
        Array.Clear(PathPointArray, 0, PathPointArray.Length)
        PathMark.Clear()
        PathLength = 0
        Me.Invalidate()
    End Sub
    Private Sub Form2_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        'e.Graphics.Clear(Color.Black)
        Dim Pen2D As New Pen(Color.Brown, 0.5)
        Dim PathPen As New Pen(Color.Yellow, 4)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        For j = 0 To MapDepth
            For i = 0 To MapWidth - 1
                Pen2D.Color = Form1.ColorGradient(i, j)
                e.Graphics.DrawLine(Pen2D, TranslatedPointArray2D(i, j), TranslatedPointArray2D(i + 1, j))
            Next
        Next

        For i = 0 To MapWidth
            For j = 0 To MapDepth - 1
                Pen2D.Color = Form1.ColorGradient(i, j)
                e.Graphics.DrawLine(Pen2D, TranslatedPointArray2D(i, j), TranslatedPointArray2D(i, j + 1))
            Next
        Next

        For j = 0 To MapDepth - 1
            For i = 0 To MapWidth - 1
                Pen2D.Color = Form1.ColorGradient(i, j)
                e.Graphics.DrawLine(Pen2D, TranslatedPointArray2D(i + 1, j), TranslatedPointArray2D(i, j + 1))
            Next
        Next

        For i = 0 To PathLength - 2
            e.Graphics.DrawLine(PathPen, TranslatedPathPointList(i), TranslatedPathPointList(i + 1))
        Next
    End Sub

    Sub PathFinding()
        ClearPath()
        For l = 0 To NodesOnGridList.Count - 2
            Dim StartPointX As Integer = NodesOnGridList(l).X + 10
            Dim StartPointY As Integer = NodesOnGridList(l).Y + 10
            Dim EndPointX As Integer = NodesOnGridList(l + 1).X + 10
            Dim EndPointY As Integer = NodesOnGridList(l + 1).Y + 10
            Dim XDifference As Integer = EndPointX - StartPointX
            Dim YDifference As Integer = EndPointY - StartPointY

            If XDifference >= 0 And YDifference <= 0 Then

                If Abs(XDifference) <= Abs(YDifference) Then

                    For i = 0 To Abs(XDifference) / 20
                        TranslatedPathPointList.Add(New Point(StartPointX + (i * 20), StartPointY - (i * 20)))
                        PathLength += 1
                    Next
                    For i = 1 To (Abs(YDifference) - Abs(XDifference)) / 20
                        TranslatedPathPointList.Add(New Point(EndPointX, (StartPointY - Abs(XDifference)) - (i * 20)))
                        PathLength += 1
                    Next
                Else

                    For i = 0 To Abs(YDifference) / 20
                        TranslatedPathPointList.Add(New Point(StartPointX + (i * 20), StartPointY - (i * 20)))
                        PathLength += 1
                    Next
                    For i = 1 To (Abs(XDifference) - Abs(YDifference)) / 20
                        TranslatedPathPointList.Add(New Point((StartPointX + Abs(YDifference)) + (i * 20), EndPointY))
                        PathLength += 1
                    Next
                End If

            ElseIf XDifference <= 0 And YDifference >= 0 Then

                If Abs(XDifference) <= Abs(YDifference) Then

                    For i = 0 To Abs(XDifference) / 20
                        TranslatedPathPointList.Add(New Point(StartPointX - (i * 20), StartPointY + (i * 20)))
                        PathLength += 1
                    Next
                    For i = 1 To (Abs(YDifference) - Abs(XDifference)) / 20
                        TranslatedPathPointList.Add(New Point(EndPointX, (StartPointY + Abs(XDifference)) + (i * 20)))
                        PathLength += 1
                    Next
                Else

                    For i = 0 To Abs(YDifference) / 20
                        TranslatedPathPointList.Add(New Point(StartPointX - (i * 20), StartPointY + (i * 20)))
                        PathLength += 1
                    Next
                    For i = 1 To (Abs(XDifference) - Abs(YDifference)) / 20
                        TranslatedPathPointList.Add(New Point((StartPointX - Abs(YDifference)) - (i * 20), EndPointY))
                        PathLength += 1
                    Next

                End If
            ElseIf XDifference > 0 And YDifference > 0 Then
                For i = 0 To Abs(XDifference) / 20
                    TranslatedPathPointList.Add(New Point(StartPointX + (i * 20), StartPointY))
                    PathLength += 1
                Next
                For i = 1 To Abs(YDifference) / 20
                    TranslatedPathPointList.Add(New Point(EndPointX, StartPointY + (i * 20)))
                    PathLength += 1
                Next
            ElseIf XDifference < 0 And YDifference < 0 Then
                For i = 0 To Abs(XDifference) / 20
                    TranslatedPathPointList.Add(New Point(StartPointX - (i * 20), StartPointY))
                    PathLength += 1
                Next
                For i = 1 To Abs(YDifference) / 20
                    TranslatedPathPointList.Add(New Point(EndPointX, StartPointY - (i * 20)))
                    PathLength += 1
                Next
            End If
        Next

        For i = 0 To PathLength - 1
            PathPointArray(i) = TranslatedPathPointList(i)
            PathPointArray(i) -= New Point(1100, 400)
            PathPointArray(i).Y \= 4
            PathPointArray(i).X \= 4
            PathPointArray(i).Y = -PathPointArray(i).Y
        Next

        For k = 0 To PathLength - 1
            For j = 0 To MapDepth
                For i = 0 To MapWidth
                    If PathPointArray(k).X >= OGPointArray(i, j).X - 2 And PathPointArray(k).X <= OGPointArray(i, j).X + 2 And PathPointArray(k).Y >= OGPointArray(i, j).Z - 2 And PathPointArray(k).Y <= OGPointArray(i, j).Z + 2 Then
                        PathMark.Add(New Point(i, j))
                    End If

                Next
            Next

        Next

        Me.Invalidate()
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

        If StartNodeInPos = True And EndNodeInPos = True Then
            NodesOnGridList.Remove(EndNode.Location)
            TravelingSalesman()
            NodesOnGridList.Add(EndNode.Location)
            PathFinding()
        End If
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

            If ClickedButton.Location = New Point(250, 600) Then
                CreateNode()
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
            If ClickedButton.Location.X >= 612 And ClickedButton.Location.X <= 1590 And ClickedButton.Location.Y >= 110 And ClickedButton.Location.Y <= 690 Then
                For j = 0 To MapDepth
                    For i = 0 To MapWidth
                        If Abs((ClickedButton.Location.X + 10) - TranslatedPointArray2D(i, j).X) <= 10 And Abs((ClickedButton.Location.Y + 10) - TranslatedPointArray2D(i, j).Y) <= 10 Then
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

                    ClickedButton.Location = New Point(500, 900)

                ElseIf ClickedButton.Name = "EndNode" Then

                    ClickedButton.Location = New Point(500, 950)
                Else
                    Me.Controls.Remove(NodeList(NodeList.Count - 1))
                    NodeList.RemoveAt(NodeList.Count - 1)
                    ClickedButton.Location = New Point(250, 600)
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

    Private Sub Btn_Clear_Click(sender As Object, e As EventArgs) Handles Btn_Clear.Click

        For i = NodeList.Count - 1 To 0 Step -1
            Me.Controls.Remove(NodeList(i))
            NodeList.RemoveAt(NodeList.Count - 1)
        Next
        StartNode.Location = New Point(500,900)
        EndNode.Location = New Point(500, 950)

        CreateNode()
        ClearPath()
    End Sub

    Sub CreateNode()
        Dim Path3 As New GraphicsPath()
        Path3.AddEllipse(0, 0, 20, 20)

        Dim TempBtn As New Button() With {
                .Name = "Intermediate" & NodeList.Count.ToString,
                .Location = New Point(250, 600),
                .FlatStyle = FlatStyle.Flat,
                .BackColor = Color.Yellow,
                .Region = New Region(Path3)
        }

        NodeList.Add(TempBtn)
        Me.Controls.Add(NodeList(NodeList.Count - 1))
        NodeList(NodeList.Count - 1).BringToFront()
        AddHandler NodeList(NodeList.Count - 1).Click, AddressOf Node_Click

    End Sub
End Class
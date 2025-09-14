
Imports System.Math
Imports System.ComponentModel.Design.Serialization
Imports System.Security.Cryptography
Imports System.Threading
Imports System.Drawing.Drawing2D

Public Class Form2
    Dim PointArray2D(100, 100) As Point
    Dim PathPointArray(10000) As Point

    Dim MouseX As Integer
    Dim MouseY As Integer


    Dim StartNodeSwitch As Boolean = False
    Dim StartNodeInPos As Boolean
    Dim EndNodeSwitch As Boolean = False
    Dim EndNodeInPos As Boolean

    Dim PathLength As Integer


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
                PointArray2D(i, j) = New Point((i * 20) + 600, (j * 20) + 100)
            Next
        Next
    End Sub

    Sub ClearPath()
        Array.Clear(PathPointArray, 0, PathPointArray.Length)
        PathLength = 0
        Me.Invalidate()
    End Sub
    Private Sub Form2_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        e.Graphics.Clear(Color.Black)
        Dim Pen2D As New Pen(Color.Brown, 0.5)
        Dim PathPen As New Pen(Color.Yellow, 2)



        For j = 0 To MapDepth
            For i = 0 To MapWidth - 1
                Pen2D.Color = Form1.ColorGradient(i, j)
                e.Graphics.DrawLine(Pen2D, PointArray2D(i, j), PointArray2D(i + 1, j))
            Next
        Next

        For i = 0 To MapWidth
            For j = 0 To MapDepth - 1
                Pen2D.Color = Form1.ColorGradient(i, j)
                e.Graphics.DrawLine(Pen2D, PointArray2D(i, j), PointArray2D(i, j + 1))
            Next
        Next

        For j = 0 To MapDepth - 1
            For i = 0 To MapWidth - 1
                Pen2D.Color = Form1.ColorGradient(i, j)
                e.Graphics.DrawLine(Pen2D, PointArray2D(i + 1, j), PointArray2D(i, j + 1))
            Next
        Next

        For i = 0 To PathLength - 2
            e.Graphics.DrawLine(PathPen, PathPointArray(i), PathPointArray(i + 1))
        Next
    End Sub

    Sub PathFinding()
        Dim StartPointX As Integer = StartNode.Location.X + 10
        Dim StartPointY As Integer = StartNode.Location.Y + 10
        Dim EndPointX As Integer = EndNode.Location.X + 10
        Dim EndPointY As Integer = EndNode.Location.Y + 10
        Dim XDifference As Integer = EndPointX - StartPointX
        Dim YDifference As Integer = EndPointY - StartPointY
        ClearPath()
        If XDifference >= 0 And YDifference <= 0 Then

            If Abs(XDifference) <= Abs(YDifference) Then

                For i = 0 To Abs(XDifference) / 20
                    PathPointArray(i) = New Point(StartPointX + (i * 20), StartPointY - (i * 20))
                    PathLength += 1
                Next
                For i = 1 To (Abs(YDifference) - Abs(XDifference)) / 20
                    PathPointArray(Abs(XDifference) / 20 + i) = New Point(EndPointX, (StartPointY - Abs(XDifference)) - (i * 20))
                    PathLength += 1
                Next
            Else

                For i = 0 To Abs(YDifference) / 20
                    PathPointArray(i) = New Point(StartPointX + (i * 20), StartPointY - (i * 20))
                    PathLength += 1
                Next
                For i = 1 To (Abs(XDifference) - Abs(YDifference)) / 20
                    PathPointArray(Abs(YDifference) / 20 + i) = New Point((StartPointX + Abs(YDifference)) + (i * 20), EndPointY)
                    PathLength += 1
                Next
            End If

        ElseIf XDifference <= 0 And YDifference >= 0 Then

            If Abs(XDifference) <= Abs(YDifference) Then

                For i = 0 To Abs(XDifference) / 20
                    PathPointArray(i) = New Point(StartPointX - (i * 20), StartPointY + (i * 20))
                    PathLength += 1
                Next
                For i = 1 To (Abs(YDifference) - Abs(XDifference)) / 20
                    PathPointArray(Abs(XDifference) / 20 + i) = New Point(EndPointX, (StartPointY + Abs(XDifference)) + (i * 20))
                    PathLength += 1
                Next
            Else

                For i = 0 To Abs(YDifference) / 20
                    PathPointArray(i) = New Point(StartPointX - (i * 20), StartPointY + (i * 20))
                    PathLength += 1
                Next
                For i = 1 To (Abs(XDifference) - Abs(YDifference)) / 20
                    PathPointArray(Abs(YDifference) / 20 + i) = New Point((StartPointX - Abs(YDifference)) - (i * 20), EndPointY)
                    PathLength += 1
                Next

            End If
        ElseIf XDifference > 0 And YDifference > 0 Then
            For i = 0 To Abs(XDifference) / 20
                PathPointArray(i) = New Point(StartPointX + (i * 20), StartPointY)
                PathLength += 1
            Next
            For i = 1 To Abs(YDifference) / 20
                PathPointArray(Abs(XDifference) / 20 + i) = New Point(EndPointX, StartPointY + (i * 20))
                PathLength += 1
            Next
        ElseIf XDifference < 0 And YDifference < 0 Then
            For i = 0 To Abs(XDifference) / 20
                PathPointArray(i) = New Point(StartPointX - (i * 20), StartPointY)
                PathLength += 1
            Next
            For i = 1 To Abs(YDifference) / 20
                PathPointArray(Abs(XDifference) / 20 + i) = New Point(EndPointX, StartPointY - (i * 20))
                PathLength += 1
            Next
        End If


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

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        StartNode.Location = New Point(Cursor.Position.X - 10, Cursor.Position.Y - 10)

    End Sub

    Private Sub Btn_Exit_Click(sender As Object, e As EventArgs) Handles Btn_Exit.Click
        Application.Exit()
    End Sub

    Private Sub StartNode_Click(sender As Object, e As EventArgs) Handles StartNode.Click
        Dim Tempi As Integer
        Dim Tempj As Integer
        Dim CircleX As Integer
        Dim CircleY As Integer
        If StartNodeSwitch = False Then
            ClearPath()
            StartNodeInPos = False
            Timer1.Start()
            StartNodeSwitch = True
        Else
            Timer1.Stop()
            If StartNode.Location.X >= 600 And StartNode.Location.X <= 1580 And StartNode.Location.Y >= 100 And StartNode.Location.Y <= 680 Then
                For j = 0 To MapDepth
                    For i = 0 To MapWidth
                        If Abs((StartNode.Location.X + 10) - PointArray2D(i, j).X) <= 10 And Abs((StartNode.Location.Y + 10) - PointArray2D(i, j).Y) <= 10 Then
                            Tempi = i
                            Tempj = j
                        End If
                    Next
                Next
                CircleX = PointArray2D(Tempi, Tempj).X - 10
                CircleY = PointArray2D(Tempi, Tempj).Y - 10
                StartNode.Location = New Point(CircleX, CircleY)
                StartNodeInPos = True
            Else
                StartNode.Location = New Point(500, 900)
            End If
            StartNodeSwitch = False
        End If
    End Sub

    Private Sub EndNode_Click(sender As Object, e As EventArgs) Handles EndNode.Click
        Dim Tempi As Integer
        Dim Tempj As Integer
        Dim CircleX As Integer
        Dim CircleY As Integer
        If EndNodeSwitch = False Then
            ClearPath()
            EndNodeInPos = False
            Timer2.Start()
            EndNodeSwitch = True
        Else
            Timer2.Stop()
            If EndNode.Location.X >= 600 And EndNode.Location.X <= 1580 And EndNode.Location.Y >= 100 And EndNode.Location.Y <= 680 Then
                For j = 0 To MapDepth
                    For i = 0 To MapWidth
                        If Abs((EndNode.Location.X + 10) - PointArray2D(i, j).X) <= 10 And Abs((EndNode.Location.Y + 10) - PointArray2D(i, j).Y) <= 10 Then
                            Tempi = i
                            Tempj = j
                        End If
                    Next
                Next
                CircleX = PointArray2D(Tempi, Tempj).X - 10
                CircleY = PointArray2D(Tempi, Tempj).Y - 10
                EndNode.Location = New Point(CircleX, CircleY)
                EndNodeInPos = True
            Else
                EndNode.Location = New Point(500, 950)
            End If
            EndNodeSwitch = False
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        EndNode.Location = New Point(Cursor.Position.X - 10, Cursor.Position.Y - 10)
    End Sub

    Private Sub Btn_Generate_Click(sender As Object, e As EventArgs) Handles Btn_Generate.Click
        If StartNodeInPos = True And EndNodeInPos = True Then
            PathFinding()
        End If
    End Sub
End Class
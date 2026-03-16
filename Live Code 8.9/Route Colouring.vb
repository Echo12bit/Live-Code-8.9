Imports System.Drawing.Drawing2D

Public Class Route_Colouring

    Dim StartNodeSelector As Boolean
    Dim EndNodeSelector As Boolean

    Private Sub Btn_HideRoteColouring_Click(sender As Object, e As EventArgs) Handles Btn_HideRoteColouring.Click
        Me.Hide()
    End Sub

    Private Sub Button_Click(sender As Object, e As EventArgs) _
    Handles Btn_RouteRed.Click, Btn_RouteOrange.Click, Btn_RouteYellow.Click, Btn_RouteGreen.Click, Btn_RouteCyan.Click, Btn_RouteBlue.Click, Btn_RoutePurple.Click, Btn_RoutePink.Click, Btn_RouteWidth2.Click, Btn_RouteWidth4.Click, Btn_RouteWidth6.Click, Btn_RouteWidth8.Click

        Dim btn = CType(sender, Button)

        Select Case btn.Name
            Case "Btn_RouteRed"
                RouteColour = Color.Red
            Case "Btn_RouteOrange"
                RouteColour = Color.Orange
            Case "Btn_RouteYellow"
                RouteColour = Color.Yellow
            Case "Btn_RouteGreen"
                RouteColour = Color.Lime
            Case "Btn_RouteCyan"
                RouteColour = Color.Aqua
            Case "Btn_RouteBlue"
                RouteColour = Color.Blue
            Case "Btn_RoutePurple"
                RouteColour = Color.Purple
            Case "Btn_RoutePink"
                RouteColour = Color.Pink
            Case "Btn_RouteWidth2"
                RouteWidth = 2
            Case "Btn_RouteWidth4"
                RouteWidth = 4
            Case "Btn_RouteWidth6"
                RouteWidth = 6
            Case "Btn_RouteWidth8"
                RouteWidth = 8
        End Select
        Form2.Invalidate()
    End Sub
    Private Sub Form2_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint

    End Sub

    Private Sub Route_Colouring_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Path1 As New GraphicsPath()
        Path1.AddEllipse(0, 0, 40, 40)
        Btn_RouteRed.Region = New Region(Path1)
        Btn_RouteOrange.Region = New Region(Path1)
        Btn_RouteYellow.Region = New Region(Path1)
        Btn_RouteGreen.Region = New Region(Path1)
        Btn_RouteCyan.Region = New Region(Path1)
        Btn_RouteBlue.Region = New Region(Path1)
        Btn_RoutePurple.Region = New Region(Path1)
        Btn_RoutePink.Region = New Region(Path1)
    End Sub

    Private Sub Btn_NodeRed_Click(sender As Object, e As EventArgs) Handles Btn_NodeRed.Click
        Select Case ComboBox1.SelectedItem.ToString
            Case "StartNode"
                StartNodeColour = Color.Red
            Case "EndNode"
                EndNodeColour = Color.Red
            Case "IntermediateNode"
                IntermediateNodeColour = Color.Red
        End Select
        Form2.Invalidate()
    End Sub

    Private Sub Btn_NodeOrange_Click(sender As Object, e As EventArgs) Handles Btn_NodeOrange.Click
        Select Case ComboBox1.SelectedItem.ToString
            Case "StartNode"
                StartNodeColour = Color.Orange
            Case "EndNode"
                EndNodeColour = Color.Orange
            Case "IntermediateNode"
                IntermediateNodeColour = Color.Orange
        End Select
        Form2.Invalidate()
    End Sub

    Private Sub Btn_NodeYellow_Click(sender As Object, e As EventArgs) Handles Btn_NodeYellow.Click
        Select Case ComboBox1.SelectedItem.ToString
            Case "StartNode"
                StartNodeColour = Color.Yellow
            Case "EndNode"
                EndNodeColour = Color.Yellow
            Case "IntermediateNode"
                IntermediateNodeColour = Color.Yellow
        End Select
        Form2.Invalidate()
    End Sub

    Private Sub Btn_NodeGreen_Click(sender As Object, e As EventArgs) Handles Btn_NodeGreen.Click
        Select Case ComboBox1.SelectedItem.ToString
            Case "StartNode"
                StartNodeColour = Color.Lime
            Case "EndNode"
                EndNodeColour = Color.Lime
            Case "IntermediateNode"
                IntermediateNodeColour = Color.Lime
        End Select
        Form2.Invalidate()
    End Sub

    Private Sub Btn_NodeCyan_Click(sender As Object, e As EventArgs) Handles Btn_NodeCyan.Click
        Select Case ComboBox1.SelectedItem.ToString
            Case "StartNode"
                StartNodeColour = Color.Aqua
            Case "EndNode"
                EndNodeColour = Color.Aqua
            Case "IntermediateNode"
                IntermediateNodeColour = Color.Aqua
        End Select
        Form2.Invalidate()
    End Sub

    Private Sub Btn_NodeBlue_Click(sender As Object, e As EventArgs) Handles Btn_NodeBlue.Click
        Select Case ComboBox1.SelectedItem.ToString
            Case "StartNode"
                StartNodeColour = Color.Blue
            Case "EndNode"
                EndNodeColour = Color.Blue
            Case "IntermediateNode"
                IntermediateNodeColour = Color.Blue
        End Select
        Form2.Invalidate()
    End Sub

    Private Sub Btn_NodePurple_Click(sender As Object, e As EventArgs) Handles Btn_NodePurple.Click
        Select Case ComboBox1.SelectedItem.ToString
            Case "StartNode"
                StartNodeColour = Color.Purple
            Case "EndNode"
                EndNodeColour = Color.Purple
            Case "IntermediateNode"
                IntermediateNodeColour = Color.Purple
        End Select
        Form2.Invalidate()
    End Sub

    Private Sub Btn_NodePink_Click(sender As Object, e As EventArgs) Handles Btn_NodePink.Click
        Select Case ComboBox1.SelectedItem.ToString
            Case "StartNode"
                StartNodeColour = Color.Pink
            Case "EndNode"
                EndNodeColour = Color.Pink
            Case "IntermediateNode"
                IntermediateNodeColour = Color.Pink
        End Select
        Form2.Invalidate()
    End Sub
End Class
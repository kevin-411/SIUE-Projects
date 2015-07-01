Imports System.IO
Imports System.Data.OleDb
Public Class Navigation
    Inherits Panel
#Region "GLOBALS"
    Const EDGE_PADDING As Integer = 20
    Const INFINITY As Integer = Integer.MaxValue
    Dim floorImages() As ImageContainer = New ImageContainer(3) {} 'holds a copy of the original floor Images
    Dim edges() As Edge = New Edge(1000) {} 'Up to 1001 Edges change this later when we actually know the number
    Dim nodes() As Node = New Node(400) {} 'Up to 401 Nodes
    Dim currentPath() As Integer = New Integer(400) {}
    Dim edgeCount As Integer = 0 ' Edge index of the actual amount of edges currently loaded
    Dim nodeCount As Integer = 0 ' Node index  of the actual amount of edges currently loaded
    Dim currentPathIndex As Integer = 0 'currentPath index of the actual path
    Dim img As PictureBox
    Dim img2 As PictureBox
    Dim hashTab As Hashtable = New Hashtable
    Dim bigPicHeight As Integer = 700
    Dim littlePicHeight As Integer = 400
#End Region
    Sub New(ByVal origin As String, ByVal dest As String)
        LoadFloorPics()
        LoadNodes()
        LoadRooms()
        DrawMaps(origin, dest)
    End Sub
    Public Function getPics() As PictureBox()
        Dim imgCont As ImageContainer = New ImageContainer(img.Image)
        Dim imgCont2 As ImageContainer = New ImageContainer(img2.Image)
        Dim pics() = New PictureBox(3) {}
        imgCont.resetHeight(bigPicHeight)
        imgCont2.resetHeight(bigPicHeight)
        
        pics(0) = imgCont.getImage
        pics(1) = imgCont2.getImage
        imgCont.resetHeight(littlePicHeight)
        imgCont2.resetHeight(littlePicHeight)
        pics(2) = imgCont.getImage
        pics(3) = imgCont2.getImage
        Return pics
    End Function
    Public Sub setBigPicHeight(ByVal h As Integer)
        bigPicHeight = h
    End Sub
    Public Sub setLittlePicHeight(ByVal h As Integer)
        littlePicHeight = h
    End Sub
    Private Sub LoadFloorPics()
        Dim floorStrings() As String = {"LowerLevel.jpg", "FirstFloor.jpg", "SecondFloor.jpg", "ThirdFloor.jpg"}
        Dim imagePath As String = Application.StartupPath & "\FloorPlanImages\"
        Dim imgCont As ImageContainer

        For Each path In floorStrings
            imgCont = New ImageContainer(Image.FromFile(imagePath & path))
            imgCont.resetHeight(500)
            floorImages(Array.IndexOf(floorStrings, path)) = imgCont
        Next

    End Sub
    Private Sub LoadNodes()
        AddNodeToArrayAndHashTab(New Node(100, 608, "001", Node.Type_Key.WALKWAY, {"002", "027"}))
        AddNodeToArrayAndHashTab(New Node(100, 632, "002", Node.Type_Key.WALKWAY, {"001", "003", "026"}))
        AddNodeToArrayAndHashTab(New Node(165, 632, "003", Node.Type_Key.WALKWAY, {"002", "004"}))
        AddNodeToArrayAndHashTab(New Node(194, 632, "004", Node.Type_Key.WALKWAY, {"003", "005"}))
        AddNodeToArrayAndHashTab(New Node(278, 632, "005", Node.Type_Key.WALKWAY, {"004", "006"}))
        AddNodeToArrayAndHashTab(New Node(317, 632, "006", Node.Type_Key.WALKWAY, {"005", "007"}))
        AddNodeToArrayAndHashTab(New Node(335, 632, "007", Node.Type_Key.WALKWAY, {"006", "008"}))
        AddNodeToArrayAndHashTab(New Node(416, 632, "008", Node.Type_Key.WALKWAY, {"007", "009"}))
        AddNodeToArrayAndHashTab(New Node(504, 632, "009", Node.Type_Key.WALKWAY, {"008", "010"}))
        AddNodeToArrayAndHashTab(New Node(504, 518, "010", Node.Type_Key.WALKWAY, {"009", "011", "016"}))
        AddNodeToArrayAndHashTab(New Node(504, 400, "011", Node.Type_Key.WALKWAY, {"010", "012"}))
        AddNodeToArrayAndHashTab(New Node(504, 257, "012", Node.Type_Key.WALKWAY, {"011", "013"}))
        AddNodeToArrayAndHashTab(New Node(504, 212, "013", Node.Type_Key.WALKWAY, {"012", "014"}))
        AddNodeToArrayAndHashTab(New Node(504, 123, "014", Node.Type_Key.WALKWAY, {"013", "015"}))
        AddNodeToArrayAndHashTab(New Node(504, 57, "015", Node.Type_Key.WALKWAY, {"014"}))
        AddNodeToArrayAndHashTab(New Node(557, 518, "016", Node.Type_Key.WALKWAY, {"010", "017"}))
        AddNodeToArrayAndHashTab(New Node(589, 518, "017", Node.Type_Key.WALKWAY, {"016", "018", "028"}))
        AddNodeToArrayAndHashTab(New Node(621, 518, "018", Node.Type_Key.WALKWAY, {"017", "019"}))
        AddNodeToArrayAndHashTab(New Node(675, 518, "019", Node.Type_Key.WALKWAY, {"018", "020"}))
        AddNodeToArrayAndHashTab(New Node(716, 518, "020", Node.Type_Key.WALKWAY, {"019", "021", "029"}))
        AddNodeToArrayAndHashTab(New Node(735, 518, "021", Node.Type_Key.WALKWAY, {"020", "022"}))
        AddNodeToArrayAndHashTab(New Node(772, 518, "022", Node.Type_Key.WALKWAY, {"021", "023"}))
        AddNodeToArrayAndHashTab(New Node(906, 518, "023", Node.Type_Key.WALKWAY, {"022", "024"}))
        AddNodeToArrayAndHashTab(New Node(966, 518, "024", Node.Type_Key.WALKWAY, {"023", "025"}))
        AddNodeToArrayAndHashTab(New Node(966, 555, "025", Node.Type_Key.WALKWAY, {"024", "030"}))
        AddNodeToArrayAndHashTab(New Node(50, 632, "026", Node.Type_Key.STAIRWAYORELEVATOR, {"002", "133"})) ' back steps
        AddNodeToArrayAndHashTab(New Node(50, 608, "027", Node.Type_Key.STAIRWAYORELEVATOR, {"001", "128"})) ' back elevator
        AddNodeToArrayAndHashTab(New Node(589, 563, "028", Node.Type_Key.STAIRWAYORELEVATOR, {"017", "131"})) ' front elevator
        AddNodeToArrayAndHashTab(New Node(716, 490, "029", Node.Type_Key.STAIRWAYORELEVATOR, {"020", "129"})) ' cicle stairs up to floor 1
        AddNodeToArrayAndHashTab(New Node(1010, 555, "030", Node.Type_Key.STAIRWAYORELEVATOR, {"025", "132"})) ' front steps
        AddNodeToArrayAndHashTab(New Node(82, 510, "101", Node.Type_Key.WALKWAY, {"102", "120"}))
        AddNodeToArrayAndHashTab(New Node(82, 620, "102", Node.Type_Key.WALKWAY, {"127", "103", "133"}))
        AddNodeToArrayAndHashTab(New Node(82, 754, "103", Node.Type_Key.WALKWAY, {"102", "104"}))
        AddNodeToArrayAndHashTab(New Node(215, 754, "104", Node.Type_Key.WALKWAY, {"103", "105"}))
        AddNodeToArrayAndHashTab(New Node(276, 754, "105", Node.Type_Key.WALKWAY, {"104", "106"}))
        AddNodeToArrayAndHashTab(New Node(291, 754, "106", Node.Type_Key.WALKWAY, {"105", "107"}))
        AddNodeToArrayAndHashTab(New Node(378, 754, "107", Node.Type_Key.WALKWAY, {"106", "108"}))
        AddNodeToArrayAndHashTab(New Node(490, 754, "108", Node.Type_Key.WALKWAY, {"107", "109"}))
        AddNodeToArrayAndHashTab(New Node(581, 754, "109", Node.Type_Key.WALKWAY, {"108", "110"}))
        AddNodeToArrayAndHashTab(New Node(618, 720, "110", Node.Type_Key.WALKWAY, {"109", "111"}))
        AddNodeToArrayAndHashTab(New Node(700, 720, "111", Node.Type_Key.WALKWAY, {"110", "122", "121"}))
        AddNodeToArrayAndHashTab(New Node(700, 510, "112", Node.Type_Key.WALKWAY, {"122", "113", "126", "130"}))
        AddNodeToArrayAndHashTab(New Node(600, 510, "113", Node.Type_Key.WALKWAY, {"112", "114"}))
        AddNodeToArrayAndHashTab(New Node(573, 510, "114", Node.Type_Key.WALKWAY, {"113", "115", "131"}))
        AddNodeToArrayAndHashTab(New Node(545, 510, "115", Node.Type_Key.WALKWAY, {"114", "116"}))
        AddNodeToArrayAndHashTab(New Node(481, 510, "116", Node.Type_Key.WALKWAY, {"115", "117"}))
        AddNodeToArrayAndHashTab(New Node(386, 510, "117", Node.Type_Key.WALKWAY, {"116", "118"}))
        AddNodeToArrayAndHashTab(New Node(273, 510, "118", Node.Type_Key.WALKWAY, {"117", "119"}))
        AddNodeToArrayAndHashTab(New Node(174, 510, "119", Node.Type_Key.WALKWAY, {"118", "120"}))
        AddNodeToArrayAndHashTab(New Node(106, 510, "120", Node.Type_Key.WALKWAY, {"119", "101"}))
        AddNodeToArrayAndHashTab(New Node(790, 720, "121", Node.Type_Key.WALKWAY, {"111"}))
        AddNodeToArrayAndHashTab(New Node(700, 540, "122", Node.Type_Key.WALKWAY, {"111", "112", "123", "126"}))
        AddNodeToArrayAndHashTab(New Node(898, 540, "123", Node.Type_Key.WALKWAY, {"122", "124", "125", "126"}))
        AddNodeToArrayAndHashTab(New Node(960, 540, "124", Node.Type_Key.WALKWAY, {"123", "132"}))
        AddNodeToArrayAndHashTab(New Node(898, 590, "125", Node.Type_Key.WALKWAY, {"123"}))
        AddNodeToArrayAndHashTab(New Node(775, 510, "126", Node.Type_Key.WALKWAY, {"122", "113", "123"}))
        AddNodeToArrayAndHashTab(New Node(82, 592, "127", Node.Type_Key.WALKWAY, {"101", "102", "128"}))
        AddNodeToArrayAndHashTab(New Node(30, 592, "128", Node.Type_Key.STAIRWAYORELEVATOR, {"127", "234", "027"})) ' back elevator
        AddNodeToArrayAndHashTab(New Node(775, 470, "129", Node.Type_Key.STAIRWAYORELEVATOR, {"126", "029"})) 'circle stairs down to lower level
        AddNodeToArrayAndHashTab(New Node(700, 470, "130", Node.Type_Key.STAIRWAYORELEVATOR, {"112", "235"})) 'circle stairs up
        AddNodeToArrayAndHashTab(New Node(573, 554, "131", Node.Type_Key.STAIRWAYORELEVATOR, {"114", "237", "028"})) 'front elevator
        AddNodeToArrayAndHashTab(New Node(1005, 540, "132", Node.Type_Key.STAIRWAYORELEVATOR, {"124", "238", "030"})) ' front steps
        AddNodeToArrayAndHashTab(New Node(30, 625, "133", Node.Type_Key.STAIRWAYORELEVATOR, {"102", "239", "026"})) ' back steps
        AddNodeToArrayAndHashTab(New Node(85, 500, "201", Node.Type_Key.WALKWAY, {"202", "223"}))
        AddNodeToArrayAndHashTab(New Node(85, 584, "202", Node.Type_Key.WALKWAY, {"201", "203", "234"}))
        AddNodeToArrayAndHashTab(New Node(85, 612, "203", Node.Type_Key.WALKWAY, {"202", "204", "239"}))
        AddNodeToArrayAndHashTab(New Node(85, 745, "204", Node.Type_Key.WALKWAY, {"203", "205"}))
        AddNodeToArrayAndHashTab(New Node(154, 745, "205", Node.Type_Key.WALKWAY, {"204", "206"}))
        AddNodeToArrayAndHashTab(New Node(278, 745, "206", Node.Type_Key.WALKWAY, {"205", "207"}))
        AddNodeToArrayAndHashTab(New Node(303, 745, "207", Node.Type_Key.WALKWAY, {"206", "208"}))
        AddNodeToArrayAndHashTab(New Node(327, 745, "208", Node.Type_Key.WALKWAY, {"207", "209"}))
        AddNodeToArrayAndHashTab(New Node(433, 745, "209", Node.Type_Key.WALKWAY, {"208", "210"}))
        AddNodeToArrayAndHashTab(New Node(495, 745, "210", Node.Type_Key.WALKWAY, {"209", "211"}))
        AddNodeToArrayAndHashTab(New Node(581, 745, "211", Node.Type_Key.WALKWAY, {"210", "212"}))
        AddNodeToArrayAndHashTab(New Node(630, 690, "212", Node.Type_Key.WALKWAY, {"211", "213"}))
        AddNodeToArrayAndHashTab(New Node(700, 542, "213", Node.Type_Key.WALKWAY, {"212", "214", "224", "225"}))
        AddNodeToArrayAndHashTab(New Node(700, 500, "214", Node.Type_Key.WALKWAY, {"213", "215", "224", "225"}))
        AddNodeToArrayAndHashTab(New Node(605, 500, "215", Node.Type_Key.WALKWAY, {"214", "216"}))
        AddNodeToArrayAndHashTab(New Node(573, 500, "216", Node.Type_Key.WALKWAY, {"215", "217", "237"}))
        AddNodeToArrayAndHashTab(New Node(542, 500, "217", Node.Type_Key.WALKWAY, {"216", "218"}))
        AddNodeToArrayAndHashTab(New Node(484, 500, "218", Node.Type_Key.WALKWAY, {"217", "219", "342"}))
        AddNodeToArrayAndHashTab(New Node(461, 500, "219", Node.Type_Key.WALKWAY, {"218", "220"}))
        AddNodeToArrayAndHashTab(New Node(298, 500, "220", Node.Type_Key.WALKWAY, {"219", "221"}))
        AddNodeToArrayAndHashTab(New Node(274, 500, "221", Node.Type_Key.WALKWAY, {"220", "222"}))
        AddNodeToArrayAndHashTab(New Node(175, 500, "222", Node.Type_Key.WALKWAY, {"221", "223"}))
        AddNodeToArrayAndHashTab(New Node(150, 500, "223", Node.Type_Key.WALKWAY, {"222", "201"}))
        AddNodeToArrayAndHashTab(New Node(774, 500, "224", Node.Type_Key.WALKWAY, {"213", "214", "225", "235"}))
        AddNodeToArrayAndHashTab(New Node(791, 542, "225", Node.Type_Key.WALKWAY, {"213", "214", "224", "226", "233"}))
        AddNodeToArrayAndHashTab(New Node(851, 542, "226", Node.Type_Key.WALKWAY, {"225", "227"}))
        AddNodeToArrayAndHashTab(New Node(905, 542, "227", Node.Type_Key.WALKWAY, {"226", "228", "229"}))
        AddNodeToArrayAndHashTab(New Node(970, 542, "228", Node.Type_Key.WALKWAY, {"227", "238"}))
        AddNodeToArrayAndHashTab(New Node(905, 625, "229", Node.Type_Key.WALKWAY, {"227", "230"}))
        AddNodeToArrayAndHashTab(New Node(905, 710, "230", Node.Type_Key.WALKWAY, {"229", "231"}))
        AddNodeToArrayAndHashTab(New Node(833, 710, "231", Node.Type_Key.WALKWAY, {"230", "232"}))
        AddNodeToArrayAndHashTab(New Node(791, 710, "232", Node.Type_Key.WALKWAY, {"231", "233"}))
        AddNodeToArrayAndHashTab(New Node(791, 625, "233", Node.Type_Key.WALKWAY, {"232", "225"}))
        AddNodeToArrayAndHashTab(New Node(40, 586, "234", Node.Type_Key.STAIRWAYORELEVATOR, {"202", "128", "340"})) 'back elevator
        AddNodeToArrayAndHashTab(New Node(774, 462, "235", Node.Type_Key.STAIRWAYORELEVATOR, {"224", "130"})) ' circle stairs down to 1st level
        AddNodeToArrayAndHashTab(New Node(700, 500, "236", Node.Type_Key.STAIRWAYORELEVATOR, {"214", "343"})) ' circle stairs up to 3rd level
        AddNodeToArrayAndHashTab(New Node(573, 545, "237", Node.Type_Key.STAIRWAYORELEVATOR, {"216", "131", "342"})) 'front elevator
        AddNodeToArrayAndHashTab(New Node(1000, 542, "238", Node.Type_Key.STAIRWAYORELEVATOR, {"228", "132", "341"})) '
        AddNodeToArrayAndHashTab(New Node(40, 614, "239", Node.Type_Key.STAIRWAYORELEVATOR, {"203", "133", "339"}))
        AddNodeToArrayAndHashTab(New Node(87, 530, "301", Node.Type_Key.WALKWAY, {"302", "329"}))
        AddNodeToArrayAndHashTab(New Node(87, 614, "302", Node.Type_Key.WALKWAY, {"301", "303", "340"}))
        AddNodeToArrayAndHashTab(New Node(87, 642, "303", Node.Type_Key.WALKWAY, {"302", "304", "339"}))
        AddNodeToArrayAndHashTab(New Node(87, 665, "304", Node.Type_Key.WALKWAY, {"303", "305", "306"}))
        AddNodeToArrayAndHashTab(New Node(154, 665, "305", Node.Type_Key.WALKWAY, {"304"}))
        AddNodeToArrayAndHashTab(New Node(87, 780, "306", Node.Type_Key.WALKWAY, {"304", "307"}))
        AddNodeToArrayAndHashTab(New Node(132, 780, "307", Node.Type_Key.WALKWAY, {"306", "308"}))
        AddNodeToArrayAndHashTab(New Node(198, 780, "308", Node.Type_Key.WALKWAY, {"307", "309"}))
        AddNodeToArrayAndHashTab(New Node(263, 780, "309", Node.Type_Key.WALKWAY, {"308", "310"}))
        AddNodeToArrayAndHashTab(New Node(328, 780, "310", Node.Type_Key.WALKWAY, {"309", "311"}))
        AddNodeToArrayAndHashTab(New Node(386, 780, "311", Node.Type_Key.WALKWAY, {"310", "312"}))
        AddNodeToArrayAndHashTab(New Node(402, 780, "312", Node.Type_Key.WALKWAY, {"311", "313", "315"}))
        AddNodeToArrayAndHashTab(New Node(402, 665, "313", Node.Type_Key.WALKWAY, {"312", "314", "325"}))
        AddNodeToArrayAndHashTab(New Node(352, 665, "314", Node.Type_Key.WALKWAY, {"313"}))
        AddNodeToArrayAndHashTab(New Node(458, 780, "315", Node.Type_Key.WALKWAY, {"312", "316"}))
        AddNodeToArrayAndHashTab(New Node(523, 780, "316", Node.Type_Key.WALKWAY, {"315", "317"}))
        AddNodeToArrayAndHashTab(New Node(604, 780, "317", Node.Type_Key.WALKWAY, {"316", "318"}))
        AddNodeToArrayAndHashTab(New Node(793, 549, "318", Node.Type_Key.WALKWAY, {"317", "319", "330"}))
        AddNodeToArrayAndHashTab(New Node(807, 530, "319", Node.Type_Key.WALKWAY, {"318", "320", "343"}))
        AddNodeToArrayAndHashTab(New Node(629, 530, "320", Node.Type_Key.WALKWAY, {"319", "321"}))
        AddNodeToArrayAndHashTab(New Node(596, 530, "321", Node.Type_Key.WALKWAY, {"320", "322", "342"}))
        AddNodeToArrayAndHashTab(New Node(564, 530, "322", Node.Type_Key.WALKWAY, {"321", "323"}))
        AddNodeToArrayAndHashTab(New Node(501, 530, "323", Node.Type_Key.WALKWAY, {"322", "324"}))
        AddNodeToArrayAndHashTab(New Node(470, 530, "324", Node.Type_Key.WALKWAY, {"323", "325"}))
        AddNodeToArrayAndHashTab(New Node(402, 530, "325", Node.Type_Key.WALKWAY, {"313", "324", "326"}))
        AddNodeToArrayAndHashTab(New Node(320, 530, "326", Node.Type_Key.WALKWAY, {"325", "327"}))
        AddNodeToArrayAndHashTab(New Node(283, 530, "327", Node.Type_Key.WALKWAY, {"326", "328"}))
        AddNodeToArrayAndHashTab(New Node(207, 530, "328", Node.Type_Key.WALKWAY, {"327", "329"}))
        AddNodeToArrayAndHashTab(New Node(185, 530, "329", Node.Type_Key.WALKWAY, {"301", "328"}))
        AddNodeToArrayAndHashTab(New Node(827, 569, "330", Node.Type_Key.WALKWAY, {"318", "331", "338"}))
        AddNodeToArrayAndHashTab(New Node(868, 569, "331", Node.Type_Key.WALKWAY, {"330", "332"}))
        AddNodeToArrayAndHashTab(New Node(916, 569, "332", Node.Type_Key.WALKWAY, {"331", "333", "334"}))
        AddNodeToArrayAndHashTab(New Node(971, 569, "333", Node.Type_Key.WALKWAY, {"332", "341"}))
        AddNodeToArrayAndHashTab(New Node(916, 625, "334", Node.Type_Key.WALKWAY, {"332", "335"}))
        AddNodeToArrayAndHashTab(New Node(916, 705, "335", Node.Type_Key.WALKWAY, {"334", "336"}))
        AddNodeToArrayAndHashTab(New Node(916, 746, "336", Node.Type_Key.WALKWAY, {"335", "337"}))
        AddNodeToArrayAndHashTab(New Node(827, 746, "337", Node.Type_Key.WALKWAY, {"336", "338"}))
        AddNodeToArrayAndHashTab(New Node(827, 655, "338", Node.Type_Key.WALKWAY, {"330", "337"}))
        AddNodeToArrayAndHashTab(New Node(34, 647, "339", Node.Type_Key.STAIRWAYORELEVATOR, {"303", "239"}))
        AddNodeToArrayAndHashTab(New Node(34, 614, "340", Node.Type_Key.STAIRWAYORELEVATOR, {"302", "234"}))
        AddNodeToArrayAndHashTab(New Node(1045, 569, "341", Node.Type_Key.STAIRWAYORELEVATOR, {"333", "238"}))
        AddNodeToArrayAndHashTab(New Node(596, 572, "342", Node.Type_Key.STAIRWAYORELEVATOR, {"321", "218"}))
        AddNodeToArrayAndHashTab(New Node(807, 550, "343", Node.Type_Key.STAIRWAYORELEVATOR, {"319", "236"})) 'circle down to floor 2 
        LoadEdges()
    End Sub
    Private Sub LoadEdges()
        For i = 0 To nodeCount - 1
            For Each adj In nodes(i).getAdjList
                AddEdgeToArrayAndHashTab(New Edge(1, nodes(i), nodes(hashTab.Item(adj))))
            Next
        Next
    End Sub
    Private Sub LoadRooms()
        hashTab.Add("EB1008", "120")
        hashTab.Add("EB1009", "119")
        hashTab.Add("EB1010", "118")
        hashTab.Add("EB1011", "117")
        hashTab.Add("EB1012", "116")
        hashTab.Add("EB1018", "109")
        hashTab.Add("EB1022", "108")
        hashTab.Add("EB1023", "107")
        hashTab.Add("EB1024", "106")
        hashTab.Add("EB1025", "106")
        hashTab.Add("EB1026", "105")
        hashTab.Add("EB1027", "104")
        hashTab.Add("EB1033", "121")
        hashTab.Add("EB1036", "125")
        hashTab.Add("EB1038", "121")
        hashTab.Add("EB3012", "324")
    End Sub
    Private Sub DrawMaps(ByVal origin As String, ByVal dest As String)
        'origin = "015"
        'dest = "123"
        'dest = hashTab(dest)
        Dim imgIndex, imgSmallIndex As Integer
        imgIndex = Integer.Parse(origin.ToCharArray()(0))
        imgSmallIndex = Integer.Parse(dest.ToCharArray()(0))
        img = floorImages(imgIndex).getImage
        img2 = floorImages(imgSmallIndex).getImage
        drawPath(Dijkstra(nodes(hashTab.Item(origin)), nodes(hashTab.Item(dest))), imgIndex = imgSmallIndex)
        img.Location = New Point(0, 0)
        Me.Controls.Add(img)
        img2.Location = New Point(600, 0)
        Me.Controls.Add(img2)
    End Sub
    Private Function Dijkstra(ByVal origin As Node, ByVal dest As Node) As Integer()
        Dim DV() As Integer = New Integer(nodeCount - 1) {}
        Dim PV() As Integer = New Integer(nodeCount - 1) {}
        Dim KV() As Boolean = New Boolean(nodeCount - 1) {} 'initializes all the values to false
        '**************************INITIALIZE VARS**************************
        For i = 0 To DV.Length - 1
            DV.SetValue(INFINITY, i)
            PV.SetValue(INFINITY, i)
        Next
        DV.SetValue(0, hashTab.Item(origin.getIdentifier()))
        '**********************DIJKSTRA'S ALGORITHM**************************
        Dim x As Integer
        Dim y As Integer
        Dim nextVert As Integer
        For i = 0 To DV.Length - 1
            '**************************FIND NEXT MIN VERTEX**************************
            If i >= 67 Then
                x = 1
            End If
            x = INFINITY
            y = -1 'graph isn't connected
            For j = 0 To DV.Length - 1 ' find the vertex with minimum distance value to travel to
                If Not KV(j) AndAlso DV(j) < x Then
                    y = j
                    x = DV(j)
                End If
            Next
            nextVert = y
            '**************************FIND NEIGHBORS AND UPDATE VALUES**************************
            KV(nextVert) = True
            For Each adjacency In nodes(nextVert).getAdjList
                Dim aNodeIndex As Integer = hashTab.Item(adjacency)
                Dim dist As Integer = DV(nextVert) + getEdge(nodes(nextVert), nodes(aNodeIndex)).getWeight 'tentative distance to take over the old distance
                If DV(aNodeIndex) > dist Then
                    DV(aNodeIndex) = dist
                    PV(aNodeIndex) = nextVert
                End If
            Next
        Next
        '**************************MAKE SHORTEST PATH ARRAY**************************
        Dim first As Integer = hashTab.Item(origin.getIdentifier())
        Dim iterator As Integer = hashTab.Item(dest.getIdentifier()) 'starts at the end
        Dim originFloor = origin.getIdentifier().ToCharArray()(0)
        Dim destFloor = dest.getIdentifier().ToCharArray()(0)
        While Not iterator = first
            Dim iterFloor = nodes(iterator).getIdentifier.ToCharArray()(0)
            If Not iterFloor = originFloor AndAlso Not iterFloor = destFloor AndAlso Not nodes(iterator).getNodeType = Node.Type_Key.STAIRWAYORELEVATOR Then
                While Not nodes(currentPath(currentPathIndex - 1)).getIdentifier.ToCharArray()(0) = destFloor
                    iterator = currentPath(currentPathIndex - 1)
                    currentPathIndex -= 1
                End While
                currentPathIndex -= 1
                For Each adj In nodes(currentPath(currentPathIndex - 1)).getAdjList
                    Dim index As Integer = hashTab.Item(adj)
                    If Not index = iterator AndAlso Not index = currentPath(currentPathIndex) AndAlso Not nodes(index).getNodeType = Node.Type_Key.STAIRWAYORELEVATOR Then
                        currentPath(currentPathIndex) = index
                        iterator = PV(index)
                        currentPathIndex += 1
                        Exit For
                    End If
                Next
            Else
                currentPath(currentPathIndex) = iterator
                iterator = PV(iterator)
                currentPathIndex += 1
            End If
        End While
        currentPath(currentPathIndex) = first
        Dim arr() As Integer = (New List(Of Integer)(currentPath)).GetRange(0, currentPathIndex + 1).ToArray
        Array.Reverse(arr)
        Return arr
    End Function
    Private Sub AddNodeToArrayAndHashTab(ByVal node As Node) 'maps he string identifier to index in the array
        nodes(nodeCount) = node
        hashTab.Add(node.getIdentifier(), nodeCount)
        nodeCount += 1
    End Sub
    Private Sub AddEdgeToArrayAndHashTab(ByVal edge As Edge)
        edges(edgeCount) = edge
        'hashTab.Add(, edgeIndex) add this later
        edgeCount += 1
    End Sub
    Public Function getEdge(ByVal node1 As Node, ByVal node2 As Node) As Edge 'TODO refactor this method using the HashTable for quicker lookup
        For Each e In edges
            If (e.getNode1() Is node1 AndAlso e.getNode2() Is node2) Then
                Return e
            End If
        Next
        Return Nothing
    End Function
    Public Sub drawPath(ByVal path() As Integer, ByVal pathOnSameFloor As Boolean)
        Dim node1, node2 As Node
        Dim edge1 As Edge
        Dim newInt As Integer
        node1 = nodes(path(0))

        For i = 1 To path.Length - 1
            node2 = nodes(path(i))
            If node1.getNodeType() = Node.Type_Key.STAIRWAYORELEVATOR AndAlso node2.getNodeType() = Node.Type_Key.STAIRWAYORELEVATOR Then
                i += 1
                While nodes(path(i)).getNodeType = Node.Type_Key.STAIRWAYORELEVATOR
                    node1 = node2
                    node2 = nodes(path(i))
                    i += 1
                End While
                newInt = i
                node1 = node2
                Exit For
            End If
            edge1 = getEdge(node1, node2)
            edge1.displayDirection(img)
            node1 = node2
        Next

        If Not pathOnSameFloor Then
            For i = newInt To path.Length - 1
                node2 = nodes(path(i))
                edge1 = getEdge(node1, node2)
                edge1.displayDirection(img2)
                node1 = node2
                If i = 20 Then
                    Dim x = 21
                End If
            Next
        End If

    End Sub
    Public Class Edge
        Dim weight As Integer
        Dim node1 As Node
        Dim node2 As Node
        Dim direction As Integer
        Dim imagePath As String = Application.StartupPath & "\Arrows\"
        Dim directionStrings() As String = {"Up.png", "Down.png.", "Left.png", "Right.png", "UpLeft.png", "UpRight.png", "DownLeft.png", "DownRight.png"}
        Dim arrowImageSize As Integer = 20
        Sub New(ByVal weight As Integer, ByVal node1 As Node, ByVal node2 As Node, Optional ByVal direction As Integer = Direction_Key.INVALID)
            Me.weight = weight
            Me.node1 = node1
            Me.node2 = node2
            Me.direction = direction
        End Sub
        Public Enum Direction_Key
            UP
            DOWN
            L
            R
            UPL
            UPR
            DOWNL
            DOWNR
            INVALID
        End Enum
        Private Sub determineDirection(ByVal origin As Node, ByVal dest As Node)
            If origin.getLocation().X = dest.getLocation().X AndAlso origin.getLocation().Y > dest.getLocation().Y Then
                direction = Direction_Key.UP
            ElseIf origin.getLocation().X = dest.getLocation().X AndAlso origin.getLocation().Y < dest.getLocation().Y Then
                direction = Direction_Key.DOWN
            ElseIf origin.getLocation().X > dest.getLocation().X AndAlso origin.getLocation().Y = dest.getLocation().Y Then
                direction = Direction_Key.L
            ElseIf origin.getLocation().X < dest.getLocation().X AndAlso origin.getLocation().Y = dest.getLocation().Y Then
                direction = Direction_Key.R
            ElseIf origin.getLocation().X < dest.getLocation().X AndAlso origin.getLocation().Y > dest.getLocation().Y Then
                direction = Direction_Key.UPR
            ElseIf origin.getLocation().X > dest.getLocation().X AndAlso origin.getLocation().Y > dest.getLocation().Y Then
                direction = Direction_Key.UPL
            ElseIf origin.getLocation().X > dest.getLocation().X AndAlso origin.getLocation().Y < dest.getLocation().Y Then
                direction = Direction_Key.DOWNL
            ElseIf origin.getLocation().X < dest.getLocation().X AndAlso origin.getLocation().Y < dest.getLocation().Y Then
                direction = Direction_Key.DOWNR
            Else
                direction = Direction_Key.INVALID
            End If

        End Sub
        Public Sub displayDirection(ByVal picbox As PictureBox)
            Const bitmampSize As Integer = 40
            Me.determineDirection(Me.node1, Me.node2)
            Dim bmp As Bitmap = New Bitmap(bitmampSize, bitmampSize)
            Dim graph As Graphics = Graphics.FromImage(picbox.Image)
            Using g As Graphics = Graphics.FromImage(bmp)
                g.DrawImage(Image.FromFile(imagePath & directionStrings(direction)), 0, 0, bmp.Width, bmp.Height)
            End Using
            Dim distance As Integer = Math.Sqrt(Math.Pow(node1.getLocation.X - node2.getLocation.X, 2) + Math.Pow(node1.getLocation.Y - node2.getLocation.Y, 2))
            Dim numArrows As Integer = distance / bitmampSize
            For i = 1 To numArrows
                Dim yDif As Integer = (i / numArrows) * Math.Abs(node1.getLocation.Y - node2.getLocation.Y)
                Dim xDif As Integer = (i / numArrows) * Math.Abs(node1.getLocation.X - node2.getLocation.X)
                If Me.direction = Direction_Key.UPL Then
                    yDif = -yDif
                    xDif = -xDif
                ElseIf Me.direction = Direction_Key.UP OrElse Me.direction = Direction_Key.UPR Then
                    yDif = -yDif
                ElseIf Me.direction = Direction_Key.L OrElse Me.direction = Direction_Key.DOWNL Then
                    xDif = -xDif
                End If
                graph.DrawImage(bmp, New Point((node1.getLocation.X - (bitmampSize / 2)) + xDif, (node1.getLocation.Y - (bitmampSize / 2)) + yDif))
            Next
        End Sub
        Public Function getWeight()
            Return weight
        End Function
        Public Function getNode1()
            Return node1
        End Function
        Public Function getNode2()
            Return node2
        End Function
    End Class
    Public Class Node
        Dim location As Point
        Dim type As Integer
        Dim identifier As String
        Dim adjList() As String
        Sub New(ByVal x As Integer, ByVal y As Integer, ByVal id As String, ByVal type As Integer, ByVal adjList() As String)
            location = New Point(x, y)
            Me.identifier = id
            Me.adjList = adjList
            Me.type = type
        End Sub
        Public Enum Type_Key
            CLASSROOM
            OFFICE
            WALKWAY
            STAIRWAYORELEVATOR
            RESTROOM
            VENDINGMACHINE
        End Enum
        Public Function getAdjList() As String()
            Return adjList
        End Function
        Public Function getIdentifier() As String
            Return identifier
        End Function
        Public Function getLocation() As Point
            Return location
        End Function
        Public Function getNodeType() As Integer
            Return type
        End Function
    End Class
    Private Class ImageContainer
        Dim aspectRatio As Double
        Dim pb As PictureBox = New PictureBox
        Dim img As Image
        Private _p1 As Integer
        Sub New(ByVal img As Image)
            aspectRatio = CDbl(img.Height / img.Width)
            Me.img = img
            pb.Image = img
            pb.Size = img.Size
            pb.SizeMode = PictureBoxSizeMode.StretchImage
        End Sub
        Sub resetHeight(ByVal h As Integer)
            pb.Height = h
            pb.Width = h / aspectRatio
        End Sub
        Function getImage() As PictureBox 'later this can be getFirstFloor, getSecondFloor etc...
            Return pb
        End Function
        Function getAspectRatio()
            Return aspectRatio
        End Function
    End Class
End Class 'End Navigation Class
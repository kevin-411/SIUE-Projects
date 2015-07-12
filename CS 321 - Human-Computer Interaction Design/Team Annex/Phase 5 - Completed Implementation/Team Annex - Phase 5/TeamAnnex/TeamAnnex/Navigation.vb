Public Class Navigation
#Region "GLOBALS"
    Const INFINITY As Integer = Integer.MaxValue
    Dim floorImages() As PictureBox = New PictureBox(3) {} 'holds a copy of the original floor Images
    Dim edges() As Edge = New Edge(1000) {} 'Up to 1001 Edges change this later when we actually know the number
    Dim nodes() As Node = New Node(400) {} 'Up to 401 Nodes
    Dim rooms() As Room = New Room(400) {} 'Up to 401 Rooms
    Dim currentPath() As Integer = New Integer(400) {}
    Dim directions() As Direction = New Direction(50) {}
    Dim edgeCount As Integer = 0 ' Edge index of the actual amount of edges currently loaded
    Dim nodeCount As Integer = 0 ' Node index  of the actual amount of edges currently loaded
    Dim roomCount As Integer = 0
    Dim currentPathIndex As Integer = 0 'currentPath index of the actual path
    Dim directionsCount As Integer = 0
    Dim img As PictureBox
    Dim img2 As PictureBox
    Dim hashTab As Hashtable = New Hashtable
    Dim sameFloor As Boolean
#End Region
    Sub New()
        LoadFloorPics()
        LoadNodes()
    End Sub
    Sub New(ByVal origin As String, ByVal dest As String)
        LoadFloorPics()
        LoadNodes()
        DrawMaps(origin, dest)
    End Sub
    Public Function getPics() As PictureBox()
        Return New PictureBox(1) {img, img2}
    End Function
    Public Function isSameFloor() As Boolean
        Return sameFloor
    End Function
    Public Function getListDirections() As Direction()
        Dim arr() As Direction = (New List(Of Direction)(directions)).GetRange(0, directionsCount).ToArray
        Return arr
    End Function
    Private Sub LoadFloorPics()
        Dim floorStrings() As String = {"LowerLevel.jpg", "FirstFloor.jpg", "SecondFloor.jpg", "ThirdFloor.jpg"}
        Dim imagePath As String = Application.StartupPath & "\FloorPlanImages\"
        Dim imgCont As PictureBox

        For Each path In floorStrings
            imgCont = New PictureBox()
            imgCont.Image = Image.FromFile(imagePath & path)
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
        AddNodeToArrayAndHashTab(New Node(50, 632, "026", Node.Type_Key.STAIRWAY, {"002", "133"})) ' back steps
        AddNodeToArrayAndHashTab(New Node(50, 608, "027", Node.Type_Key.ELEVATOR, {"001", "128"})) ' back elevator
        AddNodeToArrayAndHashTab(New Node(589, 563, "028", Node.Type_Key.ELEVATOR, {"017", "131"})) ' front elevator
        AddNodeToArrayAndHashTab(New Node(716, 490, "029", Node.Type_Key.STAIRWAY, {"020", "129"})) ' cicle stairs up to floor 1
        AddNodeToArrayAndHashTab(New Node(1010, 555, "030", Node.Type_Key.STAIRWAY, {"025", "132"})) ' front steps
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
        AddNodeToArrayAndHashTab(New Node(30, 592, "128", Node.Type_Key.ELEVATOR, {"127", "234", "027"})) ' back elevator
        AddNodeToArrayAndHashTab(New Node(775, 470, "129", Node.Type_Key.STAIRWAY, {"126", "029"})) 'circle stairs down to lower level
        AddNodeToArrayAndHashTab(New Node(700, 470, "130", Node.Type_Key.STAIRWAY, {"112", "235"})) 'circle stairs up
        AddNodeToArrayAndHashTab(New Node(573, 554, "131", Node.Type_Key.ELEVATOR, {"114", "237", "028"})) 'front elevator
        AddNodeToArrayAndHashTab(New Node(1005, 540, "132", Node.Type_Key.STAIRWAY, {"124", "238", "030"})) ' front steps
        AddNodeToArrayAndHashTab(New Node(30, 625, "133", Node.Type_Key.STAIRWAY, {"102", "239", "026"})) ' back steps
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
        AddNodeToArrayAndHashTab(New Node(484, 500, "218", Node.Type_Key.WALKWAY, {"217", "219"}))
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
        AddNodeToArrayAndHashTab(New Node(40, 586, "234", Node.Type_Key.ELEVATOR, {"202", "128", "340"})) 'back elevator
        AddNodeToArrayAndHashTab(New Node(774, 462, "235", Node.Type_Key.STAIRWAY, {"224", "130"})) ' circle stairs down to 1st level
        AddNodeToArrayAndHashTab(New Node(700, 500, "236", Node.Type_Key.STAIRWAY, {"214", "343"})) ' circle stairs up to 3rd level
        AddNodeToArrayAndHashTab(New Node(573, 545, "237", Node.Type_Key.ELEVATOR, {"216", "131", "342"})) 'front elevator
        AddNodeToArrayAndHashTab(New Node(1000, 542, "238", Node.Type_Key.STAIRWAY, {"228", "132", "341"})) 'front stairs
        AddNodeToArrayAndHashTab(New Node(40, 614, "239", Node.Type_Key.STAIRWAY, {"203", "133", "339"})) 'back stairs
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
        AddNodeToArrayAndHashTab(New Node(34, 647, "339", Node.Type_Key.STAIRWAY, {"303", "239"})) 'back stairs
        AddNodeToArrayAndHashTab(New Node(34, 614, "340", Node.Type_Key.ELEVATOR, {"302", "234"})) 'back elevator
        AddNodeToArrayAndHashTab(New Node(1045, 569, "341", Node.Type_Key.STAIRWAY, {"333", "238"})) 'front stairs
        AddNodeToArrayAndHashTab(New Node(596, 572, "342", Node.Type_Key.ELEVATOR, {"321", "237"})) 'front elevator
        AddNodeToArrayAndHashTab(New Node(807, 550, "343", Node.Type_Key.STAIRWAY, {"319", "236"})) 'circle down to floor 2 
        LoadEdges()
        LoadRooms()
    End Sub
    Private Sub LoadEdges()
        For i = 0 To nodeCount - 1
            For Each adj In nodes(i).getAdjList
                AddEdgeToArrayAndHashTab(New Edge(1, nodes(i), nodes(hashTab.Item(adj))))
            Next
        Next
    End Sub
    Private Sub LoadRooms()
        AddRoomToArrayAndHashTab(New Room("EB1008", 75, 135, 309, 373, "120"))
        AddRoomToArrayAndHashTab(New Room("EB1009", 135, 175, 309, 373, "119"))
        AddRoomToArrayAndHashTab(New Room("EB1010", 175, 225, 309, 373, "118"))
        AddRoomToArrayAndHashTab(New Room("EB1011", 225, 332, 309, 373, "117"))
        AddRoomToArrayAndHashTab(New Room("EB1012", 332, 426, 309, 373, "116"))
        AddRoomToArrayAndHashTab(New Room("EB1018", 448, 489, 388, 476, "109"))
        AddRoomToArrayAndHashTab(New Room("EB1022", 389, 426, 407, 438, "108"))
        AddRoomToArrayAndHashTab(New Room("EB1023", 290, 374, 388, 438, "107"))
        'AddRoomToArrayAndHashTab(New Room("EB1024", 226, 290, 391, 438, "106"))
        AddRoomToArrayAndHashTab(New Room("EB1025", 226, 290, 374, 391, "106"))
        AddRoomToArrayAndHashTab(New Room("EB1026", 175, 374, 226, 438, "105"))
        AddRoomToArrayAndHashTab(New Room("EB1027", 75, 374, 309, 438, "104"))
        AddRoomToArrayAndHashTab(New Room("EB1032", 910, 960, 569, 632, "125"))
        AddRoomToArrayAndHashTab(New Room("EB1033", 662, 723, 412, 447, "121"))
        AddRoomToArrayAndHashTab(New Room("EB1033", 713, 812, 374, 436, "125")) 'intended doubles to cover more area
        AddRoomToArrayAndHashTab(New Room("EB1036", 612, 665, 368, 399, "121"))
        AddRoomToArrayAndHashTab(New Room("EB1036", 640, 697, 309, 334, "125")) 'intended doubles to cover more area
        AddRoomToArrayAndHashTab(New Room("EB1038", 659, 690, 390, 394, "121"))
        AddRoomToArrayAndHashTab(New Room("EB2008", 81, 129, 310, 373, "223"))
        AddRoomToArrayAndHashTab(New Room("EB2009", 129, 179, 310, 373, "222"))
        AddRoomToArrayAndHashTab(New Room("EB2010", 179, 230, 310, 373, "221"))
        AddRoomToArrayAndHashTab(New Room("EB2011", 230, 304, 310, 373, "220"))
        AddRoomToArrayAndHashTab(New Room("EB2012", 304, 379, 310, 373, "219"))
        'AddRoomToArrayAndHashTab(New Room("EB2013", 379, 429, 310, 373, "218"))
        AddRoomToArrayAndHashTab(New Room("EB2020", 450, 490, 390, 425, "211"))
        AddRoomToArrayAndHashTab(New Room("EB2024", 418, 430, 402, 440, "210"))
        AddRoomToArrayAndHashTab(New Room("EB2025", 340, 418, 373, 440, "209"))
        AddRoomToArrayAndHashTab(New Room("EB2026", 255, 340, 373, 440, "208"))
        AddRoomToArrayAndHashTab(New Room("EB2027", 230, 255, 402, 440, "207"))
        'AddRoomToArrayAndHashTab(New Room("EB2028", 230, 255, 373, 402, "207"))
        AddRoomToArrayAndHashTab(New Room("EB2029", 129, 230, 373, 440, "206"))
        AddRoomToArrayAndHashTab(New Room("EB2030", 81, 129, 373, 440, "205"))
        'AddRoomToArrayAndHashTab(New Room("EB2031", 591, 629, 328, 354, "225"))
        AddRoomToArrayAndHashTab(New Room("EB2033", 626, 663, 294, 321, "225"))
        AddRoomToArrayAndHashTab(New Room("EB2034", 663, 688, 294, 321, "226"))
        'AddRoomToArrayAndHashTab(New Room("EB2035", 688, 713, 294, 321, "227"))
        AddRoomToArrayAndHashTab(New Room("EB2036", 713, 738, 294, 321, "227"))
        AddRoomToArrayAndHashTab(New Room("EB2037", 738, 771, 294, 321, "227"))
        AddRoomToArrayAndHashTab(New Room("EB2043", 733, 771, 339, 358, "229"))
        'AddRoomToArrayAndHashTab(New Room("EB2044", 733, 771, 358, 377, "229"))
        AddRoomToArrayAndHashTab(New Room("EB2045", 733, 771, 377, 396, "229"))
        AddRoomToArrayAndHashTab(New Room("EB2046", 733, 771, 396, 415, "230"))
        AddRoomToArrayAndHashTab(New Room("EB2047", 733, 771, 415, 432, "230"))
        'AddRoomToArrayAndHashTab(New Room("EB2048", 696, 720, 331, 358, "229"))
        'AddRoomToArrayAndHashTab(New Room("EB2049", 681, 720, 358, 376, "229"))
        AddRoomToArrayAndHashTab(New Room("EB2050", 681, 720, 376, 395, "229"))
        AddRoomToArrayAndHashTab(New Room("EB2051", 694, 720, 395, 423, "230"))
        AddRoomToArrayAndHashTab(New Room("EB2053", 724, 771, 433, 457, "230"))
        AddRoomToArrayAndHashTab(New Room("EB2054", 695, 724, 433, 457, "231"))
        AddRoomToArrayAndHashTab(New Room("EB2055", 670, 695, 433, 457, "232"))
        AddRoomToArrayAndHashTab(New Room("EB2056", 639, 670, 433, 457, "232"))
        AddRoomToArrayAndHashTab(New Room("EB2057", 591, 639, 433, 457, "232"))
        'AddRoomToArrayAndHashTab(New Room("EB2061", 591, 639, 415, 433, "232"))
        AddRoomToArrayAndHashTab(New Room("EB2062", 591, 639, 396, 415, "232"))
        AddRoomToArrayAndHashTab(New Room("EB2063", 591, 639, 375, 396, "233"))
        'AddRoomToArrayAndHashTab(New Room("EB2064", 591, 639, 355, 375, "233"))
        'AddRoomToArrayAndHashTab(New Room("EB2066", 643, 662, 331, 358, "225"))
        AddRoomToArrayAndHashTab(New Room("EB2067", 643, 681, 358, 377, "233"))
        'AddRoomToArrayAndHashTab(New Room("EB2068", 643, 681, 377, 396, "233"))
        AddRoomToArrayAndHashTab(New Room("EB0033", 267, 386, 66, 143, "013"))
        AddRoomToArrayAndHashTab(New Room("EB0040", 412, 526, 101, 142, "013"))
        AddRoomToArrayAndHashTab(New Room("EB0041", 411, 498, 143, 213, "012"))
        'AddRoomToArrayAndHashTab(New Room("EB0043", 443, 498, 213, 233, "011"))
        'AddRoomToArrayAndHashTab(New Room("EB0042", 413, 439, 214, 233, "011"))
        AddRoomToArrayAndHashTab(New Room("EB0044", 412, 497, 233, 296, "011"))
        AddRoomToArrayAndHashTab(New Room("EB0028", 306, 386, 244, 297, "011"))
        AddRoomToArrayAndHashTab(New Room("EB0007", 70, 145, 299, 365, "003"))
        AddRoomToArrayAndHashTab(New Room("EB0010", 191, 258, 299, 365, "006"))
        AddRoomToArrayAndHashTab(New Room("EB0011", 258, 321, 299, 365, "007"))
        AddRoomToArrayAndHashTab(New Room("EB0012", 321, 388, 299, 365, "008"))
        AddRoomToArrayAndHashTab(New Room("EB0013", 71, 140, 379, 459, "003"))
        AddRoomToArrayAndHashTab(New Room("EB0014", 140, 204, 379, 459, "004"))
        AddRoomToArrayAndHashTab(New Room("EB0015A", 257, 336, 651, 777, "005"))
        AddRoomToArrayAndHashTab(New Room("EB0015B", 257, 336, 651, 777, "007"))
        AddRoomToArrayAndHashTab(New Room("EB0050", 501, 597, 313, 379, "021"))
        AddRoomToArrayAndHashTab(New Room("EB0051", 597, 714, 313, 379, "022"))
        AddRoomToArrayAndHashTab(New Room("EB0052", 714, 778, 313, 379, "023"))
        AddRoomToArrayAndHashTab(New Room("EB3008", 76, 150, 311, 376, "329"))
        AddRoomToArrayAndHashTab(New Room("EB3009", 150, 226, 311, 376, "327"))
        AddRoomToArrayAndHashTab(New Room("EB3010", 226, 300, 311, 376, "326"))
        AddRoomToArrayAndHashTab(New Room("EB3012", 315, 369, 311, 376, "324"))
        AddRoomToArrayAndHashTab(New Room("EB3013", 369, 426, 311, 376, "323"))
        AddRoomToArrayAndHashTab(New Room("EB3047", 76, 124, 388, 414, "305"))
        AddRoomToArrayAndHashTab(New Room("EB3048", 124, 172, 378, 414, "305"))
        'AddRoomToArrayAndHashTab(New Room("EB3036", 172, 243, 378, 414, "314"))
        'AddRoomToArrayAndHashTab(New Room("EB3035", 243, 272, 388, 414, "314"))
        AddRoomToArrayAndHashTab(New Room("EB3034", 272, 300, 388, 414, "314"))
        AddRoomToArrayAndHashTab(New Room("EB3032", 316, 386, 378, 414, "313"))
        AddRoomToArrayAndHashTab(New Room("EB3020", 448, 485, 393, 426, "317"))
        AddRoomToArrayAndHashTab(New Room("EB3045", 76, 101, 414, 442, "307"))
        AddRoomToArrayAndHashTab(New Room("EB3044", 101, 126, 414, 442, "307"))
        AddRoomToArrayAndHashTab(New Room("EB3043", 126, 151, 414, 442, "308"))
        AddRoomToArrayAndHashTab(New Room("EB3042", 151, 176, 414, 442, "308"))
        AddRoomToArrayAndHashTab(New Room("EB3041", 176, 201, 414, 442, "309"))
        AddRoomToArrayAndHashTab(New Room("EB3040", 201, 226, 414, 442, "309"))
        AddRoomToArrayAndHashTab(New Room("EB3039", 226, 252, 414, 442, "310"))
        AddRoomToArrayAndHashTab(New Room("EB3038", 252, 276, 414, 442, "310"))
        AddRoomToArrayAndHashTab(New Room("EB3037", 276, 300, 414, 442, "311"))
        AddRoomToArrayAndHashTab(New Room("EB3029", 327, 351, 414, 442, "315"))
        AddRoomToArrayAndHashTab(New Room("EB3028", 351, 376, 414, 442, "315"))
        'AddRoomToArrayAndHashTab(New Room("EB3026", 376, 401, 414, 442, "316"))
        AddRoomToArrayAndHashTab(New Room("EB3024", 401, 425, 414, 442, "316"))
        AddRoomToArrayAndHashTab(New Room("EB3051", 621, 660, 297, 322, "330"))
        AddRoomToArrayAndHashTab(New Room("EB3052", 660, 686, 297, 322, "331"))
        AddRoomToArrayAndHashTab(New Room("EB3053", 686, 710, 297, 322, "332"))
        AddRoomToArrayAndHashTab(New Room("EB3054", 710, 736, 297, 322, "333"))
        AddRoomToArrayAndHashTab(New Room("EB3055", 736, 770, 297, 322, "333"))
        AddRoomToArrayAndHashTab(New Room("EB3079", 589, 626, 333, 357, "330"))
        AddRoomToArrayAndHashTab(New Room("EB3078", 589, 626, 357, 378, "338"))
        AddRoomToArrayAndHashTab(New Room("EB3077", 589, 626, 378, 397, "338"))
        AddRoomToArrayAndHashTab(New Room("EB3076", 589, 626, 397, 416, "337"))
        AddRoomToArrayAndHashTab(New Room("EB3075", 589, 626, 416, 434, "337"))
        'AddRoomToArrayAndHashTab(New Room("EB3072", 589, 647, 434, 461, "337"))
        AddRoomToArrayAndHashTab(New Room("EB3071", 647, 672, 434, 461, "337"))
        AddRoomToArrayAndHashTab(New Room("EB3070", 672, 697, 434, 461, "336"))
        AddRoomToArrayAndHashTab(New Room("EB3064", 697, 722, 434, 461, "336"))
        AddRoomToArrayAndHashTab(New Room("EB3063", 722, 769, 427, 461, "336"))
        AddRoomToArrayAndHashTab(New Room("EB3062", 739, 769, 399, 425, "335"))
        AddRoomToArrayAndHashTab(New Room("EB3061", 739, 769, 379, 399, "335"))
        AddRoomToArrayAndHashTab(New Room("EB3060", 739, 769, 351, 399, "334"))
        AddRoomToArrayAndHashTab(New Room("EB3059", 708, 769, 332, 351, "334"))
        'EB3058 - we got rid of this it was in the database but not on the map
        AddRoomToArrayAndHashTab(New Room("EB3057", 708, 739, 359, 427, "335"))
        'AddRoomToArrayAndHashTab(New Room("EB3080", 640, 670, 333, 350, "330"))
        'AddRoomToArrayAndHashTab(New Room("EB3081", 640, 670, 350, 369, "338"))
        'AddRoomToArrayAndHashTab(New Room("EB3082", 640, 670, 369, 388, "338"))
        'AddRoomToArrayAndHashTab(New Room("EB3065", 670, 695, 333, 360, "334"))
        AddRoomToArrayAndHashTab(New Room("EB3066", 670, 695, 360, 388, "334"))
        AddRoomToArrayAndHashTab(New Room("EB3067", 658, 695, 388, 405, "335"))
        AddRoomToArrayAndHashTab(New Room("EB3068", 658, 695, 405, 424, "335"))
    End Sub
    Private Sub AddNodeToArrayAndHashTab(ByVal node As Node) 'maps he string identifier to index in the array
        nodes(nodeCount) = node
        hashTab.Add(node.getIdentifier(), nodeCount)
        nodeCount += 1
    End Sub
    Private Sub AddEdgeToArrayAndHashTab(ByVal edge As Edge)
        edges(edgeCount) = edge
        hashTab.Add(edge.getNode1().getIdentifier & edge.getNode2().getIdentifier, edgeCount)
        edgeCount += 1
    End Sub
    Private Sub AddRoomToArrayAndHashTab(ByVal room As Room)
        rooms(roomCount) = room
        If Not hashTab.ContainsKey(room.getRoomNumber) Then
            hashTab.Add(room.getRoomNumber, roomCount)
        End If
        roomCount += 1
    End Sub
    Public Function getEdge(ByVal node1 As Node, ByVal node2 As Node) As Edge
        Return edges(hashTab.Item(node1.getIdentifier & node2.getIdentifier))
    End Function
    Public Function getRoomNumber(ByVal clickX As Integer, ByVal clickY As Integer, ByVal floor As Integer)
        For i = 0 To roomCount - 1
            If rooms(i).isRoom(clickX, clickY) AndAlso floor = Integer.Parse(rooms(i).getRoomNumber().ToCharArray()(2)) Then
                Return rooms(i).getRoomNumber()
            End If
        Next
        Return "INVALID"
    End Function
    Public Function getDestCoords(ByVal dest As String) As Integer()
        Return rooms(hashTab(dest)).getCoords()
    End Function
    Private Sub DrawMaps(ByVal origin As String, ByVal dest As String)
        dest = rooms(hashTab(dest)).getAdjacentWalkway
        Dim imgIndex, imgSmallIndex As Integer
        imgIndex = Integer.Parse(origin.ToCharArray()(0))
        imgSmallIndex = Integer.Parse(dest.ToCharArray()(0))
        sameFloor = imgIndex = imgSmallIndex
        img = floorImages(imgIndex)
        img2 = floorImages(imgSmallIndex)
        drawPath(Dijkstra(nodes(hashTab.Item(origin)), nodes(hashTab.Item(dest))), sameFloor)
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
            If Not iterFloor = originFloor AndAlso Not iterFloor = destFloor _
                AndAlso Not nodes(iterator).getNodeType = Node.Type_Key.STAIRWAY _
             AndAlso Not nodes(iterator).getNodeType = Node.Type_Key.ELEVATOR Then
                While Not nodes(currentPath(currentPathIndex - 1)).getIdentifier.ToCharArray()(0) = destFloor
                    iterator = currentPath(currentPathIndex - 1)
                    currentPathIndex -= 1
                End While
                currentPathIndex -= 1
                For Each adj In nodes(currentPath(currentPathIndex - 1)).getAdjList
                    Dim index As Integer = hashTab.Item(adj)
                    If Not index = iterator AndAlso Not index = currentPath(currentPathIndex) AndAlso Not nodes(index).getNodeType = Node.Type_Key.STAIRWAY _
             AndAlso Not nodes(index).getNodeType = Node.Type_Key.ELEVATOR Then
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
    Public Sub drawPath(ByVal path() As Integer, ByVal pathOnSameFloor As Boolean)
        Dim node1, node2 As Node
        Dim edge1 As Edge
        Dim newInt As Integer
        Dim previousEdge As Edge 'to determine left or right for angle
        node1 = nodes(path(0))

        For i = 1 To path.Length - 1
            node2 = nodes(path(i))
            If node1.getNodeType() = Node.Type_Key.STAIRWAY OrElse node1.getNodeType() = Node.Type_Key.ELEVATOR AndAlso _
                node2.getNodeType() = Node.Type_Key.STAIRWAY OrElse node2.getNodeType() = Node.Type_Key.ELEVATOR Then
                i += 1
                While nodes(path(i)).getNodeType = Node.Type_Key.STAIRWAY OrElse nodes(path(i)).getNodeType = Node.Type_Key.ELEVATOR
                    node1 = node2
                    node2 = nodes(path(i))
                    i += 1
                End While
                newInt = i
                'processEdgeForDirections(directions, directionsCount, edge1, node1.getNodeType)
                node1 = node2
                Exit For
            End If
            edge1 = getEdge(node1, node2)
            edge1.displayDirection(img)
            processEdgeForDirections(directions, directionsCount, edge1, Node.Type_Key.WALKWAY, previousEdge)
            previousEdge = edge1
            node1 = node2
        Next

        If Not pathOnSameFloor Then
            For i = newInt To path.Length - 1
                node2 = nodes(path(i))
                edge1 = getEdge(node1, node2)
                edge1.displayDirection(img2)
                processEdgeForDirections(directions, directionsCount, edge1, Node.Type_Key.WALKWAY, previousEdge)
                previousEdge = edge1
                node1 = node2
            Next
        End If

    End Sub
    Private Sub processEdgeForDirections(ByRef directions() As Direction, ByRef directionsCount As Integer, ByVal edge As Edge, ByVal type As Integer, ByVal previousEdge As Edge)
        If directionsCount = 0 Then
            directions(directionsCount) = New Direction(Direction.Direction_Key.STRAIGHT, type, img.Image.Size, CInt(Val(edge.getNode1.getIdentifier.ToCharArray()(0))) _
                                                        , edge.getDistance, edge.getNode1.getLocation.X, edge.getNode1.getLocation.Y, edge.getNode2.getLocation.X, edge.getNode2.getLocation.Y)
            directionsCount += 1
            Return
        End If

        If Not edge.getNode1.getNodeType = Node.Type_Key.WALKWAY Then
            directions(directionsCount) = New Direction(Direction.Direction_Key.CHANGEFLOOR, edge.getNode1.getNodeType, img.Image.Size, CInt(Val(edge.getNode1.getIdentifier.ToCharArray()(0))) _
                                                        , edge.getDistance, edge.getNode1.getLocation.X, edge.getNode1.getLocation.Y, edge.getNode2.getLocation.X, edge.getNode2.getLocation.Y)
            directionsCount += 1

            directions(directionsCount) = New Direction(Direction.Direction_Key.STRAIGHT, type, img.Image.Size, CInt(Val(edge.getNode1.getIdentifier.ToCharArray()(0))) _
                                                        , edge.getDistance, edge.getNode1.getLocation.X, edge.getNode1.getLocation.Y, edge.getNode2.getLocation.X, edge.getNode2.getLocation.Y)
            directionsCount += 1
        ElseIf Not previousEdge.getDirection() = edge.getDirection() Then
            directions(directionsCount) = New Direction(determineLeftOrRight(previousEdge.getDirection(), edge.getDirection), type, img.Image.Size, CInt(Val(edge.getNode1.getIdentifier.ToCharArray()(0))) _
                                                        , edge.getDistance, previousEdge.getNode2.getLocation.X, previousEdge.getNode2.getLocation.Y, edge.getNode2.getLocation.X, edge.getNode2.getLocation.Y)
            directionsCount += 1
            directions(directionsCount) = New Direction(Direction.Direction_Key.STRAIGHT, type, img.Image.Size, CInt(Val(edge.getNode1.getIdentifier.ToCharArray()(0))) _
                                                        , edge.getDistance, edge.getNode1.getLocation.X, edge.getNode1.getLocation.Y, edge.getNode2.getLocation.X, edge.getNode2.getLocation.Y)
            directionsCount += 1


        Else
            directions(directionsCount - 1).addDistance(edge.getDistance)
            directions(directionsCount - 1).updateNode2Location(edge.getNode2.getLocation.X, edge.getNode2.getLocation.Y)
        End If

    End Sub
    Private Function determineLeftOrRight(ByVal previousdirection As Integer, ByVal currentDirection As Integer) As Integer
        If previousdirection = Edge.Direction_Key.DOWN Then
            If currentDirection = Edge.Direction_Key.DOWNL Then
                Return Direction.Direction_Key.LEFT
            ElseIf currentDirection = Edge.Direction_Key.DOWNR Then
                Return Direction.Direction_Key.RIGHT
            ElseIf currentDirection = Edge.Direction_Key.L Then
                Return Direction.Direction_Key.RIGHT
            ElseIf currentDirection = Edge.Direction_Key.R Then
                Return Direction.Direction_Key.LEFT
            ElseIf currentDirection = Edge.Direction_Key.UPL Then
                Return Direction.Direction_Key.RIGHT
            ElseIf currentDirection = Edge.Direction_Key.UPR Then
                Return Direction.Direction_Key.LEFT
            End If
        ElseIf previousdirection = Edge.Direction_Key.DOWNL Then
            If currentDirection = Edge.Direction_Key.DOWN Then
                Return Direction.Direction_Key.LEFT
            ElseIf currentDirection = Edge.Direction_Key.DOWNR Then
                Return Direction.Direction_Key.RIGHT
            ElseIf currentDirection = Edge.Direction_Key.L Then
                Return Direction.Direction_Key.RIGHT
            ElseIf currentDirection = Edge.Direction_Key.R Then
                Return Direction.Direction_Key.LEFT
            ElseIf currentDirection = Edge.Direction_Key.UP Then
                Return Direction.Direction_Key.RIGHT
            ElseIf currentDirection = Edge.Direction_Key.UPL Then
                Return Direction.Direction_Key.RIGHT
            End If
        ElseIf previousdirection = Edge.Direction_Key.DOWNR Then
            If currentDirection = Edge.Direction_Key.DOWN Then
                Return Direction.Direction_Key.RIGHT
            ElseIf currentDirection = Edge.Direction_Key.DOWNL Then
                Return Direction.Direction_Key.RIGHT
            ElseIf currentDirection = Edge.Direction_Key.L Then
                Return Direction.Direction_Key.RIGHT
            ElseIf currentDirection = Edge.Direction_Key.R Then
                Return Direction.Direction_Key.LEFT
            ElseIf currentDirection = Edge.Direction_Key.UP Then
                Return Direction.Direction_Key.LEFT
            ElseIf currentDirection = Edge.Direction_Key.UPR Then
                Return Direction.Direction_Key.LEFT
            End If
        ElseIf previousdirection = Edge.Direction_Key.L Then
            If currentDirection = Edge.Direction_Key.DOWN Then
                Return Direction.Direction_Key.LEFT
            ElseIf currentDirection = Edge.Direction_Key.DOWNL Then
                Return Direction.Direction_Key.LEFT
            ElseIf currentDirection = Edge.Direction_Key.DOWNR Then
                Return Direction.Direction_Key.LEFT
            ElseIf currentDirection = Edge.Direction_Key.UP Then
                Return Direction.Direction_Key.RIGHT
            ElseIf currentDirection = Edge.Direction_Key.UPL Then
                Return Direction.Direction_Key.RIGHT
            ElseIf currentDirection = Edge.Direction_Key.UPR Then
                Return Direction.Direction_Key.RIGHT
            End If
        ElseIf previousdirection = Edge.Direction_Key.R Then
            If currentDirection = Edge.Direction_Key.DOWN Then
                Return Direction.Direction_Key.RIGHT
            ElseIf currentDirection = Edge.Direction_Key.DOWNL Then
                Return Direction.Direction_Key.RIGHT
            ElseIf currentDirection = Edge.Direction_Key.DOWNR Then
                Return Direction.Direction_Key.RIGHT
            ElseIf currentDirection = Edge.Direction_Key.UP Then
                Return Direction.Direction_Key.LEFT
            ElseIf currentDirection = Edge.Direction_Key.UPL Then
                Return Direction.Direction_Key.LEFT
            ElseIf currentDirection = Edge.Direction_Key.UPR Then
                Return Direction.Direction_Key.LEFT
            End If
        ElseIf previousdirection = Edge.Direction_Key.UP Then
            If currentDirection = Edge.Direction_Key.DOWNL Then
                Return Direction.Direction_Key.LEFT
            ElseIf currentDirection = Edge.Direction_Key.DOWNR Then
                Return Direction.Direction_Key.RIGHT
            ElseIf currentDirection = Edge.Direction_Key.L Then
                Return Direction.Direction_Key.LEFT
            ElseIf currentDirection = Edge.Direction_Key.R Then
                Return Direction.Direction_Key.RIGHT
            ElseIf currentDirection = Edge.Direction_Key.UPL Then
                Return Direction.Direction_Key.LEFT
            ElseIf currentDirection = Edge.Direction_Key.UPR Then
                Return Direction.Direction_Key.RIGHT
            End If
        ElseIf previousdirection = Edge.Direction_Key.UPL Then
            If currentDirection = Edge.Direction_Key.DOWN Then
                Return Direction.Direction_Key.LEFT
            ElseIf currentDirection = Edge.Direction_Key.DOWNL Then
                Return Direction.Direction_Key.LEFT
            ElseIf currentDirection = Edge.Direction_Key.L Then
                Return Direction.Direction_Key.LEFT
            ElseIf currentDirection = Edge.Direction_Key.R Then
                Return Direction.Direction_Key.RIGHT
            ElseIf currentDirection = Edge.Direction_Key.UP Then
                Return Direction.Direction_Key.RIGHT
            ElseIf currentDirection = Edge.Direction_Key.UPR Then
                Return Direction.Direction_Key.RIGHT
            End If
        ElseIf previousdirection = Edge.Direction_Key.UPR Then
            If currentDirection = Edge.Direction_Key.DOWN Then
                Return Direction.Direction_Key.RIGHT
            ElseIf currentDirection = Edge.Direction_Key.DOWNR Then
                Return Direction.Direction_Key.RIGHT
            ElseIf currentDirection = Edge.Direction_Key.L Then
                Return Direction.Direction_Key.LEFT
            ElseIf currentDirection = Edge.Direction_Key.R Then
                Return Direction.Direction_Key.RIGHT
            ElseIf currentDirection = Edge.Direction_Key.UP Then
                Return Direction.Direction_Key.LEFT
            ElseIf currentDirection = Edge.Direction_Key.UPL Then
                Return Direction.Direction_Key.LEFT
            End If
        End If
        Return Direction.Direction_Key.INVALID
    End Function
    Public Class Edge
        Dim weight As Integer
        Dim node1 As Node
        Dim node2 As Node
        Dim direction As Integer
        Dim imagePath As String = Application.StartupPath & "\Arrows\"
        Dim directionStrings() As String = {"Up.png", "Down.png.", "Left.png", "Right.png", "UpLeft.png", "UpRight.png", "DownLeft.png", "DownRight.png"}
        Dim distance As Integer
        Dim arrowImageSize As Integer = 20
        Sub New(ByVal weight As Integer, ByVal node1 As Node, ByVal node2 As Node, Optional ByVal direction As Integer = Direction_Key.INVALID)
            Me.weight = weight
            Me.node1 = node1
            Me.node2 = node2
            Me.direction = direction
            Me.determineDirection(Me.node1, Me.node2)
            distance = Math.Sqrt(Math.Pow(node1.getLocation.X - node2.getLocation.X, 2) + Math.Pow(node1.getLocation.Y - node2.getLocation.Y, 2))
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
            Dim bmp As Bitmap = New Bitmap(bitmampSize, bitmampSize)
            Dim graph As Graphics = Graphics.FromImage(picbox.Image)
            Using g As Graphics = Graphics.FromImage(bmp)
                g.DrawImage(Image.FromFile(imagePath & directionStrings(direction)), 0, 0, bmp.Width, bmp.Height)
            End Using
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
        Public Function getWeight() As Integer
            Return weight
        End Function
        Public Function getNode1() As Node
            Return node1
        End Function
        Public Function getNode2() As Node
            Return node2
        End Function
        Public Function getDirection() As Integer
            Return direction
        End Function
        Public Function getDistance() As Integer
            Return distance
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
            STAIRWAY
            ELEVATOR
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
    Public Class Room
        Dim roomNumber As String
        Dim xUp As Integer
        Dim xDown As Integer
        Dim yUp As Integer
        Dim yDown As Integer
        Dim adjacentWalkway As String
        Public Sub New(ByVal roomNumber As String, ByVal xDown As Integer, ByVal xUp As Integer, ByVal yDown As Integer _
                       , ByVal yUp As Integer, ByVal adjacentWalkway As String)
            Me.roomNumber = roomNumber
            Me.xUp = xUp
            Me.xDown = xDown
            Me.yUp = yUp
            Me.yDown = yDown
            Me.adjacentWalkway = adjacentWalkway
        End Sub
        Public Function getRoomNumber() As String
            Return roomNumber
        End Function
        Public Function getAdjacentWalkway() As String
            Return adjacentWalkway
        End Function
        Public Function getCoords() As Integer()
            Return New Integer() {xDown, yDown, xUp, yUp}
        End Function
        Public Function isRoom(ByVal clickX As Integer, ByVal clickY As Integer)
            If clickX <= Me.xUp AndAlso clickX >= Me.xDown AndAlso clickY <= Me.yUp AndAlso clickY >= Me.yDown Then
                Return True
            End If
            Return False
        End Function
    End Class
End Class 'End Navigation Class
Public Class TwentyOne
    Dim cardCount = 0, card = 0
    Dim bigAce = False
    Dim randomObject As New Random()

    Private Sub Deal_HitBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Deal_HitBtn.Click
        If cardCount = 5 Then
            Reset()
        End If
        If cardCount = 0 Then
            CardFlip(CardImg1)
            CardFlip(CardImg2)
            CardImg3.Visible = True
            cardCount = 2
            TotalPointsPts.Text -= 100
            Deal_HitBtn.Text = "Hit"
            StayBtn.Visible = True
        ElseIf cardCount = 2 Then
            CardFlip(CardImg3)
            CardImg4.Visible = True
            cardCount = 3
        ElseIf cardCount = 3 Then
            CardFlip(CardImg4)
            CardImg5.Visible = True
            cardCount = 4
        ElseIf cardCount = 4 Then
            CardFlip(CardImg5)
            If HandValuePts.Text <= 21 Then
                BustedLbl.Text = "5-Card Win!"
                BustedLbl.Visible = True
                HandPointsPts.Text = 250
            End If
            cardCount = 5
        End If
        If bigAce AndAlso HandValuePts.Text > 21 Then
            bigAce = False
            HandValuePts.Text -= 10
            HandPointsPts.Text = ValueOfHand(HandValuePts.Text) 'updates the points of current hand
        End If
        CheckForWinOrBust()
    End Sub
    Private Sub StayBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StayBtn.Click
        cardCount = 5
        CheckForWinOrBust()
    End Sub
    Private Sub CardFlip(ByVal CardImg As PictureBox)
        card = randomObject.Next(1, 53)
        Dim pictureResource = My.Resources.ResourceManager.GetObject(String.Format("_{0}", card))
        HandValuePts.Text += ValueOfCard(card Mod 13) 'updates the value of current hand
        HandPointsPts.Text = ValueOfHand(HandValuePts.Text) 'updates the points of current hand
        CardImg.Image = CType(pictureResource, Image)

    End Sub
    Private Function ValueOfHand(ByVal Val As Integer) As Integer
        If Val = 17 Then
            Return 100
        ElseIf Val = 18 Then
            Return 125
        ElseIf Val = 19 Then
            Return 150
        ElseIf Val = 20 Then
            Return 200
        ElseIf Val = 21 Then
            Return 250
        End If

        Return 0
    End Function
    Private Function ValueOfCard(ByVal Val As Integer) As Integer

        If Val = 1 AndAlso HandValuePts.Text <= 10 Then
            bigAce = True
            Return 11
        ElseIf Val = 1 AndAlso HandValuePts.Text > 10 Then
            Return 1
        ElseIf Val > 10 OrElse Val = 0 Then
            Return 10
        End If

        Return Val
    End Function
    Sub CheckForWinOrBust()

        If cardCount = 5 OrElse HandValuePts.Text > 21 Then
            StayBtn.Visible = False
            Deal_HitBtn.Text = "Deal"

            If HandValuePts.Text > 21 Then
                BustedLbl.Visible = True
                HandPointsPts.Text = 0
                cardCount = 5
            ElseIf cardCount = 5 Then
                Dim total As Integer
                total += TotalPointsPts.Text
                total += HandPointsPts.Text
                TotalPointsPts.Text = total
            End If
        End If
    End Sub
    Sub Reset()
        CardImg3.Visible = False
        CardImg4.Visible = False
        CardImg5.Visible = False
        BustedLbl.Visible = False
        bigAce = False
        BustedLbl.Text = "Busted"
        HandValuePts.Text = "0"
        HandPointsPts.Text = "0"
        cardCount = 0
        CardImg1.Image = CType(My.Resources.ResourceManager.GetObject(String.Format("_{0}", 55)), Image)
        CardImg2.Image = CType(My.Resources.ResourceManager.GetObject(String.Format("_{0}", 55)), Image)
        CardImg3.Image = CType(My.Resources.ResourceManager.GetObject(String.Format("_{0}", 55)), Image)
        CardImg4.Image = CType(My.Resources.ResourceManager.GetObject(String.Format("_{0}", 55)), Image)
        CardImg5.Image = CType(My.Resources.ResourceManager.GetObject(String.Format("_{0}", 55)), Image)
    End Sub

End Class

Module ParticleC
    Public Sub particle_active(ByVal pp As partcle)
        '彈幕動作
        If pp.useable Then
            '邊界判斷
            If pp.Ly < 0 - 20 Or pp.Ly > Form1.Height + 20 Or pp.Lx < 0 - 20 Or pp.Lx > Form1.Width + 20 Then
                pp.useable = False
            End If

            If pp.type = 1 Then '標準粒子
                pp.Lx = pp.Lx + pp.Sx
                pp.Ly = pp.Ly + pp.Sy
            ElseIf pp.type = 2 Then '導彈
                pp.Sx = pp.Sx * 1.05
                pp.Sy = pp.Sy * 1.05
                pp.Lx = pp.Lx + pp.Sx
                pp.Ly = pp.Ly + pp.Sy
            ElseIf pp.type = 3 Then ' 追蹤彈
                Dim Stx, Sty, th2, d As Single
                'For i = 0 To 100
                '    If Enemy_Obj(i).useable Then
                '        If d = 0 Then
                '            d = ((player_loc.Y - Enemy_Obj(i).Ly) ^ 2 + (player_loc.Y - Enemy_Obj(i).Ly) ^ 2) ^ 0.5
                '        End If
                '        Dim d2 As Single
                '        d2 = ((player_loc.Y - Enemy_Obj(i).Ly) ^ 2 + (player_loc.Y - Enemy_Obj(i).Ly) ^ 2) ^ 0.5
                '        If d2 < d Then
                '            d = d2
                '            th2 = Math.Atan2(player_loc.Y - Enemy_Obj(i).Ly, player_loc.X - Enemy_Obj(i).Lx)
                '        End If
                '    End If
                'Next
                th2 = Math.Atan2(Player_loc.Y - pp.Lx, Player_loc.X - pp.Lx)
                Stx = pp.Sx + 0.2 * Math.Cos(th2)
                Sty = pp.Sy + 0.2 * Math.Sin(th2)
                th2 = Math.Atan2(Sty, Stx)
                d = (pp.Sx ^ 2 + pp.Sy ^ 2) ^ 0.5
                pp.Sx = d * Math.Cos(th2)
                pp.Sy = d * Math.Sin(th2)
                pp.Lx = pp.Lx + pp.Sx
                pp.Ly = pp.Ly + pp.Sy
            End If
            '命中判定
            If ((pp.Lx - Player_loc.X) ^ 2 + (pp.Ly - Player_loc.Y) ^ 2 < 10 ^ 2) Then
                pp.useable = False
                '命中粒子效果
                particle_effect_create(2, pp.Lx, pp.Ly, 3, 30, 10, Color.Green)
                player_HP = player_HP - 3
            End If
        End If
    End Sub
    Public Sub particleP_active(ByVal pp As partcle)
        '彈幕動作
        If pp.useable Then
            '邊界判斷
            If pp.Ly < 0 - 20 Or pp.Ly > Form1.Height + 20 Or pp.Lx < 0 - 20 Or pp.Lx > Form1.Width + 20 Then
                pp.useable = False
            End If

            If pp.type = 1 Then '一般攻擊
                pp.Lx = pp.Lx + pp.Sx
                pp.Ly = pp.Ly + pp.Sy
                For j = 1 To 100
                    If ((pp.Lx - Enemy_Obj(j).Lx) ^ 2 + (pp.Ly - Enemy_Obj(j).Ly) ^ 2 < (Enemy_Obj(j).size.Width / 2) ^ 2) And Enemy_Obj(j).useable Then
                        pp.useable = False
                        Enemy_Obj(j).HP = Enemy_Obj(j).HP - pp.attack
                        '命中粒子效果
                        particle_effect_create(2, pp.Lx, pp.Ly, 3, 10, 5, pp.color)
                        
                    End If
                Next
            ElseIf pp.type = 2 Then '導彈
                pp.Sx = pp.Sx * 1.05
                pp.Sy = pp.Sy * 1.05
                pp.Lx = pp.Lx + pp.Sx
                pp.Ly = pp.Ly + pp.Sy
                If pp.count < 10 Then
                    pp.count = pp.count + 1
                Else
                    pp.count = 0
                    particle_effect_create(2, pp.Lx, pp.Ly, 0.5, 20, 1, Color.Gray)
                End If
                For j = 1 To 100
                    If ((pp.Lx - Enemy_Obj(j).Lx) ^ 2 + (pp.Ly - Enemy_Obj(j).Ly) ^ 2 < (Enemy_Obj(j).size.Width / 2) ^ 2) And Enemy_Obj(j).useable Then
                        pp.useable = False
                        '命中粒子效果
                        particle_effect_create(2, pp.Lx, pp.Ly, 2.5, 25, 7, Color.Orange)
                        particle_effect_create(100, pp.Lx, pp.Ly, 0, 5, 1, Color.Yellow)
                        For i = 1 To 100
                            '爆炸半徑
                            If ((pp.Lx - Enemy_Obj(j).Lx) ^ 2 + (pp.Ly - Enemy_Obj(j).Ly) ^ 2 < 100 ^ 2) And Enemy_Obj(j).useable Then
                                Enemy_Obj(j).HP = Enemy_Obj(j).HP - pp.attack
                            End If
                        Next
                        
                        Exit For
                    End If

                Next
            End If
        End If
    End Sub
End Module

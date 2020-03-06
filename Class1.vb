'粒子物件
Public Class partcle			'particle 拼錯了xdd
    Public type As Integer		'粒子類型
    Public useable As Boolean	'物件庫的開關
    Public Lx As Single			'位置
    Public Ly As Single			'位置
    Public Sx As Single			'速度
    Public Sy As Single			'速度
    Public count As Integer		'計時器-消除延遲之用
    Public color As Color		'粒子顏色
    Public size As Size			'粒子大小
    Public attack As Integer
End Class

'敵人物件
Public Class enemy
    Public Type As Integer		'敵人類型
    Public HP As Integer		'血量
    Public useable As Boolean	'物件庫的開關
    Public Lx As Single			'位置
    Public Ly As Single			'位置
    Public count As Integer		'計時器-作為敵人行為的基準
    Public color As Color		'敵人顏色
    Public size As Size			'敵人大小
End Class

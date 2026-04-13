Imports System.Text.RegularExpressions

Module Module1

	Sub Main()
		Const MAX_INT = UInteger.MaxValue
		Dim nDecNum = 0L
		Dim nHexPower = 1L
		Dim nMaxHexLen = Math.Ceiling(Math.Log(MAX_INT, 16))
		Dim oRegEx = New Regex("^[0-9A-Fa-f]+$")
		Console.WriteLine("Input a hexadecimal number")
		Dim strLine = Console.ReadLine()
		Dim nStrLen = strLine.Length
		Dim bIsMatch = oRegEx.IsMatch(strLine)
		Dim bRightString = (nStrLen <= nMaxHexLen) AndAlso bIsMatch
		If Not bRightString Then
			Console.WriteLine("Wrong hexadecimal number format!!!")
			Console.Read()
			Return
		End If
		For i As Integer = 0 To nStrLen - 1
			Dim nHexDight As Integer = 0
			Dim chHexDigit As Char = strLine.Chars(nStrLen - 1 - i)
			If (chHexDigit >= "0" And chHexDigit <= "9") Then
				nHexDight = AscW(chHexDigit) - AscW("0"c)
			ElseIf chHexDigit >= "A" And chHexDigit <= "F" Then
				nHexDight = 10 + AscW(chHexDigit) - AscW("A")
			ElseIf chHexDigit >= "a" And chHexDigit <= "f" Then
				nHexDight = 10 + AscW(chHexDigit) - AscW("a")
			End If
			nDecNum += (nHexDight * nHexPower)
			nHexPower *= 16
		Next i
		Console.WriteLine("The decimal equivalent of the hexadecimal number {0} is {1}", strLine, nDecNum)
		Console.Read()
	End Sub

End Module

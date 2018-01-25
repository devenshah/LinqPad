<Query Kind="VBProgram" />

Public Class RegexPatterns
	'sample valid value 1224-4325-7376-4563-0926
	Public Const TwentyFourCharacterReferenceNumberPattern = "^\d{4}(-\d{4}){4}$"
	
	Public Const PostCodePattern = "^([Gg][Ii][Rr] 0[Aa]{2})|((([A-Za-z][0-9]{1,2})|(([A-Za-z][A-Ha-hJ-Yj-y][0-9]{1,2})|(([A-Za-z][0-9][A-Za-z])|([A-Za-z][A-Ha-hJ-Yj-y][0-9]?[A-Za-z])))) {0,1}[0-9][A-Za-z]{2})$"
	Public const PostcodePatternAllowEmpty = "^(\s|([gG][iI][rR] {0,}0[aA]{2})|((([a-pr-uwyzA-PR-UWYZ][a-hk-yA-HK-Y]?[0-9][0-9]?)|(([a-pr-uwyzA-PR-UWYZ][0-9][a-hjkstuwA-HJKSTUW])|([a-pr-uwyzA-PR-UWYZ][a-hk-yA-HK-Y][0-9][abehmnprv-yABEHMNPRV-Y]))) {0,}[0-9][abd-hjlnp-uw-zABD-HJLNP-UW-Z]{2}))*$"
	
	Public Const AlphaNumericPattern = "^([A-Z]|[a-z]){{{0}}}\d{{{1}}}$"
	
	'Assumption: Alphabets  precedes numbers
	'You can use this for only Alphabets or only numbers by setting the other count to zero. 
	Public Shared Function IsValidAlphaNumericString(ByVal target As String, ByVal alphaCount As Integer, ByVal numberCount As Integer) As Boolean
		Return Regex.IsMatch(target, String.Format(AlphaNumericPattern, alphaCount, numberCount))
	End Function
	
	Public Shared Function IsValid24CharacterReferenceNumber(ByVal target As String)
		Return Regex.IsMatch(target, TwentyFourCharacterReferenceNumberPattern)
	End Function

End Class
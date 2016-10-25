Function Write-ToHost
{
    Param (
        [Parameter(Mandatory=$true, ValueFromPipeline=$true)]
        [string]$text, 
        [ValidateRange(1,16)]
        [int]$headerLevel=16,
        [ValidateSet("Black","DarkBlue","DarkGreen",`
                    "DarkCyan","DarkRed","DarkMagenta",`
                    "DarkYellow","Gray","DarkGray","Blue",`
                    "Green","Cyan","Red","Magenta","Yellow","White")]
        [string]$foregroundColor
        )

    $states = [enum]::GetValues([System.ConsoleColor])

    $foregroundColor = 
        if($foregroundColor -eq "") {$states[$headerLevel-1]} else {$foregroundColor}

    Write-Host $text -ForegroundColor $foregroundColor
}


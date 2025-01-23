$scriptDirectory = Split-Path -Parent $MyInvocation.MyCommand.Path
$outputBasePath = Join-Path $scriptDirectory "../PublishedApp"

$projectPaths = @(
    "src\PaddleBilling.Core\PaddleBilling.Core.csproj"
    "src\PaddleBilling.Webhooks\PaddleBilling.Webhooks.csproj"
)


if ((Test-Path $outputBasePath)) {
    Remove-Item -Recurse -Force $outputBasePath
}


New-Item -ItemType Directory -Path $outputBasePath | Out-Null


foreach ($relativeProjectPath in $projectPaths) {
    $projectPath = Join-Path $scriptDirectory "../$relativeProjectPath"
    $projectName = [System.IO.Path]::GetFileNameWithoutExtension($relativeProjectPath)
    $outputPath = Join-Path $outputBasePath $projectName

    Write-Host "Building and packing $projectName..."
    
    New-Item -ItemType Directory -Path $outputPath | Out-Null
    
    dotnet pack $projectPath --configuration Release --output $outputPath
    
    Write-Host "Done packing $projectName!"
}

Write-Host "All projects packed!"
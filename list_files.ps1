# Define the starting directory path
$directoryPath = "C:\Program Files (x86)\Microsoft Office\Office12"

# Check if the directory exists before attempting to process it
if (Test-Path -Path $directoryPath -PathType Container) {
    Write-Host "Scanning $directoryPath..." -ForegroundColor Cyan

    # Get all files recursively (excludes folders)
    # -ErrorAction SilentlyContinue skips files we don't have permission to read
    Get-ChildItem -Path $directoryPath -Recurse -ErrorAction SilentlyContinue |
    Get-FileHash  -Algorithm MD5 |
    Export-CSV -Path "C:\temp\md5_checksums.csv" 

} else {
    Write-Error "The directory '$directoryPath' does not exist or is not accessible."
}

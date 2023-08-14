# ---
$currentDirectory = Get-Location
Set-Location "C:\Users\Tobias\Desktop\PowerScraper\PowerScraper\PowerScraper\Docker"

docker build -t icybadger/powerscraper-unittests:1.0.0 -f unittests.Dockerfile ../../
docker container run -it --rm --name ps-unittests icybadger/powerscraper-unittests:1.0.0
if ($LASTEXITCODE -eq 0) {
    docker compose build
    # 'app' depends on 'postgres'
    docker compose up --attach app
    Set-Location $currentDirectory
    exit 0
}
else {
    Write-Host "unittests failed to execute successfully. Aborting."
    Set-Location $currentDirectory
    exit 1
}

<# 
   docker build -t powerscraper-app -f app.Dockerfile .
   docker build -t powerscraper-postgres -f postgres.Dockerfile . 
#>

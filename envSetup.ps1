${env:GOOGLE_APPLICATION_CREDENTIALS}= "dev-service-account-key.json"
$env:DB_HOST = '34.152.7.147'
$env:SERVER = '34.152.7.147'
$env:DB_USER = 'dev-access-account'
$env:DB_PASS = 'password'
$env:DB_NAME = 'dev'
$env:project_id = 'keen-extension-331705'
$env:region = 'northamerica-northeast1'
$env:instance_name = 'dev-smert-db'
$env:User_Id = $env:DB_USER

Start-Process -filepath ".\cloud_sql_proxy_x64.exe" -ArgumentList "--instances=${env:project_id}:${env:region}:${env:instance_name}=tcp:3306 --credential_file=$env:GOOGLE_APPLICATION_CREDENTIALS"

try {

    dotnet restore
	dotnet build --no-restore
	dotnet run 

} finally {

}
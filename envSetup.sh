export GOOGLE_APPLICATION_CREDENTIALS=./dev-service-account-key.json
export DB_HOST='34.152.7.147'
export SERVER='34.152.7.147'
export DB_USER='dev-access-account'
export DB_PASS='password'
export DB_NAME='dev'
export project_id='keen-extension-331705'
export region='northamerica-northeast1'
export instance_name=dev-'smert-db'
export User_Id=$DB_USER


./cloud_sql_proxy -instances=${project_id}:$region:${instance_name}=tcp:5432 -credential_file=$GOOGLE_APPLICATION_CREDENTIALS &
dotnet add package System.Text.Encoding.CodePages
dotnet restore
dotnet run
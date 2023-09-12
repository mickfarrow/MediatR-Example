# DiveLogger-WebApiCore
# Hello

https://www.youtube.com/watch?v=f0lMGPB10bM

https://learn.microsoft.com/en-us/dotnet/architecture/containerized-lifecycle/design-develop-containerized-apps/build-aspnet-core-applications-linux-containers-aks-kubernetes

docker image build --force-rm -t  divelog.core.webapi:dev .

docker run -d -p 3280:80 --name DiveLog.Core.WebApi divelog.core.webapi:dev

docker run -d -p 32443:443 --name DiveLog.Core.WebApi.Ssl divelog.core.webapi:dev

{
  "username": "mick.farrow@visualdev.net",
  "password": "UaB53*jm*4J7o0*z"
}
"id": 1,
  "firstName": "Mick",
  "lastName": "Farrow",
  "username": "mick.farrow@visualdev.net",
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Ik1pY2sgRmFycm93IiwiZW1haWwiOiJtaWNrLmZhcnJvd0B2aXN1YWxkZXYubmV0IiwiRXhwaXJ5IjoiMDgvMTQvMjAyMyAyMTo1MDo1NSIsIm5iZiI6MTY5MTk2MzQ1NSwiZXhwIjoxNjkyMDQ5ODU1LCJpYXQiOjE2OTE5NjM0NTV9.hIIyQMS8fEY7YPU8sgVeBdglG2JKrif64Zsen9Tz3ug"
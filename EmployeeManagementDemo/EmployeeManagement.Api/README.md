# EmployeeManagement.Api

A demo project using MediatR v 12.1.1

[MediatR GitHUb](https://github.com/jbogard/MediatR)

[Deploy an Api with Docker](https://www.youtube.com/watch?v=f0lMGPB10bM)

[Deploy app with Kubernetes](https://learn.microsoft.com/en-us/dotnet/architecture/containerized-lifecycle/design-develop-containerized-apps/build-aspnet-core-applications-linux-containers-aks-kubernetes)

docker image build --force-rm -t employeemanagement.api:dev .

docker run -d -p 3280:80 --name employeemanagement employeemanagement.api:dev

[Configuring Database](https://dev.azure.com/mickfarrow/My%20Space/_wiki/wikis/My-Space.wiki/15/Docker-and-Containers?anchor=dive-journal-sql-database)

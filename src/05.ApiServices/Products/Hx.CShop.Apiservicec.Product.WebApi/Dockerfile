FROM microsoft/aspnetcore:2.0
ARG source
WORKDIR /app
EXPOSE 8000
COPY ${source:-obj/Docker/publish} .
ENTRYPOINT ["dotnet", "Hx.CShop.Apiservicec.Product.WebApi.dll"]

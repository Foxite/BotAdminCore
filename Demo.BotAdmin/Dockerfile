FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Demo.BotAdmin/Demo.BotAdmin.csproj", "Demo.BotAdmin/"]
COPY ["Demo.BotAdmin/NuGet.config", "Demo.BotAdmin/"]
RUN dotnet restore "Demo.BotAdmin/Demo.BotAdmin.csproj"
COPY ["Demo.BotAdmin/", "Demo.BotAdmin/"]
WORKDIR "/src/Demo.BotAdmin"
RUN dotnet build "Demo.BotAdmin.csproj" -c Release -o /app/build && \
    dotnet publish "Demo.BotAdmin.csproj" -c Release -o /app/publish 


FROM scratch AS final
LABEL dev.foxite.botadmin.name=Demo.BotAdmin
WORKDIR /module
COPY --from=build /src/Demo.BotAdmin/bin/Release/net6.0/Modules/Demo.BotAdmin .

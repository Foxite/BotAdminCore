# This image needs to be built using the project root context:
# docker build -f Demo.BotAdmin/Dockerfile .
# This is because during testing, you may modify the csproj to use the local version of the SDK, instead of the SDK on nuget.
# In that case, the full context will be necessary - otherwise, it only slows down the build marginally. Since this is only a demo image, this is not considered a problem.

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Demo.BotAdmin/Demo.BotAdmin.csproj", "Demo.BotAdmin/"]
COPY ["Demo.BotAdmin/NuGet.config", "Demo.BotAdmin/"]
RUN dotnet restore "Demo.BotAdmin/Demo.BotAdmin.csproj"
COPY ["Demo.BotAdmin/", "Demo.BotAdmin/"]
WORKDIR "/src/Demo.BotAdmin"
# It says to use /app/build and /app/publish, but the csproj overrides this, and the files end up somewhere else (see below).
# Regardless, if you remove the -o flag it will break, feel free to figure out why.
RUN dotnet build "Demo.BotAdmin.csproj" -c Release -o /app/build && \
    dotnet publish "Demo.BotAdmin.csproj" -c Release -o /app/publish 


FROM scratch AS final
LABEL dev.foxite.botadmin.name=Demo.BotAdmin
WORKDIR /module
# csproj is configured to output the assembly to the modules folder. This doesn't serve any purpose in Docker,
# but if you change it, it will no longer work properly in non-docker development builds.
COPY --from=build /src/Demo.BotAdmin/bin/Release/net6.0/Modules/Demo.BotAdmin .

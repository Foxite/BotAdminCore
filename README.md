# BotAdminCore
This is a program that provides the foundation for a centralized web interface for managing apps.

It's called BotAdminCore because it's mainly intended to be used with Discord bots, but in theory it should work with anything.

How it works: BotAdminCore is an executable that looks in its Modules folder, and any folder that's there is searched for module assemblies. These module assemblies are .net class libraries that reference BotAdminCore. In this repository is an example, Demo.BotAdmin. Any module assembly that it finds is loaded, and searched for implementations of the abstract Module class defined in BotAdminCore. These implementations are instantiated and then used configure the whole app.

A module provides the necessary code to configure an app and exposes it through an ASP.NET controller. BotAdminCore is responsible for enforcing security on all controllers.

Most modules will configure an app by modifying its database or other config files.

## How to run
### In development
When starting BotAdminCore by itself it doesn't do much, so you should start Demo.BotAdmin, using the launchSettings.json file.

It uses a custom SDK provided by BotAdminCore, and as such it is configured to output its own binaries to bin/Debug/net6.0/Modules/Demo.BotAdmin, while BotAdminCore is pulled from Nuget and copied into bin/Debug/net6.0.

When working on BotAdminCore, you may want to test your changes using Demo.BotAdmin; open the Demo.BotAdmin.csproj, remove the project sdk, and uncomment the Import tags. This will allow you to test your local changes to BotAdminCore.

To set up your own module, you can copy Demo.BotAdmin -- a project template is on the todo list.

### In production
The recommended setup is to use the docker-compose.yml file in this repository. It is set up to automatically find docker containers with these labels:
- `dev.foxite.botadmin` (value is ignored)
- `dev.foxite.botadmin.name` (value is the name of the module assembly)
- `dev.foxite.botadmin.image` (value is the name of the image containing the module assembly)

Whenever you start or stop containers with those images, a new docker image will be built that incorporates BotAdminCore and all the modules for your app.  Use [Watchtower](https://github.com/containrrr/watchtower) to automatically update your BotAdmin container.

More details on the implementation:
- The Dockerfile in BotAdminCore produces the base BotAdminCore image.
- The Dockerfile in Demo.BotAdmin produces a `FROM scratch` image containing only the files in the module folder.
- This repository contains a Dockerfile.tmpl file, to be used with [docker-gen](https://github.com/nginx-proxy/docker-gen/); this will monitor the docker engine for containers with the label `dev.foxite.botadmin`, and produce a dockerfile that combines BotAdminCore with the modules specified by the `dev.foxite.botadmin.name` (should be `Demo.BotAdmin`) and `dev.foxite.botadmin.image` (should be `your.repository.org/demo.botadmin`).
- This dockerfile is then built inside the docker-gen container, which is connected to the host's docker engine, so the image will be accessible from your host.

## TODO
- Module project template
- Frontend system
- OAuth2 provided by Discord (or custom SSO)

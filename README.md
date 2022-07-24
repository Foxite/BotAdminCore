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
TODO.

## TODO
- Production deployment
- Module project template
- Frontend system
- OAuth2 provided by Discord (or custom SSO)

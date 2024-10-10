
### Installation Requirements:
- If the project uses **.NET Core**: Download **.NET** here: [Download .NET](https://dotnet.microsoft.com/en-us/download/dotnet)
- If the project uses **.NET Framework**: Download **.NET Framework** here: [Download .NET Framework](https://dotnet.microsoft.com/en-us/download/dotnet-framework)

---

### How to debug in development environment:

#### For **Visual Studio Code**:
1. Open Visual Studio Code, select `File/Open Folder...` and choose the folder containing the project.
2. Click `Run/Start Debugging (F5)` or select `Run and Debug` or `View/Run`, then click on the `Launch __Server__.Startup (Debug)` button.

#### For **Visual Studio 2022** or later:
1. Open the `__Server__.sln` file in Visual Studio.
2. In `Solution Explorer`, right-click the **__Server__.Startup** project and select `Set as Startup Project`.
3. Click `Debug/Start Debugging (F5)` to start debugging.

---

### How to deploy to production:
## [Deploy](https://protonnetserver.com/deploy)

## I. Without Docker
Use **ProtonNet Control** to deploy the **__Server__** application:

1. Download the latest version of **ProtonNet Control** here: [Download ProtonNet Control](https://protonnetserver.com/download)

2. Extract it to any folder on your system, for example, `ProtonNetControl`.

3. **Edit the `ProtonNetServerSettings.json` file**:
    - Change the `"TargetFramework"` field: Set it to `"__TargetFramework__"`.
    - Change the `"TargetRuntime"` field: Choose the runtime that matches your server.
    - **Add configuration for `__Server__`** and final file `ProtonNetServerSettings.json` should look like:
     ```json
    {
        "TargetFramework": "__TargetFramework__",
        "TargetRuntime": "linux-x64",
        "Instances": [
            {
                ...other instance...
            },
            {
                "Name": "__Server__",
                "Enable": true,
                "ServerType": "__ServerType__",
                "BinPath": "__Server__",
                "AssemblyName": "__Server__",
                "StartupSettingsFilePath": "StartupSettings.json",
                "Log4NetFilePath": "log4net.config",
                "StartupType": "auto"
            }
        ]
    }
     
     ```

4. Build the **__Server__** project in release mode:
    - After building, copy all DLL files, the `StartupSettings.json` file, and the `log4net.config` file from the default path `__Server__\__Server__\bin\Release\__TargetFramework__\` to `ProtonNetControl applications\__Server__\`.

5. **Install the service** using the following commands:
    - **For Windows**: Open Command Prompt and type:
     ```
     control.bat install __Server__
     ```
    - **For Linux or macOS**: Open Terminal and type:
     ```
     ./control.sh install __Server__
     ```

6. **Start the service**:
    - **For Windows**: Type:
     ```
     control.bat start __Server__
     ```
    - **For Linux or macOS**: Type:
     ```
     control.sh start __Server__
     ```

### Status and Logs
1. **Check service status**:
    - **For Windows**: Type:
     ```
     control.bat status __Server__
     ```
    - **For Linux or macOS**: Type:
     ```
     control.sh status __Server__
     ```

2. **View service logs**: (all server logs will be located in `ProtonNetControl\logs\__Server__\`)
    - **For Windows**: Type:
     ```
     control.bat log __Server__
     ```
    - **For Linux or macOS**: Type:
     ```
     control.sh log __Server__
     ```

---

## II. With Docker (for .NET Core projects)

You can use the `Dockerfile` in this project to build a Docker `image` by running the following command:
```
    docker build -t __ServerLowercase__ ./
```

After the build completes successfully, you can run a Docker `container` (make sure to adjust the ports as needed) by running the following command:
```
    docker run __ServerLowercase__ -p 32202:32202 -p 30802:30802 -p 42202:42202/udp -p 52202:52202 -p 50802:50802
```

- `-p 32202:32202`: Maps port 32202 from the container to the host port 32202. (default tcp port in `StartupSettings.json`)
- `-p 30802:30802`: Maps port 30802 from the container to the host port 30802. (default ssl port in `StartupSettings.json`)
- `-p 42202:42202/udp`: Maps udp port 42202 from the container to the host udp port 42202. (default udp port in `StartupSettings.json`)
- `-p 52202:52202`: Maps port 52202 from the container to the host port 52202. (default ws port in `StartupSettings.json`)
- `-p 50802:50802`: Maps port 32202 from the container to the host port 32202. (default wss port in `StartupSettings.json`)

Ensure that these ports do not conflict with other services running on your machine.

---

**Note**:
- Ensure all files and folders are correctly placed in `ProtonNetControl` before installing and starting the service.
- Check the configuration of **ProtonNetServerSettings.json** to avoid any startup errors.
- Feel free to share your issues on [ProtonNet Discussions](https://discussions.protonnetserver.com) for support, or contact me via email at changx.develop@gmail.com.

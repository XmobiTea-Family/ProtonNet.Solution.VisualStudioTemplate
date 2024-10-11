ARG SERVER="__Server__"
ARG SERVER_TYPE="__ServerType__"
ARG PROTON_NET_VERSION="__ProtonNetVersion__"
ARG TARGET_RUNTIME="__TargetFramework__"

# Default port, you can edit with your port in your profile, it should like `StartupSettings.json` file.
ARG HTTP_PORT="22202"
ARG HTTPS_PORT="20802"

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-sdk

ARG SERVER TARGET_RUNTIME

# Set working directory
WORKDIR /src

# Copy source code into the container
COPY ./${SERVER}/${SERVER} .

# Build the project in Release mode and publish it to the /app/publish folder
RUN dotnet publish -c Release --os linux -f ${TARGET_RUNTIME} -o ./app/publish

# Base image
FROM xmobitea/protonnetcontrol:${PROTON_NET_VERSION} AS final

ARG SERVER SERVER_TYPE
ARG HTTP_PORT HTTPS_PORT

# # Update package lists and install dependencies
# RUN apt-get update && apt-get install -y \
#     libicu-dev \
#     libssl-dev \
#     libstdc++6 \
#     && rm -rf /var/lib/apt/lists/*

WORKDIR /protonnetcontrol

COPY --from=build-sdk /src/app/publish ./applications/${SERVER}

RUN mkdir -p ./applications/${SERVER}/wwwroot
RUN mkdir -p ./applications/${SERVER}/web

COPY ./${SERVER}/${SERVER}/wwwroot ./applications/${SERVER}/wwwroot
COPY ./${SERVER}/${SERVER}/web ./applications/${SERVER}/web

RUN chmod +x ./applications/${SERVER}/wwwroot
RUN chmod +x ./applications/${SERVER}/web

# Create ProtonNetServerSettings.json
RUN sed -i "s|__dockerServer__|${SERVER}|g" ./ProtonNetServerSettings.json && \
    sed -i "s|__dockerServerType__|${SERVER_TYPE}|g" ./ProtonNetServerSettings.json

RUN echo "#!/bin/bash\n\n./applications/${SERVER}/__service/docker-service.sh" > ./docker-service.sh
RUN chmod +x ./docker-service.sh

RUN ./control.sh install ${SERVER}

EXPOSE ${HTTP_PORT} ${HTTPS_PORT}

# # Set the entry point to run the script
ENTRYPOINT ["./docker-service.sh"]

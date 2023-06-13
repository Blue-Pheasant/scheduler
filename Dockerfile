# Stage 1: Build the React.js frontend
FROM node:18.140-alpine as build

WORKDIR /app/ClientApp

# Copy package.json and package-lock.json
COPY ClientApp/package*.json ./

# Install dependencies
RUN npm ci

# Copy the rest of the frontend source code
COPY ClientApp .

# Build the frontend
RUN npm run build

# Stage 2: Build the .NET backend
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS publish

WORKDIR /src

# Copy the .NET project file
COPY MyProject.csproj .

# Restore dependencies
RUN dotnet restore

# Install EF packages
RUN dotnet tool install --global dotnet-ef

# Copy the rest of the backend source code
COPY . .

# Run database migrations
RUN dotnet ef database update --project scheduler.csproj --no-build --context YourDbContext

# Publish the backend
RUN dotnet publish -c Release -o /app

# Stage 3: Create the final image
FROM mcr.microsoft.com/dotnet/aspnet:5.0

WORKDIR /app

# Copy the published .NET backend
COPY --from=publish /app .

# Set environment variables (replace with your own values if needed)
ENV ConnectionStrings__DefaultConnection="Server=database;Database=MyDatabase;User=sa;Password=thisisasecret;"

# Expose the desired port (replace with your own port if needed)
EXPOSE 80

# Start the .NET application
ENTRYPOINT ["dotnet", "scheduler.dll"]

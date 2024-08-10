# Phone-Directory

PostgreSQL Database SQL Kodları

CREATE TABLE Users (
    Id SERIAL PRIMARY KEY,
    Username VARCHAR(100) UNIQUE NOT NULL,
    PasswordHash BYTEA NOT NULL,
    PasswordSalt BYTEA NOT NULL,
    FirstName VARCHAR(100) NOT NULL,
    LastName VARCHAR(100),
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE Directory (
    Id SERIAL PRIMARY KEY,
    FirstName VARCHAR(100) NOT NULL,
    LastName VARCHAR(100),
    PhoneNumber VARCHAR(25) NOT NULL,
    Address TEXT,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UserId INT REFERENCES Users(Id) ON DELETE CASCADE
);

# AutoMapper
dotnet add package AutoMapper --version 13.0.1

# Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 8.0.7

# Microsoft.Extensions.Configuration.Abstractions
dotnet add package Microsoft.Extensions.Configuration.Abstractions --version 8.0.0

# Microsoft.AspNetCore.Components.WebAssembly
dotnet add package Microsoft.AspNetCore.Components.WebAssembly --version 8.0.3

# Microsoft.AspNetCore.Components.WebAssembly.DevServer
dotnet add package Microsoft.AspNetCore.Components.WebAssembly.DevServer --version 8.0.3

# Dapper
dotnet add package Dapper --version 2.1.35

# Npgsql
dotnet add package Npgsql --version 8.0.3

# Microsoft.AspNetCore.Components.WebAssembly.Server
dotnet add package Microsoft.AspNetCore.Components.WebAssembly.Server --version 8.0.7

# Swashbuckle.AspNetCore
dotnet add package Swashbuckle.AspNetCore --version 6.4.0

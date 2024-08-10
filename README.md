# Phone-Directory

PostgreSQL Database First Yaklaşımıyla çalışmaktadır.

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

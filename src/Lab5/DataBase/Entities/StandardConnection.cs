namespace DataBase.Entities;

public record StandardConnection() : Connection("localhost",
    "5432",
    "cashmachine",
    "postgres",
    "postgres");
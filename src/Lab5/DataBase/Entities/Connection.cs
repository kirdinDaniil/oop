namespace DataBase.Entities;

public abstract record Connection(
    string Host,
    string Port,
    string Db,
    string Username,
    string Password);
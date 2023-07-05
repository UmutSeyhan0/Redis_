using StackExchange.Redis;
using System;

public class Redis_
{
    private ConnectionMultiplexer redis;

    public Redis_(string connectionString)
    {
        redis = ConnectionMultiplexer.Connect(connectionString);
    }

    public void AddData(string key, string value)
    {
        var db = redis.GetDatabase();
        db.StringSet(key, value);
        Console.WriteLine("Veri başarıyla eklendi.");
    }

    public void RemoveData(string key)
    {
        var db = redis.GetDatabase();
        db.KeyDelete(key);
        Console.WriteLine("Veri başarıyla silindi.");
    }

    public string GetData(string key)
    {
        var db = redis.GetDatabase();
        string value = db.StringGet(key);
        return value;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Redis bağlantı dizesini belirtin
        string connectionString = "your_redis_connection_string";

        // RedisExample sınıfını oluşturun
        Redis_ redisExample = new Redis_(connectionString);

        // Veri ekleme örneği
        redisExample.AddData("mykey", "myvalue");

        // Veri alma örneği
        string value = redisExample.GetData("mykey");
        Console.WriteLine($"Getirilen veri: {value}");

        // Veri silme örneği
        redisExample.RemoveData("mykey");

        // Veri tekrar alma örneği (silindiği için null olmalı)
        value = redisExample.GetData("mykey");
        Console.WriteLine($"Getirilen veri: {value}");

        Console.ReadLine();
    }
}


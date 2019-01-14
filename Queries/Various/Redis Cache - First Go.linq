<Query Kind="Program">
  <NuGetReference>StackExchange.Redis</NuGetReference>
  <Namespace>StackExchange.Redis</Namespace>
</Query>

void Main()
{
    ConnectionMultiplexer conn = 
        ConnectionMultiplexer.Connect("127.0.0.1:6379");
    //    ConnectionMultiplexer.Connect("sfa-redis-dev.redis.cache.windows.net,abortConnect=false,ssl=true,password=T+j/JWDfL0O8FtdWGC8PY/UU2FRzRgoSGWSO+1bBxHE=");
    
    
    
    var db = conn.GetDatabase();
    
    //db.StringSet("Key1","Deven");
    
    db.StringGet("key1").Log();
    conn.GetStatus().Log();
}

// Define other methods and classes here
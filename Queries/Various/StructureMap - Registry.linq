<Query Kind="Program">
  <NuGetReference Version="3.1.6.186">structuremap</NuGetReference>
  <Namespace>StructureMap</Namespace>
  <Namespace>StructureMap.Configuration.DSL</Namespace>
</Query>




void Main()
{
    var c = new Container(x => x.AddRegistry(new LoggerRegistry()));

    c.Configure(x =>
    {
        var l = c.GetInstance<ILogger>();
        l.GetName().Dump("Logger dump!");
        var r = c.GetInstance<PrinterRegistry>();
        x.AddRegistry(r);
    });
    
    c.GetInstance<IPrinter>().Print("Hello world");
    
    
}

interface IPrinter
{
    void Print(string message);
}

class Printer : IPrinter
{
    ILogger _logger;
    public Printer(ILogger log)
    {
        _logger = log;
    }
    public void Print(string message)
    {
        _logger.GetName().Dump("Printer dump");
        message.Dump("Printer dump");
    }
}

class PrinterRegistry : Registry
{
    public PrinterRegistry(ILogger logger)
    {
        logger.GetName().Dump("Ctor");
        For<IPrinter>().Use<Printer>();
    }
}

interface ILogger
{
    string GetName();
}

class Logger: ILogger
{
    public string GetName() => "Deven";
}

class LoggerRegistry : Registry
{
    public LoggerRegistry()
    {
        For<ILogger>().Use<Logger>();
    }
}
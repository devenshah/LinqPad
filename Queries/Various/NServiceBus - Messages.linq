<Query Kind="Program">
  <NuGetReference>NServiceBus</NuGetReference>
  <NuGetReference>NServiceBus.Newtonsoft.Json</NuGetReference>
  <Namespace>NServiceBus</Namespace>
  <Namespace>NServiceBus.Logging</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>


static async Task Main()
{
    var clientUI = "ClientUI";
    
    var outputFolder = @"C:\temp\nservicebus";
    
    var endpointConfiguration = new EndpointConfiguration(clientUI);
    
    endpointConfiguration.SetDiagnosticsPath(outputFolder);
    endpointConfiguration.UseSerialization<NewtonsoftSerializer>(); //Requires package NServiceBus.Newtonsoft.Json
    
    
    var transport = endpointConfiguration.UseTransport<LearningTransport>();
    transport.StorageDirectory(outputFolder);

    var defaultFactory = LogManager.Use<DefaultFactory>();
    defaultFactory.Level(LogLevel.Info);
    defaultFactory.Directory(outputFolder);

    var endpointInstance = 
        await Endpoint.Start(endpointConfiguration).ConfigureAwait(false);

    await MyProgram.RunLoop(endpointInstance).ConfigureAwait(false);

    await endpointInstance.Stop()
        .ConfigureAwait(false);
}

class MyProgram
{
    static ILog log = LogManager.GetLogger<MyProgram>();

    public static async Task RunLoop(IEndpointInstance endpointInstance)
    {
        while (true)
        {
            log.Info("Press 'P' to place an order, or 'Q' to quit.");
            var key = Util.ReadLine().ToLower();

            switch (key)
            {
                case "p":
                    // Send the command to the local endpoint
                    await endpointInstance.SendLocal(new PrintProductDetails())
                        .ConfigureAwait(false);
                    break;
                    
                case "i":
                    // Send the command to the local endpoint
                    log.Info($"Incrementing quantity, current value = {QuantityHandler.Quantity}");
                    await endpointInstance.SendLocal(new IncrementQuantity())
                        .ConfigureAwait(false);
                    break;
                    
                case "d":
                    // Send the command to the local endpoint
                    log.Info($"Decrementing quantity, current value = {QuantityHandler.Quantity}");
                    await endpointInstance.SendLocal(new DecrementQuantity())
                        .ConfigureAwait(false);
                    break;
                case "q":
                    return;

                default:
                    // Instantiate the command
                    var command = new SetProduct(key);

                    // Send the command to the local endpoint
                    log.Info($"Sending SetProduct command, OrderId = {command.ProductName}");
                    await endpointInstance.SendLocal(command)
                        .ConfigureAwait(false);

                    break;
            }
        }
    }
}

public static class Product
{
    public static string Name { get; set; }
    public static int Quantity { get; set; }
}

public class SetProduct : NServiceBus.ICommand
{
    public SetProduct(string productName)
    {
        ProductName = productName;
    }
    public string ProductName { get; set; } = "";
}

public class SetProductHandler : IHandleMessages<SetProduct>
{    
    static ILog log = LogManager.GetLogger<SetProductHandler>();
    
    public Task Handle(SetProduct message, IMessageHandlerContext context)
    {
        Product.Name = message.ProductName;
        Product.Quantity = 0;
        log.Warn($"New product name: {message.ProductName}");
        return Task.CompletedTask;
    }
}

public class PrintProductDetails : NServiceBus.ICommand {}

public class PrintProductDetailsHandler : IHandleMessages<PrintProductDetails>
{
    static ILog log = LogManager.GetLogger<PrintProductDetailsHandler>();

    public Task Handle(PrintProductDetails message, IMessageHandlerContext context)
    {
        if (string.IsNullOrWhiteSpace(Product.Name))
            log.Error("Product not set");
        else
            log.Warn($"Product name: {Product.Name}, Quantity: {Product.Quantity}");
        return Task.CompletedTask;
    }
}

public class IncrementQuantity : NServiceBus.ICommand {}

public class DecrementQuantity : NServiceBus.ICommand {}
//Example of Multiple command handler
public class QuantityHandler : IHandleMessages<IncrementQuantity>, IHandleMessages<DecrementQuantity>
{
    static ILog log = LogManager.GetLogger<QuantityHandler>();
    public static int Quantity = 0;
    public Task Handle(IncrementQuantity message, IMessageHandlerContext context)
    {
        log.Warn($"Quantity incremented to {++Product.Quantity}");
        return Task.CompletedTask;
    }

    public Task Handle(DecrementQuantity message, IMessageHandlerContext context)
    {
        log.Warn($"Quantity decremented to {--Product.Quantity}");
        return Task.CompletedTask;
    }
}


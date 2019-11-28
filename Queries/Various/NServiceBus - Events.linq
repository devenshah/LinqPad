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
                    await endpointInstance.SendLocal(new PlaceOrder(4))
                        .ConfigureAwait(false);
                    break;
                    
                case "q":
                    return;

                default:
                    log.Error("Invalid selection");
                    log.Error("Press 'P' to place an order, or 'Q' to quit.");
                    break;
            }
        }
    }
}

public class PlaceOrder : NServiceBus.ICommand 
{
    public PlaceOrder(int orderId) { OrderId = orderId; }
    public int OrderId { get; set; }
}

public class OrderPlaced : NServiceBus.IEvent
{
    public OrderPlaced(int orderId) { OrderId = orderId; }
    public int OrderId { get; set; }
}

public class PlaceOrderHandler : IHandleMessages<PlaceOrder>
{    
    static ILog log = LogManager.GetLogger<PlaceOrderHandler>();
    
    public Task Handle(PlaceOrder message, IMessageHandlerContext context)
    {
        log.Warn($"New order placed");
        return context.Publish(new OrderPlaced(message.OrderId));
    }
}

public class PaymentHandler : IHandleMessages<OrderPlaced>
{
    static ILog log = LogManager.GetLogger<PaymentHandler>();

    public Task Handle(OrderPlaced message, IMessageHandlerContext context)
    {
        log.Info($"Received OrderPlaced, OrderId = {message.OrderId} - Charging credit card...");

        return Task.CompletedTask;
    }
}


public class BillingHandler : IHandleMessages<OrderPlaced>
{
    static ILog log = LogManager.GetLogger<BillingHandler>();

    public Task Handle(OrderPlaced message, IMessageHandlerContext context)
    {
        log.Info($"Received OrderPlaced, OrderId = {message.OrderId} - Generating invoice...");

        return Task.CompletedTask;
    }
}



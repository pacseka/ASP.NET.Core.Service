namespace ASP.NET.Core.Service.RabbitMQBus.CommandBus
{
    public interface IIntegrationCommandHandler
    {
        void Handle(IntegrationCommand command);
    }

    public interface IIntegrationCommandHandler<T> : IIntegrationCommandHandler
    {
        void Handle(IntegrationCommand<T> command);
    }
}

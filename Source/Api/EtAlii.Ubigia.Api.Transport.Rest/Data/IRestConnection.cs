namespace EtAlii.Ubigia.Api.Transport.Rest
{
    public interface IRestConnection : IConnection
    {
        IRestInfrastructureClient Client { get; }
        IAddressFactory AddressFactory { get; }
    }
}

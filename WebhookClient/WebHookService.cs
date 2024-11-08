internal interface IWebHookService
{
    void Subscribe(Subscription subscription);
    Task PublishMessage(string topic, object message);
}
internal class WebHookService : IWebHookService
{
    List<Subscription> _subscriptions = new();
    HttpClient _httpClient = new();

    public async Task PublishMessage(string topic, object message)
    {
        var _suscriptions = _subscriptions.Where(s => s.Topic == topic);

        foreach (var webhook in _subscriptions)
        {
            await _httpClient.PostAsJsonAsync(webhook.Callback, message);
        }
    }

    public void Subscribe(Subscription subscription)
    {
        _subscriptions.Add(subscription);
    }
}

public record Subscription(string Topic, string Callback);
public record PublishRequest(string Topic, object Message);

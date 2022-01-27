using HelloMassTransit.Events;
using MassTransit;

namespace HelloMassTransit.Consumers
{
    internal class MessageConsumer : IConsumer<TestEvent>
    {
        private readonly ILogger<MessageConsumer> _logger;

        public MessageConsumer(ILogger<MessageConsumer> logger) 
            => _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        public async Task Consume(ConsumeContext<TestEvent> context)
        {
            _logger.LogInformation($"Received value: {context.Message.Text}");

            await Task.CompletedTask;
        }
    }
}

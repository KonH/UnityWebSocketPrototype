using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace Server {
	public sealed class ChatHub : Hub {
		ILogger _logger;

		public ChatHub(ILogger<ChatHub> logger) {
			_logger = logger;
		}

		public async Task Send(string message) {
			_logger.LogInformation($"Send: '{message}'");
			await Clients.All.SendAsync(nameof(Send), message);
		}
	}
}
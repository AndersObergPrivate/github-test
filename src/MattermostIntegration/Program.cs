using System.Text;
using System.Text.Json;

namespace MattermostIntegration;

class Program
{
    static async Task Main(string[] args)
    {
        // Get webhook URL from environment variable or command line argument
        string? webhookUrl = Environment.GetEnvironmentVariable("MATTERMOST_WEBHOOK_URL");
        
        if (args.Length > 0)
        {
            webhookUrl = args[0];
        }

        if (string.IsNullOrEmpty(webhookUrl))
        {
            Console.WriteLine("Usage: MattermostIntegration <webhook-url>");
            Console.WriteLine("Or set MATTERMOST_WEBHOOK_URL environment variable");
            Console.WriteLine();
            Console.WriteLine("Example:");
            Console.WriteLine("  MattermostIntegration https://your-mattermost-server.com/hooks/xxx-generatedkey-xxx");
            return;
        }

        string message = args.Length > 1 ? string.Join(" ", args[1..]) : "Hello from Mattermost Integration!";

        await SendMattermostMessage(webhookUrl, message);
    }

    static async Task SendMattermostMessage(string webhookUrl, string message)
    {
        try
        {
            using var httpClient = new HttpClient();
            
            var payload = new
            {
                text = message,
                username = "Integration Bot",
                icon_emoji = ":robot_face:"
            };

            var json = JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            Console.WriteLine($"Sending message to Mattermost: {message}");
            var response = await httpClient.PostAsync(webhookUrl, content);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("✓ Message sent successfully!");
            }
            else
            {
                Console.WriteLine($"✗ Failed to send message. Status: {response.StatusCode}");
                var responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Response: {responseBody}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"✗ Error sending message: {ex.Message}");
        }
    }
}

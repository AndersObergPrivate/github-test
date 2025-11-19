# Mattermost Integration

A simple C# console application for sending messages to Mattermost via incoming webhooks.

## Features

- Send messages to Mattermost channels using incoming webhooks
- Support for custom messages
- Environment variable or command-line configuration
- Simple and lightweight implementation

## Prerequisites

- .NET 10.0 SDK or later
- A Mattermost server with incoming webhook configured

## Setting up Mattermost Incoming Webhook

1. Log in to your Mattermost server
2. Go to **Main Menu** > **Integrations** > **Incoming Webhooks**
3. Click **Add Incoming Webhook**
4. Select the channel where you want to post messages
5. Provide a display name and description
6. Click **Save**
7. Copy the webhook URL (it will look like: `https://your-mattermost-server.com/hooks/xxx-generatedkey-xxx`)

## Installation

Clone this repository:
```bash
git clone https://github.com/AndersObergPrivate/github-test.git
cd github-test
```

## Usage

### Build the application

```bash
cd src/MattermostIntegration
dotnet build
```

### Run the application

#### Option 1: Using command-line arguments

```bash
dotnet run -- "https://your-mattermost-server.com/hooks/xxx-generatedkey-xxx" "Your message here"
```

#### Option 2: Using environment variable

```bash
export MATTERMOST_WEBHOOK_URL="https://your-mattermost-server.com/hooks/xxx-generatedkey-xxx"
dotnet run -- "Your message here"
```

## Example

```bash
cd src/MattermostIntegration
dotnet run -- "https://mattermost.example.com/hooks/abc123" "Hello from the integration!"
```

Output:
```
Sending message to Mattermost: Hello from the integration!
✓ Message sent successfully!
```

## Project Structure

```
.
├── README.md                          # This file
└── src/
    └── MattermostIntegration/
        ├── MattermostIntegration.csproj  # Project file
        └── Program.cs                     # Main application code
```

## Security Notes

- **Never commit your webhook URL to version control**
- Use environment variables or secure configuration management
- The `.gitignore` file includes `*.env` to help prevent accidental commits
- Webhook URLs should be treated as secrets

## Contributing

This is a test repository for demonstrating Mattermost integration capabilities.

## License

This project is provided as-is for testing and educational purposes.

# Dockerized C# Email Sender

This project demonstrates how to send emails from a Docker container using C#. It includes a Dockerfile, a Docker Compose configuration, and a .NET Core console application that reads email settings from appsettings.json.
# Prerequisites

Docker and Docker-Compose

# Getting Started

-  Clone the Repository:

-  Configure Email Settings:
-  Open the appsettings.json file and update the following settings:
```
SmtpSettings.Host: SMTP server hostname (e.g., "smtp.example.com").
SmtpSettings.Port: SMTP server port (e.g., 587).
SmtpSettings.EnableSsl: Set to true if SSL/TLS is required.
SmtpSettings.Username: Your SMTP username.
SmtpSettings.Password: Your SMTP password.
EmailSettings.ToAddress: Recipient email address.
EmailSettings.Subject: Email subject.
EmailSettings.Body: Email body.
```

-  Run the Docker Container:

`docker-compose up`

-  Check the Console Output:

If everything is configured correctly, you’ll see a message indicating that the email was sent successfully.

# Customization

Feel free to add a pull request with any new features you see as being useful! Perhaps like using different ports, etc.

# Troubleshooting

If you encounter any issues, check the console output for error messages.
Ensure that your SMTP server settings are accurate.

# License

This project is licensed under the MIT License. Feel free to use, modify, and distribute it as needed.
# Rosca-Net

Rosca-Net is a .NET Core implementation of a Rotating Savings and Credit Association (ROSCA). A ROSCA is a group of people who agree to meet for a defined period of time and contribute a fixed amount of money to a common fund. Each member takes a turn receiving the total amount of the fund as a lump sum. The idea behind ROSCAs is to provide members with access to credit and savings that they might not have been able to access otherwise.

Rosca-Net is designed to be a flexible and scalable implementation of a ROSCA. It provides a set of APIs that allow users to create, join and manage a ROSCA, and to make contributions and receive payouts. Rosca-Net also includes a set of configurable parameters that allow users to customize their ROSCA experience to meet their specific needs.
## Getting Started

To use Rosca-Net, you will need to have the .NET Core SDK installed on your system. You can download the SDK from the official .NET website: https://dotnet.microsoft.com/download.
Once you have the .NET Core SDK installed, you can clone the Rosca-Net repository from GitHub:

```
git clone https://github.com/guimar86/rosca-net.git
```
After cloning the repository, navigate to the root directory of the project and run the following command to build the solution:
```
dotnet build
```

You can then run the solution using the following command:
```
dotnet run --project src/RoscaNet.Api/RoscaNet.Api.csproj
```

This will start the Rosca-Net API server, which you can access using a web browser or a tool like cURL.

## API Reference

The Rosca-Net API provides a set of endpoints that allow users to create, join and manage a ROSCA, and to make contributions and receive payouts. The API endpoints are documented using Swagger, which you can access by navigating to the following URL:
```
https://localhost:5001/swagger/index.html
```
This will open the Swagger UI, which provides a user-friendly interface for exploring the API endpoints and making requests.

## Configuration

Rosca-Net includes a set of configurable parameters that allow users to customize their ROSCA experience to meet their specific needs. The configuration parameters are defined in the appsettings.json file, which is located in the root directory of the project.

The following is an example of the default configuration:

```json
{
  "RoscaConfig": {
    "ContributionAmount": 100,
    "PayoutStrategy": "Equal",
    "PayoutPeriod": 1,
    "NumberOfParticipants": 5
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  }
}
```
The RoscaConfig section defines the parameters for the ROSCA, including the contribution amount, the payout strategy, the payout period, and the number of participants. You can modify these parameters to customize your ROSCA experience.

### Contributing

Contributions to Rosca-Net are welcome and encouraged! If you would like to contribute, please follow these steps:

    1. Fork the Rosca-Net repository.
    2. Create a new branch for your changes.
    3. Make your changes and commit them to your branch.
    4. Push your branch to your forked repository.
    5. Submit a pull request to the Rosca-Net repository.

### License

Rosca-Net is released under the MIT License. See the LICENSE file for details.

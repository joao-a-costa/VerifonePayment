# Verifone Payment Test Application

This application is a test client for interacting with the Verifone Payment SDK. It allows users to execute various payment-related actions interactively.

## Features

- Communicate with Payment SDK
- Login with credentials
- Start a session
- Add merchandise
- Process payment transactions
- End a session

## Prerequisites

- .NET Framework 4.8
- Verifone Payment SDK
- Visual Studio or any other C# IDE

## Getting Started

1. **Clone the repository**

    ```sh
    git clone https://github.com/your-username/VerifonePayment.git
    ```

2. **Navigate to the project directory**

    ```sh
    cd VerifonePayment
    ```

3. **Open the project in Visual Studio**

    - Open `VerifonePayment.sln` in Visual Studio.

4. **Build the project**

    - In Visual Studio, click on `Build` -> `Build Solution`.

5. **Run the application**

    - In Visual Studio, click on `Debug` -> `Start Without Debugging` or press `Ctrl+F5`.

## Event Handling

The application subscribes to various events from the Verifone Payment SDK and handles them accordingly. The events include:

- **StatusEventOccurred**
- **TransactionEventOccurred**
- **DeviceVitalsInformationEventOccurred**
- **BasketEventOccurred**
- **NotificationEventOccurred**
- **PaymentCompletedEventOccurred**

Each event logs the status, type, and message to the console.

## Contributing

Contributions are welcome! Please fork the repository and submit a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Contact

For any questions or issues, please open an issue on GitHub or contact the maintainer.

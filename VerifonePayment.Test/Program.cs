using System;
using System.Threading;

namespace VerifonePayment.Test
{
    internal class Program
    {
        #region "Events"

        private static ManualResetEvent statusEventReceived = new ManualResetEvent(false);
        private static ManualResetEvent loginEventReceived = new ManualResetEvent(false);
        private static ManualResetEvent startSessionStatusEventReceived = new ManualResetEvent(false);
        private static ManualResetEvent basketEventStatusEventReceived = new ManualResetEvent(false);
        private static ManualResetEvent paymentCompletedEventReceived = new ManualResetEvent(false);

        #endregion

        static void Main(string[] args)
        {
            try
            {
                var verifonePayment = new Lib.VerifonePayment("192.168.40.173");

                // Subscribe to the event
                verifonePayment.StatusEventOccurred += VerifonePayment_StatusEventOccurred;
                verifonePayment.TransactionEventOccurred += VerifonePayment_TransactionEventOccurred;
                verifonePayment.DeviceVitalsInformationEventOccurred += VerifonePayment_DeviceVitalsInformationEventOccurred;
                verifonePayment.BasketEventOccurred += VerifonePayment_BasketEventOccurred;
                verifonePayment.NotificationEventOccurred += VerifonePayment_NotificationEventOccurred;
                verifonePayment.PaymentCompletedEventOccurred += VerifonePayment_PaymentCompletedEventOccurred;
                verifonePayment.CommerceEventOccurred += VerifonePayment_CommerceEventOccurred;

                bool running = true;

                while (running)
                {
                    Console.WriteLine("Choose an action:");
                    Console.WriteLine("1. CommunicateWithPaymentSDK");
                    Console.WriteLine("2. LoginWithCredentials");
                    Console.WriteLine("3. StartSession");
                    Console.WriteLine("4. AddMerchandise");
                    Console.WriteLine("5. PaymentTransaction");
                    Console.WriteLine("6. RemoveMerchandise");
                    Console.WriteLine("7. EndSession");
                    Console.WriteLine("8. TearDown");
                    Console.WriteLine("9. Exit");

                    switch (Console.ReadLine())
                    {
                        case "1":
                            verifonePayment.CommunicateWithPaymentSDK();
                            WaitForEvent(statusEventReceived, "CommunicateWithPaymentSDK");
                            break;

                        case "2":
                            verifonePayment.LoginWithCredentials();
                            WaitForEvent(loginEventReceived, "LoginWithCredentials");
                            break;

                        case "3":
                            verifonePayment.StartSession(Guid.NewGuid().ToString());
                            WaitForEvent(startSessionStatusEventReceived, "StartSession");
                            break;

                        case "4":
                            verifonePayment.AddMerchandise();
                            WaitForEvent(basketEventStatusEventReceived, "AddMerchandise");
                            break;

                        case "5":
                            verifonePayment.PaymentTransaction((long)(new Random().NextDouble() * 99) + 1);
                            WaitForEvent(paymentCompletedEventReceived, "PaymentTransaction");
                            break;

                        case "6":
                            verifonePayment.RemoveMerchandise();
                            WaitForEvent(basketEventStatusEventReceived, "RemoveMerchandise");
                            break;

                        case "7":
                            verifonePayment.EndSession();
                            WaitForEvent(statusEventReceived, "EndSession");
                            break;
                        case "8":
                            verifonePayment.TearDown();
                            WaitForEvent(statusEventReceived, "TearDown");
                            break;

                        case "9":
                            running = false;
                            break;

                        default:
                            Console.WriteLine("Invalid choice, please try again.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }

        #region "Private Methods"

        /// <summary>
        /// Event wait handler
        /// </summary>
        /// <param name="eventHandle">The event handle</param>
        /// <param name="actionName">The action name</param>
        private static void WaitForEvent(ManualResetEvent eventHandle, string actionName)
        {
            Console.WriteLine($"{actionName}: Waiting for status event...");
            eventHandle.WaitOne();
            eventHandle.Reset();
        }

        /// <summary>
        /// Event handler for DeviceVitalsInformationEventOccurred
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event arguments</param>
        private static void VerifonePayment_DeviceVitalsInformationEventOccurred(object sender, Lib.Models.PaymentEventArgs e)
        {
            Console.WriteLine($"   - Status: {e.Status}, Type: {e.Type}, Message: {e.Message}");
            statusEventReceived.Set();
        }

        /// <summary>
        /// Event handler for TransactionEventOccurred
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event arguments</param>
        private static void VerifonePayment_TransactionEventOccurred(object sender, Lib.Models.PaymentEventArgs e)
        {
            Console.WriteLine($"   - Status: {e.Status}, Type: {e.Type}, Message: {e.Message}");

            if (e.Type == Lib.Enums.EventType.SESSION_STARTED && e.Status == "0")
            {
                startSessionStatusEventReceived.Set();
            }
            if (e.Type == Lib.Enums.EventType.SESSION_ENDED && e.Status == "0")
            {
                statusEventReceived.Set();
            }
            if (e.Type == Lib.Enums.EventType.LOGIN_COMPLETED)
            {
                loginEventReceived.Set();

                if (e.Status == "-20")
                    statusEventReceived.Set();
            }
        }

        /// <summary>
        /// Event handler for StatusEventOccurred
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event arguments</param>
        private static void VerifonePayment_StatusEventOccurred(object sender, Lib.Models.PaymentEventArgs e)
        {
            Console.WriteLine($"   - Status: {e.Status}, Type: {e.Type}, Message: {e.Message}");

            statusEventReceived.Set();
        }

        /// <summary>
        /// Event handler for BasketEventOccurred
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event arguments</param>
        private static void VerifonePayment_BasketEventOccurred(object sender, Lib.Models.PaymentEventArgs e)
        {
            Console.WriteLine($"   - Status: {e.Status}, Type: {e.Type}, Message: {e.Message}");
            basketEventStatusEventReceived.Set();
        }

        /// <summary>
        /// Event handler for NotificationEventOccurred
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event arguments</param>
        private static void VerifonePayment_NotificationEventOccurred(object sender, Lib.Models.PaymentEventArgs e)
        {
            Console.WriteLine($"   - Status: {e.Status}, Type: {e.Type}, Message: {e.Message}");
        }

        /// <summary>
        /// Event handler for PaymentCompletedEventOccurred
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event arguments</param>
        private static void VerifonePayment_PaymentCompletedEventOccurred(object sender, Lib.Models.PaymentEventArgs e)
        {
            Console.WriteLine($"   - Status: {e.Status}, Type: {e.Type}, Message: {e.Message}");

            if (e.Type == Lib.Enums.EventType.NOTIFICATION_EVENT && e.Message == "Transaction Completed")
                paymentCompletedEventReceived.Set();
            if (e.Type == Lib.Enums.EventType.TRANSACTION_PAYMENT_COMPLETED)
                paymentCompletedEventReceived.Set();
        }

        /// <summary>
        /// Event handler for CommerceEventOccurred
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event arguments</param>
        private static void VerifonePayment_CommerceEventOccurred(object sender, Lib.Models.PaymentEventArgs e)
        {
            Console.WriteLine($"   - Status: {e.Status}, Type: {e.Type}, Message: {e.Message}");

            if (e.Type == Lib.Enums.EventType.STATUS_ERROR && e.Status == "-20")
                startSessionStatusEventReceived.Set();
        }

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using VerifonePayment.Lib.Models;
using VerifoneSdk;
using static VerifonePayment.Lib.Enums;

namespace VerifonePayment.Lib
{
    public class VerifonePayment
    {
        #region "Constants"

        #region "Verifone"

        private const string _DEVICE_ADDRESS_KEY = "DEVICE_ADDRESS_KEY";
        private const string _DEVICE_CONNECTION_TYPE_KEY = "DEVICE_CONNECTION_TYPE_KEY";
        private const string _DEVICE_CONNECTION_TYPE_KEY_VALUE = "tcpip";

        #endregion

        private const string _defaultLogFile = "psdk.log";
        private const string _TextIpAddressEmpty = "Ip address empty";

        #endregion

        #region "Members"

        private PaymentSdk payment_sdk_ = new PaymentSdk();
        private VerifonePaymentListener listener_ = new VerifonePaymentListener();

        #endregion

        #region "Events"

        public event EventHandler<PaymentEventArgs> StatusEventOccurred
        {
            add { listener_.StatusEventOccurred += value; }
            remove { listener_.StatusEventOccurred -= value; }
        }
        public event EventHandler<PaymentEventArgs> TransactionEventOccurred
        {
            add { listener_.TransactionEventOccurred += value; }
            remove { listener_.TransactionEventOccurred -= value; }
        }
        public event EventHandler<PaymentEventArgs> DeviceVitalsInformationEventOccurred
        {
            add { listener_.DeviceVitalsInformationEventOccurred += value; }
            remove { listener_.DeviceVitalsInformationEventOccurred -= value; }
        }
        public event EventHandler<PaymentEventArgs> BasketEventOccurred
        {
            add { listener_.BasketEventOccurred += value; }
            remove { listener_.BasketEventOccurred -= value; }
        }
        public event EventHandler<PaymentEventArgs> NotificationEventOccurred
        {
            add { listener_.NotificationEventOccurred += value; }
            remove { listener_.NotificationEventOccurred -= value; }
        }
        public event EventHandler<PaymentEventArgs> PaymentCompletedEventOccurred
        {
            add { listener_.PaymentCompletedEventOccurred += value; }
            remove { listener_.PaymentCompletedEventOccurred -= value; }
        }
        public event EventHandler<PaymentEventArgs> CommerceEventOccurred
        {
            add { listener_.CommerceEventOccurred += value; }
            remove { listener_.CommerceEventOccurred -= value; }
        }

        #endregion

        #region "Properties"

        public string LogFile { get; set; }
        public string IpAddress { get; set; }

        #endregion

        #region "Constructor"

        public VerifonePayment(string ipAddress)
        {
            if (string.IsNullOrEmpty(ipAddress))
                throw new ArgumentException(_TextIpAddressEmpty, nameof(ipAddress));

            IpAddress = ipAddress;
            ConfigureLogFile();
        }

        #endregion

        #region "Private Methods"

        /// <summary>
        /// Configure log file.
        /// </summary>
        private void ConfigureLogFile()
        {
            // If 'LogFile' not present then set it to default log file
            if (string.IsNullOrEmpty(LogFile))
            {
                var logFile = Path.Combine(Path.GetTempPath(), _defaultLogFile);

                if (File.Exists(logFile))
                    File.Delete(logFile);

                LogFile = Path.Combine(Path.GetTempPath(), _defaultLogFile);
            }

            PaymentSdk.ConfigureLogFile(LogFile, 2048);
        }

        #endregion

        #region "Public Methods"

        /// <summary>
        /// Communicate with payment SDK.
        /// </summary>
        public void CommunicateWithPaymentSDK()
        {
            var dict = new Dictionary<string, string>
            {
                { _DEVICE_ADDRESS_KEY, IpAddress },
                { _DEVICE_CONNECTION_TYPE_KEY, _DEVICE_CONNECTION_TYPE_KEY_VALUE }
            };

            payment_sdk_.InitializeFromValues(listener_, dict);
        }

        /// <summary>
        /// Login with credentials.
        /// </summary>
        /// <returns>The status of login.</returns>
        public bool LoginWithCredentials()
        {
            var credentials = LoginCredentials.Create();

            credentials.UserId = "username";
            credentials.Password = "password";
            credentials.ShiftNumber = "shift";

            var status = payment_sdk_.TransactionManager.LoginWithCredentials(credentials);

            return status.StatusCode == 0;
        }

        /// <summary>
        /// Start session.
        /// </summary>
        /// <param name="invoiceId">The invoice id.</param>
        /// <returns>The status of session.</returns>
        public bool StartSession(string invoiceId)
        {
            Transaction transaction = Transaction.Create();
            transaction.InvoiceId = invoiceId;
            return payment_sdk_.TransactionManager.StartSession(transaction);
        }

        /// <summary>
        /// End session.
        /// </summary>
        /// <returns>The status of session.</returns>
        public bool EndSession()
        {
            return payment_sdk_.TransactionManager.EndSession();
        }

        /// <summary>
        /// Add merchandise.
        /// </summary>
        public void AddMerchandise()
        {
            Merchandise merchandise = Merchandise.Create();
            var current_amount_totals = payment_sdk_.TransactionManager.BasketManager.CurrentAmountTotals;

            VerifoneSdk.Decimal gratuity = new VerifoneSdk.Decimal(0);
            if (current_amount_totals == null)
            {
                current_amount_totals = AmountTotals.Create(true);
                current_amount_totals.SetWithAmounts(merchandise.ExtendedPrice, merchandise.Tax, gratuity,
                        new VerifoneSdk.Decimal(0), new VerifoneSdk.Decimal(0), new VerifoneSdk.Decimal(0), new VerifoneSdk.Decimal(108));
            }
            else
            {
                current_amount_totals.AddAmounts(merchandise.ExtendedPrice, merchandise.Tax, gratuity,
                        new VerifoneSdk.Decimal(0), new VerifoneSdk.Decimal(0), new VerifoneSdk.Decimal(0), new VerifoneSdk.Decimal(108));
            }

            var merch_list = new List<Merchandise>
            {
                merchandise
            };

            payment_sdk_.TransactionManager.BasketManager.AddMerchandise(merch_list, current_amount_totals);
        }

        /// <summary>
        /// Payment transaction.
        /// </summary>
        /// <param name="total">The total amount.</param>
        public void PaymentTransaction(long total, Enums.PaymentType paymentType = Enums.PaymentType.CREDIT, int scale = 2)
        {
            var payment = Payment.Create();
            payment.RequestedAmounts = payment_sdk_.TransactionManager.BasketManager.CurrentAmountTotals;
            payment.RequestedAmounts.Total = new VerifoneSdk.Decimal(scale, total);
            payment.PaymentType = (VerifoneSdk.PaymentType?)paymentType;

            payment_sdk_.TransactionManager.StartPayment(payment);
        }

        /// <summary>
        /// Tear down.
        /// </summary>
        public void TearDown()
        {
            payment_sdk_.TearDown();
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using VerifonePayment.Lib.Controllers;
using VerifonePayment.Lib.Models;
using VerifoneSdk;

namespace VerifonePayment.Lib
{
    public class VerifonePayment
    {
        #region "Constants"

        #region "Verifone"

        /// <summary>
        /// Constant for device address key.
        /// </summary>
        private const string _DEVICE_ADDRESS_KEY = "DEVICE_ADDRESS_KEY";
        /// <summary>
        /// Constant for device connection type key.
        /// </summary>
        private const string _DEVICE_CONNECTION_TYPE_KEY = "DEVICE_CONNECTION_TYPE_KEY";
        /// <summary>
        /// Constant for device connection type key value.
        /// </summary>
        private const string _DEVICE_CONNECTION_TYPE_KEY_VALUE = "tcpip";

        #endregion

        /// <summary>
        /// Default log file.
        /// </summary>
        private const string _defaultLogFile = "psdk.log";
        /// <summary>
        /// Constant for ip address empty.
        /// </summary>
        private const string _TextIpAddressEmpty = "Ip address empty";

        #endregion

        #region "Members"

        /// <summary>
        /// Payment SDK.
        /// </summary>
        private readonly PaymentSdk payment_sdk_ = new PaymentSdk();
        /// <summary>
        /// Listener.
        /// </summary>
        private readonly VerifonePaymentListener listener_ = new VerifonePaymentListener();

        #endregion

        #region "Events"

        /// <summary>
        /// Event occurred.
        /// </summary>
        public event EventHandler<PaymentEventArgs> StatusEventOccurred
        {
            add { listener_.StatusEventOccurred += value; }
            remove { listener_.StatusEventOccurred -= value; }
        }
        /// <summary>
        /// Transaction event occurred.
        /// </summary>
        public event EventHandler<PaymentEventArgs> TransactionEventOccurred
        {
            add { listener_.TransactionEventOccurred += value; }
            remove { listener_.TransactionEventOccurred -= value; }
        }
        /// <summary>
        /// Device vitals information event occurred.
        /// </summary>
        public event EventHandler<PaymentEventArgs> DeviceVitalsInformationEventOccurred
        {
            add { listener_.DeviceVitalsInformationEventOccurred += value; }
            remove { listener_.DeviceVitalsInformationEventOccurred -= value; }
        }
        /// <summary>
        /// Basket event occurred.
        /// </summary>
        public event EventHandler<PaymentEventArgs> BasketEventOccurred
        {
            add { listener_.BasketEventOccurred += value; }
            remove { listener_.BasketEventOccurred -= value; }
        }
        /// <summary>
        /// Notification event occurred.
        /// </summary>
        public event EventHandler<PaymentEventArgs> NotificationEventOccurred
        {
            add { listener_.NotificationEventOccurred += value; }
            remove { listener_.NotificationEventOccurred -= value; }
        }
        /// <summary>
        /// Payment completed event occurred.
        /// </summary>
        public event EventHandler<PaymentEventArgs> PaymentCompletedEventOccurred
        {
            add { listener_.PaymentCompletedEventOccurred += value; }
            remove { listener_.PaymentCompletedEventOccurred -= value; }
        }
        /// <summary>
        /// Commerce event occurred.
        /// </summary>
        public event EventHandler<PaymentEventArgs> CommerceEventOccurred
        {
            add { listener_.CommerceEventOccurred += value; }
            remove { listener_.CommerceEventOccurred -= value; }
        }

        #endregion

        #region "Properties"

        /// <summary>
        /// Log file.
        /// </summary>
        public string LogFile { get; set; }
        /// <summary>
        /// Ip address.
        /// </summary>
        public string IpAddress { get; set; }
        /// <summary>
        /// Delete log file.
        /// </summary>
        public bool DeleteLogFile { get; set; } = false;

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

                if (DeleteLogFile && File.Exists(logFile))
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
        /// Remove merchandise.
        /// </summary>
        public void RemoveMerchandise()
        {
            var basket_manager = payment_sdk_.TransactionManager.BasketManager;
            var basket = basket_manager.Basket;
            IList<Merchandise> merchandise_list = new List<Merchandise>();
            if (basket != null)
            {
                merchandise_list = basket.Merchandise;
            }
            if (merchandise_list.Count > 0)
            {
                var merchandise = merchandise_list[merchandise_list.Count - 1];
                var amount = merchandise.Amount;
                var amount_totals = basket_manager.CurrentAmountTotals;
                if (amount_totals != null)
                {
                    amount_totals.SubtractAmounts(amount, new VerifoneSdk.Decimal(0), new VerifoneSdk.Decimal(0),
                       new VerifoneSdk.Decimal(0), new VerifoneSdk.Decimal(0), new VerifoneSdk.Decimal(0), amount);
                    var removed = new List<Merchandise>(); removed.Add(merchandise);
                    basket_manager.RemoveMerchandise(removed, amount_totals);
                }
            }
        }

        /// <summary>
        /// Payment transaction.
        /// </summary>
        /// <param name="total">The total amount.</param>
        public void PaymentTransaction(long total, Enums.PaymentType paymentType = Enums.PaymentType.CREDIT, int scale = 2)
        {
            var payment = VerifoneSdk.Payment.Create();
            payment.RequestedAmounts = payment_sdk_.TransactionManager.BasketManager.CurrentAmountTotals;
            payment.RequestedAmounts.Total = new VerifoneSdk.Decimal(scale, total);
            payment.PaymentType = (PaymentType?)paymentType;

            payment_sdk_.TransactionManager.StartPayment(payment);
        }

        /// <summary>
        /// Refund transaction.
        /// </summary>
        /// <param name="payment">The payment to refund.</param>
        public void RefundTransaction(Models.Payment payment)
        {
            var mapper = new RepositoriesMappingProfileController().Configuration.CreateMapper();
            var paymentObject = mapper.Map<VerifoneSdk.Payment>(payment);

            payment_sdk_.TransactionManager.ProcessRefund(paymentObject);
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

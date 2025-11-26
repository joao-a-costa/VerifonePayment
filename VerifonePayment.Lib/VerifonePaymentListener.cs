using System;
using VerifonePayment.Lib.Controllers;
using VerifonePayment.Lib.Models;
using VerifoneSdk;
using static VerifonePayment.Lib.Enums;
using VerifonePayment.Lib.Models;

namespace VerifonePayment.Lib
{
    /// <summary>
    /// Verifone payment listener
    /// </summary>
    public class VerifonePaymentListener : CommerceListener2
    {
        /// <summary>
        /// Event handler for amount adjusted event
        /// </summary>
        public event EventHandler<PaymentEventArgs> AmountAdjustedEventOccurred;
        /// <summary>
        /// Event handler for basket adjusted event
        /// </summary>
        public event EventHandler<PaymentEventArgs> BasketAdjustedEventOccurred;
        /// <summary>
        /// Event handler for basket event
        /// </summary>
        public event EventHandler<PaymentEventArgs> BasketEventOccurred;
        /// <summary>
        /// Card information received event
        /// </summary>
        public event EventHandler<PaymentEventArgs> CardInformationReceivedEventOccurred;
        /// <summary>
        /// Event handler for commerce event
        /// </summary>
        public event EventHandler<PaymentEventArgs> CommerceEventOccurred;
        /// <summary>
        /// Event handler for device management event
        /// </summary>
        public event EventHandler<PaymentEventArgs> DeviceManagementEventOccurred;
        /// <summary>
        /// Event handler for host authorization event
        /// </summary>
        public event EventHandler<PaymentEventArgs> HostAuthorizationEventOccurred;
        /// <summary>
        /// Event handler for host finalize transaction event
        /// </summary>
        public event EventHandler<PaymentEventArgs> HostFinalizeTransactionEventOccurred;
        /// <summary>
        /// Event handler for loyalty received event
        /// </summary>
        public event EventHandler<PaymentEventArgs> LoyaltyReceivedEventOccurred;
        /// <summary>
        /// Event handler for notification event
        /// </summary>
        public event EventHandler<PaymentEventArgs> NotificationEventOccurred;
        /// <summary>
        /// Event handler for payment completed event
        /// </summary>
        public event EventHandler<PaymentEventArgs> PaymentCompletedEventOccurred;
        /// <summary>
        /// Event handler for print event
        /// </summary>
        public event EventHandler<PaymentEventArgs> PrintEventOccurred;
        /// <summary>
        /// Event handler for receipt delivery method event
        /// </summary>
        public event EventHandler<PaymentEventArgs> ReceiptDeliveryMethodEventOccurred;
        /// <summary>
        /// Event handler for reconciliation event
        /// </summary>
        public event EventHandler<PaymentEventArgs> ReconciliationEventOccurred;
        /// <summary>
        /// Event handler for reconciliations list event
        /// </summary>
        public event EventHandler<PaymentEventArgs> ReconciliationsListEventOccurred;
        /// <summary>
        /// Event handler for status event
        /// </summary>
        public event EventHandler<PaymentEventArgs> StatusEventOccurred;
        /// <summary>
        /// Event handler for stored value card event
        /// </summary>
        public event EventHandler<PaymentEventArgs> StoredValueCardEventOccurred;
        /// <summary>
        /// Event handler for transaction event
        /// </summary>
        public event EventHandler<PaymentEventArgs> TransactionEventOccurred;
        /// <summary>
        /// Event handler for transaction query event
        /// </summary>
        public event EventHandler<PaymentEventArgs> TransactionQueryEventOccurred;
        /// <summary>
        /// Event handler for user input event
        /// </summary>
        public event EventHandler<PaymentEventArgs> UserInputEventOccurred;
        /// <summary>
        /// Event handler for device vitals information event
        /// </summary>
        public event EventHandler<PaymentEventArgs> DeviceVitalsInformationEventOccurred;

        #region "Private methods"

        /// <summary>
        /// Raises an event
        /// </summary>
        /// <param name="eventHandler">The event handler</param>
        /// <param name="status">The status</param>
        /// <param name="type">The type</param>
        /// <param name="message">The message</param>
        /// <exception cref="ArgumentException">Thrown when the event type is invalid</exception>
        private void RaiseEvent(EventHandler<PaymentEventArgs> eventHandler, string status, string type, string message, object extraData = null)
        {
            if (!Enum.TryParse(type, out EventType eventType))
                throw new ArgumentException($"Invalid event type: {type}");

            eventHandler?.Invoke(this, new PaymentEventArgs { Status = status, Type = eventType, Message = message, ExtraData = extraData });
        }

        #endregion

        #region "Public methods"

        /// <summary>
        /// Handles the amount adjusted event
        /// </summary>
        /// <param name="sdk_event">The event</param>
        public override void HandleAmountAdjustedEvent(AmountAdjustedEvent sdk_event)
        {
            string type = sdk_event.Type == null ? "(null)" : sdk_event.Type.ToString();
            string status = sdk_event.Status.ToString();
            string message = sdk_event.Message == null ? "(null)" : sdk_event.Message.ToString();
            RaiseEvent(AmountAdjustedEventOccurred, status, type, message);
        }

        /// <summary>
        /// Handles the basket adjusted event
        /// </summary>
        /// <param name="sdk_event">The event</param>
        public override void HandleBasketAdjustedEvent(BasketAdjustedEvent sdk_event)
        {
            string type = sdk_event.Type;
            string status = sdk_event.Status.ToString();
            string message = sdk_event.Message == null ? "(null)" : sdk_event.Message.ToString();
            RaiseEvent(BasketAdjustedEventOccurred, status, type, message);
        }

        /// <summary>
        /// Handles the basket event
        /// </summary>
        /// <param name="sdk_event">The event</param>
        public override void HandleBasketEvent(BasketEvent sdk_event)
        {
            string type = sdk_event.Type == null ? "(null)" : sdk_event.Type.ToString();
            string status = sdk_event.Status.ToString();
            string message = sdk_event.Message == null ? "(null)" : sdk_event.Message.ToString();
            RaiseEvent(BasketEventOccurred, status, type, message);
        }

        /// <summary>
        /// Handles the card information received event
        /// </summary>
        /// <param name="sdk_event">The event</param>
        public override void HandleCardInformationReceivedEvent(CardInformationReceivedEvent sdk_event)
        {
            string type = sdk_event.Type == null ? "(null)" : sdk_event.Type.ToString();
            string status = sdk_event.Status.ToString();
            string message = sdk_event.Message == null ? "(null)" : sdk_event.Message.ToString();
            RaiseEvent(CardInformationReceivedEventOccurred, status, type, message);
        }

        /// <summary>
        /// Handles the commerce event
        /// </summary>
        /// <param name="sdk_event">The event</param>
        public override void HandleCommerceEvent(CommerceEvent sdk_event)
        {
            string type = sdk_event.Type == null ? "(null)" : sdk_event.Type.ToString();
            string status = sdk_event.Status.ToString();
            string message = sdk_event.Message == null ? "(null)" : sdk_event.Message.ToString();
            RaiseEvent(CommerceEventOccurred, status, type, message);
        }

        /// <summary>
        /// Handles the device management event
        /// </summary>
        /// <param name="sdk_event">The event</param>
        public override void HandleDeviceManagementEvent(DeviceManagementEvent sdk_event)
        {
            string type = sdk_event.Type == null ? "(null)" : sdk_event.Type.ToString();
            string status = sdk_event.Status.ToString();
            string message = sdk_event.Message == null ? "(null)" : sdk_event.Message.ToString();
            RaiseEvent(DeviceManagementEventOccurred, status, type, message);
        }

        /// <summary>
        /// Handles the host authorization event
        /// </summary>
        /// <param name="sdk_event">The event</param>
        public override void HandleHostAuthorizationEvent(HostAuthorizationEvent sdk_event)
        {
            string type = sdk_event.Type == null ? "(null)" : sdk_event.Type.ToString();
            string status = sdk_event.Status.ToString();
            string message = sdk_event.Message == null ? "(null)" : sdk_event.Message.ToString();
            RaiseEvent(HostAuthorizationEventOccurred, status, type, message);
        }

        /// <summary>
        /// Handles the host finalize transaction event
        /// </summary>
        /// <param name="sdk_event">The event</param>
        public override void HandleHostFinalizeTransactionEvent(HostFinalizeTransactionEvent sdk_event)
        {
            string type = sdk_event.Type == null ? "(null)" : sdk_event.Type.ToString();
            string status = sdk_event.Status.ToString();
            string message = sdk_event.Message == null ? "(null)" : sdk_event.Message.ToString();
            RaiseEvent(HostFinalizeTransactionEventOccurred, status, type, message);
        }

        /// <summary>
        /// Handles the loyalty received event
        /// </summary>
        /// <param name="sdk_event">The event</param>
        public override void HandleLoyaltyReceivedEvent(LoyaltyReceivedEvent sdk_event)
        {
            string type = sdk_event.Type == null ? "(null)" : sdk_event.Type.ToString();
            string status = sdk_event.Status.ToString();
            string message = sdk_event.Message == null ? "(null)" : sdk_event.Message.ToString();
            RaiseEvent(LoyaltyReceivedEventOccurred, status, type, message);
        }

        /// <summary>
        /// Handles the notification event
        /// </summary>
        /// <param name="sdk_event">The event</param>
        public override void HandleNotificationEvent(NotificationEvent sdk_event)
        {
            string type = sdk_event.Type == null ? "(null)" : sdk_event.Type.ToString();
            string status = sdk_event.Status.ToString();
            string message = sdk_event.Message == null ? "(null)" : sdk_event.Message.ToString();
            RaiseEvent(NotificationEventOccurred, status, type, message);
        }

        /// <summary>
        /// Handles the payment completed event
        /// </summary>
        /// <param name="sdk_event">The event</param>
        public override void HandlePaymentCompletedEvent(PaymentCompletedEvent sdk_event)
        {
            var jsonReceipt = Newtonsoft.Json.JsonConvert.SerializeObject(sdk_event.Receipt);
            var jsonPayment = Newtonsoft.Json.JsonConvert.SerializeObject(sdk_event.Payment);
            string type = sdk_event.Type == null ? "(null)" : sdk_event.Type.ToString();
            string status = sdk_event.Status.ToString();
            string message = sdk_event.Message == null ? "(null)" : sdk_event.Message.ToString();

            var mapper = new RepositoriesMappingProfileController().Configuration.CreateMapper();
            //var receiptObject = mapper.Map<Models.Receipt>(sdk_event.Receipt);
            var paymentObject = mapper.Map<Models.Payment>(sdk_event.Payment);

            RaiseEvent(PaymentCompletedEventOccurred, status, type, message,
                extraData: paymentObject);
        }

        /// <summary>
        /// Handles the print event
        /// </summary>
        /// <param name="sdk_event">The event</param>
        public override void HandlePrintEvent(PrintEvent sdk_event)
        {
            string type = sdk_event.Type == null ? "(null)" : sdk_event.Type.ToString();
            string status = sdk_event.Status.ToString();
            string message = sdk_event.Message == null ? "(null)" : sdk_event.Message.ToString();
            RaiseEvent(PrintEventOccurred, status, type, message);
        }

        /// <summary>
        /// Handles the receipt delivery method event
        /// </summary>
        /// <param name="sdk_event">The event</param>
        public override void HandleReceiptDeliveryMethodEvent(ReceiptDeliveryMethodEvent sdk_event)
        {
            string type = sdk_event.Type == null ? "(null)" : sdk_event.Type.ToString();
            string status = sdk_event.Status.ToString();
            string message = sdk_event.Message == null ? "(null)" : sdk_event.Message.ToString();
            RaiseEvent(ReceiptDeliveryMethodEventOccurred, status, type, message);
        }

        /// <summary>
        /// Handles the reconciliation event
        /// </summary>
        /// <param name="sdk_event">The event</param>
        public override void HandleReconciliationEvent(ReconciliationEvent sdk_event)
        {
            string type = sdk_event.Type == null ? "(null)" : sdk_event.Type.ToString();
            string status = sdk_event.Status.ToString();
            string message = sdk_event.Message == null ? "(null)" : sdk_event.Message.ToString();
            RaiseEvent(ReconciliationEventOccurred, status, type, message);
        }

        /// <summary>
        /// Handles the reconciliations list event
        /// </summary>
        /// <param name="sdk_event">The event</param>
        public override void HandleReconciliationsListEvent(ReconciliationsListEvent sdk_event)
        {
            string type = sdk_event.Type == null ? "(null)" : sdk_event.Type.ToString();
            string status = sdk_event.Status.ToString();
            string message = sdk_event.Message == null ? "(null)" : sdk_event.Message.ToString();
            RaiseEvent(ReconciliationsListEventOccurred, status, type, message);
        }

        /// <summary>
        /// Handles the status event
        /// </summary>
        /// <param name="status">The status</param>
        public override void HandleStatus(Status status)
        {
            string type = status.Type.ToString();
            RaiseEvent(StatusEventOccurred, status.StatusCode.ToString(), type, status.Message);
        }

        /// <summary>
        /// Handles the stored value card event
        /// </summary>
        /// <param name="sdk_event">The event</param>
        public override void HandleStoredValueCardEvent(StoredValueCardEvent sdk_event)
        {
            string type = sdk_event.Type == null ? "(null)" : sdk_event.Type.ToString();
            string status = sdk_event.Status.ToString();
            string message = sdk_event.Message == null ? "(null)" : sdk_event.Message.ToString();
            RaiseEvent(StoredValueCardEventOccurred, status, type, message);
        }

        /// <summary>
        /// Handles the transaction event
        /// </summary>
        /// <param name="sdk_event">The event</param>
        public override void HandleTransactionEvent(TransactionEvent sdk_event)
        {
            string type = sdk_event.Type == null ? "(null)" : sdk_event.Type.ToString();
            string status = sdk_event.Status.ToString();
            string message = sdk_event.Message == null ? "(null)" : sdk_event.Message.ToString();
            RaiseEvent(TransactionEventOccurred, status, type, message);
        }

        /// <summary>
        /// Handles the transaction query event
        /// </summary>
        /// <param name="sdk_event">The event</param>
        public override void HandleTransactionQueryEvent(TransactionQueryEvent sdk_event)
        {
            string type = sdk_event.Type == null ? "(null)" : sdk_event.Type.ToString();
            string status = sdk_event.Status.ToString();
            string message = sdk_event.Message == null ? "(null)" : sdk_event.Message.ToString();
            RaiseEvent(TransactionQueryEventOccurred, status, type, message);
        }

        /// <summary>
        /// Handles the user input event
        /// </summary>
        /// <param name="sdk_event">The event</param>
        public override void HandleUserInputEvent(UserInputEvent sdk_event)
        {
            string type = sdk_event.Type == null ? "(null)" : sdk_event.Type.ToString();
            string status = sdk_event.Status.ToString();
            string message = sdk_event.Message == null ? "(null)" : sdk_event.Message.ToString();
            RaiseEvent(UserInputEventOccurred, status, type, message);
        }

        /// <summary>
        /// Handles the device vitals information event
        /// </summary>
        /// <param name="sdk_event">The event</param>
        public override void HandleDeviceVitalsInformationEvent(DeviceVitalsInformationEvent sdk_event)
        {
            string type = sdk_event.Type == null ? "(null)" : sdk_event.Type.ToString();
            string status = sdk_event.Status.ToString();
            string message = sdk_event.Message == null ? "(null)" : sdk_event.Message.ToString();
            RaiseEvent(DeviceVitalsInformationEventOccurred, status, type, message);
        }

        /// <summary>
        /// Handles the pin event
        /// </summary>
        /// <param name="event">The event</param>
        public override void HandlePinEvent(PinEvent @event)
        {
            throw new NotImplementedException();
        }

        #endregion  
    }
}

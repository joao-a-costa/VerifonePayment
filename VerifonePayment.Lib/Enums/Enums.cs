namespace VerifonePayment.Lib
{
    /// <summary>
    /// Enumerations for the different types of events that can be received from the Verifone device.
    /// </summary>
    public class Enums
    {
        /// <summary>
        /// Enumerations for the different types of events that can be received from the Verifone device.
        /// </summary>
        public enum EventType
        {
            /// <summary>
            /// Status initialized.
            /// </summary>
            STATUS_INITIALIZED = 0,
            /// <summary>
            /// Transaction notification.
            /// </summary>
            TRANSACTION_NOTIFICATION = 1,
            /// <summary>
            /// Device vitals information.
            /// </summary>
            DEVICE_VITALS_INFORMATION_EVENT = 2,
            /// <summary>
            /// Login completed.
            /// </summary>
            LOGIN_COMPLETED = 3,
            /// <summary>
            /// Session started.
            /// </summary>
            SESSION_STARTED = 4,
            /// <summary>
            /// Session ended.
            /// </summary>
            SESSION_ENDED = 5,
            /// <summary>
            /// Basket event.
            /// </summary>
            BASKET_EVENT = 6,
            /// <summary>
            /// Notification event.
            /// </summary>
            NOTIFICATION_EVENT = 7,
            /// <summary>
            /// Transaction payment completed.
            /// </summary>
            TRANSACTION_PAYMENT_COMPLETED = 8,
            /// <summary>
            /// Status teardown.
            /// </summary>
            STATUS_TEARDOWN = 9,
            /// <summary>
            /// Status error.
            /// </summary>
            STATUS_ERROR = 10
        }
    }
}

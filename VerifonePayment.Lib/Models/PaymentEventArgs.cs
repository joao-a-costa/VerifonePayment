using System;
using static VerifonePayment.Lib.Enums;

namespace VerifonePayment.Lib.Models
{
    /// <summary>
    /// Payment event arguments
    /// </summary>
    public class PaymentEventArgs : EventArgs
    {
        /// <summary>
        /// Status of the payment
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Type of the event
        /// </summary>
        public EventType Type { get; set; }
        /// <summary>
        /// Message of the event
        /// </summary>
        public string Message { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Models
{
    public enum OrderStatus
    {
        InProcessing,
        AwaitingPayment,
        AcceptedForExecution,
        Submitted
    }
}

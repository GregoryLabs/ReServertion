using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ServerReservation.Areas.Identity.Models;

namespace ServerReservation.Models
{
    public class Request
    {
        public int Id { get; set; }
        private DateTime? timestamp;
        public DateTime Timestamp
        {
            get { return timestamp ?? DateTime.Now; }
            set { timestamp = value; }
        }

        [DisplayName("Start Date")] [DataType(DataType.Date)] public DateTime? StartDate { get; set; }
        [DisplayName("End Date")] [DataType(DataType.Date)] public DateTime? EndDate { get; set; }
        [DisplayName("New Server")] public bool IsNewServer { get; set; }



        [DisplayName("Server")] public int? ServerId { get; set; }
        [DisplayName("Server")] public Server Server { get; set; }

        [DisplayName("Request Employee Id")] public string RequestedByEmployeeId { get; set; }
        [DisplayName("Request Employee Name")] public string RequestedByEmployeeName { get; set; }
        [DisplayName("Request User")] public string RequestedByUserId { get; set; }
        [DisplayName("Requested by")] public virtual ApplicationUser RequestedByUser { get; set; }
        [DisplayName("Request Justification")] public string RequestJustification { get; set; }

        [DisplayName("Approval Status")] public ApprovalStatus? ApprovalStatus { get; set; }
        [DisplayName("Approve Employee Id")] public string ApprovedByEmployeeId { get; set; }
        [DisplayName("Approve Employee Name")] public string ApprovedByEmployeeName { get; set; }
        [DisplayName("Approve User")] public string ApprovedByUserId { get; set; }
        [DisplayName("Approved by")] public virtual ApplicationUser ApprovedByUser { get; set; }
        [DisplayName("Approval Comment")] public string ApprovalComment { get; set; }
    }

    public enum ApprovalStatus
    {
        Pending,
        Approved,
        Declined
    }
}

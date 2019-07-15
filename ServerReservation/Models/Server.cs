using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServerReservation.Models
{
    public class Server
    {
        public int Id { get; set; }
        private DateTime? timestamp;
        public DateTime Timestamp
        {
            get { return timestamp ?? DateTime.UtcNow; }
            set { timestamp = value; }
        }

        [DisplayName("Cost")] public double Cost { get; set; }

        public string Hostname { get; set; }
        [DisplayName("Hard Drive")] public double? HD { get; set; }
        [DisplayName("Hard Drive Size")] public FileSize? HDSize { get; set; }
        public string HDString { get { return HD.ToString() + " " + HDSize.Value.ToString(); } }
        [DisplayName("RAM")] public double? RAM { get; set; }
        [DisplayName("RAM Size")] public FileSize? RAMSize { get; set; }
        public string RAMString { get { return RAM.ToString() + " " + RAMSize.Value.ToString(); } }
        [DisplayName("CPU")] public string CPU { get; set; }

        public string Details
        {
            get
            {
                string temp = !string.IsNullOrEmpty(Hostname) ? "Hostname: " + Hostname + " " : "";
                temp += HD != null ? "HD: " + HD.ToString() + " " : "";
                temp += HDSize != null ? " " + HDSize.Value.ToString() + " " : "";
                temp += RAM != null ? "RAM: " + RAM.ToString() + " " : "";
                temp += RAMSize != null ? " " + RAMSize.Value.ToString() + " " : "";
                temp += !string.IsNullOrEmpty(CPU) ? "CPU: " + CPU + " " : "";
                return temp;
            }
        }

        [DisplayName("Type")] public ServerType? ServerType { get; set; }
        public string Location { get; set; }
        public string Note { get; set; }
    }

    public enum FileSize
    {
        KB,
        MB,
        GB,
        TB
    }
    public enum ServerType
    {
        [Display(Name = "Physical Server")] Physical,
        [Display(Name = "Virtual Machine Server")] VM,
        [Display(Name = "Cloud Server")] Cloud
    }
}

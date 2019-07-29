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
            get { return timestamp ?? DateTime.Now; }
            set { timestamp = value; }
        }

        [DisplayName("Cost")] [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)] public double? Cost { get; set; }

        [DisplayName("Group")] public string Group { get; set; }
        [DisplayName("Alias")] public string Alias { get; set; }

        [DisplayName("Host Name")] public string Hostname { get; set; }
        [DisplayName("DNS Domain")] public string DNSDomain { get; set; }
        [DisplayName("Windows Domain")] public string WindowsDomain { get; set; }
        [DisplayName("Machine Domain")] public string MachineDomain { get; set; }
        [DisplayName("Logon Domain")] public string LogonDomain { get; set; }
        [DisplayName("Logon Server")] public string LogonServer { get; set; }

        [DisplayName("System Type")] public string SystemType { get; set; }
        [DisplayName("OS Version")] public string OSVersion { get; set; }
        [DisplayName("Service Pack")] public string ServicePack { get; set; }

        [DisplayName("Network Card")] public string NetworkCard { get; set; }
        [DisplayName("Network Type")] public string NetworkType { get; set; }
        [DisplayName("Network Speed")] public string NetworkSpeed { get; set; }

        [DisplayName("MAC Address")] public string MACAddress { get; set; }
        [DisplayName("IPv4 Address")] public string IPv4Address { get; set; }
        [DisplayName("IPv6 Address")] public string IPv6Address { get; set; }
        [DisplayName("Subnet Mask")] public string SubnetMask { get; set; }
        [DisplayName("Default Gateway")] public string DefaultGateway { get; set; }
        [DisplayName("DHCP Server")] public string DHCPServer { get; set; }
        [DisplayName("DNS Server")] public string DNSServer { get; set; }

        [DisplayName("MAC Address 2")] public string MACAddress2 { get; set; }
        [DisplayName("IPv4 Address 2")] public string IPv4Address2 { get; set; }
        [DisplayName("IPv6 Address 2")] public string IPv6Address2 { get; set; }
        [DisplayName("Subnet Mask 2")] public string SubnetMask2 { get; set; }
        [DisplayName("Default Gateway 2")] public string DefaultGateway2 { get; set; }
        [DisplayName("DHCP Server 2")] public string DHCPServer2 { get; set; }
        [DisplayName("DNS Server 2")] public string DNSServer2 { get; set; }


        [DisplayName("CPU")] public string CPU { get; set; }
        [DisplayName("Cores")] public int? Cores { get; set; }
        [DisplayName("Hard Drive")] public double? HD { get; set; }
        [DisplayName("Hard Drive Size")] public FileSize? HDSize { get; set; }
        public string HDString { get { return HD.ToString() + " " + HDSize.Value.ToString(); } }
        [DisplayName("RAM")] public double? RAM { get; set; }
        [DisplayName("RAM Size")] public FileSize? RAMSize { get; set; }
        public string RAMString { get { return RAM.ToString() + " " + RAMSize.Value.ToString(); } }

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
        [DisplayName("Location")] public string Location { get; set; }
        [DisplayName("Note")] public string Note { get; set; }
        [DisplayName("Justification")] public string Justification { get; set; }
        [DisplayName("ProjectId")] public string ProjectId { get; set; }


    }

    public enum FileSize
    {
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

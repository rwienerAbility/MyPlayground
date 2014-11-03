using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.VisualBasic.FileIO;

namespace ConsoleApplication1
{
    class Program
    {
        enum ClaimStatusCode
        {
            UnprocessedOrPended = 0,
            MdolAccepted = 1,
            MdolRejected = 2,
            MdolIgnored = 3,
            MdolUnreadable = 4,
            MdolDiscarded = 5,
            ClearinghouseAcknowledge = 100,
            ClearinghouseAccept = 101,
            ClearinghouseReject = 102,
            ClaimStatusAcknowledge = 200,
            ClaimStatusAccept = 201,
            ClaimStatusReject = 202,
            ClaimsInAdjudication = 290,
            PayerAcknowledge = 300,
            PayerAccept = 301,
            PayerReject = 302
        }

        class MyDataClass
        {
            public int ClaimIdMDOL { get; set; }
            public int ClaimIdClient { get; set; }
            public int Tin { get; set; }
            public int BillingNpi { get; set; }
            public String PatientLastName { get; set; }
            public String PatientFirstName { get; set; }
            public String PatientControlNumber { get; set; }
            public String DOSStatementPeriod { get; set; } // mmddyy Data
            public String InsuredId { get; set; }
            public int Charges{ get; set; }
            public int PayerId { get; set; }
            public String PayerName { get; set; }
            public ClaimStatusCode ClaimStatus { get; set; }
            public String Message { get; set; }

            public override string ToString()
            {
                return PatientFirstName + " " + PatientLastName + "\t(" + PatientControlNumber + ")";
            }
        }

        private static void Main(string[] args)
        {

            var csv = new CsvReader(new StreamReader(args[0]), 
                new CsvConfiguration
                {
                    HasHeaderRecord = false,
                    Delimiter = ",",
                    AllowComments = true, 
                    Comment = '#',
                    IgnoreBlankLines = true,
                    SkipEmptyRecords = true,
                    TrimFields = true
                    ,
                });

            try
            {
                var records = csv.GetRecords<MyDataClass>().ToList();
                foreach (var record in records)
                {
                    Console.WriteLine(record.ToString());
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

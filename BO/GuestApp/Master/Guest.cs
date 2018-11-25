using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.GuestApp.Master
{
    public class Guest
    {

        public string   Name { get; set; }
        public string ID { get; set; }

        [Display(Name = "Reservation No")]
        public string ReservationNo { get; set; }

        [Display(Name = "Reservation Date")]
        public string ReservationDate { get; set; }
        public string PlanID { get; set; }

        [Display(Name = "Room No")]
        public string RoomNo { get; set; }
        public string RoomPlan { get; set; }
        public string RegNo { get; set; }
        public string GuestName1 { get; set; }
        public string GuestName3 { get; set; }
        public string Nationality { get; set; }
        public string TotalPAX { get; set; }
        public string ExtraAdult { get; set; }
        public string ExtraChild { get; set; }
        public string Status { get; set; }
        public string PropertyName { get; set; }
        public string CurrentUser { get; set; }
        public string FromDateToDate { get; set; }
        public string SortBy { get; set; }
        public string Pax { get; set; }
        public string Description { get; set; }
        public string Rooms { get; set; }
        public string RoomNos { get; set; }
        public string Count { get; set; }
        [Display(Name = "Room Type")]
        public string RoomType { get; set; }

        public string ToDate { get; set; }
        [Display(Name = "Rooms")]
        public int NoOfRooms { get; set; }


        [Display(Name = "Arrival Date")]
        public string ArrivalDate { get; set; }

        [Display(Name = "Arrival Date")]
        public string MyArrivalDate { get; set; }


        [Display(Name = "Arrival Time")]
        public string ArrivalTime { get; set; }


        [Display(Name = "Departure Date")]
        public string DepartureDate { get; set; }


        [Display(Name = "Departure Time")]
        public string DepartureTime { get; set; }


        [Display(Name = "Arrival")]
        public string MyArrivalDateTime { get; set; }

        [Display(Name = "Departure")]
        public string MyDepartureDateTime { get; set; }


        [Display(Name = "No Of Days")]
        [RegularExpression(@"^[0-9.]*$", ErrorMessage = "Only numbers allowed")]
        public string NoOfDays { get; set; }

        [Display(Name = "In/Out")]
        public string InOut { get; set; }

        [Display(Name = "Reservation Status")]
        public string ReservationStatus { get; set; }

        [RegularExpression(@"^[0-9.]*$", ErrorMessage = "Only numbers allowed")]
        [Display(Name = "Adults")]
        public int AdultPax { get; set; }

        [RegularExpression(@"^[0-9.]*$", ErrorMessage = "Only numbers allowed")]
        [Display(Name = "Children")]
        public int ChildPax { get; set; }

        [Display(Name = "RACK AMOUNT")]
        [RegularExpression(@"^[0-9.]*$", ErrorMessage = "Only numbers allowed")]
        public decimal RackAmount { get; set; }

        [Display(Name = "Discount Percentage")]
        [RegularExpression(@"^[0-9.]*$", ErrorMessage = "Only numbers allowed")]
        public decimal DiscountPercentage { get; set; }

        [Display(Name = "Discounted By")]
        public string DiscountedBy { get; set; }

        [Display(Name = "Discount Reason")]
        public string DiscountReason { get; set; }


        [Display(Name = "CHARGE AMOUNT")]
        [RegularExpression(@"^[0-9.]*$", ErrorMessage = "Only numbers allowed")]
        public decimal ChargeAmount { get; set; }

        [Display(Name = "TOTAL TARIFF AMOUNT")]
        [RegularExpression(@"^[0-9.]*$", ErrorMessage = "Only numbers allowed")]
        public decimal TotalTariffAmount { get; set; }

        [Display(Name = "Extra Bed Adult")]
        [RegularExpression(@"^[0-9.]*$", ErrorMessage = "Only numbers allowed")]
        public int ExtraBedAdult { get; set; }

        [Display(Name = "EXTRA RACK ADULT")]
        [RegularExpression(@"^[0-9.]*$", ErrorMessage = "Only numbers allowed")]
        public decimal ExtraRackAdult { get; set; }

        [Display(Name = "EXTRA CHARGE ADULT")]
        [RegularExpression(@"^[0-9.]*$", ErrorMessage = "Only numbers allowed")]
        public decimal ExtraChargeAdult { get; set; }

        public string FDate { get; set; }
        public string TDate { get; set; }
        public string CompanyName { get; set; }
        public string restroType { get; set; }

        [Display(Name = "EXTRA ADULT TOTAL TARIFF")]
        [RegularExpression(@"^[0-9.]*$", ErrorMessage = "Only numbers allowed")]
        public decimal ExtraAdultTotalTariff { get; set; }

        [Display(Name = "Extra Bed Child")]
        [RegularExpression(@"^[0-9.]*$", ErrorMessage = "Only numbers allowed")]
        public int ExtraBedChild { get; set; }

        [Display(Name = "EXTRA RACK CHILD")]
        [RegularExpression(@"^[0-9.]*$", ErrorMessage = "Only numbers allowed")]
        public decimal ExtraRackChild { get; set; }


        [Display(Name = "EXTRA CHARGE CHILD")]
        [RegularExpression(@"^[0-9.]*$", ErrorMessage = "Only numbers allowed")]
        public decimal ExtraChargeChild { get; set; }


        [Display(Name = "EXTRA CHILD TOTAL TARIFF")]
        [RegularExpression(@"^[0-9.]*$", ErrorMessage = "Only numbers allowed")]
        public decimal ExtraChildTotalTariff { get; set; }


        [Display(Name = "FINAL TOTAL TARIFF AMOUNT")]
        [RegularExpression(@"^[0-9.]*$", ErrorMessage = "Only numbers allowed")]
        public decimal FinalTotalTariffAmount { get; set; }

        public int ExtraBed { get; set; }


        [Display(Name = "TARIFF TAX")]
        public string TariffTax { get; set; }


        [Display(Name = "EXTENTION TAX")]
        public string ExtentionTax { get; set; }

        [Display(Name = "Payment Type")]
        public string PayMode { get; set; }

        public string SetAmt { get; set; }
        public string SettledUser { get; set; }
        [Display(Name = "MARKET SEGMENT")]
        public string MarketSegment { get; set; }


        [Display(Name = "Guest Status")]
        public string GuestType { get; set; }

        public string TotalResvRoom { get; set; }
        public string totalNumber { get; set; }
        public string totalroom { get; set; }

        public string BlockRoom { get; set; }
        public string roomstatus { get; set; }

        /*=============== Guest Details===========================*/


        [Display(Name = "GUEST ID")]
        public string GuestID { get; set; }

        [Display(Name = "Title")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Only character allowed")]
        public string GuestTitle { get; set; }

        [Display(Name = "Guest Name")]
        [RegularExpression(@"^[a-zA-Z. ]*$", ErrorMessage = "Only character allowed")]
        public string GuestName { get; set; }

        [Display(Name = "Title")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Only character allowed")]
        public string GuestTitle2 { get; set; }

        [Display(Name = "Guest Name")]
        [RegularExpression(@"^[a-zA-Z. ]*$", ErrorMessage = "Only character allowed")]
        public string GuestName2 { get; set; }

        [Display(Name = "GENDER")]
        [RegularExpression(@"^[a-zA-Z. ]*$", ErrorMessage = "Only character allowed")]
        public string GuestGender { get; set; }

        [Display(Name = "MARITAL STATUS")]
        [RegularExpression(@"^[a-zA-Z. ]*$", ErrorMessage = "Only character allowed")]
        public string GuestMaritalStatus { get; set; }

        [Display(Name = "Address")]
        [RegularExpression(@"^[a-zA-Z0-9. ]*$", ErrorMessage = "Only character and numbers allowed")]
        public string GuestAddress { get; set; }

        [Display(Name = "COUNTRY")]
        [RegularExpression(@"^[a-zA-Z. ]*$", ErrorMessage = "Only character allowed")]
        public string GuestCountry { get; set; }

        [Display(Name = "STATE")]
        [RegularExpression(@"^[a-zA-Z. ]*$", ErrorMessage = "Only character allowed")]
        public string GuestState { get; set; }

        [Display(Name = "CITY")]
        [RegularExpression(@"^[a-zA-Z. ]*$", ErrorMessage = "Only character allowed")]
        public string GuestCity { get; set; }

        [Display(Name = "ZIP CODE")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Only numbers allowed")]
        public string GuestZipCode { get; set; }

        [Display(Name = "TELEPHONE")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Only numbers allowed")]
        public string GuestTelePhone { get; set; }

        [Display(Name = "Mobile No.")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Only numbers allowed")]
        public string GuestMobile { get; set; }

        [Display(Name = "FAX NO")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Only numbers allowed")]
        public string GuestFaxNo { get; set; }

        [Display(Name = "Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        public string GuestEmail { get; set; }

        [Display(Name = "DOB")]
        public string GuestDOB { get; set; }

        [Display(Name = "ANNIVERSARY DATE")]
        public string GuestAnniversaryDate { get; set; }

        [Display(Name = "GUEST DocumentID")]
        public string GuestDocumentID { get; set; }

        [Display(Name = "ID TYPE")]
        [RegularExpression(@"^[a-zA-Z0-9. ]*$", ErrorMessage = "Only character and numbers allowed")]
        public string GuestIDType { get; set; }

        [Display(Name = "ID NUMBER")]
        [RegularExpression(@"^[a-zA-Z0-9. ]*$", ErrorMessage = "Only character and numbers allowed")]
        public string GuestIDNumber { get; set; }
        public string Date { get; set; }
        public string User { get; set; }
        public string BillDate { get; set; }
        public string BillTime { get; set; }
        public string BillNo { get; set; }
        public string Outlet { get; set; }
        public string UserID { get; set; }
        public string OrderDate { get; set; }
        public string RoundOff { get; set; }
        public string Total_Amount { get; set; }
        public string BillAmount { get; set; }
        public string TaxAmt { get; set; }
        public string Discount { get; set; }
        public string NetAmt { get; set; }
        public string GuestAmt { get; set; }
        public string RevenueCode { get; set; }
        public string OutletName { get; set; }
        public string ItemName { get; set; }

        public string Rate { get; set; }
        public string Quantity { get; set; }
        public string TotalAmount { get; set; }
        public string currentDate { get; set; }
        public string SubCat { get; set; }
        public string Remark { get; set; }
        public string Cash { get; set; }
        public string Cheque { get; set; }
        public string Credit { get; set; }
        public string OrderID { get; set; }
        public string CGST { get; set; }
        public string Covers { get; set; }
        public string SGST { get; set; }
        public string SystemDateTime { get; set; }




        public string GuestNationality { get; set; }
    }
}

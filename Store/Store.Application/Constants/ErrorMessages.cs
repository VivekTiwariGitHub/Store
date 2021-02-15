using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Application.Constants
{
    public class ErrorMessages
    {
        public static string RoleCanNotBeEmpty { get; set; } = "Users role can not be empty";
        public static string WeightCanNotBeZero { get; set; } = "Weight or Price can not be less than or equal to zero";
        public static string DiscountCanNotBe100 { get; set; } = "Discount can not be 100.";
        public static string NotAPrivilegedCustomer { get; set; } = "Not a privileged customer to get discount";

    }
}

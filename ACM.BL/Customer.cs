using System;

namespace ACM.BL
{
    public class Customer
    {
        public Customer() { }

        public Customer(int customerId)
        {
            CustomerId = customerId;
        }

        public static int InstanceCount { get; set; }

        public int CustomerId { get; internal set; } 

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set => _lastName = value;
        }

        public string FirstName { get; set; }
        public string EmailAddress { get; set; }
        public Address HomeAddress { get; set; }
        public Address WorkAddress { get; set; }

        public string FullName
        {
            get
            {
                string fullName = LastName;
                if (!string.IsNullOrWhiteSpace(FirstName))
                {
                    if (!string.IsNullOrWhiteSpace(fullName))
                        fullName += ", ";
                    fullName += FirstName;
                }
                return fullName;
            }
        }

        public bool Validate()
        {
            var isValid = true;
            if (string.IsNullOrWhiteSpace(LastName)) isValid = false;
            if (string.IsNullOrWhiteSpace(EmailAddress)) isValid = false;
            return isValid;
        }
    }
}
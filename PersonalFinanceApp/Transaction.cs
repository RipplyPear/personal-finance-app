using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceApp
{
    [Serializable]
    internal class Transaction : IComparable<Transaction>//, ISerializable
    {
        public static int IdGenerator;
        private readonly int id;
        private decimal amount;
        private string currency;
        private DateTime dateTime;
        private string recipient;
        private string details;

        public int Id { get => id; }
        public decimal Amount { get => amount;  set => amount = value; } 
        public string Currency { 
            get => currency;
            set {
                if (value.Length == 3)
                    currency = value;
                else throw new ArgumentException("The currency must be exactly 3 letters", nameof(Currency));
            } 
        }
        public DateTime DateTime { get => dateTime;  set => dateTime = value; }
        public string Details { get => details; set => details = value; }
        public string Recipient { get => recipient; set => recipient = value; }

        public Transaction(decimal amount, string currency, DateTime dateTime, string recipient, string details)
        {
            this.id = IdGenerator++;
            this.amount = amount;
            this.currency = currency ?? throw new ArgumentNullException(nameof(currency));
            this.dateTime = dateTime;
            this.recipient = recipient ?? throw new ArgumentNullException(nameof(recipient));
            this.details = details ?? throw new ArgumentNullException(nameof(details));
        }

        /*public Transaction(SerializationInfo info, StreamingContext context)
        {
            this.id = info.GetInt32("ID");
            this.amount = info.GetDecimal("Amount");
            this.currency = info.GetString("Currency");

        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ID", this.id);
            info.AddValue("Amount", this.amount);
            info.AddValue("Currency", this.currency);
            info.AddValue("Date & Time", this.dateTime);
            info.AddValue("Recipient", this.recipient);
            info.AddValue("Details", this.details);
        }*/

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Transaction))
                return false;
            if (obj is not Transaction tx) return false;
            if (this.Amount == tx.Amount)
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            return this.id;
        }

        public override string? ToString()
        {
            string toString = 
                this.id + "," 
                + this.amount + "," 
                + this.currency + "," 
                + this.dateTime.ToString() + ","
                + this.recipient + "," 
                + this.details;
            return toString;
        }

        public int CompareTo(Transaction? other)
        {
            if (other is null)
                return 1;
            if (this.amount < other.Amount)
                return -1;
            if (this.amount > other.Amount)
                return 1;
            return 0;
        }
    }
}

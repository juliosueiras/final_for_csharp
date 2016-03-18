using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binaryFile1
{
    //class stores data for 1 record
    //represents SCHEMA
    class AccountRecord
    {
        private const int _RECORD_SIZE = 44;

        //first identify fields
        private int _accountNumber;
        private string _firstName;
        private string _lastName;
        private double _accountBalance;
        //second set constructors
        public AccountRecord()
        {
            AccountNumber = 0;
            FirstName = "";
            LastName = "";
            AccountBalance = 0.0;
        }
        public AccountRecord(int accountNumber, string firstName, string lastName, double accountBalance)
        {
            AccountNumber = accountNumber;
            FirstName = firstName;
            LastName = lastName;
            AccountBalance = accountBalance;
        }
        //third set properties (setters/getters)
        public int AccountNumber
        {
            get
            {
                return _accountNumber;
            }
            set
            {
                _accountNumber = value;
            }
        }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }
        public double AccountBalance
        {
            get
            {
                return _accountBalance;
            }
            set
            {
                _accountBalance = value;
            }
        }
        public int FileIndex
        {
            get
            {
                return (AccountNumber - 1) * _RECORD_SIZE;
            }
        }
        public static int RecordSize
        {
            get
            {
                return _RECORD_SIZE;
            }
        }
        public static int getFileIndex(int recordNum)
        {
            return (recordNum - 1) * RecordSize;
        }
    }
}

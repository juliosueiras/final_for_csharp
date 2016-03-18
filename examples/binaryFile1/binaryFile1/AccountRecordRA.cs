using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binaryFile1
{
    class AccountRecordRA : AccountRecord
    {
        private const int _MAX_NAME_LENGTH = 15;

        public AccountRecordRA()
            : base()
        {
            //no arg base constructor called
        }
        public AccountRecordRA(int accountNumber, string firstName, string lastName, double accountBalance)
            : base(accountNumber, firstName, lastName, accountBalance)
        {
            //4 arg base constructor called
        }
        public void write(FileStream file)
        {
            BinaryWriter bw = new BinaryWriter(file);
            //fields must be written in order
            bw.Write(AccountNumber);
            bw.Write(toFixedString(FirstName));
            bw.Write(toFixedString(LastName));
            bw.Write(AccountBalance);
        }
        private string toFixedString(string n)
        {
            StringBuilder sb = new StringBuilder(n);
            sb.Length = _MAX_NAME_LENGTH;
            return sb.ToString();
        }
        public void read(FileStream file)
        {
            BinaryReader br = new BinaryReader(file);
            AccountNumber = br.ReadInt32();
            //null characters need to be removed
            FirstName = br.ReadString().Replace('\0', ' ');
            LastName = br.ReadString().Replace('\0', ' ');
            AccountBalance = br.ReadDouble();
        }
        public void delete(FileStream file){
            AccountNumber = 0;
            FirstName = "";
            LastName = "";
            AccountBalance = 0.0;
            write(file);
        }
    }
}

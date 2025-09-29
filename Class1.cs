using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace PhBT
{
    internal class Class1
    {
        public static OleDbConnection con = new OleDbConnection(@"provider=microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\phbtdb.mdb;jet oledb:Database password=1234;");
    }
}

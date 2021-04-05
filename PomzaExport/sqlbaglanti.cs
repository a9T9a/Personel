using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PomzaExport
{
    class sqlbaglanti
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source = ATA-PC\\AAA;Initial Catalog = Pomza_Export_Sart; Integrated Security = True");
            baglan.Open();
            return baglan;
        }
    }
}

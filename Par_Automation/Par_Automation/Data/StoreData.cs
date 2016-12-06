using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Par.Data
{
    public static class StoreData
    {
        static string store1name = "Store 1";
        static List<string> store1employees = new List<string>{"Aaron St. Dennis", "Adrian Acosta", "alan hernandez"};
        static List<string> store1shifts = new List<string> {"1-2-2017,3:00-5:00", "1-2-2017,6:00-8:00"};

        static string store2name = "Store 2";
        static List<string> store2employees = new List<string> {"Bob", "Bill"};
        static List<string> store2shifts = new List<string> {"1-3-2017,3:00-5:00", "1-4-2017,6:00-8:00"};

        static string store3name = "Store 3";
        static List<string> store3employees = new List<string> {"Henry", "Rob"};
        static List<string> store3shifts = new List<string> {"12-4-2017,3:00-5:00", "12-2-2017,6:00-8:00"};

        public static readonly Dictionary<string, Store> stores = new Dictionary<string, Store>
       {
           {store1name, new Store(store1name,store1employees,store1shifts) },
           {store2name, new Store(store2name,store2employees,store2shifts) },
           {store3name, new Store(store3name,store3employees,store3shifts) }
       };
    }
}

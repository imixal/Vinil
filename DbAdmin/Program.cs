using Data_Access_Layer;
using Data_Access_Layer.Repository;
using Data_Access_Layer.UnitOfWork;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAdmin
{
    class Program
    {
        
        static void Main(string[] args)
        {
            List<Vinil> vinils = new List<Vinil>() ;
            using (StreamReader sr = new StreamReader("data.txt", System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Vinil newVinil = JsonConvert.DeserializeObject<Vinil>(line);
                    vinils.Add(newVinil);
                }
            }
            using (UnitOfWork uow = new UnitOfWork())
            {
                uow.Vinils.DeleteAll("Vinils");
                foreach (var item in vinils)
                {
                    uow.Vinils.Add(item);
                }
                uow.Save();
            }
            for (;;)
            {
                Console.WriteLine("database update");
                var temp = Console.ReadLine();
                
            }
        }


    }
}

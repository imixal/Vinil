using Data_Access_Layer;
using Data_Access_Layer.Repository;
using Data_Access_Layer.UnitOfWork;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAdmin
{
    class Program
    {
        
        static void Main(string[] args)
        {
            for (;;)
            {
                Console.WriteLine("add or show");
                var temp = Console.ReadLine();
                if (temp == "add") AddM();
                else if(temp == "show") ShowDB();

            }
        }
        static private void ShowDB()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var list = uow.Vinils.GetAll();
                foreach(var item in list)
                {
                    Console.WriteLine(item.Name);
                }
            }
        }
        static private void AddM()
        {

            using (UnitOfWork uow = new UnitOfWork())
            { 
                Vinil disk = new Vinil();
                Console.WriteLine("Name");
                disk.Name = Console.ReadLine();
                uow.Vinils.Add(disk);
                uow.Save();
            }
        }
    }
}

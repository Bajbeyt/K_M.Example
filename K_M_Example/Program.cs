using System;
using System.Data.SqlClient;
using System.Xml.Linq;
using BusinesLayer;
using DataLayer;
namespace K_M_Example
{
    internal class Program
    {
        static MyBusinesCode businesCode;
        static Personnel personnel;

        private static void Main(string[] args)
        {
            businesCode = new MyBusinesCode();
            HomePages();
        }
        public static void HomePages()
        {
            
            Console.WriteLine("++menü++\nyapmak istediğin işlem");
            Console.WriteLine("1 kullanıcı kayıt");
            Console.WriteLine("2 kullanıcı güncelle");
            Console.WriteLine("3 kullanıcı sil");
            Console.WriteLine("4 kullanıcı listele");
            int choose = Convert.ToInt32(Console.ReadLine());
            switch (choose)
            {
                case 1:
                    Console.Clear();
                    InsertUser();
                    break;
                case 2:
                    Console.Clear();
                    UpdateUser();
                    break;
                case 3:
                    Console.Clear();
                    DeleteUser();
                    break;
                case 4:
                    Console.Clear();
                    ListUser();

                    break;
            }
        }
        public static void InsertUser()
        {
            Console.WriteLine("adını gir");
            string name = Console.ReadLine();
            Console.WriteLine("soyadını girin");
            string surname = Console.ReadLine();
            Console.WriteLine("okul adını gir");
            string schoolName = Console.ReadLine();
            Console.WriteLine("mesleğini gir");
            string jop = Console.ReadLine();

            businesCode.InsertData(name, surname, schoolName, jop);
            HomePages();
        }
        public static void UpdateUser()
        {
            List();
            Console.WriteLine("güncellemek istediğin kullanıcı numarası");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("güncellemek istediğin adın");
            string name = Console.ReadLine();
            Console.WriteLine("güncellemek istediğin soyadın");
            string surname = Console.ReadLine();
            Console.WriteLine("güncellemek istediğin okul adın");
            string schoolName = Console.ReadLine();
            Console.WriteLine("güncellemek istediğin meslek bilgisi");
            string jop = Console.ReadLine();

            businesCode.UpdateData(id,name, surname, schoolName, jop);
            HomePages();
        }
        public static void DeleteUser()
        {
            List();
            Console.WriteLine("silmek istediğin kullanıcı numarasını gir");
            int id = Convert.ToInt32(Console.ReadLine());
            businesCode.DeleteUser(id);
            HomePages();
        }
        public static void ListUser()
        {
            Console.WriteLine("Kullanıcı Listesi\n");
            foreach (Personnel personnel1 in businesCode.ListUsers())
            {
                Console.WriteLine(personnel1.Id);
                Console.WriteLine(personnel1.Name);
                Console.WriteLine(personnel1.Surname);
                Console.WriteLine(personnel1.SchoolName);
                Console.WriteLine(personnel1.Jop);
                
            }
            HomePages();
        }
        public static void List()
        {
            Console.WriteLine("Kullanıcı Listesi\n");
            foreach (Personnel personnel1 in businesCode.ListUsers())
            {
                Console.WriteLine(personnel1.Id);
                Console.WriteLine(personnel1.Name);
                Console.WriteLine(personnel1.Surname+"\n");
            }
        }
    }
}
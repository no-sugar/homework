﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbdesign
{
    class Program
    {
        const string ConnectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=contacts_data;Integrated Security=true;";
        static void Main(string[] args)
        {
            try
            {
                // 连接数据库引
                using (contact_dataDataContext aDataContext = new contact_dataDataContext(ConnectionString))
                {
                    if (!aDataContext.DatabaseExists())
                    {
                        aDataContext.CreateDatabase();
                        Console.WriteLine("数据库已经创建！");
                    }
                    else
                    {
                        Console.WriteLine("数据库已经存在！");
                    }

                    // 读取数据表内容
                    var aContacts = from r in aDataContext.Contacts select r;
                    foreach (Contacts aContact in aContacts)
                    {
                        Console.WriteLine($"{aContact.name} : {aContact.telephone}");
                    }
                    Console.WriteLine("插入新记录");
                    Contacts aNewContact = new Contacts { name = "张三", telephone = "13562811111", email = "6300210@163.com", organization = "BUCT", remarks = "nothing" };
                    aDataContext.Contacts.InsertOnSubmit(aNewContact);

                    Console.WriteLine("提交数据……");
                    aDataContext.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            Console.WriteLine("按回车键退出……");
            Console.ReadLine();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace LGPD
{
    class Program
    {
        static void Main(string[] args)
        {

            using var db = new DatabaseContext();
            db.Database.EnsureCreated();
            //db.Empresas.Add(new Empresa
            //{
            //    Nome = "Tyle"
            //});


            //db.Clientes.Add(new Cliente
            //{
            //    Nome = "Rafael Almeida",
            //    Endereco = "Aqui mesmo",
            //    Telefone = "41999991234",
            //    CPF = "123456",
            //    EmpresaId = db.Empresas.FirstOrDefault().Id
            //});

            //db.SaveChanges();

            //var cliente = db.Clientes.Include("EmpresaNavigation").FirstOrDefault(p => p.CPF == "123456");
            //Console.WriteLine(cliente.Nome);
            //Console.WriteLine(cliente.CPF);
            //Console.WriteLine(cliente.EmpresaNavigation.Nome);

            string empNome = "Tyle";

            var cliente2 = db.Clientes.Include("EmpresaNavigation").Where(p => !string.IsNullOrEmpty(empNome) && p.EmpresaNavigation.Nome == empNome).FirstOrDefault();
            Console.WriteLine(cliente2.Nome);
            Console.WriteLine(cliente2.CPF);
            Console.WriteLine(cliente2.EmpresaNavigation.Nome);


            Console.Read();

        }
    }
}

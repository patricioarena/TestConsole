using System;
using System.Collections;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace Test.Services
{
    public interface IRolesServices
    {
        Queue ConfigToQueue(string str);
        Queue ConfigToQueue2(string str);
        Queue GetRoles(Queue myQ);
        void printRoles(Queue myQ);
        string readJson();
    }

    public class RolesServices : IRolesServices
    {
        private readonly IConfigurationRoot _configuration;
        public RolesServices(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }

        public string readJson() // Retorna la configuracion Elemplo: Admin=1;Employee=1;Client=9999;
        {
            var temp = _configuration["UserRoles:Roles"];
            return temp;
        }

        public Queue ConfigToQueue(string str) // Retorno de Queue realizado con foreach
        {
            String value = str;
            Char delimiter = ';';
            String[] substrings = value.Split(delimiter);
            Queue myQ = new Queue();
            foreach (var item in substrings)
            {
                Char newDelimiter = '=';
                String[] substrings2 = item.Split(newDelimiter);
                foreach (var item2 in substrings2)
                {
                    myQ.Enqueue(item2);
                }
            }
            return myQ;
        }

        public Queue ConfigToQueue2(string str) // Retorno de Queue realizado con lambda
        {
            String value = str;
            Char delimiter = ';';
            String[] substrings = value.Split(delimiter);
            Queue myQ = new Queue();
            substrings.ToList().ForEach(n =>
            {
                Char newDelimiter = '=';
                String[] substrings2 = n.Split(newDelimiter);
                substrings2.ToList().ForEach(x =>
                {
                    myQ.Enqueue(x);
                });
            });
            return myQ;
        }

        public void printRoles(Queue myQ)  // Imprime todos los roles y las cantidades correspondientes
        {
            myQ.ToArray().ToList().ForEach(v =>
            {
                if (myQ.Count != 1)
                {
                    var aRole = myQ.Dequeue();
                    var aLog = myQ.Dequeue();
                    var allInRole = 0;
                    if (allInRole < Int32.Parse(aLog.ToString()))
                    {
                        Console.WriteLine(aRole + " - " + aLog + " -> Success");
                    }
                }
            });
        }

        public Queue GetRoles(Queue myQ) // Entrega solamente roles
        {
            Queue otherQueue = new Queue();
            myQ.ToArray().ToList().ForEach(v =>
            {
                if (myQ.Count != 1)
                {
                    var aRole = myQ.Dequeue();
                    otherQueue.Enqueue(aRole);
                    var aLog = myQ.Dequeue();
                }
            });
            return otherQueue;
        }
    }
}
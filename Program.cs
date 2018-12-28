using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class Program
    {
        class hashtable
        {
            class hashentry
            {
                int key;
                string data;
                public hashentry(int key, string data)
                {
                    this.key = key;
                    this.data = data;
                }
                public int getkey()
                {
                    return key;
                }
                public string getdata()
                {
                    return data;
                }
            }
          public  const int maxSize = 100; //our table size
            hashentry[] table;
            public hashtable()
            {
                table = new hashentry[maxSize];
                for (int i = 0; i < maxSize; i++)
                {
                    table[i] = null;
                }
            }
            public string retrieve(int key)
            {
                int hash = key % maxSize;
                while (table[hash] != null && table[hash].getkey() != key)
                {
                    hash = (hash + 1) % maxSize;
                }
                if (table[hash] == null)
                {
                    return "nothing found!";
                }
                else
                {
                    return table[hash].getdata();
                }
            }
            public void Insert(int key, string data)
            {
                if (!checkOpenSpace())//if no open spaces available
                {
                    Console.WriteLine("table is at full capacity!");
                    return;
                }
                int hash = (key % maxSize);
                while (table[hash] != null )
                {
                    hash = (hash + 1) % maxSize;
                }
                table[hash] = new hashentry(key, data);
            }
            private bool checkOpenSpace()//checks for open spaces in the table for insertion
            {
                bool isOpen = false;
                for (int i = 0; i < maxSize; i++)
                {
                    if (table[i] == null)
                    {
                        isOpen = true;
                    }
                }
                return isOpen;
            }
            public bool remove(int key)
            {
                int hash = key % maxSize;
                while (table[hash] != null && table[hash].getkey() != key)
                {
                    hash = (hash + 1) % maxSize;
                }
                if (table[hash] == null)
                {
                    return false;
                }
                else
                {
                    table[hash] = null;
                    return true;
                }
            }
            public void print()
            {
                for (int i = 0; i < table.Length; i++)
                {
                    if (table[i] == null && i <= maxSize)//if we have null entries
                    {
                        continue;//dont print them, continue looping
                    }
                    else
                    {
                       
                        Console.WriteLine("{0}", table[i].getdata()); 
                    }
                }
            }
            public void quadraticHashInsert(int key, string data)
            {
                //quadratic probing method
                if (!checkOpenSpace())//if no open spaces available
                {
                    Console.WriteLine("table is at full capacity!");
                    return;
                }

                int j = 0;
                int hash = key % maxSize;
                while (table[hash] != null )
                {
                    j++;
                    hash = (hash + j * j) % maxSize;
                }
                if (table[hash] == null)
                {
                    table[hash] = new hashentry(key, data);
                    return;
                }
            }
         
          
        }
 



            static void Main(string[] args)
        {
            Random Uretec = new Random();
            
            hashtable mytable = new hashtable();
            // linear probing Kulanarak
            for(int i=0;i<100;i++)
            {
                string data = (i + 1) + ". eleman";
                mytable.Insert(Uretec.Next(0, 1000),data);
            }

            //// quadratc probing  Kulanarak
            //for (int i = 0; i < 100; i++)
            //{
            //    string data = (i + 1) + ". eleman";
            //    mytable.Insert(Uretec.Next(0, 1000), data);
            //}


            mytable.print();
            Console.ReadLine();

        }
    }
  
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitove_manipulce
{
    class library 
    {
        public byte setBit(byte value, int bit) 
        {
            value = (byte)(value | (byte)(1 << bit)); // vymaskování pomocí OR a bitového posunu o bit indexu
            return value;
        }
        public byte deleteBit(byte value, int bit) 
        {
            value = (byte)(value & (byte)~(1<<bit)); // vymaskování pomocí AND a znegovaneho bitového posunu o bit indexu
            return value;
        }
        public byte changeBit(byte value, int bit) 
        {
            value = (byte)(value ^ (byte)(1 << bit)); // vymaskování pomocí XOR a bitového posunu o bit indexu
            return value;
        }
        public bool isBitOne(byte value, int bit)
        {
            if ((value & (byte)(1<<bit)) != 0) // vymaskování pomocí AND a porovnavam zda bit na pozici bit je 0
                return true; // kdyz bit je 1
            else
                return false; // kdyz bit je 0
        }
        public bool isBitZero(byte value, int bit)
        {
            if ((value & (byte)(1 << bit)) != 0) // vymaskování pomocí AND a porovnavam zda bit na pozici bit je 0
                return false; // kdyz bit je 0
            else
                return true; // kdyz bit je 1
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // jednoduchý rychlý prográmek pouze pro otestování metod
            byte testByte;
            int testBit;
            bool choice;
            library lib = new library();
            while (true) // loop aby program jel dokud uzivatel chce
            { 
                // vyberove menu
                Console.WriteLine("1 - set bit to 1");
                Console.WriteLine("2 - set bit to 0");
                Console.WriteLine("3 - change bit");
                Console.WriteLine("4 - is bit set to one");
                Console.WriteLine("5 - is bit set to zero");
                Console.WriteLine("6 - end aplication");
                Console.Write("Operace: "); // volba
                choice = int.TryParse(Console.ReadLine(), out int result); // snaha parsnout vstup pokud projde normalne se pkracuje pokud neprojde tak se upozorni na nespravnou volbu
                if (result == 6)
                {
                    break; // pokud uzivatel vybere moznost 6 rovnou ukoncuje loop a tedy i program
                }
                if (result <= 7 || result >= 0)
                {
                    choice = false;
                }
                if (choice) // pokud je vstup platny tak se zacne vykonavat kod nize
                {
                    Console.Write(" \r\nByte: "); // zadani vstupni byte
                    testByte = Convert.ToByte(Console.ReadLine());
                    Console.Write("Bit: "); // zadani bitu k manipulaci
                    testBit = Convert.ToByte(Console.ReadLine());
                    // podle vyberu uzivatele se provede dany if
                    if (result == 1)
                    {
                        Console.WriteLine("New value: {0}", lib.setBit(testByte, testBit)); // zavola metodu v classe pro nastaveni bitu do 1
                    }
                    else if (result == 2)
                    {
                        Console.WriteLine("New value: {0}", lib.deleteBit(testByte, testBit)); // zavola metodu v classe pro nastaveni bitu do 0
                    }
                    else if (result == 3)
                    {
                        Console.WriteLine("New value: {0}", lib.changeBit(testByte, testBit)); // zavola metodu v classe pro nastaveni bitu do jeho znegovane hodnoity
                    }
                    else if (result == 4)
                    {
                        Console.WriteLine("Is bit in 1?: {0}", lib.isBitOne(testByte, testBit)); // zavola metodu v classe pro vraceni bool zda je bit 1
                    }
                    else if (result == 5)
                    {
                        Console.WriteLine("Is bit in 0?: {0}", lib.isBitZero(testByte, testBit)); // zavola metodu v classe pro vraceni bool zda je bit 0
                    }
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Unvalid value, try again"); // hlaska pro uzivatele ze zadal neplatny vstup
                }
            }
        }
    }
}

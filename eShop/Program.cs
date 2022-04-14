using System;
using Business.Services.Implementations;
using Data.Entities;
using System.Linq;

namespace eShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var console = new eShopConsole();
            var showMenu = true;
            while (showMenu)
            {
                showMenu = console.MainMenu();
            }
        }
    }
}

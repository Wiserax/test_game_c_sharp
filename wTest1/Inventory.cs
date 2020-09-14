using System;
using System.Collections.Generic;

namespace test_game
{
    public class Inventory
    {
        public List<Item> itemList = new List<Item>();

        public void showItems() {
            if (itemList.Count == 0) {
                Console.WriteLine("Ваш инвентарь пуст.");
                return;
            }
            
            Console.WriteLine("Инвентарь:");
            foreach (var variable in itemList) {
                variable.showInfo();
            }
        }
        
    }
}
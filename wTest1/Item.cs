using System;

namespace test_game
{
    public class Item
    {
        private string name;
        private bool isEat;

        public Item(string name, bool isEat) {
            this.name = name;
            this.isEat = isEat;
        }

        public string getName()
        {
            return name;
        }
        
        public bool isEatable()
        {
            return isEat;
        }

        public void setName(string name)
        {
            this.name = name;
        }
        
        public void setIsEatable(bool isEat)
        {
            this.isEat = isEat;
        }
        
        public void showInfo()
        {
            string isEatable = isEat ? "да" : "нет";
            
            Console.WriteLine("Название предмета: " + name + "\n" + 
                              "Съедобно: " + isEatable + "\n");
        }
    }
}
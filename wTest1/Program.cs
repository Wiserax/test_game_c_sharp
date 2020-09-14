//Rextester.Program.Main is the entry point for your code. Don't change it.
//Microsoft (R) Visual C# Compiler version 2.9.0.63208 (958f2354)

using System;
using System.Collections.Generic;
namespace test_game
{

    public class Program
    {
        private static string help = "Список доступных действий: \n" + 
                                        "1. Посмотреть список предметов в комнате. \n" + 
                                        "2. Посмотреть информацию о предмете. \n" +
                                        "3. Подобрать предмет. \n" +
                                        "4. Посмотреть список предметов в инвентаре.\n" +
                                        "5. Съесть предмет. \n" +
                                        "6. Задать вопрос старику\n" +
                                        "7. Вывести список доступных действий ещё раз\n";
        
        private static string intro = "Резкая боль в ноге заставляет вас проснуться.\nВскочив и отдернув " + 
                                        "ногу вы видите шарахнувшегося от вас старика, что явно \nтолько что пытался " +
                                        "откусить кусок. Он выглядит очень грязным и худым. \n- Какого чёрта?! - " +
                                        "спрашиваете вы в исступлении, но старик не отвечает.\n\n" +
                                        "Вокруг холодно и сыро: вы находитесь в помещении напоминающем тюремную" +
                                        " камеру.  Прошло полчаса, пока вы наконец не вышли из ступора и решили что-то сделать.  " +
                                        "\n\n" + help;

        private static string answer1 = "Старик огрызается, но всё-таки отвечает: \n" +
                                        "Здоровяк Джо приволок тебя день назад. Я уже подумал, что мне еды принесли. А я очень хочу есть. " +
                                        "У тебя нет ничего для доброго дедушки?..\n";
        
        private static string answer2 = "Старик оборачивается, и смотрит на вас в упор, недоумевая: \n" +
                                        "О, нет, тот кто попадает в Дом Госпожи Ночи, уже никогда не покидает его стен. Оставь эту идею сопляк. " +
                                        "Может у тебя есть что-нибудь перекусить?..\n";


        public static void Main(string[] args) {
            
            List<Item> avaliableItems = new List<Item>();
            
            Item item0 = new Item("Странная таблетка", true);
            Item item1 = new Item("Треснутый камень", false);
            Item item2 = new Item("Отмычка", false);
            Item item3 = new Item("Большая кость", false);
            
            avaliableItems.Add(item0);
            avaliableItems.Add(item1);
            avaliableItems.Add(item2);
            avaliableItems.Add(item3);
            
            Inventory inventory = new Inventory();

            Console.WriteLine(intro);
            
            while (true) {
                
                Console.WriteLine("Введите цифру от 1 до 7");
                string selection = Console.ReadLine();
                string choice;
                
                switch (selection) {
                    //Посмотреть список предметов в комнате.
                    case "1":
                        Console.WriteLine("Вы ещё раз осматриваете предметы в комнате...");
                        foreach (var val in avaliableItems) {
                            Console.WriteLine(val.getName());
                        }
                        Console.WriteLine();
                        break;
                    
                    //Посмотреть информацию о предмете.
                    case "2":
                        Console.WriteLine("Вы решили подробнее рассмотреть предмет. Какой именно?");
                        choice = Console.ReadLine();
                        Item tmpItem = avaliableItems.Find(x => x.getName() == choice);
                        
                        if (tmpItem != null) tmpItem.showInfo();
                        else Console.WriteLine("Такого предмета нет.\n");
                        break;
                    
                    //Подобрать предмет, который перемещается в инвентарь.
                    case "3":
                        Console.WriteLine("Какой предмет вы хотите подобрать?");
                        choice = Console.ReadLine();
                        Item tmpItem1 = avaliableItems.Find(x => x.getName() == choice);

                        if (tmpItem1 != null) {
                            inventory.itemList.Add(tmpItem1);
                            avaliableItems.Remove(tmpItem1);
                            Console.WriteLine("Вы взяли предмет: " + tmpItem1.getName() + "\n");
                        }
                        else Console.WriteLine("Такого предмета нет.\n");
                        break;
                    
                    //Посмотреть список предметов в инвентаре.
                    case "4":
                        Console.WriteLine("Вы смотрите в свой угол комнаты, куда вы боязливо оттащили вещи.");
                        inventory.showItems();
                        Console.WriteLine();
                        break;
                    
                    //Скушать предмет, если он является едой.
                    case "5":
                        Console.WriteLine("Пора бы подкрепится. Что будем есть?");
                        choice = Console.ReadLine();
                        Item tmpItem2 = avaliableItems.Find(x => x.getName() == choice);
                        Item tmpItem3 = inventory.itemList.Find(x => x.getName() == choice);

                        if (tmpItem2 != null) {
                            if (avaliableItems.Contains(tmpItem2)) {
                                Console.WriteLine("Только вы подошли и попытались укусить " + tmpItem2.getName() + ", как дед в углу комнаты " +
                                                  "грозно зашипел. Вам следует сначала взять предмет в инвентарь.\n");
                            }
                        } else if (tmpItem3 != null) {
                            if (!tmpItem3.isEatable()) {
                                Console.WriteLine("Вы честно и упорно грызли " + tmpItem3.getName() + ", но у вас сломался зуб. " +
                                                  "Не стоит больше так делать.\n");
                            } else {
                                inventory.itemList.Remove(tmpItem3);
                                Console.WriteLine("Вы съели " + tmpItem3.getName() + " и теперь чувствуете себя более сытым.\n");
                            }
                        }
                        else Console.WriteLine("Такого предмета нет.\n");
                        break;
                    
                    //Задать 2 вопроса NPC, он может дать ответ на каждый вопрос.
                    case "6":
                        Console.WriteLine("В поисках ответов вы решили спросить вопрос у своего соседа по камере. Вас интересуют всего 2 вещи.\n" +
                                          "1. Как я здесь оказался?\n" +
                                          "2. Как отсюда выбратся?");
                        Console.WriteLine("Нажмите 1 или 2");
                        choice = Console.ReadLine();

                        if (choice != null && Int32.Parse(choice) == 1) {
                            Console.WriteLine(answer1);
                        } else if (choice != null && Int32.Parse(choice) == 2) {
                            Console.WriteLine(answer2);
                        } else {
                            Console.WriteLine("Неправильный вопрос");
                        }
                        break;
                    
                    //help
                    case "7":
                        Console.WriteLine(help);
                        break;
                    
                    case "cheat":
                        Console.WriteLine("В комнату вламываются вооруженные охранники. Один из них подходит к вам и сердечно просит прощения. " +
                                          "Вас явно держали здесь по ошибке. \nCongratulations!!!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Неизвестная команда\n");
                        break;
                }  
            }
            
        }
    }
}
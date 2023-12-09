using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;

class NPC
{
    public string Name { get; set; }

    public void Talk(string message)
    {
        Debug.Log($"{Name}: {message}");
    }
}

class DialogueSysten: MonoBehaviour
{
    static void Main(string[] args)
    {
        NPC npc1 = new NPC();
        npc1.Name = "NPC1";

        NPC npc2 = new NPC();
        npc2.Name = "NPC2";

        npc1.Talk(" Ого, не думала, что тут будет зима, хорошо что с нами нет взрослых");
        npc2.Talk("Угу, впали бы в спячку, пришлось бы тащить обратно");
        npc1.Talk("Зато с нами все будет хорошо");
        npc2.Talk("...");
        npc1.Talk("...");
        npc2.Talk("В прошлый раз первопроходцам не удалось выяснить кто обитает на этой планете");
        npc1.Talk("Про снег нас тоже не предупреждали..");
        npc2.Talk("Ну ничего, у нас все получится и мы докажет что ничем не хуже взрослых!");
        npc1.Talk("Верно! Пошли осмотримся пока");

        Console.ReadLine();
    }
}

using UnityEngine;

public class Messages {

    public static string[] es_text = new string[6] {
        "Nivel 1",
        "Nivel 2",
        "Nivel 3",
        "Nivel 4",
        "Nivel 5",
        "Nivel 6"
    };

    public static string[] en_text = new string[6] {
        "Level 1",
        "Level 2",
        "Level 3",
        "Level 4",
        "Level 5",
        "Level 6"
    };

    public static string[] es_menu = new string[3] {
        "Kuvi es desarrollado por una persona. Espero que te agrade.",
        "Este juego no seria posible sin el apoyo de Mama, Papa y la Chandy", 
        "¿Quieres saber más de nosotros? Visita nuestro sitio web"
    };

    public static string[] en_menu = new string[3] {
        "Kuvi is developed by one person. I hope you like it <3", 
        "Null", 
        "Null"
    };

    public static string getLevelMessage(int level) {
        return((Application.systemLanguage == SystemLanguage.Spanish) ? es_text[level] : en_text[level]); 
    }

    public static string getMenuMessage(int message) {
        return((Application.systemLanguage == SystemLanguage.Spanish) ? es_menu[message] : en_menu[message]); 
    }

}

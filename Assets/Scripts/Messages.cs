﻿using UnityEngine;

public class Messages {

    public static string[] es_text = new string[10] {
        "Intenta mover el cubo azul",
        "¡Muy bien! \nAqui tienes mas cubos",
        "A cada color le corresponde un sitio",
        "El orden si importa",
        "Nivel 5",
        "Nivel 6",
        "Nivel 6",
        "Nivel 6",
        "Nivel 6",
        "Nivel 6",
    };

    public static string[] en_text = new string[10] {
        "Try to move the blue cube",
        "Very nice! \nHave some more cubes",
        "Order matters",
        "Level 4",
        "Level 5",
        "Level 6",
        "Nivel 6",
        "Nivel 6",
        "Nivel 6",
        "Nivel 6",
    };

    public static string[] es_menu = new string[6] {
        "Kuvi es desarrollado por un pequeño equipo. \nEsperamos que te encante",
        "AGRADECIMIENTOS", 
        "Mama y Papa", 
        "Sigan siendo increibles",
        "Gracias por escucharme hablar tanto sobre desarrollo",
        "¿Quieres saber más de nosotros? Visita nuestro sitio web"
    };

    public static string[] en_menu = new string[6] {
        "Kuvi is developed by a small team. We hope you love it", 
        "THANKS",
        "Mom & Dad",
        "Keep being awesome",
        "Thank you for listening so much about gamedev", 
        "Do you want to know more \nCheck our other projects"
    };

    public static string getLevelMessage(int level) {
        return((Application.systemLanguage == SystemLanguage.Spanish) ? es_text[level] : en_text[level]); 
    }

    public static string getMenuMessage(int message) {
        return((Application.systemLanguage == SystemLanguage.Spanish) ? es_menu[message] : en_menu[message]); 
    }

}

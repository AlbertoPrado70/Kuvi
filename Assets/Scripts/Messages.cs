using UnityEngine;

public class Messages {

    public static string[] es_text = new string[50] {
        "Intenta mover el cubo azul",
        "¡Muy bien! Intentalo ahora con estos cubos",
        "Cada cubo tiene su lugar",
        "La paciencia es fundamental",
        "",
        "",
        "El orden si importa",
        "",
        "¿Estas atorado? Puedes ver la solucion del nivel desde el menu",
        "Tip: Puedes reiniciar el nivel desde el menu",
        "",
        "",
        "Tip: No olvides que puedes reiniciar el nivel desde el menu",
        "",
        "",
        "",
        "¿Te gusta Kuvi? Recuerda calificarnos en la Play Store",
        "",
        "",
        "",
        "Apoya el desarrollo de Kuvi volviendote premium y disfruta del juego sin anuncios",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
    };

    public static string[] en_text = new string[50] {
        "Try to move the blue cube",
        "Great! Now move those cubes to the right floor",
        "",
        "Patience is the key",
        "",
        "",
        "",
        "",
        "Use the autosolve button to check the answer",
        "Tip: You can reset the level from the menu",
        "",
        "",
        "Tip: The reset button is helpful",
        "",
        "",
        "",
        "Do you like Kuvi? Dont forget to rate us in the Play Store",
        "",
        "",
        "",
        "Become premium to disable Ads and help the developer <3",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "Final test",
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
        "Kuvi is developed by a small team. \nWe hope you love it!", 
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

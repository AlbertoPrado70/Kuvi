using UnityEngine;

public class Messages {

    public static string[] es_text = new string[50] {
        "Intenta mover el cubo azul",
        "¡Muy bien! Intentalo ahora con estos cubos",
        "Cada cubo tiene su lugar",
        "La paciencia es fundamental",
        "",
        "Utiliza los botones superiores para cambiar de nivel",
        "El orden si importa",
        "",
        "¿Estas atorado? Puedes ver la solucion del nivel desde el menu",
        "Puedes reiniciar el nivel desde el menu",
        "",
        "",
        "Recuerda que puedes reiniciar el nivel desde el menu",
        "",
        "",
        "",
        "¿Te gusta Kuvi? Recuerda darnos 5 estrellas en la Play Store",
        "",
        "",
        ":)",
        "Apoya el desarrollo de Kuvi volviendote premium y disfruta del juego sin anuncios",
        "",
        "",
        "Utiliza los botones superiores para saltarte niveles",
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
        "Jaque mate",
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
        "Prueba final",
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

    public static string[] es_ending = new string[3] {
        "De parte de todo el equipo", 
        "¡Gracias por jugar!",
        "Kuvi es posible gracias a tu apoyo. \n\nEstamos trabajando en nuevas experiencias, siguenos para estar al tanto"
    }; 

    public static string[] en_ending = new string[3] {
        "From the bottom of our hearts", 
        "Thank you for playing!",
        "We are developing more levels. \nCheck our site to know more about Kuvi",
    }; 

    public static string getLevelMessage(int level) {
        return((Application.systemLanguage == SystemLanguage.Spanish) ? es_text[level] : en_text[level]); 
    }

    public static string getMenuMessage(int message) {
        return((Application.systemLanguage == SystemLanguage.Spanish) ? es_menu[message] : en_menu[message]); 
    }

    public static string getEndingMessage(int message) {
        return((Application.systemLanguage == SystemLanguage.Spanish) ? es_ending[message] : en_ending[message]); 
    }

}

using UnityEngine;

public class Messages {

    public static string[] es_text = new string[50] {
        "Intenta mover el cubo azul",
        "¡Muy bien! Intentalo ahora con estos cubos",
        "Cada cubo tiene su lugar",
        "La paciencia es fundamental",
        "La paciencia es fundamental 2",
        "Utiliza los botones superiores para cambiar de nivel",
        "El orden si importa",
        "Un cubo tiene 6 caras",
        "¿Estas atorado? Puedes ver la solucion del nivel desde el menu",
        "Tip: Puedes reiniciar el nivel desde el menu",
        "Tip: resuelve el nivel para avanzar",
        "Movimientos minimos: 13",
        "Tip: No olvides que puedes reiniciar el nivel desde el menu",
        "Los cubos grises pueden ser solo una distraccion",
        "Movimientos minimos: 13",
        "Movimientos minimos: 16",
        "¿Te gusta Kuvi? Recuerda darnos 5 estrellas en la Play Store",
        "Movimientos minimos: 15",
        "Utiliza todos tus cubos para llegar a la solución",
        "Sonrie :)",
        "Apoya el desarrollo de Kuvi volviendote premium y disfruta del juego sin anuncios",
        "Tip: Comienza por el color amarillo",
        "Esto deberia ser facil",
        "Utiliza los botones superiores para saltarte niveles",
        "Recuerda que puedes conocer la solución desde el menu",
        "Tip: Comienza por el color azul",
        "Utiliza todos tus cubos para llegar a la solución",
        "Intenta mover los cubos grises",
        "Movimientos minimos: 13",
        "Evita atorar tus cubos",
        "Parece que el cubo azul necesita ayuda",
        "Tip: Recuerda descansar la vista cada 30 minutos",
        "Un cubo tiene 12 aristas",
        "¡Tu puedes con este nivel!",
        "¿Cuantos cuadrados hay en este nivel?",
        "Jaque mate",
        "Esos cubos azules necesitan un poco de ayuda",
        "Movimientos minimos: 37 movimientos",
        "Movimientos minimos: 29 movimientos",
        "Esta vez no sera tan facil",
        "Movimientos minimos: 34 movimientos",
        "Movimientos minimos: 18",
        "Movimientos minimos: 32",
        "Movimientos minimos: 27",
        "Movimientos minimos: 19",
        "Movimientos minimos: 22",
        "Movimientos minimos: 19",
        "Movimientos minimos: 31",
        "Movimientos minimos: 26",
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

    public static string getLevelMessage(int level) {
        return((Application.systemLanguage == SystemLanguage.Spanish) ? es_text[level] : en_text[level]); 
    }

    public static string getMenuMessage(int message) {
        return((Application.systemLanguage == SystemLanguage.Spanish) ? es_menu[message] : en_menu[message]); 
    }

}

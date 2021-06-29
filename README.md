# Desenvolupament d’un videojoc 2D de plataformes en Unity

El projecte ha consistit en el desenvolupament d’un videojoc en Unity del gènere de plataformes 2D utilitzant el llenguatge de programació C#. El jugador ha de completar un conjunt de nivells alhora que va evitant diferents obstacles i enemics per arribar a la bandera al final del nivell. El jugador també pot aconseguir una sèrie de col·leccionables, intentar superar els millors temps en cada nivell o configurar diverses opcions del joc com els gràfics, àudio o controls. Per a realitzar-lo s’ha seguit una metodologia Agile com és la de Scrum i s’han creat les diferents proves utilitzant el procés de Test-driven development. S’ha fet servir Trello per a gestionar la feina a realitzar en cada un dels sprint i s’ha creat un repositori de GitHub per al control de versions.

# Explicació del joc:
L’objectiu principal és el de superar tots els nivells del joc  intentant completar-los el més ràpid possible i col·leccionant objectes repartits pels nivells. En el videojoc el jugador controla a un personatge per a que vagi superant els nivells evitant obstacles i enemics que es va trobant durant el recorregut, hi ha un total de set nivells diferents. Per a aconseguir-ho el jugador mou i utilitza els moviments i habilitats que el personatge té a la seva disposició. Els nivells són en dues dimensions, només es pot moure de manera horitzontal o vertical, és a dir, el videojoc és de plataformes en 2D i per a només un jugador.

Quan el jugador comença o continua una partida es troba davant una pantalla principal en el que pot veure la llista de nivells del joc. El jugador només pot escollir l'últim nivell desbloquejat o repetir els que ja hagi completat anteriorment, cada cop que supera l'últim disponible se li desbloqueja un de nou. El personatge pot aprendre noves habilitats a l’arribar a certs punts del joc, les habilitats que té desbloquejades depenen del nivell que jugi. Només pot utilitzar les habilitats tres vegades, perdent un punt d’habilitat cada cop que en fa servir una. Des de la pantalla principal també pot observar els millors temps i el nombre de col·leccionables que ha obtingut en cada nivell. A l’iniciar el joc es mostra una petita cinemàtica o vídeo per explicar la història al jugador.

Un cop ha entrat dins un nivell, el jugador ja té control del personatge per moure'l per tota l’escena. El seu objectiu és desplaçar-se lateralment cap a la dreta fins a arribar a la meta. En el camí el personatge ha d'esquivar mitjançant els seus moviments a diferents obstacles, com per exemple: precipicis o plataformes en moviment. També es pot trobar a enemics controlats per la màquina que intentaran impedir que el jugador arribi a la meta. Al tocar els enemics el personatge perd un punt de vida, però poden ser derrotats saltant a sobre d’ells. Quan el personatge perd els seus tres punts de vida o cau per un precipici, reapareix al principi del nivell o al punt de control i recupera tots els punts de vida i habilitat. Una altra activitat que el jugador pot fer en els nivells és trobar col·leccionables, n’hi ha tres a cada nivell.

Quan el jugador supera l'últim nivell disponible, el jugador ha completat el joc, tot i així pot seguir jugant tots els nivells tantes vegades com vulgui, intentant obtenir millors temps o aconseguir tots els col·leccionables.

# Instal·lació:
Es recomana utilitzar la versió de Unity 2019.4.18f1 o superior.

1. Descarregar els fitxers del repositori

2. Obrir el projecte amb Unity 

3. Generar una Build

4. Iniciar el joc (TFG.exe)

# Controls:
- **Controls del personatge**:

Moviment: Fletxes de desplaçament

Dash: Q

Heal: E

Obrir / tancar menú d'opcions: M

Els controls del personatge mostrats són les tecles que venen per defecte, es poden modificar des del menú d'opcions.

- **Controls del menú**:

Moviment: Fletxes de desplaçament / WASD

Acceptar: Enter / Espai

# API para Quetzal

Equipo legends

<br>

### Endpoints:

`/`

Entrega mensaje de confirmación de que el servidor está corriendo.

<br>

## Stats

### GET

`/stats`

Entrega stats generales del juego, normalizadas.

<br>

`/stats/top10`

<br>

`/stats/runs`

## Items

### GET

`/items`

Entrega items del juego.

`/items/:id`

Entrega datos de un item específico.

<br>

## Characters

### GET

`/characters/NPCs`

Entrega NPCs del juego.

`/characters/enemies`

Entrega los enemigos del juego, incluyendo al BOSS.

`/characters/dialogs`

Entrega los diálogos del juego. INCOMPLETO, LO IDEAL SERÍA QUE EL ENDPOINT DE
NPCS COMBINE EL HECHO DE ENTREGAR DIÁLOGOS JUNTO CON LOS NPCS A LOS QUE
CORRESPONDE.

`/characters/heroes`

Entrega los héroes del juego. Los personajes principales, vaya.

<br>

## Users

### GET

`/users`

Entrega todos los jugadores que hay.

`/users/:email`

Entrega los datos del usuario que ingresó, para poder mostrarle qué sesiones
tiene.

`/users/stats/sessions`

Entrega todas las sesiones que hay.

`/users/getSessionData/:id`

Entrega los datos la sesión pasando el id. Este se obtendría al tener la
información del usuario previamente, en donde cada slot suyo tendría un id de
sesión asociado.

### POST

`/users/add`

`body: { email, user_name }`

Agrega un jugador a la base de datos.

`/users/createSession`

`body: { email, hero_id, memory_slot }`

Se crea una sesión para el usuario en cuestión. Al hacerlo, se debe pasar el
mail del usuario, el id del héroe que escogió (para agregar sus stats) y el slot
de memoria que eligió, tal cual 1, 2 o 3.

### PATCH

`/users/selectItem`

`body: { health, mana, defense, speed, damage, session_id, item_id }`

Se actualizan los stats PARA LA SESIÓN DE JUEGO, por lo que es importante pasar
el id de dicha sesión y los nuevos stats (porque agarró un item o le dio
guardar, por ejemplo). Asimismo se agrega +1 al items chosen de ese item,
entonces es importante tener su item id también.

<br>

##

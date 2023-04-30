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

Entrega una lista con los 10 mejores jugadores del juego, ordenados según la
cantidad de partidas finalizadas con éxito. Se entrega el username y la cantidad
de partidas.

<br>

`/stats/runs:email`

Entrega el promedio de estadísticas de todas las partidas de un usuario
específico, identificado por su correo electrónico.

## Items

### GET

`/items`

Entrega items del juego.

`/items/:id`

Entrega datos de un item específico.

<br>

## Characters

### GET

`/characters/heroes`

Entrega los héroes del juego. Los personajes principales, vaya.

`/characters/enemies`

Entrega los enemigos del juego, incluyendo al BOSS.

`DEPRECATED - /characters/NPCs`

Entrega NPCs del juego.

`DEPRECATED - /characters/dialogs`

Entrega los diálogos del juego.

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

`/users/endSession`

`body: { session_id }`

Termina una sesión, o sea, es cuando un jugador acaba el juego (mata al boss?).
Se pasa el id de sesión para marcar que esa sesión ya está terminada, y se le
agrega +1 a los runs del jugador, para el tema de las stats.

`/users/clearSlot`

`body: { session_id }`

Nulifica el slot del usuario en cuestión que tiene el id de sesión
correspondiente.

<br>

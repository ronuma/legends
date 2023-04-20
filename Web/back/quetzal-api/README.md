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

Entrega stats generales del juego.

<br>

## Users

### GET

`/users/:email`

Entrega los datos del usuario que ingresó, para poder mostrarle qué sesiones
tiene.

`/users/stats`

Entrega todas las sesiones que hay.

`/users/data`

Entrega todos los jugadores que hay.

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

`/users/updateStats`

`body: { health, mana, defense, speed, damage, session_id }`

Se actualizan los stats PARA LA SESIÓN DE JUEGO, por lo que es importante pasar
el id de dicha sesión y los nuevos stats (porque agarró un item o le dio
guardar, por ejemplo)

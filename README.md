# telepro-singleton-poc

En ese ejemplo se muestra cómo implementar una caché usando el patrón Singleton, para evitar tener que ir a traer datos de la Base de Datos cada vez que necesitemos mostrarlos al usuario.

El objetivo es cachear información que mostraríamos en dos campos desplegables de un formulario relacionados uno con el otro.

Se proporcionan dos ejemplos:

- vb-singleton: implementación de la caché en VB.net
- csharp-singleton: implementación de la caché en C#

La salida de ambos programas es la misma.

```
LOADING DATA FROM DATABASE ....
[x] Loading planets ....
[x] Loading satellites ....
[x] Caching data ....
FETCHING DATA FROM CACHE ....
[x] Loading cache instance ....
[x] Printing cached data
- Mercury
    Mercury has no satellites
- Venus
    Venus has no satellites
- Earth
    * Moon
- Mars
    * Phobos
    * Deimos
- Jupiter
    * Metis
    * Adrastea
    * Amalthea
    * Thebe
- Saturn
    * Pan
    * Daphnis
    * Atlas
    * Prometheus
- Uranus
    * Ariel
    * Umbriel
    * Titania
    * Oberon
- Neptune
    * Triton
    * Nereid
    * Naiad
    * Thalassa

```

Se pueden distinguir dos fases.

- Consultar los datos de la BD y almacenarlos en la caché. En el ejemplo no estamos accediendo a una BD real, sólo lo simulamos. Esta fase se ejecutaría nada más arrancar el servidor, de este modo tendremos los datos almacenados en la memória.
- Mostr los datos al usuario. En este caso mostramos todos los planetas del sistema solar (primer campo desplegable) y los satélites naturales de cada uno de ellos.



## Estructura del código

En cada uno de los programas encontraremos tres ficheros:

- `CachedData`. Representa la estuctura que tendremos almacenada en memoria conteniendo los datos para rellenar los distintos *desplegables*.
- `CacheExample`. Representa un objeto de tipo Singleton que contiene la estructura de datos representada por `CachedData` y garantiza que va a existir una única instancia accesible por los ditintos *threads* de la aplicación.
- `Program`. Programa que realiza las siguientes acciones.
	- simula que recupera los datos de la BD
	- almacena los datos recuperados en la caché
	- obtiene una instancia de la caché
	- muestra por todos los valores para el primer *desplegable*
	- muestra por pantalla los valores que contendría el segundo *desplegable* según se seleccione un valor del primero.

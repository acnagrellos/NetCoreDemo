1. Diseñe y escriba los endpoints que serán utilizados en una API que tendrá estos requisitos.

Una empresa de autobuses quiere que sus clientes puedan acceder a la información de sus viajes:

* Se podrá acceder a una lista de clientes. Esta lista será paginada. Los clientes se podrán editar, borrar y consultar.

Para este punto los endpoints que podemos crear son:

```
GET /customers?page={numpage}
GET /customers/{id}
PUT /customers/{id}
DELETE /customers/{id}
```

* Para poder registrarse hará falta que el cliente suba una foto de carnet suya.

En este punto podría haber dos soluciones. Poner dos endpoints, uno con el POST del usuario y otro con la subida de la imagen o poner un endpoint que en el body lo lleve todo. En este caso optaremos por los 2 endpoints:

POST /customers
POST /customers/{id}/image 

* Los clientes tendrán acceso a sus viajes. Estos podrán ser consultados pero nunca eliminados.

Los endpoints de los viajes de los viajeros tendrán que ir debajo en la estructura de los clientes, ya que son de los propios clientes:

```
GET /customers/{customerId}/trips
GET /customers/{customerId}/trips/{tripId}
```

* Un cliente puede comprar un viaje. Una vez comprado el viaje no se puede modificar. Para comprar un viaje puede acceder al catálogo de rutas de la compañía.

Habrá un catálogo de rutas de la compañía y un POST para que el cliente pueda crear un viaje:

```
GET /routes
POST /customers/{customerId}/trips => En el cuerpo del mensaje le pasaremos la ruta.
```

* Para poder comprar un viaje, el cliente puede seleccionar y ver las prestaciones que ofrece el asiento. El asiento ofrecerá de pestaciones: pasillo/ventana, tablet, calefacción, viaje con agua incluída o no.

Toda esa información irá en la llamada post anterior; pero tendremos que crear una llamada get que nos de las características de los asientos disponibles en la ruta seleccionada.

```
GET /routes/{routeid}/trip => con esto podremos acceder a un viaje concreto de un día/hora concreto con las características del bus para poder seleccionar el viaje.
POST /customers/{customerId}/trips => Actualizar body.
```

* Los conductores de autobús tendrán acceso a la lista de pasajeros del viaje. Podrán ver el dni del pasajero y su asiento.

```
GET /routes/{routeid}/trip/{tripId}/passengers => Los pasajeros tendrán una estructura diferente a un cliente normal, ya que aquí se indicará su número de asiento y su DNI.
```
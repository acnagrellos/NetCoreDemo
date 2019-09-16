1. Analice estos nombres de URLs y exponga si son correctas o no y por qué.

* PUT /users/56/edit ❌ => PUT users/56 (no se permiten verbos en las URIs)
* GET /user/56 ❌ => GET /user<b>s</b>/56 (es mejor poner los nombres en plural)
* DELETE /users/ ❌ => DELETE users/56 (sería peligroso esta llamada, ya que borraría todos los usuarios del sistema. Mejor borrar por registro)
* GET /users/56 ✔️
* PUT /user/45  ❌ => PUT user<b>s</b>/45 (el plural de nuevo)
* POST /users/create ❌ => POST /users (sin el verbo)
* POST /user/create ❌ => POST /users (sin el verbo y en plural)
* GET /users/56/invoice ❌ => GET users/56/invoices (en plural)
* PUT /users/34 ✔️
* POST /users/54 ✔️
* DELETE /users/delete/43 ❌ => DELETE users/43 (sin el verbo)
* GET /users/page/2 ❌ => GET /users?page=2 (los parámetro de filtro por QueryString)
* GET /users/654/image.png ❌ => GET /users/654/image (sin formato. El formato irá en las cabeceras)
* GET /users?page=2?order=DESC ❌ => GET /users?page=2<b>&</b>order=DESC
* GET /users/invoice/67/3 ❌ => /users/67/invoices/3 (el order de los parámetros de ruta era incorrecto)
* GET /users/?page=2 ❌ => /users?page=2 (Sin barra cuando va una ?)
* GET /users?page=2&order=ASC ✔️
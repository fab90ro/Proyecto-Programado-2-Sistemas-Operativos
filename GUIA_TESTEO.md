# Guia corta de uso y pruebas - BUS UH

## 1. Requisitos

- Tener instalado `.NET 9 SDK`.
- Abrir la solucion `BusUH.sln` en Visual Studio 2022 o superior.

## 2. Proyectos del sistema

- `BusUH.Server`: aplicacion servidor con mantenimiento de terminales, viajes y socket.
- `BusUH.Client`: aplicacion cliente para conectarse y enviar tramas.
- `BusUH.Core`: logica compartida del negocio.

## 3. Como ejecutar

### Opcion A: desde Visual Studio

1. Abrir `BusUH.sln`.
2. Ejecutar primero `BusUH.Server`.
3. En una segunda ejecucion, iniciar `BusUH.Client`.

### Opcion B: desde terminal

1. Servidor:
   `dotnet run --project .\BusUH.Server\BusUH.Server.csproj`
2. Cliente:
   `dotnet run --project .\BusUH.Client\BusUH.Client.csproj`

## 4. Datos iniciales

El sistema ya carga estos viajes por defecto:

- `01` - San Jose -> El Coco - Capacidad `67` - Costo `3500`
- `02` - El Coco -> San Jose - Capacidad `67` - Costo `4000`

## 5. Uso del servidor

En la ventana del servidor hay 3 pestanas:

### Mantenimiento de Terminales

- Permite registrar o editar terminales en memoria.
- Digite codigo y nombre.
- Presione `Guardar`.

### Mantenimiento de Viajes

- Permite registrar o editar viajes.
- Digite:
  - codigo de viaje,
  - terminal de salida,
  - terminal de llegada,
  - capacidad,
  - costo.
- Presione `Guardar viaje`.
- A la derecha se ve la disponibilidad de asientos por fila.

### Socket de Comunicacion

- Verifique que el puerto sea `30000`.
- Presione `Iniciar socket`.
- La bitacora mostrara conexiones y solicitudes.
- Tambien se muestra la cantidad de clientes conectados.

## 6. Uso del cliente

1. Digite la IP: `127.0.0.1`
2. Digite el puerto: `30000`
3. Presione `Conectar`
4. Seleccione:
   - codigo de viaje (`01` o `02`)
   - cantidad de boletos (`1` a `5`)
5. Presione `Generar trama`
6. Presione `Enviar al servidor`
7. Revise:
   - la trama de respuesta,
   - la interpretacion,
   - y la bitacora del cliente.

## 7. Formato de la trama enviada

La trama del cliente tiene 3 digitos:

- `01-02`: codigo del viaje
- `03`: cantidad de boletos

Ejemplos:

- `011` = viaje `01`, 1 boleto
- `014` = viaje `01`, 4 boletos
- `025` = viaje `02`, 5 boletos

## 8. Casos de prueba recomendados

### Caso 1: compra exitosa

1. Inicie servidor y cliente.
2. En el cliente envie `014`.
3. Resultado esperado:
   - respuesta con estado `1`
   - monto `14000`
   - disminuye la capacidad disponible
   - el servidor registra la solicitud en la bitacora

### Caso 2: excede la cantidad maxima

1. Escriba manualmente en la trama: `016`
2. Resultado esperado:
   - respuesta con estado `3`
   - mensaje de maximo 5 boletos

### Caso 3: codigo de viaje inexistente

1. Escriba manualmente en la trama: `991`
2. Resultado esperado:
   - respuesta con estado `4`

### Caso 4: formato invalido

1. Escriba manualmente en la trama: `0A4`
2. Resultado esperado:
   - respuesta con estado `5`

### Caso 5: agotar asientos

1. Envie multiples compras del viaje `01` hasta consumir los asientos disponibles.
2. Cuando no queden espacios, envie otra solicitud.
3. Resultado esperado:
   - respuesta con estado `0`

## 9. Observaciones

- Toda la informacion se maneja en memoria, tal como pide el documento.
- Al cerrar la aplicacion, los datos se reinician.
- La fila 13 tiene 7 asientos; las filas 1 a la 12 tienen 5 asientos.

## 10. Explicacion general de la logica del programa

El sistema esta dividido en 3 partes:

- `BusUH.Server`: contiene la interfaz del servidor, el mantenimiento de terminales y viajes, y el socket que escucha las solicitudes del cliente.
- `BusUH.Client`: contiene la interfaz del cliente para conectarse al servidor, enviar la trama y mostrar la respuesta.
- `BusUH.Core`: contiene la logica del negocio compartida, por ejemplo el manejo de viajes, asientos, validaciones y construccion de la trama de respuesta.

### Flujo general

1. El servidor inicia con dos terminales y dos viajes precargados.
2. Cada viaje tiene:
   - codigo,
   - terminal de salida,
   - terminal de llegada,
   - capacidad,
   - costo,
   - y una matriz de asientos.
3. La matriz de asientos representa la disponibilidad del bus:
   - filas 1 a 12 con 5 asientos,
   - fila 13 con 7 asientos.
4. Cuando el usuario del cliente genera una trama, por ejemplo `014`, eso significa:
   - viaje `01`
   - solicitud de `4` boletos
5. El cliente envia esa trama al servidor por medio de `TCP` al puerto `30000`.
6. El servidor recibe la trama y la procesa con la logica de negocio.

### Validaciones que realiza el servidor

Cuando llega una solicitud, el servidor revisa:

- si la trama tiene el formato correcto,
- si el codigo de viaje existe,
- si la cantidad de boletos esta entre 1 y 5,
- y si todavia hay capacidad disponible en el viaje.

Segun el resultado, devuelve un codigo de estado:

- `1`: transaccion exitosa
- `0`: no hay asientos disponibles
- `3`: excede el maximo de 5 boletos
- `4`: el viaje no existe
- `5`: formato invalido

### Asignacion de asientos

Si la compra es valida, el servidor recorre el arreglo de asientos del viaje en orden:

1. Busca espacios libres desde la fila 1 en adelante.
2. Va marcando los asientos ocupados conforme los vende.
3. Si todos los boletos caben en una sola fila, solo usa `Fila 1` en la respuesta.
4. Si no caben en una sola fila, continua en la siguiente fila y usa tambien `Fila 2` en la respuesta.
5. Luego actualiza la capacidad disponible del viaje.

### Respuesta al cliente

Despues de procesar la compra, el servidor arma una trama de respuesta con:

- codigo de estado,
- codigo del viaje,
- fila y asientos asignados,
- monto total de la transaccion,
- capacidad disponible restante.

El cliente recibe esa trama y la interpreta en pantalla para que el usuario no tenga que leerla manualmente.

### Bitacora y monitoreo

El servidor tambien funciona como monitor del proceso:

- muestra cuantos clientes hay conectados,
- registra cada solicitud recibida,
- muestra la trama enviada,
- muestra la respuesta generada.

Esto permite comprobar facilmente durante las pruebas que la comunicacion por socket y la logica de venta estan funcionando correctamente.

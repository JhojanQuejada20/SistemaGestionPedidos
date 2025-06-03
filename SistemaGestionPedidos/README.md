
# Sistema de Gestión de Pedidos de Restaurante - Docker

Este proyecto contiene dos microservicios:

- `MicroservicioDePedidos` (C#)
- `InventarioService` (C#)

Juntos forman un sistema que permite gestionar pedidos y verificar inventario. Toda la arquitectura está basada en **arquitectura hexagonal**, con comunicación asincrónica mediante **RabbitMQ**, y persistencia en **PostgreSQL**.

------------------------------------------------------------------------------------------------------------------------------

## Requisitos

- Docker
- Docker Compose

------------------------------------------------------------------------------------------------------------------------------

## Instrucciones para ejecutar con Docker Compose

1. **Clona o descomprime el proyecto:**

```bash
git clone https://github.com/tuusuario/SistemaGestionPedidos.git
cd SistemaGestionPedidos
------------------------------------------------------------------------------------------------------------------------------

2. **Construye e inicia los contenedores:**

```bash
docker-compose up --build
```

Esto levantará los siguientes servicios:

- `pedidos-service` (Puerto: 5001)
- `inventario-service` (Puerto: 5002)
- `postgres` (Puerto: 5432)
- `rabbitmq` (Puerto: 15672, usuario: guest / guest)

------------------------------------------------------------------------------------------------------------------------------
3. **Verifica los servicios:**

| Servicio           | URL                             |
|--------------------|----------------------------------|
| API Pedidos        | http://localhost:5001/swagger    |
| API Inventario     | http://localhost:5002/swagger    |
| RabbitMQ Admin     | http://localhost:15672           |

---

## Variables de entorno

Configuradas directamente en el código:

- `POSTGRES_USER=postgres`
- `POSTGRES_PASSWORD=postgres`
- `POSTGRES_DB=pedidosdb / inventariodb`

---

## Pruebas

Para ejecutar las pruebas de ambos microservicios:

```bash
docker exec -it pedidos-service dotnet test
docker exec -it inventario-service dotnet test
```

---

## Apagar los contenedores

```bash
docker-compose down
```

---

## Estructura de carpetas (resumen)

```
SistemaGestionPedidos/
│
├── MicroservicioDePedidos/
│   ├── Dockerfile
│   └── ...
│
├── InventarioService/
│   ├── Dockerfile
│   └── ...
│
├── docker-compose.yml
└── README.md
```

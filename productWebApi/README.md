# 🚀 Product Web API

## 📌 Descripción

API REST desarrollada en **.NET 8 (ASP.NET Core)** para la gestión de productos.
Incluye operaciones CRUD, persistencia en base de datos MySQL y despliegue en la nube.

El proyecto fue diseñado aplicando buenas prácticas de desarrollo backend, separación de responsabilidades y enfoque en escalabilidad.

---

##  API en producción

URL pública:
https://productwebapi-production.up.railway.app

Swagger:
https://productwebapi-production.up.railway.app/swagger

GitHub
https://github.com/galvanmancerajavier/productWebApi.git

---

## Tecnologías utilizadas

* .NET 8 (ASP.NET Core Web API)
* Entity Framework Core
* MySQL
* Docker
* Railway (deploy en la nube)

---

## Arquitectura

El proyecto sigue una arquitectura por capas:

* **Controllers** → Exponen los endpoints HTTP
* **Services** → Contienen la lógica de negocio
* **Repository** → Acceso a datos
* **Models / DTOs** → Representación de datos

Esto permite:

* Separación de responsabilidades
* Mayor mantenibilidad
* Facilidad de escalabilidad

---

##  Decisiones técnicas

* Se utilizó **Entity Framework Core** por su integración nativa con .NET
* Se eligió **MySQL** por facilidad de despliegue en la nube (Railway)
* Se implementó **Docker** para garantizar portabilidad
* Se estructuró en capas para mantener un código limpio y organizado

---

## Ejecución local

### 1. Clonar repositorio

```bash
git clone https://github.com/galvanmancerajavier/productWebApi.git
cd productWebApi
```

---

### 2. Configurar conexión a base de datos

Editar `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=HOST;Port=PORT;Database=DB;User=USER;Password=PASSWORD;"
}
```

---

### 3. Ejecutar migraciones

```bash
dotnet ef database update
```

---

### 4. Ejecutar la aplicación

```bash
dotnet run
```

---

## Ejecución con Docker

### Construir imagen

```bash
docker build -t product-api .
```

### Ejecutar contenedor

```bash
docker run -p 8080:80 product-api
```

---

## 🧪 Endpoints principales

| Método | Endpoint           |
| ------ | ------------------ |
| GET    | /api/Products      |
| GET    | /api/Products/{id} |
| POST   | /api/Products      |
| PUT    | /api/Products/{id} |
| DELETE | /api/Products/{id} |
| PATCH  | /api/Products/{id}/decrease-stock |
| PATCH  | /api/Products/{id}/increase-sttock|

---

## 📦 Estructura del proyecto

```
productWebApi/
│── Controllers/
│── Services/
│── Repositories/
│── Models/
│── AppData/
│── Dockerfile
│── Program.cs
```

---

##  Despliegue

La aplicación se encuentra desplegada en Railway.

Se utilizó Docker para asegurar que el entorno de ejecución sea consistente entre desarrollo y producción.

---

##  Estado del proyecto

✔ API funcional
✔ CRUD completo
✔ Base de datos conectada
✔ Despliegue en la nube
✔ Documentación Swagger

---

## 👨‍💻 Autor

Desarrollado como prueba técnica backend. Javier Galvan Mancera. 
Nota: El servicio de MySQL proporcionado por Railway tiene una duración de 24 horas a partir de la creación, por tanto expirará el día 30/04/2026 3:00Pp.m

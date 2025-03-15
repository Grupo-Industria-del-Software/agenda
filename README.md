# 🗓️ Agenda

## 🚀 **Pasos para levantar el proyecto**

### 1️⃣ **Levantar la base de datos en Docker**
Ejecuta el siguiente comando en la carpeta `Infra/db-agenda`:

```
cd Infra/db-agenda
docker compose up -d
```

### 2️⃣ **Restaurar herramientas de .NET (si es necesario)**
Si no tienes instaladas las herramientas de EF Core, ejecuta:

```
dotnet tool restore
```

### 3️⃣ **Configurar variables de entorno**
Copia el contenido del archivo `example.env` en un archivo `.env` dentro del proyecto `API`


### 4️⃣ **Crear la migración inicial y actualizar la base de datos**
Ejecuta los siguientes comandos para crear la migración y actualizar la base de datos:

```
dotnet ef migrations add InitialMigration --project Infrastructure --startup-project API
dotnet ef database update --project Infrastructure --startup-project API
```


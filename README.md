# 📝 To-Do App - Vue + .NET Core

Aplicación web de gestión de tareas desarrollada con **Vue.js** en el frontend y **ASP.NET Core Web API** en el backend.  
El frontend está desplegado en **Netlify** y el backend en **Azure App Service**.

---

## 🚀 Demo en producción

- 🔗 **Frontend (Netlify):** [[https://to-dou.netlify.app](https://to-dou.netlify.app/)]
- 🔗 **Backend (Azure):** [[https://backend-to-to-service.azureebsites.net/api/Tarea](https://backend-to-to-service.azurewebsites.net/api/tarea)]


---

## 📌 Características

- Crear, listar, editar y eliminar tareas.
- Persistencia a través de API REST con Axios.
- Diseño responsivo con Bootstrap.
- Iconografía de estado con Font Awesome.
- Integración y despliegue continuo en Netlify y Azure.

---

## 🛠️ Tecnologías utilizadas

### Frontend

- [Vue.js 3](https://vuejs.org/)
- [Axios](https://axios-http.com/)
- [Bootstrap 5](https://getbootstrap.com/)
- [Font Awesome](https://fontawesome.com/)

### Backend

- [ASP.NET Core Web API (.NET 6 o superior)](https://dotnet.microsoft.com/)
- [Entity Framework Core](https://learn.microsoft.com/ef/core/)
- [CORS habilitado para comunicación entre dominios]

---

## ⚙️ Requisitos previos

- Node.js ≥ 16.x
- .NET SDK ≥ 6.0
- Visual Studio o VS Code
- Cuenta de Azure (opcional para deploy)
- Cuenta en Netlify (opcional para deploy)

---

## 🧑‍💻 Instrucciones de desarrollo

### 🟢 Backend (.NET Core)

```bash
cd backend   # carpeta que contiene el .csproj
dotnet restore
dotnet run
```
### 🔵 Frontend (Vue.js)

```bash
cd frontend  # carpeta con el proyecto Vue
npm install
npm run dev
```
## 🌐 Despliegue
  - 📤 Backend en Azure
Se publicó como Web App con API Management (ruta: /api/Tarea).

Asegurarse de configurar CORS en el backend para permitir el dominio de Netlify.

  - 📤 Frontend en Netlify
Se publicó el contenido del dist/ tras ejecutar npm run build.

En netlify.toml o configuración del dashboard, se puede definir redirección y entorno (VITE_API_URL si usás Vite).

## 📎 Notas
  - Al editar una tarea se invierte su estado (state: true/false).

  - Los íconos de tareas completadas usan fa-circle-check y las pendientes fa-circle.

  - El botón de carga (spinner-border) se activa durante las operaciones asincrónicas.

# 📋 TaskManager API

A simple and efficient ASP.NET Core Web API project built for managing tasks.  
Created by **Anas Mohamed** as part of a developer challenge / personal growth project.

---

## 🚀 Features

- ✅ Get all tasks
- 📌 Get a specific task by ID
- ➕ Create a task
- ✏️ Update a task
- 🗑️ Delete a task
- 🔍 Swagger UI support for live testing

---

## 📂 Endpoints

| Method | Route                | Description           |
|--------|----------------------|-----------------------|
| GET    | `/api/tasks`         | Get all tasks         |
| GET    | `/api/tasks/{id}`    | Get task by ID        |
| POST   | `/api/tasks`         | Create a new task     |
| PUT    | `/api/tasks/{id}`    | Update a task         |
| DELETE | `/api/tasks/{id}`    | Delete a task         |

---

## 🛠️ Technologies Used

- ASP.NET Core Web API (.NET 6 / .NET 8)
- C#
- Entity Framework Core
- SQL Server
- Swagger

---

## 💻 How to Run Locally

1. Clone the repository  
   `git clone https://github.com/aamohamedo/TaskManagerApi.git`

2. Navigate into the project  
   `cd TaskManagerApi`

3. Restore dependencies/ Rebuild Solution  
   `dotnet restore`

4. Run the application  

5. Open Swagger UI in your browser:  
   👉 [https://localhost:7007/swagger](https://localhost:7007/swagger)

---

## 📘 Example Task Payload (PUT)

```json
{
  "id": 1,
  "title": "football",
  "description": "Need to go football",
  "status": "In Progress",
  "dueDate": "2025-04-15T18:00:00"
}

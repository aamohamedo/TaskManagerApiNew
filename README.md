# 🧠 Task Manager API

This is the **backend API** for the Task Manager system. It is built using **ASP.NET Core Web API** and provides RESTful endpoints to manage tasks (create, read, update, delete).

> ⚠️ **Note:** This API must be running before launching the [TaskManagerFrontend](https://github.com/aamohamedo/TaskManagerFrontend) application.

---

## 📋 Features

✅ Get all tasks  
✅ Get a single task by ID  
✅ Create a new task  
✅ Update an existing task  
✅ Delete a task  
✅ Built-in validation and error handling  
✅ XML documentation enabled for all endpoints  
✅ Swagger UI for interactive API documentation

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

## 🛠 Tech Stack

- **ASP.NET Core Web API** (.NET 8)
- **Entity Framework Core** (Code First)
- **SQL Server LocalDB**
- **Swagger / Swashbuckle.AspNetCore**
- **xUnit + Moq** for unit testing

---

## 💻 How to Run Locally

1. Clone the repository  
   `git clone https://github.com/aamohamedo/TaskManagerApiNew`

2. Navigate into the project  
   `cd TaskManagerApi`

3. Restore dependencies / Rebuild solution  
   `dotnet restore`

4. Run the application  
   `dotnet run`

5. Open Swagger UI in your browser:  
   👉 [https://localhost:7017/swagger](https://localhost:7017/swagger)

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
```

---

## 🧪 Unit Testing

This API is unit tested using:
- **xUnit** – for writing tests
- **Moq** – for mocking `HttpClient` and simulating API responses

Test coverage includes:
- Retrieving all tasks
- Getting a task by ID
- Creating a task

To run the tests:
```bash
dotnet test
```

---

## 📖 API Documentation

Swagger UI is enabled and documents all routes with request/response samples. 
Navigate to: `https://localhost:7017/swagger/index.html`

---

## 📦 Future Improvements

- Add authentication (JWT)
- Extend validation logic
- Add integration tests
- Add pagination/filtering support

---

## 🔗 Related
- Frontend repo: [TaskManagerFrontend](https://github.com/aamohamedo/TaskManagerFrontend)

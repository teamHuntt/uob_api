# Library Management System API

A simple Web API for managing books, members, and borrow/return records using ASP.NET Core, Entity Framework, and C#.

## **Project Overview**

This API allows you to:
- Manage books (add, update, delete, list)
- Manage members (add, update, delete, list)
- Borrow and return books
- Track borrow records

- All APIs return a **standardized `ApiResponse<T>`** for consistency.

- ## **Tech Stack**

- ASP.NET Core 8 Web API
- Entity Framework Core (Code-First)
- SQL Server (or any EF-supported database)
- C# 12
- Dependency Injection & Generic Repository pattern
- Middleware for global exception handling and CORS

Note: On first migration, the database will be automatically seeded with:

5 sample books
1 default member

- ## **Setup Instructions**

- 1. Clone the repository:

```bash
1.
git clone https://github.com/yourusername/library-management-api.git](https://github.com/teamHuntt/uob_api.git

2.
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=LibraryDB;Trusted_Connection=True;"
}

3..Run EF Migrations:

//For migrations run 
dotnet ef database update


| Method | URL                    | Description             |
| ------ | ---------------------- | ----------------------- |
| GET    | `/api/books`           | Get all books           |
| GET    | `/api/books/{id}`      | Get a book by ID        |
| GET    | `/api/books/available` | Get all available books |
| POST   | `/api/books`           | Create a new book       |
| PATCH  | `/api/books/{id}`      | Update book             |
| DELETE | `/api/books/{id}`      | Delete book             |


| Method | URL                 | Description      |
| ------ | ------------------- | ---------------- |
| GET    | `/api/members`      | Get all members  |
| GET    | `/api/members/{id}` | Get member by ID |
| POST   | `/api/members`      | Create member    |
| PATCH  | `/api/members/{id}` | Update member    |
| DELETE | `/api/members/{id}` | Delete member    |


| Method | URL                                    | Description                        |
| ------ | -------------------------------------- | ---------------------------------- |
| POST   | `/api/memberrecords/borrow`            | Borrow a book                      |
| POST   | `/api/memberrecords/return`            | Return a book                      |
| GET    | `/api/memberrecords`                   | Get all borrow records             |
| GET    | `/api/memberrecords/member/{memberId}` | Get all borrow records of a member |

Notes

All POST and PATCH endpoints use application/x-www-form-urlencoded or application/json.

Borrowing a book automatically marks it as unavailable; returning marks it available.

Global exception handling middleware provides consistent error responses.




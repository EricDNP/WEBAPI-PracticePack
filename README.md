# WEBAPI-PracticePack

# PracticePack - Cloud-Native Product Delivery API

PracticePack is a serverless product delivery application built on top of AWS Lambda using .NET 8, following the principles of **Hexagonal Architecture** to ensure strong separation of concerns, high scalability, and ease of testing.

## 🎓 Project Overview

This system manages:
- **User authentication & role-based authorization**
- **Product listing and ordering**
- **Payments and deliveries**
- **CRUD operations for all business entities**

All Lambda functions are deployed via **AWS SAM**, and the relational data is hosted in **Amazon RDS (SQL Server)**.

---

## 🚀 Architecture Overview

The solution follows **Hexagonal Architecture (Ports & Adapters)**, broken into four main layers:

```
┌────────────────────────────┐
│     AWS Lambda Functions   │ ◄── Entry point / Adapters
└────────────┬───────────────┘
             │
┌────────────▼──────────────┐
│      Application Layer     │ ◄── UseCases, Interfaces, Mappings
└────────────┬──────────────┘
             │
┌────────────▼──────────────┐
│       Domain Layer         │ ◄── Entities, ValueObjects, Ports
└────────────┬──────────────┘
             │
┌────────────▼──────────────┐
│     Infrastructure Layer   │ ◄── Repositories, EF DbContext, Services
└────────────────────────────┘
```

Each Lambda handles a specific entity's CRUD operation using a **Router pattern** to support multiple HTTP methods per function.

---

## 🏃️ Workflows

### Authentication Flow
1. `/login` and `/register` endpoints in `LMBUserAuthentication`
2. Generates a JWT with claims: `UserId`, `Role`, `Email`
3. JWT token is validated manually in protected endpoints via `Authorization` header

### Product Ordering
1. Users browse products via `LMBProductCRUD`
2. Users create orders using `LMBOrderCRUD`
3. Payments are processed via `LMBPaymentCRUD`

---

## 🚚 Deployment Stack

- **Compute**: AWS Lambda (via AWS SAM)
- **API Gateway**: AWS HTTP API (v2)
- **Database**: Amazon RDS (SQL Server Express)
- **IAM**: Roles created for Lambda execution and RDS access

---

## ⚖️ Technologies Used

- **.NET 8 / C#**
- **Entity Framework Core**
- **AutoMapper**
- **JWT Token Auth (manual parsing)**
- **AWS SAM (Serverless Application Model)**
- **SQL Server on Amazon RDS**
- **Multipart/Form-data support via `HttpMultipartParser`**

---

## 📂 Project Structure

```bash
/Domain
  /Entities (Address, Product, User...)
  /Interfaces (Ports - Repositories)

/Application
  /UseCases (Per entity)
  /Mappings (AutoMapper Profiles)
  /Interfaces (Services like Encryptor, Auth)

/Infrastructure
  /Repositories (EFCore implementations)
  /Context (PracticePackDbContext)
  /Services (EncryptorService, AuthenticationService)

/Serverless
  /Lambdas (One per entity - each has Router.cs)
  template.yaml (AWS SAM configuration)
```

---

## 🔐 Authentication & Authorization

- JWT tokens are created on login.
- Stored claims: `sub` (UserId), `role`, `email`
- Validation occurs manually in each Lambda by decoding `Authorization` header
- Role-based access (e.g., `Admin`, `User`) is possible via claims

---

## 🔖 Key Entities

### User & Person
```csharp
User: Id, Username, Email, PasswordHash, Role
Person: Id, UserId (FK), Name, Lastname, Phone
```

### Product, Order & Payment
```csharp
Product: Id, Name, Description, Price, Image (Base64)
Order: Id, UserId, List<OrderItem>
Payment: Id, OrderId, Method, Status
```

---

## 🚧 Environment Variables

Set in `template.yaml`:
```yaml
Jwt__Secret: <Base64 256-bit key>
Jwt__Issuer: PracticePack.auth
Jwt__Audience: PracticePack.api
ConnectionStrings__DefaultConnection: <RDS connection string>
Encryptor__Key: <AES Key>
Encryptor__IV: <AES IV>
```

---

## 🚒 API Testing

- Postman collection available under `/docs/Postman/`
- Sample JSON bodies and headers provided per endpoint

---

## 🚧 Local Testing with AWS SAM

```bash
sam build
sam local start-api
```
- Test locally with your real API Gateway routes

---

## 🌟 Final Notes

- Full Hexagonal Architecture using AWS Lambdas ✅
- All UseCases tested via DI ✅
- RDS-connected EF Core Context ✅
- Fully compatible with CI/CD and GitHub Actions ✅

---

> Designed with scalability, testability, and serverless deployment in mind — built like a modern AWS-ready microservice system ✨


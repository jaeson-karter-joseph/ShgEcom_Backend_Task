# MongoDB EF Core Using Clean Architecture

A comprehensive solution for managing products & leveraging .NET Core with MongoDB, Clean Architecture, and CQRS patterns. The application is designed to manage products while also supporting a variety of other features to streamline products management and improve efficiency.

## Features

### 1. **MongoDB Integration**
   - **Guid-based Entity IDs**: The application uses `Guid` for unique identifiers and integrates seamlessly with MongoDB as the primary data store.
   - **CRUD Operations**: Full Create, Read, Update, and Delete operations are implemented for all entities (products, clients, instructors, etc.).
   - **Soft Deletes**: Products, clients, and instructors can be marked as "soft deleted", allowing for recovery without permanent deletion.

### 2. **CQRS Pattern**
   - **Separation of Read and Write Models**: The app implements Command Query Responsibility Segregation (CQRS) to separate commands (write operations) and queries (read operations).
   - **Mediator Pattern**: Commands and Queries are handled by the Mediator pattern to further decouple dependencies and improve maintainability.

### 3. **Product Management**
   - **Create, Update, Soft Delete Products**: Manage the studio's offerings such as classes, products, and services. Easily update the details of these products or mark them as deleted.
   - **Get Active/Out of Stock Products**: Retrieve active products or out-of-stock products based on the stock quantity and delete status.
   - **Tag-Based Product Filtering**: Filter products by tags to facilitate category-based search.
   - **Soft Deletion**: Mark products as deleted without removing them from the database, enabling potential restoration if necessary.
   
### 4. **Clean Architecture**
   - **Separation of Concerns**: The project follows the Clean Architecture pattern, ensuring that the business logic is decoupled from infrastructure and UI code.
   - **Testable Code**: With layers clearly separated, unit tests and integration tests can be easily written for each component.
   - **Maintainability**: The project’s modular structure ensures that new features or changes can be added with minimal impact on other parts of the system.

### 5. **Swagger Documentation**
   - The project includes Swagger UI, which automatically generates interactive API documentation for all endpoints.
   - **Easy-to-Use API Endpoints**: The Swagger interface provides a user-friendly way to explore the API, test endpoints, and view responses.

### 6. **CORS Support**
   - The project has been configured to handle Cross-Origin Resource Sharing (CORS), enabling it to communicate with front-end applications hosted on different domains.

### 7. **Authentication & Authorization**
   - **JWT Authentication**: Secure endpoints using JSON Web Tokens (JWT). Only authenticated users can access sensitive data or make changes to the database.
   - **Role-based Authorization**: Users are assigned roles such as Admin, Instructor, and Client to control access to specific areas of the system.

## Benefits

1. **Scalability**: 
   - MongoDB provides a flexible and scalable data store that can easily handle growing amounts of data as the business grows.
   
2. **Flexibility in Management**: 
   - Soft delete functionality allows for easy restoration of data, providing flexibility to reverse accidental deletions.
   
3. **Improved Maintainability**: 
   - Using the Clean Architecture and CQRS patterns helps keep the codebase clean and easier to maintain, while also improving scalability.
   
4. **Reduced Complexity**: 
   - By separating commands and queries, we reduce the complexity of the application, making it more efficient and easier to understand.
   
5. **Faster Development**: 
   - The use of an easily extensible architecture with pre-built modules allows developers to add new features without a steep learning curve.
   
6. **Security**: 
   - JWT-based authentication provides a secure and stateless way to handle user sessions, while role-based authorization ensures that users can only access the resources they are allowed to.

7. **Integration with Front-end**: 
   - With CORS support and a well-documented API, the project is ready for integration with any front-end framework or service.

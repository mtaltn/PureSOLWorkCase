
# Check Activities Project

This project was developed to record the activities of the users in the system with the help of restful api.

## Kullanılan Pattenler

● Repository Pattern: Abstracts database transactions so that database transactions are not trapped in code and are reusable and testable.

● Unit of Work Pattern: Manages multiple repository transactions as a single transaction, so that transactions are performed atomically and database transactions are consistent.

● Strategy Pattern: Encapsulates different algorithmic strategies under one interface, thus providing a flexible structure that can be modified at runtime.

● Decorator Pattern: A structural design pattern, allows behavior to be added to objects dynamically without affecting the behavior of other objects from the same class. It's useful for extending functionality in a flexible and reusable way by wrapping objects with new behaviors or responsibilities.

## Api Gateway

● Ocelot Api Gateway: An API gateway solution used as an entry point in microservice architectures, routing and managing incoming requests.

## Security

● JTW Token: Uses JSON Web Token for authentication and authorization, providing a secure and scalable authentication mechanism.

● Data Transfer Object: Objects used for data transfer, usually data structures used for data transfer.

## Data Management

● Entity Framework: An ORM (Object-Relational Mapping) solution that makes database operations suitable for object-oriented programming.

## Additional Features

● Seed Data: Used to add initial data to the database, it provides data preparation when the application first starts.

● IEntityTypeConfiguration: An interface used with the Entity Framework, determines how database tables are structured, programmatically manages the database schema. 

## Optional Features (not included in the project)

● Exceptionhandler: Handles exceptions that may occur in the application and handles them appropriately, providing clear error messages to the user.

● Middleware: Software components used in software development processes to process HTTP requests, representing each stage in the request processing chain and increasing the modularity, flexibility and reusability of the application. Each middleware performs a specific function (e.g. authentication, logging, error handling) and routes the request to other middleware or application code.


### These patterns and technologies are common components often used in modern software development projects and ensure that the application is robust, modular and easy to maintain.

● If you want to download and test the project, you can send your requests with the Postman Collection that I have shared in the attachment when you make the database configuration according to yourself and run it.

● If you have a problem with JWT, just remove the [Authorize] field at the beginning of the controller.

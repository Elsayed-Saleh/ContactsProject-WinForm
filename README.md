# Contacts Management System

A C# project that started as a Console Application and was later transformed into a Windows Forms desktop application using Three-Tier Architecture.

## Overview

The Contacts Management System was initially developed as a console-based application. As the project evolved, it was redesigned as a Windows Forms application to provide a more interactive and user-friendly graphical interface.

During this transformation, the application was organized using Three-Tier Architecture, separating the presentation layer, business logic layer, and data access layer to improve code organization, maintainability, and separation of responsibilities.

The application allows users to manage contact information, including names, email addresses, phone numbers, dates of birth, countries, addresses, and profile pictures.

## Project Evolution

- Started as a Console Application.
- Redesigned as a Windows Forms desktop application.
- Refactored into a Three-Tier Architecture.
- Separated the user interface, business logic, and data access responsibilities.

## Features

- Add new contacts.
- View and edit contact information.
- Manage first names, last names, email addresses, and phone numbers.
- Store dates of birth, countries, and addresses.
- Upload and remove contact profile pictures.
- Use a graphical interface built with Windows Forms.
- Organize application code into separate architectural layers.

## Architecture

The solution consists of three projects:

### 1. Presentation Layer
**Project:** `ContactsProject-WinForm`

Responsible for the graphical user interface and user interactions.

### 2. Business Logic Layer
**Project:** `ContactsBusinessLayer`

Responsible for handling the application's business logic and contact-related operations.

### 3. Data Access Layer
**Project:** `ContactsDataAccessLayer`

Responsible for database access and data-related operations.

## Technologies Used

- C#
- Windows Forms
- .NET Framework
- SQL Server
- Visual Studio
- Three-Tier Architecture

## Screenshots

<p align="center">
  <img src="ScreenShots/Screenshot%202026-10-19%20010250.png" width="32%" />
  <img src="ScreenShots/Screenshot%202026-10-19%20011103.png" width="32%" />
  <img src="ScreenShots/Screenshot%202026-10-19%20011203.png" width="32%" />
  <img src="ScreenShots/Screenshot%202026-10-19%20011239.png" width="32%" />
  <img src="ScreenShots/Screenshot%202026-10-19%20011335.png" width="32%" />
</p>

## Getting Started

1. Clone or download this repository.
2. Open `ContactsProject-WinForm/ContactsProject-WinForm.sln` in Visual Studio.
3. Configure the database connection in `App.config` to match your local SQL Server setup.
4. Ensure the required database and tables are available.
5. Build and run the application.

## Author

**Elsayed Saleh**

[GitHub Profile](https://github.com/Elsayed-Saleh)

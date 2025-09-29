# DVLD - Driving & Vehicle Licensing Desktop Application

This is a comprehensive desktop application built with C# and Windows Forms for managing a Driving and Vehicle Licensing Department (DVLD). It follows a 3-tier architecture (Presentation, Business Logic, and Data Access Layers) to ensure a scalable and maintainable system.

## ✨ Key Features

The system provides a wide range of features to manage all aspects of driving licenses and related processes.

### 👤 People & User Management
- **Manage People:** Add, Edit, Delete, and Search for individuals in the system.
- **Manage Users:** Create and manage system user accounts with different access levels.
- **Login System:** Secure access for registered users.

### 📝 Application & Licensing Management
- **Local Driving License Applications:**
  - Create new driving license applications for different license classes.
  - Track application status through various stages (New, Completed, Cancelled).
- **License Management:**
  - Issue new licenses upon successful completion of tests.
  - Renew expired licenses.
  - Replace lost or damaged licenses.
- **International License Applications:**
  - Issue new international driving licenses based on existing local licenses.
- **Application Types:** Manage different types and fees for all applications.

### ✍️ Test & Appointment Management
- **Test Appointments:** Schedule appointments for three types of tests:
  - Vision Test
  - Written Test
  - Street (Practical) Test
- **Test Results:** Record and manage results for each test. If a candidate fails, they can retake the test.
- **Test Types:** Configure different test types and their associated fees.

### 👮 License Enforcement
- **Detain Licenses:** Record and manage detained licenses.
- **Release Detained Licenses:** Process the release of previously detained licenses.

### 🚗 Driver Management
- **Driver Profiles:** View a complete history of a driver's licenses and applications.

## 🛠️ Tech Stack & Architecture

- **Frontend:** Windows Forms (.NET Framework)
- **Backend:** C#
- **Database:** Microsoft SQL Server
- **Architecture:** 3-Tier Architecture
  - **DVLD (Presentation Layer):** The user interface and user experience layer.
  - **DVLD_BLL (Business Logic Layer):** Handles all business rules, logic, and data processing.
  - **DVLD_DAL (Data Access Layer):** Responsible for all database interactions (CRUD operations).

## 🚀 Getting Started

To get a local copy up and running, follow these simple steps.

### Prerequisites
- **Microsoft Visual Studio:** (e.g., Visual Studio 2022)
- **.NET Framework:** (e.g., version 4.8 or later)
- **Microsoft SQL Server:** (e.g., SQL Server Express or Developer edition)

### Installation
1. **Clone the repository:**
   ```sh
   git clone https://github.com/MostafaShraief/DVLD
   ```
2. **Database Setup:**
   - A database backup file (`DVLD.bak`) is included in the root directory.
   - Restore this backup to your local SQL Server instance.
1. **Configure Connection String:**
   - Open the `DVLD_DAL` project.
   - Locate the `clsSettings_DAL.cs` file (or a similar configuration file).
   - Update the database connection string with your SQL Server credentials.
4. **Build the Solution:**
   - Open `DVLD.sln` in Visual Studio.
   - Build the solution to restore NuGet packages and compile the projects.
   - Run the `DVLD` project to start the application.

## 📧 Contact

Mostafa Shraief - mostafashraief5@gmail.com

Project Link: [https://github.com/MostafaShraief/DVLD](https://github.com/MostafaShraief/DVLD)
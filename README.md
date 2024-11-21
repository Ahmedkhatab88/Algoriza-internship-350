# Vezeeta API  

A robust API developed during the **Algoriza Back-end Development Internship** for managing healthcare appointments. Built with **ASP.NET Core**, the API includes modules for administrators, doctors, and patients, offering features like scheduling, user management, and discount handling.  

---

## Features  

### Admin Features  
- **Dashboard Statistics:**  
  - View total doctors, patients, and appointment requests (pending, completed, canceled).  
  - Identify top specializations and doctors by requests.  
  - Filter statistics by custom time frames (e.g., last 24 hours, week, month).  
- **Doctor Management:**  
  - Add, edit, view, and delete doctor profiles.  
  - Send credentials (username and password) to newly added doctors via email.  
- **Patient Management:**  
  - Add, edit, view, and delete patient profiles.  
- **Discount Management:**  
  - Create, update, deactivate, or delete discount codes.  

### Doctor Features  
- **Authentication:**  
  - Secure login using email and password.  
- **Appointment Management:**  
  - View and filter patient bookings.  
  - Confirm patient appointments.  
- **Availability Settings:**  
  - Add, update, or delete available time slots.  

### Patient Features  
- **Authentication:**  
  - Register and log in securely.  
- **Search for Doctors:**  
  - Filter by specialization, name, and availability.  
- **Appointment Booking:**  
  - Select available time slots and apply discount codes.  
- **Manage Appointments:**  
  - View and cancel bookings.  

---

## Project Requirements  

- **Architecture:** Onion structure to ensure modularity and maintainability.  
- **Database Relationships:** Fully normalized schema with relational integrity.  
- **Authentication:** Implemented using Identity and JWT tokens.  
- **Testing and Documentation:** APIs are tested and documented with Swagger.  
- **Clean Code Standards:** Follows best practices for readability and maintainability.  

### Bonus Features  
- Localization support (English and Arabic).  
- Registration through social media platforms.  

---

## Technologies  

- **Framework:** ASP.NET Core  
- **Database:** SQL Server  
- **Authentication:** Identity & JWT  
- **Language:** C#  
- **Documentation:** Swagger  

---

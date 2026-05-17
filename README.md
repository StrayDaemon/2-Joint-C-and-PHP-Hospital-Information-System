# 🏥 Hospital Management System (HMS)

A dual-system Hospital Management application consisting of a **PHP-based web app (System 1)** and a **C# WinForms desktop app (System 2)**, both sharing the same MySQL database through a centralized **Node.js REST API**.

---

## 📐 System Architecture

```
┌─────────────────────────┐         ┌─────────────────────────┐
│   SYSTEM 1              │         │   SYSTEM 2              │
│   PHP Web App           │         │   C# WinForms           │
│   (forked GitHub)       │         │   (MaterialSkin2)       │
│                         │         │                         │
│   Direct MySQL via      │         │   HTTP calls to         │
│   XAMPP (already works) │         │   Node.js API           │
└────────────┬────────────┘         └────────────┬────────────┘
             │                                   │
             │ Direct DB                         │ REST API
             │ connection                        │ calls
             │                                   │
             └──────────────┬────────────────────┘
                            │
                   ┌────────▼────────┐
                   │  XAMPP MySQL    │
                   │  myhmsdb        │
                   │                 │
                   │  Same database  │
                   │  shared by both │
                   └─────────────────┘
```

Both systems operate on the **same `myhmsdb` database**, meaning any change made in System 1 (PHP) is instantly reflected in System 2 (C# WinForms) and vice versa.

---

## 🗂️ Project Structure

```
HMS Project Root/
│
├── web-system/                        ← PHP Web App (forked)
│   └── (existing PHP project)
│
├── hms-api/                        ← Node.js REST API
│   ├── .env
│   ├── package.json
│   ├── server.js
│   ├── config/
│   │   └── db.js
│   ├── middleware/
│   │   └── validate.js
│   └── routes/
│       ├── auth.js
│       ├── patients.js
│       ├── doctors.js
│       ├── appointments.js
│       ├── prescriptions.js
│       └── contacts.js
│
└── desktop-system/       ← C# WinForms App (System 2)
    └── HospitalManagementSystem/
        ├── Program.cs
        ├── Core/
        │   └── ApiClient.cs
        ├── Models/
        │   ├── Admin.cs
        │   ├── Patient.cs
        │   ├── Doctor.cs
        │   ├── Appointment.cs
        │   ├── Prescription.cs
        │   └── Contact.cs
        ├── Helpers/
        │   ├── SessionManager.cs
        │   └── DataGridHelper.cs
        └── Forms/
            ├── LoginForm.cs
            ├── Admin/
            │   ├── AdminDashboard.cs
            │   ├── ManagePatients.cs
            │   ├── ManageDoctors.cs
            │   ├── ManageAppointments.cs
            │   └── ViewContacts.cs
            ├── Doctor/
            │   ├── DoctorDashboard.cs
            │   ├── DoctorAppointments.cs
            │   └── WritePrescription.cs
            └── Patient/
                ├── PatientDashboard.cs
                ├── BookAppointment.cs
                ├── ViewAppointments.cs
                └── ViewPrescriptions.cs
```

---

## 🗄️ Database Schema — `myhmsdb`

> Hosted on XAMPP MySQL — shared by both systems.

### `admintb`
| Column | Type | Description |
|---|---|---|
| `username` | varchar(50) | Admin username |
| `password` | varchar(30) | Admin password |

**Default credentials:** `admin` / `admin123`

---

### `patreg` — Patients
| Column | Type | Description |
|---|---|---|
| `pid` | int(11) PK AI | Patient ID |
| `fname` | varchar(20) | First name |
| `lname` | varchar(20) | Last name |
| `gender` | varchar(10) | Gender |
| `email` | varchar(30) | Email (used as login username) |
| `contact` | varchar(10) | Contact number |
| `password` | varchar(30) | Password |
| `cpassword` | varchar(30) | Confirm password |

---

### `doctb` — Doctors
| Column | Type | Description |
|---|---|---|
| `username` | varchar(50) | Doctor username (login) |
| `password` | varchar(50) | Password |
| `email` | varchar(50) | Email |
| `spec` | varchar(50) | Specialization |
| `docFees` | int(10) | Consultation fees |

---

### `appointmenttb` — Appointments
| Column | Type | Description |
|---|---|---|
| `pid` | int(11) | Patient ID (ref: patreg) |
| `ID` | int(11) PK AI | Appointment ID |
| `fname` | varchar(20) | Patient first name |
| `lname` | varchar(20) | Patient last name |
| `gender` | varchar(10) | Gender |
| `email` | varchar(30) | Email |
| `contact` | varchar(10) | Contact |
| `doctor` | varchar(30) | Doctor username (ref: doctb) |
| `docFees` | int(5) | Fees at time of booking |
| `appdate` | date | Appointment date |
| `apptime` | time | Appointment time |
| `userStatus` | int(5) | Patient confirmation: 0=Pending, 1=Confirmed |
| `doctorStatus` | int(5) | Doctor confirmation: 0=Pending, 1=Confirmed |

---

### `prestb` — Prescriptions
| Column | Type | Description |
|---|---|---|
| `doctor` | varchar(50) | Doctor username |
| `pid` | int(11) | Patient ID |
| `ID` | int(11) | Appointment ID (ref: appointmenttb) |
| `fname` | varchar(50) | Patient first name |
| `lname` | varchar(50) | Patient last name |
| `appdate` | date | Appointment date |
| `apptime` | time | Appointment time |
| `disease` | varchar(250) | Disease / condition |
| `allergy` | varchar(250) | Known allergies |
| `prescription` | varchar(1000) | Full prescription text |

---

### `contact` — Contact Messages
| Column | Type | Description |
|---|---|---|
| `name` | varchar(30) | Sender name |
| `email` | text | Sender email |
| `contact` | varchar(10) | Phone number |
| `message` | varchar(200) | Message content |

---

## 🔌 Node.js REST API — `hms-api`

### Base URL
```
http://localhost:3000/api
```

### Full Endpoint Reference

#### 🔐 Auth
| Method | Endpoint | Description |
|---|---|---|
| POST | `/api/auth/login` | Login for admin, doctor, patient |
| POST | `/api/auth/register` | Register new patient |

**Login body:**
```json
{
  "username": "admin",
  "password": "admin123",
  "role": "admin"
}
```
> For patient login, `username` is the patient's **email address**.

---

#### 👤 Patients
| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/patients` | Get all patients |
| GET | `/api/patients/:pid` | Get single patient |
| POST | `/api/patients` | Add new patient |
| PUT | `/api/patients/:pid` | Update patient |
| DELETE | `/api/patients/:pid` | Delete patient |

---

#### 🩺 Doctors
| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/doctors` | Get all doctors |
| GET | `/api/doctors/:username` | Get single doctor |
| POST | `/api/doctors` | Add new doctor |
| PUT | `/api/doctors/:username` | Update doctor |
| DELETE | `/api/doctors/:username` | Delete doctor |

---

#### 📅 Appointments
| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/appointments` | Get all appointments |
| GET | `/api/appointments?pid=4` | Filter by patient |
| GET | `/api/appointments?doctor=Ganesh` | Filter by doctor |
| GET | `/api/appointments?filter=1` | 1=Pending, 2=Confirmed |
| GET | `/api/appointments/:id` | Get single appointment |
| POST | `/api/appointments` | Book new appointment |
| PUT | `/api/appointments/:id/status` | Update status flags |
| DELETE | `/api/appointments/:id` | Delete appointment |

---

#### 💊 Prescriptions
| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/prescriptions?pid=4` | Get patient's prescriptions |
| GET | `/api/prescriptions?doctor=Ganesh` | Get doctor's prescriptions |
| GET | `/api/prescriptions/:id` | Get by appointment ID |
| GET | `/api/prescriptions/:id?pid=4` | Patient-scoped detail |
| POST | `/api/prescriptions` | Save or update prescription |
| PUT | `/api/prescriptions/:id` | Update prescription |
| DELETE | `/api/prescriptions/:id` | Delete prescription |

---

#### 📨 Contacts
| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/contacts` | Get all messages |
| GET | `/api/contacts?search=keyword` | Search by name or email |
| POST | `/api/contacts` | Send a contact message |
| DELETE | `/api/contacts?email=x&name=y` | Delete a message |

---

### Standard API Response Format

Every endpoint returns this JSON shape:

```json
{
  "success": true,
  "message": "Operation description.",
  "data": { }
}
```

---

## 🖥️ System 2 — C# WinForms App

### Tech Stack
| Item | Detail |
|---|---|
| Framework | .NET Framework (WinForms) |
| UI Library | MaterialSkin2 |
| HTTP Client | System.Net.Http.HttpClient |
| JSON Parser | Newtonsoft.Json |
| API Target | Node.js REST API (localhost:3000) |

### NuGet Packages
```
MaterialSkin.2
Newtonsoft.Json
```

### Role-Based Access

| Role | Login Credential | Dashboard |
|---|---|---|
| Admin | Username + Password | AdminDashboard |
| Doctor | Username + Password | DoctorDashboard |
| Patient | Email + Password | PatientDashboard |

### Admin Features
- View, Add, Edit, Delete **Patients**
- View, Add, Edit, Delete **Doctors**
- View, Update status, Delete **Appointments**
- View **Contact Messages** with search

### Doctor Features
- View own **Appointments** (filtered by logged-in doctor)
- Confirm / update appointment status
- Write and save **Prescriptions**

### Patient Features
- Book **Appointments** (select doctor, date, time)
- View own appointments with status tracking
- Cancel pending appointments
- View **Prescriptions** with print support

---

## ⚙️ Setup & Running

### Prerequisites
| Tool | Purpose |
|---|---|
| XAMPP | Apache + MySQL server |
| Node.js (v18+) | REST API runtime |
| Visual Studio 2019+ | C# WinForms development |
| PHP 7.2+ | System 1 web app |

---

### Step 1 — Database Setup

1. Start **XAMPP** → Start **Apache** and **MySQL**
2. Open `http://localhost/phpmyadmin`
3. Create database: `myhmsdb`
4. Import the SQL file:
```
File → Import → myhmsdb.sql → Go
```

---

### Step 2 — Node.js API Setup

```bash
# Navigate to API folder
cd hms-api

# Install dependencies
npm install

# Configure environment
# Edit .env file:
#   DB_HOST=localhost
#   DB_PORT=3306
#   DB_USER=root
#   DB_PASSWORD=
#   DB_NAME=myhmsdb
#   PORT=3000

# Start the API
node server.js
```

Expected output:
```
✅ MySQL Connected — myhmsdb
🚀 HMS API running at http://localhost:3000
```

---

### Step 3 — C# WinForms Setup

1. Open `HospitalManagementSystem.sln` in Visual Studio
2. Right-click Solution → **Restore NuGet Packages**
3. Verify `Core/ApiClient.cs` base URL:
```csharp
private const string BaseUrl = "http://localhost:3000/api/";
```
4. Press **F5** to build and run

---

### Step 4 — System 1 (PHP Web App)

1. Copy the PHP project into `htdocs/` in your XAMPP folder
2. Access via `http://localhost/your-project-folder`
3. No additional configuration needed — it connects directly to `myhmsdb`

---

### Running All Systems Together

```
Terminal 1:  XAMPP Control Panel → Start Apache + MySQL
Terminal 2:  cd hms-api && node server.js
Visual Studio: Run HospitalManagementSystem (F5)
Browser:     http://localhost/system1
```

---

## 🔑 Default Login Credentials

### Admin
| Field | Value |
|---|---|
| Username | `admin` |
| Password | `admin123` |

### Sample Doctors
| Username | Password | Specialization |
|---|---|---|
| `ashok` | `ashok123` | General |
| `Ganesh` | `ganesh123` | Pediatrician |
| `Dinesh` | `dinesh123` | General |
| `Kumar` | `kumar123` | Pediatrician |
| `Amit` | `amit123` | Cardiologist |
| `Abbis` | `abbis123` | Neurologist |
| `Tiwary` | `tiwary123` | Pediatrician |

### Sample Patients (login with email)
| Email | Password |
|---|---|
| `alia@gmail.com` | `alia123` |
| `william@gmail.com` | `william123` |
| `kishan@gmail.com` | `kishan123` |
| `gautam@gmail.com` | `gautam123` |

---

## 🧩 Key Design Decisions

### Why Node.js API instead of direct DB from C#?
- Centralizes all database logic in one place
- System 1 (PHP) and System 2 (C#) share data via same DB
- Easier to maintain, extend, and secure
- No need to expose MySQL port to the desktop app

### Why no PHP curl bridge?
- System 1 already connects directly to XAMPP MySQL and works
- Both systems share the same `myhmsdb` — changes sync automatically
- Adding a bridge would introduce unnecessary complexity

### Why MaterialSkin2 for C# WinForms?
- Provides Material Design UI components natively in WinForms
- Consistent, modern look without WPF complexity
- Supports `MaterialForm`, `MaterialButton`, `MaterialTextBox`, `MaterialComboBox`

---

## 🐛 Troubleshooting

| Problem | Solution |
|---|---|
| `Connection error` in C# app | Make sure `node server.js` is running on port 3000 |
| `DB Connection Failed` in Node.js | Check XAMPP MySQL is running; verify `.env` credentials |
| `Login failed` for any role | Verify credentials match database values |
| `Namespace conflict` (Doctor/Patient) | Use `using DoctorModel = HMS.Models.Doctor` alias |
| `InitializeComponent` duplicate error | Remove `InitializeComponent()` definition from `.cs` file; keep only in `.Designer.cs` |
| Grid columns too narrow | Right-click grid → **Auto-fit All Columns** |
| PHP web app can't connect to DB | Check XAMPP MySQL is running; verify DB config in PHP project |

---

## 📦 Dependencies

### Node.js API (`hms-api/package.json`)
```json
{
  "dependencies": {
    "cors": "^2.8.5",
    "dotenv": "^16.0.0",
    "express": "^4.18.0",
    "express-validator": "^7.0.0",
    "mysql2": "^3.0.0"
  }
}
```

### C# WinForms (NuGet)
```
MaterialSkin.2
Newtonsoft.Json
```

---

## 👥 User Roles & Permissions

| Feature | Admin | Doctor | Patient |
|---|---|---|---|
| Manage Patients (CRUD) | ✅ | ❌ | ❌ |
| Manage Doctors (CRUD) | ✅ | ❌ | ❌ |
| View All Appointments | ✅ | ❌ | ❌ |
| Update Any Appointment Status | ✅ | ❌ | ❌ |
| Delete Appointments | ✅ | ❌ | ❌ |
| View Contact Messages | ✅ | ❌ | ❌ |
| View Own Appointments | ❌ | ✅ | ✅ |
| Update Own Status | ❌ | ✅ | ✅ |
| Write Prescriptions | ❌ | ✅ | ❌ |
| Book Appointments | ❌ | ❌ | ✅ |
| Cancel Appointments | ❌ | ❌ | ✅ |
| View Own Prescriptions | ❌ | ❌ | ✅ |
| Print Prescriptions | ❌ | ❌ | ✅ |

---

## 📝 Notes

- Passwords are stored in **plain text** in this version. For production use, implement hashing (e.g., `bcrypt` in Node.js).
- The `contact` table has **no primary key** — deletion is scoped by `email + name`.
- The `prestb` table has **no primary key** — upsert logic uses `ID + doctor` as a unique combination.
- Patient login uses **email** as the username field.
- The Node.js API runs on **port 3000** by default — configurable via `.env`.

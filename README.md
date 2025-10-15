<div align="center">
  <h1>🏛️ Municipal Services App - Part 2</h1>
  <h3>Community Engagement & Events Made Simple</h3>
  
  <p>Empowering South African citizens through seamless access to local events, announcements, and personalized recommendations within a comprehensive Municipal Services platform.</p>
  
  ![C#](https://img.shields.io/badge/C%23-11.0-purple?style=for-the-badge&logo=csharp)
  ![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.8-blue?style=for-the-badge&logo=dotnet)
  ![Windows Forms](https://img.shields.io/badge/Windows%20Forms-Desktop-green?style=for-the-badge&logo=windows)
  ![Visual Studio](https://img.shields.io/badge/Visual%20Studio-2022-blueviolet?style=for-the-badge&logo=visualstudio)
  
  <a href="https://youtu.be/p7eRyulXWA0">
    <img src="https://img.shields.io/badge/Watch_Demo-YouTube-red?style=for-the-badge&logo=youtube" alt="Watch Demo on YouTube">
  </a>
</div>

---

## 📋 Table of Contents
- [Overview](#-overview)
- [Key Features](#-key-features)
- [Screenshots](#-screenshots)
- [Technology Stack](#-technology-stack)
- [Data Structures Implementation](#-data-structures-implementation)
- [Prerequisites](#-prerequisites)
- [Installation](#-installation)
- [Usage Guide](#-usage-guide)
- [Project Structure](#-project-structure)
- [Code Attributions](#-code-attributions)
- [Contributing](#-contributing)
- [License](#-license)
- [Contact](#-contact)

---

## 🌟 Overview

**Municipal Services App - Part 2** extends the platform developed in Part 1 by introducing a comprehensive **Local Events and Announcements** system. This enhancement allows South African citizens to:

- Browse upcoming community events in a visually appealing interface
- Search and filter events by category and date
- Receive personalized event recommendations based on search history
- Stay informed about municipal activities and community engagement opportunities

The application leverages advanced data structures including **stacks, queues, priority queues, dictionaries, sorted dictionaries, and sets** to ensure efficient data management and optimal user experience.

---

## ✨ Key Features




### 🎯 Core Functionality
- **Local Events Dashboard**: Browse all upcoming community events in an aesthetically pleasing card-based layout
- **Advanced Search**: Filter events by category and date with real-time results
- **Smart Recommendations**: AI-powered suggestions based on your search patterns and preferences
- **Event Details**: View comprehensive information about each event including location, date, description, and category
- **Search Analytics**: Track your search history and see what types of events you're interested in
- 

### 🔧 Technical Highlights
- **Custom Data Structures**: Implemented from scratch to demonstrate algorithmic proficiency
  - Custom Sorted Dictionary for event organization by date
  - Custom Dictionary for fast event lookups by ID
  - Custom Sets for unique categories and dates
  - Custom Queue for recently viewed events
  - Custom Priority Queue for upcoming high-priority events
- **Recommendation Engine**: Analyzes user search patterns using dictionaries and frequency algorithms
- **Responsive UI**: Modern, clean interface with gradient effects and smooth animations
- **Event Management**: Efficient storage and retrieval of event data

---
## Youtube Video Link

https://youtu.be/p7eRyulXWA0
## 📸 Screenshots


### 🏠 Main Menu
The central hub providing access to all municipal services.

<div align="center">
  <img src="https://github.com/user-attachments/assets/f5197ef1-c267-4b0d-b94c-88f16fa7fafb" alt="Main Menu" width="900">
</div>

### 📅 Local Events & Announcements Dashboard
Browse upcoming events with intuitive search and filter options.

<div align="center">
  <img src="https://github.com/user-attachments/assets/8ccaf85d-ea0c-49d7-982e-5e142f293032" alt="Local Events Dashboard" width="900">
</div>

### ⭐ Personalized Recommendations
Get event suggestions based on your search history and interests.

<div align="center">
  <img src="https://github.com/user-attachments/assets/a10cc5cc-71e7-4142-9291-713b6a2998f5" alt="Recommendations" width="900">
</div>

### 📊 Search Statistics
View detailed analytics about your search patterns and preferences.

<div align="center">
  <img src="https://github.com/user-attachments/assets/e79500eb-6bac-4864-8762-5f012a11f994" alt="Search Statistics" width="500">
  <p><em>Detailed breakdown of your search activity</em></p>
</div>

---

## 🛠️ Technology Stack

### Core Technologies
- **Framework**: .NET Framework 4.8
- **Language**: C# 11.0
- **UI**: Windows Forms with custom controls and graphics
- **IDE**: Visual Studio 2022

### Development Practices
- **Architecture**: Layered desktop architecture with separation of concerns
- **Design Patterns**: Object-Oriented Programming (OOP) principles
- **Data Management**: Custom data structures implementation
- **Code Organization**: Modular design with reusable components

---

## 📚 Data Structures Implementation

### Assignment Requirements Fulfilled (70 Marks)

#### 1. Stacks, Queues, Priority Queues (15 Marks)
```csharp
// Custom Queue for recently viewed events
private CustomQueue<Event> recentlyViewedEvents;

// Custom Priority Queue for upcoming events by priority
private CustomPriorityQueue<Event> upcomingEvents;
```

#### 2. Hash Tables, Dictionaries, Sorted Dictionaries (15 Marks)
```csharp
// Custom Sorted Dictionary - organizes events by date
private CustomSortedDictionary<string, Event> eventsByDate;

// Custom Dictionary - fast event lookup by ID
private CustomDictionary<string, Event> eventsById;
```

#### 3. Sets (10 Marks)
```csharp
// Custom Sets for unique categories and dates
private CustomSet<string> categories;
private CustomSet<string> uniqueDates;
```

#### 4. Recommendation Feature (30 Marks)
```csharp
// Recommendation Engine with search pattern analysis
public class RecommendationEngine
{
    private Dictionary<string, int> categorySearchCount;
    private Dictionary<DateTime, int> dateSearchCount;
    private Dictionary<string, int> textSearchCount;
    
    // Analyzes search patterns
    // Generates personalized recommendations
    // Displays statistics
}
```

**Algorithm**: The recommendation engine uses frequency-based analysis to:
1. Track category and date search patterns
2. Weight events based on search frequency
3. Prioritize upcoming high-priority events
4. Generate personalized suggestions

---

## 📋 Prerequisites

### Essential Requirements
- **Operating System**: Windows 10 or Windows 11 (64-bit)
- **Visual Studio**: 2022 (Community, Professional, or Enterprise Edition)
- **.NET Framework**: 4.8 or later
- **RAM**: Minimum 4GB (8GB recommended)
- **Disk Space**: 500MB for application and dependencies

### Optional
- **Git**: For cloning the repository and version control

---

## 🚀 Installation

### Step 1: Clone the Repository
```bash
git clone https://github.com/ST10082747/MunicipalServicesApp_Part2.git
cd MunicipalServicesApp_Part2
```

### Step 2: Open in Visual Studio
1. Launch **Visual Studio 2022**
2. Select **Open a project or solution**
3. Navigate to the cloned directory
4. Open `MunicipalServicesApp.sln`

### Step 3: Restore Dependencies
```bash
# In Visual Studio Package Manager Console
dotnet restore
```

Or right-click solution → **Restore NuGet Packages**

### Step 4: Build the Solution
- Press `Ctrl + Shift + B`
- Or select **Build → Build Solution**
- Ensure no errors in the Output window

### Step 5: Run the Application
- Press `F5` to run with debugging
- Or `Ctrl + F5` to run without debugging

---

## 📖 Usage Guide

### Browsing Events
1. Launch the application
2. From the main menu, click **"Local Events and Announcements"**
3. Browse events displayed in card format
4. Click any event card to view full details

### Searching Events
1. Use the **search bar** to find events by title or description
2. Select a **category** from the dropdown (Community, Government, Health, etc.)
3. Pick a **date** using the date picker
4. Click **🔍 Search** to filter results
5. Click **🔄 Clear** to reset filters

### Getting Recommendations
1. Perform several searches (category or date-based)
2. Click **⭐ Recommendations** button
3. View personalized event suggestions based on your search history
4. See your search statistics at the bottom of the recommendations window

### Viewing Event Details
1. Click on any event card
2. View comprehensive details:
   - Event title and description
   - Category and location
   - Date and time
   - Visual category indicators
3. Click **Close** to return to the main view

---

## 📁 Project Structure

```
MunicipalServicesApp/
│
├── DataStructures/              # Custom data structure implementations
│   ├── CustomDictionary.cs      # Hash table implementation
│   ├── CustomSortedDictionary.cs # Sorted dictionary for dates
│   ├── CustomSet.cs             # Set for unique values
│   ├── CustomQueue.cs           # Queue for recent views
│   ├── CustomPriorityQueue.cs   # Priority queue for events
│   └── RecommendationEngine.cs  # Search pattern analysis
│
├── Models/                      # Data models
│   ├── Event.cs                 # Event entity
│   └── Issue.cs                 # Issue reporting entity
│
├── Forms/                       # Windows Forms UI
│   ├── MainForm.cs              # Main menu
│   ├── EventsAndAnnouncementsForm.cs  # Events dashboard
│   └── ReportIssueForm.cs       # Issue reporting (Part 1)
│
├── Services/                    # Business logic services
│   ├── IssueStorage.cs          # Data persistence
│   └── EngagementService.cs     # Community engagement tracking
│
├── Resources/                   # Application assets
│   ├── Icons/                   # UI icons
│   └── Images/                  # Screenshots and logos
│
├── Program.cs                   # Application entry point
├── App.config                   # Configuration file
└── README.md                    # This file
```

---

## 🧩 Code Attributions

This project was developed as part of an academic assignment for **PROG7312 - Programming 3B** at **The Independent Institute of Education (IIE)**.  
It draws on a combination of educational resources, open-source inspiration, and modern design practices to create a robust and visually engaging Windows Forms application.

---

### 📘 Educational Resources
- [.NET Documentation](https://learn.microsoft.com/en-us/dotnet/) — Official Microsoft Docs for C# and Windows Forms  
- [Windows Forms Documentation](https://learn.microsoft.com/en-us/dotnet/desktop/winforms/) — UI design, controls, and event handling  
- [C# Programming Guide](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/) — Core language principles and OOP patterns  
- [Stack Overflow Community](https://stackoverflow.com/) — Problem-solving references and best practices for C# and WinForms  
- [Microsoft Learn](https://learn.microsoft.com/en-us/training/) — Guided tutorials for .NET and Visual Studio development  
- [GeeksforGeeks - Data Structures in C#](https://www.geeksforgeeks.org/csharp-programming-language/) — Reference for implementing custom stacks, queues, and dictionaries  
- [TutorialsTeacher - C# Collections](https://www.tutorialsteacher.com/csharp/csharp-collection) — Understanding and applying collection classes  

---

### 💻 Technical References
- **Visual Studio 2022** — Development environment for Windows desktop applications  
- **.NET Framework 4.8** — Framework for application build and execution  
- **GitHub** — Version control, collaboration, and project documentation  
- **NuGet Packages** — Dependency management for C# libraries  
- **GDI+ (System.Drawing)** — Custom graphics and rendering for UI elements  
- **Windows API Concepts** — Enhanced user interface responsiveness and interaction handling  

---

### 🎨 Design Inspiration
- **Material Design by Google** — Color palette, card-based UI, and elevation principles  
- **Microsoft Fluent Design System** — Clean Windows UI style and interactive responsiveness  
- **Modern UI/UX Design** — Gradient effects, rounded corners, and visual hierarchy principles  
- **Dribbble & Behance** — Inspiration for desktop layout and iconography styles  
- **Color Hunt** — Selection of harmonious color schemes used in the app  
- **FlatIcon & Icons8** — Icon resources for improving interface clarity and engagement  

---

### 🧠 Conceptual and Academic References
- **Data Structures and Algorithms** — Linked lists, stacks, queues, dictionaries, and sorted dictionaries for efficient data management  
- **Object-Oriented Programming (OOP)** — Inheritance, encapsulation, and polymorphism applied throughout the project  
- **User-Centered Design (UCD)** — Creating intuitive interfaces that focus on accessibility and usability  
- **Gamification Theory** — Achievement badges and engagement metrics to promote user participation  
- **Software Architecture Principles** — Separation of concerns, maintainability, and scalability within the desktop environment  

---


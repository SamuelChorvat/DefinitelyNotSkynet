DROP TABLE IF EXISTS "Notes";

CREATE TABLE "Notes" (
    "NoteId" INTEGER PRIMARY KEY AUTOINCREMENT,
    "CreatedAt" DATETIME DEFAULT (DATETIME('now')),
    "RelatesTo" NVARCHAR(32) NOT NULL,
    "TicketId" NVARCHAR(32) DEFAULT 'N/A',
    "NoteText" NVARCHAR NOT NULL
);

INSERT INTO Notes ("CreatedAt", "RelatesTo", "TicketId", "NoteText") VALUES
    (DATETIME('now'), 'Project Work', 'TICKET-001', 'Implemented a RESTful API for user management.'),
    (DATETIME('now'), 'Project Work', 'TICKET-002', 'Resolved performance issue in the database query.'),
    (DATETIME('now'), 'Self Development', 'N/A', 'Read the book "Clean Code" by Robert C. Martin.'),
    (DATETIME('now'), 'Other', 'N/A', 'Attended a team meeting to discuss project requirements.'),
    (DATETIME('now'), 'Project Work', 'TICKET-003', 'Refactored the authentication module to improve security.'),
    (DATETIME('now'), 'Project Work', 'TICKET-004', 'Optimized database schema for improved performance.'),
    (DATETIME('now'), 'Project Work', 'TICKET-005', 'Fixed a bug in the payment processing module.'),
    (DATETIME('now'), 'Self Development', 'N/A', 'Experimented with a new JavaScript framework for frontend development.'),
    (DATETIME('now'), 'Other', 'N/A', 'Reviewed code changes and provided feedback to the team.'),
    (DATETIME('now'), 'Project Work', 'TICKET-006', 'Implemented automated testing using Selenium framework.'),
    (DATETIME('now'), 'Project Work', 'TICKET-007', 'Created a modular architecture for the backend system.'),
    (DATETIME('now'), 'Self Development', 'N/A', 'Completed an online course on data structures and algorithms.'),
    (DATETIME('now'), 'Other', 'N/A', 'Conducted a code review session for code quality improvement.'),
    (DATETIME('now'), 'Project Work', 'TICKET-008', 'Integrated third-party API for geolocation services.'),
    (DATETIME('now'), 'Project Work', 'TICKET-009', 'Implemented caching mechanism to enhance application performance.'),
    (DATETIME('now'), 'Self Development', 'N/A', 'Attended a conference on emerging technologies in software engineering.'),
    (DATETIME('now'), 'Other', 'N/A', 'Prepared project documentation and user manuals.'),
    (DATETIME('now'), 'Project Work', 'TICKET-010', 'Enhanced the user interface with responsive design.'),
    (DATETIME('now'), 'Project Work', 'TICKET-011', 'Investigated and resolved a critical security vulnerability.'),
    (DATETIME('now'), 'Self Development', 'N/A', 'Participated in a workshop on test-driven development.'),
    (DATETIME('now'), 'Other', 'N/A', 'Coordinated with stakeholders to gather requirements for a new feature.');
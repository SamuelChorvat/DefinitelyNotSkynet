DROP TABLE IF EXISTS "Notes";

CREATE TABLE "Notes" (
    "NoteId" INTEGER IDENTITY(1,1) PRIMARY KEY,
    "CreatedAt" DATETIME DEFAULT CURRENT_TIMESTAMP,
    "RelatesTo" VARCHAR(32) NOT NULL,
    "TicketId" VARCHAR(32) DEFAULT 'N/A',
    "NoteText" VARCHAR(MAX) NOT NULL
);

INSERT INTO Notes ("CreatedAt", "RelatesTo", "TicketId", "NoteText") VALUES
    (CURRENT_TIMESTAMP, 'Project Work', 'TICKET-001', 'Implemented a RESTful API for user management.'),
    (CURRENT_TIMESTAMP, 'Project Work', 'TICKET-002', 'Resolved performance issue in the database query.'),
    (CURRENT_TIMESTAMP, 'Self Development', 'N/A', 'Read the book "Clean Code" by Robert C. Martin.'),
    (CURRENT_TIMESTAMP, 'Other', 'N/A', 'Attended a team meeting to discuss project requirements.'),
    (CURRENT_TIMESTAMP, 'Project Work', 'TICKET-003', 'Refactored the authentication module to improve security.'),
    (CURRENT_TIMESTAMP, 'Project Work', 'TICKET-004', 'Optimized database schema for improved performance.'),
    (CURRENT_TIMESTAMP, 'Project Work', 'TICKET-005', 'Fixed a bug in the payment processing module.'),
    (CURRENT_TIMESTAMP, 'Self Development', 'N/A', 'Experimented with a new JavaScript framework for frontend development.'),
    (CURRENT_TIMESTAMP, 'Other', 'N/A', 'Reviewed code changes and provided feedback to the team.'),
    (CURRENT_TIMESTAMP, 'Project Work', 'TICKET-006', 'Implemented automated testing using Selenium framework.'),
    (CURRENT_TIMESTAMP, 'Project Work', 'TICKET-007', 'Created a modular architecture for the backend system.'),
    (CURRENT_TIMESTAMP, 'Self Development', 'N/A', 'Completed an online course on data structures and algorithms.'),
    (CURRENT_TIMESTAMP, 'Other', 'N/A', 'Conducted a code review session for code quality improvement.'),
    (CURRENT_TIMESTAMP, 'Project Work', 'TICKET-008', 'Integrated third-party API for geolocation services.'),
    (CURRENT_TIMESTAMP, 'Project Work', 'TICKET-009', 'Implemented caching mechanism to enhance application performance.'),
    (CURRENT_TIMESTAMP, 'Self Development', 'N/A', 'Attended a conference on emerging technologies in software engineering.'),
    (CURRENT_TIMESTAMP, 'Other', 'N/A', 'Prepared project documentation and user manuals.'),
    (CURRENT_TIMESTAMP, 'Project Work', 'TICKET-010', 'Enhanced the user interface with responsive design.'),
    (CURRENT_TIMESTAMP, 'Project Work', 'TICKET-011', 'Investigated and resolved a critical security vulnerability.'),
    (CURRENT_TIMESTAMP, 'Self Development', 'N/A', 'Participated in a workshop on test-driven development.'),
    (CURRENT_TIMESTAMP, 'Other', 'N/A', 'Coordinated with stakeholders to gather requirements for a new feature.');
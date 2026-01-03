# Personal AI Job Application Automation – MVP

## Objective
Build a personal automation system that discovers relevant job openings, generates high-quality personalized application emails using AI, and sends them safely from my own email — with manual review and full tracking.

This is a **single-user, personal-use MVP**.

---

## MVP Goals
- Reduce time spent applying to jobs
- Maintain high email quality (no spam)
- Keep full control over what is sent
- Be safe, legal, and realistic

---

## Explicitly Out of Scope (Not MVP)
- Fully automatic email sending
- Auto scraping private HR emails
- Follow-up automation
- Multiple users
- Payments / subscriptions
- Chrome extensions

---

## MVP Features

### 1. Job Discovery (Semi-Automated)
- Crawl selected company career pages
- Extract:
  - Job Title
  - Job Description
  - Location
  - Job URL
- Store discovered jobs in database
- Ability to mark jobs as:
  - Interested
  - Ignored

---

### 2. Resume Management
- Upload and store a single primary resume
- Resume used as context for AI email generation
- Replace resume if needed

---

### 3. Recruiter / HR Contact Management
- Manually add recruiter or HR email per company
- Store and reuse contacts for future roles
- No automated email scraping

---

### 4. AI Email Draft Generation (Core Feature)
- Generate personalized application emails using:
  - Job Description
  - Company Name
  - Resume
  - Preferred tone
- Output:
  - Short, professional, human-like email
- Ability to:
  - Regenerate
  - Edit manually
  - Approve before sending

---

### 5. Email Sending (Safe Mode)
- Gmail OAuth integration
- Emails sent from user’s own Gmail account
- One-click send after manual approval
- Store sent email metadata

---

### 6. Application Tracking
Track application status:
- Draft
- Sent
- Replied

Maintain history of:
- Jobs applied
- Emails sent
- Timestamps

---

## User Flow

1. System discovers jobs
2. User marks relevant jobs as Interested
3. User generates AI email draft
4. User reviews / edits email
5. User sends email via Gmail
6. System tracks application status

Estimated daily effort: **15–20 minutes**

---

## Database Schema (SQLite – MVP)

### User
```sql
Id (PK)
FullName
Email
ResumePath
PreferredTone
CreatedAt
```

### Company
```sql
Id (PK)
Name
CareerPageUrl
Website
CreatedAt
```

### Job
```sql
Id (PK)
CompanyId (FK)
Title
Description
Location
JobUrl
DiscoveredAt
IsInterested (bool)
```

### RecruiterContact
```sql
Id (PK)
CompanyId (FK)
Name (nullable)
Email
AddedManually (bool)
```

### EmailDraft
```sql
Id (PK)
JobId (FK)
Subject
Body
GeneratedByAI (bool)
CreatedAt
```

### Application
```sql
Id (PK)
JobId (FK)
RecruiterContactId (FK)
EmailDraftId (FK)
Status (Draft | Sent | Replied)
SentAt (nullable)
```

### EmailLog
```sql
Id (PK)
JobId (FK)
RecruiterContactId (FK)
EmailDraftId (FK)
Status (Draft | Sent | Replied)
SentAt (nullable)
```
## MVP API Endpoints (High Level)
```
POST   /jobs/discover
GET    /jobs
POST   /jobs/{id}/interest

POST   /resume/upload

POST   /email/generate/{jobId}
PUT    /email/{id}

POST   /email/send/{applicationId}

GET    /applications
```

## MVP Build Timeline (7 Days)
| Day   | Task                  |
| ----- | --------------------- |
| Day 1 | Database & entities   |
| Day 2 | Job discovery crawler |
| Day 3 | Resume upload         |
| Day 4 | AI email generation   |
| Day 5 | Gmail OAuth & sending |
| Day 6 | Application tracking  |
| Day 7 | Testing & polish      |


## MVP Success Criteria
- Apply to jobs faster with better quality emails
- Zero spam behavior
- Emails feel human and relevant
- Full visibility into application history



















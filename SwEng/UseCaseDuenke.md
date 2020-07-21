# ISTAPRO09-B
**Jacob Duenke**  
*March 25, 2019*

## Use Cases
A use case is a written description of how users will perform tasks on your website.  It outlines, from a user�s point of view, a system�s behavior as it responds to a request. Each use case is represented as a sequence of simple steps, beginning with a user's goal and ending when that goal is fulfilled.

## Use Case Name: Submit Help Ticket
**Actors:**
* User
* System
* Technician

**Triggers:**  
* The user encounters an issue while performing daily operations.

**Preconditions:**  
* The user regularly uses a product supplied by the company.

**Post-conditions**  
* The technician will have resolved the issue.
* The help ticket will be archived in the system.
* The user will resume normal operations.

**Normal Flow**  
1. The user will navigate to the online help ticket submission page.
1. The system will present black boxes for "Name, Email Address, Platform, and Issue Encountered".
1. The user will fill in the required boxes.
1. The user will click the "Submit" button when ready.
1. The system will generate a UserID, TicketNumber, and Submission TimeStamp for the submission.
1. The system will populate the NewTickets database with the new ticket.
1. The technician will open the ticket and review the issue.
1. The system will move the ticket to the OpenTickets database and generate an Opening TimeStamp.
1. The technician will diagnose the issue.
1. The technician will resolve the issue and add notes to the ticket.
1. The technician will click the "Resolved" button when ready.
1. The system will notify the user of the resolution with the technician's notes.
1. The system will move the ticket to the ClosedTickets database.
1. The user will resume normal operations until another issue arises.

**Alternate Flows**  
9A1. The user did not include enough relevant information for the technician to diagnose the issue.
1. The technician will contact the user via email, requesting more relevant information.
1. The technician may call the user via telephone if necessary.
1. The use case continues.

9A2. The problem cannot be diagnosed remotely and the technician requires user input to resolve the issue.
1. The technician contacts the user via email, requesting telephone conferencing.
1. The user calls the technician.
1. The technician guides the user step by step, gathering information over the phone about the issue.
1. The use case continues.

9B1. The problem requires hands on intervention to resolve the issue.
1. The technician informs the user that the tools required to resolve the issue are not available on site.
1. The user brings the platform to the designated repair shop required.
1. The issue was not resolvable with the technology available and the issue was passed to an appropriate resource.
1. The technician notes the results on the ticket and clicks the "Resolved" button.
1. The use case continues at Step 12.
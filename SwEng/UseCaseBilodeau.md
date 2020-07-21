## Project Step 9
#### USE CASE: Adoption
##### Actors
customer

##### Trigger
customer indicates they want to adopt a dog

##### Precondition
the shelter must have dogs in the shelter

##### Post-condition
user will have appointment time to meet animal

##### Normal Flow
1. The user selects an animal and indicates they would like to adopt it
2. The user will make an account if they don't have one
3. The user will log in
4. The user will be presented with an adoption form to fill out
5. The user will submit the form
6. The system will prompt the user to confirm all information is correct
7. The user will be presented with a calendar
8. The user can then select an appointment time to meet the animal.
9. The system will prompt the user to confirm the time is correct
10. the system will send a conformation email to customer
11. The user will exit the system

##### Alternate Flow
A. The user will discover the appointment time they selected is unavailable.
  1. The system will prompt an error that the time they selected is unavailable.
  1. The use case returns to step 7

B. The user changes their mind, and wants to cancel the appointment
  1. The user requests the appointment be canceled
  2. The system will prompt that this is correct
  3. The user will confirm
  4. The use case ends
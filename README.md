# UniProject


Structure : 

Entities and their relationships

1.	User Entity:
•	Id (string)
•	FirstName (string)
•	LastName (string)
•	Email (string)
•	Password (string)
•	ProfileImage (byte[])
•	Role (string)



2.	Meal Plan Entity:
•	Id (string)
•	Name (string)
•	Description (string)
•	MacroNutrients (string)
•	UserId (string)

3.	Meal Entity:
•	Id (string)
•	Name (string)
•	Description (string)
•	Ingredients (string)
•	CalorieCount (int)
•	MealPlanId (string)


4.	Workout Plan Entity:
•	Id (string)
•	Name (string)
•	Description (string)
•	UserId (string)



5.	Workout Entity:
•	Id (string)
•	Date (DateTime)
•	Duration (int)
•	WorkoutPlanId (int)
•	UserId (string)


6.	Exercise Entity:
•	Id (string)
•	Name (string)
•	Description (string)
•	MuscleGroups (string)
•	EquipmentNeeded (string)


7.	Progress Tracking Entity:
•	Id (string)
•	BodyWeight (float)
•	Bench (float)
•	Squat (float)
•	Deadlift (float)
•	UserId (string)




8.	Water Intake Entity:
•	Id (string)
•	Date (DateTime)
•	Amount (float)
•	UserId (string)



9.	Calorie Tracker Entity:
•	Id (string)
•	Date (DateTime)
•	MealName (string)
•	CalorieCount (int)
•	UserId (string)




10.	Challenge Entity:
•	Id (string)
•	Name (string)
•	Description (string)
•	StartDate (DateTime)
•	EndDate (DateTime)
•	UserId (string)


11.	Bodyweight Tracker Entity:
•	Id (string)
•	Date (DateTime)
•	Weight (float)
•	UserId (string)



12.	Workout Schedule Entity:
•	Id (string)
•	DayOfWeek (string)
•	WorkoutType (string)
•	TimeOfDay (TimeSpan)
•	UserId (string)



Relationships : 


1.	User Entity:
•	One-to-One with Progress Tracking Entity
•	One-to-Many with Meal Plan Entity
•	One-to-Many with Workout Plan Entity
•	One-to-Many with Challenge Entity
•	One-to-Many with Water Intake Entity
•	One-to-Many with Calorie Tracker Entity
•	One-to-Many with Bodyweight Tracker Entity
•	One-to-Many with Workout Schedule Entity



2.	Meal Plan Entity:
•	One-to-Many with Meal Entity
•	Many-to-One with User Entity



3.	Meal Entity:
•	Many-to-One with Meal Plan Entity


4.	Workout Plan Entity:
•	One-to-Many with Workout Entity
•	Many-to-One with User Entity



5.	Workout Entity:
•	Many-to-One with Workout Plan Entity
•	Many-to-One with User Entity




6.	Exercise Entity:
•	Many-to-Many with Workout Entity



7.	Progress Tracking Entity:
•	One-to-One with User Entity


8.	Water Intake Entity:
•	Many-to-One with User Entity


9.	Calorie Tracker Entity:
•	Many-to-One with User Entity


10.	Challenge Entity:
•	Many-to-One with User Entity




11.	Bodyweight Tracker Entity:
•	Many-to-One with User Entity


12.	Workout Schedule Entity:
•	Many-to-One with User Entity

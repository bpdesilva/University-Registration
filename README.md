# University-Registration
First OOP Course Work.

#### Scenario 

Student Registration System for Stafford University (SU)

The process of assigning Professors to modules and the registration of students is a frustrating and time consuming experience for SU.  
 
After the Professors of SU have decided which modules they are going to teach for the semester, the Registrar’s office enters the information into a computer system.  A batch report is printed for Professors indicating which modules they will teach. A module list is printed and distributed to the students.   

Currently, the students fill out registration forms that indicate their choice of modules, and return the completed forms to the Registrar’s office. The typical student load is four modules per semester. The staff of the Registrar’s office then enters the students’ forms into the computer. Once the students’ selection for the semester has been entered, a batch job is run overnight to assign students to modules. Most of the time student’s get their first choice; however, in those cases where there is a conflict, the Registrar’s office talks with each student to get additional choices. Once all students have been successfully assigned to modules, a hard copy of the students’ schedule is sent to the students for their verification. Most student registrations are processed within a week, but some exceptional cases take up to two weeks to solve.  

SU Module Registration Problem Statements  

At the beginning of each semester, students may request a module list containing a list of modules offered for the coming semester. In addition, each student will indicate two alternative choices in case a module allocation becomes filled or cancelled. No module will have more than ten students or fewer than three students. A module with fewer than three students will be canceled. Once the registration process is completed for a student, the registration system sends information to the billing system so that student can be billed for the semester.  

Professors must be able to access the student registration system through their logins to indicate which modules they will be teaching, and to see which students signed up for their offered modules.
   
For each semester, there is a period of time that students can change their schedule. Students must be able to access the system during this time to add or drop modules.   

The following are the basic requirements from the System of SU
	*	Students want to register for modules 

	*	Professors want to select modules to teach. 

	*	The Registrar must create the curriculum and generate a module list for the semester. 

	*	The Registrar must maintain all the information about Modules, Professors and Students. 

	*	The Billing system must receive billing information from the system 
		
	*	The student needs to use the system to register for modules 

	*	After the module selection process is completed, the Billing System must be supplied with billing information 

	*	The Professor needs to use the system to select the modules to teach for a semester, and must be able to receive a module schedule from the system. 

	*	The Registrar is responsible for the generation of the module list for a semester, and for the maintenance of all information about the curriculum, the students, and the Professors needed by the system.
	

Note:- Billing is not a covered within the scope of this Student Registration system. But this system should supply student module registration information for billing. Billing system is an actor in the context of this registration system.

Based on the above information given, develop an object-oriented software system using C#.NET

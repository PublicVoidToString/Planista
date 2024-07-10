
Scheduler - School Class Scheduling Application
Project Description

Scheduler is an application designed for automatic scheduling of school class timetables. The problem of scheduling school classes is a complex optimization task, involving assigning lectures to available time slots, rooms, and student groups while minimizing violations of time and logistical constraints.
Application Features

    Automatic Class Scheduling: The application automatically generates class timetables based on input data regarding subjects, teachers, classrooms, and student groups.

    Constraint Handling: Handles both hard constraints (mandatory) and soft constraints (optional) to ensure a feasible and optimized schedule.

    Hybrid Genetic Algorithm: Implements a hybrid genetic algorithm to efficiently explore the solution space and optimize the class schedule.

Key Components

    Genetic Algorithm Core: Utilizes a genetic algorithm framework to evolve and improve schedules over successive iterations.

    Reward-Based Optimization: Incorporates a reward system to evaluate and prioritize solutions that better satisfy soft constraints, enhancing the quality of the final timetable.

    User Interface: Provides an intuitive interface for users to input scheduling preferences, view generated timetables, and adjust parameters if needed.

Usage

    Input Data: Users provide data such as subject lists, teacher availability, classroom capacities, and student group schedules.

    Generation of Timetables: Upon inputting data, the application processes the information using the genetic algorithm to generate optimized class schedules.

    Visualization and Adjustment: Users can view generated timetables, adjust scheduling parameters, and fine-tune constraints to tailor the schedule to specific school requirements.

Installation

To run Scheduler locally, ensure you have Python 3.x installed along with necessary dependencies specified in requirements.txt. Clone the repository and run python scheduler.py to start the application.
Future Enhancements

    Multi-objective Optimization: Extend the algorithm to handle multiple objectives simultaneously, such as minimizing teacher workload alongside student preferences.

    Real-Time Updates: Implement features for real-time updates and notifications for schedule changes or conflicts.

Contributors

    Kamil Pieper (kml.pieper@gmail.com)
    Bartosz Roczniok (bartek.roczniok@gmail.com)
    Ireneusz Czarnowski (i.czarnowski@umg.edu.pl)

License

This project is licensed under the MIT License - see the LICENSE file for details.
Acknowledgments

The Scheduler project draws inspiration from research on class scheduling problems and metaheuristic algorithms, aiming to provide a practical solution for educational institutions.

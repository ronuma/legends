## Requirement 1:

### W1. Create a webpage to embed the project (Functional, WEB)

| Use case name            | W1. Embed the project in a webpage                                                    |                                                                                                                                       |
| ------------------------ | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------- |
| Related Requirements     | W2, W3, WDB1                                                                          |                                                                                                                                       |
| Goal In Context          | Design and implement a webpage to host the project and allow users to access the game |                                                                                                                                       |
| Preconditions            | Web development tools and web server configured                                       |                                                                                                                                       |
| Successful End Condition | Webpage created and project embedded successfully                                     |                                                                                                                                       |
| Failed End Condition     | Webpage not created or project not embedded successfully                              |                                                                                                                                       |
| Primary Actors           | Web developers                                                                        |                                                                                                                                       |
| Secondary Actors         | None                                                                                  |                                                                                                                                       |
| Triggers                 | The decision to deploy the project on a website                                       |                                                                                                                                       |
| Main Flow                | Step                                                                                  | Action                                                                                                                                |
|                          | 1.                                                                                    | Web developer selects a suitable web development framework and creates a new webpage                                                  |
|                          | 2.                                                                                    | Web developer integrates the project into the webpage using appropriate embedding techniques                                          |
|                          | 3.                                                                                    | Web developer tests the embedded project to ensure it functions as expected                                                           |
|                          | 4.                                                                                    | Web developer deploys the webpage to the web server and configures necessary settings                                                 |
| Extensions               | Step                                                                                  | Branching Action                                                                                                                      |
|                          | 1a.                                                                                   | If the chosen web development framework is incompatible, the web developer selects a different framework and repeats steps 1-4        |
|                          | 3a.                                                                                   | If the embedded project does not function as expected, the web developer troubleshoots and resolves the issue, then repeats steps 3-4 |

## Requirement 2:

### W2. Embed project on the main page (Functional, WEB)

<!-- | Use case name            | W2. Embed project on the main page                               |
| ------------------------ | ---------------------------------------------------------------- |
| Related Requirements     | W1, WDB1                                                         |
| Goal In Context          | Integrate the project into the main webpage to allow user access |
| Preconditions            | W1 completed                                                     |
| Successful End Condition | Project embedded on the main page successfully                   |
| Failed End Condition     | Project not embedded on the main page                            |
| Primary Actors           | Web developers                                                   |
| Secondary Actors         | N/A                                                              |
| Triggers                 | Completion of W1                                                 | -->

| Use case name            | W2. Embed the project on the main page                                       |                                                                                                                                            |
| ------------------------ | ---------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------ |
| Related Requirements     | W1, W3, WDB1                                                                 |                                                                                                                                            |
| Goal In Context          | Ensure the project is accessible and visible on the main page of the website |                                                                                                                                            |
| Preconditions            | Webpage created                                                              |                                                                                                                                            |
| Successful End Condition | Project embedded and visible on the main page                                |                                                                                                                                            |
| Failed End Condition     | Project not embedded or not visible on the main page                         |                                                                                                                                            |
| Primary Actors           | Web developers                                                               |                                                                                                                                            |
| Secondary Actors         | None                                                                         |                                                                                                                                            |
| Triggers                 | The decision to make the project accessible on the main page                 |                                                                                                                                            |
| Main Flow                | Step                                                                         | Action                                                                                                                                     |
|                          | 1.                                                                           | Web developer identifies the desired location for the project on the main page                                                             |
|                          | 2.                                                                           | Web developer embeds the project using appropriate embedding techniques                                                                    |
|                          | 3.                                                                           | Web developer tests the embedded project on the main page to ensure it is visible and accessible                                           |
| Extensions               | Step                                                                         | Branching Action                                                                                                                           |
|                          | 2a.                                                                          | If the project does not display correctly on the main page, the web developer troubleshoots and resolves the issue, then repeats steps 2-3 |

## Requirement 3:

### W3. Add attractive images of the game to the website (Non-functional, WEB)

<!-- | Use case name            | W3. Add attractive game images to the website        |
| ------------------------ | ---------------------------------------------------- |
| Related Requirements     | W1                                                   |
| Goal In Context          | Enhance the website's visual appeal with game images |
| Preconditions            | W1 completed                                         |
| Successful End Condition | Attractive game images added to the website          |
| Failed End Condition     | Game images not added or not visually appealing      |
| Primary Actors           | Web developers, Graphic designers                    |
| Secondary Actors         | N/A                                                  |
| Triggers                 | Completion of W1                                     | -->

| Use case name            | W3. Add attractive images of the game on the website                   |                                                                                                     |
| ------------------------ | ---------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------- |
| Related Requirements     | W1, W2                                                                 |                                                                                                     |
| Goal In Context          | Enhance the website's visual appeal with attractive images of the game |                                                                                                     |
| Preconditions            | Webpage created                                                        |                                                                                                     |
| Successful End Condition | Attractive images of the game added to the website                     |                                                                                                     |
| Failed End Condition     | Images not added or not visually appealing                             |                                                                                                     |
| Primary Actors           | Web developers                                                         |                                                                                                     |
| Secondary Actors         | None                                                                   |                                                                                                     |
| Triggers                 | The decision to improve the website's visual appeal                    |                                                                                                     |
| Main Flow                | Step                                                                   | Action                                                                                              |
|                          | 1.                                                                     | Web developer sources or creates attractive images of the game                                      |
|                          | 2.                                                                     | Web developer adds the images to the website in appropriate locations                               |
|                          | 3.                                                                     | Web developer tests the website to ensure images are displayed correctly and are visually appealing |
| Extensions               | Step                                                                   | Branching Action                                                                                    |

## Requirement 4:

### W4. Define the color palette of the website (Non-functional, WEB)

<!--
| Use case name            | W4. Define the website's color palette                               |
| ------------------------ | -------------------------------------------------------------------- |
| Related Requirements     | W1                                                                   |
| Goal In Context          | Choose a visually appealing color palette for the website            |
| Preconditions            | W1 completed                                                         |
| Successful End Condition | A consistent and visually appealing color palette chosen and applied |
| Failed End Condition     | Inconsistent or visually unappealing color palette chosen or applied |
| Primary Actors           | Web developers, Graphic designers                                    |
| Secondary Actors         | N/A                                                                  |
| Triggers                 | Completion of W1                                                     | -->

| Use case name            | W4. Define the color scheme of the webpage                                 |                                                                                                                                |
| ------------------------ | -------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------ |
| Related Requirements     | W1, W3                                                                     |                                                                                                                                |
| Goal In Context          | Establish a visually appealing and consistent color scheme for the website |                                                                                                                                |
| Preconditions            | Webpage created                                                            |                                                                                                                                |
| Successful End Condition | Color scheme defined and applied to the website                            |                                                                                                                                |
| Failed End Condition     | Color scheme not defined or not applied                                    |                                                                                                                                |
| Primary Actors           | Web developers                                                             |                                                                                                                                |
| Secondary Actors         | None                                                                       |                                                                                                                                |
| Triggers                 | The decision to create a visually appealing and consistent website         |                                                                                                                                |
| Main Flow                | Step                                                                       | Action                                                                                                                         |
|                          | 1.                                                                         | Web developer researches and selects a suitable color scheme                                                                   |
|                          | 2.                                                                         | Web developer applies the color scheme to the website's design elements                                                        |
|                          | 3.                                                                         | Web developer tests the website to ensure the color scheme is applied consistently and is visually appealing                   |
| Extensions               | Step                                                                       | Branching Action                                                                                                               |
|                          | 1a.                                                                        | If the chosen color scheme is not visually appealing, the web developer selects a different color scheme and repeats steps 1-3 |

## Requirement 5:

### W5. Create a secondary page within the website with the game manual (Non-functional, WEB)

<!--
| Use case name            | W5. Create a game manual page                      |
| ------------------------ | -------------------------------------------------- |
| Related Requirements     | W1                                                 |
| Goal In Context          | Provide a game manual for users within the website |
| Preconditions            | W1 completed                                       |
| Successful End Condition | Game manual page created and accessible            |
| Failed End Condition     | Game manual page not created or not accessible     |
| Primary Actors           | Web developers, Game designers                     |
| Secondary Actors         | N/A                                                |
| Triggers                 | Completion of W1                                   | -->

| Use case name            | W5. Secondary page within the website with the game manual                        |                                                                  |
| ------------------------ | --------------------------------------------------------------------------------- | ---------------------------------------------------------------- |
| Related Requirements     | W1, W4                                                                            |                                                                  |
| Goal In Context          | Provide a dedicated page on the website with instructions on how to play the game |                                                                  |
| Preconditions            | Webpage created                                                                   |                                                                  |
| Successful End Condition | Game manual page created and accessible from the main page                        |                                                                  |
| Failed End Condition     | Game manual page not created or not accessible                                    |                                                                  |
| Primary Actors           | Web developers                                                                    |                                                                  |
| Secondary Actors         | None                                                                              |                                                                  |
| Triggers                 | The decision to provide instructions for the game on the website                  |                                                                  |
| Main Flow                | Step                                                                              | Action                                                           |
|                          | 1.                                                                                | Web developer creates a new secondary page for the game manual   |
|                          | 2.                                                                                | Web developer adds the game manual content to the secondary page |
|                          | 3.                                                                                | Web developer links the game manual page to the main page        |

## Requirement 6:

### DB1. Create the entity-relationship diagram of the database (Non-functional, DB)

<!-- | Use case name            | DB1. Create entity-relationship diagram                 |
| ------------------------ | ------------------------------------------------------- |
| Related Requirements     | DB2, DB3, DB4                                           |
| Goal In Context          | Design the structure and relationships of the database  |
| Preconditions            | Database management system selected                     |
| Successful End Condition | Entity-relationship diagram created and approved        |
| Failed End Condition     | Entity-relationship diagram not created or not approved |
| Primary Actors           | Database designer                                       |
| Secondary Actors         | N/A                                                     |
| Triggers                 | Decision to create a database for the project           | -->

| Use case name            | DB1. Create the entity-relationship diagram of the database              |                                                                                                                      |
| ------------------------ | ------------------------------------------------------------------------ | -------------------------------------------------------------------------------------------------------------------- |
| Related Requirements     | DB2, DB3, DB4, WDB1                                                      |                                                                                                                      |
| Goal In Context          | Design the database structure by creating an entity-relationship diagram |                                                                                                                      |
| Preconditions            | Knowledge of the project's data requirements                             |                                                                                                                      |
| Successful End Condition | Entity-relationship diagram created and approved                         |                                                                                                                      |
| Failed End Condition     | Entity-relationship diagram not created or not approved                  |                                                                                                                      |
| Primary Actors           | Database developers                                                      |                                                                                                                      |
| Secondary Actors         | Stakeholders                                                             |                                                                                                                      |
| Triggers                 | The decision to design the database structure                            |                                                                                                                      |
| Main Flow                | Step                                                                     | Action                                                                                                               |
|                          | 1.                                                                       | Database developer identifies the entities, attributes, and relationships required for the project                   |
|                          | 2.                                                                       | Database developer creates the entity-relationship diagram                                                           |
|                          | 3.                                                                       | Project stakeholders review and approve the entity-relationship diagram                                              |
| Extensions               | Step                                                                     | Branching Action                                                                                                     |
|                          | 3a.                                                                      | If the entity-relationship diagram is not approved, the database developer revises the diagram and repeats steps 2-3 |

## Requirement 7:

### DB2. Implement the database and its tables (Functional, DB)

<!--
| Use case name            | DB2. Implement the database and tables                                  |
| ------------------------ | ----------------------------------------------------------------------- |
| Related Requirements     | DB1, DB3, DB4                                                           |
| Goal In Context          | Create the database and tables based on the entity-relationship diagram |
| Preconditions            | DB1 completed                                                           |
| Successful End Condition | Database and tables implemented successfully                            |
| Failed End Condition     | Database or tables not implemented successfully                         |
| Primary Actors           | Database developer                                                      |
| Secondary Actors         | N/A                                                                     |
| Triggers                 | Completion of DB1                                                       | -->

| Use case name            | DB2. Implement the database and its tables                                           |                                                                                                 |
| ------------------------ | ------------------------------------------------------------------------------------ | ----------------------------------------------------------------------------------------------- |
| Related Requirements     | DB1, DB3, DB4, WDB1                                                                  |                                                                                                 |
| Goal In Context          | Create the database and its tables based on the approved entity-relationship diagram |                                                                                                 |
| Preconditions            | Entity-relationship diagram approved                                                 |                                                                                                 |
| Successful End Condition | Database and tables implemented                                                      |                                                                                                 |
| Failed End Condition     | Database and tables not implemented                                                  |                                                                                                 |
| Primary Actors           | Database developers                                                                  |                                                                                                 |
| Secondary Actors         | None                                                                                 |                                                                                                 |
| Triggers                 | The decision to build the storage and sorter of game data                            |                                                                                                 |
| Main Flow                | Step                                                                                 | Action                                                                                          |
|                          | 1.                                                                                   | Database developer creates the database and tables according to the entity-relationship diagram |
|                          | 2.                                                                                   | Database developer tests the database and tables to ensure they function as expected            |

## Requirement 8:

### DB3. Create a stats table and link it with the user (Functional, DB)

<!--
| Use case name            | DB3. Create and link user stats table                              |
| ------------------------ | ------------------------------------------------------------------ |
| Related Requirements     | DB1, DB2, DB4                                                      |
| Goal In Context          | Design and implement a stats table and associate it with user data |
| Preconditions            | DB1 and DB2 completed                                              |
| Successful End Condition | Stats table created and linked with user data                      |
| Failed End Condition     | Stats table not created or not linked with user data               |
| Primary Actors           | Database developer                                                 |
| Secondary Actors         | N/A                                                                |
| Triggers                 | Completion of DB1 and DB2                                          | -->

| Use case name            | DB3. Create a stats table and link it with the user                           |                                                                                                 |
| ------------------------ | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------- |
| Related Requirements     | DB1, DB2, DB4, WDB1                                                           |                                                                                                 |
| Goal In Context          | Implement a stats table and associate it with the user entity in the database |                                                                                                 |
| Preconditions            | Database and tables implemented                                               |                                                                                                 |
| Successful End Condition | Stats table created and linked with the user                                  |                                                                                                 |
| Failed End Condition     | Stats table not created or not linked with the user                           |                                                                                                 |
| Primary Actors           | Database developers                                                           |                                                                                                 |
| Secondary Actors         | None                                                                          |                                                                                                 |
| Triggers                 | The decision to track user statistics                                         |                                                                                                 |
| Main Flow                | Step                                                                          | Action                                                                                          |
|                          | 1.                                                                            | Database developer creates the stats table and defines its structure                            |
|                          | 2.                                                                            | Database developer links the stats table with the user entity                                   |
|                          | 3.                                                                            | Database developer tests the functionality of the stats table and its association with the user |

## Requirement 9:

### DB4. Implement CRUD in the database (Functional, DB)

<!-- | Use case name            | DB4. Implement CRUD operations in the database               |
| ------------------------ | ------------------------------------------------------------ |
| Related Requirements     | DB1, DB2, DB3                                                |
| Goal In Context          | Enable CRUD operations for the database tables               |
| Preconditions            | DB1, DB2, and DB3 completed                                  |
| Successful End Condition | CRUD operations implemented and functioning correctly        |
| Failed End Condition     | CRUD operations not implemented or not functioning correctly |
| Primary Actors           | Database developer                                           |
| Secondary Actors         | N/A                                                          |
| Triggers                 | Completion of DB1, DB2, and DB3                              | -->

| Use case name            | DB4. Implement CRUD in the database                                          |                                                                                                          |
| ------------------------ | ---------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------- |
| Related Requirements     | DB1, DB2, DB3, WDB1, WDB2, WDB3, UDB1                                        |                                                                                                          |
| Goal In Context          | Implement Create, Read, Update, and Delete (CRUD) operations in the database |                                                                                                          |
| Preconditions            | Database and its tables created and configured                               |                                                                                                          |
| Successful End Condition | CRUD operations functioning correctly in the database                        |                                                                                                          |
| Failed End Condition     | CRUD operations not functioning correctly in the database                    |                                                                                                          |
| Primary Actors           | Database administrators                                                      |                                                                                                          |
| Secondary Actors         | None                                                                         |                                                                                                          |
| Triggers                 | The need for managing data in the database                                   |                                                                                                          |
| Main Flow                | Step                                                                         | Action                                                                                                   |
|                          | 1.                                                                           | Database administrator defines CRUD operations for each table in the database                            |
|                          | 2.                                                                           | Database administrator implements the CRUD operations using appropriate programming techniques and tools |
|                          | 3.                                                                           | Database administrator tests the CRUD operations to ensure they function as expected                     |

## Requirement 10:

### U1. Create a project in Unity (Functional, UNITY/Video games)

<!-- | Use case name            | U1. Create a project in Unity                   |
| ------------------------ | ----------------------------------------------- |
| Related Requirements     | U2, U3, U4, U5, U6                              |
| Goal In Context          | Set up a Unity project as the base for the game |
| Preconditions            | Unity software installed, game concept defined  |
| Successful End Condition | Unity project created and configured            |
| Failed End Condition     | Unity project not created or not configured     |
| Primary Actors           | Game developer                                  |
| Secondary Actors         | N/A                                             |
| Triggers                 | Decision to create a game in Unity              | -->

| Use case name            | U1. Create a Unity project                           |                                                                                |
| ------------------------ | ---------------------------------------------------- | ------------------------------------------------------------------------------ |
| Related Requirements     | U2, U3, U4, U5, U6                                   |                                                                                |
| Goal In Context          | Set up a new Unity project for the game development  |                                                                                |
| Preconditions            | Unity installed, knowledge of Unity game development |                                                                                |
| Successful End Condition | Unity project created and configured                 |                                                                                |
| Primary Actors           | Game developers                                      |                                                                                |
| Secondary Actors         | None                                                 |                                                                                |
| Triggers                 | The decision to develop the game using Unity         |                                                                                |
| Main Flow                | Step                                                 | Action                                                                         |
|                          | 1.                                                   | Game developer opens Unity and creates a new project                           |
|                          | 2.                                                   | Game developer configures project settings and organizes the project structure |
|                          | 3.                                                   | Game developer imports necessary assets and plugins                            |

## Requirement 11:

### U2. Define and integrate Sound Effects (Non-functional, UNITY/Video games)

<!-- | Use case name            | U2. Define and integrate sound effects                    |
| ------------------------ | --------------------------------------------------------- |
| Related Requirements     | U1                                                        |
| Goal In Context          | Create and add appropriate sound effects for the game     |
| Preconditions            | U1 completed                                              |
| Successful End Condition | Sound effects defined, created, and integrated            |
| Failed End Condition     | Sound effects not defined, not created, or not integrated |
| Primary Actors           | Sound designer, Game developer                            |
| Secondary Actors         | N/A                                                       |
| Triggers                 | Completion of U1                                          | -->

| Use case name            | U2. Define and integrate Sound Effects             |                                                                                        |
| ------------------------ | -------------------------------------------------- | -------------------------------------------------------------------------------------- |
| Related Requirements     | U1, U3, U4, U5, U6                                 |                                                                                        |
| Goal In Context          | Design and implement sound effects for the game    |                                                                                        |
| Preconditions            | Unity project created                              |                                                                                        |
| Successful End Condition | Sound effects defined and integrated into the game |                                                                                        |
| Failed End Condition     | Sound effects not defined or not integrated        |                                                                                        |
| Primary Actors           | Game developers, creative developers               |                                                                                        |
| Secondary Actors         | None                                               |                                                                                        |
| Triggers                 | The decision to include sound effects in the game  |                                                                                        |
| Main Flow                | Step                                               | Action                                                                                 |
|                          | 1.                                                 | Creative developer creates or sources suitable sound effects                           |
|                          | 2.                                                 | Game developer imports the sound effects into the Unity project                        |
|                          | 3.                                                 | Game developer implements the sound effects in the game logic                          |
|                          | 4.                                                 | Game developer tests the sound effects in the game to ensure they function as intended |

## Requirement 12:

### U3. Compose and implement Music (Non-functional, UNITY/Video games)

<!--
| Use case name            | U3. Compose and implement music                 |
| ------------------------ | ----------------------------------------------- |
| Related Requirements     | U1                                              |
| Goal In Context          | Compose and add background music for the game   |
| Preconditions            | U1 completed                                    |
| Successful End Condition | Background music composed and integrated        |
| Failed End Condition     | Background music not composed or not integrated |
| Primary Actors           | Composer, Game developer                        |
| Secondary Actors         | N/A                                             |
| Triggers                 | Completion of U1                                | -->

| Use case name            | U3. Compose and implement Music                        |                                                                                          |
| ------------------------ | ------------------------------------------------------ | ---------------------------------------------------------------------------------------- |
| Related Requirements     | U1, U2, U4, U5, U6                                     |                                                                                          |
| Goal In Context          | Design and implement background music for the game     |                                                                                          |
| Preconditions            | Unity project created                                  |                                                                                          |
| Successful End Condition | Background music composed and integrated into the game |                                                                                          |
| Failed End Condition     | Background music not composed or not integrated        |                                                                                          |
| Primary Actors           | Game developers, creative developers                   |                                                                                          |
| Secondary Actors         | None                                                   |                                                                                          |
| Triggers                 | The decision to include background music in the game   |                                                                                          |
| Main Flow                | Step                                                   | Action                                                                                   |
|                          | 1.                                                     | Creative developer creates or sources suitable background music for the game             |
|                          | 2.                                                     | Game developer imports the background music into the Unity project                       |
|                          | 3.                                                     | Game developer implements the background music in the game logic                         |
|                          | 4.                                                     | Game developer tests the background music in the game to ensure it functions as intended |

## Requirement 13:

### U4. Develop Prefabs (Functional, UNITY/Video games)

<!-- | Use case name            | U4. Develop prefabs                                   |
| ------------------------ | ----------------------------------------------------- |
| Related Requirements     | U1                                                    |
| Goal In Context          | Create reusable prefabs for game objects and elements |
| Preconditions            | U1 completed                                          |
| Successful End Condition | Prefabs created and functioning properly              |
| Failed End Condition     | Prefabs not created or not functioning properly       |
| Primary Actors           | Game developer                                        |
| Secondary Actors         | N/A                                                   |
| Triggers                 | Completion of U1                                      | -->

| Use case name            | U4. Develop Prefabs                                    |                                                                      |
| ------------------------ | ------------------------------------------------------ | -------------------------------------------------------------------- |
| Related Requirements     | U1, U2, U3, U5, U6                                     |                                                                      |
| Goal In Context          | Create reusable prefabs for efficient game development |                                                                      |
| Preconditions            | Unity project created                                  |                                                                      |
| Successful End Condition | Prefabs created and functioning as intended            |                                                                      |
| Failed End Condition     | Prefabs not created or not functioning as intended     |                                                                      |
| Primary Actors           | Game developers                                        |                                                                      |
| Secondary Actors         | None                                                   |                                                                      |
| Triggers                 | The need for reusable game objects in the game         |                                                                      |
| Main Flow                | Step                                                   | Action                                                               |
|                          | 1.                                                     | Game developer identifies necessary prefabs for the game             |
|                          | 2.                                                     | Game developer creates prefabs in Unity                              |
|                          | 3.                                                     | Game developer tests the prefabs to ensure they function as intended |

## Requirement 14:

### U5. Create Scenery (Non-functional, UNITY/Video games)

<!-- | Use case name            | U5. Create scenery                                   |
| ------------------------ | ---------------------------------------------------- |
| Related Requirements     | U1                                                   |
| Goal In Context          | Design and implement visually appealing game scenery |
| Preconditions            | U1 completed                                         |
| Successful End Condition | Game scenery created and implemented                 |
| Failed End Condition     | Game scenery not created or not implemented          |
| Primary Actors           | Game developer, Graphic designer                     |
| Secondary Actors         | N/A                                                  |
| Triggers                 | Completion of U1                                     | -->

| Use case name            | U5. Create backgrounds (scenery)                                 |                                                                                      |
| ------------------------ | ---------------------------------------------------------------- | ------------------------------------------------------------------------------------ |
| Related Requirements     | U1, U2, U3, U4, U6                                               |                                                                                      |
| Goal In Context          | Design and implement visually appealing backgrounds for the game |                                                                                      |
| Preconditions            | Unity project created                                            |                                                                                      |
| Successful End Condition | Backgrounds created and integrated into the game                 |                                                                                      |
| Failed End Condition     | Backgrounds not created or not integrated                        |                                                                                      |
| Primary Actors           | Creative developers                                              |                                                                                      |
| Secondary Actors         | Game developers                                                  |                                                                                      |
| Triggers                 | The need for visually appealing backgrounds in the game          |                                                                                      |
| Main Flow                | Step                                                             | Action                                                                               |
|                          | 1.                                                               | Creative developer designs backgrounds for the game                                  |
|                          | 2.                                                               | Game developer imports the backgrounds into the Unity project                        |
|                          | 3.                                                               | Game developer implements the backgrounds in the game logic                          |
|                          | 4.                                                               | Game developer tests the backgrounds in the game to ensure they function as intended |

## Requirement 15:

### U6. Implement game mechanics (Functional, UNITY/Video games)

<!-- | Use case name            | U6. Implement game mechanics                               |
| ------------------------ | ---------------------------------------------------------- |
| Related Requirements     | U1                                                         |
| Goal In Context          | Design and develop the core game mechanics                 |
| Preconditions            | U1 completed                                               |
| Successful End Condition | Game mechanics implemented and functioning properly        |
| Failed End Condition     | Game mechanics not implemented or not functioning properly |
| Primary Actors           | Game developer                                             |
| Secondary Actors         | N/A                                                        |
| Triggers                 | Completion of U1                                           | -->

| Use case name            | U6. Implement Game Mechanics                                  |                                                                             |
| ------------------------ | ------------------------------------------------------------- | --------------------------------------------------------------------------- |
| Related Requirements     | U1, U2, U3, U4, U5                                            |                                                                             |
| Goal In Context          | Develop and integrate core game mechanics                     |                                                                             |
| Preconditions            | Unity project created                                         |                                                                             |
| Successful End Condition | Game mechanics implemented and functioning as intended        |                                                                             |
| Failed End Condition     | Game mechanics not implemented or not functioning as intended |                                                                             |
| Primary Actors           | Game developers                                               |                                                                             |
| Secondary Actors         | None                                                          |                                                                             |
| Triggers                 | The need for core game mechanics in the game                  |                                                                             |
| Main Flow                | Step                                                          | Action                                                                      |
|                          | 1.                                                            | Game developer designs and plans the core game mechanics                    |
|                          | 2.                                                            | Game developer implements the game mechanics in Unity                       |
|                          | 3.                                                            | Game developer tests the game mechanics to ensure they function as intended |

## Requirement 16:

### G1. UML General of the entire system (Non-functional, DB, UNITY/Video games, WEB)

<!-- | Use case name            | G1. UML General of the entire system                     |
| ------------------------ | -------------------------------------------------------- |
| Related Requirements     | All other requirements                                   |
| Goal In Context          | Create a comprehensive UML diagram for the entire system |
| Preconditions            | All other requirements defined                           |
| Successful End Condition | UML diagram created and approved                         |
| Failed End Condition     | UML diagram not created or not approved                  |
| Primary Actors           | System architect, Developers                             |
| Secondary Actors         | N/A                                                      |
| Triggers                 | Decision to create a UML diagram                         | -->

| Use case name            | G1. General UML of the entire system                                                 |                                                                                     |
| ------------------------ | ------------------------------------------------------------------------------------ | ----------------------------------------------------------------------------------- |
| Related Requirements     | G2, DB1, DB2, DB3, DB4, U1, U2, U3, U4, U5, U6, W1, W2, W3, W4, W5, WDB1, WDB2, WDB3 |                                                                                     |
| Goal In Context          | Create a comprehensive UML diagram for the system                                    |                                                                                     |
| Preconditions            | All components designed and implemented                                              |                                                                                     |
| Successful End Condition | UML diagram accurately represents the system and its components                      |                                                                                     |
| Failed End Condition     | UML diagram does not accurately represent the system and its components              |                                                                                     |
| Primary Actors           | System architects                                                                    |                                                                                     |
| Secondary Actors         | Game developers                                                                      |                                                                                     |
| Triggers                 | The need for a visual representation of the system                                   |                                                                                     |
| Main Flow                | Step                                                                                 | Action                                                                              |
|                          | 1.                                                                                   | System architect identifies all components and their relationships                  |
|                          | 2.                                                                                   | System architect creates the UML diagram                                            |
|                          | 3.                                                                                   | System architect and developers review the UML diagram for accuracy and consistency |

## Requirement 17:

### G2. Create use case tables (Non-functional, WEB, UNITY/Video games, DB)

<!--
| Use case name            | G2. Create use case tables                      |
| ------------------------ | ----------------------------------------------- |
| Related Requirements     | G1, All other requirements                      |
| Goal In Context          | Create use case tables based on the UML diagram |
| Preconditions            | G1 completed                                    |
| Successful End Condition | Use case tables created and approved            |
| Failed End Condition     | Use case tables not created or not approved     |
| Primary Actors           | System architect, Developers                    |
| Secondary Actors         | N/A                                             |
| Triggers                 | Completion of G1                                | -->

| Use case name            | G2. Create use case tables                                                           |                                                                                         |
| ------------------------ | ------------------------------------------------------------------------------------ | --------------------------------------------------------------------------------------- |
| Related Requirements     | G1, DB1, DB2, DB3, DB4, U1, U2, U3, U4, U5, U6, W1, W2, W3, W4, W5, WDB1, WDB2, WDB3 |                                                                                         |
| Goal In Context          | Develop use case tables for all components and requirements                          |                                                                                         |
| Preconditions            | All components and requirements defined                                              |                                                                                         |
| Successful End Condition | Use case tables created for all components and requirements                          |                                                                                         |
| Failed End Condition     | Use case tables not created or incomplete                                            |                                                                                         |
| Primary Actors           | System architects                                                                    |                                                                                         |
| Secondary Actors         | Game developers                                                                      |                                                                                         |
| Triggers                 | The need for detailed documentation of the system's use cases                        |                                                                                         |
| Main Flow                | Step                                                                                 | Action                                                                                  |
|                          | 1.                                                                                   | System architect identifies all components and their related requirements               |
|                          | 2.                                                                                   | System architect and developers create use case tables for all components               |
|                          | 3.                                                                                   | System architect and developers review the use case tables for accuracy and consistency |

## Requirement 18:

### WDB1. Create authentication system logic (Functional, WEB, DB)

<!-- | Use case name            | WDB1. Create authentication system logic                          |
| ------------------------ | ----------------------------------------------------------------- |
| Related Requirements     | W1, DB1, DB2, DB3                                                 |
| Goal In Context          | Implement a secure authentication system for the website          |
| Preconditions            | W1 and DB1-DB3 completed                                          |
| Successful End Condition | Authentication system implemented and functioning properly        |
| Failed End Condition     | Authentication system not implemented or not functioning properly |
| Primary Actors           | Web developer, Database developer                                 |
| Secondary Actors         | N/A                                                               |
| Triggers                 | Completion of W1 and DB1-DB3                                      | -->

| Use case name            | WDB1. Create identification system (auth) logic                                        |                                                                                                                             |
| ------------------------ | -------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------- |
| Related Requirements     | W1, W2, DB1, DB2, DB3, DB4, WDB2, WDB3, UDB1                                           |                                                                                                                             |
| Goal In Context          | Implement an authentication system for users to access restricted parts of the website |                                                                                                                             |
| Preconditions            | Web development tools, web server, and database configured                             |                                                                                                                             |
| Successful End Condition | Authentication system functions correctly and securely                                 |                                                                                                                             |
| Failed End Condition     | Authentication system does not function correctly or securely                          |                                                                                                                             |
| Primary Actors           | Web developers, database administrators                                                |                                                                                                                             |
| Secondary Actors         | None                                                                                   |                                                                                                                             |
| Triggers                 | The need for secure user access to restricted parts of the website                     |                                                                                                                             |
| Main Flow                | Step                                                                                   | Action                                                                                                                      |
|                          | 1.                                                                                     | Web developer and database administrator design the authentication system and its requirements                              |
|                          | 2.                                                                                     | Web developer implements the authentication logic using appropriate programming techniques and tools                        |
|                          | 3.                                                                                     | Database administrator creates and configures necessary database tables and structures to support the authentication system |
|                          | 4.                                                                                     | Web developer and database administrator test the authentication system to ensure it functions as expected and securely     |

## Requirement 19:

### WDB2. Create secondary webpage with stats linked to the database (Functional, WEB, DB)

<!-- | Use case name            | WDB2. Create secondary webpage with stats linked to the database                     |
| ------------------------ | ------------------------------------------------------------------------------------ |
| Related Requirements     | W1, WDB1, DB3                                                                        |
| Goal In Context          | Design and implement a stats page linked to the database                             |
| Preconditions            | W1, WDB1, and DB3 completed                                                          |
| Successful End Condition | Stats page created, linked to the database, and displaying data correctly            |
| Failed End Condition     | Stats page not created, not linked to the database, or not displaying data correctly |
| Primary Actors           | Web developer, Database developer                                                    |
| Secondary Actors         | N/A                                                                                  |
| Triggers                 | Completion of W1, WDB1, and DB3                                                      | -->

| Use case name            | WDB2. Secondary page within the website for stats with the table linked to the database |                                                                                        |
| ------------------------ | --------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------- |
| Related Requirements     | W1, W5, WDB1, WDB3, DB1, DB2, DB3, DB4                                                  |                                                                                        |
| Goal In Context          | Display user statistics on a secondary page within the website                          |                                                                                        |
| Preconditions            | Web server, database server, and development tools configured                           |                                                                                        |
| Successful End Condition | Secondary page created and displaying user statistics                                   |                                                                                        |
| Failed End Condition     | Secondary page not created or not displaying user statistics                            |                                                                                        |
| Primary Actors           | Web developers                                                                          |                                                                                        |
| Secondary Actors         | None                                                                                    |                                                                                        |
| Triggers                 | The need for user statistics to be displayed on the website                             |                                                                                        |
| Main Flow                | Step                                                                                    | Action                                                                                 |
|                          | 1.                                                                                      | Web developer designs the secondary page layout and user statistics table              |
|                          | 2.                                                                                      | Web developer implements the secondary page on the web server                          |
|                          | 3.                                                                                      | Web developer integrates the general communication with the database                   |
|                          | 4.                                                                                      | Web developer tests the secondary page to ensure it displays user statistics correctly |

## Requirement 20:

### WDB3. Define host for the webpage and database (Functional, WEB, DB)

<!-- | Use case name            | WDB3. Define host for the webpage and database            |
| ------------------------ | --------------------------------------------------------- |
| Related Requirements     | W1, DB1, DB2, DB3, WDB1, WDB2                             |
| Goal In Context          | Choose and configure hosting for the webpage and database |
| Preconditions            | W1, DB1-DB3, WDB1, and WDB2 completed                     |
| Successful End Condition | Webpage and database hosted and accessible online         |
| Failed End Condition     | Webpage or database not hosted or not accessible online   |
| Primary Actors           | Web developer, Database developer                         |
| Secondary Actors         | Hosting service provider                                  |
| Triggers                 | Completion of W1, DB1-DB3, WDB1, and WDB2                 | -->

| Use case name            | WDB3. Define host for the website and the database            |                                                                                                                 |
| ------------------------ | ------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------- |
| Related Requirements     | W1, W2, W3, W4, W5, WDB1, WDB2, DB1, DB2, DB3, DB4            |                                                                                                                 |
| Goal In Context          | Set up hosting for the website and database                   |                                                                                                                 |
| Preconditions            | Web server, database server, and development tools configured |                                                                                                                 |
| Successful End Condition | Website and database hosted and accessible                    |                                                                                                                 |
| Failed End Condition     | Website and database not hosted or not accessible             |                                                                                                                 |
| Primary Actors           | Web developers, database administrators                       |                                                                                                                 |
| Secondary Actors         | None                                                          |                                                                                                                 |
| Triggers                 | The need to host the website and database                     |                                                                                                                 |
| Main Flow                | Step                                                          | Action                                                                                                          |
|                          | 1.                                                            | Web developer and database administrator select a suitable hosting provider                                     |
|                          | 2.                                                            | Web developer and database administrator configure hosting settings and deploy the website and database         |
|                          | 3.                                                            | Web developer and database administrator test the hosted website and database for accessibility and performance |

## Requirement 21:

### UDB1. Connect database with the game (Functional, UNITY/Video games, DB)

<!-- | Use case name            | UDB1. Connect database with the game                           |
| ------------------------ | -------------------------------------------------------------- |
| Related Requirements     | U1, DB1, DB2, DB3                                              |
| Goal In Context          | Integrate the database with the Unity game                     |
| Preconditions            | U1 and DB1-DB3 completed                                       |
| Successful End Condition | Database connected to the game, data exchange working properly |
| Failed End Condition     | Database not connected or data exchange not working properly   |
| Primary Actors           | Unity developer, Database developer                            |
| Secondary Actors         | N/A                                                            |
| Triggers                 | Completion of U1 and DB1-DB3                                   | -->

| Use case name            | UDB1. Connect the database with the game                                      |                                                                                        |
| ------------------------ | ----------------------------------------------------------------------------- | -------------------------------------------------------------------------------------- |
| Related Requirements     | U1, U2, U3, U4, U5, U6, DB1, DB2, DB3, DB4                                    |                                                                                        |
| Goal In Context          | Integrate the game with the database for storing and retrieving data          |                                                                                        |
| Preconditions            | Unity project created, database implemented                                   |                                                                                        |
| Successful End Condition | Game connected to the database and data exchange functioning correctly        |                                                                                        |
| Failed End Condition     | Game not connected to the database or data exchange not functioning correctly |                                                                                        |
| Primary Actors           | Game developers, database administrators                                      |                                                                                        |
| Secondary Actors         | None                                                                          |                                                                                        |
| Triggers                 | The need for data exchange between the game and the database                  |                                                                                        |
| Main Flow                | Step                                                                          | Action                                                                                 |
|                          | 1.                                                                            | Game developer identifies data exchange requirements between the game and the database |
|                          | 2.                                                                            | Game developer implements the connection between the game and the database             |

DROP SCHEMA IF EXISTS quetzal;
CREATE SCHEMA quetzal;
-- First we create the database
-- Now we use the database
USE quetzal;

-- Create the tables:
CREATE TABLE Players (
    player_id INT PRIMARY KEY NOT NULL UNIQUE,
    user_name VARCHAR(20) NOT NULL,
    runs INT,
    slot_1 INT,
    slot_2 INT,
    slot_3 INT,
    FOREIGN KEY (slot_1) REFERENCES Sessions (session_id),
    FOREIGN KEY (slot_2) REFERENCES Sessions (session_id),
    FOREIGN KEY (slot_3) REFERENCES Sessions (session_id)
);

CREATE INDEX idx_players_user_name ON Players(user_name);

CREATE TABLE Sessions (
    session_id INT PRIMARY KEY NOT NULL UNIQUE,
    player_id INT NOT NULL,
    damage FLOAT NOT NULL,
    health FLOAT NOT NULL,
    mana FLOAT NOT NULL,
    speed FLOAT NOT NULL,
    defense FLOAT NOT NULL,
    play_time TIME NOT NULL,
    finished BOOLEAN NOT NULL DEFAULT FALSE,
    FOREIGN KEY (player_id) REFERENCES Players (player_id)
);

CREATE INDEX idx_sessions_player_id ON Sessions(player_id);
CREATE INDEX idx_sessions_finished ON Sessions(finished);

CREATE TABLE Items (
    item_id INT PRIMARY KEY NOT NULL UNIQUE,
    name VARCHAR(20) NOT NULL,
    damage_change FLOAT,
    defense_change FLOAT,
    health_change FLOAT,
    mana_change FLOAT,
    speed_change FLOAT,
    times_chosen INT NOT NULL
);

CREATE INDEX idx_items_name ON Items(name);

CREATE TABLE Dialogs (
    dialog_id INT PRIMARY KEY NOT NULL UNIQUE,
    text VARCHAR(255) NOT NULL
);

CREATE TABLE NPCs (
    npc_id INT PRIMARY KEY NOT NULL UNIQUE,
    dialog_id INT NOT NULL,
    name VARCHAR(20) NOT NULL,
    FOREIGN KEY (dialog_id) REFERENCES Dialogs (dialog_id)
);

CREATE INDEX idx_npcs_dialog_id ON NPCs(dialog_id);

CREATE TABLE Dialog_NPC (
    id INT PRIMARY KEY NOT NULL UNIQUE,
    dialog_id INT NOT NULL,
    npc_id INT NOT NULL,
    FOREIGN KEY (dialog_id) REFERENCES Dialogs (dialog_id),
    FOREIGN KEY (npc_id) REFERENCES NPCs (npc_id)
);

CREATE INDEX idx_dialog_npc_dialog_id ON Dialog_NPC(dialog_id);
CREATE INDEX idx_dialog_npc_npc_id ON Dialog_NPC(npc_id);

CREATE TABLE Enemies (
    enemy_id INT PRIMARY KEY NOT NULL UNIQUE,
    health FLOAT NOT NULL,
    damage FLOAT NOT NULL,
    speed FLOAT NOT NULL,
    name VARCHAR(20) NOT NULL
);

CREATE INDEX idx_enemies_name ON Enemies(name);

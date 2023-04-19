DROP SCHEMA IF EXISTS quetzal;

-- First we create the database
CREATE SCHEMA quetzal;

-- Use the new schema
USE quetzal;
-- Create the tables:
CREATE TABLE Players (
    player_id INT PRIMARY KEY NOT NULL UNIQUE,
    user_name VARCHAR(20) NOT NULL,
    runs INT,
    slot_1 INT,
    slot_2 INT,
    slot_3 INT
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
    play_time DATETIME NOT NULL,
    finished BOOLEAN NOT NULL DEFAULT FALSE,
    CONSTRAINT chk_health_player_range CHECK (health >= 1 AND health <= 1000),
    CONSTRAINT chk_mana_player_range CHECK (mana >= 0 AND mana <= 300),
    CONSTRAINT chk_defense_player_range CHECK (defense >= 0 AND defense <= 250),
    CONSTRAINT chk_damage_player_range CHECK (damage >= 0 AND damage <= 125),
    CONSTRAINT chk_speed_player_range CHECK (speed >= 1 AND speed <= 8)
);

CREATE INDEX idx_sessions_player_id ON Sessions(player_id);
CREATE INDEX idx_sessions_finished ON Sessions(finished);

-- Add foreign key constraints to Players table
ALTER TABLE Players
ADD FOREIGN KEY (slot_1) REFERENCES Sessions (session_id),
ADD FOREIGN KEY (slot_2) REFERENCES Sessions (session_id),
ADD FOREIGN KEY (slot_3) REFERENCES Sessions (session_id);


CREATE TABLE Items (
    item_id INT PRIMARY KEY NOT NULL UNIQUE,
    name VARCHAR(20) NOT NULL,
    damage_change FLOAT,
    defense_change FLOAT,
    health_change FLOAT,
    mana_change FLOAT,
    speed_change FLOAT,
    times_chosen INT NOT NULL,
    CONSTRAINT chk_health_item_range CHECK (health_change >= -100 AND health_change <= 100),
    CONSTRAINT chk_mana_item_range CHECK (mana_change >= -50 AND mana_change <= 50),
    CONSTRAINT chk_defense_item_range CHECK (defense_change >= -60 AND defense_change <= 60),
    CONSTRAINT chk_damage_item_range CHECK (damage_change >= -50 AND damage_change <= 50),
    CONSTRAINT chk_speed_item_range CHECK (speed_change >= -2 AND speed_change <= 2)
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
    name VARCHAR(20) NOT NULL,
    CONSTRAINT chk_health_enemy_range CHECK (health >= 0 AND health <= 2000),
    CONSTRAINT chk_damage_enemy_range CHECK (damage >= 0 AND damage <= 150),
    CONSTRAINT chk_speed_enemy_range CHECK (speed >= 1 AND speed <= 7)
);

CREATE INDEX idx_enemies_name ON Enemies(name);
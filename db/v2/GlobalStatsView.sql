CREATE VIEW stats_view AS
SELECT 
    COUNT(*) AS total_game_runs,
    SUM(play_time) AS total_play_time,
    AVG(play_time) AS average_play_time,
    AVG(damage) AS average_damage,
    AVG(health) AS average_health,
    AVG(mana) AS average_mana,
    AVG(defense) AS average_defense,
    AVG(speed) AS average_speed,
    SUM(CASE WHEN finished = TRUE THEN 1 ELSE 0 END) AS total_sessions_finished
FROM Sessions;

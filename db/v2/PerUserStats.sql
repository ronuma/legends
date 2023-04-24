CREATE VIEW global_statistics AS
SELECT
       SUM(CASE WHEN finished = 1 THEN 1 ELSE 0 END) AS total_finished_runs,
       Players.user_name,
       MIN(play_time) AS fastest_run_time
     FROM
       Sessions
     JOIN Players ON Sessions.email = Players.email
     WHERE
       finished = 1
     GROUP BY
       Players.user_name
     ORDER BY
       fastest_run_time ASC;
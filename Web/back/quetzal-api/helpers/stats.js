import connectToDB from "../index.js";

export async function getStats() {
   const db = await connectToDB();

   const [items] = await db.query("SELECT * FROM sorted_items_view");
   const [stats] = await db.execute("SELECT * FROM stats_view");

   const {
      total_game_runs: totalGameRuns,
      average_play_time: averagePlayTime,
      average_damage: damage,
      average_health: health,
      average_mana: mana,
      average_defense: defense,
      average_speed: speed,
      total_sessions_finished: totalSessionsFinished,
   } = stats[0];

   const averageSessionStats = {damage, health, mana, defense, speed};
   db.end();
   return {
      mostUsedItems: items,
      totalGameRuns,
      averagePlayTime,
      averageSessionStats,
      totalSessionsFinished,
   };
}

import connectToDB from "../index.js";
import {statLimits} from "../constants.js";

// Normalizar las estadísticas utilizando la fórmula min-max
const normalizeStat = (statValue, min, max) => (statValue - min) / (max - min);

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

   const normalizedStats = {
      damage: normalizeStat(
         damage,
         statLimits.damage.min,
         statLimits.damage.max
      ),
      health: normalizeStat(
         health,
         statLimits.health.min,
         statLimits.health.max
      ),
      mana: normalizeStat(mana, statLimits.mana.min, statLimits.mana.max),
      defense: normalizeStat(
         defense,
         statLimits.defense.min,
         statLimits.defense.max
      ),
      speed: normalizeStat(speed, statLimits.speed.min, statLimits.speed.max),
   };

   db.end();
   return {
      mostUsedItems: items,
      totalGameRuns,
      averagePlayTime,
      averageSessionStats: normalizedStats,
      totalSessionsFinished,
   };
}

// Top 10 players by number of finished runs
export async function getTop10() {
   const db = await connectToDB();

   const [top10] = await db.query("SELECT * FROM top10_view");
   db.end();
   return top10;
}

// get /run/:email selects the row from the Sessions table where the email matches the email in the request
export async function getUserRun(email) {
   const db = await connectToDB();
   const [results] = await db.execute(
      `SELECT * FROM quetzal.hero_sessions WHERE email = '${email}' ORDER BY session_id`
   );
   if (results.length === 0) {
      db.end();
      return {};
   }

   let averageStats = {
      health: 0,
      mana: 0,
      defense: 0,
      damage: 0,
      speed: 0,
   };

   let heroStats = {};

   for (const result of results) {
      averageStats.health += result.health;
      averageStats.mana += result.mana;
      averageStats.defense += result.defense;
      averageStats.damage += result.damage;
      averageStats.speed += result.speed;

      // Add hero stats
      const heroName = result.hero_name;
      if (!heroStats[heroName]) {
         heroStats[heroName] = {runs: 0, finished_runs: 0};
      }
      heroStats[heroName].runs++;
      if (result.finished) {
         heroStats[heroName].finished_runs++;
      }
   }

   averageStats.health /= results.length;
   averageStats.mana /= results.length;
   averageStats.defense /= results.length;
   averageStats.damage /= results.length;
   averageStats.speed /= results.length;

   const normalizedStats = {
      damage: normalizeStat(
         averageStats.damage,
         statLimits.damage.min,
         statLimits.damage.max
      ),
      health: normalizeStat(
         averageStats.health,
         statLimits.health.min,
         statLimits.health.max
      ),
      mana: normalizeStat(
         averageStats.mana,
         statLimits.mana.min,
         statLimits.mana.max
      ),
      defense: normalizeStat(
         averageStats.defense,
         statLimits.defense.min,
         statLimits.defense.max
      ),
      speed: normalizeStat(
         averageStats.speed,
         statLimits.speed.min,
         statLimits.speed.max
      ),
   };

   db.end();
   return {
      runs: results.length,
      finished_runs: results.filter(result => result.finished).length,
      averageStats: normalizedStats,
      heroStats,
   };
}

import connectToDB from "../index.js";

export async function getStats() {
   const db = await connectToDB();

   const [items] = await db.execute("SELECT name, times_chosen FROM Items");
   const [players] = await db.execute("SELECT * FROM Players");
   const [sessions] = await db.execute("SELECT * FROM Sessions");

   const mostUsedItems = items.sort((a, b) => b.times_chosen - a.times_chosen);
   const totalGameRuns = players.length;

   let totalPlayTime = 0;
   let totalSessionStats = {
      damage: 0,
      health: 0,
      mana: 0,
      defense: 0,
      speed: 0,
   };
   let totalSessionsFinished = 0;

   for (const session of sessions) {
      totalPlayTime += session.play_time;
      totalSessionStats.damage += session.damage;
      totalSessionStats.health += session.health;
      totalSessionStats.mana += session.mana;
      totalSessionStats.defense += session.defense;
      totalSessionStats.speed += session.speed;

      if (session.finished) {
         totalSessionsFinished++;
      }
   }

   const averagePlayTime = totalPlayTime / sessions.length;

   const averageSessionStats = {
      damage: totalSessionStats.damage / sessions.length,
      health: totalSessionStats.health / sessions.length,
      mana: totalSessionStats.mana / sessions.length,
      defense: totalSessionStats.defense / sessions.length,
      speed: totalSessionStats.speed / sessions.length,
   };

   return {
      mostUsedItems,
      totalGameRuns,
      averagePlayTime,
      averageSessionStats,
      totalSessionsFinished,
   };
}

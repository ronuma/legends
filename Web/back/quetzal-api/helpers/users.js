import connectToDB from "../index.js";

export async function getData() {
   const db = await connectToDB();
   const [results] = await db.execute("SELECT * FROM quetzal.Players");
   return results;
}

export async function getStats() {
   const db = await connectToDB();
   const [results] = await db.execute("SELECT * FROM quetzal.Sessions");
   return results;
}

export async function getCurrentSession(sessionId) {
   const db = await connectToDB();
   const [results] = await db.execute(
      `SELECT * FROM quetzal.Sessions WHERE session_id = ${sessionId}`
   );
   return results[0];
}

export async function createSession(data) {
   // TODO: add increment to player's number of runs
   const db = await connectToDB();
   const {email, hero_id, memory_slot} = data;
   const [heroData] = await db.execute(
      `SELECT * FROM quetzal.Heroes WHERE id = ${hero_id}`
   );
   // get hero data from heroes table and insert into sessions table
   const {health, mana, defense, speed, damage} = heroData[0];
   await db.execute(
      "INSERT INTO quetzal.sessions (email, health, mana, defense, speed, damage, session_id, play_time) VALUES (?, ?, ?, ?, ?, ?, ?, ?)",
      [email, health, mana, defense, speed, damage, 1454474, 0]
   );
   const [sessionData] = await db.execute(
      `SELECT * FROM quetzal.Sessions WHERE email = \'${email}\' ORDER BY session_id DESC LIMIT 1`
   );
   const session_id = sessionData[0].session_id;
   const slotString = `slot_${memory_slot}`;
   await db.execute(
      `UPDATE quetzal.Players SET ${slotString} = ${session_id} WHERE email = \'${email}\'`
   );
   return sessionData[0];
}

export async function addData(email, user_name) {
   const db = await connectToDB();
   const [results] = await db.execute(
      `INSERT INTO quetzal.Players(email, user_name) VALUES(\'${email}\', \'${user_name}\')`
   );
   return results;
}

export async function updateStats(data) {
   const db = await connectToDB();
   const {health, mana, defense, speed, damage, session_id} = data;
   const [newResults] = await db.execute(
      "UPDATE quetzal.Sessions SET health = ?, mana = ?, defense = ?, speed = ?, damage = ? WHERE session_id = ?",
      [health, mana, defense, speed, damage, session_id]
   );
   return newResults;
}

export async function getUser(email) {
   const db = await connectToDB();
   const [results] = await db.execute(
      `SELECT * FROM quetzal.Players WHERE email = \'${email}\'`
   );
   return results[0];
}

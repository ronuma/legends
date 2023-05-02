import connectToDB from "../index.js";

export async function getData() {
   const db = await connectToDB();
   const [results] = await db.execute("SELECT * FROM quetzal.Players");
   db.end();
   return results;
}

export async function getStats() {
   const db = await connectToDB();
   const [results] = await db.execute("SELECT * FROM quetzal.Sessions");
   db.end();
   return results;
}

export async function getCurrentSession(session_id) {
   const db = await connectToDB();
   const [results] = await db.execute(
      `SELECT * FROM quetzal.Sessions WHERE session_id = ${session_id}`
   );
   db.end();
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
      "INSERT INTO quetzal.Sessions (email, health, mana, defense, speed, damage, play_time, hero_id) VALUES (?, ?, ?, ?, ?, ?, ?, ?)",
      [email, health, mana, defense, speed, damage, 0, hero_id]
   );
   const [sessionData] = await db.execute(
      `SELECT * FROM quetzal.Sessions WHERE email = \'${email}\' ORDER BY session_id DESC LIMIT 1`
   );
   const session_id = sessionData[0].session_id;
   const slotString = `slot_${memory_slot}`;
   await db.execute(
      `UPDATE quetzal.Players SET ${slotString} = ${session_id} WHERE email = \'${email}\'`
   );
   db.end();
   return sessionData[0].session_id;
}

export async function addData(email, user_name) {
   const db = await connectToDB();
   const [results] = await db.execute(
      `INSERT INTO quetzal.Players(email, user_name, runs) VALUES(\'${email}\', \'${user_name}\', 0)`
   );
   db.end();
   return results;
}

export async function selectItem(data) {
   const db = await connectToDB();
   const {health, mana, defense, speed, damage, session_id, item_id} = data;
   const [newResults] = await db.execute(
      "UPDATE quetzal.Sessions SET health = ?, mana = ?, defense = ?, speed = ?, damage = ? WHERE session_id = ?",
      [health, mana, defense, speed, damage, session_id]
   );
   await db.execute(
      `UPDATE quetzal.Items SET times_chosen = times_chosen + 1 WHERE item_id = ${item_id}`
   );
   db.end();
   return newResults;
}

export async function getUser(email) {
   const db = await connectToDB();
   const [results] = await db.execute(
      `SELECT * FROM quetzal.Players WHERE email = \'${email}\'`
   );
   if (!results[0]) {
      return null;
   }
   const userData = results[0];
   const {slot_1, slot_2, slot_3} = userData;
   const slots = [slot_1, slot_2, slot_3];
   for (let i = 0; i < slots.length; i++) {
      if (slots[i] !== null) {
         const [session] = await db.execute(
            `SELECT * FROM quetzal.Sessions WHERE session_id = ${slots[i]}`
         );
         const sessionData = session[0];
         delete sessionData.email;
         const slot = `slot_${i + 1}`;
         userData[slot] = sessionData;
      }
   }
   db.end();
   return userData;
}

// takes session id and sets finished flag from 0 to 1
// retrieves user email
// user table gets updated with runs + 1
export async function endSession(session_id) {
   const db = await connectToDB();
   const [results] = await db.execute(
      `UPDATE quetzal.Sessions SET finished = 1 WHERE session_id = \'${session_id}\'`
   );
   const email = await db.execute(
      `SELECT email FROM quetzal.Sessions WHERE session_id = \'${session_id}\'`
   );

   await db.execute(
      `UPDATE quetzal.Players SET runs = runs + 1 WHERE email = \'${email}\'`
   );
   db.end();
   return results;
}

// takes session id and nullifies the slot in the user table that corresponds to the session id
export async function clearSlot(session_id) {
   const db = await connectToDB();
   const [rows] = await db.execute(
      `SELECT slot_1, slot_2, slot_3 FROM quetzal.Players WHERE slot_1 = ${session_id} OR slot_2 = ${session_id} OR slot_3 = ${session_id}`
   );

   if (rows.length === 0) {
      throw new Error(`No rows found for session ID ${session_id}`);
   }

   const row = rows[0];

   const columnToUpdate =
      row.slot_1 === session_id
         ? "slot_1"
         : row.slot_2 === session_id
         ? "slot_2"
         : row.slot_3 === session_id
         ? "slot_3"
         : null;

   if (!columnToUpdate) {
      throw new Error(`Session ID ${session_id} not found in any slot columns`);
   }

   const [results] = await db.execute(
      `UPDATE quetzal.Players SET ${columnToUpdate} = NULL WHERE ${columnToUpdate} = ${session_id}`
   );

   db.end();
   return results;
}

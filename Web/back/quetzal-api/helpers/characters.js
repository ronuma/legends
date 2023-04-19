import connectToDB from "../index.js";

export async function getNPCs() {
   const db = await connectToDB();
   const [results, fields] = await db.execute("SELECT * FROM quetzal.NPCs");
   return results;
}

export async function getEnemies() {
   const db = await connectToDB();
   const [results, fields] = await db.execute("SELECT * FROM quetzal.Enemies");
   return results;
}

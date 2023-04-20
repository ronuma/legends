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

export async function getHeroes() {
   const db = await connectToDB();
   const [results, fields] = await db.execute("SELECT * FROM quetzal.Heroes");
   return results;
}

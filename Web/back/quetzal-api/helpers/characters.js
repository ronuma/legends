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
// Please finish splitting results into a dictionary with id : [array of dialogs]
export async function getDialogs() {
   const db = await connectToDB();
   const [results, fields] = await db.execute("SELECT * FROM quetzal.Dialogs");
   return results;
}
import connectToDB from "../index.js";

export async function getData() {
   const db = await connectToDB();
   const [results, fields] = await db.execute("SELECT * FROM quetzal.Players");
   return results;
}

export async function getStats() {
   const db = await connectToDB();
   const [results, fields] = await db.execute("SELECT * FROM quetzal.Sessions");
   return results;
}

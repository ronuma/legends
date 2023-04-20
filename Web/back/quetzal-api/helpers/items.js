import connectToDB from "../index.js";

export async function getItems() {
   const db = await connectToDB();
   const [results, fields] = await db.execute("SELECT * FROM quetzal.Items");
   return results;
}

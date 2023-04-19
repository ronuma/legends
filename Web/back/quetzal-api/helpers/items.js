import connectToDB from "../index.js";

export async function getItems() {
   const db = await connectToDB();
   const [results, fields] = await db.execute("select * from Items");
   return results;
}

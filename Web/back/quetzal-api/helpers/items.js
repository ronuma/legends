import connectToDB from "../api/index.js";

export async function getItems() {
   const db = await connectToDB();
   const [results, fields] = await db.execute(
      "SELECT * FROM quetzal.Items ORDER BY item_id"
   );
   db.end();
   return results;
}

export async function getItem(id) {
   const db = await connectToDB();
   const [results, fields] = await db.execute(
      "SELECT * FROM quetzal.Items WHERE item_id = ?",
      [id]
   );
   db.end();
   return results;
}

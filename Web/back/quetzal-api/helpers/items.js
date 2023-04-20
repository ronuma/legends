import connectToDB from "../index.js";

export async function getItems() {
   const db = await connectToDB();
   const [results, fields] = await db.execute("SELECT * FROM quetzal.Items");
   return results;
}

export async function getItem(id) {
   const db = await connectToDB();
   const [results, fields] = await db.execute(
      "SELECT * FROM quetzal.Items WHERE item_id = ?",
      [id]
   );
   return results;
}

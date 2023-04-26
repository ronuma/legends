import {response} from "express";
import connectToDB from "../index.js";

export async function getNPCs() {
   const db = await connectToDB();
   const [results, fields] = await db.execute("SELECT * FROM quetzal.NPCs");
   db.end();
   return results;
}

export async function getEnemies() {
   const db = await connectToDB();
   const [results, fields] = await db.execute("SELECT * FROM quetzal.Enemies");
   db.end();
   return results;
}

export async function getHeroes() {
   const db = await connectToDB();
   const [results, fields] = await db.execute("SELECT * FROM quetzal.Heroes");
   db.end();
   return results;
}
// Please finish splitting results into a dictionary with id : [array of dialogs]
export async function getDialogs() {
   const db = await connectToDB();
   const [results, fields] = await db.execute("SELECT * FROM quetzal.Dialogs");
   let filtered_results = results.map(item => {
      return {
         dialog_id: item.dialog_id,
         text: item.text.split("/{*"),
      };
   });
   return filtered_results;
}

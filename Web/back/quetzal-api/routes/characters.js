import {Router} from "express";

import {getNPCs, getEnemies, getHeroes} from "../helpers/characters.js";

const router = Router();

router.get("/NPCs", async (req, res) => {
   // needs to get all NPCs and their dialogues
   try {
      const data = await getNPCs();
      if (!data) {
         res.status(404).json({
            msg: "No npcs found",
         });
         return;
      }
      res.status(200).json(data);
   } catch (error) {
      console.log("GET npcs error: ", error);
      res.status(500).json({
         msg: "GET npcs error",
         error,
      });
   }
});

router.get("/enemies", async (req, res) => {
   // done: gets all enemies
   try {
      const data = await getEnemies();
      if (!data) {
         res.status(404).json({
            msg: "No enemies found",
         });
         return;
      }
      res.status(200).json(data);
   } catch (error) {
      console.log("GET enemies error: ", error);
      res.status(500).json({
         msg: "GET enemies error",
         error,
      });
   }
});

router.get("/heroes", async (req, res) => {
   // done: gets all heroes
   try {
      const data = await getHeroes();
      if (!data) {
         res.status(404).json({
            msg: "No heroes found",
         });
         return;
      }
      res.status(200).json(data);
   } catch (error) {
      console.log("GET heroes error: ", error);
      res.status(500).json({
         msg: "GET heroes error",
         error,
      });
   }
});

export default router;

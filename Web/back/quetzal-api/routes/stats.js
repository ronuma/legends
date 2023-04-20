import {Router} from "express";

import {getStats} from "../helpers/stats.js";

const router = Router();

router.get("/", async (req, res) => {
   try {
      const data = await getStats();
      if (!data) {
         res.status(404).json({
            msg: "No stats found",
         });
         return;
      }
      res.status(200).json(data);
   } catch (error) {
      console.log("GET stats error: ", error);
      res.status(500).json({
         msg: "GET stats error",
         error,
      });
   }
});

export default router;

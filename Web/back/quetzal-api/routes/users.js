import {Router} from "express";

import {getStats, getData, addData} from "../helpers/users.js";

const router = Router();

router.get("/stats", async (req, res) => {
   try {
      const data = await getStats();
      if (!data) {
         res.status(404).json({
            msg: "No user stats found",
         });
         return;
      }
      res.status(200).json(data);
   } catch (error) {
      console.log("GET user stats error: ", error);
      res.status(500).json({
         msg: "GET user stats error",
         error,
      });
   }
});

router.get("/data", async (req, res) => {
   try {
      const data = await getData();
      if (!data) {
         res.status(404).json({
            msg: "No user data found",
         });
         return;
      }
      res.status(200).json(data);
   } catch (error) {
      console.log("GET user data error: ", error);
      res.status(500).json({
         msg: "GET user data error",
         error,
      });
   }
});

router.post("/add", async (req, res) => {
   try {
      console.log("req: ", req);
      const {email, user_name} = req.body;

      const data = await addData(email, user_name);
      if (!data) {
         res.status(404).json({
            msg: "User data not added",
         });
         return;
      }
      res.status(200).json({
         msg: "User data added",
         data,
      });
   } catch (error) {
      console.log("POST user data error: ", error);
      res.status(500).json({
         msg: "POST user data error",
         error,
      });
   }
});

export default router;

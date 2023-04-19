import connectToDB from "../index";

export default getItems = async () => {
  const db = await connectToDB();
  const [results, fields] = await db.execute("select * from Items");
  return results;
};

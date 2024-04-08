import { Project } from "@/models/project";
import { useEffect, useState } from "react";

const baseurl = "";
const Home = () => {
  const [data, setData] = useState([]);

  async function GetProjects() {
    try {
        const response = await fetch(baseurl);
        if (!response.ok) throw new Error("HTTP error " + response.status);
        const data = await response.json();
        setData(data);
    } catch (error) {
        console.error('Error fetching projects:', error);
    }
  }

  useEffect(() => {
    GetProjects();
  }, [])

  return (
    <div>
      <h1>Home Page</h1>
    </div>
  );
};

export default Home;

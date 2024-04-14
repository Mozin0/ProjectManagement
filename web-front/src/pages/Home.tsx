import { DataTable } from "@/components/ui/custom/customTable";
import { Project } from "@/models/project";
import { useEffect, useState } from "react";
import { columns as projectTableColumns } from '@/components/ui/custom/projectTableColumns';

const baseurl = "http://localhost:5159/api/v1";


const Home = () => {
  const [data, setData] = useState<Project[]>([]);

  async function getProjects() {
    try {
      const response = await fetch(baseurl + "/projects");
      if (!response.ok) throw new Error("HTTP error " + response.status);
      const data = await response.json();
      setData(data);
    } catch (error) {
      console.error("Error fetching projects:", error);
    }
  }

  useEffect(() => {
    getProjects();
  }, []);

  return (
    <div>
      <DataTable columns={projectTableColumns} data={data} />
    </div>
  );
};

export default Home;

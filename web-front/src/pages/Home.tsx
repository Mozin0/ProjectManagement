import { DataTable } from "@/components/data-table/data-table";
import { Project } from "@/models/project";
import { useEffect, useState } from "react";
import { columns } from "@/components/projectColumns";
import { fetchProjects } from "@/api/projectsApi";
const Home = () => {
  const [data, setData] = useState<Project[]>([]);

  async function getProjects() {
   var projects = await fetchProjects();
   setData(projects);
  }

  useEffect(() => {
    getProjects();
  }, []);

  return (
    <div>
      <DataTable columns={columns} data={data} />
    </div>
  );
};

export default Home;

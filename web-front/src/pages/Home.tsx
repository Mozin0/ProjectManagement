import { DataTable } from "@/components/data-table/data-table";
import { Project } from "@/models/project";
import { useEffect, useState } from "react";
import { columns } from "@/components/projectColumns";
import { fetchProjects } from "@/api/projectsApi";
import { Guid } from "guid-typescript";

const Home = () => {
  const [data, setData] = useState<Project[]>([]);

  async function getProjects() {
    var projects = await fetchProjects();
    setData(projects);
  }

  useEffect(() => {
    getProjects();
  }, []);

  useEffect(() => {
    if (data.length === 0) {
      const dummyData: Project[] = Array.from({ length: 25 }, (_, index) => ({
        id: Guid.create(),
        name: `Dummy Project ${index + 1}`,
        createdDate: new Date(),
        tasks: [],
        statusId: 0,
        status: undefined,
      }));
      setData(dummyData);
    }
  }, [data]);

  return (
    <div>
      <DataTable columns={columns} data={data} />
    </div>
  );
};

export default Home;

import { DataTable } from "@/components/data-table/data-table";
import { Task } from "@/models/task";
import { useEffect, useState } from "react";
import { fetchTasks } from "@/api/taskApi";
import { columns } from "@/components/data-table/taskColumns";
import CreateModal from "@/components/data-table/createModal";

const Tasks = () => {
  const [data, setData] = useState<Task[]>([]);
  const [open, setOpen] = useState(false);
  const [taskName, setTaskName] = useState("");
  const [date, setDate] = useState<Date>();

  async function getTasks(projectId: string) {
    const tasks = await fetchTasks(projectId);
    setData(tasks);
  }

  useEffect(() => {
    const projectId = location.pathname.split("/")[1];
    getTasks(projectId);
  }, []);

  function addNewTask() {

  }
  
  function createTaskModal() {
    return (
      <CreateModal
        name={"Task"}
        openDialog={open}
        setOpenDialog={setOpen}
        objectName={taskName}
        setObjectName={setTaskName}
        create={addNewTask}
        date={date}
        setDate={setDate}
      />
    );
  }

  return (
    <div>
      <DataTable
        columns={columns}
        data={data}
        createForm={createTaskModal}
        placeholder={"Tasks"}
        clickableRow={false}
      ></DataTable>
    </div>
  );
};

export default Tasks;

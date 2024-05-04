import { Task } from "@/models/task";

const baseurl = "http://localhost:5159/api/v1/tasks";

export async function fetchTasks(projectId: string): Promise<Task[]> {
  try {
    const response = await fetch(`${baseurl}/project/${projectId}`);
    if (!response.ok) throw new Error("HTTP error " + response.status);
    const data = await response.json();
    return data;
  } catch (error) {
    console.log("Error fetching project's tasks" + error);
    throw error;
  }
}

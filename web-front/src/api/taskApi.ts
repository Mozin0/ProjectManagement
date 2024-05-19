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

export async function addTask(task: Task): Promise<Task> {
  try {
    if (task !== null) {
      const response = await fetch(baseurl, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(task),
      });
      if (!response.ok) throw new Error("HTTP error " + response.status);
      const addedTask = await response.json();
      return addedTask;
    } else {
      throw new Error("Task is null");
    }
  } catch (error) {
    console.log("Error Adding Task", error);
    throw error;
  }
}

export async function updateProject(id: string, task: Task): Promise<Task> {
  try {
    if (task !== null) {
      const response = await fetch(`${baseurl}/projects/${id}`, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(task),
      });
      if (!response.ok) throw new Error("HTTP error " + response.status);
      const updatedTask = await response.json();
      return updatedTask;
    } else {
      throw new Error("Task is null");
    }
  } catch (error) {
    console.log("Error Updating Task", error);
    throw error;
  }
}

export async function deleteTask(id: string): Promise<void> {
  try {
    const response = await fetch(`${baseurl}/projects/${id}`, {
      method: "DELETE",
    });
    if (!response.ok) throw new Error("HTTP error " + response.status);
    console.log("Task Deleted Successfully");
  } catch (error) {
    console.error("Error Deleting Task:", error);
    throw error;
  }
}

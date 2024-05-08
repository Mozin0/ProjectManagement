import { Project } from "@/models/project";
import { Guid } from "guid-typescript";

const baseurl = "http://localhost:5159/api/v1";

export async function fetchProjects(): Promise<Project[]> {
  try {
    const response = await fetch(baseurl + "/projects");
    if (!response.ok) throw new Error("HTTP error " + response.status);
    const data = await response.json();
    return data;
  } catch (error) {
    console.error("Error fetching projects:", error);
    throw error;
  }
}

export async function fetchProjectById(id: Guid): Promise<Project> {
  try {
    const response = await fetch(baseurl + "/projects/" + id);
    if (!response.ok) throw new Error("HTTP error " + response.status);
    const data = await response.json();
    return data;
  } catch (error) {
    console.error("Error fetching projects:", error);
    throw error;
  }
}

export async function addProject(project: Project): Promise<Project> {
  try {
    if (project !== null) {
      const response = await fetch(baseurl + "/projects", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(project),
      });
      if (!response.ok) throw new Error("HTTP error " + response.status);
      const addedProject = await response.json();
      return addedProject;
    } else {
      throw new Error("Project is null");
    }
  } catch (error) {
    console.log("Error Adding Project", error);
    throw error;
  }
}

export async function updateProject(id: string, project: Project): Promise<Project> {
  try {
    if (project !== null) {
      const response = await fetch(baseurl + "/projects", {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(project),
      });
      if (!response.ok) throw new Error("HTTP error " + response.status);
      const updatedProject = await response.json();
      return updatedProject;
    } else {
      throw new Error("Project is null");
    }
  } catch (error) {
    console.log("Error updating Project", error);
    throw error;
  }
}

export async function deleteProject(id: string) : Promise<void> {
  try {
    const response = await fetch(`${baseurl}/projects/${id}`, {
      method: "DELETE",
    });
    if (!response.ok) throw new Error("HTTP error " + response.status);
    console.log("Project deleted successfully");
  } catch (error) {
    console.error("Error deleting project:", error);
    throw error;
  }
}

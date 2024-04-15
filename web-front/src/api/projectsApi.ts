import { Project } from "@/models/project";

const baseurl = "http://localhost:5159/api/v1";

export async function fetchProjects() : Promise<Project[]> {
    try {
      const response = await fetch(baseurl + "/projects");
      if (!response.ok) throw new Error("HTTP error " + response.status);
      const data = await response.json();
      return data
    } catch (error) {
      console.error("Error fetching projects:", error);
      throw error;
    }
  }

 export async function addProject(project: Project) : Promise<Project> {
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
      }
      else {    
        throw new Error("Project is null"); 
      }
    } catch (error) {
      console.log("Error Adding Project", error);
      throw error;
    }
  }
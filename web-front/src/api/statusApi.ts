import { Status } from "@/models/status";

const baseurl = "http://localhost:5159/api/v1";

export async function fetchStatuses(): Promise<Status[]> {
  try {
    const response = await fetch(baseurl + "/statuses");
    if (!response.ok) throw new Error("HTTP error " + response.status);
    const data = await response.json();
    return data;
  } catch (error) {
    console.error("Error fetching statuses:", error);
    throw error;
  }
}

export async function fetchStatusById(id: number) : Promise<Status> {
    try {
      const response = await fetch(baseurl + "/statuses/" + id);
      if (!response.ok) throw new Error("HTTP error " + response.status);
      const data = await response.json();
      return data
    } catch (error) {
      console.error("Error Fetching Status:", error);
      throw error;
    }
  }

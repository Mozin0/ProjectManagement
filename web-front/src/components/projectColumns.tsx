import { Project } from "@/models/project";
import { ColumnDef } from "@tanstack/react-table";

export const columns: ColumnDef<Project>[] = [ 
    {
      accessorKey: "name",
      header: "Name",
    },
    {
      accessorKey: "createdDate",
      header: "Created",
      cell: (cellData) => {
          const dateString = cellData.getValue() as string;
          const date = new Date(dateString);
  
          const day = date.getDate().toLocaleString().padStart(2, "0");
          const month = (date.getMonth() + 1).toString().padStart(2, "0"); // Month is zero-indexed
          const year = date.getFullYear().toString().slice(-2); // Extract last two digits of the year
  
          return `${day}/${month}/${year}`
      }
    },
    {
      accessorKey: "statusId",
      header: "Status",
      cell: (cellData) => {
        switch (cellData.getValue()) {
          case 1:
            return "Pending";
          default:
            return "No Status";
        }
      },
    },
  ];
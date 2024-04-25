import { Guid } from "guid-typescript";
import { Status } from "./status";
import { Project } from "./project";

export class Task {
  id: string;
  name: string;
  createdDate: Date;
  deadline: string;
  parentTaskId?: Guid;
  parentTask?: Task;
  subTasks?: Task[] = [];
  projectId: Guid;
  project?: Project;
  statusId?: number;
  status?: Status;

  constructor(
    id: string,
    name: string,
    createdDate: Date,
    projectId: Guid,
    project: Project,
    statusId: number,
    status: Status,
    deadline: string,
    parentTaskId?: Guid,
    parentTask?: Task,
    subTasks?: Task[],
  ) {
    this.id = id;
    this.name = name;
    this.createdDate = createdDate;
    this.deadline = deadline;
    this.parentTaskId = parentTaskId;
    this.parentTask = parentTask;
    this.projectId = projectId;
    this.project = project;
    this.subTasks = subTasks;
    this.statusId = statusId;
    this.status = status;
  }
}

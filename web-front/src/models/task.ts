import { Guid } from "guid-typescript";
import { Status } from "./status";
import { Project } from "./project";

export class Task {
  id: Guid;
  name: string;
  createdDate: Date;
  deadline: Date;
  parentTaskId?: Guid;
  parentTask?: Task;
  subTasks: Task[] = [];
  projectId: Guid;
  project?: Project;
  statusId?: number;
  status?: Status;

  constructor(
    id: Guid,
    name: string,
    createdDate: Date,
    deadline: Date,
    parentTaskId: Guid,
    parentTask: Task,
    subTasks: Task[],
    projectId: Guid,
    project: Project,
    statusId: number,
    status: Status
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

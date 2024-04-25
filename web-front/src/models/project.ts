import { Task } from './task';
import { Status } from './status';

export class Project {
    id: string;
    name: string;
    createdDate: Date = new Date();
    deadline: string;
    tasks?:  Task[] = [];
    statusId?: number;
    status?: Status;

    constructor(id: string,  name: string,  createdDate: Date, statusId: number, deadline: string, tasks?: Task[], status?: Status) {
        this.id = id;
        this.name = name;
        this.createdDate = createdDate;
        this.deadline = deadline;
        this.tasks = tasks;
        this.statusId = statusId;
        this.status = status;
    }
}
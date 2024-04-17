import {Guid} from 'guid-typescript'
import { Task } from './task';
import { Status } from './status';

export class Project {
    id: Guid;
    name: string;
    createdDate: Date;
    tasks:  Task[] = [];
    statusId?: number;
    status?: Status;

    constructor(id: Guid,  name: string,  createdDate: Date, tasks: Task[], statusId: number, status: Status) {
        this.id = id;
        this.name = name;
        this.createdDate = createdDate;
        this.tasks = tasks;
        this.statusId = statusId;
        this.status = status;
    }
}
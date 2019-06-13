import { Injectable } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs';
import { HttpClient } from '@angular/common/http';

interface ExposableTask {
	name: string;
	employees: Array<number>;
	department_id: number;
	due_date: Date;
}

export interface Task extends ExposableTask {
	id: number;
	finished: boolean;
}

@Injectable({
	providedIn: 'root'
})
export class TasksService {
	private _tasks: BehaviorSubject<Task[]> = new BehaviorSubject([]);
	readonly API = 'http://i875395.hera.fhict.nl/api/390228/task';
	public tasks: Observable<Task[]> = this._tasks.asObservable();

	constructor(private http: HttpClient) {
		this.reloadTasks();
	}

	public getTasks(): Observable<Task[]> {
		return this.tasks;
	}

	public createTask(task: ExposableTask) {
		this.http.post(this.API, task).subscribe(() => {
			this.reloadTasks();
		});
	}

	public deleteTask(id: number) {
		this.http.delete(this.API + '?id=' + id).subscribe(() => {
			this.reloadTasks();
		});
	}

	public updateTask(updatedTask: Task) {
		this.http.put(this.API + '?id=' + updatedTask.id, updatedTask).subscribe(() => {
			this.reloadTasks();
		});
	}

	private reloadTasks() {
		this.http.get<Task[]>(this.API).subscribe((tasks) => {
			console.log(tasks);
			this._tasks.next(tasks);
		});
	}

	public getTask(id: number): Task | null {
		const tasks = this._tasks.getValue().filter((task) => task.id === id);
		if (tasks.length > 0) {
			return tasks[0];
		}
		return null;
	}
}

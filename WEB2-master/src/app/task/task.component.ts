import { HttpClient } from '@angular/common/http';
import { EmployeeService } from './../employee services/employee.service';
import { DepartmentService } from './../services/department.service';
import { TasksService } from './../services/tasks.service';
import { Component, OnInit, Input } from '@angular/core';
import { Task } from '../services/tasks.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
	selector: 'app-task',
	templateUrl: './task.component.html'
})
export class TaskComponent implements OnInit {
	@Input() task: Task;
	public department = '';
	public employee = '';

	constructor(private tasksService: TasksService, private modalService: NgbModal, private http: HttpClient) {}

	ngOnInit() {
		this.http.get('http://i875395.hera.fhict.nl/api/384741/department').subscribe((d: Array<any>) => {
			const department: any = d.filter((dd) => dd.id === this.task.department_id);
			this.department = department[0] ? department.name : 'No department';
		});

		this.http.get('http://i875395.hera.fhict.nl/api/384741/employee').subscribe((d: Array<any>) => {
			const employee: any = d.filter((dd) => dd.id === this.task.employees[0]);
			this.employee = employee[0] ? employee.first_name + ' ' + employee.last_name : 'No employee';
		});
	}

	public changeStatus() {
		this.tasksService.updateTask({ ...this.task, name: this.task.name });
	}

	public changeDescription(name: string) {
		this.tasksService.updateTask({ ...this.task, name });
	}

	public deleteTask() {
		this.tasksService.deleteTask(this.task.id);
	}

	public open(content: string) {
		this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' });
	}

	public getDepartment() {
		return this.department;
	}

	public getEmployees() {
		return [ this.employee ];
	}
}

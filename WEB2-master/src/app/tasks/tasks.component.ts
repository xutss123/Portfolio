import { DepartmentService, Department } from './../services/department.service';
import { EmployeeService } from './../employee services/employee.service';
import { Employee } from './../employee services/employee.service';
import { TasksService, Task } from './../services/tasks.service';
import { Component, OnInit } from '@angular/core';

@Component({
	selector: 'app-tasks',
	templateUrl: './tasks.component.html'
})
export class TasksComponent implements OnInit {
	public tasks: Array<Task>;
	public employees: Array<Employee>;
	public departments: Array<Department>;
	public search = '';

	constructor(
		private tasksService: TasksService,
		private employeeService: EmployeeService,
		private departmentService: DepartmentService
	) {}

	ngOnInit() {
		this.getTasks();
		this.getEmployees();
		this.getDepartments();
	}

	private getTasks() {
		this.tasksService.getTasks().subscribe((tasks) => (this.tasks = tasks));
	}

	private getEmployees() {
		this.employeeService.getEmployees().subscribe((employees) => (this.employees = employees));
	}

	private getDepartments() {
		this.departmentService.getDepartments().subscribe((departments) => (this.departments = departments));
	}

	public addTask(name: string, employee: number, department: number) {
		this.tasksService.createTask({
			name,
			department_id: 168,
			employees: [ Number(employee) ],
			due_date: null
		});
	}

	public searchTask() {
		if (this.search === '') {
			return [];
		}
		return this.tasks.filter((task) => task.name.toLowerCase().startsWith(this.search.toLowerCase()));
	}
}
